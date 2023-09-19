using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Kovacs_Adela_Licenta.Models
{
    public class TipCafea
    {
        public int ID { get; set; }

        [Display(Name = "Coffee type")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "The name of the coffee should start with a capital letter and also, it should contain at least 3 letters.")]

        [StringLength(70, MinimumLength = 3)]
        public string Tip { get; set; }

        //O sa contina referinta catre mai multe cafele
        public ICollection<Cafea>? Cafele { get; set; }
    }
}
