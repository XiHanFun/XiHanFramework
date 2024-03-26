﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2024 ZhaiFanhua All Rights Reserved.
// Licensed under the MulanPSL2 License. See LICENSE in the project root for license information.
// FileName:SelectConditionEnum
// Guid:b8369754-0ee4-4369-bd18-c236fb49c5e9
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2024/1/29 20:56:31
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

using System.ComponentModel;

namespace XiHan.Common.Shared.Pages.Enums;

/// <summary>
/// 选择条件枚举
/// </summary>
public enum SelectConditionEnum
{
    /// <summary>
    /// 包含
    /// </summary>
    [Description("包含")]
    Contains,

    /// <summary>
    /// 等于
    /// </summary>
    [Description("等于")]
    Equal,

    /// <summary>
    /// 大于
    /// </summary>
    [Description("大于")]
    Greater,

    /// <summary>
    /// 大于等于
    /// </summary>
    [Description("大于等于")]
    GreaterEqual,

    /// <summary>
    /// 小于
    /// </summary>
    [Description("小于")]
    Less,

    /// <summary>
    /// 小于等于
    /// </summary>
    [Description("小于等于")]
    LessEqual,

    /// <summary>
    /// 不等于
    /// </summary>
    [Description("不等于")]
    NotEqual,

    /// <summary>
    /// 多个值执行包含比较
    /// </summary>
    [Description("多个值执行包含比较")]
    InWithContains,

    /// <summary>
    /// 多个值执行等于比较
    /// </summary>
    [Description("多个值执行等于比较")]
    InWithEqual,

    /// <summary>
    /// 在...之间
    /// </summary>
    [Description("在...之间")]
    Between,
}