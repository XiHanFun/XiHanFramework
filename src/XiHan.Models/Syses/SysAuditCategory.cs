﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:SysAuditCategory
// long:52830965-a1e7-4d56-b98e-2582f19d22d8
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-05-08 下午 06:48:09
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

using SqlSugar;
using XiHan.Models.Bases.Entity;

namespace XiHan.Models.Syses;

/// <summary>
/// 系统审核类型表
/// </summary>
[SugarTable(TableName = "Sys_Audit_Category")]
public class SysAuditCategory : BaseDeleteEntity
{
    /// <summary>
    /// 父级审核分类
    /// </summary>
    [SugarColumn(IsNullable = true)]
    public long? ParentId { get; set; }

    /// <summary>
    /// 分类名称
    /// </summary>
    [SugarColumn(Length = 20)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 审核等级
    /// </summary>
    public int Tier { get; set; } = 1;

    /// <summary>
    /// 分类描述
    /// </summary>
    [SugarColumn(Length = 50, IsNullable = true)]
    public string? Remark { get; set; }
}