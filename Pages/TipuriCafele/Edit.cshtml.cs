﻿using System;
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

namespace Kovacs_Adela_Licenta.Pages.TipuriCafele
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
        public TipCafea TipCafea { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TipCafea == null)
            {
                return NotFound();
            }

            var tipcafea =  await _context.TipCafea.FirstOrDefaultAsync(m => m.ID == id);
            if (tipcafea == null)
            {
                return NotFound();
            }
            TipCafea = tipcafea;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TipCafea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipCafeaExists(TipCafea.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TipCafeaExists(int id)
        {
          return (_context.TipCafea?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
