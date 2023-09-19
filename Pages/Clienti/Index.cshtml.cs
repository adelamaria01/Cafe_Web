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

namespace Kovacs_Adela_Licenta.Pages.Clienti
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly Kovacs_Adela_Licenta.Data.Kovacs_Adela_LicentaContext _context;

        public IndexModel(Kovacs_Adela_Licenta.Data.Kovacs_Adela_LicentaContext context)
        {
            _context = context;
        }

        //PENTRU CAUTARE - SEARCH STRING
        public string CurrentFilter { get; set; }
        public CafeaData CafeaD { get; set; }
        public IList<Client> Client { get;set; } = default!;

        public async Task OnGetAsync(string searchString)
        {
            CafeaD = new CafeaData();
            CurrentFilter = searchString;

            CafeaD.Client = await _context.Client.ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                CafeaD.Client = CafeaD.Client.Where(s => s.NumeComplet.ToLower().Contains(searchString));
            }

        }
    }
}
