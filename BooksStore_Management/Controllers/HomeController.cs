using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Helpers;

namespace BooksStore_Management.Controllers
{
    public class HomeController : Controller
    {
        Quynh_K8A_BookStoreManagement_DbContext context;
        public HomeController()
        {
            context = new Quynh_K8A_BookStoreManagement_DbContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(string tenDN, string matKhau, string url)
        {
            var users = context.TKKhachHang.ToList().FirstOrDefault(c => c.TenTK == tenDN && c.MatKhau.ToUpper() == EncryptedMD5.GenerateHash(matKhau).ToUpper());
            if (users != null)
            {
                SessionHelper.SetSession(new UserSession() { UserName = users.TenTK });
                return Json(new { Status = true, Message = "Đăng nhập thành công!" }, JsonRequestBehavior.AllowGet);

            }
            return Json(new { Status = false, Message = "Tên đăng nhập hoặc mật khẩu sai!" }, JsonRequestBehavior.AllowGet);
        }
    }
}