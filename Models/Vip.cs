namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vip")]
    public partial class Vip
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vip()
        {
            KhachHang = new HashSet<KhachHang>();
        }

        [Key]
        public int MaVip { get; set; }

        [Required]
        [StringLength(10)]
        public string TenVip { get; set; }

        [Column(TypeName = "money")]
        public decimal Moc { get; set; }

        public int UuDai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhachHang> KhachHang { get; set; }
    }
}
