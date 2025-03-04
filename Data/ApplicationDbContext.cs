﻿using Microsoft.EntityFrameworkCore;


namespace SunuerManageEn.Data
{

    /// <summary>
    /// Project:Sunuer Manage
    /// Description:存放数据库上下文和数据访问配置文件，用于配置 EF(Entity Framework)
    /// Author：HaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License：Apache License 2.0
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

    }
}