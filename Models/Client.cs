using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Kovacs_Adela_Licenta.Models
{
    public class Client
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "The name should start with a capital letter (ex: Pop) and also, it should contain at least 3 letters.")]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "First name")]
        public string? Nume { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "The name of the flavour type should start with a capital letter (ex:Mihai) and also, it should contain at least 3 letters.")]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Last name")]
        public string? Prenume { get; set; }

        [RegularExpression("^\\S+@\\S+\\.\\S+$")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "The email cannot start with special characters and neither can it end that way!(Example of valid email: anapop@gmail.com)")]
        public string Email { get; set; }

        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "The phone number format should be like '0744-666-100' or '0744.666.100' or '0744 666 100'.")]
        [Display(Name = "Phone")]
        public string? Telefon { get; set; }

        [Display(Name = "Full name")]
        public string? NumeComplet
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }

        public ICollection<Poveste>? Poveste { get; set; }

        public ICollection<CafeaClient>? CafeaClient { get; set; }
    }
}
