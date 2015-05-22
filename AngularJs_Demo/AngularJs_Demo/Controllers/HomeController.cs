using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;

namespace AngularJs_Demo.Controllers
{
    public class HomeController : Controller
    {
        private IService _iService;
        public HomeController(IService iService)
        {
            this._iService = iService;
        }
        // GET: Home
        public ActionResult Index()
        { 
            return View();
        }

     
    }
}