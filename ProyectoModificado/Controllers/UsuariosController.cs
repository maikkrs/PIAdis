using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ProyectoModificado.Datos;
using ProyectoModificado.Models;
using ProyectoModificado.Models.Union;


namespace ProyectoModificado.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        UsuariosDatos _DatosProd = new UsuariosDatos();
        public IActionResult Listar()
        {
           var x = _DatosProd.Listar();

            return View(x);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(Usuario oProductos)
        {
            var respuesta = _DatosProd.Guardar(oProductos);

            if (respuesta == true)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int idProducto)
        {
            var oproducto = _DatosProd.Obtener(idProducto);
            return View(oproducto);
        }

        [HttpPost]
        public IActionResult Editar(Usuario oProductos, string conActual)
        {
            if (oProductos.upass2 == conActual)
            {
                var respuesta = _DatosProd.Editar(oProductos);

                if (respuesta == true)
                    return RedirectToAction("Listar");
                else
                    return View();
            }
            else
            {
                oProductos.upass = conActual;
                oProductos.upass2 = "Contraseña incorrecta";
                return View(oProductos);
            }

           
           
        }

        public IActionResult Eliminar(int idProducto)
        {
            var oproducto = _DatosProd.Obtener(idProducto);
            return View(oproducto);
        }

        [HttpPost]
        public IActionResult Eliminar(Usuario oProductos, string conActual)
        {
            if (oProductos.upass==conActual)
            {
                var respuesta = _DatosProd.Eliminar(oProductos.uid);

                if (respuesta == true)
                    return RedirectToAction("Listar");
                else
                    return View();
            }
            else
            {
                oProductos.upass = conActual;
                oProductos.upass2 = "Contraseña incorrecta";
                return View(oProductos);
            }

            
        }


    }

}