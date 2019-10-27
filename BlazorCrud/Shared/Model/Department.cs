using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorCrud.Shared.Model
{
    public class Department
    {
        public Department()
        {
            Employees = new List<Employee>();
        }

        public ICollection<Employee> Employees { get; set; }

        [Key]
        [Required]
        public long Uid { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
