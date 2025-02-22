using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PenielBikeControle.Models;
using PenielBikeControle.Models.ViewModels;
using PenielBikeControle.Utils;

namespace PenielBikeControle.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;

        public UsuariosController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Cadastro(CadastroUsuarioViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new Usuario
                    {
                        UserName = model.Login,
                        Email = model.Email,
                        DataCadastro = DateTime.Now
                    };
                    var result = await _userManager.CreateAsync(user, model.Senha);

                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: true);
                        return ControllerUtils.RetornoJsonResult(true, "Cadastro de usu�rio realizado com sucesso!");
                    }

                    // Adiciona os erros de Identity ao ModelState
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    //return ControllerUtils.RetornoJsonResult(false, "Falha ao realizar cadastro de usu�rio", result.Errors.Select(x => x.Description).ToList());
                }
                //return ControllerUtils.RetornoJsonResult(false, "Falha ao realizar cadastro de usu�rio");
                return View(model);
                
            }
            catch (Exception ex)
            {
                return ControllerUtils.RetornoJsonResult(ex);
            }
        }
    }
}