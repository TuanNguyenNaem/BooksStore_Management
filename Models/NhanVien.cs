namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            HoaDonNhap = new HashSet<HoaDonNhap>();
            HoaDonXuat = new HashSet<HoaDonXuat>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaNV { get; set; }

        [Required]
        [StringLength(100)]
        public string TenNV { get; set; }

        [StringLength(5)]
        public string GioiTinh { get; set; }

        [Required]
        [StringLength(100)]
        public string DiaChi { get; set; }

        [StringLength(11)]
        public string Sdt { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgaySinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayDen { get; set; }

        [Required]
        [StringLength(20)]
        public string TinhTrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDonNhap> HoaDonNhap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDonXuat> HoaDonXuat { get; set; }

        public virtual TKNhanVien TKNhanVien { get; set; }
    }
}
