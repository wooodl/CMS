using System.ComponentModel.DataAnnotations;

namespace ComprehensiveManagementSystem.Models
{
    public class Aircraft
    {
        public long Id { get; set; } // 使用雪花算法生成

        [Required(ErrorMessage = "物品编码不能为空")]
        [StringLength(50, ErrorMessage = "物品编码长度不能超过50个字符")]
        [Display(Name = "物品编码")]
        public string ItemCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "飞机名称不能为空")]
        [StringLength(200, ErrorMessage = "飞机名称长度不能超过200个字符")]
        [Display(Name = "飞机名称")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "机尾号不能为空")]
        [StringLength(20, ErrorMessage = "机尾号长度不能超过20个字符")]
        [Display(Name = "机尾号")]
        public string TailNumber { get; set; } = string.Empty;

        [Display(Name = "型号")]
        [StringLength(100, ErrorMessage = "型号长度不能超过100个字符")]
        public string? Model { get; set; }

        [Display(Name = "类别")]
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        [Display(Name = "制造商")]
        public int? ManufacturerId { get; set; }
        public virtual Manufacturer? Manufacturer { get; set; }

        [Display(Name = "制造日期")]
        [DataType(DataType.Date)]
        public DateTime? ManufactureDate { get; set; }

        [Display(Name = "投入使用日期")]
        [DataType(DataType.Date)]
        public DateTime? CommissionDate { get; set; }

        [Display(Name = "飞行小时数")]
        [Range(0, double.MaxValue, ErrorMessage = "飞行小时数不能为负数")]
        public decimal? FlightHours { get; set; }

        [Display(Name = "起降次数")]
        [Range(0, int.MaxValue, ErrorMessage = "起降次数不能为负数")]
        public int? LandingCount { get; set; }

        [Display(Name = "最大起飞重量(kg)")]
        [Range(0, double.MaxValue, ErrorMessage = "最大起飞重量不能为负数")]
        public decimal? MaxTakeoffWeight { get; set; }

        [Display(Name = "最大载客量")]
        [Range(0, int.MaxValue, ErrorMessage = "最大载客量不能为负数")]
        public int? MaxPassengerCapacity { get; set; }

        [Display(Name = "状态")]
        public AircraftStatus Status { get; set; } = AircraftStatus.Active;

        [Display(Name = "位置")]
        [StringLength(200, ErrorMessage = "位置信息长度不能超过200个字符")]
        public string? Location { get; set; }

        [Display(Name = "维护状态")]
        public MaintenanceStatus MaintenanceStatus { get; set; } = MaintenanceStatus.Normal;

        [Display(Name = "下次维护日期")]
        [DataType(DataType.Date)]
        public DateTime? NextMaintenanceDate { get; set; }

        [Display(Name = "备注")]
        [StringLength(1000, ErrorMessage = "备注长度不能超过1000个字符")]
        public string? Remarks { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "更新时间")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }

    public enum AircraftStatus
    {
        [Display(Name = "服役中")]
        Active = 1,
        [Display(Name = "维护中")]
        Maintenance = 2,
        [Display(Name = "退役")]
        Retired = 3,
        [Display(Name = "封存")]
        Stored = 4
    }

    public enum MaintenanceStatus
    {
        [Display(Name = "正常")]
        Normal = 1,
        [Display(Name = "需要维护")]
        NeedsMaintenance = 2,
        [Display(Name = "维护中")]
        UnderMaintenance = 3,
        [Display(Name = "故障")]
        Malfunction = 4
    }
}