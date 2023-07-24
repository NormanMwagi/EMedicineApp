namespace EMediceBE.Models
{
    public class Orders
    {
        public Int64 id { get; set; }
        public Int64 user_id { get; set; }
        public string order_no { get; set; }
        public Decimal order_total { get; set; }
        public string order_status { get; set; }
    }
}
