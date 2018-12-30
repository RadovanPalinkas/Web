using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebovaAplikace.Models
{
    public class Employee
    {
        
        public int EmployeeId { get; set; }
        [Required]
        public string  FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public int ZipCode { get; set; }
        [Required]
        public int Authorization { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}