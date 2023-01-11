namespace MagazinElectronic
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CategorieProduse")]
    public partial class CategorieProduse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CategorieProduse()
        {
            Produses = new HashSet<Produse>();
        }

        [Key]
        public int IDCategorie { get; set; }

        [Required]
        [StringLength(50)]
        public string Denumire { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produse> Produses { get; set; }
    }
}
