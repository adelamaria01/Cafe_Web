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
using SendGrid.Helpers.Mail;
using SendGrid;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Identity;

namespace Kovacs_Adela_Licenta.Pages.CafeleClienti
{
    public class EditModel : PageModel
    {
        private readonly Kovacs_Adela_Licenta.Data.Kovacs_Adela_LicentaContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public EditModel(Kovacs_Adela_Licenta.Data.Kovacs_Adela_LicentaContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public CafeaClient CafeaClient { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CafeaClient = await _context.CafeaClient
                .Include(b => b.TipCafea)
                .Include(b => b.TipBoabe)
                .Include(b => b.TipLapte)
                .Include(b => b.TipAroma)
                .Include(b => b.TipTopping)
                .Include(b => b.Marime)
                .Include(b => b.Client)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (CafeaClient == null)
            {
                return NotFound();
            }

            // POPULARE VIEWDATA - TIP CAFEA
            var listaTipCafea = _context.TipCafea.Select(x => new
            {
                x.ID,
                x.Tip

            });
            ViewData["TipCafeaID"] = new SelectList(listaTipCafea, "ID", "Tip");

            // POPULARE VIEWDATA - TIP BOABE
            var listaTipBoabe = _context.TipBoabe.Select(x => new
            {
                x.ID,
                x.DenumireBoabe
            });
            ViewData["TipBoabeID"] = new SelectList(listaTipBoabe, "ID", "DenumireBoabe");

            // POPULARE VIEWDATA - TIP LAPTE
            var listaTipLapte = _context.TipLapte.Select(x => new
            {
                x.ID,
                x.DenumireLapte
            });
            ViewData["TipLapteID"] = new SelectList(listaTipLapte, "ID", "DenumireLapte");

            // POPULARE VIEWDATA - TIP AROMA
            var listaTipAroma = _context.TipAroma.Select(x => new
            {
                x.ID,
                x.DenumireAroma
            });
            ViewData["TipAromaID"] = new SelectList(listaTipAroma, "ID", "DenumireAroma");

            // POPULARE VIEWDATA - TIP TOPPING
            var listaTipTopping = _context.TipTopping.Select(x => new
            {
                x.ID,
                x.DenumireTopping
            });
            ViewData["TipToppingID"] = new SelectList(listaTipTopping, "ID", "DenumireTopping");

            // POPULARE VIEWDATA - MARIME
            var listaMarime = _context.Marime.Select(x => new
            {
                x.ID,
                infoMarime = x.MarimeMl + " " + x.Pret.ToString()
            });
            ViewData["MarimeID"] = new SelectList(listaMarime, "ID", "infoMarime");

            var listaIdClienti = _context.Client
            .Where(c => c.Email == _userManager.GetUserName(User)) // CA SA AFISAM DOAR NUMELE UTILIZATORULUI CURENT LOGAT
             .Select(x => new
             {
                 x.ID,
                 x.Email
             });
            ViewData["ClientID"] = new SelectList(listaIdClienti, "ID", "Email");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cafeaActualizare = await _context.CafeaClient
                .Include(i => i.TipCafea)
                .Include(b => b.TipBoabe)
                .Include(b => b.TipLapte)
                .Include(b => b.TipAroma)
                .Include(b => b.TipTopping)
                .Include(b => b.Marime)
                .Include(b => b.Client)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (cafeaActualizare == null)
            {
                return NotFound();
            }


            if (await TryUpdateModelAsync<CafeaClient>(
            cafeaActualizare,
            "CafeaClient",
            i => i.DenumireCafea, i => i.TipCafeaID, i => i.TipBoabeID, i => i.TipLapteID,
            i => i.TipAromaID, i => i.TipToppingID, i => i.MarimeID, i => i.ClientID))
            {

                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }


            return Page();
        }

        
    }
}