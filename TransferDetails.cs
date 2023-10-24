namespace EntityLinQProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TransferDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TransferDetailID { get; set; }

        public int? TransferID { get; set; }

        public int? ProductID { get; set; }

        public int? Quantity { get; set; }

        public virtual Products Products { get; set; }

        public virtual Transfers Transfers { get; set; }
    }
}
