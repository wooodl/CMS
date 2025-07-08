using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ComprehensiveManagementSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "真实姓名不能为空")]
        [StringLength(100, ErrorMessage = "真实姓名长度不能超过100个字符")]
        [Display(Name = "真实姓名")]
        public string RealName { get; set; } = string.Empty;

        [Display(Name = "性别")]
        public Gender? Gender { get; set; }

        [Display(Name = "出生日期")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "身份证号")]
        [StringLength(18, ErrorMessage = "身份证号长度不能超过18个字符")]
        public string? IdCard { get; set; }

        [Display(Name = "职位")]
        [StringLength(100, ErrorMessage = "职位长度不能超过100个字符")]
        public string? Position { get; set; }

        [Display(Name = "部门")]
        public int? DepartmentId { get; set; }
        public virtual Department? Department { get; set; }

        [Display(Name = "头像")]
        [StringLength(200, ErrorMessage = "头像路径长度不能超过200个字符")]
        public string? Avatar { get; set; }

        [Display(Name = "是否启用")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "最后登录时间")]
        public DateTime? LastLoginTime { get; set; }

        [Display(Name = "登录次数")]
        public int LoginCount { get; set; } = 0;

        [Display(Name = "创建时间")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "更新时间")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注长度不能超过500个字符")]
        public string? Remarks { get; set; }
    }
}