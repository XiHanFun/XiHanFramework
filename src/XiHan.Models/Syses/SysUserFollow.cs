﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:SysUserFollow
// long:196d9961-eb5f-4e8d-807d-a29b87a0a4f9
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-05-08 下午 06:05:37
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

using SqlSugar;
using XiHan.Models.Bases.Entity;

namespace XiHan.Models.Syses;

/// <summary>
/// 用户关注表
/// </summary>
/// <remarks>记录创建信息</remarks>
[SugarTable(TableName = "Sys_User_Follow")]
public class SysUserFollow : BaseCreateEntity
{
    /// <summary>
    /// 关注用户
    /// </summary>
    public long FollowedUserId { get; set; }

    /// <summary>
    /// 备注名称
    /// </summary>
    [SugarColumn(Length = 20, IsNullable = true)]
    public string? RemarkName { get; set; }
}