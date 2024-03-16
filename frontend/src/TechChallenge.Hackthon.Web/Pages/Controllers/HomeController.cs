using Microsoft.AspNetCore.Mvc;
using TechChallenge.Pages.Model;

namespace TechChallenge.Hackthon.Web.Pages.Controllers
{
    public class HomeController : Controller
    {
        // 
        // GET: /HelloWorld/
        public IActionResult Index()
        {
            
            var viewModel = new ListaDeProcessamentosViewModel();      

            // Passa a viewModel para a view
            return View(viewModel);
        }
        // 
        // GET: /HelloWorld/Welcome/ 
        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}
