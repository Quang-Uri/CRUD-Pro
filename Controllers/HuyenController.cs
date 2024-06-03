using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Web_Pro.Entities;

namespace Web_CRUD.Controllers
{
    public class HuyenController : Controller
    {
        private readonly LocationDbContext _context;

        public HuyenController(LocationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Huyens.ToList();
            ViewData["Tinh"] = _context.Tinhs.ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Huyen model)
        {
            if (ModelState.IsValid)
            {
                Huyen newItem = new Huyen()
                {
                    MaT = model.MaT,
                    MaH = model.MaH,
                    Ten = model.Ten,
                    Cap = model.Cap
                };
                _context.Huyens.Add(newItem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var data = _context.Huyens.FirstOrDefault(x => x.MaH == id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edited(Huyen model)
        {
            if (ModelState.IsValid)
            {
                var data = _context.Huyens.FirstOrDefault(x => x.MaH == model.MaH);
                data.MaT = model.MaT;
                data.Ten = model.Ten;
                data.Cap = model.Cap;
                _context.Huyens.Update(data);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var data = _context.Huyens.FirstOrDefault(x => x.MaH == id);
            if (data != null)
            {
                _context.Huyens.Remove(data);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
