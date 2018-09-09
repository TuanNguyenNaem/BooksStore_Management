namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTSach")]
    public partial class CTSach
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaS { get; set; }

        [Required]
        [StringLength(100)]
        public string TenS { get; set; }

        [Required]
        [StringLength(10)]
        public string LoaiBia { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayXuatBan { get; set; }

        [Required]
        [StringLength(10)]
        public string Kho { get; set; }

        public int SoTrang { get; set; }

        [Required]
        [StringLength(30)]
        public string LoaiGiay { get; set; }

        [Column(TypeName = "money")]
        public decimal Gia { get; set; }

        [StringLength(3000)]
        public string ChiTiet { get; set; }

        public virtual Sach Sach { get; set; }
    }
}
