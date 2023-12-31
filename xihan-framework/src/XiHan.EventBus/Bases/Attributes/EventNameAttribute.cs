﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2023 ZhaiFanhua All Rights Reserved.
// Licensed under the MulanPSL2 License. See LICENSE in the project root for license information.
// FileName:EventNameAttribute
// Guid:d3b8bae6-803c-47a7-bf97-b84364ae8cec
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2023/12/31 10:36:47
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

namespace XiHan.EventBus.Bases.Attributes;

/// <summary>
/// 事件名称属性
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class EventNameAttribute : Attribute
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="name"></param>
    public EventNameAttribute(string name)
    {
        this.Name = name;
    }

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; init; }
}