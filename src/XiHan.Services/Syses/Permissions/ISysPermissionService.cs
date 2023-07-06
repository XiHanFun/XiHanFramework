﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2023 ZhaiFanhua All Rights Reserved.
// Licensed under the MulanPSL2 License. See LICENSE in the project root for license information.
// FileName:ISysPermissionService
// Guid:749972c3-c4cf-4fba-84fd-19090110211f
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreatedTime:2023-04-22 上午 03:58:52
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

using XiHan.Models.Syses;

namespace XiHan.Services.Syses.Permissions;

/// <summary>
/// ISysPermissionService
/// </summary>
public interface ISysPermissionService
{
    /// <summary>
    /// 获取角色权限
    /// </summary>
    /// <param name="user">用户信息</param>
    /// <returns>角色权限信息</returns>
    List<string> GetRolePermission(SysUser user);

    /// <summary>
    /// 获取菜单权限
    /// </summary>
    /// <param name="user">用户信息</param>
    /// <returns>菜单权限信息</returns>
    List<string> GetMenuPermission(SysUser user);
}