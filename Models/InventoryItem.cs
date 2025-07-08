using System.ComponentModel.DataAnnotations;

namespace ComprehensiveManagementSystem.Models
{
    public class InventoryItem
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "物品编码不能为空")]
        [StringLength(50, ErrorMessage = "物品编码长度不能超过50个字符")]
        [Display(Name = "物品编码")]
        public string ItemCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "物品名称不能为空")]
        [StringLength(200, ErrorMessage = "物品名称长度不能超过200个字符")]
        [Display(Name = "物品名称")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "规格型号")]
        [StringLength(100, ErrorMessage = "规格型号长度不能超过100个字符")]
        public string? Specification { get; set; }

        [Display(Name = "类别")]
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        [Display(Name = "计量单位")]
        public int? UnitOfMeasureId { get; set; }
        public virtual UnitOfMeasure? UnitOfMeasure { get; set; }

        [Display(Name = "库房")]
        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; } = null!;

        [Display(Name = "存放位置")]
        [StringLength(100, ErrorMessage = "存放位置长度不能超过100个字符")]
        public string? StorageLocation { get; set; }

        [Display(Name = "当前库存")]
        [Range(0, double.MaxValue, ErrorMessage = "库存数量不能为负数")]
        public decimal CurrentStock { get; set; } = 0;

        [Display(Name = "安全库存")]
        [Range(0, double.MaxValue, ErrorMessage = "安全库存不能为负数")]
        public decimal SafetyStock { get; set; } = 0;

        [Display(Name = "最大库存")]
        [Range(0, double.MaxValue, ErrorMessage = "最大库存不能为负数")]
        public decimal? MaxStock { get; set; }

        [Display(Name = "单价")]
        [Range(0, double.MaxValue, ErrorMessage = "单价不能为负数")]
        [DataType(DataType.Currency)]
        public decimal? UnitPrice { get; set; }

        [Display(Name = "总价值")]
        [Range(0, double.MaxValue, ErrorMessage = "总价值不能为负数")]
        [DataType(DataType.Currency)]
        public decimal TotalValue => CurrentStock * (UnitPrice ?? 0);

        [Display(Name = "批次号")]
        [StringLength(50, ErrorMessage = "批次号长度不能超过50个字符")]
        public string? BatchNumber { get; set; }

        [Display(Name = "生产日期")]
        [DataType(DataType.Date)]
        public DateTime? ProductionDate { get; set; }

        [Display(Name = "过期日期")]
        [DataType(DataType.Date)]
        public DateTime? ExpiryDate { get; set; }

        [Display(Name = "供应商")]
        [StringLength(200, ErrorMessage = "供应商名称长度不能超过200个字符")]
        public string? Supplier { get; set; }

        [Display(Name = "最后入库时间")]
        public DateTime? LastInboundDate { get; set; }

        [Display(Name = "最后出库时间")]
        public DateTime? LastOutboundDate { get; set; }

        [Display(Name = "库存状态")]
        public InventoryStatus Status { get; set; } = InventoryStatus.Normal;

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注长度不能超过500个字符")]
        public string? Remarks { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "更新时间")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }

    public enum InventoryStatus
    {
        [Display(Name = "正常")]
        Normal = 1,
        [Display(Name = "库存不足")]
        LowStock = 2,
        [Display(Name = "库存过多")]
        OverStock = 3,
        [Display(Name = "即将过期")]
        NearExpiry = 4,
        [Display(Name = "已过期")]
        Expired = 5,
        [Display(Name = "冻结")]
        Frozen = 6
    }
}