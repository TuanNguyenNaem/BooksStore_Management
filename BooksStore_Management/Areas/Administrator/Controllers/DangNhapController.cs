using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Helpers;

namespace BooksStore_Management.Areas.Administrator.Controllers
{
    public class DangNhapController : Controller
    {
        Quynh_K8A_BookStoreManagement_DbContext context;
        public DangNhapController()
        {
            context = new Quynh_K8A_BookStoreManagement_DbContext();
        }
        // GET: Administrator/DangNhap
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string tenDangNhap, string matKhau)
        {
            var users = context.TKKhachHang.ToList().FirstOrDefault(c => c.TenTK == tenDangNhap && c.MatKhau.ToUpper() == EncryptedMD5.GenerateHash(matKhau).ToUpper());
            if (users != null)
            {
                SessionHelper.SetSession(new UserSession() { UserName = users.TenTK });
                return Redirect("/Administrator/AdminHome");
            }
            else
            {
                return Redirect("/Administrator/DangNhap");
            }
        }
    }
}