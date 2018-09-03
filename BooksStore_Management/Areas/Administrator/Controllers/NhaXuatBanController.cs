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
    public class NhaXuatBanController : Controller
    {
        Quynh_K8A_BookStoreManagement_DbContext context;
        public NhaXuatBanController()
        {
            context = new Quynh_K8A_BookStoreManagement_DbContext();
        }
        // GET: Administrator/NhaXuatBan
        public ActionResult Index()
        {
            var listNhaXuatBan = context.NhaXuatBan.ToList();
            return View(listNhaXuatBan);
        }

        [HttpPost]
        public ActionResult ThemMoi(string tenNhaXuatBan, string soDienThoai, string diaChi)
        {
            try
            {
                var nhaXuatBan = new NhaXuatBan()
                {
                    TenNXB = tenNhaXuatBan,
                    Sdt = soDienThoai,
                    DiaChi = diaChi
                };
                context.NhaXuatBan.Add(nhaXuatBan);
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
            ViewBag.NhaXuatBan = context.NhaXuatBan.FirstOrDefault(c => c.MaNXB == id);
            return View();
        }
        [HttpPost]
        public ActionResult ChinhSua(int maNhaXuatBan, string tenNhaXuatBan, string soDienThoai, string diaChi)
        {
            try
            {
                var nhaXuatBan = context.NhaXuatBan.FirstOrDefault(c => c.MaNXB == maNhaXuatBan);
                nhaXuatBan.TenNXB = tenNhaXuatBan;
                nhaXuatBan.Sdt = soDienThoai;
                nhaXuatBan.DiaChi = diaChi;
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
            var nhaXuatBan = context.NhaXuatBan.FirstOrDefault(c => c.MaNXB == id);
            context.NhaXuatBan.Remove(nhaXuatBan);
            context.SaveChanges();
            return Redirect("/Administrator/NhaXuatBan/Index");
        }
    }
}