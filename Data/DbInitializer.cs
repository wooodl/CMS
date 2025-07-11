using ComprehensiveManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ComprehensiveManagementSystem.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // 检查数据库是否已经有数据
                if (context.Departments.Any() || context.Organizations.Any())
                {
                    return;   // 数据库已经有数据
                }

                // 创建机构数据 - 分批创建以避免外键约束问题
                var rootOrganizations = new Organization[]
                {
                    new Organization { Name = "总部", Type = OrganizationType.Unit, DisplayOrder = 1, Location = "北京", Remark = "公司总部", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
                };
                
                context.Organizations.AddRange(rootOrganizations);
                context.SaveChanges(); // 保存根级机构
                
                // 获取刚刚创建的总部机构的ID
                var headquarters = context.Organizations.FirstOrDefault(o => o.Name == "总部");
                if (headquarters != null)
                {
                    var secondLevelOrganizations = new Organization[]
                    {
                        new Organization { Name = "研发中心", Type = OrganizationType.Department, DisplayOrder = 2, Location = "北京", Remark = "负责技术研发", ParentId = headquarters.Id, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                        new Organization { Name = "运营中心", Type = OrganizationType.Department, DisplayOrder = 3, Location = "上海", Remark = "负责运营管理", ParentId = headquarters.Id, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
                    };
                    
                    context.Organizations.AddRange(secondLevelOrganizations);
                    context.SaveChanges(); // 保存二级机构
                    
                    // 获取二级机构的ID
                    var researchCenter = context.Organizations.FirstOrDefault(o => o.Name == "研发中心");
                    var operationCenter = context.Organizations.FirstOrDefault(o => o.Name == "运营中心");
                    
                    if (researchCenter != null && operationCenter != null)
                    {
                        var thirdLevelOrganizations = new Organization[]
                        {
                            new Organization { Name = "软件开发部", Type = OrganizationType.Group, DisplayOrder = 4, Location = "北京", Remark = "软件开发团队", ParentId = researchCenter.Id, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                            new Organization { Name = "硬件开发部", Type = OrganizationType.Group, DisplayOrder = 5, Location = "北京", Remark = "硬件开发团队", ParentId = researchCenter.Id, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                            new Organization { Name = "市场部", Type = OrganizationType.Group, DisplayOrder = 6, Location = "上海", Remark = "市场推广团队", ParentId = operationCenter.Id, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                            new Organization { Name = "客服部", Type = OrganizationType.Group, DisplayOrder = 7, Location = "上海", Remark = "客户服务团队", ParentId = operationCenter.Id, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
                        };
                        
                        context.Organizations.AddRange(thirdLevelOrganizations);
                    }
                }

                // 创建部门数据
                var departments = new Department[]
                {
                    new Department { Name = "行政部", Code = "ADMIN", Description = "负责公司行政管理工作", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new Department { Name = "技术部", Code = "TECH", Description = "负责技术开发和维护", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new Department { Name = "财务部", Code = "FIN", Description = "负责财务管理和会计工作", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new Department { Name = "人力资源部", Code = "HR", Description = "负责人员招聘和管理", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new Department { Name = "运营部", Code = "OPS", Description = "负责日常运营管理", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new Department { Name = "安全部", Code = "SEC", Description = "负责安全管理和保障", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
                };

                context.Departments.AddRange(departments);

                // 创建类别数据
                var categories = new Category[]
                {
                    new Category { Name = "飞机", Description = "各类飞机设备", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new Category { Name = "装备", Description = "各类专用装备", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new Category { Name = "设备", Description = "各类通用设备", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new Category { Name = "装具", Description = "各类装具物品", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
                };

                context.Categories.AddRange(categories);

                // 创建计量单位数据
                var units = new UnitOfMeasure[]
                {
                    new UnitOfMeasure { Name = "台", Description = "设备台数", ConversionFactor = 1.0m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new UnitOfMeasure { Name = "个", Description = "物品个数", ConversionFactor = 1.0m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new UnitOfMeasure { Name = "套", Description = "物品套数", ConversionFactor = 1.0m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new UnitOfMeasure { Name = "件", Description = "物品件数", ConversionFactor = 1.0m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new UnitOfMeasure { Name = "公斤", Description = "重量单位", ConversionFactor = 1.0m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new UnitOfMeasure { Name = "米", Description = "长度单位", ConversionFactor = 1.0m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
                };

                context.UnitsOfMeasure.AddRange(units);

                // 创建库房数据
                var warehouses = new Warehouse[]
                {
                    new Warehouse { Name = "一号库房", Code = "WH001", Location = "东区", Area = 500.0m, Capacity = 1000.0m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new Warehouse { Name = "二号库房", Code = "WH002", Location = "西区", Area = 300.0m, Capacity = 600.0m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new Warehouse { Name = "三号库房", Code = "WH003", Location = "南区", Area = 400.0m, Capacity = 800.0m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
                };

                context.Warehouses.AddRange(warehouses);

                // 创建制造商数据
                var manufacturers = new Manufacturer[]
                {
                    new Manufacturer { Name = "中航工业", ContactPerson = "张经理", Phone = "010-12345678", Address = "北京市朝阳区", RegisteredCapital = 10000000.0m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new Manufacturer { Name = "航天科技", ContactPerson = "李经理", Phone = "010-87654321", Address = "北京市海淀区", RegisteredCapital = 8000000.0m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new Manufacturer { Name = "通用设备公司", ContactPerson = "王经理", Phone = "021-11111111", Address = "上海市浦东新区", RegisteredCapital = 5000000.0m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
                };

                context.Manufacturers.AddRange(manufacturers);

                context.SaveChanges();
            }
        }
    }
}