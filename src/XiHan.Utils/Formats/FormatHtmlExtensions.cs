﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:FormatHtmlExtensions
// Guid:92253fa2-2ea7-4fbc-b803-fd48f337b515
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-09-07 上午 03:10:39
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

using System.Text.RegularExpressions;

namespace XiHan.Utils.Formats;

/// <summary>
/// Html格式化拓展类
/// </summary>
public static class FormatHtmlExtensions
{
    /// <summary>
    /// 去除富文本中的HTML标签
    /// </summary>
    /// <param name="html"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    public static string FormatReplaceHtmlTag(this string html, int length = 0)
    {
        var strText = Regex.Replace(html, "<[^>]+>", "");
        strText = Regex.Replace(strText, "&[^;]+;", "");
        if (length > 0 && strText.Length > length)
        {
            return strText[..length];
        }
        return strText;
    }
}