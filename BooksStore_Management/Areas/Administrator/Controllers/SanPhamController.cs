using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Helpers;
using System.IO;
using System.Drawing;

namespace BooksStore_Management.Areas.Administrator.Controllers
{
    [LoginRequired]
    public class SanPhamController : Controller
    {
        Quynh_K8A_BookStoreManagement_DbContext context;

        public SanPhamController()
        {
            context = new Quynh_K8A_BookStoreManagement_DbContext();

        }
        // GET: Administrator/SanPham
        public ActionResult Index()
        {
            var listSach = context.Sach.ToList();
            return View(listSach);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.TacGia = context.TacGia.ToList();
            ViewBag.NhaXuatBan = context.NhaXuatBan.ToList();
            ViewBag.DanhMuc = context.DanhMuc.ToList();
            ViewBag.DoTuoi = context.DoTuoi.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(
            string tenSach,
            int tacGia,
            int nhaXuatBan,
            int doTuoi,
            int danhMuc,
            string loaiBia,
            string khoGiay,
            DateTime ngayXuatBan,
            string loaiGiay,
            string soTrang,
            string gia)
        {
            if (Request.Files.Count > 0)
            {
                var image = new string[Request.Files.Count];

                for (int i = 0; i < Request.Files.Count; i++)
                {

                    var file = Request.Files[i];
                    if (file != null && file.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/Images/"), filename);
                        file.SaveAs(path);
                        image[i] = filename;
                    }
                }
            }
            return Redirect("/Administrator/SanPham");
        }
    }
}