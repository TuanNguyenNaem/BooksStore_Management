namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDonNhap")]
    public partial class HoaDonNhap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDonNhap()
        {
            CTHoaDonNhap = new HashSet<CTHoaDonNhap>();
        }

        [Key]
        public int MaHDN { get; set; }

        public int MaNCC { get; set; }

        public int MaNV { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayLap { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayGiaoHang { get; set; }

        [Required]
        [StringLength(20)]
        public string TinhTrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHoaDonNhap> CTHoaDonNhap { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
