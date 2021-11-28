using MobilePhoneShop.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MobilePhoneShop.Controllers
{
    public class DangNhapController : Controller
    {

        // GET: DangNhap
        public ActionResult Index()
        {
            if(Session["userName"] != null)
            {
                return RedirectToAction("Index", "TrangChu");
            }

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorise(UserProfile user)
        {
            using (MobilePhoneShopEntities db = new MobilePhoneShopEntities())
            {
                var userDetail = db.UserProfiles.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();
                if (userDetail == null)
                {
                    user.LoginErrorMsg = "Tài khoản hoặc mật khẩu không tồn tại";
                    return View("Index", user);

                }
                else
                {
                    /*                    user.ActiveFlat = true;*/
                    Session["userName"] = user.UserName;
                    return RedirectToAction("Index", "TrangChu");
                }
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "TrangChu");
        }


    }
}