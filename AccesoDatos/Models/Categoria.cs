using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Libro>Libros { get; set; } = new List<Libro>();
    }
}
