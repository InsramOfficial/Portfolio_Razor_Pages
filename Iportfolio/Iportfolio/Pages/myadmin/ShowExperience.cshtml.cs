using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.myadmin
{
    public class ShowExperienceModel : PageModel
    {
        AppDbContext db;
        public List<Experience> experience { get; set; }
        public ShowExperienceModel(AppDbContext _db)
        {
            db= _db;
        }
        public void OnGet()
        {
            experience=db.tbl_Experience.ToList();
        }
        public IActionResult OnGetDelete(int Id) {

          var  ItemToDel = db.tbl_Experience.Find(Id);
            db.tbl_Experience.Remove(ItemToDel);
            db.SaveChanges();
            return RedirectToPage("ShowExperience");

        }
    }
}
