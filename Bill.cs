namespace MagazinElectronic
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bill")]
    public partial class Bill
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDOrder { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool Bill_status { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime Payment_date { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "money")]
        public decimal Bill_amount { get; set; }

        [StringLength(50)]
        public string DetaliiBill { get; set; }

        public virtual Order Order { get; set; }
    }
}
