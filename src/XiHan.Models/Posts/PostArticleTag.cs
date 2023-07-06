﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// Licensed under the MulanPSL2 License. See LICENSE in the project root for license information.
// FileName:PostArticleTag
// Guid:7f74e0d5-2c12-492c-b849-9651624ef6ae
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreatedTime:2022-05-08 下午 06:33:08
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

using SqlSugar;
using XiHan.Models.Bases.Entity;

namespace XiHan.Models.Posts;

/// <summary>
/// 文章标签关联表
/// </summary>
/// <remarks>记录新增，修改信息</remarks>
[SugarTable(TableName = "Post_Article_Tag")]
public class PostArticleTag : BaseModifyEntity
{
    /// <summary>
    /// 关联文章
    /// </summary>
    public long ArticleId { get; set; }

    /// <summary>
    /// 关联标签
    /// </summary>
    public long TagId { get; set; }
}