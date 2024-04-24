using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.myadmin
{
    public class AddServicesModel : PageModel
    {
        AppDbContext db;
        public List<Services> services { get; set; }
        public AddServicesModel(AppDbContext _db)
        {
            db=_db;
        }
        public void OnGet()
        {
            services = db.tbl_Services.ToList();      
        }
  
        public IActionResult OnPost(Services services)
        {
            db.tbl_Services.Add(services);
            db.SaveChanges();
            return RedirectToPage("ShowServices");
        }
    }
}
