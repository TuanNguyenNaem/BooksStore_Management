using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Helpers;

namespace BooksStore_Management.Areas.Administrator.Controllers
{
    [LoginRequired]
    public class KhuyenMaiController : Controller
    {
        Quynh_K8A_BookStoreManagement_DbContext context;
        public KhuyenMaiController()
        {
            context = new Quynh_K8A_BookStoreManagement_DbContext();
        }
        // GET: Administrator/KhuyenMai
        public ActionResult Index()
        {
            var listSach = context.Sach.ToList();
            return View(listSach);
        }
    }
}