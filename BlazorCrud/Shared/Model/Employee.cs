using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlazorCrud.Shared.Model
{
    public class Employee
    {
        [Key]
        [Required]
        public long Uid { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public Decimal Salary { get; set; }

        [Required]
        public long DepartmentUid { get; set; }

        [ForeignKey("DepartmentUid")]
        public Department Department { get; set; }
    }
}
