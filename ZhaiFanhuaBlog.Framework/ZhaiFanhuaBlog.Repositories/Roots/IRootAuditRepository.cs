﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:IRootAuditRepository
// Guid:ee309ebd-b345-4396-8feb-7f704cd0544f
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-05-08 下午 09:18:45
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

using ZhaiFanhuaBlog.Core.Services;
using ZhaiFanhuaBlog.Models.Roots;
using ZhaiFanhuaBlog.Repositories.Bases;

namespace ZhaiFanhuaBlog.Repositories.Roots;

/// <summary>
/// IRootAuditRepository
/// </summary>
public interface IRootAuditRepository : IBaseRepository<RootAudit>, IScopeDependency
{
}