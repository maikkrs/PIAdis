using ProyectoModificado.Models;


namespace ProyectoModificado.Models.Union
{
    public class Class
    {
        public IEnumerable<Productos> p1 { get; set; }
        public IEnumerable<ProductosFaltaModels> p2 { get; set; }
    }
}
