using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComprehensiveManagementSystem.Models
{
    /// <summary>
    /// 人员活动参与记录表
    /// </summary>
    [Table("PersonnelActivityRecord")]
    public class PersonnelActivityRecord
    {
        /// <summary>
        /// 活动记录ID（主键，使用雪花算法）
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
        /// 活动开始时间
        /// </summary>
        [Required(ErrorMessage = "活动开始时间不能为空")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 活动结束时间
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 活动地点
        /// </summary>
        [Required(ErrorMessage = "活动地点不能为空")]
        [StringLength(200, ErrorMessage = "活动地点长度不能超过200个字符")]
        public string ActivityPlace { get; set; } = string.Empty;

        /// <summary>
        /// 活动名称
        /// </summary>
        [Required(ErrorMessage = "活动名称不能为空")]
        [StringLength(200, ErrorMessage = "活动名称长度不能超过200个字符")]
        public string ActivityName { get; set; } = string.Empty;

        /// <summary>
        /// 参与角色
        /// </summary>
        [Required(ErrorMessage = "参与角色不能为空")]
        [StringLength(100, ErrorMessage = "参与角色长度不能超过100个字符")]
        public string ParticipantRole { get; set; } = string.Empty;

        /// <summary>
        /// 活动类型
        /// </summary>
        [StringLength(100, ErrorMessage = "活动类型长度不能超过100个字符")]
        public string? ActivityType { get; set; }

        /// <summary>
        /// 活动组织单位
        /// </summary>
        [StringLength(200, ErrorMessage = "活动组织单位长度不能超过200个字符")]
        public string? OrganizingUnit { get; set; }

        /// <summary>
        /// 活动描述
        /// </summary>
        [StringLength(1000, ErrorMessage = "活动描述长度不能超过1000个字符")]
        public string? ActivityDescription { get; set; }

        /// <summary>
        /// 参与表现
        /// </summary>
        [StringLength(1000, ErrorMessage = "参与表现长度不能超过1000个字符")]
        public string? Performance { get; set; }

        /// <summary>
        /// 获得成果/奖项
        /// </summary>
        [StringLength(500, ErrorMessage = "获得成果长度不能超过500个字符")]
        public string? Achievement { get; set; }

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