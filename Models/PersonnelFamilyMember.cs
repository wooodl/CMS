using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComprehensiveManagementSystem.Models
{
    /// <summary>
    /// 人员家庭成员信息表
    /// </summary>
    [Table("PersonnelFamilyMember")]
    public class PersonnelFamilyMember
    {
        /// <summary>
        /// 家庭成员ID（主键，使用雪花算法）
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// 人员ID（外键）
        /// </summary>
        [Required(ErrorMessage = "人员ID不能为空")]
        public Guid PersonnelId { get; set; }

        /// <summary>
        /// 人员基本信息导航属性
        /// </summary>
        [ForeignKey("PersonnelId")]
        public PersonnelBasicInfo Personnel { get; set; } = null!;

        /// <summary>
        /// 家庭成员关系类型
        /// </summary>
        [Required(ErrorMessage = "家庭成员关系类型不能为空")]
        public FamilyRelationType RelationType { get; set; }

        /// <summary>
        /// 成员姓名
        /// </summary>
        [Required(ErrorMessage = "成员姓名不能为空")]
        [StringLength(50, ErrorMessage = "成员姓名长度不能超过50个字符")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 性别（0-女，1-男）
        /// </summary>
        [Required(ErrorMessage = "性别不能为空")]
        public Gender Gender { get; set; }

        /// <summary>
        /// 籍贯
        /// </summary>
        [StringLength(100, ErrorMessage = "籍贯长度不能超过100个字符")]
        public string? NativePlace { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        [StringLength(50, ErrorMessage = "民族长度不能超过50个字符")]
        public string? Nation { get; set; }

        /// <summary>
        /// 出生年月
        /// </summary>
        [Required(ErrorMessage = "出生年月不能为空")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// 政治面貌
        /// </summary>
        [StringLength(50, ErrorMessage = "政治面貌长度不能超过50个字符")]
        public string? PoliticalStatus { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [StringLength(18, MinimumLength = 18, ErrorMessage = "身份证号必须为18位")]
        [RegularExpression(@"^\d{17}[\dXx]$", ErrorMessage = "身份证号格式不正确")]
        public string? IdCard { get; set; }

        /// <summary>
        /// 所在单位
        /// </summary>
        [StringLength(200, ErrorMessage = "所在单位长度不能超过200个字符")]
        public string? WorkUnit { get; set; }

        /// <summary>
        /// 职务
        /// </summary>
        [StringLength(100, ErrorMessage = "职务长度不能超过100个字符")]
        public string? Position { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [StringLength(50, ErrorMessage = "联系电话长度不能超过50个字符")]
        [RegularExpression(@"^1[3-9]\d{9}$", ErrorMessage = "手机号格式不正确")]
        public string? Phone { get; set; }

        /// <summary>
        /// 住址
        /// </summary>
        [StringLength(200, ErrorMessage = "住址长度不能超过200个字符")]
        public string? Address { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(1000, ErrorMessage = "备注长度不能超过1000个字符")]
        public string? Remark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; } = false;
    }

    /// <summary>
    /// 家庭成员关系类型枚举
    /// </summary>
    public enum FamilyRelationType
    {
        /// <summary>
        /// 子女
        /// </summary>
        Child = 0,
        /// <summary>
        /// 父亲
        /// </summary>
        Father = 1,
        /// <summary>
        /// 母亲
        /// </summary>
        Mother = 2,
        /// <summary>
        /// 配偶父亲
        /// </summary>
        SpouseFather = 3,
        /// <summary>
        /// 配偶母亲
        /// </summary>
        SpouseMother = 4,
        /// <summary>
        /// 其他
        /// </summary>
        Other = 5
    }
}