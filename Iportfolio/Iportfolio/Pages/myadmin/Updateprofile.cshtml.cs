using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.myadmin
{
    public class UpdateprofileModel : PageModel
    {
        AppDbContext db;
        IWebHostEnvironment env;
        public Profile profile { get; set; }
        public UpdateprofileModel(AppDbContext _db, IWebHostEnvironment env)
        {
            db = _db;
            this.env = env;
        }

        public void Onget()
        {
            profile = db.tbl_Profile.FirstOrDefault();

        }
        public IActionResult OnPost(Profile profile)
        {

            if(profile.Photo is null)
            {
                db.tbl_Profile.Update(profile);
                db.SaveChanges();
            }
            else
            {
                string ImageName = profile.Photo.FileName;
                var folderpath = Path.Combine(env.WebRootPath, "images");
                var imagepath = Path.Combine(folderpath, ImageName);
                FileStream fs = new FileStream(imagepath, FileMode.Create);
                profile.Photo.CopyTo(fs);
                fs.Dispose();
                profile.Image = ImageName;
                db.tbl_Profile.Update(profile);
                db.SaveChanges();
               
            }
            return RedirectToPage("Updateprofile");
        }
    }
}
