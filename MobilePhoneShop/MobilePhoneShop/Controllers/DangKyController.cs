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

        [HttpPost]
        public ActionResult CreateAccount(UserProfile user)
        {
            using (MobilePhoneShopEntities db = new MobilePhoneShopEntities())
            {
                var userDetail = db.UserProfiles.Where(x => x.UserName == user.UserName).FirstOrDefault();
                if(userDetail != null)
                {
                    user.LoginErrorMsg = "Tên đăng nhập đã tồn tại";
                    return View("Index", user);
                }
                else
                {
                    if (user.ConfirmPassword != user.Password)
                    {
                        user.LoginErrorMsg = "Sai mật khẩu";
                        return View("Index", user);
                    } else
                    {
                        if (ModelState.IsValid)
                        {
                            db.UserProfiles.Add(user);
                            db.SaveChanges();
                            return RedirectToAction("Index", "DangNhap");
                        }
                    }
                }
                
                
                
              
                return View("Index", user);
            }
            
        }
    }
}