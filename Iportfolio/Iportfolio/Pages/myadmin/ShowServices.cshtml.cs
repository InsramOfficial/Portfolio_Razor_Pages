using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.myadmin
{
    public class ShowServicesModel : PageModel
    {
        AppDbContext db;
        public List<Services> services { get; set; }
        public ShowServicesModel(AppDbContext _db)
        {
            db = _db;
        }
        public void OnGet()
        {
            services=db.tbl_Services.ToList();
        }
        public IActionResult OnGetDelete(int Id)
        {
          var  ItemToDel = db.tbl_Services.Find(Id);
            db.tbl_Services.Remove(ItemToDel);
            return RedirectToPage("showServices");
        }
    }
}
