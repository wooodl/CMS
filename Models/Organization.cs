using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComprehensiveManagementSystem.Models
{
    public class Organization
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "机构名称不能为空")]
        [StringLength(100, ErrorMessage = "机构名称长度不能超过100个字符")]
        [Display(Name = "机构名称")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "机构类型不能为空")]
        [Display(Name = "机构类型")]
        public OrganizationType Type { get; set; }

        [Display(Name = "显示序号")]
        public int DisplayOrder { get; set; } = 0;

        [Display(Name = "地点")]
        [StringLength(200, ErrorMessage = "地点长度不能超过200个字符")]
        public string? Location { get; set; }

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注长度不能超过500个字符")]
        public string? Remark { get; set; }

        [Display(Name = "父机构")]
        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public virtual Organization? Parent { get; set; }

        [Display(Name = "子机构")]
        public virtual ICollection<Organization> Children { get; set; } = new List<Organization>();

        [Display(Name = "创建时间")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "更新时间")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // 导航属性
        public virtual ICollection<Personnel> Personnel { get; set; } = new List<Personnel>();
    }
}