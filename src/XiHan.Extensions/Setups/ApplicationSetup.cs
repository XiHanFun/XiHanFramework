﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:ApplicationSetup
// Guid:b216dd59-346e-44c1-bdef-1830ebca6d0f
// Author:Administrator
// Email:me@zhaifanhua.com
// CreateTime:2022-12-28 下午 08:00:53
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Hosting;
using XiHan.Extensions.Setups.Application;
using XiHan.Utils.Console;
using XiHan.Utils.Message.ChatHub;

namespace XiHan.Extensions.Setups;

/// <summary>
/// ApplicationSetup
/// </summary>
public static class ApplicationSetup
{
    /// <summary>
    /// 应用扩展 配置中间件
    /// </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    /// <param name="streamHtml"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IApplicationBuilder UseApplicationSetup(this IApplicationBuilder app, IWebHostEnvironment env, Func<Stream> streamHtml)
    {
        "XiHan Application Start……".WriteLineInfo();
        if (app == null)
        {
            throw new ArgumentNullException(nameof(app));
        }

        // 初始化数据库
        app.ApplicationServices.InitDatabase();
        // 环境变量，开发环境
        if (env.IsDevelopment())
        {
            // 生成异常页面
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // 使用HSTS的中间件，该中间件添加了严格传输安全头
            app.UseHsts();
        }
        // Nginx 反向代理获取真实IP
        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
        });
        // 强制https跳转
        app.UseHttpsRedirection();
        // MiniProfiler
        app.UseMiniProfilerSetup();
        // Swagger
        app.UseSwaggerSetup(streamHtml);
        // 使用静态文件
        app.UseStaticFiles();
        // 路由
        app.UseRouting();
        // 跨域
        app.UseCorsSetup();
        // 鉴权
        app.UseAuthentication();
        // 授权
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            // 不对约定路由做任何假设，也就是不使用约定路由，依赖用户的特性路由
            endpoints.MapControllers();
            // 健康检查
            endpoints.MapHealthChecks("/Health");
            // 即时通讯
            endpoints.MapHub<ChatHubHelper>("/Chathub");
        });

        "XiHan Application Started Successfully！".WriteLineSuccess();
        return app;
    }
}