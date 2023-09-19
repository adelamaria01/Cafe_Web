using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Kovacs_Adela_Licenta.Models
{
    public class CafeaClient
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

        //Cheie straina si navigation propery pentru Marime
        public int? MarimeID { get; set; }
        [Display(Name = "Cup size")]
        public Marime? Marime { get; set; }

        //Cheie straina si navigation propery pentru Client
        public int? ClientID { get; set; }
        [Display(Name = "Owner")]
        public Client? Client { get; set; }

    }
}
