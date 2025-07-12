using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ComprehensiveManagementSystem.Models;

namespace ComprehensiveManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // 人员管理
        public DbSet<Personnel> Personnel { get; set; }
        public DbSet<Department> Departments { get; set; }
        
        // 人员详细信息管理
        public DbSet<PersonnelBasicInfo> PersonnelBasicInfos { get; set; }
        public DbSet<PersonnelSupplementaryInfo> PersonnelSupplementaryInfos { get; set; }
        public DbSet<PersonnelRewardPunishment> PersonnelRewardPunishments { get; set; }
        public DbSet<PersonnelHistory> PersonnelHistories { get; set; }
        public DbSet<PersonnelSpouse> PersonnelSpouses { get; set; }
        public DbSet<PersonnelFamilyMember> PersonnelFamilyMembers { get; set; }
        public DbSet<PersonnelWorkRecord> PersonnelWorkRecords { get; set; }
        public DbSet<PersonnelActivityRecord> PersonnelActivityRecords { get; set; }
        public DbSet<PersonnelTraining> PersonnelTrainings { get; set; }
        public DbSet<PersonnelChange> PersonnelChanges { get; set; }

        // 飞机管理
        public DbSet<Aircraft> Aircraft { get; set; }

        // 装备管理
        public DbSet<Equipment> Equipments { get; set; }

        // 设备管理
        public DbSet<Device> Devices { get; set; }

        // 装具管理
        public DbSet<Kit> Kits { get; set; }

        // 库存管理
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<InboundRecord> InboundRecords { get; set; }
        public DbSet<OutboundRecord> OutboundRecords { get; set; }
        public DbSet<TransferRecord> TransferRecords { get; set; }
        public DbSet<StockTaking> StockTakings { get; set; }

        // 厂家管理
        public DbSet<Manufacturer> Manufacturers { get; set; }

        // 计量单位
        public DbSet<UnitOfMeasure> UnitsOfMeasure { get; set; }

        // 类别设置
        public DbSet<Category> Categories { get; set; }

        // 机构管理
        public DbSet<Organization> Organizations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // 配置实体关系和约束
            ConfigurePersonnel(builder);
            ConfigurePersonnelDetail(builder);
            ConfigurePersonnelChange(builder);
            ConfigureInventory(builder);
            ConfigureEquipment(builder);
            ConfigureAircraft(builder);
            ConfigureDevice(builder);
            ConfigureKit(builder);
            ConfigureOrganization(builder);
        }

        private void ConfigurePersonnel(ModelBuilder builder)
        {
            builder.Entity<Personnel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.EmployeeNumber).IsRequired().HasMaxLength(50);
                entity.HasIndex(e => e.EmployeeNumber).IsUnique();
                
                entity.HasOne(e => e.Department)
                      .WithMany(d => d.Personnel)
                      .HasForeignKey(e => e.DepartmentId);
            });

            builder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Code).IsRequired().HasMaxLength(20);
                entity.HasIndex(e => e.Code).IsUnique();
            });
        }

        private void ConfigureInventory(ModelBuilder builder)
        {
            builder.Entity<Warehouse>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Code).IsRequired().HasMaxLength(20);
                entity.HasIndex(e => e.Code).IsUnique();
            });

            builder.Entity<InventoryItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ItemCode).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.HasIndex(e => e.ItemCode).IsUnique();
                
                entity.HasOne(e => e.Warehouse)
                      .WithMany(w => w.InventoryItems)
                      .HasForeignKey(e => e.WarehouseId);
                
                entity.HasOne(e => e.Category)
                      .WithMany()
                      .HasForeignKey(e => e.CategoryId);
                
                entity.HasOne(e => e.UnitOfMeasure)
                      .WithMany()
                      .HasForeignKey(e => e.UnitOfMeasureId);
            });
        }

        private void ConfigureEquipment(ModelBuilder builder)
        {
            builder.Entity<Equipment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ItemCode).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.HasIndex(e => e.ItemCode).IsUnique();
                
                entity.HasOne(e => e.Category)
                      .WithMany()
                      .HasForeignKey(e => e.CategoryId);
                
                entity.HasOne(e => e.Manufacturer)
                      .WithMany()
                      .HasForeignKey(e => e.ManufacturerId);
            });
        }

        private void ConfigureAircraft(ModelBuilder builder)
        {
            builder.Entity<Aircraft>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ItemCode).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.TailNumber).IsRequired().HasMaxLength(20);
                entity.HasIndex(e => e.ItemCode).IsUnique();
                entity.HasIndex(e => e.TailNumber).IsUnique();
                
                entity.HasOne(e => e.Category)
                      .WithMany()
                      .HasForeignKey(e => e.CategoryId);
                
                entity.HasOne(e => e.Manufacturer)
                      .WithMany()
                      .HasForeignKey(e => e.ManufacturerId);
            });
        }

        private void ConfigureDevice(ModelBuilder builder)
        {
            builder.Entity<Device>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ItemCode).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.HasIndex(e => e.ItemCode).IsUnique();
                
                entity.HasOne(e => e.Category)
                      .WithMany()
                      .HasForeignKey(e => e.CategoryId);
                
                entity.HasOne(e => e.Manufacturer)
                      .WithMany()
                      .HasForeignKey(e => e.ManufacturerId);
            });
        }

        private void ConfigureKit(ModelBuilder builder)
        {
            builder.Entity<Kit>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ItemCode).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.HasIndex(e => e.ItemCode).IsUnique();
                
                entity.HasOne(e => e.Category)
                      .WithMany()
                      .HasForeignKey(e => e.CategoryId);
                
                entity.HasOne(e => e.Manufacturer)
                      .WithMany()
                      .HasForeignKey(e => e.ManufacturerId);
            });
        }

        private void ConfigurePersonnelDetail(ModelBuilder builder)
        {
            // 配置人员基本信息表
            builder.Entity<PersonnelBasicInfo>(entity =>
            {
                entity.HasKey(e => e.PersonnelId);
                entity.Property(e => e.PersonnelId).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.IdCard).IsRequired().HasMaxLength(18);
                entity.HasIndex(e => e.IdCard).IsUnique();
                
                entity.HasOne(e => e.Department)
                      .WithMany()
                      .HasForeignKey(e => e.DepartmentId);
            });

            // 配置人员补充信息表
            builder.Entity<PersonnelSupplementaryInfo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                
                entity.HasOne(e => e.Personnel)
                      .WithOne(p => p.SupplementaryInfo)
                      .HasForeignKey<PersonnelSupplementaryInfo>(e => e.PersonnelId);
            });

            // 配置人员奖惩表
            builder.Entity<PersonnelRewardPunishment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Level).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Reason).IsRequired().HasMaxLength(500);
                entity.Property(e => e.DecisionUnit).IsRequired().HasMaxLength(200);
                
                entity.HasOne(e => e.Personnel)
                      .WithMany(p => p.RewardPunishments)
                      .HasForeignKey(e => e.PersonnelId);
            });

            // 配置人员履历表
            builder.Entity<PersonnelHistory>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.WorkPlace).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Role).IsRequired().HasMaxLength(100);
                
                entity.HasOne(e => e.Personnel)
                      .WithMany(p => p.Histories)
                      .HasForeignKey(e => e.PersonnelId);
            });

            // 配置配偶信息表
            builder.Entity<PersonnelSpouse>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                
                entity.HasOne(e => e.Personnel)
                      .WithOne(p => p.Spouse)
                      .HasForeignKey<PersonnelSpouse>(e => e.PersonnelId);
            });

            // 配置家庭成员表
            builder.Entity<PersonnelFamilyMember>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                
                entity.HasOne(e => e.Personnel)
                      .WithMany(p => p.FamilyMembers)
                      .HasForeignKey(e => e.PersonnelId);
            });

            // 配置工作记录表
            builder.Entity<PersonnelWorkRecord>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.WorkPlace).IsRequired().HasMaxLength(200);
                entity.Property(e => e.WorkContent).IsRequired().HasMaxLength(1000);
                
                entity.HasOne(e => e.Personnel)
                      .WithMany(p => p.WorkRecords)
                      .HasForeignKey(e => e.PersonnelId);
            });

            // 配置活动记录表
            builder.Entity<PersonnelActivityRecord>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.ActivityPlace).IsRequired().HasMaxLength(200);
                entity.Property(e => e.ActivityName).IsRequired().HasMaxLength(200);
                entity.Property(e => e.ParticipantRole).IsRequired().HasMaxLength(100);
                
                entity.HasOne(e => e.Personnel)
                      .WithMany(p => p.ActivityRecords)
                      .HasForeignKey(e => e.PersonnelId);
            });

            // 配置培训记录表
            builder.Entity<PersonnelTraining>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd(); // 恢复自动生成
                entity.Property(e => e.TrainingName).IsRequired().HasMaxLength(200);
                entity.Property(e => e.TrainingOrganization).IsRequired().HasMaxLength(200);
                entity.Property(e => e.TrainingLocation).IsRequired().HasMaxLength(200);
                
                entity.HasOne(e => e.Personnel)
                      .WithMany(p => p.Trainings)
                      .HasForeignKey(e => e.PersonnelId);
            });
        }

        private void ConfigurePersonnelChange(ModelBuilder builder)
        {
            builder.Entity<PersonnelChange>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.ChangeType).IsRequired();
                entity.Property(e => e.ChangeDate).IsRequired();
                entity.Property(e => e.Status).IsRequired();
                
                // 配置与人员的关系
                entity.HasOne(e => e.Personnel)
                      .WithMany()
                      .HasForeignKey(e => e.PersonnelId)
                      .OnDelete(DeleteBehavior.Restrict);
                
                // 配置与变动前机构的关系
                entity.HasOne(e => e.PreviousOrganization)
                      .WithMany()
                      .HasForeignKey(e => e.PreviousOrganizationId)
                      .OnDelete(DeleteBehavior.Restrict);
                
                // 配置与变动后机构的关系
                entity.HasOne(e => e.NewOrganization)
                      .WithMany()
                      .HasForeignKey(e => e.NewOrganizationId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private void ConfigureOrganization(ModelBuilder builder)
        {
            builder.Entity<Organization>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Type).IsRequired();
                entity.Property(e => e.Location).HasMaxLength(200);
                entity.Property(e => e.Remark).HasMaxLength(500);
                
                // 配置自引用关系
                entity.HasOne(e => e.Parent)
                      .WithMany(e => e.Children)
                      .HasForeignKey(e => e.ParentId)
                      .OnDelete(DeleteBehavior.Restrict);
                
                // 配置与人员的关系
                entity.HasMany(e => e.Personnel)
                      .WithOne(p => p.Organization)
                      .HasForeignKey(p => p.OrganizationId);
            });
        }
    }
}