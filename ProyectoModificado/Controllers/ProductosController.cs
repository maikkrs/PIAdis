using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ProyectoModificado.Datos;
using ProyectoModificado.Models;


namespace ProyectoModificado.Controllers
{
    [Authorize]
    public class ProductosController : Controller
    {
        DatosProd _DatosProd = new DatosProd();
        public IActionResult Listar()
        {
            var oLista = _DatosProd.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(Productos oProductos)
        {
            var respuesta = _DatosProd.Guardar(oProductos);

            if (respuesta == true)
                return RedirectToAction("Listar");
            else
                return View("~/Views/Productos/ListarProductos.cshtml");
        }

        public IActionResult Editar(int idProducto)
            {
            var oproducto = _DatosProd.Obtener(idProducto);
            return View(oproducto);
        }

        [HttpPost]
        public IActionResult Editar(Productos oProductos)
        {
            var respuesta = _DatosProd.Editar(oProductos);

            if (respuesta == true)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int idProducto)
        {
            var oproducto = _DatosProd.Obtener(idProducto);
            return View(oproducto);
        }

        [HttpPost]
        public IActionResult Eliminar(Productos oProductos)
        {
            var respuesta = _DatosProd.Eliminar(oProductos.Id);

            if (respuesta == true)
                return RedirectToAction("Listar");
            else
                return View("~/Views/Productos/ListarProductos.cshtml");
        }


    }

}