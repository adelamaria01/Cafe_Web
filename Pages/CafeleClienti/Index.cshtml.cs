
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
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Kovacs_Adela_Licenta.Pages.CafeleClienti
{
    public class IndexModel : PageModel
    {
        private readonly Kovacs_Adela_Licenta.Data.Kovacs_Adela_LicentaContext _context;
        private readonly UserManager<IdentityUser> _userManager;




        public IndexModel(Kovacs_Adela_Licenta.Data.Kovacs_Adela_LicentaContext context, UserManager<IdentityUser> userManager)        {
            _context = context;
            _userManager = userManager;
        }

        public IList<CafeaClient> CafeaClient { get; set; } = default!;
        public string CurrentFilter { get; set; }
        public CafeaData CafeaD { get; set; }


        public async Task OnGetAsync(int? id, string searchString)
        {
            var user = await _userManager.GetUserAsync(User);
            var clientId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Console.WriteLine(clientId);

            CafeaD = new CafeaData();

            CafeaD.CafeleClienti = await _context.CafeaClient
            .Where(c => c.Client.Email == _userManager.GetUserName(User) && c.ClientID == c.Client.ID) // PT AFISARE BAZATA PE UTILIZATOR
            .Include(c => c.TipAroma)
            .Include(c => c.TipBoabe)
            .Include(c => c.TipCafea)
            .Include(c => c.TipLapte)
            .Include(c => c.TipTopping)
            .Include(c => c.Marime)
            .ToListAsync();


            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                CafeaD.CafeleClienti = CafeaD.CafeleClienti.Where(s => s.DenumireCafea.ToLower().Contains(searchString));
            }

        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            string qr_link = Request.Form["qr"];
            string email = Request.Form["email"];

            await SendEmail(email, qr_link);

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> SendEmail(string toEmail, string qr)
        {

            var from = new EmailAddress("verve.for.people@gmail.com", "VerveFamily");
            var to = new EmailAddress(toEmail);
            const string subject = "Verve coffee";

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


