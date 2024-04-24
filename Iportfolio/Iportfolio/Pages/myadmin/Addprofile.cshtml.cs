using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.myadmin
{
    public class AddprofileModel : PageModel
    {
        AppDbContext db;
        IWebHostEnvironment env;
        public Profile profile { get; set; }
        public AddprofileModel(AppDbContext _db,IWebHostEnvironment env)
        {
            db = _db;
            this.env = env;
        }
        
        public void Onget()
        {

        }
        public IActionResult OnPost(Profile profile)
        {
            string ImageName = profile.Photo.FileName.ToString();
            var folderpath = Path.Combine(env.WebRootPath, "images");
            var imagepath= Path.Combine(folderpath,ImageName);
            FileStream fs= new FileStream(imagepath,FileMode.Create);
            profile.Photo.CopyTo(fs);
            fs.Dispose();
            profile.Image = ImageName;
            db.tbl_Profile.Add(profile);
            db.SaveChanges ();
            return RedirectToPage("Addprofile");
        }

    }
}
