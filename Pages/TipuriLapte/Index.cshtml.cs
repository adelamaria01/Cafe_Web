using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Kovacs_Adela_Licenta.Data;
using Kovacs_Adela_Licenta.Models;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Kovacs_Adela_Licenta.Pages.TipuriLapte
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly Kovacs_Adela_Licenta.Data.Kovacs_Adela_LicentaContext _context;

        public IndexModel(Kovacs_Adela_Licenta.Data.Kovacs_Adela_LicentaContext context)
        {
            _context = context;
        }

        public IList<TipLapte> TipLapte { get;set; } = default!;
        public string Descrescator { get; set; }
        public string Crescator { get; set; }
        public CafeaData CafeaD { get; set; }
        public async Task OnGetAsync(string sortOrder)
        {
            CafeaD = new CafeaData();
            Descrescator = String.IsNullOrEmpty(sortOrder) ? "descrescator" : "";
            Crescator = String.IsNullOrEmpty(sortOrder) ? "crescator" : "";
            
            CafeaD.TipLapte = await _context.TipLapte.ToListAsync();

            switch (sortOrder)
            {
                case "descrescator":
                    CafeaD.TipLapte = CafeaD.TipLapte.OrderByDescending(s =>
                   s.DenumireLapte);
                    break;

                case "crescator":
                    CafeaD.TipLapte = CafeaD.TipLapte.OrderBy(s =>
                  s.DenumireLapte);
                    break;

            }

        }
    }
}
