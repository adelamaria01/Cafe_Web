namespace Kovacs_Adela_Licenta.Models
{
    public class CafeaData
    {
        public IEnumerable<Cafea> Cafele { get; set; }
        public IEnumerable<CafeaClient> CafeleClienti { get; set; }
        public IEnumerable<TipTopping> TipTopping { get; set; }
        public IEnumerable<TipAroma> TipAroma { get; set; }
        public IEnumerable<TipBoabe> TipBoabe { get; set; }
        public IEnumerable<TipLapte> TipLapte { get; set; }
        public IEnumerable<Client> Client { get; set; }
    }
}
