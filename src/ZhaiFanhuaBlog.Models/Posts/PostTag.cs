﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:PostTag
// Guid:fa23fa92-d511-41b1-ac8d-1574fa01a3af
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-05-08 下午 06:31:06
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

using SqlSugar;
using ZhaiFanhuaBlog.Models.Bases;

namespace ZhaiFanhuaBlog.Models.Posts;

/// <summary>
/// 文章标签表
/// </summary>
public class PostTag : BaseEntity
{
    /// <summary>
    /// 标签别名
    /// </summary>
    [SugarColumn(Length = 20)]
    public string Alias { get; set; } = string.Empty;

    /// <summary>
    /// 标签名称
    /// </summary>
    [SugarColumn(Length = 20)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 标签描述
    /// </summary>
    [SugarColumn(Length = 50)]
    public string Remark { get; set; } = string.Empty;

    /// <summary>
    /// 文章总数
    /// </summary>
    public int ArticleCount { get; set; }
}