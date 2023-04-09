﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:JwtTokenUtil
// Guid:df38addc-198d-4f69-aca1-5f3cc1c1c01b
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-09-29 上午 02:32:25
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XiHan.Infrastructure.Apps.Setting;
using XiHan.Utils.Console;
using XiHan.Utils.Object;

namespace XiHan.Extensions.Common.Auth;

/// <summary>
/// JwtTokenTool
/// </summary>
public static class JwtTokenUtil
{
    /// <summary>
    /// 颁发JWT字符串
    /// </summary>
    /// <param name="tokenModel"></param>
    /// <returns></returns>
    public static string JwtIssue(TokenModel tokenModel)
    {
        try
        {
            // 读取配置
            var issuer = AppSettings.Auth.JWT.Issuer.GetValue();
            var audience = AppSettings.Auth.JWT.Audience.GetValue();
            var symmetricKey = AppSettings.Auth.JWT.SymmetricKey.GetValue();
            var expires = AppSettings.Auth.JWT.Expires.GetValue();

            // Nuget引入：Microsoft.IdentityModel.Tokens
            var claims = new List<Claim>
            {
                new Claim("UserId", tokenModel.UserId.ToString()),
                new Claim("UserName", tokenModel.UserName??string.Empty),
                new Claim("NickName", tokenModel.NickName ?? string.Empty),
            };
            // 为了解决一个用户多个角色(比如：Admin,System)，用下边的方法
            List<string> rootRolesClaim = new(tokenModel.RootRoles.Split(','));
            claims.AddRange(rootRolesClaim.Select(role => new Claim("RootRole", role)));

            // 秘钥 (SymmetricSecurityKey 对安全性的要求，密钥的长度太短会报出异常)
            SymmetricSecurityKey signingKey = new(Encoding.UTF8.GetBytes(symmetricKey));
            SigningCredentials credentials = new(signingKey, SecurityAlgorithms.HmacSha256);

            // Nuget引入：System.IdentityModel.Tokens.Jwt
            JwtSecurityToken securityToken = new(
                // 自定义选项
                claims: claims,
                // 颁发者
                issuer: issuer,
                // 签收者
                audience: audience,
                // 秘钥
                signingCredentials: credentials,
                // 生效时间
                notBefore: DateTime.UtcNow,
                // 过期时间
                expires: DateTime.UtcNow.AddMinutes(expires)
            );
            var accessToken = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return accessToken;
        }
        catch (Exception ex)
        {
            var errorMsg = $"Jwt 字符串颁发失败";
            Log.Error(ex, errorMsg);
            errorMsg.WriteLineError();
            throw;
        }
    }

    /// <summary>
    /// 解析JWT字符串
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public static TokenModel JwtSerialize(string token)
    {
        try
        {
            var tokenModel = new TokenModel();
            var jwtHandler = new JwtSecurityTokenHandler();

            // 开始Token校验
            if (!token.IsNotEmptyOrNull() || !jwtHandler.CanReadToken(token)) return tokenModel;
            var jwtToken = jwtHandler.ReadJwtToken(token);
            List<Claim> claims = jwtToken.Claims.ToList();

            // 分离参数
            var userIdClaim = claims.FirstOrDefault(claim => claim.Type == "UserId")!;
            var userNameClaim = claims.FirstOrDefault(claim => claim.Type == "UserName")!;
            var nickNameClaim = claims.FirstOrDefault(claim => claim.Type == "NickName")!;
            var rootRolesClaim = claims.Where(claim => claim.Type == "RootRole").ToList();

            var userId = new Guid(userIdClaim.Value);
            var userName = userNameClaim.Value;
            var nickName = nickNameClaim.Value;
            var rootRoles = rootRolesClaim.Select(c => c.Value).ToList();

            tokenModel = new TokenModel
            {
                UserId = userId,
                UserName = userName,
                NickName = nickName,
                RootRoles = string.Join(',', rootRoles),
            };
            return tokenModel;
        }
        catch (Exception ex)
        {
            var errorMsg = $"Jwt 字符串解析失败";
            Log.Error(ex, errorMsg);
            errorMsg.WriteLineError();
            throw;
        }
    }

    /// <summary>
    /// Token安全验证，刷新Token用
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public static bool JwtTokenSafeVerify(string token)
    {
        try
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var symmetricKey = AppSettings.Auth.JWT.SymmetricKey.GetValue();
            // 秘钥 (SymmetricSecurityKey 对安全性的要求，密钥的长度太短会报出异常)
            SymmetricSecurityKey signingKey = new(Encoding.UTF8.GetBytes(symmetricKey));
            SigningCredentials credentials = new(signingKey, SecurityAlgorithms.HmacSha256);
            // 读取旧token
            var jwt = jwtHandler.ReadJwtToken(token);
            var verifyResult = jwt.RawSignature == JwtTokenUtilities.CreateEncodedSignature(jwt.RawHeader + "." + jwt.RawPayload, credentials);
            return verifyResult;
        }
        catch (Exception ex)
        {
            var errorMsg = $"Token 被篡改或无效";
            Log.Error(ex, errorMsg);
            errorMsg.WriteLineError();
            throw;
        }
    }
}

/// <summary>
/// Token 模型
/// </summary>
public class TokenModel
{
    /// <summary>
    /// 用户主键
    /// </summary>
    public Guid UserId { get; init; }

    /// <summary>
    /// 用户名称
    /// </summary>
    public string UserName { get; init; } = string.Empty;

    /// <summary>
    /// 用户昵称
    /// </summary>
    public string NickName { get; init; } = string.Empty;

    /// <summary>
    /// 用户角色
    /// </summary>
    public string RootRoles { get; init; } = string.Empty;
}