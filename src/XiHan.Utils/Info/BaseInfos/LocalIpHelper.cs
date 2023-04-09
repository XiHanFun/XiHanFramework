﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:LocalIpHelper
// Guid:dc0502e1-f675-41d3-8a67-dbd590e76260
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-05-09 上午 01:11:29
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace XiHan.Utils.Info.BaseInfos;

/// <summary>
/// 本地Ip帮助类
/// </summary>
public static class LocalIpHelper
{
    /// <summary>
    /// 获取本机IpV4地址
    /// </summary>
    /// <returns></returns>
    public static string GetLocalIpV4()
    {
        IEnumerable<UnicastIPAddressInformation>? unicastIpAddressInformations = LocalIpAddressInfo();
        if (unicastIpAddressInformations != null)
        {
            foreach (var ipInfo in unicastIpAddressInformations)
            {
                if (!IPAddress.IsLoopback(ipInfo.Address) && ipInfo.Address.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ipInfo.Address.ToString();
                }
            }
        }
        return "No IP address was obtained";
    }

    /// <summary>
    /// 获取本机IpV6地址
    /// </summary>
    /// <returns></returns>
    public static string GetLocalIpV6()
    {
        IEnumerable<UnicastIPAddressInformation>? unicastIpAddressInformations = LocalIpAddressInfo();
        if (unicastIpAddressInformations != null)
        {
            foreach (var ipInfo in unicastIpAddressInformations)
            {
                if (!IPAddress.IsLoopback(ipInfo.Address) && ipInfo.Address.AddressFamily == AddressFamily.InterNetworkV6)
                {
                    return ipInfo.Address.ToString();
                }
            }
        }
        return "No IP address was obtained";
    }

    /// <summary>
    /// 获取本机所有可用网卡IP信息
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<UnicastIPAddressInformation>? LocalIpAddressInfo()
    {
        // 获取可用网卡
        var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces()?.Where(network => network.OperationalStatus == OperationalStatus.Up);
        // 获取所有可用网卡IP信息
        var unicastIpAddressInformations = networkInterfaces?.Select(x => x.GetIPProperties())?.SelectMany(x => x.UnicastAddresses);
        if (unicastIpAddressInformations != null)
        {
            return unicastIpAddressInformations;
        }
        return null;
    }
}