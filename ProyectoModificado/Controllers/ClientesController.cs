using Microsoft.AspNetCore.Mvc;
using ProyectoModificado.Models;
using System.Diagnostics;

using Microsoft.AspNetCore.Authorization;
using ProyectoModificado.Datos;

namespace ProyectoModificado.Controllers
{
    [Authorize]
    public class ClientesController : Controller
    {

        ClientesDatos _ClientesDatos = new ClientesDatos();
        public IActionResult Listar()
        {
            var oLista = _ClientesDatos.Listar();
            return View(oLista);
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
