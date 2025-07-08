using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComprehensiveManagementSystem.Models
{
    /// <summary>
    /// 人员基本信息表
    /// </summary>
    [Table("PersonnelBasicInfo")]
    public class PersonnelBasicInfo
    {
        /// <summary>
        /// 人员ID（主键，使用GUID）
        /// </summary>
        [Key]
        public Guid PersonnelId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required(ErrorMessage = "姓名不能为空")]
        [StringLength(50, ErrorMessage = "姓名长度不能超过50个字符")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 性别（0-女，1-男）
        /// </summary>
        [Required(ErrorMessage = "性别不能为空")]
        public Gender Gender { get; set; }

        /// <summary>
        /// 出生年月
        /// </summary>
        [Required(ErrorMessage = "出生年月不能为空")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// 籍贯
        /// </summary>
        [StringLength(100, ErrorMessage = "籍贯长度不能超过100个字符")]
        public string? NativePlace { get; set; }

        /// <summary>
        /// 学历
        /// </summary>
        [StringLength(50, ErrorMessage = "学历长度不能超过50个字符")]
        public string? Education { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [Required(ErrorMessage = "身份证号不能为空")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "身份证号必须为18位")]
        [RegularExpression(@"^\d{17}[\dXx]$", ErrorMessage = "身份证号格式不正确")]
        public string IdCard { get; set; } = string.Empty;

        /// <summary>
        /// 入职年月
        /// </summary>
        [Required(ErrorMessage = "入职年月不能为空")]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        /// <summary>
        /// 政治面貌
        /// </summary>
        [StringLength(50, ErrorMessage = "政治面貌长度不能超过50个字符")]
        public string? PoliticalStatus { get; set; }

        /// <summary>
        /// 入党（团）时间
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime? PartyJoinDate { get; set; }

        /// <summary>
        /// 婚否（0-未婚，1-已婚，2-离异，3-丧偶）
        /// </summary>
        public MaritalStatus MaritalStatus { get; set; }

        /// <summary>
        /// 人员类别
        /// </summary>
        [StringLength(50, ErrorMessage = "人员类别长度不能超过50个字符")]
        public string? PersonnelCategory { get; set; }

        /// <summary>
        /// 级别
        /// </summary>
        [StringLength(50, ErrorMessage = "级别长度不能超过50个字符")]
        public string? Grade { get; set; }

        /// <summary>
        /// 最近级别调整时间
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime? LastGradeAdjustmentDate { get; set; }

        /// <summary>
        /// 待遇级别
        /// </summary>
        [StringLength(50, ErrorMessage = "待遇级别长度不能超过50个字符")]
        public string? TreatmentLevel { get; set; }

        /// <summary>
        /// 最近待遇调整时间
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime? LastTreatmentAdjustmentDate { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        public int? DepartmentId { get; set; }

        /// <summary>
        /// 部门导航属性
        /// </summary>
        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }

        /// <summary>
        /// 加入部门时间
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime? DepartmentJoinDate { get; set; }

        /// <summary>
        /// 岗位
        /// </summary>
        [StringLength(100, ErrorMessage = "岗位长度不能超过100个字符")]
        public string? Position { get; set; }

        /// <summary>
        /// 职务
        /// </summary>
        [StringLength(100, ErrorMessage = "职务长度不能超过100个字符")]
        public string? Duty { get; set; }

        /// <summary>
        /// 职务等级
        /// </summary>
        [StringLength(50, ErrorMessage = "职务等级长度不能超过50个字符")]
        public string? DutyLevel { get; set; }

        /// <summary>
        /// 职级评定时间
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime? RankAssessmentDate { get; set; }

        /// <summary>
        /// 最近一次考核结果
        /// </summary>
        [StringLength(50, ErrorMessage = "考核结果长度不能超过50个字符")]
        public string? LastAssessmentResult { get; set; }

        /// <summary>
        /// 最近三年优秀次数
        /// </summary>
        [Range(0, 10, ErrorMessage = "优秀次数必须在0-10之间")]
        public int ExcellentCount { get; set; }

        /// <summary>
        /// 证件照路径
        /// </summary>
        [StringLength(500, ErrorMessage = "证件照路径长度不能超过500个字符")]
        public string? PhotoPath { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [StringLength(50, ErrorMessage = "联系电话长度不能超过50个字符")]
        [RegularExpression(@"^1[3-9]\d{9}$", ErrorMessage = "手机号格式不正确")]
        public string? Phone { get; set; }

        /// <summary>
        /// 家庭住址
        /// </summary>
        [StringLength(200, ErrorMessage = "家庭住址长度不能超过200个字符")]
        public string? HomeAddress { get; set; }

        /// <summary>
        /// 单位地址
        /// </summary>
        [StringLength(200, ErrorMessage = "单位地址长度不能超过200个字符")]
        public string? WorkAddress { get; set; }

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

        // 导航属性
        /// <summary>
        /// 人员奖惩记录
        /// </summary>
        public virtual ICollection<PersonnelRewardPunishment> RewardPunishments { get; set; } = new List<PersonnelRewardPunishment>();

        /// <summary>
        /// 人员履历记录
        /// </summary>
        public virtual ICollection<PersonnelHistory> Histories { get; set; } = new List<PersonnelHistory>();

        /// <summary>
        /// 配偶信息
        /// </summary>
        public virtual PersonnelSpouse? Spouse { get; set; }

        /// <summary>
        /// 家庭成员信息
        /// </summary>
        public virtual ICollection<PersonnelFamilyMember> FamilyMembers { get; set; } = new List<PersonnelFamilyMember>();

        /// <summary>
        /// 工作记录
        /// </summary>
        public virtual ICollection<PersonnelWorkRecord> WorkRecords { get; set; } = new List<PersonnelWorkRecord>();

        /// <summary>
        /// 活动记录
        /// </summary>
        public virtual ICollection<PersonnelActivityRecord> ActivityRecords { get; set; } = new List<PersonnelActivityRecord>();
    }


    /// <summary>
    /// 婚姻状况枚举
    /// </summary>
    public enum MaritalStatus
    {
        /// <summary>
        /// 未婚
        /// </summary>
        Single = 0,
        /// <summary>
        /// 已婚
        /// </summary>
        Married = 1,
        /// <summary>
        /// 离异
        /// </summary>
        Divorced = 2,
        /// <summary>
        /// 丧偶
        /// </summary>
        Widowed = 3
    }
}