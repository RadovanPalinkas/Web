using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebovaAplikace.Models
{
    [Table("Customers")]
    public class Customer
    {
        public int ID { get; set; }
        [Column("FirstName")]
        public string Name { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }       
    }
}
