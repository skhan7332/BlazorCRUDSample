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
        [Route("Index")]
        public IQueryable<Department> Index()
        {
            return Context.Query<Department>();
        }   
    }
}