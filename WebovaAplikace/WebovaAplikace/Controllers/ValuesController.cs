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
        
        //Customer by ID 
        [HttpGet]
        public async Task<HttpResponseMessage> Get(int id)
        {
            var entity = await iUnitOfWork.Customers.GetAsync(id);
            if (entity != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"zaměstnanec s tímto Id: {id} neexistuje");
            }
        }

        // Add Customer
        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody]Customer customer)
        {
            iUnitOfWork.Customers.Add(customer);
            await iUnitOfWork.CompleteAsync();

            var message = Request.CreateResponse(HttpStatusCode.Created, customer);
            message.Headers.Location = new System.Uri(Request.RequestUri + customer.CustomerId.ToString());    
            return message;
        }

        // PUT api/values/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE Customer
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            Customer cust = await iUnitOfWork.Customers.GetAsync(id);
            if (cust == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Customer with {id} neexistuje");
            }
            else
            {
                iUnitOfWork.Customers.Remove(cust);
                await iUnitOfWork.CompleteAsync();
                return Request.CreateResponse(HttpStatusCode.OK, $"Customer s {id} byl vymazán");
            }
        }
    }
}
