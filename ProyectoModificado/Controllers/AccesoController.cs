using Microsoft.AspNetCore.Mvc;
using ProyectoModificado.Models;
using ProyectoModificado.Datos;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;


namespace ProyectoModificado.Controllers
{
    public class AccesoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Usuario _usuario)
        {
            DA_logica _da_usuario = new DA_logica();
            var usuario = _da_usuario.ValidarUsuario(_usuario.umail, _usuario.upass);
            if (usuario.upass == _usuario.upass)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.umail),
                };

                var ClaimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(ClaimsIdentity));

                return RedirectToAction("Listar", "Productos");
            }
            else
            {
                return RedirectToAction("Index", "Acceso");
            }

            
        }

        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Acceso");

        }
    }
}
