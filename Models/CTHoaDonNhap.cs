namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTHoaDonNhap")]
    public partial class CTHoaDonNhap
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaHDN { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaS { get; set; }

        public int SoLuong { get; set; }

        public int GiamGia { get; set; }

        public virtual HoaDonNhap HoaDonNhap { get; set; }

        public virtual Sach Sach { get; set; }
    }
}
