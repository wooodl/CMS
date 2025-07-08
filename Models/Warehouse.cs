using System.ComponentModel.DataAnnotations;

namespace ComprehensiveManagementSystem.Models
{
    public class Warehouse
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "库房名称不能为空")]
        [StringLength(100, ErrorMessage = "库房名称长度不能超过100个字符")]
        [Display(Name = "库房名称")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "库房编码不能为空")]
        [StringLength(20, ErrorMessage = "库房编码长度不能超过20个字符")]
        [Display(Name = "库房编码")]
        public string Code { get; set; } = string.Empty;

        [Display(Name = "库房类型")]
        public WarehouseType Type { get; set; } = WarehouseType.General;

        [Display(Name = "位置")]
        [StringLength(200, ErrorMessage = "位置信息长度不能超过200个字符")]
        public string? Location { get; set; }

        [Display(Name = "面积(平方米)")]
        [Range(0, double.MaxValue, ErrorMessage = "面积不能为负数")]
        public decimal? Area { get; set; }

        [Display(Name = "容量(立方米)")]
        [Range(0, double.MaxValue, ErrorMessage = "容量不能为负数")]
        public decimal? Capacity { get; set; }

        [Display(Name = "温度要求")]
        [StringLength(100, ErrorMessage = "温度要求长度不能超过100个字符")]
        public string? TemperatureRequirement { get; set; }

        [Display(Name = "湿度要求")]
        [StringLength(100, ErrorMessage = "湿度要求长度不能超过100个字符")]
        public string? HumidityRequirement { get; set; }

        [Display(Name = "负责人")]
        [StringLength(100, ErrorMessage = "负责人姓名长度不能超过100个字符")]
        public string? Manager { get; set; }

        [Display(Name = "联系电话")]
        [StringLength(20, ErrorMessage = "联系电话长度不能超过20个字符")]
        public string? Phone { get; set; }

        [Display(Name = "描述")]
        [StringLength(500, ErrorMessage = "描述长度不能超过500个字符")]
        public string? Description { get; set; }

        [Display(Name = "是否启用")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "创建时间")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "更新时间")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // 导航属性
        public virtual ICollection<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>();
    }

    public enum WarehouseType
    {
        [Display(Name = "普通库房")]
        General = 1,
        [Display(Name = "冷藏库房")]
        Refrigerated = 2,
        [Display(Name = "危险品库房")]
        Hazardous = 3,
        [Display(Name = "精密仪器库房")]
        Precision = 4,
        [Display(Name = "临时库房")]
        Temporary = 5
    }
}