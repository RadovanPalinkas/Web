using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebovaAplikace.Models;
using WebovaAplikace.UnitsOfWork.Interfaces;

namespace WebovaAplikace.Controllers
{
    public class EmployeeController : ApiController
    {
        public IUnitOfWork iUnitOfWork { get; set; }
        public EmployeeController(IUnitOfWork iUnitOfWork)
        {
            this.iUnitOfWork = iUnitOfWork;
        }
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllEmployee()
        {
            var Employee = await iUnitOfWork.Employees.GetAllAsync();
            return Request.CreateResponse(HttpStatusCode.OK, Employee);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetEmployeeBy(int authorization)
        {
            var Employee = await iUnitOfWork.Employees.GetEmployeeByCompetencyAsync(authorization);

            return Request.CreateResponse(HttpStatusCode.OK, Employee);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> AddEmployee([FromBody]Employee employee)
        {
            await iUnitOfWork.Employees.AddAsync(employee);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

    }
}
