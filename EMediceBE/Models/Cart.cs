namespace EMediceBE.Models
{
    public class Cart
    {
        public Int64 id { get; set; }
        public Int64 user_id { get; set; }
        public Int64 medicine_id { get; set; }
        public Decimal unit_price { get; set; }
        public Decimal discount { get; set; }
        public Int64 quantity { get; set; }
        public Decimal total_price { get; set; }
    }
}
