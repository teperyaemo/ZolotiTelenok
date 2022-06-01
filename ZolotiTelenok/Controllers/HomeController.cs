using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ZolotiTelenok.Models;

namespace ZolotiTelenok.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmailService _emailService;
        private readonly ZTDBContext _context;

        public HomeController(ZTDBContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("ИдКлиента,Фамилия,Имя,Время,Телефон")] Клиент клиент)
        {
            if (ModelState.IsValid)
            {
                Notificate((клиент.Время).ToString(), клиент.Фамилия, клиент.Имя, клиент.Телефон);
                _context.Клиентs.Add(клиент);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(клиент);
        }


        public IActionResult Notificate(string time, string surname, string name, string phone)
        {
            _emailService.SendEmail("Gabahadlion@gmail.com", "Новый клиент", $"На время: {time} записан {surname} {name}. Телефон: {phone}");
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}