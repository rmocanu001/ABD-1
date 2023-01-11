namespace MagazinElectronic
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Costumer")]
    public partial class Costumer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Costumer()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public int IDCostumer { get; set; }

        [Required]
        [StringLength(50)]
        public string login_name { get; set; }

        [Required]
        [StringLength(50)]
        public string login_password { get; set; }

        [Required]
        [StringLength(100)]
        public string email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
