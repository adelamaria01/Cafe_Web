﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Kovacs_Adela_Licenta.Data;
using Kovacs_Adela_Licenta.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Kovacs_Adela_Licenta.Pages.TipuriArome
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly Kovacs_Adela_Licenta.Data.Kovacs_Adela_LicentaContext _context;

        public CreateModel(Kovacs_Adela_Licenta.Data.Kovacs_Adela_LicentaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TipAroma TipAroma { get; set; } = default!;
        
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.TipAroma == null || TipAroma == null)
            {
                return Page();
            }

            _context.TipAroma.Add(TipAroma);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
