﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// Licensed under the MulanPSL2 License. See LICENSE in the project root for license information.
// FileName:SysUser
// Guid:5c92c656-8955-4343-8e6f-7ba028f1eab4
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreatedTime:2022-05-08 下午 04:30:03
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

using SqlSugar;
using XiHan.Models.Bases;

namespace XiHan.Models.Syses;

/// <summary>
/// 系统用户表
/// </summary>
/// <remarks> 记录新增，修改，删除，审核，状态信息</remarks>
[SugarTable(TableName = "Sys_User")]
public class SysUser : BaseEntity
{
    #region 账号信息

    /// <summary>
    /// 用户账号
    /// </summary>
    [SugarColumn(Length = 20)]
    public virtual string Account { get; set; } = string.Empty;

    /// <summary>
    /// 用户密码（MD5加密）
    /// </summary>
    [SugarColumn(Length = 64)]
    public virtual string Password { get; set; } = string.Empty;

    /// <summary>
    /// 用户昵称
    /// </summary>
    [SugarColumn(Length = 20)]
    public string NickName { get; set; } = string.Empty;

    /// <summary>
    /// 头像路径
    /// </summary>
    [SugarColumn(Length = 512)]
    public string AvatarPath { get; set; } = @"/Images/Accounts/Avatar/default.png";

    /// <summary>
    /// 签名
    /// </summary>
    [SugarColumn(Length = 256, IsNullable = true)]
    public string? Signature { get; set; }

    #endregion

    #region 基本信息

    /// <summary>
    /// 姓名
    /// </summary>
    [SugarColumn(IsNullable = true, Length = 10)]
    public virtual string RealName { get; set; } = string.Empty;

    /// <summary>
    /// 性别
    /// 男(true)女(false)
    /// </summary>
    [SugarColumn(IsNullable = true)]
    public bool? Gender { get; set; }

    /// <summary>
    /// 邮箱
    /// </summary>
    [SugarColumn(Length = 64)]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// 手机号码
    /// </summary>
    [SugarColumn(IsNullable = true, Length = 11)]
    public string? Phone { get; set; }

    /// <summary>
    /// 生日
    /// </summary>
    [SugarColumn(IsNullable = true)]
    public DateTime? Birthday { get; set; }

    /// <summary>
    /// 地址
    /// </summary>
    [SugarColumn(Length = 256, IsNullable = true)]
    public string? Address { get; set; }

    #endregion

    #region 注册信息

    /// <summary>
    /// 注册来源
    /// </summary>
    [SugarColumn(Length = 64)]
    public string RegisterFrom { get; set; } = string.Empty;

    /// <summary>
    /// 注册Ip
    /// </summary>
    [SugarColumn(IsOnlyIgnoreUpdate = true, IsNullable = true, Length = 64)]
    public string? RegisterIp { get; set; }

    #endregion

    #region 登录信息

    /// <summary>
    /// 最新登录设备
    /// </summary>
    [SugarColumn(IsOnlyIgnoreInsert = true, IsNullable = true, Length = 128)]
    public string? LastLoginDevice { get; set; }

    /// <summary>
    /// 最新登录Ip
    /// </summary>
    [SugarColumn(IsOnlyIgnoreInsert = true, IsNullable = true, Length = 64)]
    public string? LastLoginIp { get; set; }

    /// <summary>
    /// 最新登录时间
    /// </summary>
    [SugarColumn(IsOnlyIgnoreInsert = true, IsNullable = true)]
    public DateTime? LastLoginTime { get; set; }

    #endregion

    #region 其他信息

    /// <summary>
    /// 是否超级管理员
    /// </summary>
    /// <returns></returns>
    public bool IsAdmin()
    {
        return IsAdmin(BaseId);
    }

    /// <summary>
    /// 是否超级管理员
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    private static bool IsAdmin(long userId)
    {
        return userId == 00000001L;
    }

    /// <summary>
    /// 所属角色集合
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public List<SysRole> SysRoles { get; set; } = new();

    /// <summary>
    /// 所属角色主键集合
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public List<long> SysRoleIds { get; set; } = new();

    #endregion
}