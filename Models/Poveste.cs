using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Kovacs_Adela_Licenta.Models
{
    public class Poveste
    {
        public int ID { get; set; }
        [Display(Name = "The story")]
        public string text { get; set; }

        public string NumeClient { get; set; }

        //Cheie straina si navigation propery pentru Toppinguri
        public int? ClientID { get; set; }
        [Display(Name = "Client")]
        public Client? Client { get; set; }
        public string Imagine { get; set; }
    }
}
