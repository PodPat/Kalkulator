using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.imie = "Anna";
            ViewBag.godzina = DateTime.Now.Hour;
            ViewBag.powitanie = ViewBag.godzina < 17 ? "Dzień dobry" : "dobry wieczor";

            Dane[] osoby =
            {
                new Dane {Name = "Anna", Surname = "Kowalska"},
                new Dane {Name = "Jan", Surname = "Nowak"},
                new Dane {Name = "Mateusz", Surname = "Kowalski"},
            };
            return View(osoby);
        }

        public IActionResult urodziny(Urodziny urodziny) {
            ViewBag.powitanie = $"Witaj {urodziny.Imie} masz {DateTime.Now.Year - urodziny.Rok} lat";
            
            return View();    
            
        }

       
        public IActionResult Kalkulator(Kalkulator kalkulator)
        {

            double a = kalkulator.a;
            double b = kalkulator.b;
            double result = 0;
            string operation = kalkulator.operation;
            string error_message = "";
            if (operation == "+")
            {
                result =  a + b;
                
            }
            else if (operation == "-")
            {
                result = a - b;
            }
            else if(operation == "*")
            {
                    
                result = a * b;
            }
            else if (operation == "/" & b != 0)
            {
                result = a / b;
            }
            else if (operation == "/" & b == 0)
            {
                error_message = "Błąd! Dzielenie przez 0!";
            }
            
            
            ViewBag.Result = result;
            ViewBag.error_message = error_message;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}