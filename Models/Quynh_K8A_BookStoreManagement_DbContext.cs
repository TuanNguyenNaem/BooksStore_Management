namespace Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Quynh_K8A_BookStoreManagement_DbContext : DbContext
    {
        public Quynh_K8A_BookStoreManagement_DbContext()
            : base("name=Quynh_K8A_BookStoreManagement_DbContext")
        {
        }

        public virtual DbSet<AnhSach> AnhSach { get; set; }
        public virtual DbSet<CTHoaDonNhap> CTHoaDonNhap { get; set; }
        public virtual DbSet<CTHoaDonXuat> CTHoaDonXuat { get; set; }
        public virtual DbSet<CTSach> CTSach { get; set; }
        public virtual DbSet<DanhGiaSach> DanhGiaSach { get; set; }
        public virtual DbSet<DanhMuc> DanhMuc { get; set; }
        public virtual DbSet<DoTuoi> DoTuoi { get; set; }
        public virtual DbSet<HoaDonNhap> HoaDonNhap { get; set; }
        public virtual DbSet<HoaDonXuat> HoaDonXuat { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<KhuVuc> KhuVuc { get; set; }
        public virtual DbSet<KhuyenMai> KhuyenMai { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCap { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<NhaXuatBan> NhaXuatBan { get; set; }
        public virtual DbSet<Sach> Sach { get; set; }
        public virtual DbSet<TacGia> TacGia { get; set; }
        public virtual DbSet<TKKhachHang> TKKhachHang { get; set; }
        public virtual DbSet<TKNhanVien> TKNhanVien { get; set; }
        public virtual DbSet<Vip> Vip { get; set; }
        public virtual DbSet<Kho> Kho { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CTSach>()
                .Property(e => e.Kho)
                .IsUnicode(false);

            modelBuilder.Entity<CTSach>()
                .Property(e => e.Gia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DanhMuc>()
                .HasMany(e => e.Sach)
                .WithRequired(e => e.DanhMuc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DoTuoi>()
                .HasMany(e => e.Sach)
                .WithRequired(e => e.DoTuoi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDonNhap>()
                .HasMany(e => e.CTHoaDonNhap)
                .WithRequired(e => e.HoaDonNhap)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDonXuat>()
                .HasMany(e => e.CTHoaDonXuat)
                .WithRequired(e => e.HoaDonXuat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Sdt)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KhuVuc>()
                .Property(e => e.PhiShip)
                .HasPrecision(19, 4);

            modelBuilder.Entity<KhuVuc>()
                .HasMany(e => e.HoaDonXuat)
                .WithRequired(e => e.KhuVuc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.Sdt)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .HasMany(e => e.HoaDonNhap)
                .WithRequired(e => e.NhaCungCap)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Sdt)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.HoaDonNhap)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.HoaDonXuat)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhaXuatBan>()
                .Property(e => e.Sdt)
                .IsUnicode(false);

            modelBuilder.Entity<NhaXuatBan>()
                .HasMany(e => e.Sach)
                .WithRequired(e => e.NhaXuatBan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sach>()
                .HasOptional(e => e.AnhSach)
                .WithRequired(e => e.Sach);

            modelBuilder.Entity<Sach>()
                .HasMany(e => e.CTHoaDonNhap)
                .WithRequired(e => e.Sach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sach>()
                .HasMany(e => e.CTHoaDonXuat)
                .WithRequired(e => e.Sach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sach>()
                .HasOptional(e => e.CTSach)
                .WithRequired(e => e.Sach);

            modelBuilder.Entity<Sach>()
                .HasOptional(e => e.DanhGiaSach)
                .WithRequired(e => e.Sach);

            modelBuilder.Entity<Sach>()
                .HasOptional(e => e.KhuyenMai)
                .WithRequired(e => e.Sach);

            modelBuilder.Entity<Sach>()
                .HasMany(e => e.Kho)
                .WithRequired(e => e.Sach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TacGia>()
                .HasMany(e => e.Sach)
                .WithRequired(e => e.TacGia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TKKhachHang>()
                .Property(e => e.TenTK)
                .IsUnicode(false);

            modelBuilder.Entity<TKKhachHang>()
                .HasOptional(e => e.KhachHang)
                .WithRequired(e => e.TKKhachHang);

            modelBuilder.Entity<TKNhanVien>()
                .Property(e => e.TenTK)
                .IsUnicode(false);

            modelBuilder.Entity<TKNhanVien>()
                .HasOptional(e => e.NhanVien)
                .WithRequired(e => e.TKNhanVien);

            modelBuilder.Entity<Vip>()
                .Property(e => e.TenVip)
                .IsUnicode(false);

            modelBuilder.Entity<Vip>()
                .Property(e => e.Moc)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Vip>()
                .HasMany(e => e.KhachHang)
                .WithRequired(e => e.Vip)
                .WillCascadeOnDelete(false);
        }
    }
}
