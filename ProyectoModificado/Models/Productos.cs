using System.Collections.Generic;

namespace ProyectoModificado.Models
{
    public class Productos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public int Precio { get; set; }

        public int Stock { get; set; }
    }
}
