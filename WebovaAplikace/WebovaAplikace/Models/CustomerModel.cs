using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebovaAplikace.Repository.IRepositories;

namespace WebovaAplikace.Models
{
    public class CustomerModel : ICustomerModel
    {
        private ICustomerRepository iCustomerRepository;


        public CustomerModel(ICustomerRepository iCustomerRepository)
        {
            this.iCustomerRepository = iCustomerRepository;
        }
        //získá data z repositáře
        public List<Customer> GetCustomers()
        {
            return iCustomerRepository.GetCustomers();
        }

    }
}