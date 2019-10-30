using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorCrud.Server.DataAccess;
using BlazorCrud.Shared.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IEntityRepository Context;
        public DepartmentController(IEntityRepository context)
        {
            Context = context;
        }

        [HttpGet]
        [Route("getAll")]
        public IQueryable<Department> GetDepartments()
        {
            return Context.Query<Department>();
        }

        [HttpGet]
        [Route("getById")]
        public async Task<Department> GetDepartment(long id)
        {
            var result = await Context.FindAsync<Department>(id);
            return result;
        }

        [HttpPut]
        [Route("updateDepartment")]
        public async Task<Department> UpdateDepartment(Department department)
        {
             Context.Update(department);
             await Context.SaveChangesAsync();
             return department;
        }
    }
}