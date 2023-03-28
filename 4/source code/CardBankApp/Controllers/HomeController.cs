using CardBankApp.DBContext;
using CardBankApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CardBankApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			var bank = CBankDAO.ExecuteDatatable("SELECT * FROM Bank WITH(NOLOCK)");

			return View(bank);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

    }
}