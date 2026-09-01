using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Repositories
{
    internal interface IGenericRepository
    {
		public interface IGenericRepository<T> where T : class
		{
			void Agregar(T entidad);
			List<T> ObtenerTodos();
			T ObtenerPorId(int id);
			void Eliminar(object id);
			void Modificar(T entidad);
		}
	}
}
