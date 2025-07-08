using System.ComponentModel.DataAnnotations;

namespace ComprehensiveManagementSystem.Models
{
    public class UnitOfMeasure
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "单位名称不能为空")]
        [StringLength(50, ErrorMessage = "单位名称长度不能超过50个字符")]
        [Display(Name = "单位名称")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "单位符号不能为空")]
        [StringLength(10, ErrorMessage = "单位符号长度不能超过10个字符")]
        [Display(Name = "单位符号")]
        public string Symbol { get; set; } = string.Empty;

        [Display(Name = "单位类型")]
        public UnitType Type { get; set; } = UnitType.Quantity;

        [Display(Name = "描述")]
        [StringLength(200, ErrorMessage = "描述长度不能超过200个字符")]
        public string? Description { get; set; }

        [Display(Name = "换算比例")]
        [Range(0.000001, double.MaxValue, ErrorMessage = "换算比例必须大于0")]
        public decimal ConversionFactor { get; set; } = 1;

        [Display(Name = "基础单位")]
        public int? BaseUnitId { get; set; }
        public virtual UnitOfMeasure? BaseUnit { get; set; }

        [Display(Name = "是否启用")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "创建时间")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "更新时间")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // 导航属性
        public virtual ICollection<UnitOfMeasure> DerivedUnits { get; set; } = new List<UnitOfMeasure>();
    }

    public enum UnitType
    {
        [Display(Name = "数量")]
        Quantity = 1,
        [Display(Name = "重量")]
        Weight = 2,
        [Display(Name = "长度")]
        Length = 3,
        [Display(Name = "面积")]
        Area = 4,
        [Display(Name = "体积")]
        Volume = 5,
        [Display(Name = "时间")]
        Time = 6,
        [Display(Name = "温度")]
        Temperature = 7,
        [Display(Name = "压力")]
        Pressure = 8,
        [Display(Name = "电流")]
        Current = 9,
        [Display(Name = "电压")]
        Voltage = 10
    }
}