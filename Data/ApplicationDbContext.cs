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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // 配置实体关系和约束
            ConfigurePersonnel(builder);
            ConfigureInventory(builder);
            ConfigureEquipment(builder);
            ConfigureAircraft(builder);
            ConfigureDevice(builder);
            ConfigureKit(builder);
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
    }
}