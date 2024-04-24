using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.myadmin
{
    public class ShowContactsModel : PageModel
    {
        AppDbContext db;
        public List<Contact> contacts { get; set; }
        public ShowContactsModel(AppDbContext _db)
        {
            db = _db;
        }
        public void OnGet()
        {
            contacts = db.tbl_Contact.ToList();
        }
        public IActionResult OnGetDelete(int Id) 
        {
            var ItemToDel = db.tbl_Contact.Find(Id);
            db.tbl_Contact.Remove(ItemToDel);
            db.SaveChanges();
            return RedirectToPage("ShowContacts");
        }
    }
}
