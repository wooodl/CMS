using System.ComponentModel.DataAnnotations;

namespace ComprehensiveManagementSystem.Models
{
    public enum OrganizationType
    {
        [Display(Name = "单位")]
        Unit = 1,
        
        [Display(Name = "部门")]
        Department = 2,
        
        [Display(Name = "小组")]
        Group = 3
    }
}