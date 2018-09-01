namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhuVuc")]
    public partial class KhuVuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhuVuc()
        {
            HoaDonXuat = new HashSet<HoaDonXuat>();
        }

        [Key]
        public int MaKV { get; set; }

        [Required]
        [StringLength(100)]
        public string TenKV { get; set; }

        [Column(TypeName = "money")]
        public decimal PhiShip { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDonXuat> HoaDonXuat { get; set; }
    }
}
