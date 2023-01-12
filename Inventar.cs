namespace MagazinElectronic
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Inventar")]
    public partial class Inventar
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDProdus { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Cantitate { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "money")]
        public decimal PretUnitar { get; set; }

        public virtual Produse Produse { get; set; }
    }
}
