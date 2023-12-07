namespace webproje1.Models
{
    public class Yag
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public decimal Fiyat { get; set; }
        public string ResimUrl { get; set; }
        public string Yore { get; set; }
        public DateTime UretimTarihi { get; set; }

        public bool StoktaMi { get; set; }
    }
}
