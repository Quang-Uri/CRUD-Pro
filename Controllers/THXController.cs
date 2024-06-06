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

        //public IActionResult Index()
        //{
        //    var listOfTinhs = _context.Tinhs.ToList();
        //    var listOfHuyens = _context.Huyens.ToList();

        //    var model = new Tuple<IEnumerable<Web_Pro.Entities.Tinh>, IEnumerable<Web_Pro.Entities.Huyen>>(listOfTinhs, listOfHuyens);

        //    return View(model);
        //}

        //public IActionResult Index()
        //{
        //    var data = _context.Huyens.ToList();
        //    ViewData["Tinh"] = _context.Tinhs.ToList();
        //    return View(data);
        //}

        public IActionResult Index()
        {
            var data = _context.Xas.ToList();
            ViewData["Huyen"] = _context.Huyens.ToList();
            ViewData["Tinh"] = _context.Tinhs.ToList();
            return View(data);
        }
    }
}
