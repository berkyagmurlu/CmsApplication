using CmsApplication.Areas.Panel.Models;
using CmsApplication.Data;
using Core.Flash;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CmsApplication.Areas.Panel.Controllers
{
    [Area("Panel")]
    public class SlidersController : Controller
    {
        private string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };

        private readonly ApplicationDbContext _context;
        private readonly IFlasher _f;
        private IWebHostEnvironment _webHostEnvironment;

        public SlidersController(ApplicationDbContext context, IFlasher flahser, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _f = flahser;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Slider.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider, IFormFile sliderFile)
        {
            if (sliderFile.Length > 0)
            {
                // Generate File Name 
                // GUID
                // Path.GetRandomFileName (Without Extension)

                var extension = Path.GetExtension(sliderFile.FileName).ToLowerInvariant();
                if (!this.allowedExtensions.Contains(extension))
                {
                    _f.Flash(Types.Danger, "Lütfen uygun dosya formatını seçiniz.");
                    return View();
                }
                
                string fileName = Guid.NewGuid().ToString() + extension;

                // Create Upload Directory
                var path = Path.Combine(this._webHostEnvironment.WebRootPath, "uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                // New File Stream Save File As Path.Combine
                var stream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
                sliderFile.CopyToAsync(stream);

                slider.FileName = fileName;
                slider.CreateAt = DateTime.Now;
                _context.Add(slider);
                await _context.SaveChangesAsync();

                _f.Flash(Types.Success, "İşlem Başarıyla Gerçekleştirildi");
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _f.Flash(Types.Danger, "Lütfen dosya seçimi yapınız.");
            }

            return View(slider);
        }
    }
}
