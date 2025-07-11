using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComprehensiveManagementSystem.Models
{
    /// <summary>
    /// 人员培训记录
    /// </summary>
    [Table("PersonnelTrainings")]
    public class PersonnelTraining
    {
        /// <summary>
        /// 培训记录ID - 使用雪花算法
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// 人员ID - 外键
        /// </summary>
        [Required(ErrorMessage = "人员ID不能为空")]
        public Guid PersonnelId { get; set; }

        /// <summary>
        /// 关联的人员基本信息
        /// </summary>
        [ForeignKey("PersonnelId")]
        public virtual PersonnelBasicInfo Personnel { get; set; } = null!;

        /// <summary>
        /// 培训名称
        /// </summary>
        [Required(ErrorMessage = "培训名称不能为空")]
        [StringLength(200, ErrorMessage = "培训名称长度不能超过200个字符")]
        public string TrainingName { get; set; } = string.Empty;

        /// <summary>
        /// 培训类型
        /// </summary>
        [StringLength(100, ErrorMessage = "培训类型长度不能超过100个字符")]
        public string? TrainingType { get; set; }

        /// <summary>
        /// 培训机构/举办单位
        /// </summary>
        [Required(ErrorMessage = "培训机构不能为空")]
        [StringLength(200, ErrorMessage = "培训机构长度不能超过200个字符")]
        public string TrainingOrganization { get; set; } = string.Empty;

        /// <summary>
        /// 培训地点
        /// </summary>
        [Required(ErrorMessage = "培训地点不能为空")]
        [StringLength(200, ErrorMessage = "培训地点长度不能超过200个字符")]
        public string TrainingLocation { get; set; } = string.Empty;

        /// <summary>
        /// 培训开始时间
        /// </summary>
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// 培训结束时间
        /// </summary>
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 培训天数
        /// </summary>
        [Range(1, 365, ErrorMessage = "培训天数必须在1-365天之间")]
        public int TrainingDays { get; set; }

        /// <summary>
        /// 培训内容/课程
        /// </summary>
        [StringLength(1000, ErrorMessage = "培训内容长度不能超过1000个字符")]
        public string? TrainingContent { get; set; }

        /// <summary>
        /// 培训结果/成绩
        /// </summary>
        [StringLength(100, ErrorMessage = "培训结果长度不能超过100个字符")]
        public string? TrainingResult { get; set; }

        /// <summary>
        /// 是否获得证书
        /// </summary>
        public bool HasCertificate { get; set; } = false;

        /// <summary>
        /// 证书名称
        /// </summary>
        [StringLength(200, ErrorMessage = "证书名称长度不能超过200个字符")]
        public string? CertificateName { get; set; }

        /// <summary>
        /// 证书编号
        /// </summary>
        [StringLength(100, ErrorMessage = "证书编号长度不能超过100个字符")]
        public string? CertificateNumber { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(500, ErrorMessage = "备注长度不能超过500个字符")]
        public string? Remarks { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 是否已删除（软删除）
        /// </summary>
        public bool IsDeleted { get; set; } = false;
    }
}