﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// Licensed under the MulanPSL2 License. See LICENSE in the project root for license information.
// FileName:SysConfig
// Guid:826c51d5-2ef4-43cb-baf3-fc08fd843c19
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreatedTime:2022-05-08 下午 06:35:58
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

using SqlSugar;
using XiHan.Models.Bases.Entity;

namespace XiHan.Models.Syses;

/// <summary>
/// 系统配置表
/// </summary>
/// <remarks>记录新增，修改信息</remarks>
[SugarTable(TableName = "Sys_Config")]
public class SysConfig : BaseModifyEntity
{
    /// <summary>
    /// 网站名称
    /// </summary>
    [SugarColumn(Length = 20)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 网站描述
    /// </summary>
    [SugarColumn(Length = 200, IsNullable = true)]
    public string? Description { get; set; }

    /// <summary>
    /// 网站关键字
    /// </summary>
    [SugarColumn(Length = 200)]
    public string KeyWord { get; set; } = string.Empty;

    /// <summary>
    /// 网站域名
    /// </summary>
    [SugarColumn(Length = 50)]
    public string Domain { get; set; } = string.Empty;

    /// <summary>
    /// 站长名称
    /// </summary>
    [SugarColumn(Length = 20)]
    public string AdminName { get; set; } = string.Empty;

    /// <summary>
    /// 站长邮箱
    /// </summary>
    [SugarColumn(Length = 50)]
    public string AdminEmail { get; set; } = string.Empty;

    /// <summary>
    /// 升级时间
    /// </summary>
    [SugarColumn(IsNullable = true)]
    public DateTime? UpdateTime { get; set; }
}