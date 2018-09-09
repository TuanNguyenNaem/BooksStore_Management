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
            ViewBag.KhuyenMai = context.KhuyenMai.ToList();
            var listSach = context.Sach.ToList();
            return View(listSach);
        }
        public ActionResult DangKhuyenMai()
        {
            ViewBag.KhuyenMai = context.KhuyenMai.Where(c=>c.BatDau <= DateTime.Now && DateTime.Now <= c.KetThuc).ToList();
            return View();
        }
        [HttpGet]
        public ActionResult ThemMoi(int id)
        {
            ViewBag.Item = id;
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(
            int maSach,
            double giamGia,
            DateTime ngayBatDau,
            DateTime ngayKetThuc,
            string tenSuKien)
        {
            var kM = context.KhuyenMai.FirstOrDefault(c => c.MaS == maSach);
            if (kM != null)
            {
                context.KhuyenMai.Remove(kM);
                context.SaveChanges();
            }
            var khuyenMai = new KhuyenMai()
            {
                MaS = maSach,
                KhuyenMai1 = giamGia,
                BatDau = ngayBatDau,
                KetThuc = ngayKetThuc,
                TenSuKien = tenSuKien
            };
            context.KhuyenMai.Add(khuyenMai);
            context.SaveChanges();
            return Redirect("/Administrator/KhuyenMai/Index");
        }
    }
}