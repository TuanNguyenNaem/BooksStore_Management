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
    public class TacGiaController : Controller
    {
        private Quynh_K8A_BookStoreManagement_DbContext context;
        public TacGiaController()
        {
            context = new Quynh_K8A_BookStoreManagement_DbContext();
        }
        // GET: Administrator/TacGia
        public ActionResult Index()
        {
            var listTacGia = context.TacGia.ToList();
            return View(listTacGia);
        }
        [HttpPost]
        public ActionResult ThemMoi(string tenTacGia, string gioiTinh, DateTime ngaySinh, string diaChi)
        {
            string gt = "";
            if (gioiTinh == "1")
                gt = "Nam";
            else if (gioiTinh == "2")
                gt = "Nữ";
            else if (gioiTinh == "3")
                gt = "Khác";
            try
            {
                var tacGia = new TacGia()
                {
                    TenTG = tenTacGia,
                    GioiTinh = gt,
                    NgaySinh = ngaySinh,
                    DiaChi = diaChi
                };
                context.TacGia.Add(tacGia);
                var result = context.SaveChanges();
                if (result > 0)
                    return Json(new { Status = true, Message = "Thêm thành công!" }, JsonRequestBehavior.AllowGet);
                else
                    return Json(new { Status = false, Message = "Thất bại!" }, JsonRequestBehavior.AllowGet);

            }
            catch
            {
                return Json(new { Status = false, Message = "Trùng tên!" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult ChinhSua(int id)
        {
            ViewBag.TacGia = context.TacGia.FirstOrDefault(c => c.MaTG == id);
            return View();
        }
        [HttpPost]
        public ActionResult ChinhSua(int maTacGia, string tenTacGia, string gioiTinh, DateTime ngaySinh, string diaChi)
        {
            string gt = "";
            if (gioiTinh == "1")
                gt = "Nam";
            else if (gioiTinh == "2")
                gt = "Nữ";
            else if (gioiTinh == "3")
                gt = "Khác";
            try
            {
                var tacGia = context.TacGia.FirstOrDefault(c => c.MaTG == maTacGia);
                tacGia.TenTG = tenTacGia;
                tacGia.GioiTinh = gt;
                tacGia.NgaySinh = ngaySinh;
                tacGia.DiaChi = diaChi;
                var result = context.SaveChanges();
                return Json(new { Status = true, Message = "Sửa thành công!" }, JsonRequestBehavior.AllowGet);

            }
            catch
            {
                return Json(new { Status = false, Message = "Trùng tên!" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult Xoa(int id)
        {
            var tacGia = context.TacGia.FirstOrDefault(c => c.MaTG == id);
            context.TacGia.Remove(tacGia);
            context.SaveChanges();
            return Redirect("/Administrator/TacGia/Index");
        }
    }
}