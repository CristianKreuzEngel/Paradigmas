using System;

namespace ApiWebDB.DTO
{
    public class PromotionDTO
    {
        public int Id { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public int Promotiontype { get; set; }
        public int Productid { get; set; }
        public decimal Value { get; set; }
    }
}
