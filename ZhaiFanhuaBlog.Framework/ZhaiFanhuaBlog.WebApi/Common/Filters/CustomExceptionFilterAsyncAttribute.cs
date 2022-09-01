﻿// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:CustomExceptionFilterAsyncAttribute
// Guid:0c556f22-3f97-4ea7-aa0c-78d8d5722cc4
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-06-15 下午 11:13:23
// ----------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using ZhaiFanhuaBlog.Utils.Config;
using ZhaiFanhuaBlog.ViewModels.Response;

namespace ZhaiFanhuaBlog.WebApi.Common.Filters;

/// <summary>
/// 异步异常处理过滤器属性（一般用于捕捉异常）
/// </summary>
[AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
public class CustomExceptionFilterAsyncAttribute : Attribute, IAsyncExceptionFilter
{
    // 日志开关
    private readonly bool ExceptionLogSwitch = ConfigHelper.Configuration.GetValue<bool>("Logging:Switch:Exception");

    private readonly ILogger<CustomExceptionFilterAsyncAttribute> _ILogger;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="iLogger"></param>
    public CustomExceptionFilterAsyncAttribute(ILogger<CustomExceptionFilterAsyncAttribute> iLogger)
    {
        _ILogger = iLogger;
    }

    /// <summary>
    /// 当异常发生时
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task OnExceptionAsync(ExceptionContext context)
    {
        // 异常是否被处理过，没有则在这里处理
        if (context.ExceptionHandled == false)
        {
            if (context.Exception is ApplicationException)
            {
                // 应用程序业务级异常
                // 判断是否Ajax请求，是就返回Json
                //if (this.IsAjaxRequest(context.HttpContext.Request))
                //{
                context.Result = new JsonResult(BaseResponseDto.BadRequest(context.Exception.Message));
                //}
            }
            else
            {
                // 系统级别异常，不直接明文显示
                context.Result = new JsonResult(BaseResponseDto.InternalServerError());
                // 获取控制器、路由信息
                var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
                // 获取请求的方法
                var method = actionDescriptor!.MethodInfo;
                // 获取 HttpContext 和 HttpRequest 对象
                var httpContext = context.HttpContext;
                var httpRequest = httpContext.Request;
                // 获取客户端 Ip 地址
                var remoteIp = httpContext.Connection.RemoteIpAddress == null ? string.Empty : httpContext.Connection.RemoteIpAddress.ToString();
                // 获取请求的 Url 地址(域名、路径、参数)
                var requestUrl = httpRequest.Host.Value + httpRequest.Path + httpRequest.QueryString.Value ?? string.Empty;
                // 获取操作人（必须授权访问才有值）"userId" 为你存储的 claims type，jwt 授权对应的是 payload 中存储的键名
                var userId = httpContext.User?.FindFirstValue("UserId");
                // 请求时间
                var requestedTime = DateTimeOffset.Now;
                // 写入日志
                string info = $"\t 请求Ip：{remoteIp}\n" +
                         $"\t 请求地址：{requestUrl}\n" +
                         $"\t 请求方法：{method}\n" +
                         $"\t 操作用户：{userId}";
                if (ExceptionLogSwitch)
                    _ILogger.LogError($"系统异常\n{info}\n{context.Exception}");
            }
        }
        // 标记异常已经处理过了
        context.ExceptionHandled = true;
        await Task.CompletedTask;
    }

    /// <summary>
    /// 判断是否Ajax请求
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    private bool IsAjaxRequest(HttpRequest request)
    {
        string header = request.Headers["X-Request-With"];
        return "XMLHttpRequest".Equals(header);
    }
}