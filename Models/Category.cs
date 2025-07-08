using System.ComponentModel.DataAnnotations;

namespace ComprehensiveManagementSystem.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "类别名称不能为空")]
        [StringLength(100, ErrorMessage = "类别名称长度不能超过100个字符")]
        [Display(Name = "类别名称")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "类别编码不能为空")]
        [StringLength(20, ErrorMessage = "类别编码长度不能超过20个字符")]
        [Display(Name = "类别编码")]
        public string Code { get; set; } = string.Empty;

        [Display(Name = "父类别")]
        public int? ParentId { get; set; }
        public virtual Category? Parent { get; set; }

        [Display(Name = "类别描述")]
        [StringLength(500, ErrorMessage = "类别描述长度不能超过500个字符")]
        public string? Description { get; set; }

        [Display(Name = "排序")]
        public int SortOrder { get; set; } = 0;

        [Display(Name = "是否启用")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "创建时间")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "更新时间")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // 导航属性
        public virtual ICollection<Category> Children { get; set; } = new List<Category>();
    }
}