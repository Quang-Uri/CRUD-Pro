using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Web_Pro.Entities;

namespace Web_Pro.Controllers
{
    public class THXController : Controller
    {
        private readonly ILogger<THXController> _logger;
        private readonly LocationDbContext _context;

        public THXController(ILogger<THXController> logger, LocationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, string type)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (type == "Tinh")
                    {
                        // Tìm và xóa tất cả các bản ghi liên quan trong bảng Huyen
                        var huyenRecords = _context.Huyens.Where(h => h.MaT == id).ToList();
                        // Xóa tất cả các bản ghi Xa liên quan
                        foreach (var huyen in huyenRecords)
                        {
                            var xaRecords = _context.Xas.Where(x => x.MaH == huyen.MaH).ToList();
                            _context.Xas.RemoveRange(xaRecords);
                        }

                        // Xóa bản ghi Huyen
                        _context.Huyens.RemoveRange(huyenRecords);

                        // Xóa bản ghi Tinh
                        var tinhRecord = await _context.Tinhs.FindAsync(id);
                        if (tinhRecord != null)
                        {
                            _context.Tinhs.Remove(tinhRecord);
                        }
                    }
                    else if (type == "Huyen")
                    {
                        // Tìm và xóa tất cả các bản ghi Xa liên quan
                        var xaRecords = _context.Xas.Where(x => x.MaH == id).ToList();
                        _context.Xas.RemoveRange(xaRecords);

                        // Xóa bản ghi Huyen
                        var huyenRecord = await _context.Huyens.FindAsync(id);
                        if (huyenRecord != null)
                        {
                            _context.Huyens.Remove(huyenRecord);
                        }
                    }
                    else if (type == "Xa")
                    {
                        // Xóa bản ghi Xa
                        var xaRecord = await _context.Xas.FindAsync(id);
                        if (xaRecord != null)
                        {
                            _context.Xas.Remove(xaRecord);
                        }
                    }

                    // Lưu thay đổi
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    // Xử lý lỗi nếu cần
                    return View("Error");
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var data = _context.Xas.ToList();
            ViewData["Huyen"] = _context.Huyens.ToList();
            ViewData["Tinh"] = _context.Tinhs.ToList();
            ViewData["Xa"] = _context.Xas.ToList();
            return View(data);
        }
    }
}

