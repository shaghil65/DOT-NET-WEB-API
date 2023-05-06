using Microsoft.Xrm.Sdk.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Web_Api.Models;

namespace Web_Api.Controllers
{
    public class HomeController : Controller
    {
        HttpClient client = new HttpClient();

        public ActionResult Check()
        {
            List<Todos> employees = new List<Todos>();
            var response = client.GetAsync("https://jsonplaceholder.typicode.com/todos");
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Todos>>();
                display.Wait();

                employees = display.Result;
            }
            return View(employees);
        }
        [HttpPost]
        public ActionResult Check(string searchterm)
        {
            List<Todos> employees = new List<Todos>();
            var response = client.GetAsync("https://jsonplaceholder.typicode.com/todos?id=" + searchterm.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Todos>>();
                display.Wait();

                employees = display.Result;
            }
            return View(employees);
        }




        //Read
        public ActionResult Index()
        {
            List<Employee> employees = new List<Employee>();
            client.BaseAddress = new Uri("https://localhost:44342/api/firstapi");
            var response = client.GetAsync("firstapi");
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Employee>>();
                display.Wait();

                employees = display.Result;
            }
            return View(employees);
        }


        //Insert
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            List<Employee> employees = new List<Employee>();
            client.BaseAddress = new Uri("https://localhost:44342/api/firstapi");
            var response = client.PostAsXmlAsync("firstapi", emp);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            return View("Create");
        }

        //Details
        public ActionResult Details(int id)
        {
            Employee emp = null;
            client.BaseAddress = new Uri("https://localhost:44342/api/firstapi");
            var response = client.GetAsync("firstapi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();

                emp = display.Result;
            }
            return View(emp);
        }

        //Update
        public ActionResult Edit(int id)
        {
            Employee emp = null;
            client.BaseAddress = new Uri("https://localhost:44342/api/firstapi");
            var response = client.GetAsync("firstapi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();

                emp = display.Result;
            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            List<Employee> employees = new List<Employee>();
            client.BaseAddress = new Uri("https://localhost:44342/api/firstapi");
            var response = client.PutAsJsonAsync("firstapi", emp);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            return View("Create");
        }

        //Delete
        public ActionResult Delete(int id)
        {
            Employee emp = null;
            client.BaseAddress = new Uri("https://localhost:44342/api/firstapi");
            var response = client.GetAsync("firstapi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();

                emp = display.Result;
            }
            return View(emp);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmation(int id)
        {
            client.BaseAddress = new Uri("https://localhost:44342/api/firstapi");
            var response = client.DeleteAsync("firstapi?id=" + id.ToString()) ;
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            return RedirectToAction("index");
        }



    }
}
