using System.ComponentModel.DataAnnotations;

namespace ComprehensiveManagementSystem.Models
{
    public class Personnel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "姓名不能为空")]
        [StringLength(100, ErrorMessage = "姓名长度不能超过100个字符")]
        [Display(Name = "姓名")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "工号不能为空")]
        [StringLength(50, ErrorMessage = "工号长度不能超过50个字符")]
        [Display(Name = "工号")]
        public string EmployeeNumber { get; set; } = string.Empty;

        [Display(Name = "性别")]
        public Gender Gender { get; set; } = Gender.Male;

        [Display(Name = "出生日期")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "身份证号")]
        [StringLength(18, ErrorMessage = "身份证号长度不能超过18个字符")]
        public string? IdCard { get; set; }

        [Display(Name = "联系电话")]
        [StringLength(20, ErrorMessage = "联系电话长度不能超过20个字符")]
        public string? Phone { get; set; }

        [Display(Name = "电子邮箱")]
        [EmailAddress(ErrorMessage = "请输入有效的电子邮箱地址")]
        public string? Email { get; set; }

        [Display(Name = "职位")]
        [StringLength(100, ErrorMessage = "职位长度不能超过100个字符")]
        public string? Position { get; set; }

        [Display(Name = "部门")]
        public int? DepartmentId { get; set; }
        public virtual Department? Department { get; set; }

        [Display(Name = "机构")]
        public int? OrganizationId { get; set; }
        public virtual Organization? Organization { get; set; }

        [Display(Name = "入职日期")]
        [DataType(DataType.Date)]
        public DateTime? HireDate { get; set; }

        [Display(Name = "状态")]
        public PersonnelStatus Status { get; set; } = PersonnelStatus.Active;

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "备注长度不能超过500个字符")]
        public string? Remarks { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "更新时间")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }

    public enum Gender
    {
        [Display(Name = "女")]
        Female = 0,
        [Display(Name = "男")]
        Male = 1
    }

    public enum PersonnelStatus
    {
        [Display(Name = "在职")]
        Active = 1,
        [Display(Name = "离职")]
        Inactive = 2,
        [Display(Name = "休假")]
        OnLeave = 3
    }
}