using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kovacs_Adela_Licenta.Data;
using Kovacs_Adela_Licenta.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Kovacs_Adela_Licenta.Pages.Povesti
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly Kovacs_Adela_Licenta.Data.Kovacs_Adela_LicentaContext _context;

        public EditModel(Kovacs_Adela_Licenta.Data.Kovacs_Adela_LicentaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Poveste Poveste { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Poveste = await _context.Poveste
                .Include(b => b.Client)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Poveste == null)
            {
                return NotFound();
            }


            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var povesteActualizare = await _context.Poveste
               .Include(i => i.Client)
               .FirstOrDefaultAsync(s => s.ID == id);

            if (povesteActualizare == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Poveste>(
            povesteActualizare,
            "Poveste",
            i => i.text, i => i.NumeClient, i => i.Imagine))
            {

                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return RedirectToPage("./Index");
        }

        
    }
}
