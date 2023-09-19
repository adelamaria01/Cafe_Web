using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Kovacs_Adela_Licenta.Data;
using Kovacs_Adela_Licenta.Models;
using SendGrid.Helpers.Mail;
using SendGrid;
using System.Net;

namespace Kovacs_Adela_Licenta.Pages.Cafele
{
    public class IndexModel : PageModel
    {
        private readonly Kovacs_Adela_Licenta.Data.Kovacs_Adela_LicentaContext _context;

        public IndexModel(Kovacs_Adela_Licenta.Data.Kovacs_Adela_LicentaContext context)
        {
            _context = context;
        }
        public string CurrentFilter { get; set; }
        public IList<Cafea> Cafea { get; set; } = default!;
        public CafeaData CafeaD { get; set; }

        public async Task OnGetAsync(int? id, string searchString, string coffeeType)
        {
            CafeaD = new CafeaData();
            CurrentFilter = searchString;

            CafeaD.Cafele = _context.Cafea
                .Include(c => c.TipAroma)
                .Include(c => c.TipBoabe)
                .Include(c => c.TipCafea)
                .Include(c => c.TipLapte)
                .Include(c => c.TipTopping);

            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                CafeaD.Cafele = CafeaD.Cafele.Where(s => s.DenumireCafea.ToLower().Contains(searchString));
            }

            if (!String.IsNullOrEmpty(coffeeType))
            {
                switch (coffeeType.ToLower())
                {
                    case "decaf":
                        CafeaD.Cafele = CafeaD.Cafele.Where(c => c.TipCafea.Tip.ToLower() == "decaf");
                        break;
                    case "regular":
                        CafeaD.Cafele = CafeaD.Cafele.Where(c => c.TipCafea.Tip.ToLower() == "regular");
                        break;
                    case "iced coffee":
                        CafeaD.Cafele = CafeaD.Cafele.Where(c => c.CategorieCafea.ToLower() == "iced coffee");
                        break;
                    case "hot coffee":
                        CafeaD.Cafele = CafeaD.Cafele.Where(c => c.CategorieCafea.ToLower() == "hot coffee");
                        break;
                    default:
                        break;
                }
            }

        }

        public async Task<IActionResult> OnPostAsync()
        {
            string qr_link = Request.Form["qr"];
            string email = Request.Form["email"];

            await SendEmail(email, qr_link);

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> SendEmail(string toEmail, string qr)
        {

            // Mail header
            var from = new EmailAddress("verve.for.people@gmail.com", "VerveFamily");
            var to = new EmailAddress(toEmail);
            const string subject = "Verve coffee";

            // Client 
            var apiKey = "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";
            var client = new SendGridClient(apiKey);

            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", WebUtility.HtmlEncode("Hello there, coffee lover! Here's the link to your custom QR code:" + "https://api.qrserver.com/v1/create-qr-code/?size=150x150&data=" + qr));


            var response = await client.SendEmailAsync(msg);

            if (response.StatusCode != HttpStatusCode.Accepted)
            {
                throw new Exception("Error sending message");
            }


            return RedirectToPage("Index");
        }
    }
}



