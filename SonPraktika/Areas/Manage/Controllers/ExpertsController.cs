using Microsoft.AspNetCore.Mvc;
using SonPraktika.Models;
using Microsoft.AspNetCore;
using SonPraktika.DAL;

namespace SonPraktika.Areas.Manage.Controllers
{
    [Area("Manage")]

    public class ExpertsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ExpertsController(AppDbContext context,IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }
   

        public IActionResult Index()
        {
           var experts=_context.experts.ToList();
            return View(experts);
        }


        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Experts experts)
        {
            if (!ModelState.IsValid) return View();
            if (!experts.ImgFile.ContentType.Contains("image/")) return View(experts);

            string path = _hostEnvironment.WebRootPath+@"/upload/";

            string fileame = Guid.NewGuid().ToString() + experts.ImgFile.FileName;

            using (FileStream stream = new FileStream(Path.Combine(path, fileame), FileMode.Create))
            {
                await experts.ImgFile.CopyToAsync(stream);
            }

            experts.PhotoUrl= fileame;
            await _context.experts.AddAsync(experts);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var exper=_context.experts.FirstOrDefault(x=>x.Id==id);
            _context.experts.Remove(exper);
            _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
