using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComprehensiveManagementSystem.Models
{
    /// <summary>
    /// 人员奖惩记录表
    /// </summary>
    [Table("PersonnelRewardPunishment")]
    public class PersonnelRewardPunishment
    {
        /// <summary>
        /// 记录ID（主键，使用雪花算法）
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
        /// 奖惩时间
        /// </summary>
        [Required(ErrorMessage = "奖惩时间不能为空")]
        [DataType(DataType.Date)]
        public DateTime RecordDate { get; set; }

        /// <summary>
        /// 奖惩类型（0-奖励，1-处罚）
        /// </summary>
        [Required(ErrorMessage = "奖惩类型不能为空")]
        public RewardPunishmentType Type { get; set; }

        /// <summary>
        /// 奖惩级别
        /// </summary>
        [Required(ErrorMessage = "奖惩级别不能为空")]
        [StringLength(50, ErrorMessage = "奖惩级别长度不能超过50个字符")]
        public string Level { get; set; } = string.Empty;

        /// <summary>
        /// 奖惩原因
        /// </summary>
        [Required(ErrorMessage = "奖惩原因不能为空")]
        [StringLength(500, ErrorMessage = "奖惩原因长度不能超过500个字符")]
        public string Reason { get; set; } = string.Empty;

        /// <summary>
        /// 奖惩决定单位
        /// </summary>
        [Required(ErrorMessage = "奖惩决定单位不能为空")]
        [StringLength(200, ErrorMessage = "奖惩决定单位长度不能超过200个字符")]
        public string DecisionUnit { get; set; } = string.Empty;

        /// <summary>
        /// 奖惩决定文号
        /// </summary>
        [StringLength(100, ErrorMessage = "奖惩决定文号长度不能超过100个字符")]
        public string? DecisionDocument { get; set; }

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
    /// 奖惩类型枚举
    /// </summary>
    public enum RewardPunishmentType
    {
        /// <summary>
        /// 奖励
        /// </summary>
        Reward = 0,
        /// <summary>
        /// 处罚
        /// </summary>
        Punishment = 1
    }
}