using Microsoft.AspNetCore.Mvc;
using PenielBikeControle.Utils;

namespace PenielBikeControle.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CadastroConta()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> CadastrarConta()
        {
            try
            {
                
                return ControllerUtils.RetornoJsonResult(true, "Conta criada com sucesso!");
            }
            catch (Exception ex)
            {
                return ControllerUtils.RetornoJsonResult(false, ex.Message);
            }
        }
    }
}