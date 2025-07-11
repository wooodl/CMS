using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComprehensiveManagementSystem.Models
{
    /// <summary>
    /// 人员补充信息表
    /// </summary>
    [Table("PersonnelSupplementaryInfo")]
    public class PersonnelSupplementaryInfo
    {
        /// <summary>
        /// 补充信息ID（主键，使用雪花算法）
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
        /// 入党（团）时间
        /// </summary>
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime? PartyJoinDate { get; set; }

        /// <summary>
        /// 最近级别调整时间（精确到月）
        /// </summary>
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime? LastGradeAdjustmentDate { get; set; }

        /// <summary>
        /// 待遇级别
        /// </summary>
        [StringLength(50, ErrorMessage = "待遇级别长度不能超过50个字符")]
        public string? TreatmentLevel { get; set; }

        /// <summary>
        /// 最近待遇调整时间（精确到月）
        /// </summary>
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime? LastTreatmentAdjustmentDate { get; set; }

        /// <summary>
        /// 加入部门时间（精确到月）
        /// </summary>
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime? DepartmentJoinDate { get; set; }

        /// <summary>
        /// 职级评定时间（精确到月）
        /// </summary>
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
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
        /// 个人照片路径
        /// </summary>
        [StringLength(500, ErrorMessage = "个人照片路径长度不能超过500个字符")]
        public string? PhotoPath { get; set; }

        /// <summary>
        /// 家庭地址
        /// </summary>
        [StringLength(200, ErrorMessage = "家庭地址长度不能超过200个字符")]
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
    }
}