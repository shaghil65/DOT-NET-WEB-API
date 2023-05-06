using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_Api.Models;

namespace Web_Api.Controllers
{
    public class FirstApiController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Index()
        {
            using (EmployeeDBContext db = new EmployeeDBContext())
            {
                List<Employee> lst = db.Employees.ToList();
                return Ok(lst);
            }
        }
        [HttpGet]
        public IHttpActionResult Index(int id)
        {
            using (EmployeeDBContext db = new EmployeeDBContext())
            {
                var lst = db.Employees.Where(x=>x.EmployeeId == id).First();
                return Ok(lst);
            }
        }
        [HttpPost]
        public IHttpActionResult Create(Employee e)
        {
            using (EmployeeDBContext db = new EmployeeDBContext())
            {
                db.Employees.Add(e);
                db.SaveChanges();
                return Ok();
            }
        }
        [HttpPut]
        public IHttpActionResult Edit(Employee e)
        {
            using (EmployeeDBContext db = new EmployeeDBContext())
            {
                db.Entry(e).State = EntityState.Modified;
                db.SaveChanges();
                return Ok();
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            Employee e = new Employee() { EmployeeId = id };
            using (EmployeeDBContext db = new EmployeeDBContext())
            {
                db.Entry(e).State = EntityState.Deleted;
                db.SaveChanges();
                return Ok();
            }
        }
    }
}
