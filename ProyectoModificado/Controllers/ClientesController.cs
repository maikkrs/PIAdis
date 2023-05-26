using Microsoft.AspNetCore.Mvc;
using ProyectoModificado.Models;
using System.Diagnostics;
using ProyectoModificado.Models.Union;

using Microsoft.AspNetCore.Authorization;
using ProyectoModificado.Datos;

namespace ProyectoModificado.Controllers
{
    [Authorize]
    public class ClientesController : Controller
    {

        ClientesDatos _ClientesDatos = new ClientesDatos();

        
        public IActionResult Listar(string x, string y, string z)
        {

            Class2 c = new Class2();
            c.c1 = _ClientesDatos.Listar();
            c.c2 = _ClientesDatos.Buscar(x, y, z);
            return View(c);
        }


        public IActionResult Buscar(string a, string b, string c)
        {
            var oproducto = _ClientesDatos.Buscar(a, b, c);
            return Listar(a, b, c); 
        }


        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ClientesModels oProductos)
        {
            var respuesta = _ClientesDatos.Guardar(oProductos);

            if (respuesta == true)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int idProducto)
        {
            var oproducto = _ClientesDatos.Obtener(idProducto);
            return View(oproducto);
        }

        [HttpPost]
        public IActionResult Editar(ClientesModels oProductos)
        {
            var respuesta = _ClientesDatos.Editar(oProductos);

            if (respuesta == true)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int idProducto)
        {
            var oproducto = _ClientesDatos.Obtener(idProducto);
            return View(oproducto);
        }

        [HttpPost]
        public IActionResult Eliminar(ClientesModels oProductos)
        {
            var respuesta = _ClientesDatos.Eliminar(oProductos.Id);

            if (respuesta == true)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }
}
