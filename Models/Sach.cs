namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            CTHoaDonNhap = new HashSet<CTHoaDonNhap>();
            CTHoaDonXuat = new HashSet<CTHoaDonXuat>();
            Kho = new HashSet<Kho>();
        }

        [Key]
        public int MaS { get; set; }

        public int MaTG { get; set; }

        public int MaDM { get; set; }

        public int MaDT { get; set; }

        public int MaNXB { get; set; }

        public virtual AnhSach AnhSach { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHoaDonNhap> CTHoaDonNhap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHoaDonXuat> CTHoaDonXuat { get; set; }

        public virtual CTSach CTSach { get; set; }

        public virtual DanhGiaSach DanhGiaSach { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }

        public virtual DoTuoi DoTuoi { get; set; }

        public virtual NhaXuatBan NhaXuatBan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kho> Kho { get; set; }

        public virtual TacGia TacGia { get; set; }
    }
}
