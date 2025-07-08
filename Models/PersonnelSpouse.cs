using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComprehensiveManagementSystem.Models
{
    /// <summary>
    /// 人员配偶信息表
    /// </summary>
    [Table("PersonnelSpouse")]
    public class PersonnelSpouse
    {
        /// <summary>
        /// 配偶信息ID（主键，使用雪花算法）
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// 人员ID（外键，一对一关系）
        /// </summary>
        [Required(ErrorMessage = "人员ID不能为空")]
        public Guid PersonnelId { get; set; }

        /// <summary>
        /// 人员基本信息导航属性
        /// </summary>
        [ForeignKey("PersonnelId")]
        public PersonnelBasicInfo Personnel { get; set; } = null!;

        /// <summary>
        /// 配偶姓名
        /// </summary>
        [Required(ErrorMessage = "配偶姓名不能为空")]
        [StringLength(50, ErrorMessage = "配偶姓名长度不能超过50个字符")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 配偶籍贯
        /// </summary>
        [StringLength(100, ErrorMessage = "配偶籍贯长度不能超过100个字符")]
        public string? NativePlace { get; set; }

        /// <summary>
        /// 配偶出生年月
        /// </summary>
        [Required(ErrorMessage = "配偶出生年月不能为空")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// 配偶民族
        /// </summary>
        [StringLength(50, ErrorMessage = "配偶民族长度不能超过50个字符")]
        public string? Nation { get; set; }

        /// <summary>
        /// 配偶学历
        /// </summary>
        [StringLength(50, ErrorMessage = "配偶学历长度不能超过50个字符")]
        public string? Education { get; set; }

        /// <summary>
        /// 结婚时间
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime? MarriageDate { get; set; }

        /// <summary>
        /// 配偶政治面貌
        /// </summary>
        [StringLength(50, ErrorMessage = "配偶政治面貌长度不能超过50个字符")]
        public string? PoliticalStatus { get; set; }

        /// <summary>
        /// 配偶是否为同类型人员
        /// </summary>
        public bool IsSameType { get; set; } = false;

        /// <summary>
        /// 配偶是否在本地
        /// </summary>
        public bool IsLocal { get; set; } = false;

        /// <summary>
        /// 配偶到本地时间
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime? LocalArrivalDate { get; set; }

        /// <summary>
        /// 配偶工作单位
        /// </summary>
        [StringLength(200, ErrorMessage = "配偶工作单位长度不能超过200个字符")]
        public string? WorkUnit { get; set; }

        /// <summary>
        /// 配偶职务
        /// </summary>
        [StringLength(100, ErrorMessage = "配偶职务长度不能超过100个字符")]
        public string? Position { get; set; }

        /// <summary>
        /// 配偶联系电话
        /// </summary>
        [StringLength(50, ErrorMessage = "配偶联系电话长度不能超过50个字符")]
        [RegularExpression(@"^1[3-9]\d{9}$", ErrorMessage = "配偶手机号格式不正确")]
        public string? Phone { get; set; }

        /// <summary>
        /// 配偶身份证号
        /// </summary>
        [StringLength(18, MinimumLength = 18, ErrorMessage = "配偶身份证号必须为18位")]
        [RegularExpression(@"^\d{17}[\dXx]$", ErrorMessage = "配偶身份证号格式不正确")]
        public string? IdCard { get; set; }

        /// <summary>
        /// 配偶工作证号
        /// </summary>
        [StringLength(50, ErrorMessage = "配偶工作证号长度不能超过50个字符")]
        public string? WorkId { get; set; }

        /// <summary>
        /// 配偶住址
        /// </summary>
        [StringLength(200, ErrorMessage = "配偶住址长度不能超过200个字符")]
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
}