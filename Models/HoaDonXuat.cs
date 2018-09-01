namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDonXuat")]
    public partial class HoaDonXuat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDonXuat()
        {
            CTHoaDonXuat = new HashSet<CTHoaDonXuat>();
        }

        [Key]
        public int MaHDX { get; set; }

        public int? MaKH { get; set; }

        public int MaNV { get; set; }

        public int MaKV { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayLap { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayGiaoHang { get; set; }

        [Required]
        [StringLength(20)]
        public string TinhTrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHoaDonXuat> CTHoaDonXuat { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual KhuVuc KhuVuc { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
