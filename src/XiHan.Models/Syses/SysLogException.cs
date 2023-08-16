﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// Licensed under the MulanPSL2 License. See LICENSE in the project root for license information.
// FileName:SysLogException
// Guid:0b64e03b-c87c-4c6e-9262-7e4f5e507ce2
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreatedTime:2022-05-08 下午 06:37:47
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

using SqlSugar;
using XiHan.Models.Bases.Attributes;
using XiHan.Models.Bases.Entities;

namespace XiHan.Models.Syses;

/// <summary>
/// 系统异常日志表
/// </summary>
/// <remarks>记录新增信息</remarks>
[SystemTable]
[SugarTable(TableName = "Sys_Log_Exception")]
public class SysLogException : BaseCreateEntity
{
    /// <summary>
    /// 日志级别
    /// </summary>
    [SugarColumn(Length = 16, IsNullable = true)]
    public string? Level { get; set; }

    /// <summary>
    /// 触发线程
    /// </summary>
    [SugarColumn(IsNullable = true)]
    public int? Thread { get; set; }

    /// <summary>
    /// 出错文件
    /// </summary>
    [SugarColumn(Length = 256, IsNullable = true)]
    public string? File { get; set; }

    /// <summary>
    /// 出错行号
    /// </summary>
    [SugarColumn(IsNullable = true)]
    public int Line { get; set; }

    /// <summary>
    /// 请求类名
    /// </summary>
    [SugarColumn(Length = 256, IsNullable = true)]
    public string? Class { get; set; }

    /// <summary>
    /// 事件对象
    /// </summary>
    [SugarColumn(Length = 256, IsNullable = true)]
    public string? Event { get; set; }

    /// <summary>
    /// 消息描述
    /// </summary>
    [SugarColumn(Length = 512, IsNullable = true)]
    public string? Message { get; set; }

    /// <summary>
    /// 错误详情
    /// </summary>
    [SugarColumn(ColumnDataType = StaticConfig.CodeFirst_BigString, IsNullable = true)]
    public string? Exception { get; set; }
}