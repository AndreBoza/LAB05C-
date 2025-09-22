using System.Collections.Generic;

namespace LAB05_AndreBoza.Models
{
    public partial class Categoria
    {
        public int IdCategoria { get; set; }  // 👈 antes seguro era "object"
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
    }
}