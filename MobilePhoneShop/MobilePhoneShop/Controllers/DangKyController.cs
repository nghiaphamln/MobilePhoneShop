using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobilePhoneShop.Models;

namespace MobilePhoneShop.Controllers
{
    public class DangKyController : Controller
    {
        UserProfile user;
        public bool active = true;

        // GET: Register
        public ActionResult Index()
        {
            if(Session["userName"] != null)
            {
                return RedirectToAction("Index","TrangChu");
            }
          
            return View();

        }
    }
}