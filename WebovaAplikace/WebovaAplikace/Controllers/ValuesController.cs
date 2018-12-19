using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebovaAplikace.Models;
using WebovaAplikace.UnitsOfWork.Interfaces;

namespace WebovaAplikace.Controllers
{
    public class ValuesController : ApiController
    {
        IUnitOfWork iUnitOfWork;

        public ValuesController(IUnitOfWork iUnitOfWork)
        {
            this.iUnitOfWork = iUnitOfWork;
        }

        // GET api/values        
        public IEnumerable<Customer> Get()
        {
            return iUnitOfWork.Customers.GetAll();
        }

        // GET api/values/5
        public Customer Get(int id)
        {
            return iUnitOfWork.Customers.Get(id);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
