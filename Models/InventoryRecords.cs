using System.ComponentModel.DataAnnotations;

namespace ComprehensiveManagementSystem.Models
{
    // 入库记录
    public class InboundRecord
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "入库单号不能为空")]
        [StringLength(50, ErrorMessage = "入库单号长度不能超过50个字符")]
        [Display(Name = "入库单号")]
        public string RecordNumber { get; set; } = string.Empty;

        [Display(Name = "物品编码")]
        [StringLength(50, ErrorMessage = "物品编码长度不能超过50个字符")]
        public string? ItemCode { get; set; }

        [Required(ErrorMessage = "物品名称不能为空")]
        [StringLength(200, ErrorMessage = "物品名称长度不能超过200个字符")]
        [Display(Name = "物品名称")]
        public string ItemName { get; set; } = string.Empty;

        [Display(Name = "规格型号")]
        [StringLength(100, ErrorMessage = "规格型号长度不能超过100个字符")]
        public string? Specification { get; set; }

        [Display(Name = "入库数量")]
        [Range(0.001, double.MaxValue, ErrorMessage = "入库数量必须大于0")]
        public decimal Quantity { get; set; }

        [Display(Name = "计量单位")]
        [StringLength(20, ErrorMessage = "计量单位长度不能超过20个字符")]
        public string? Unit { get; set; }

        [Display(Name = "单价")]
        [Range(0, double.MaxValue, ErrorMessage = "单价不能为负数")]
        [DataType(DataType.Currency)]
        public decimal? UnitPrice { get; set; }

        [Display(Name = "总价")]
        [Range(0, double.MaxValue, ErrorMessage = "总价不能为负数")]
        [DataType(DataType.Currency)]
        public decimal? TotalPrice { get; set; }

        [Display(Name = "供应商")]
        [StringLength(200, ErrorMessage = "供应商名称长度不能超过200个字符")]
        public string? Supplier { get; set; }

        [Display(Name = "库房")]
        [StringLength(100, ErrorMessage = "库房名称长度不能超过100个字符")]
        public string? Warehouse { get; set; }

        [Display(Name = "存放位置")]
        [StringLength(100, ErrorMessage = "存放位置长度不能超过100个字符")]
        public string? StorageLocation { get; set; }

        [Display(Name = "批次号")]
        [StringLength(50, ErrorMessage = "批次号长度不能超过50个字符")]
        public string? BatchNumber { get; set; }

        [Display(Name = "生产日期")]
        [DataType(DataType.Date)]
        public DateTime? ProductionDate { get; set; }

        [Display(Name = "过期日期")]
        [DataType(DataType.Date)]
        public DateTime? ExpiryDate { get; set; }

        [Display(Name = "入库日期")]
        [DataType(DataType.Date)]
        public DateTime InboundDate { get; set; } = DateTime.Now;

        [Display(Name = "经办人")]
        [StringLength(100, ErrorMessage = "经办人姓名长度不能超过100个字符")]
        public string? Handler { get; set; }

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注长度不能超过500个字符")]
        public string? Remarks { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    // 出库记录
    public class OutboundRecord
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "出库单号不能为空")]
        [StringLength(50, ErrorMessage = "出库单号长度不能超过50个字符")]
        [Display(Name = "出库单号")]
        public string RecordNumber { get; set; } = string.Empty;

        [Display(Name = "物品编码")]
        [StringLength(50, ErrorMessage = "物品编码长度不能超过50个字符")]
        public string? ItemCode { get; set; }

        [Required(ErrorMessage = "物品名称不能为空")]
        [StringLength(200, ErrorMessage = "物品名称长度不能超过200个字符")]
        [Display(Name = "物品名称")]
        public string ItemName { get; set; } = string.Empty;

        [Display(Name = "规格型号")]
        [StringLength(100, ErrorMessage = "规格型号长度不能超过100个字符")]
        public string? Specification { get; set; }

        [Display(Name = "出库数量")]
        [Range(0.001, double.MaxValue, ErrorMessage = "出库数量必须大于0")]
        public decimal Quantity { get; set; }

        [Display(Name = "计量单位")]
        [StringLength(20, ErrorMessage = "计量单位长度不能超过20个字符")]
        public string? Unit { get; set; }

        [Display(Name = "单价")]
        [Range(0, double.MaxValue, ErrorMessage = "单价不能为负数")]
        [DataType(DataType.Currency)]
        public decimal? UnitPrice { get; set; }

        [Display(Name = "总价")]
        [Range(0, double.MaxValue, ErrorMessage = "总价不能为负数")]
        [DataType(DataType.Currency)]
        public decimal? TotalPrice { get; set; }

        [Display(Name = "领用部门")]
        [StringLength(100, ErrorMessage = "领用部门名称长度不能超过100个字符")]
        public string? Department { get; set; }

        [Display(Name = "领用人")]
        [StringLength(100, ErrorMessage = "领用人姓名长度不能超过100个字符")]
        public string? Recipient { get; set; }

        [Display(Name = "用途")]
        [StringLength(200, ErrorMessage = "用途说明长度不能超过200个字符")]
        public string? Purpose { get; set; }

        [Display(Name = "库房")]
        [StringLength(100, ErrorMessage = "库房名称长度不能超过100个字符")]
        public string? Warehouse { get; set; }

        [Display(Name = "批次号")]
        [StringLength(50, ErrorMessage = "批次号长度不能超过50个字符")]
        public string? BatchNumber { get; set; }

        [Display(Name = "出库日期")]
        [DataType(DataType.Date)]
        public DateTime OutboundDate { get; set; } = DateTime.Now;

        [Display(Name = "经办人")]
        [StringLength(100, ErrorMessage = "经办人姓名长度不能超过100个字符")]
        public string? Handler { get; set; }

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注长度不能超过500个字符")]
        public string? Remarks { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    // 移库记录
    public class TransferRecord
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "移库单号不能为空")]
        [StringLength(50, ErrorMessage = "移库单号长度不能超过50个字符")]
        [Display(Name = "移库单号")]
        public string RecordNumber { get; set; } = string.Empty;

        [Display(Name = "物品编码")]
        [StringLength(50, ErrorMessage = "物品编码长度不能超过50个字符")]
        public string? ItemCode { get; set; }

        [Required(ErrorMessage = "物品名称不能为空")]
        [StringLength(200, ErrorMessage = "物品名称长度不能超过200个字符")]
        [Display(Name = "物品名称")]
        public string ItemName { get; set; } = string.Empty;

        [Display(Name = "规格型号")]
        [StringLength(100, ErrorMessage = "规格型号长度不能超过100个字符")]
        public string? Specification { get; set; }

        [Display(Name = "移库数量")]
        [Range(0.001, double.MaxValue, ErrorMessage = "移库数量必须大于0")]
        public decimal Quantity { get; set; }

        [Display(Name = "计量单位")]
        [StringLength(20, ErrorMessage = "计量单位长度不能超过20个字符")]
        public string? Unit { get; set; }

        [Display(Name = "源库房")]
        [StringLength(100, ErrorMessage = "源库房名称长度不能超过100个字符")]
        public string? FromWarehouse { get; set; }

        [Display(Name = "源位置")]
        [StringLength(100, ErrorMessage = "源位置长度不能超过100个字符")]
        public string? FromLocation { get; set; }

        [Display(Name = "目标库房")]
        [StringLength(100, ErrorMessage = "目标库房名称长度不能超过100个字符")]
        public string? ToWarehouse { get; set; }

        [Display(Name = "目标位置")]
        [StringLength(100, ErrorMessage = "目标位置长度不能超过100个字符")]
        public string? ToLocation { get; set; }

        [Display(Name = "移库原因")]
        [StringLength(200, ErrorMessage = "移库原因长度不能超过200个字符")]
        public string? Reason { get; set; }

        [Display(Name = "批次号")]
        [StringLength(50, ErrorMessage = "批次号长度不能超过50个字符")]
        public string? BatchNumber { get; set; }

        [Display(Name = "移库日期")]
        [DataType(DataType.Date)]
        public DateTime TransferDate { get; set; } = DateTime.Now;

        [Display(Name = "经办人")]
        [StringLength(100, ErrorMessage = "经办人姓名长度不能超过100个字符")]
        public string? Handler { get; set; }

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注长度不能超过500个字符")]
        public string? Remarks { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    // 盘点记录
    public class StockTaking
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "盘点单号不能为空")]
        [StringLength(50, ErrorMessage = "盘点单号长度不能超过50个字符")]
        [Display(Name = "盘点单号")]
        public string RecordNumber { get; set; } = string.Empty;

        [Display(Name = "物品编码")]
        [StringLength(50, ErrorMessage = "物品编码长度不能超过50个字符")]
        public string? ItemCode { get; set; }

        [Required(ErrorMessage = "物品名称不能为空")]
        [StringLength(200, ErrorMessage = "物品名称长度不能超过200个字符")]
        [Display(Name = "物品名称")]
        public string ItemName { get; set; } = string.Empty;

        [Display(Name = "规格型号")]
        [StringLength(100, ErrorMessage = "规格型号长度不能超过100个字符")]
        public string? Specification { get; set; }

        [Display(Name = "账面数量")]
        [Range(0, double.MaxValue, ErrorMessage = "账面数量不能为负数")]
        public decimal BookQuantity { get; set; }

        [Display(Name = "实际数量")]
        [Range(0, double.MaxValue, ErrorMessage = "实际数量不能为负数")]
        public decimal ActualQuantity { get; set; }

        [Display(Name = "盈亏数量")]
        public decimal DifferenceQuantity => ActualQuantity - BookQuantity;

        [Display(Name = "计量单位")]
        [StringLength(20, ErrorMessage = "计量单位长度不能超过20个字符")]
        public string? Unit { get; set; }

        [Display(Name = "单价")]
        [Range(0, double.MaxValue, ErrorMessage = "单价不能为负数")]
        [DataType(DataType.Currency)]
        public decimal? UnitPrice { get; set; }

        [Display(Name = "盈亏金额")]
        [DataType(DataType.Currency)]
        public decimal DifferenceAmount => DifferenceQuantity * (UnitPrice ?? 0);

        [Display(Name = "库房")]
        [StringLength(100, ErrorMessage = "库房名称长度不能超过100个字符")]
        public string? Warehouse { get; set; }

        [Display(Name = "存放位置")]
        [StringLength(100, ErrorMessage = "存放位置长度不能超过100个字符")]
        public string? StorageLocation { get; set; }

        [Display(Name = "批次号")]
        [StringLength(50, ErrorMessage = "批次号长度不能超过50个字符")]
        public string? BatchNumber { get; set; }

        [Display(Name = "盘点日期")]
        [DataType(DataType.Date)]
        public DateTime StockTakingDate { get; set; } = DateTime.Now;

        [Display(Name = "盘点人")]
        [StringLength(100, ErrorMessage = "盘点人姓名长度不能超过100个字符")]
        public string? StockTaker { get; set; }

        [Display(Name = "复核人")]
        [StringLength(100, ErrorMessage = "复核人姓名长度不能超过100个字符")]
        public string? Reviewer { get; set; }

        [Display(Name = "差异原因")]
        [StringLength(200, ErrorMessage = "差异原因长度不能超过200个字符")]
        public string? DifferenceReason { get; set; }

        [Display(Name = "处理状态")]
        public StockTakingStatus Status { get; set; } = StockTakingStatus.Pending;

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注长度不能超过500个字符")]
        public string? Remarks { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    public enum StockTakingStatus
    {
        [Display(Name = "待处理")]
        Pending = 1,
        [Display(Name = "已处理")]
        Processed = 2,
        [Display(Name = "已忽略")]
        Ignored = 3
    }
}