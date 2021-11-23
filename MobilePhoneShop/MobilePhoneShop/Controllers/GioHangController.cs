using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobilePhoneShop.Controllers
{
    public class GioHangController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }

        // GET: /ShoppingCart/GioHang
        public ActionResult GioHang()
        {
            return View();
        }

        public ActionResult ThanhToan()
        {
            return View();
        }
    }
}