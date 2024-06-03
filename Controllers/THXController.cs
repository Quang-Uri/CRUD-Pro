using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        public IActionResult Index()
        {
            return View();
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
