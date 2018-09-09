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
            ViewBag.Item = null;
            ViewBag.TacGia = context.TacGia.ToList();
            ViewBag.NhaXuatBan = context.NhaXuatBan.ToList();
            ViewBag.DanhMuc = context.DanhMuc.ToList();
            ViewBag.DoTuoi = context.DoTuoi.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(
            string tenSach,
            string tacGia,

            bool add_TacGia,
            string tenTacGia,
            string gioiTinhTG,
            DateTime? ngaySinhTG,
            string diaChiTG,

            string nhaXuatBan,

            bool add_NhaXuatBan,
            string tenNhaXuatBan,
            string diaChiNXB,
            string soDienThoaiNXB,

            int doTuoi,
            string danhMuc,

            bool add_DanhMuc,
            string tenDanhMuc,
            DateTime? ngayTaoDM,
            string tinhTrangDM,

            string loaiBia,
            string khoGiay,
            DateTime ngayXuatBan,
            string loaiGiay,
            int soTrang,
            string chiTiet,
            int gia,


            double? giamGia,
            DateTime? ngayBatDau,
            DateTime? ngayKetThuc,
            string tenSuKien)
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
                var sach = new Sach();
                var ctSach = new CTSach();
                var anhSach = new AnhSach();
                sach.MaDT = doTuoi;
                if (add_TacGia)
                {
                    var tac_Gia = new TacGia()
                    {
                        TenTG = tenTacGia,
                        GioiTinh = gioiTinhTG,
                        NgaySinh = ngaySinhTG,
                        DiaChi = diaChiTG
                    };
                    context.TacGia.Add(tac_Gia);
                    context.SaveChanges();
                    sach.MaTG = tac_Gia.MaTG;
                }
                else
                {
                    sach.MaTG = int.Parse(tacGia);
                }
                if (add_NhaXuatBan)
                {
                    var nha_Xuat_Ban = new NhaXuatBan()
                    {
                        TenNXB = tenNhaXuatBan,
                        DiaChi = diaChiNXB,
                        Sdt = soDienThoaiNXB
                    };
                    context.NhaXuatBan.Add(nha_Xuat_Ban);
                    context.SaveChanges();
                    sach.MaNXB = nha_Xuat_Ban.MaNXB;
                }
                else
                {
                    sach.MaNXB = int.Parse(nhaXuatBan);
                }
                if (add_DanhMuc)
                {
                    var danh_Muc = new DanhMuc()
                    {
                        TenDM = tenDanhMuc,
                        NgayTao = DateTime.Today,
                        TinhTrang = "Hoạt động"
                    };
                    context.DanhMuc.Add(danh_Muc);
                    context.SaveChanges();
                    sach.MaDM = danh_Muc.MaDM;
                }
                else
                {
                    sach.MaDM = int.Parse(danhMuc);
                }
                context.Sach.Add(sach);
                context.SaveChanges();
                ctSach.MaS = sach.MaS;

                anhSach.MaS = sach.MaS;
                ctSach.TenS = tenSach;
                ctSach.LoaiBia = loaiBia;
                ctSach.NgayXuatBan = ngayXuatBan;
                ctSach.Kho = khoGiay;
                ctSach.SoTrang = soTrang;
                ctSach.Gia = gia;
                ctSach.LoaiGiay = loaiGiay;
                ctSach.ChiTiet = chiTiet;
                context.CTSach.Add(ctSach);
                context.SaveChanges();

                anhSach.Anh1 = "/Content/Images/" + image[0];
                anhSach.Anh2 = "/Content/Images/" + image[1];
                anhSach.Anh3 = "/Content/Images/" + image[2];
                anhSach.Anh4 = "/Content/Images/" + image[3];
                anhSach.Anh5 = "/Content/Images/" + image[4];
                anhSach.Anh6 = "/Content/Images/" + image[5];
                context.AnhSach.Add(anhSach);
                context.SaveChanges();

                //giảm giá
                if (ngayBatDau.ToString() != "")
                {
                    string bD = ngayBatDau.ToString();
                    bD = DateTime.Parse(bD).ToString();
                    string kT = ngayKetThuc.ToString();
                    kT = DateTime.Parse(kT).ToString();
                    string gg = giamGia.ToString();
                    var khuyenMai = new KhuyenMai()
                    {
                        MaS = sach.MaS,
                        KhuyenMai1 = float.Parse(gg),
                        BatDau = DateTime.Parse(bD),
                        KetThuc = DateTime.Parse(kT),
                        TenSuKien = tenSuKien
                    };
                    context.KhuyenMai.Add(khuyenMai);
                    context.SaveChanges();
                }
            }
            return Redirect("/Administrator/SanPham");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Item = context.Sach.FirstOrDefault(c => c.MaS == id);
            ViewBag.TacGia = context.TacGia.ToList();
            ViewBag.NhaXuatBan = context.NhaXuatBan.ToList();
            ViewBag.DanhMuc = context.DanhMuc.ToList();
            ViewBag.DoTuoi = context.DoTuoi.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Edit(
            int idSach,
            string tenSach,
            string tacGia,

            bool add_TacGia,
            string tenTacGia,
            string gioiTinhTG,
            DateTime? ngaySinhTG,
            string diaChiTG,

            string nhaXuatBan,

            bool add_NhaXuatBan,
            string tenNhaXuatBan,
            string diaChiNXB,
            string soDienThoaiNXB,

            int doTuoi,
            string danhMuc,

            bool add_DanhMuc,
            string tenDanhMuc,
            DateTime? ngayTaoDM,
            string tinhTrangDM,

            string loaiBia,
            string khoGiay,
            DateTime ngayXuatBan,
            string loaiGiay,
            int soTrang,
            string chiTiet,
            int gia,

            double? giamGia,
            DateTime? ngayBatDau,
            DateTime? ngayKetThuc,
            string tenSuKien)
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
                var sach = context.Sach.FirstOrDefault(c => c.MaS == idSach);
                var ctSach = context.CTSach.FirstOrDefault(c => c.MaS == idSach);
                var anhSach = context.AnhSach.FirstOrDefault(c => c.MaS == idSach);

                //update Sach
                sach.MaDT = doTuoi;
                if (add_TacGia)
                {
                    var tac_Gia = new TacGia()
                    {
                        TenTG = tenTacGia,
                        GioiTinh = gioiTinhTG,
                        NgaySinh = ngaySinhTG,
                        DiaChi = diaChiTG
                    };
                    context.TacGia.Add(tac_Gia);
                    context.SaveChanges();
                    sach.MaTG = tac_Gia.MaTG;
                }
                else
                {
                    sach.MaTG = int.Parse(tacGia);
                }
                if (add_NhaXuatBan)
                {
                    var nha_Xuat_Ban = new NhaXuatBan()
                    {
                        TenNXB = tenNhaXuatBan,
                        DiaChi = diaChiNXB,
                        Sdt = soDienThoaiNXB
                    };
                    context.NhaXuatBan.Add(nha_Xuat_Ban);
                    context.SaveChanges();
                    sach.MaNXB = nha_Xuat_Ban.MaNXB;
                }
                else
                {
                    sach.MaNXB = int.Parse(nhaXuatBan);
                }
                if (add_DanhMuc)
                {
                    var danh_Muc = new DanhMuc()
                    {
                        TenDM = tenDanhMuc,
                        NgayTao = DateTime.Today,
                        TinhTrang = "Hoạt động"
                    };
                    context.DanhMuc.Add(danh_Muc);
                    context.SaveChanges();
                    sach.MaDM = danh_Muc.MaDM;
                }
                else
                {
                    sach.MaDM = int.Parse(danhMuc);
                }
                context.SaveChanges();

                //Update CTSach
                ctSach.TenS = tenSach;
                ctSach.LoaiBia = loaiBia;
                ctSach.NgayXuatBan = ngayXuatBan;
                ctSach.Kho = khoGiay;
                ctSach.SoTrang = soTrang;
                ctSach.Gia = gia;
                ctSach.LoaiGiay = loaiGiay;
                ctSach.ChiTiet = chiTiet;
                context.SaveChanges();

                //Update AnhSach
                if (image[0] != null)
                    anhSach.Anh1 = "/Content/Images/" + image[0];
                if (image[1] != null)
                    anhSach.Anh2 = "/Content/Images/" + image[1];
                if (image[2] != null)
                    anhSach.Anh3 = "/Content/Images/" + image[2];
                if (image[3] != null)
                    anhSach.Anh4 = "/Content/Images/" + image[3];
                if (image[4] != null)
                    anhSach.Anh5 = "/Content/Images/" + image[4];
                if (image[5] != null)
                    anhSach.Anh6 = "/Content/Images/" + image[5];
                context.SaveChanges();

                //giảm giá
                if (ngayBatDau.ToString() != "")
                {

                    var kM = context.KhuyenMai.FirstOrDefault(c => c.MaS == idSach);
                    if (kM == null)
                    {
                        string bD = ngayBatDau.ToString();
                        bD = DateTime.Parse(bD).ToString();
                        string kT = ngayKetThuc.ToString();
                        kT = DateTime.Parse(kT).ToString();
                        string gg = giamGia.ToString();
                        var khuyenMai = new KhuyenMai()
                        {
                            MaS = sach.MaS,
                            KhuyenMai1 = float.Parse(gg),
                            BatDau = DateTime.Parse(bD),
                            KetThuc = DateTime.Parse(kT),
                            TenSuKien = tenSuKien
                        };
                        context.KhuyenMai.Add(khuyenMai);
                    }
                    else
                    {
                        string bD = ngayBatDau.ToString();
                        bD = DateTime.Parse(bD).ToString();
                        string kT = ngayKetThuc.ToString();
                        string gg = giamGia.ToString();
                        kT = DateTime.Parse(kT).ToString();
                        kM.KhuyenMai1 = float.Parse(gg);
                        kM.BatDau = DateTime.Parse(bD);
                        kM.KetThuc = DateTime.Parse(kT);
                        kM.TenSuKien = tenSuKien;
                    }
                    context.SaveChanges();
                }
                else
                {
                    var kM = context.KhuyenMai.FirstOrDefault(c => c.MaS == idSach);
                    if (kM != null)
                    {
                        context.KhuyenMai.Remove(kM);
                        context.SaveChanges();
                    }
                }

            }
            return Redirect("/Administrator/SanPham");
        }
    }
}