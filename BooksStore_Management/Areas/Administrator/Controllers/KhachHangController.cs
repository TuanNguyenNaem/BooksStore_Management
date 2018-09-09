using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Helpers;

namespace BooksStore_Management.Areas.Administrator.Controllers
{
    public class KhachHangController : Controller
    {
        Quynh_K8A_BookStoreManagement_DbContext context;
        public KhachHangController()
        {
            context = new Quynh_K8A_BookStoreManagement_DbContext();
        }
        // GET: Administrator/KhachHang
        public ActionResult Index()
        {
            ViewBag.VIP = context.Vip.ToList();
            var listKhachHang = context.KhachHang.ToList();
            return View(listKhachHang);
        }
        [HttpPost]
        public ActionResult Create(
            string tenDangNhap,
            string matKhau,
            string tenKhachHang,
            string gioiTinh,
            DateTime? ngaySinh,
            string soDienThoai,
            string email,
            string diaChi,
            int loaiVip,
            string tinhTrang)
        {
            try
            {
                var khachHang = new KhachHang()
                {
                    TenKh = tenKhachHang,
                    GioiTinh = gioiTinh,
                    NgaySinh = ngaySinh,
                    Sdt = soDienThoai,
                    Email = email,
                    DiaChi = diaChi,
                    MaVip = loaiVip,
                    TinhTrang = tinhTrang
                };
                var tkKhachHang = new TKKhachHang()
                {
                    TenTK = tenDangNhap,
                    MatKhau = matKhau
                };
                context.TKKhachHang.Add(tkKhachHang);
                context.SaveChanges();
                khachHang.MaKH = tkKhachHang.MaKH;
                context.KhachHang.Add(khachHang);
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
            ViewBag.VIP = context.Vip.ToList();
            ViewBag.KhachHang = context.KhachHang.FirstOrDefault(c => c.MaKH == id);
            return View();
        }
        [HttpPost]
        public ActionResult ChinhSua(
            int idKhachHang,
            string tenKhachHang,
            string gioiTinh,
            DateTime? ngaySinh,
            string soDienThoai,
            string email,
            string diaChi,
            int loaiVip,
            string tinhTrang)
        {
            try
            {
                var khachHang = context.KhachHang.FirstOrDefault(c => c.MaKH == idKhachHang);
                khachHang.TenKh = tenKhachHang;
                khachHang.GioiTinh = gioiTinh;
                khachHang.NgaySinh = ngaySinh;
                khachHang.Sdt = soDienThoai;
                khachHang.DiaChi = diaChi;
                khachHang.Email = email;
                khachHang.MaVip = loaiVip;
                khachHang.TinhTrang = tinhTrang;
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
            var khachHang = context.KhachHang.FirstOrDefault(c => c.MaKH == id);
            context.KhachHang.Remove(khachHang);
            context.SaveChanges();
            return Redirect("/Administrator/KhachHang/Index");
        }
    }
}