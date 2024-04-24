using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.myadmin
{
    public class UpdateServicesModel : PageModel
    {
        AppDbContext db;
        public Services services { get; set; }
        public UpdateServicesModel(AppDbContext _db)
        {
            db = _db;
        }
        public void OnGet(int Id)
        {
            services = db.tbl_Services.Find(Id);
           
        }
        public IActionResult OnPost(Services services)
        {
            db.tbl_Services.Update(services);
            db.SaveChanges();
            return RedirectToPage("ShowServices");
        }
    }
}
