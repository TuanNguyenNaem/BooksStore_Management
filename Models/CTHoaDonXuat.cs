namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTHoaDonXuat")]
    public partial class CTHoaDonXuat
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaHDX { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaS { get; set; }

        public int SoLuong { get; set; }

        public int GiamGia { get; set; }

        public virtual HoaDonXuat HoaDonXuat { get; set; }

        public virtual Sach Sach { get; set; }
    }
}
