namespace webproje1.Models
{
    public class Recel
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public decimal Fiyat { get; set; }
        public string ResimUrl { get; set; }
        public string Yore { get; set; }
        public DateTime UretimTarihi { get; set; }
        public int Uretici { get; set; }

        public bool StoktaMi { get; set; }
    }
}
