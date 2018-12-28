using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;
using WebovaAplikace.Common.Filters;
using WebovaAplikace.Models;
using WebovaAplikace.UnitsOfWork.Interfaces;

namespace WebovaAplikace.Controllers
{
    //[Authorize]

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
        public async Task<IEnumerable<Customer>> Get()
        {
            return await iUnitOfWork.Customers.GetAllAsync();
        }

        //get Customer by ID 
        [HttpGet]
        public async Task<HttpResponseMessage> Get(int id)
        {
            Customer customer = await iUnitOfWork.Customers.GetAsync(id);
            if (customer == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"zaměstnanec s tímto Id: {id} neexistuje");
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        //Add Customer
        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody]Customer customer)
        {
            await iUnitOfWork.Customers.AddAsync(customer);
            await iUnitOfWork.CompleteAsync();

            var message = Request.CreateResponse(HttpStatusCode.Created, customer);
            message.Headers.Location = new System.Uri(Request.RequestUri + customer.CustomerId.ToString());
            return message;
        }

        //PUT api/values/5
        [HttpPut]
        public async Task<HttpResponseMessage> Put(int id, [FromBody]Customer customer)
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
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        //DELETE Customer
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            Customer entity = await iUnitOfWork.Customers.GetAsync(id);
            if (entity == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"zaměstnanec s tímto Id: {id} neexistuje");
            }

            iUnitOfWork.Customers.Remove(entity);
            await iUnitOfWork.CompleteAsync();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
