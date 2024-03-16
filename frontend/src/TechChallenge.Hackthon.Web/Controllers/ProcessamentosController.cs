using Microsoft.AspNetCore.Mvc;
using TechChallenge.Hackthon.Web.Models;

namespace TechChallenge.Hackthon.Web.Controllers
{
    public class ProcessamentosController : Controller
    {

        public IActionResult Detalhes()
        {
            var viewModel = new ListaDeProcessamentosViewModel();            

            return View(viewModel);
        }
    }
}
