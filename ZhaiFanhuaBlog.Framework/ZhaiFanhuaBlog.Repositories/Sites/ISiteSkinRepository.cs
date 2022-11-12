﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:ISiteSkinRepository
// Guid:0739390d-6294-475e-8694-8d201d2f251e
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-05-08 下午 09:22:54
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

using ZhaiFanhuaBlog.Core.Services;
using ZhaiFanhuaBlog.Models.Sites;
using ZhaiFanhuaBlog.Repositories.Bases;

namespace ZhaiFanhuaBlog.Repositories.Sites;

/// <summary>
/// ISiteSkinRepository
/// </summary>
public interface ISiteSkinRepository : IBaseRepository<SiteSkin>, IScopeDependency
{
}