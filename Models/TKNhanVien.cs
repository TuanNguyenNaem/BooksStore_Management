namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TKNhanVien")]
    public partial class TKNhanVien
    {
        [Key]
        public int MaNV { get; set; }

        [Required]
        [StringLength(30)]
        public string TenTK { get; set; }

        [Required]
        [StringLength(100)]
        public string MatKhau { get; set; }

        [Required]
        [StringLength(50)]
        public string ChucVu { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
