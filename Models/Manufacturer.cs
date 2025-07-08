using System.ComponentModel.DataAnnotations;

namespace ComprehensiveManagementSystem.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "制造商名称不能为空")]
        [StringLength(200, ErrorMessage = "制造商名称长度不能超过200个字符")]
        [Display(Name = "制造商名称")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "制造商编码不能为空")]
        [StringLength(50, ErrorMessage = "制造商编码长度不能超过50个字符")]
        [Display(Name = "制造商编码")]
        public string Code { get; set; } = string.Empty;

        [Display(Name = "联系人")]
        [StringLength(100, ErrorMessage = "联系人姓名长度不能超过100个字符")]
        public string? ContactPerson { get; set; }

        [Display(Name = "联系电话")]
        [StringLength(50, ErrorMessage = "联系电话长度不能超过50个字符")]
        public string? Phone { get; set; }

        [Display(Name = "电子邮箱")]
        [EmailAddress(ErrorMessage = "请输入有效的电子邮箱地址")]
        [StringLength(200, ErrorMessage = "电子邮箱长度不能超过200个字符")]
        public string? Email { get; set; }

        [Display(Name = "官方网站")]
        [Url(ErrorMessage = "请输入有效的网站地址")]
        [StringLength(200, ErrorMessage = "网站地址长度不能超过200个字符")]
        public string? Website { get; set; }

        [Display(Name = "地址")]
        [StringLength(500, ErrorMessage = "地址长度不能超过500个字符")]
        public string? Address { get; set; }

        [Display(Name = "邮政编码")]
        [StringLength(20, ErrorMessage = "邮政编码长度不能超过20个字符")]
        public string? PostalCode { get; set; }

        [Display(Name = "国家")]
        [StringLength(100, ErrorMessage = "国家名称长度不能超过100个字符")]
        public string? Country { get; set; }

        [Display(Name = "省份/州")]
        [StringLength(100, ErrorMessage = "省份/州名称长度不能超过100个字符")]
        public string? Province { get; set; }

        [Display(Name = "城市")]
        [StringLength(100, ErrorMessage = "城市名称长度不能超过100个字符")]
        public string? City { get; set; }

        [Display(Name = "税号")]
        [StringLength(50, ErrorMessage = "税号长度不能超过50个字符")]
        public string? TaxNumber { get; set; }

        [Display(Name = "注册资本")]
        [Range(0, double.MaxValue, ErrorMessage = "注册资本不能为负数")]
        [DataType(DataType.Currency)]
        public decimal? RegisteredCapital { get; set; }

        [Display(Name = "成立日期")]
        [DataType(DataType.Date)]
        public DateTime? EstablishedDate { get; set; }

        [Display(Name = "认证信息")]
        [StringLength(500, ErrorMessage = "认证信息长度不能超过500个字符")]
        public string? Certification { get; set; }

        [Display(Name = "备注")]
        [StringLength(1000, ErrorMessage = "备注长度不能超过1000个字符")]
        public string? Remarks { get; set; }

        [Display(Name = "是否启用")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "创建时间")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "更新时间")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}