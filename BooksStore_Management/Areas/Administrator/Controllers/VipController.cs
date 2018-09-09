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
    public class VipController : Controller
    {
        Quynh_K8A_BookStoreManagement_DbContext context;
        public VipController()
        {
            context = new Quynh_K8A_BookStoreManagement_DbContext();
        }
        // GET: Administrator/Vip
        public ActionResult Index()
        {
            var listVip = context.Vip.ToList();
            return View(listVip);
        }
        [HttpPost]
        public ActionResult ThemMoi(string tenLoaiVip, int moc, int giamHoaDon)
        {
            try
            {
                var vip = new Vip()
                {
                    TenVip=tenLoaiVip,
                    Moc= moc,
                    UuDai = giamHoaDon
                };
                context.Vip.Add(vip);
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
            ViewBag.Vip = context.Vip.FirstOrDefault(c => c.MaVip == id);
            return View();
        }
        [HttpPost]
        public ActionResult Edit(int maVip, string tenLoaiVip, string moc, int giamHoaDon)
        {
            try
            {
                var vip = context.Vip.FirstOrDefault(c => c.MaVip == maVip);
                vip.TenVip = tenLoaiVip;
                vip.Moc = int.Parse(moc.Substring(0, moc.Length - 5));
                vip.UuDai = giamHoaDon;
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
            var vip = context.Vip.FirstOrDefault(c => c.MaVip == id);
            context.Vip.Remove(vip);
            context.SaveChanges();
            return Redirect("/Administrator/Vip/Index");
        }
    }
}