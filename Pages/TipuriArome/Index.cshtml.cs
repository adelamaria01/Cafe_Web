using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Kovacs_Adela_Licenta.Data;
using Kovacs_Adela_Licenta.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Kovacs_Adela_Licenta.Pages.TipuriArome
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly Kovacs_Adela_Licenta.Data.Kovacs_Adela_LicentaContext _context;

        public IndexModel(Kovacs_Adela_Licenta.Data.Kovacs_Adela_LicentaContext context)
        {
            _context = context;
        }

        public IList<TipAroma> TipAroma { get;set; } = default!;
        public string Descrescator { get; set; }
        public string Crescator { get; set; }
        public CafeaData CafeaD { get; set; }


        public async Task OnGetAsync(string sortOrder)
        {
            CafeaD = new CafeaData();
            Descrescator = String.IsNullOrEmpty(sortOrder) ? "descrescator" : "";
            Crescator = String.IsNullOrEmpty(sortOrder) ? "crescator" : "";

            CafeaD.TipAroma = await _context.TipAroma.ToListAsync();

            switch (sortOrder)
            {
                case "descrescator":
                    CafeaD.TipAroma = CafeaD.TipAroma.OrderByDescending(s =>
                   s.DenumireAroma);
                    break;

                case "crescator":
                    CafeaD.TipAroma = CafeaD.TipAroma.OrderBy(s =>
                  s.DenumireAroma);
                    break;

            }

        }
    }
}
