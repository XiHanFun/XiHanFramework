﻿// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:ClientInfoHelper
// Guid:07ebcfda-13ac-4019-a8ba-b03f21d6a8c2
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-09-16 上午 01:51:36
// ----------------------------------------------------------------

using Microsoft.AspNetCore.Http;

namespace ZhaiFanhuaBlog.Utils.Info;

/// <summary>
/// ClientInfoHelper
/// </summary>
public class ClientInfoHelper
{
    /// <summary>
    /// IPv4
    /// </summary>
    public string? IPv4 { get; set; }

    /// <summary>
    /// IPv6
    /// </summary>
    public string? IPv6 { get; set; }

    /// <summary>
    /// 浏览器名称
    /// </summary>
    public string? BrowserName { get; set; }

    /// <summary>
    /// 浏览器版本
    /// </summary>
    public string? BrowserVersion { get; set; }

    /// <summary>
    /// 系统名称
    /// </summary>
    public string? SystemName { get; set; }

    /// <summary>
    /// 系统类型
    /// </summary>
    public string? SystemType { get; set; }

    /// <summary>
    /// 语言
    /// </summary>
    public string? Language { get; set; }

    /// <summary>
    /// 引荐
    /// </summary>
    public string? Referer { get; set; }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="httpContext"></param>
    public ClientInfoHelper(HttpContext httpContext)
    {
        var header = httpContext.Request.HttpContext.Request.Headers;
        IPv4 = httpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString();
        Language = header["Accept-Language"].ToString().Split(';')[0];
        Referer = header["Referer"].ToString();
        //取代理IP
        if (header.ContainsKey("X-Forwarded-For"))
        {
            IPv4 = header["X-Forwarded-For"].ToString();
        }
        var ua = header["User-Agent"].ToString().ToLower();
        SystemName = GetSystemName(ua);
        SystemType = GetSystemType(ua);
        BrowserName = GetBrowserName(ua);
    }

    /// <summary>
    /// 获取系统名称
    /// </summary>
    /// <param name="ua"></param>
    private static string GetSystemName(string ua)
    {
        string sn = "Unknown";
        if (ua.Contains("nt 5.0"))
            sn = "Windows 2000";
        else if (ua.Contains("nt 5.1"))
            ua = "Windows XP";
        else if (ua.Contains("nt 5.2"))
            sn = "Windows 2003";
        else if (ua.Contains("nt 6.0"))
            sn = "Windows Vista";
        else if (ua.Contains("nt 6.1"))
            sn = "Windows 7";
        else if (ua.Contains("nt 6.2"))
            sn = "Windows 8";
        else if (ua.Contains("nt 6.3"))
            sn = "Windows 8.1";
        else if (ua.Contains("nt 6.4") || ua.Contains("nt 10.0"))
            sn = "Windows 10";
        else if (ua.Contains("unix"))
            sn = "Unix";
        else if (ua.Contains("linux"))
            sn = "Linux";
        else if (ua.Contains("mac"))
            sn = "Mac";
        else if (ua.Contains("sunos"))
            sn = "SunOS";
        return sn;
    }

    /// <summary>
    /// 获取系统类型
    /// </summary>
    /// <param name="ua"></param>
    /// <returns></returns>
    private static string GetSystemType(string ua)
    {
        return ua.Contains("x64") ? "64位" : "32位";
    }

    /// <summary>
    /// 获取浏览器名称
    /// </summary>
    /// <param name="ua"></param>
    private static string GetBrowserName(string ua)
    {
        string bn = "Unknown";
        if (ua.Contains("opera/ucweb"))
            bn = "UC Opera";
        else if (ua.Contains("openwave/ucweb"))
            bn = "UCOpenwave";
        else if (ua.Contains("ucweb"))
            bn = "UC";
        else if (ua.Contains("360se"))
            bn = "360";
        else if (ua.Contains("metasr"))
            bn = "搜狗";
        else if (ua.Contains("maxthon"))
            bn = "遨游";
        else if (ua.Contains("the world"))
            bn = "世界之窗";
        else if (ua.Contains("tencenttraveler") || ua.Contains("qqbn"))
            bn = "QQ";
        else if (ua.Contains("msie"))
            bn = "IE";
        else if (ua.Contains("edg"))
            bn = "Edge";
        else if (ua.Contains("chrome"))
            bn = "Chrome";
        else if (ua.Contains("safari"))
            bn = "Safari";
        else if (ua.Contains("firefox"))
            bn = "Firefox";
        else if (ua.Contains("opera"))
            bn = "Opera";

        return bn;
    }
}