using Iportfolio.Data;
using Iportfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Iportfolio.Pages.myadmin
{
    public class AddtestimonialModel : PageModel
    {
        AppDbContext db;
        IWebHostEnvironment env;
        public Testimonial testimonial { get; set; }
        public AddtestimonialModel(AppDbContext _db, IWebHostEnvironment env)
        {
            db = _db;
            this.env = env;
            testimonial = new Testimonial();
        }

        public void Onget()
        {

        }
        public IActionResult OnPost(Testimonial testimonial)
        {
            string ImageName = testimonial.Photo.FileName.ToString();
            var folderpath = Path.Combine(env.WebRootPath, "images");
            var imagepath = Path.Combine(folderpath, ImageName);
            FileStream fs = new FileStream(imagepath, FileMode.Create);
            testimonial.Photo.CopyTo(fs);
            fs.Dispose();
            testimonial.Image = ImageName;
            db.tbl_Testimonial.Add(testimonial);
            db.SaveChanges();
            return RedirectToPage("Addtestimonial");
        }
    }
}
