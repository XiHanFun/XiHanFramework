﻿// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:CustomJwtExtension
// Guid:fcc7eece-77f0-4f6c-bc50-fbb21dc9d96f
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-05-30 上午 02:25:36
// ----------------------------------------------------------------

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ZhaiFanhuaBlog.Models.Response;

namespace ZhaiFanhuaBlog.WebApi.Common.Extensions.DependencyInjection;

/// <summary>
/// CustomJwtExtension
/// </summary>
public static class CustomJwtExtension
{
    /// <summary>
    /// JWT扩展
    /// </summary>
    /// <param name="services"></param>
    /// <param name="config"></param>
    /// <returns></returns>
    public static IServiceCollection AddCustomJWT(this IServiceCollection services, IConfiguration config)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
                         {
                             options.SaveToken = true;
                             options.TokenValidationParameters = new TokenValidationParameters
                             {
                                 //是否验证颁发者
                                 ValidateIssuer = true,
                                 // 是否验证接收者
                                 ValidateAudience = true,
                                 // 是否调用对签名SecurityToken的SecurityKey进行验证
                                 ValidateIssuerSigningKey = true,
                                 // 是否验证失效时间
                                 ValidateLifetime = true,
                                 // 颁发者
                                 ValidIssuer = config.GetValue<string>("Configuration:Domain"),
                                 // 接收者
                                 ValidAudience = config.GetValue<string>("Configuration:Domain"),
                                 // 签名秘钥
                                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetValue<string>("Auth:JWT:IssuerSigningKey"))),
                                 // 设置过期缓冲时间,若为0，过期时间一到立即失效
                                 ClockSkew = TimeSpan.FromSeconds(config.GetValue<int>("Auth:JWT:ClockSkew")),
                             };
                             options.Events = new JwtBearerEvents
                             {
                                 OnAuthenticationFailed = context =>
                                 {
                                     // 如果过期，则把是否过期添加到返回头信息中
                                     if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                                     {
                                         context.Response.Headers.Add("Token-Expired", "true");
                                     }
                                     return Task.CompletedTask;
                                 },
                                 OnChallenge = context =>
                                 {
                                     // 跳过默认的处理逻辑，返回下面的模型数据
                                     context.HandleResponse();
                                     return Task.FromResult(ResultResponse.Unauthorized());
                                 }
                             };
                         });
        return services;
    }
}