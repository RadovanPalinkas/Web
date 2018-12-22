using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebovaAplikace.Common.DataFirst;
using WebovaAplikace.Models;
using WebovaAplikace.UnitsOfWork.Interfaces;

namespace WebovaAplikace.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        private readonly IUnitOfWork iUnitOfWork;

        public ValuesController(IUnitOfWork iUnitOfWork)
        {
            this.iUnitOfWork = iUnitOfWork;
        }

        // GET api/values        
        public IEnumerable<Customer> Get()
        {

            IEnumerable<Customer> getAll = iUnitOfWork.Customers.GetAll();
            iUnitOfWork.Dispose();
            return getAll;

        }


        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            var entity = iUnitOfWork.Customers.Get(id);

            if (entity != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"zaměstnanec s tímto Id: {id} neexistuje");
            }

        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]Customer customer)
        {
            try
            {
                iUnitOfWork.Customers.Add(customer);
                iUnitOfWork.Complete();
                iUnitOfWork.Dispose();
                var message = Request.CreateResponse(HttpStatusCode.Created, customer);
                message.Headers.Location = new System.Uri(Request.RequestUri + customer.CustomerId.ToString());
                return message;

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            Customer cust = iUnitOfWork.Customers.Get(id);
            iUnitOfWork.Customers.Remove(cust);
            iUnitOfWork.Complete();
        }
    }
}
