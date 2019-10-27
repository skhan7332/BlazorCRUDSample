using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorCrud.Server.DataAccess;
using BlazorCrud.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEntityRepository Context;
        public EmployeeController(IEntityRepository context)
        {
            Context = context;
        }

        [HttpGet]
        [Route("getAll")]
        public IQueryable<Employee> GetEmployees()
        {
            return Context.Query<Employee>();
        }

        [HttpGet]
        [Route("getAllByDepartment")]
        public async Task<IList<Employee>> GetEmployeesByDepartment(long depId)
        {
            return (await Context.QueryAsync<Employee>(e => e.DepartmentUid == depId));
        }

    }
}