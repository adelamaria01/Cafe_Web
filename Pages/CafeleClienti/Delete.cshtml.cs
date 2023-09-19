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

namespace Kovacs_Adela_Licenta.Pages.CafeleClienti
{
    public class DeleteModel : PageModel
    {
        private readonly Kovacs_Adela_Licenta.Data.Kovacs_Adela_LicentaContext _context;

        public DeleteModel(Kovacs_Adela_Licenta.Data.Kovacs_Adela_LicentaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public CafeaClient CafeaClient { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CafeaClient == null)
            {
                return NotFound();
            }

            var cafeaclient = await _context.CafeaClient.FirstOrDefaultAsync(m => m.ID == id);

            if (cafeaclient == null)
            {
                return NotFound();
            }
            else 
            {
                CafeaClient = cafeaclient;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.CafeaClient == null)
            {
                return NotFound();
            }
            var cafeaclient = await _context.CafeaClient.FindAsync(id);

            if (cafeaclient != null)
            {
                CafeaClient = cafeaclient;
                _context.CafeaClient.Remove(CafeaClient);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
