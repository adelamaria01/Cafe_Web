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

namespace Kovacs_Adela_Licenta.Pages.Marimi
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly Kovacs_Adela_Licenta.Data.Kovacs_Adela_LicentaContext _context;

        public DetailsModel(Kovacs_Adela_Licenta.Data.Kovacs_Adela_LicentaContext context)
        {
            _context = context;
        }

      public Marime Marime { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Marime == null)
            {
                return NotFound();
            }

            var marime = await _context.Marime.FirstOrDefaultAsync(m => m.ID == id);
            if (marime == null)
            {
                return NotFound();
            }
            else 
            {
                Marime = marime;
            }
            return Page();
        }
    }
}
