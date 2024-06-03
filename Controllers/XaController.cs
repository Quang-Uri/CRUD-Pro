using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Web_Pro.Entities;

namespace Web_CRUD.Controllers
{
    public class XaController : Controller
    {
        private readonly LocationDbContext _context;

        public XaController(LocationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Xas.ToList();
            ViewData["Huyen"] = _context.Huyens.ToList();
            ViewData["Tinh"] = _context.Tinhs.ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Xa model)
        {
            if (ModelState.IsValid)
            {
                Xa newItem = new Xa()
                {
                    MaH = model.MaH,
                    MaX = model.MaX,
                    Ten = model.Ten,
                    Cap = model.Cap
                };
                _context.Xas.Add(newItem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var data = _context.Xas.FirstOrDefault(x => x.MaX == id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edited(Xa model)
        {
            if (ModelState.IsValid)
            {
                var data = _context.Xas.FirstOrDefault(x => x.MaX == model.MaX);
                data.MaH = model.MaH;
                data.Ten = model.Ten;
                data.Cap = model.Cap;
                _context.Xas.Update(data);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var data = _context.Xas.FirstOrDefault(x => x.MaX == id);
            if (data != null)
            {
                _context.Xas.Remove(data);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
