﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:LifeTimeEnum
// Guid:2a8fb64c-6038-4cde-8ebc-03976c2c23e2
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-12-13 上午 01:18:02
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

using System.ComponentModel;

namespace ZhaiFanhuaBlog.Infrastructure.Enums;

/// <summary>
/// 生命周期
/// </summary>
public enum LifeTimeEnum
{
    /// <summary>
    /// 单例
    /// </summary>
    [Description("单例")]
    SINGLETON,

    /// <summary>
    /// 作用域
    /// </summary>
    [Description("作用域")]
    SCOPED,

    /// <summary>
    /// 瞬时
    /// </summary>
    [Description("瞬时")]
    TRANSIENT
}