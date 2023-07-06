﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// Licensed under the MulanPSL2 License. See LICENSE in the project root for license information.
// FileName:SysUserCollectType
// Guid:8d28b4f1-d0cc-4857-9150-353deffa880d
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreatedTime:2022-05-08 下午 06:03:34
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

using SqlSugar;
using XiHan.Models.Bases;

namespace XiHan.Models.Syses;

/// <summary>
/// 用户收藏分类表
/// </summary>
/// <remarks>记录新增，修改，删除，审核，状态信息</remarks>
[SugarTable(TableName = "Sys_User_Collect_Type")]
public class SysUserCollectType : BaseEntity
{
    /// <summary>
    /// 父级收藏分类
    /// </summary>
    [SugarColumn(IsNullable = true)]
    public long? ParentId { get; set; }

    /// <summary>
    /// 收藏分类名称
    /// </summary>
    [SugarColumn(Length = 20, IsNullable = true)]
    public string CategoryName { get; set; } = string.Empty;

    /// <summary>
    /// 收藏分类描述
    /// </summary>
    [SugarColumn(Length = 50, IsNullable = true)]
    public string? CategoryRemark { get; set; }

    /// <summary>
    /// 收藏总数
    /// </summary>
    public int CollectCount { get; set; }
}