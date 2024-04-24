using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.myadmin
{
    public class UpdateContactsModel : PageModel
    {
        AppDbContext db;
        public Contact contact { get; set; }
        public UpdateContactsModel(AppDbContext _db)
        {
            db = _db;
        }
        public void OnGet( int Id)
        {
            contact = db.tbl_Contact.Find(Id);
            
        }
        public IActionResult OnPost(Contact contact ) 
        {
            db.tbl_Contact.Update(contact);
            db.SaveChanges();
            return RedirectToPage("ShowContacts");

        }
    }
}
