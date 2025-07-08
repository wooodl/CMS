using System.ComponentModel.DataAnnotations;

namespace ComprehensiveManagementSystem.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "部门名称不能为空")]
        [StringLength(100, ErrorMessage = "部门名称长度不能超过100个字符")]
        [Display(Name = "部门名称")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "部门编码不能为空")]
        [StringLength(20, ErrorMessage = "部门编码长度不能超过20个字符")]
        [Display(Name = "部门编码")]
        public string Code { get; set; } = string.Empty;

        [Display(Name = "部门描述")]
        [StringLength(500, ErrorMessage = "部门描述长度不能超过500个字符")]
        public string? Description { get; set; }

        [Display(Name = "负责人")]
        [StringLength(100, ErrorMessage = "负责人姓名长度不能超过100个字符")]
        public string? Manager { get; set; }

        [Display(Name = "联系电话")]
        [StringLength(20, ErrorMessage = "联系电话长度不能超过20个字符")]
        public string? Phone { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "更新时间")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // 导航属性
        public virtual ICollection<Personnel> Personnel { get; set; } = new List<Personnel>();
    }
}