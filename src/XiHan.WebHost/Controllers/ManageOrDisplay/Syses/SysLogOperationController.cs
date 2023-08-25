﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2023 ZhaiFanhua All Rights Reserved.
// Licensed under the MulanPSL2 License. See LICENSE in the project root for license information.
// FileName:SysLogOperationController
// Guid:a6b72a71-814c-43ca-b83c-3313cf432b83
// Author:Administrator
// Email:me@zhaifanhua.com
// CreateTime:2023-07-24 下午 04:45:01
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XiHan.Infrastructures.Apps.Logging;
using XiHan.Infrastructures.Responses.Pages;
using XiHan.Models.Syses;
using XiHan.Services.Syses.Logging;
using XiHan.Services.Syses.Logging.Dtos;
using XiHan.WebHost.Controllers.Bases;
using XiHan.WebCore.Common.Swagger;

namespace XiHan.WebHost.Controllers.ManageOrDisplay.Syses;

/// <summary>
/// 系统操作日志管理
/// </summary>
[Authorize]
[ApiGroup(ApiGroupNameEnum.Manage)]
public class SysLogOperationController : BaseApiController
{
    private readonly ISysLogOperationService _sysLogOperationService;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="sysLogOperationService"></param>
    public SysLogOperationController(ISysLogOperationService sysLogOperationService)
    {
        _sysLogOperationService = sysLogOperationService;
    }

    /// <summary>
    /// 批量删除操作日志
    /// </summary>
    /// <param name="logIds"></param>
    /// <returns></returns>
    [HttpDelete("Delete")]
    [AppLog(Module = "系统操作日志", BusinessType = BusinessTypeEnum.Delete)]
    public async Task<bool> DeleteLogOperation(long[] logIds)
    {
        return await _sysLogOperationService.DeleteLogOperationByIds(logIds);
    }

    /// <summary>
    /// 清空操作日志
    /// </summary>
    [HttpDelete("Clear")]
    [AppLog(Module = "系统操作日志", BusinessType = BusinessTypeEnum.Delete)]
    public async Task<bool> ClearLogOperation()
    {
        return await _sysLogOperationService.ClearLogOperation();
    }

    /// <summary>
    /// 查询操作日志(根据Id)
    /// </summary>
    /// <param name="logId"></param>
    /// <returns></returns>
    [HttpGet("Get/ById")]
    [AppLog(Module = "系统操作日志", BusinessType = BusinessTypeEnum.Get)]
    public async Task<SysLogOperation> GetLogOperationById(long logId)
    {
        return await _sysLogOperationService.GetLogOperationById(logId);
    }

    /// <summary>
    /// 查询操作日志列表
    /// </summary>
    /// <param name="whereDto"></param>
    /// <returns></returns>
    [HttpPost("GetList")]
    [AppLog(Module = "系统操作日志", BusinessType = BusinessTypeEnum.Get)]
    public async Task<List<SysLogOperation>> GetLogOperationList([FromBody] SysLogOperationWDto whereDto)
    {
        return await _sysLogOperationService.GetLogOperationList(whereDto);
    }

    /// <summary>
    /// 查询操作日志列表(根据分页条件)
    /// </summary>
    /// <param name="pageWhere"></param>
    /// <returns></returns>
    [HttpPost("GetPageList")]
    [AppLog(Module = "系统操作日志", BusinessType = BusinessTypeEnum.Get)]
    public async Task<PageDataDto<SysLogOperation>> GetLogOperationPageList([FromBody] PageWhereDto<SysLogOperationWDto> pageWhere)
    {
        return await _sysLogOperationService.GetLogOperationPageList(pageWhere);
    }
}