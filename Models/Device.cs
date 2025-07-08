using System.ComponentModel.DataAnnotations;

namespace ComprehensiveManagementSystem.Models
{
    public class Device
    {
        public long Id { get; set; } // 使用雪花算法生成

        [Required(ErrorMessage = "物品编码不能为空")]
        [StringLength(50, ErrorMessage = "物品编码长度不能超过50个字符")]
        [Display(Name = "物品编码")]
        public string ItemCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "设备名称不能为空")]
        [StringLength(200, ErrorMessage = "设备名称长度不能超过200个字符")]
        [Display(Name = "设备名称")]
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

        [Display(Name = "资产编号")]
        [StringLength(50, ErrorMessage = "资产编号长度不能超过50个字符")]
        public string? AssetNumber { get; set; }

        [Display(Name = "制造日期")]
        [DataType(DataType.Date)]
        public DateTime? ManufactureDate { get; set; }

        [Display(Name = "采购日期")]
        [DataType(DataType.Date)]
        public DateTime? PurchaseDate { get; set; }

        [Display(Name = "安装日期")]
        [DataType(DataType.Date)]
        public DateTime? InstallationDate { get; set; }

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

        [Display(Name = "电源要求")]
        [StringLength(100, ErrorMessage = "电源要求长度不能超过100个字符")]
        public string? PowerRequirement { get; set; }

        [Display(Name = "工作环境")]
        [StringLength(200, ErrorMessage = "工作环境长度不能超过200个字符")]
        public string? WorkingEnvironment { get; set; }

        [Display(Name = "状态")]
        public DeviceStatus Status { get; set; } = DeviceStatus.Normal;

        [Display(Name = "位置")]
        [StringLength(200, ErrorMessage = "位置信息长度不能超过200个字符")]
        public string? Location { get; set; }

        [Display(Name = "责任人")]
        [StringLength(100, ErrorMessage = "责任人姓名长度不能超过100个字符")]
        public string? ResponsiblePerson { get; set; }

        [Display(Name = "上次维护日期")]
        [DataType(DataType.Date)]
        public DateTime? LastMaintenanceDate { get; set; }

        [Display(Name = "下次维护日期")]
        [DataType(DataType.Date)]
        public DateTime? NextMaintenanceDate { get; set; }

        [Display(Name = "维护周期(天)")]
        [Range(0, int.MaxValue, ErrorMessage = "维护周期不能为负数")]
        public int? MaintenanceCycleDays { get; set; }

        [Display(Name = "IP地址")]
        [StringLength(50, ErrorMessage = "IP地址长度不能超过50个字符")]
        public string? IpAddress { get; set; }

        [Display(Name = "MAC地址")]
        [StringLength(50, ErrorMessage = "MAC地址长度不能超过50个字符")]
        public string? MacAddress { get; set; }

        [Display(Name = "备注")]
        [StringLength(1000, ErrorMessage = "备注长度不能超过1000个字符")]
        public string? Remarks { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "更新时间")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }

    public enum DeviceStatus
    {
        [Display(Name = "正常")]
        Normal = 1,
        [Display(Name = "运行中")]
        Running = 2,
        [Display(Name = "维护中")]
        Maintenance = 3,
        [Display(Name = "故障")]
        Malfunction = 4,
        [Display(Name = "停用")]
        Disabled = 5,
        [Display(Name = "报废")]
        Scrapped = 6
    }
}