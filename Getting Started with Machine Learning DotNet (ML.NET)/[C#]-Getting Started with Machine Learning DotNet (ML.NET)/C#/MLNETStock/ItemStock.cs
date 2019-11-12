using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Runtime.Api;

namespace MLNETStock
{
    public class ItemStock
    {
        [Column("0")]
        public string ItemID;

        [Column("1")]
        public float Loccode;

        [Column("2")]
        public float InQty;

        [Column("3")]
        public float OutQty;

        [Column("4")]
        public string ItemType;

        [Column("5")]
        public float TotalStockQty;
    }

    public class itemStockQtyPrediction
    {
        [ColumnName("Score")]
        public float TotalStockQty;
    }
}
