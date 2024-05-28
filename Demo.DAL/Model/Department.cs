﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Model
{
    public class Department
    {

        public int Id { get; set; }

        [Required(ErrorMessage ="Name Is Required ..!")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage ="Code Is Required")]
        public int Code { get; set; }
        public DateTime DateOfCreation { get; set; }

        [InverseProperty("Department")]
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

    }
}
