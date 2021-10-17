using CmsApplication.Areas.Panel.Models;
using CmsApplication.Data;
using Core.Flash;
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
        private readonly ApplicationDbContext _context;
        private readonly IFlasher _f;

        public SlidersController(ApplicationDbContext context, IFlasher flahser)
        {
            _context = context;
            _f = flahser;
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
            if (ModelState.IsValid)
            {
                slider.CreateAt = DateTime.Now;
                _context.Add(slider);
                await _context.SaveChangesAsync();

                _f.Flash(Types.Success, "İşlem Başarıyla Gerçekleştirildi");
                return RedirectToAction(nameof(Index));
            }

            return View(slider);
        }
    }
}
