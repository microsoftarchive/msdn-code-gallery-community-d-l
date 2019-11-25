namespace LINQ_B_to_A.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sales.CustomerTransactions")]
    public partial class CustomerTransaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerTransactionID { get; set; }

        public int CustomerID { get; set; }

        public int TransactionTypeID { get; set; }

        public int? InvoiceID { get; set; }

        public int? PaymentMethodID { get; set; }

        [Column(TypeName = "date")]
        public DateTime TransactionDate { get; set; }

        public decimal AmountExcludingTax { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal TransactionAmount { get; set; }

        public decimal OutstandingBalance { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FinalizationDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public bool? IsFinalized { get; set; }

        public int LastEditedBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime LastEditedWhen { get; set; }

        public virtual PaymentMethod PaymentMethod { get; set; }

        public virtual Person Person { get; set; }

        public virtual TransactionType TransactionType { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}
