using CRUD_APSNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_APSNET.Controllers
{
    public class HomeController : Controller
    {
        db dbop = new db();

        string msg;
        private readonly ILogger<HomeController> _logger;

        public HomeController( ILogger<HomeController> logger )
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Employee em = new Employee();
            em.flag = "get";
            DataSet ds = dbop.Empget(em , out msg);
            List<Employee> list = new List<Employee>();
            foreach ( DataRow dr in ds.Tables[0].Rows )
            {
                list.Add(new Employee
                {
                    ID = Convert.ToInt32(dr["ID"]) ,
                    Name = dr["Name"].ToString() ,
                    City = dr["City"].ToString() ,
                    State = dr["State"].ToString() ,
                    Country = dr["Country"].ToString() ,
                    Department = dr["Department"].ToString()
                });

            }

            return View(list);
        }

        public IActionResult Create( [Bind] Employee em )
        {
            try
            {
                em.flag = "insert";
                dbop.Empdml(em , out msg);
                TempData["msg"] = msg;
            }
            catch ( Exception ex )
            {
                TempData["msg"] = ex.Message;
            }
            return (IActionResult)RedirectToAction("Index");
        }

        public IActionResult Edit( int id )
        {
            Employee em = new Employee();
            em.ID = id;
            em.flag = "getid";
            DataSet ds = dbop.Empget(em , out msg);
            foreach ( DataRow dr in ds.Tables[0].Rows )
            {
                em.ID = Convert.ToInt32(dr["ID"]);
                em.Name = dr["Name"].ToString();
                em.City = dr["City"].ToString();
                em.State = dr["State"].ToString();
                em.Country = dr["Country"].ToString();
                em.Department = dr["Department"].ToString();
            }
            return (IActionResult)View(em);
        }

        [HttpPost]

        public IActionResult Edit( int id , [Bind] Employee em )
        {
            try
            {
                em.ID = id;
                em.flag = "update";
                dbop.Empdml(em , out msg);
                TempData["msg"] = msg;
            }
            catch ( Exception ex )
            {
                TempData["msg"] = ex.Message;

            }
            return (IActionResult)RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete( int id , [Bind] Employee em )
        {
            try
            {
                em.ID = id;
                em.flag = "Update";
                dbop.Empdml(em , out msg);
                TempData["msg"] = msg;

            }
            catch ( Exception ex )
            {
                TempData["msg"] = ex.Message;
            }
            return (IActionResult)RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0 , Location = ResponseCacheLocation.None , NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
