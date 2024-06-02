using System;

namespace ApiWebDB.DTO
{
    public class StockLogDTO
    {
        public long Id { get; set; }
        public int Productid { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }
        public DateTime Createdat { get; set; }
    }
}
