﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2023 ZhaiFanhua All Rights Reserved.
// FileName:SysDictDataService
// Guid:3f7ca12f-9a86-4e07-b304-1a0f951a133c
// Author:Administrator
// Email:me@zhaifanhua.com
// CreateTime:2023-06-12 下午 04:32:05
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

using SqlSugar;
using XiHan.Infrastructures.Apps.Services;
using XiHan.Infrastructures.Responses.Pages;
using XiHan.Models.Syses;
using XiHan.Services.Bases;
using XiHan.Services.Syses.Dicts.Dtos;
using XiHan.Utils.Extensions;

namespace XiHan.Services.Syses.Dicts.Logic;

/// <summary>
/// 系统字典数据服务
/// </summary>
[AppService(ServiceType = typeof(ISysDictDataService), ServiceLifetime = ServiceLifeTimeEnum.Transient)]
public class SysDictDataService : BaseService<SysDictData>, ISysDictDataService
{
    private readonly ISysDictDataService _sysDictDataService;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="sysDictDataService"></param>
    public SysDictDataService(ISysDictDataService sysDictDataService)
    {
        _sysDictDataService = sysDictDataService;
    }

    /// <summary>
    /// 新增字典数据
    /// </summary>
    /// <param name="sysDictData"></param>
    /// <returns></returns>
    public async Task<long> CreateDictData(SysDictData sysDictData)
    {
        return await AddReturnIdAsync(sysDictData);
    }

    /// <summary>
    /// 批量删除字典数据
    /// </summary>
    /// <param name="dictIds"></param>
    /// <returns></returns>
    public async Task<bool> DeleteDictDataByIds(long[] dictIds)
    {
        return await RemoveAsync(dictIds);
    }

    /// <summary>
    /// 修改字典数据
    /// </summary>
    /// <param name="sysDictData"></param>
    /// <returns></returns>
    public async Task<bool> ModifyDictData(SysDictData sysDictData)
    {
        sysDictData.ModifiedTime = DateTime.Now;
        return await UpdateAsync(sysDictData);
    }

    /// <summary>
    /// 修改同步字典类型
    /// </summary>
    /// <param name="old_dictType">旧字典类型</param>
    /// <param name="new_dictType">新字典类型</param>
    /// <returns></returns>
    public async Task<int> ModifyDictDataType(string old_dictType, string new_dictType)
    {
        // 只更新 Type 字段
        return await Context.Updateable<SysDictData>()
            .SetColumns(t => new SysDictData() { Type = new_dictType })
            .Where(f => f.Type == old_dictType)
            .ExecuteCommandAsync();
    }

    /// <summary>
    /// 查询字典数据(根据Id)
    /// </summary>
    /// <param name="dictId"></param>
    /// <returns></returns>
    public async Task<SysDictData> GetDictDataById(long dictId)
    {
        return await FindAsync(dictId);
    }

    /// <summary>
    /// 查询字典数据(根据类型)
    /// </summary>
    /// <param name="dictTypes"></param>
    /// <returns></returns>
    public async Task<List<SysDictData>> GetDictDataByTypes(string[] dictTypes)
    {
        var result = await QueryAsync(f => f.IsEnable && dictTypes.Contains(f.Type));
        return result.OrderBy(o => o.SortOrder).ToList();
    }

    /// <summary>
    /// 查询字典数据列表(根据分页条件)
    /// </summary>
    /// <param name="pageWhereDto"></param>
    /// <returns></returns>
    public async Task<BasePageDataDto<SysDictData>> GetDictDataList(PageWhereDto<SysDictDataWhereDto> pageWhereDto)
    {
        var whereDto = pageWhereDto.Where;

        var whereExpression = Expressionable.Create<SysDictData>();
        whereExpression.AndIF(whereDto.Type.IsNotEmptyOrNull(), u => u.Type == whereDto.Type);
        whereExpression.AndIF(whereDto.Label.IsNotEmptyOrNull(), u => u.Label.Contains(whereDto.Label!));
        whereExpression.AndIF(whereDto.IsDefault != null, u => u.IsDefault == whereDto.IsDefault);
        whereExpression.AndIF(whereDto.IsEnable != null, u => u.IsEnable == whereDto.IsEnable);

        return await QueryPageAsync(whereExpression.ToExpression(), pageWhereDto.PageDto);
    }
}