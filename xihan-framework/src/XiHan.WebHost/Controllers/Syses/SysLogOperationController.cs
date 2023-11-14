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
using XiHan.Infrastructures.Responses;
using XiHan.Infrastructures.Responses.Pages;
using XiHan.Services.Syses.Logging;
using XiHan.Services.Syses.Logging.Dtos;
using XiHan.WebCore.Common.Swagger;

namespace XiHan.WebHost.Controllers.Syses;

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
    /// 批量删除系统操作日志
    /// </summary>
    /// <param name="logIds"></param>
    /// <returns></returns>
    [HttpDelete("Delete")]
    [AppLog(Module = "系统操作日志", BusinessType = BusinessTypeEnum.Delete)]
    public async Task<ApiResult> DeleteLogOperation(long[] logIds)
    {
        var result = await _sysLogOperationService.DeleteLogOperationByIds(logIds);
        return ApiResult.Success(result);
    }

    /// <summary>
    /// 清空系统操作日志
    /// </summary>
    /// <returns></returns>
    [HttpDelete("Clean")]
    [AppLog(Module = "系统操作日志", BusinessType = BusinessTypeEnum.Clean)]
    public async Task<ApiResult> CleanLogOperation()
    {
        var result = await _sysLogOperationService.CleanLogOperation();
        return ApiResult.Success(result);
    }

    /// <summary>
    /// 查询系统操作日志(根据Id)
    /// </summary>
    /// <param name="logId"></param>
    /// <returns></returns>
    [HttpGet("Get/ById")]
    [AppLog(Module = "系统操作日志", BusinessType = BusinessTypeEnum.Get)]
    public async Task<ApiResult> GetLogOperationById(long logId)
    {
        var result = await _sysLogOperationService.GetLogOperationById(logId);
        return ApiResult.Success(result);
    }

    /// <summary>
    /// 查询系统操作日志列表
    /// </summary>
    /// <param name="whereDto"></param>
    /// <returns></returns>
    [HttpPost("GetList")]
    [AppLog(Module = "系统操作日志", BusinessType = BusinessTypeEnum.Get)]
    public async Task<ApiResult> GetLogOperationList([FromBody] SysLogOperationWDto whereDto)
    {
        var result = await _sysLogOperationService.GetLogOperationList(whereDto);
        return ApiResult.Success(result);
    }

    /// <summary>
    /// 查询系统操作日志列表(根据分页条件)
    /// </summary>
    /// <param name="pageWhere"></param>
    /// <returns></returns>
    [HttpPost("GetPageList")]
    [AppLog(Module = "系统操作日志", BusinessType = BusinessTypeEnum.Get)]
    public async Task<ApiResult> GetLogOperationPageList([FromBody] PageWhereDto<SysLogOperationWDto> pageWhere)
    {
        var result = await _sysLogOperationService.GetLogOperationPageList(pageWhere);
        return ApiResult.Success(result);
    }
}