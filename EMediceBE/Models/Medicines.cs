
namespace EMediceBE.Models
{
    public class Medicines
    {
        public Int64 id { get; set; }
        public string name { get; set; }
        public string manufacturer { get; set; }
        public Decimal unit_price { get; set; }
        public Decimal discount { get; set; }
        public Int64 quantity { get; set; }
        public DateTime exp_date { get; set; }
        public string img_url { get; set; }
        public Int64 status { get; set; }
        public string type { get; set; }
    }
}
