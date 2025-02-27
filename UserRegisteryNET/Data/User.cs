using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
//using BCrypt.Net;

namespace UserRegisteryNET.Data
{
    [Index(nameof(TCKN), IsUnique = true)]
    internal sealed class User // Inheritable olmasın, proje dışından erişilmesin
    {
        [Key]
        public int UserId { get; set; }


        // İsim zorunlu, maks 100 karakter
        [Required]
        [MaxLength(length: 100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(length: 100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "TCKN 11 karakterden oluşmalıdır.")]
        [RegularExpression("^[1-9][0-9]{10}$", ErrorMessage = " TCKN formatı yanlış.")]
        public string TCKN { get; set; } = string.Empty;

        //[Required]
        //public string PasswordHash { get; set; } = string.Empty;

        // Şifreler direkt olarak depolanmayacak
        //[Required]
        [MinLength(8)]
        [MaxLength(100)]
        //[DataType(DataType.Password)]
        //[NotMapped] // EF Core tarafından veritabanına yansıtılmayacak
        public string Password { get; set; } = string.Empty;


    }
}
