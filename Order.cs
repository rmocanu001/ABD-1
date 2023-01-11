namespace MagazinElectronic
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Bills = new HashSet<Bill>();
        }

        [Key]
        public int IDOrder { get; set; }

        public int IDCostumer { get; set; }

        public int IDProdus { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataPlasareComanda { get; set; }

        public int Order_quantity { get; set; }

        public virtual Costumer Costumer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bills { get; set; }

        public virtual Produse Produse { get; set; }
    }
}
