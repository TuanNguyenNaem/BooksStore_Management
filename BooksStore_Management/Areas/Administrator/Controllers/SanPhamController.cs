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
    public class SanPhamController : Controller
    {
        // GET: Administrator/SanPham
        public ActionResult Index()
        {
            return View();
        }
    }
}