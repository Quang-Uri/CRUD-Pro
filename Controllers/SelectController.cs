using Microsoft.AspNetCore.Mvc;
using Web_Pro.Entities;

namespace Web_Pro.Controllers
{
    public class SelectController : Controller
    {
        private readonly ILogger<SelectController> _logger;
        private readonly LocationDbContext _context;

        public SelectController(ILogger<SelectController> logger, LocationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Xas.ToList();
            ViewData["Huyen"] = _context.Huyens.ToList();
            ViewData["Tinh"] = _context.Tinhs.ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult GetTinhs()
        {
            var tinhs = _context.Tinhs.ToList();
            return Ok(tinhs);
        }

        [HttpGet]
        public IActionResult GetHuyens(int maT)
        {
            var huyens = _context.Huyens.Where(h => h.MaT == maT).ToList();
            return Ok(huyens);
        }

        [HttpGet]
        public IActionResult GetXas(int maH)
        {
            var xas = _context.Xas.Where(x => x.MaH == maH).ToList();
            return Ok(xas);
        }
    }
}
