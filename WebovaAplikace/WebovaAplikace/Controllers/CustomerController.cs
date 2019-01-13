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
    [BasicAuthentication]
    [EnableCors("*", "*", "*")]
    public class CustomerController : ApiController
    {
        private readonly IUnitOfWork iUnitOfWork;
       

        public CustomerController(IUnitOfWork iUnitOfWork)
        {           
            this.iUnitOfWork = iUnitOfWork;
        }

        
        [HttpGet]
        [Route("api/Customer/")]
        public HttpResponseMessage Intro()
        {
            List<string> intro = new List<string>() { "Zadejte dotaz:", "getAll=all", "getById=NUMBER" };
            return Request.CreateResponse(HttpStatusCode.OK, intro);
        }

        [HttpGet]
        [Route("api/Customer/GetAll")]
        public async Task<HttpResponseMessage> GetAllCustomers()
        {
           
                var customer = await iUnitOfWork.Customers.GetAllAsync();
                return Request.CreateResponse(HttpStatusCode.OK, customer);           
        }
        //get Customer by ID 
        [HttpGet]
        [Route("api/Customer/{Id}")]
        public async Task<HttpResponseMessage> GetCustomerById([FromUri]int Id)
        {
            Customer entity = await iUnitOfWork.Customers.GetAsync(Id);
            if (entity == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"zaměstnanec s tímto Id: {Id} neexistuje");
            }

            return Request.CreateResponse(HttpStatusCode.OK, entity);
        }

        [HttpGet]
        [Route("api/Customer/FullName/{firstName}_{lastName}")]
        public async Task< HttpResponseMessage> GetCustomerByFirstNameAndLastName([FromUri]string firstName, [FromUri]string lastName)
        {
            IEnumerable<Customer> entity = await iUnitOfWork.Customers.FindAsync(a => a.FirstName == firstName && a.LastName==lastName);
            return Request.CreateResponse(HttpStatusCode.OK, entity);                        
        }

        //Add Customer
        [HttpPost]
        [Route("api/Customer/Add/")]
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
        [Route("api/Customer/Update/{id}")]
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
        //[DisableCors]
        [Route("api/Customer/Delete/{Id}")]
        public async Task<HttpResponseMessage> DeleteCustomer([FromUri]int Id)
        {
            Customer entity = await iUnitOfWork.Customers.GetAsync(Id);
            if (entity == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"zaměstnanec s tímto Id: {Id} neexistuje");
            }

            iUnitOfWork.Customers.Remove(entity);
            await iUnitOfWork.CompleteAsync();
            return Request.CreateResponse(HttpStatusCode.OK, entity);
        }
    }
}
