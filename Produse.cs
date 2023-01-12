namespace MagazinElectronic
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Produse")]
    public partial class Produse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Produse()
        {
            Orders = new HashSet<Order>();
            Inventars = new HashSet<Inventar>();
        }

        [Key]
        public int IDProdus { get; set; }

        [Required]
        [StringLength(50)]
        public string Denumire { get; set; }

        public int IDCategorie { get; set; }

        [Required]
        [StringLength(50)]
        public string DescriereProdus { get; set; }

        public virtual CategorieProduse CategorieProduse { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventar> Inventars { get; set; }
    }
}
