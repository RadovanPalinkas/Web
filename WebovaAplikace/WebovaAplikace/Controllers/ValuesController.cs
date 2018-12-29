using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using WebovaAplikace.Common.Filters;
using WebovaAplikace.Models;
using WebovaAplikace.UnitsOfWork.Interfaces;

namespace WebovaAplikace.Controllers
{
    //[Authorize]
    [EnableCors("*", "*", "*")]
    [UnavailableServiceFilter]
    public class ValuesController : ApiController
    {
        private readonly IUnitOfWork iUnitOfWork;

        public ValuesController(IUnitOfWork iUnitOfWork)
        {
            this.iUnitOfWork = iUnitOfWork;
        }

        //All Customers 
        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await iUnitOfWork.Customers.GetAllAsync();
        }

        //get Customer by ID 
        [HttpGet]
        public async Task<HttpResponseMessage> GetCustomerById([FromUri]int id)
        {
            Customer entity = await iUnitOfWork.Customers.GetAsync(id);
            if (entity == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"zaměstnanec s tímto Id: {id} neexistuje");
            }

            return Request.CreateResponse(HttpStatusCode.OK, entity);
        }

        [HttpGet]
        public async Task< HttpResponseMessage> GetCustomerByFirstNameAndLastName([FromUri]string firstName, [FromUri]string lastName)
        {
            IEnumerable<Customer> entity = await iUnitOfWork.Customers.FindAsync(a => a.FirstName == firstName && a.LastName==lastName);
            return Request.CreateResponse(HttpStatusCode.OK, entity);                        
        }

        //Add Customer
        [HttpPost]
        public async Task<HttpResponseMessage> AddCustomer([FromBody]Customer customer)
        {
            await iUnitOfWork.Customers.AddAsync(customer);
            await iUnitOfWork.CompleteAsync();

            var message = Request.CreateResponse(HttpStatusCode.Created, customer);
            message.Headers.Location = new Uri(Request.RequestUri + customer.CustomerId.ToString()); //přesměrování
            return message;
        }

        //PUT api/values/5
        [HttpPut]
        public async Task<HttpResponseMessage> UpdateCustomer([FromUri]int id, [FromBody]Customer customer)
        {
            Customer entity = await iUnitOfWork.Customers.GetAsync(id);
            if (entity == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"zaměstnanec s tímto Id: {id} neexistuje");
            }
            entity.FirstName = customer.FirstName;
            entity.LastName = customer.LastName;
            entity.City = customer.City;
            entity.Street = customer.Street;
            entity.Number = customer.Number;
            entity.ZipCode = customer.ZipCode;

            await iUnitOfWork.CompleteAsync();
            return Request.CreateResponse(HttpStatusCode.OK, entity);
        }
        
        //DELETE Customer
        [HttpDelete]
        [DisableCors]
        public async Task<HttpResponseMessage> DeleteCustomer([FromUri]int id)
        {
            Customer entity = await iUnitOfWork.Customers.GetAsync(id);
            if (entity == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"zaměstnanec s tímto Id: {id} neexistuje");
            }

            iUnitOfWork.Customers.Remove(entity);
            await iUnitOfWork.CompleteAsync();
            return Request.CreateResponse(HttpStatusCode.OK, entity);
        }
    }
}
