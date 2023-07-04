﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2023 ZhaiFanhua All Rights Reserved.
// FileName:BusinessTypeEnum
// Guid:c5476f41-ac11-4b2a-bd75-054b853efd23
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2023-04-20 下午 03:16:57
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

using System.ComponentModel;

namespace XiHan.Infrastructures.Apps.Logging;

/// <summary>
/// 业务操作类型
/// </summary>
public enum BusinessTypeEnum
{
    /// <summary>
    /// 其它
    /// </summary>
    [Description("其它")]
    Other = 0,

    /// <summary>
    /// 新增
    /// </summary>
    [Description("新增")]
    Create = 1,

    /// <summary>
    /// 修改
    /// </summary>
    [Description("修改")]
    Modify = 2,

    /// <summary>
    /// 删除
    /// </summary>
    [Description("删除")]
    Delete = 3,

    /// <summary>
    /// 授权
    /// </summary>
    [Description("授权")]
    Grant = 4,

    /// <summary>
    /// 导出
    /// </summary>
    [Description("导出")]
    Export = 5,

    /// <summary>
    /// 导入
    /// </summary>
    [Description("导入")]
    Import = 6,

    /// <summary>
    /// 强退
    /// </summary>
    [Description("强退")]
    Force = 7,

    /// <summary>
    /// 生成代码
    /// </summary>
    [Description("生成代码")]
    GenCode = 8,

    /// <summary>
    /// 清空数据
    /// </summary>
    [Description("清空数据")]
    Clean = 9
}