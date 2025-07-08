using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComprehensiveManagementSystem.Models
{
    /// <summary>
    /// 人员工作记录表
    /// </summary>
    [Table("PersonnelWorkRecord")]
    public class PersonnelWorkRecord
    {
        /// <summary>
        /// 工作记录ID（主键，使用雪花算法）
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
        /// 工作时间
        /// </summary>
        [Required(ErrorMessage = "工作时间不能为空")]
        [DataType(DataType.Date)]
        public DateTime WorkDate { get; set; }

        /// <summary>
        /// 工作地点
        /// </summary>
        [Required(ErrorMessage = "工作地点不能为空")]
        [StringLength(200, ErrorMessage = "工作地点长度不能超过200个字符")]
        public string WorkPlace { get; set; } = string.Empty;

        /// <summary>
        /// 工作内容
        /// </summary>
        [Required(ErrorMessage = "工作内容不能为空")]
        [StringLength(1000, ErrorMessage = "工作内容长度不能超过1000个字符")]
        public string WorkContent { get; set; } = string.Empty;

        /// <summary>
        /// 工作性质/类型
        /// </summary>
        [StringLength(100, ErrorMessage = "工作性质长度不能超过100个字符")]
        public string? WorkType { get; set; }

        /// <summary>
        /// 参与人员
        /// </summary>
        [StringLength(500, ErrorMessage = "参与人员长度不能超过500个字符")]
        public string? Participants { get; set; }

        /// <summary>
        /// 工作成果
        /// </summary>
        [StringLength(1000, ErrorMessage = "工作成果长度不能超过1000个字符")]
        public string? WorkResult { get; set; }

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