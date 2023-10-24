namespace EntityLinQProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Transfers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transfers()
        {
            TransferDetails = new HashSet<TransferDetails>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TransferID { get; set; }

        public int? FromStoreID { get; set; }

        public int? ToStoreID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TransferDate { get; set; }

        public virtual Stores Stores { get; set; }

        public virtual Stores Stores1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransferDetails> TransferDetails { get; set; }
    }
}
