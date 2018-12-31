using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using WebovaAplikace.Models;
using WebovaAplikace.UnitsOfWork.Interfaces;

namespace WebovaAplikace.Controllers
{
    [EnableCors("*", "*", "*")]
    public class EmployeeController : ApiController
    {
        public IUnitOfWork iUnitOfWork { get; set; }
        public EmployeeController(IUnitOfWork iUnitOfWork)
        {
            this.iUnitOfWork = iUnitOfWork;
        }
        [HttpGet]
        public HttpResponseMessage Intro()
        {
            List<string> intro = new List<string>() { "Zadejte dotaz:", "getAll=all", "getById=NUMBER", "getByAuthorization=NUMBER"};
            return Request.CreateResponse(HttpStatusCode.OK, intro);
        }
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllEmployees([FromUri]string getAll)
        {
            if (getAll == "all")
            {
                var employee = await iUnitOfWork.Employees.GetAllAsync();
                return Request.CreateResponse(HttpStatusCode.OK, employee);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Zadali jste špatný příkaz");
            }           
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetEmployeeById([FromUri]int getById)
        {
            var employee = await iUnitOfWork.Employees.GetAsync(getById);
            return Request.CreateResponse(HttpStatusCode.OK, employee);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetEmployeeByAuthorization([FromUri]int getByAuthorization)
        {
            var Employee = await iUnitOfWork.Employees.GetEmployeeByAuthorizationAsync(getByAuthorization);

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
