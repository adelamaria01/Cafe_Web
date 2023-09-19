using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Kovacs_Adela_Licenta.Models
{
    public class Marime
    {
        public int ID { get; set; }

        [Display(Name = "Coffe size - ml")]
        public string MarimeMl { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 100)]
        [Display(Name = "Price")]
        public decimal Pret { get; set; }

        //O sa contina referinta catre mai multe cafele
        public ICollection<CafeaClient>? CafeleClient { get; set; }
    }
}
