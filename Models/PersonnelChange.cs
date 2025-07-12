using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComprehensiveManagementSystem.Models
{
    /// <summary>
    /// 人员变动记录表
    /// </summary>
    [Table("PersonnelChange")]
    public class PersonnelChange
    {
        /// <summary>
        /// 变动记录ID（主键）
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 人员ID
        /// </summary>
        [Required(ErrorMessage = "人员ID不能为空")]
        public Guid PersonnelId { get; set; }

        /// <summary>
        /// 人员导航属性
        /// </summary>
        [ForeignKey("PersonnelId")]
        public virtual PersonnelBasicInfo? Personnel { get; set; }

        /// <summary>
        /// 变动类型
        /// </summary>
        [Required(ErrorMessage = "变动类型不能为空")]
        public PersonnelChangeType ChangeType { get; set; }

        /// <summary>
        /// 变动日期
        /// </summary>
        [Required(ErrorMessage = "变动日期不能为空")]
        [DataType(DataType.Date)]
        public DateTime ChangeDate { get; set; }

        /// <summary>
        /// 变动原因
        /// </summary>
        [StringLength(500, ErrorMessage = "变动原因长度不能超过500个字符")]
        public string? ChangeReason { get; set; }

        /// <summary>
        /// 变动前机构ID
        /// </summary>
        public int? PreviousOrganizationId { get; set; }

        /// <summary>
        /// 变动前机构导航属性
        /// </summary>
        [ForeignKey("PreviousOrganizationId")]
        public virtual Organization? PreviousOrganization { get; set; }

        /// <summary>
        /// 变动后机构ID
        /// </summary>
        public int? NewOrganizationId { get; set; }

        /// <summary>
        /// 变动后机构导航属性
        /// </summary>
        [ForeignKey("NewOrganizationId")]
        public virtual Organization? NewOrganization { get; set; }

        /// <summary>
        /// 变动前职务
        /// </summary>
        [StringLength(100, ErrorMessage = "变动前职务长度不能超过100个字符")]
        public string? PreviousPosition { get; set; }

        /// <summary>
        /// 变动后职务
        /// </summary>
        [StringLength(100, ErrorMessage = "变动后职务长度不能超过100个字符")]
        public string? NewPosition { get; set; }

        /// <summary>
        /// 变动前级别
        /// </summary>
        [StringLength(50, ErrorMessage = "变动前级别长度不能超过50个字符")]
        public string? PreviousGrade { get; set; }

        /// <summary>
        /// 变动后级别
        /// </summary>
        [StringLength(50, ErrorMessage = "变动后级别长度不能超过50个字符")]
        public string? NewGrade { get; set; }

        /// <summary>
        /// 变动前政治面貌
        /// </summary>
        [StringLength(50, ErrorMessage = "变动前政治面貌长度不能超过50个字符")]
        public string? PreviousPoliticalStatus { get; set; }

        /// <summary>
        /// 变动后政治面貌
        /// </summary>
        [StringLength(50, ErrorMessage = "变动后政治面貌长度不能超过50个字符")]
        public string? NewPoliticalStatus { get; set; }

        /// <summary>
        /// 生效日期
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime? EffectiveDate { get; set; }

        /// <summary>
        /// 办理人
        /// </summary>
        [StringLength(50, ErrorMessage = "办理人长度不能超过50个字符")]
        public string? ProcessedBy { get; set; }

        /// <summary>
        /// 审批人
        /// </summary>
        [StringLength(50, ErrorMessage = "审批人长度不能超过50个字符")]
        public string? ApprovedBy { get; set; }

        /// <summary>
        /// 变动状态
        /// </summary>
        [Required]
        public PersonnelChangeStatus Status { get; set; } = PersonnelChangeStatus.Pending;

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(1000, ErrorMessage = "备注长度不能超过1000个字符")]
        public string? Remarks { get; set; }

        /// <summary>
        /// 相关文件路径
        /// </summary>
        [StringLength(500, ErrorMessage = "文件路径长度不能超过500个字符")]
        public string? AttachmentPath { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 创建人
        /// </summary>
        [StringLength(50, ErrorMessage = "创建人长度不能超过50个字符")]
        public string? CreatedBy { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; } = false;
    }

    /// <summary>
    /// 人员变动类型枚举
    /// </summary>
    public enum PersonnelChangeType
    {
        /// <summary>
        /// 入职
        /// </summary>
        Onboard = 1,

        /// <summary>
        /// 离职
        /// </summary>
        Resign = 2,

        /// <summary>
        /// 调入
        /// </summary>
        TransferIn = 3,

        /// <summary>
        /// 调出
        /// </summary>
        TransferOut = 4,

        /// <summary>
        /// 晋升
        /// </summary>
        Promotion = 5,

        /// <summary>
        /// 党员发展
        /// </summary>
        PartyDevelopment = 6,

        /// <summary>
        /// 职务变动
        /// </summary>
        PositionChange = 7,

        /// <summary>
        /// 机构变动
        /// </summary>
        OrganizationTransfer = 8
    }

    /// <summary>
    /// 人员变动状态枚举
    /// </summary>
    public enum PersonnelChangeStatus
    {
        /// <summary>
        /// 待审批
        /// </summary>
        Pending = 1,

        /// <summary>
        /// 已批准
        /// </summary>
        Approved = 2,

        /// <summary>
        /// 已拒绝
        /// </summary>
        Rejected = 3,

        /// <summary>
        /// 已生效
        /// </summary>
        Effective = 4,

        /// <summary>
        /// 已撤销
        /// </summary>
        Cancelled = 5
    }
}