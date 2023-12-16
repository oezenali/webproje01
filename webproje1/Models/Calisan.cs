using System.ComponentModel.DataAnnotations;

namespace webproje1.Models
{
    public class Calisan
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Ad")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Pozisyon")]
        public string Position { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefon Numarası")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-posta Adresi")]
        public string Email { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Maaş")]
        public decimal Salary { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "İşe Başlama Tarihi")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Tam Zamanlı Mı?")]
        public bool IsFullTime { get; set; }
    }
}
