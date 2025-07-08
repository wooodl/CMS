using System.ComponentModel.DataAnnotations;

namespace ComprehensiveManagementSystem.Models
{
    public class Kit
    {
        public long Id { get; set; } // 使用雪花算法生成

        [Required(ErrorMessage = "物品编码不能为空")]
        [StringLength(50, ErrorMessage = "物品编码长度不能超过50个字符")]
        [Display(Name = "物品编码")]
        public string ItemCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "装具名称不能为空")]
        [StringLength(200, ErrorMessage = "装具名称长度不能超过200个字符")]
        [Display(Name = "装具名称")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "型号")]
        [StringLength(100, ErrorMessage = "型号长度不能超过100个字符")]
        public string? Model { get; set; }

        [Display(Name = "规格")]
        [StringLength(200, ErrorMessage = "规格长度不能超过200个字符")]
        public string? Specification { get; set; }

        [Display(Name = "类别")]
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        [Display(Name = "制造商")]
        public int? ManufacturerId { get; set; }
        public virtual Manufacturer? Manufacturer { get; set; }

        [Display(Name = "序列号")]
        [StringLength(100, ErrorMessage = "序列号长度不能超过100个字符")]
        public string? SerialNumber { get; set; }

        [Display(Name = "尺寸")]
        [StringLength(100, ErrorMessage = "尺寸长度不能超过100个字符")]
        public string? Size { get; set; }

        [Display(Name = "颜色")]
        [StringLength(50, ErrorMessage = "颜色长度不能超过50个字符")]
        public string? Color { get; set; }

        [Display(Name = "材质")]
        [StringLength(100, ErrorMessage = "材质长度不能超过100个字符")]
        public string? Material { get; set; }

        [Display(Name = "重量(kg)")]
        [Range(0, double.MaxValue, ErrorMessage = "重量不能为负数")]
        public decimal? Weight { get; set; }

        [Display(Name = "制造日期")]
        [DataType(DataType.Date)]
        public DateTime? ManufactureDate { get; set; }

        [Display(Name = "采购日期")]
        [DataType(DataType.Date)]
        public DateTime? PurchaseDate { get; set; }

        [Display(Name = "采购价格")]
        [Range(0, double.MaxValue, ErrorMessage = "采购价格不能为负数")]
        [DataType(DataType.Currency)]
        public decimal? PurchasePrice { get; set; }

        [Display(Name = "使用寿命(年)")]
        [Range(0, int.MaxValue, ErrorMessage = "使用寿命不能为负数")]
        public int? LifeSpanYears { get; set; }

        [Display(Name = "保修期(月)")]
        [Range(0, int.MaxValue, ErrorMessage = "保修期不能为负数")]
        public int? WarrantyMonths { get; set; }

        [Display(Name = "状态")]
        public KitStatus Status { get; set; } = KitStatus.Available;

        [Display(Name = "存放位置")]
        [StringLength(200, ErrorMessage = "存放位置长度不能超过200个字符")]
        public string? Location { get; set; }

        [Display(Name = "责任人")]
        [StringLength(100, ErrorMessage = "责任人姓名长度不能超过100个字符")]
        public string? ResponsiblePerson { get; set; }

        [Display(Name = "上次检查日期")]
        [DataType(DataType.Date)]
        public DateTime? LastInspectionDate { get; set; }

        [Display(Name = "下次检查日期")]
        [DataType(DataType.Date)]
        public DateTime? NextInspectionDate { get; set; }

        [Display(Name = "检查周期(天)")]
        [Range(0, int.MaxValue, ErrorMessage = "检查周期不能为负数")]
        public int? InspectionCycleDays { get; set; }

        [Display(Name = "清洗要求")]
        [StringLength(200, ErrorMessage = "清洗要求长度不能超过200个字符")]
        public string? CleaningRequirement { get; set; }

        [Display(Name = "存储要求")]
        [StringLength(200, ErrorMessage = "存储要求长度不能超过200个字符")]
        public string? StorageRequirement { get; set; }

        [Display(Name = "备注")]
        [StringLength(1000, ErrorMessage = "备注长度不能超过1000个字符")]
        public string? Remarks { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "更新时间")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }

    public enum KitStatus
    {
        [Display(Name = "可用")]
        Available = 1,
        [Display(Name = "借出")]
        CheckedOut = 2,
        [Display(Name = "维护中")]
        Maintenance = 3,
        [Display(Name = "清洗中")]
        Cleaning = 4,
        [Display(Name = "损坏")]
        Damaged = 5,
        [Display(Name = "报废")]
        Scrapped = 6
    }
}