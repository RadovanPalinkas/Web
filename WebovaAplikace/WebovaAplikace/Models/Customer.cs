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
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }       
        public string Street { get; set; }
        public int Number { get; set; }        
        public int ZipCode { get; set; }    
        
    
    }
}
