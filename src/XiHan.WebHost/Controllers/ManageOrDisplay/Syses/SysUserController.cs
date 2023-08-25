﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2023 ZhaiFanhua All Rights Reserved.
// Licensed under the MulanPSL2 License. See LICENSE in the project root for license information.
// FileName:SysUserController
// Guid:68036199-f77d-41b5-a629-bc972917fa69
// Author:Administrator
// Email:me@zhaifanhua.com
// CreateTime:2023-07-19 下午 05:50:15
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

using Microsoft.AspNetCore.Authorization;
using XiHan.WebHost.Controllers.Bases;
using XiHan.WebCore.Common.Swagger;

namespace XiHan.WebHost.Controllers.ManageOrDisplay.Syses;

/// <summary>
/// 系统用户管理
/// </summary>
[Authorize]
[ApiGroup(ApiGroupNameEnum.Manage)]
public class SysUserController : BaseApiController
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public SysUserController()
    {
    }
}