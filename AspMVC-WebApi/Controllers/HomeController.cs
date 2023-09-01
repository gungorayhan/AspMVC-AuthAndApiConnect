using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using AspMVC_WebApi.Models;
using Newtonsoft.Json;
using AspMVC_WebApi.Filter;

namespace AspMVC_WebApi.Controllers
{
    
    public class HomeController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:5000/api");
        HttpClient client;

        public void UserController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles ="Admin")]
        public ActionResult apiconnect() {

            UserController();

            List<blog> blog = new List<blog>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/blog").Result;
            if (response.IsSuccessStatusCode) {
                string data = response.Content.ReadAsStringAsync().Result;
                blog = JsonConvert.DeserializeObject<List<blog>>(data);
            }
           
            
            return View(blog);
        }
        [AuthFilter]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult deneme(blog blog) {
            var i = 0;

            return Json(i, JsonRequestBehavior.AllowGet);
        }
    }
}