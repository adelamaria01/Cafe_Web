using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Kovacs_Adela_Licenta.Models
{
    public class Cafea
    {
        public int ID { get; set; }

        [Display(Name = "Coffee name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "The name of the coffee should start with a capital letter.")]
        public string DenumireCafea { get; set; }

        //Cheie straina si navigation propery pentru TipCafea
        public int? TipCafeaID { get; set; }
        [Display(Name = "Coffee type")]
        public TipCafea? TipCafea { get; set; }

        //Cheie straina si navigation propery pentru TipBoabe
        public int? TipBoabeID { get; set; }
        [Display(Name = "Beans")]
        public TipBoabe? TipBoabe { get; set; }

        //Cheie straina si navigation propery pentru Lapte
        public int? TipLapteID { get; set; }
        [Display(Name = "Milk")]
        public TipLapte? TipLapte { get; set; }

        //Cheie straina si navigation propery pentru Arome
        public int? TipAromaID { get; set; }
        [Display(Name = "Flavour")]
        public TipAroma? TipAroma { get; set; }

        //Cheie straina si navigation propery pentru Toppinguri
        public int? TipToppingID { get; set; }
        [Display(Name = "Topping")]
        public TipTopping? TipTopping { get; set; }

        [Display(Name = "Price")]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }

        [Display(Name = "Image")]
        public String Imagine { get; set; }

        [Display(Name = "Category")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "You must select either: \"Iced coffee\" or \"Hot coffee\"")]
        [StringLength(11, MinimumLength = 10)]
        public String CategorieCafea { get; set; }

    }
}
