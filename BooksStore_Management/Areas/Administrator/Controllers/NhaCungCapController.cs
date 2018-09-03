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
    public class NhaCungCapController : Controller
    {
        Quynh_K8A_BookStoreManagement_DbContext context;
        public NhaCungCapController()
        {
            context = new Quynh_K8A_BookStoreManagement_DbContext();
        }
        // GET: Administrator/NhaCungCap
        public ActionResult Index()
        {
            var listNhaCungCap = context.NhaCungCap.ToList();
            return View(listNhaCungCap);
        }
        [HttpPost]
        public ActionResult ThemMoi(string tenNhaCungCap, string soDienThoai, string diaChi)
        {
            try
            {
                var nhaCungCap = new NhaCungCap()
                {
                    TenNCC = tenNhaCungCap,
                    Sdt = soDienThoai,
                    DiaChi = diaChi
                };
                context.NhaCungCap.Add(nhaCungCap);
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
            ViewBag.NhaCungCap = context.NhaCungCap.FirstOrDefault(c => c.MaNCC == id);
            return View();
        }
        [HttpPost]
        public ActionResult ChinhSua(int maNhaCungCap, string tenNhaCungCap, string soDienThoai, string diaChi)
        {
            try
            {
                var nhaCungCap = context.NhaCungCap.FirstOrDefault(c => c.MaNCC == maNhaCungCap);
                nhaCungCap.TenNCC = tenNhaCungCap;
                nhaCungCap.Sdt = soDienThoai;
                nhaCungCap.DiaChi = diaChi;
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
            var nhaCungCap = context.NhaCungCap.FirstOrDefault(c => c.MaNCC == id);
            context.NhaCungCap.Remove(nhaCungCap);
            context.SaveChanges();
            return Redirect("/Administrator/NhaCungCap/Index");
        }
    }
}