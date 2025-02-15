using Microsoft.AspNetCore.Mvc;
using PenielBikeControle.Utils;

namespace PenielBikeControle.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Logar(string usuario, string senha)
        {
            try
            {
                
                return RedirectToAction("Index", "Home");
               
            }
            catch (Exception ex)
            {
                return ControllerUtils.RetornoJsonResult(ex);
            }
        }
    }
}
