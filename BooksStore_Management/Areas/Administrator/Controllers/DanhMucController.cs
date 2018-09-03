using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Helpers;

namespace BooksStore_Management.Areas.Administrator.Controllers
{
    public class DanhMucController : Controller
    {
        Quynh_K8A_BookStoreManagement_DbContext context;
        public DanhMucController()
        {
            context = new Quynh_K8A_BookStoreManagement_DbContext();
        }
        // GET: Administrator/DanhMuc
        public ActionResult Index()
        {
            var listDanhMuc = context.DanhMuc.ToList();
            return View(listDanhMuc);
        }
        [HttpPost]
        public ActionResult ThemMoi(string tenDanhMuc)
        {
            try
            {
                var danhMuc = new DanhMuc()
                {
                    TenDM = tenDanhMuc,
                    NgayTao = DateTime.Now,
                    TinhTrang = "Hoạt động"
                };
                context.DanhMuc.Add(danhMuc);
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
            ViewBag.DanhMuc = context.DanhMuc.FirstOrDefault(c => c.MaDM == id);
            return View();
        }
        [HttpPost]
        public ActionResult ChinhSua(int maDanhMuc, string tenDanhMuc, DateTime ngayTao, string tinhTrang)
        {
            string tt = "Hoạt động";
            if (tinhTrang == "2")
                tt = "Dừng hoạt động";
            try
            {
                var danhMuc = context.DanhMuc.FirstOrDefault(c => c.MaDM == maDanhMuc);
                danhMuc.TenDM = tenDanhMuc;
                danhMuc.NgayTao = ngayTao;
                danhMuc.TinhTrang = tt;
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
            var danhMuc = context.DanhMuc.FirstOrDefault(c => c.MaDM == id);
            context.DanhMuc.Remove(danhMuc);
            context.SaveChanges();
            return Redirect("/Administrator/DanhMuc/Index");
        }
    }
}