using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.myadmin
{
    public class UpdatetestimonialModel : PageModel
    {
        AppDbContext db;
        IWebHostEnvironment env;
        public Testimonial testimonial { get; set; }
        public UpdatetestimonialModel(AppDbContext _db, IWebHostEnvironment env)
        {
            db = _db;
            this.env = env;
        }

        public void Onget()
        {
            testimonial = db.tbl_Testimonial.FirstOrDefault();

        }

        public IActionResult OnPost(Testimonial testimonial)
        {

            if (testimonial.Photo is null)
            {
                db.tbl_Testimonial.Update(testimonial);
                db.SaveChanges();
            }
            else
            {
                string ImageName = testimonial.Photo.FileName;
                var folderpath = Path.Combine(env.WebRootPath, "images");
                var imagepath = Path.Combine(folderpath, ImageName);
                FileStream fs = new FileStream(imagepath, FileMode.Create);
                testimonial.Photo.CopyTo(fs);
                fs.Dispose();
                testimonial.Image = ImageName;
                db.tbl_Testimonial.Update(testimonial);
                db.SaveChanges();

            }
            return RedirectToPage("Updatetestimonial");
        }
    }
}
