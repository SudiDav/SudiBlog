using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SudiBlog.Data;
using SudiBlog.Enums;
using SudiBlog.Models;
using SudiBlog.Services;
using SudiBlog.ViewModels;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace SudiBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogEmailSender _emailSender;
        private readonly ApplicationDbContext _dbContext;
        public HomeController(ILogger<HomeController> logger, IBlogEmailSender emailSender, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _emailSender = emailSender;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 5;

            var blogs = _dbContext.Blogs.Include(b => b.BlogUser).Where(b => b.Posts
               .Any(p => p.ReadyStatus == ReadyStatus.ProductionReady))
                .OrderByDescending(b => b.Created)
                .ToPagedListAsync(pageNumber, pageSize);


            return View(await blogs);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(ContactMe model)
        {
            model.Message = $"{model.Message} <hr/> Phone: {model.Phone}";
            await _emailSender.SendContactEmailAsync(model.Email, model.Name, model.Subject, model.Message);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
