using System.ComponentModel.DataAnnotations;

namespace webproje1.Models
{
    public class Feedback
    {
     public int Id { get; set; }
     public string Name { get; set; }
     [Required(ErrorMessage = "Email alanı gereklidir.")]
     [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
     public string Email { get; set; } 
     public string Message { get; set; }
    }
}
