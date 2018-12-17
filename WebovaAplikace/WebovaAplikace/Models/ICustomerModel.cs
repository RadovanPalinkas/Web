using System.Collections.Generic;


namespace WebovaAplikace.Models
{
    public interface ICustomerModel
    {
        List<Customer> GetCustomers();
    }
}