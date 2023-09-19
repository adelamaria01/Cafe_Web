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

namespace Kovacs_Adela_Licenta.Pages.Povesti
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly Kovacs_Adela_Licenta.Data.Kovacs_Adela_LicentaContext _context;

        public DeleteModel(Kovacs_Adela_Licenta.Data.Kovacs_Adela_LicentaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Poveste Poveste { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Poveste == null)
            {
                return NotFound();
            }

            var poveste = await _context.Poveste.FirstOrDefaultAsync(m => m.ID == id);

            if (poveste == null)
            {
                return NotFound();
            }
            else 
            {
                Poveste = poveste;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Poveste == null)
            {
                return NotFound();
            }
            var poveste = await _context.Poveste.FindAsync(id);

            if (poveste != null)
            {
                Poveste = poveste;
                _context.Poveste.Remove(Poveste);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
