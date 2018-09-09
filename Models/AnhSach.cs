namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AnhSach")]
    public partial class AnhSach
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaS { get; set; }

        [StringLength(300)]
        public string Anh1 { get; set; }

        [StringLength(300)]
        public string Anh2 { get; set; }

        [StringLength(300)]
        public string Anh3 { get; set; }

        [StringLength(300)]
        public string Anh4 { get; set; }

        [StringLength(300)]
        public string Anh5 { get; set; }

        [StringLength(300)]
        public string Anh6 { get; set; }

        public virtual Sach Sach { get; set; }
    }
}
