namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhuyenMai")]
    public partial class KhuyenMai
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaS { get; set; }

        [Column("KhuyenMai")]
        public double KhuyenMai1 { get; set; }

        [Column(TypeName = "date")]
        public DateTime BatDau { get; set; }

        [Column(TypeName = "date")]
        public DateTime KetThuc { get; set; }

        [StringLength(300)]
        public string TenSuKien { get; set; }

        public virtual Sach Sach { get; set; }
    }
}
