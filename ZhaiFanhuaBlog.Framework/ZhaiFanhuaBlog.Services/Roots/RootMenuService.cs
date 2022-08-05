﻿// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:RootMenuService
// Guid:0c28440b-c5c0-4507-bc91-7b0f0c6f272b
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-08-05 下午 05:35:32
// ----------------------------------------------------------------

using ZhaiFanhuaBlog.IRepositories.Roots;
using ZhaiFanhuaBlog.IServices.Roots;
using ZhaiFanhuaBlog.Models.Roots;
using ZhaiFanhuaBlog.Services.Bases;

namespace ZhaiFanhuaBlog.Services.Roots;

/// <summary>
/// RootAuditCategoryService
/// </summary>
public class RootMenuService : BaseService<RootMenu>, IRootMenuService
{
    private readonly IRootMenuRepository _IRootMenuRepository;

    public RootMenuService(IRootMenuRepository iRootMenuRepository)
    {
        base._IBaseRepository = iRootMenuRepository;
        _IRootMenuRepository = iRootMenuRepository;
    }

    /// <summary>
    /// 检验是否存在
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    public async Task<RootMenu> IsExistenceAsync(Guid guid)
    {
        var rootMenu = await _IRootMenuRepository.FindAsync(e => e.BaseId == guid && !e.SoftDeleteLock);
        if (rootMenu == null)
            throw new ApplicationException("系统菜单不存在");
        return rootMenu;
    }

    public async Task<bool> InitRootMenuAsync(List<RootMenu> rootMenus)
    {
        rootMenus.ForEach(rootMenu =>
        {
            rootMenu.SoftDeleteLock = false;
        });
        var result = await _IRootMenuRepository.CreateBatchAsync(rootMenus);
        return result;
    }

    public async Task<bool> CreateRootMenuAsync(RootMenu rootMenu)
    {
        if (rootMenu.ParentId != null && await _IRootMenuRepository.FindAsync(e => e.ParentId == rootMenu.ParentId && !e.SoftDeleteLock) == null)
            throw new ApplicationException("父级系统菜单不存在");
        if (await _IRootMenuRepository.FindAsync(e => e.Name == rootMenu.Name && !e.SoftDeleteLock) != null)
            throw new ApplicationException("系统菜单名称已存在");
        if (await _IRootMenuRepository.FindAsync(e => e.Path == rootMenu.Path && !e.SoftDeleteLock) != null)
            throw new ApplicationException("系统菜单页面路经已存在");
        if (await _IRootMenuRepository.FindAsync(e => e.Route == rootMenu.Route && !e.SoftDeleteLock) != null)
            throw new ApplicationException("系统菜单路由已存在");
        rootMenu.SoftDeleteLock = false;
        var result = await _IRootMenuRepository.CreateAsync(rootMenu);
        return result;
    }

    public async Task<bool> DeleteRootMenuAsync(Guid guid, Guid deleteId)
    {
        var rootMenu = await IsExistenceAsync(guid);
        rootMenu.SoftDeleteLock = true;
        rootMenu.DeleteId = deleteId;
        rootMenu.DeleteTime = DateTime.Now;
        return await _IRootMenuRepository.UpdateAsync(rootMenu);
    }

    public async Task<RootMenu> ModifyRootMenuAsync(RootMenu rootMenu)
    {
        await IsExistenceAsync(rootMenu.BaseId);
        if (rootMenu.ParentId != null && await _IRootMenuRepository.FindAsync(e => e.ParentId == rootMenu.ParentId && !e.SoftDeleteLock) == null)
            throw new ApplicationException("父级系统菜单不存在");
        if (await _IRootMenuRepository.FindAsync(e => e.Name == rootMenu.Name && !e.SoftDeleteLock) != null)
            throw new ApplicationException("系统菜单名称已存在");
        if (await _IRootMenuRepository.FindAsync(e => e.Path == rootMenu.Path && !e.SoftDeleteLock) != null)
            throw new ApplicationException("系统菜单页面路经已存在");
        if (await _IRootMenuRepository.FindAsync(e => e.Route == rootMenu.Route && !e.SoftDeleteLock) != null)
            throw new ApplicationException("系统菜单路由已存在");
        rootMenu.ModifyTime = DateTime.Now;
        var result = await _IRootMenuRepository.UpdateAsync(rootMenu);
        if (result) rootMenu = await _IRootMenuRepository.FindAsync(rootMenu.BaseId);
        return rootMenu;
    }

    public async Task<RootMenu> FindRootMenuAsync(Guid guid)
    {
        var RootMenu = await IsExistenceAsync(guid);
        return RootMenu;
    }

    public async Task<List<RootMenu>> QueryRootMenuAsync()
    {
        var RootMenu = from rootmenu in await _IRootMenuRepository.QueryListAsync(e => !e.SoftDeleteLock)
                       orderby rootmenu.CreateTime descending
                       select rootmenu;
        return RootMenu.ToList();
    }
}