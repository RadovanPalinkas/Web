using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebovaAplikace.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }        
        public string Description { get; set; }
        public int Price { get; set; }
    }
}
