using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SoftUni.Models
{
    public partial class Project
    {
        public Project()
        {
            EmployeesProjects = new HashSet<EmployeeProject>();
        }

        [Key]
        [Column("ProjectID")]
        public int ProjectId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? EndDate { get; set; }

        [InverseProperty("Project")]
        public virtual ICollection<EmployeeProject> EmployeesProjects { get; set; }
    }
}
