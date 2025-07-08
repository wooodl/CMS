using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComprehensiveManagementSystem.Models
{
    /// <summary>
    /// 人员履历记录表
    /// </summary>
    [Table("PersonnelHistory")]
    public class PersonnelHistory
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
        /// 开始时间
        /// </summary>
        [Required(ErrorMessage = "开始时间不能为空")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 工作地点
        /// </summary>
        [Required(ErrorMessage = "工作地点不能为空")]
        [StringLength(200, ErrorMessage = "工作地点长度不能超过200个字符")]
        public string WorkPlace { get; set; } = string.Empty;

        /// <summary>
        /// 担任角色/职务
        /// </summary>
        [Required(ErrorMessage = "担任角色不能为空")]
        [StringLength(100, ErrorMessage = "担任角色长度不能超过100个字符")]
        public string Role { get; set; } = string.Empty;

        /// <summary>
        /// 工作内容描述
        /// </summary>
        [StringLength(1000, ErrorMessage = "工作内容描述长度不能超过1000个字符")]
        public string? WorkDescription { get; set; }

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