using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Models
{
    public class Libro
    {
		public int Id { get; set; }

		public string titulo { get; set; }

        public int aniopublicacion { get; set; }
        
        public int autorId { get; set; }
		public Autor Autor { get; set; } = null!;
	}
}
