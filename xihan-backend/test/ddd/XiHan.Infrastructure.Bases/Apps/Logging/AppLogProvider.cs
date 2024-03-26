﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// Licensed under the MulanPSL2 License. See LICENSE in the project root for license information.
// FileName:AppLogProvider
// Guid:3cb34283-30a3-45cf-8cdb-599bb722a211
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreatedTime:2022-12-24 上午 02:07:04
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System.Text;

namespace XiHan.Infrastructure.Bases.Logging;

/// <summary>
/// 全局日志供应器
/// </summary>
public static class AppLogProvider
{
    /// <summary>
    /// 注册日志
    /// </summary>
    /// <param name="builder"></param>
    public static void RegisterLog(ILoggingBuilder builder)
    {
        const string infoPath = @"Logs/Info/_.log";
        const string waringPath = @"Logs/Waring/_.log";
        const string errorPath = @"Logs/Error/_.log";
        const string fatalPath = @"Logs/Fatal/_.log";
        const string debugPath = @"Logs/Debug/_.log";

        const string infoTemplate =
            @"Date：{Timestamp:yyyy-MM-dd HH:mm:ss.fff}{NewLine}Level：{Level}{NewLine}Message：{Message}{NewLine}================{NewLine}";
        const string warnTemplate =
            @"Date：{Timestamp:yyyy-MM-dd HH:mm:ss.fff}{NewLine}Level：{Level}{NewLine}Source：{SourceContext}{NewLine}Message：{Message}{NewLine}================{NewLine}";
        const string errorTemplate =
            @"Date：{Timestamp:yyyy-MM-dd HH:mm:ss.fff}{NewLine}Level：{Level}{NewLine}Source：{SourceContext}{NewLine}Message：{Message}{NewLine}Exception：{Exception}{NewLine}Properties：{Properties}{NewLine}================{NewLine}";

        Log.Logger = new LoggerConfiguration()
            // 日志调用类命名空间如果以 Microsoft 开头的其他日志进行重写，覆盖日志输出最小级别为 Warning
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Override("System", LogEventLevel.Warning)
#if DEBUG
            // 最小记录级别
            .MinimumLevel.Debug()
#endif
            .MinimumLevel.Information()
            // 记录相关上下文信息
            .Enrich.FromLogContext()
            .SinkFileConfig(LogEventLevel.Information, infoPath, infoTemplate)
            .SinkFileConfig(LogEventLevel.Warning, waringPath, warnTemplate)
            .SinkFileConfig(LogEventLevel.Error, errorPath, errorTemplate)
            .SinkFileConfig(LogEventLevel.Fatal, fatalPath, errorTemplate)
#if DEBUG
            .SinkFileConfig(LogEventLevel.Debug, debugPath, errorTemplate)
#endif
            .CreateLogger();
        builder.AddSerilog();
    }

    /// <summary>
    /// 返回写入文件对应级别配置
    /// </summary>
    /// <param name="config"></param>
    /// <param name="level"></param>
    /// <param name="filePath"></param>
    /// <param name="template"></param>
    /// <returns></returns>
    private static LoggerConfiguration SinkFileConfig(this LoggerConfiguration config, LogEventLevel level, string filePath, string template)
    {
        return config.WriteTo.Logger(log => log.Filter.ByIncludingOnly(lev => lev.Level == level)
            // 异步输出到文件
            .WriteTo.Async(newConfig => newConfig.File(
                // 配置日志输出到文件，文件输出到当前项目的 logs 目录下，linux 中大写会出错
                Path.Combine(AppContext.BaseDirectory, filePath).ToLowerInvariant(),
                // 生成周期：天
                rollingInterval: RollingInterval.Day,
                // 文件大小：10M，默认1GB
                fileSizeLimitBytes: 1024 * 1024 * 10,
                // 保留最近：60个文件，默认31个，等于null时永远保留文件
                retainedFileCountLimit: 60,
                // 超过大小自动创建新文件
                rollOnFileSizeLimit: true,
                // 最小写入级别
                restrictedToMinimumLevel: level,
                // 写入模板
                outputTemplate: template,
                // 编码
                encoding: Encoding.UTF8)));
    }
}