using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CmsApplication.Areas.Panel.Models;
using CmsApplication.Data;
using SmartBreadcrumbs.Attributes;
using Core.Flash;

namespace CmsApplication.Areas.Panel.Controllers
{
    [Area("Panel")]
    public class ConfigsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IFlasher _f;

        public ConfigsController(ApplicationDbContext context, IFlasher flahser)
        {
            _context = context;
            _f = flahser;
        }

        // GET: Panel/Configs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Config.ToListAsync());
        }

        // GET: Panel/Configs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Panel/Configs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Title,Value")] Config config)
        {
            if (ModelState.IsValid)
            {
                config.CreateAt = DateTime.Now;
                _context.Add(config);
                await _context.SaveChangesAsync();

                _f.Flash(Types.Success, "İşlem Başarıyla Gerçekleştirildi");
                return RedirectToAction(nameof(Index));
            }

            return View(config);
        }

        // GET: Panel/Configs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var config = await _context.Config.FindAsync(id);
            if (config == null)
            {
                return NotFound();
            }
            return View(config);
        }

        // POST: Panel/Configs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Title,Value")] Config config)
        {
            if (id != config.Id)
            {
                return NotFound();
            }

            ModelState.Remove("CreateAt");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(config);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfigExists(config.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                _f.Flash(Types.Success, "İşlem Başarıyla Gerçekleştirildi");
                return RedirectToAction(nameof(Index));
            }
            return View(config);
        }

        // POST: Panel/Configs/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var config = await _context.Config.FindAsync(id);
            _context.Config.Remove(config);
            await _context.SaveChangesAsync();

            _f.Flash(Types.Success, "İşlem Başarıyla Gerçekleştirildi");
            return RedirectToAction(nameof(Index));
        }

        private bool ConfigExists(int id)
        {
            return _context.Config.Any(e => e.Id == id);
        }
    }
}
