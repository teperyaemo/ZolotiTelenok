using Microsoft.AspNetCore.Mvc;

namespace ZolotiTelenok.Controllers
{
    public class SupportController : Controller
    {
        private readonly EmailService _emailService;

        public SupportController(EmailService emailService)
        {
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string name, string lastname, string username, string email, string message)
        {
            string send;
            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(lastname) && !string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(message))
            {
                if (!string.IsNullOrWhiteSpace(email))
                {
                    send = $"Обращение от {lastname} {name}. {message}. Телеграм: @{username} . Почта: {email} .";
                    Notificate(send);
                }
                else
                {
                    send = $"Обращение от {lastname} {name}. {message}. Телеграм: @{username} .";
                    Notificate(send);
                }
            }

            return Inv;
        }


        public IActionResult Notificate(string message)
        {
            _emailService.SendEmail("Gabahadlion@gmail.com", "Техподдержка", message);
            return RedirectToAction("Index");
        }
    }
}
