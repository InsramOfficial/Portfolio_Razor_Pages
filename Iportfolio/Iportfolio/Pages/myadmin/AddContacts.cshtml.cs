using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.myadmin
{
    public class AddContactsModel : PageModel
    {
        AppDbContext db;
        public Contact contact { get; set; }
        public AddContactsModel(AppDbContext _db)
        {
            db=_db;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(Contact contact) {
           db.tbl_Contact.Add(contact);
            db.SaveChanges();
            return RedirectToPage("ShowContacts");
        }
    }
}
