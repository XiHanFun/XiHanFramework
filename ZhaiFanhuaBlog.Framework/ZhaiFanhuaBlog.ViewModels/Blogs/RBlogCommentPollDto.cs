﻿// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:RBlogCommentPollDto
// Guid:98e48290-634a-4e1f-b1ad-cfa8d5ad1e8a
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-07-28 下午 10:54:26
// ----------------------------------------------------------------

using ZhaiFanhuaBlog.ViewModels.Bases.Fields;

namespace ZhaiFanhuaBlog.ViewModels.Blogs;

/// <summary>
/// RBlogCommentPollDto
/// </summary>
public class RBlogCommentPollDto : BaseFieldDto
{
    /// <summary>
    /// 点赞者
    /// </summary>
    public Guid AccountId { get; set; }

    /// <summary>
    /// 所属评论
    /// </summary>
    public Guid CommentId { get; set; }

    /// <summary>
    /// 赞(true)或踩(false)
    /// </summary>
    public bool IsPositive { get; set; } = true;
}