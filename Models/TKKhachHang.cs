namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TKKhachHang")]
    public partial class TKKhachHang
    {
        [Key]
        public int MaKH { get; set; }

        [Required]
        [StringLength(30)]
        public string TenTK { get; set; }

        [Required]
        [StringLength(100)]
        public string MatKhau { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
