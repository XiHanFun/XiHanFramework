﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:WeComConnection
// Guid:e090aec3-2ede-4510-8ec2-6e542f34c26d
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-11-24 上午 02:35:23
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

namespace XiHan.Subscriptions.Robots.WeCom;

/// <summary>
/// WeChatConnection
/// </summary>
public class WeComConnection
{
    private const string DefaultWeComWebHookUrl = "https://qyapi.weixin.qq.com/cgi-bin/webhook/send";

    private const string DefaultWeComUploadkUrl = "https://qyapi.weixin.qq.com/cgi-bin/webhook/upload_media";

    private string? _webHookUrl;

    private string? _uploadkUrl;

    /// <summary>
    /// 网络挂钩地址
    /// </summary>
    public string WebHookUrl
    {
        get => _webHookUrl ??= DefaultWeComWebHookUrl;
        set => _webHookUrl = value;
    }

    /// <summary>
    /// 文件上传地址
    /// </summary>
    public string UploadkUrl
    {
        get => _uploadkUrl ??= DefaultWeComUploadkUrl;
        set => _uploadkUrl = value;
    }

    /// <summary>
    /// 访问令牌
    /// </summary>
    public string Key { get; set; } = string.Empty;
}