using EmployeesApi.Domain;
using EmployeesApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Controllers
{
    public class EmployeesController : Controller
    {
        EmployeesDataContext Context;

        public EmployeesController(EmployeesDataContext context)
        {
            Context = context;
        }

        [HttpGet("/employees")]
        public ActionResult GetEmployees()
        {
            var model = new EmployeesGetResponse();

            var response = Context.Employees
                .Where(e => e.IsActive)
                .Select(e => new EmployeesGetResponseItem
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Department = e.Department
                })
                .ToList();
            model.Data = response;
            return Ok(model);
        }
    }
}
