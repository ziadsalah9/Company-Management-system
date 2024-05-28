﻿using Demo.DAL.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;

namespace Demo.PL.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Is Required")]
        [MaxLength(50, ErrorMessage = "Max Lentgh is 50 Chars")]
        [MinLength(5, ErrorMessage = "Min Lentgh is 5 Chars")]
        public string Name { get; set; }

        [Range(22, 35, ErrorMessage = "Age Must Be Between 22 and 35 ")]
        public int? Age { get; set; }

        [RegularExpression("^[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{5,10}$", ErrorMessage = "Address Must Be Like 123-Street-City-Country")]
        public string Address { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }

        public IFormFile Image { get; set; }

        public string ImageName { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }

        [InverseProperty("Employees")]
        public Department Department { get; set; }
    }
}
