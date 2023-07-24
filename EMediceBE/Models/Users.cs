namespace EMediceBE.Models
{
    public class Users
    {
        public Int64 id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public Decimal fund { get; set; }
        public string type { get; set; }
        public Int64 status { get; set; }
        public DateTime created_on { get; set; }
    }
}
