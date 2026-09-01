using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using AccesoDatos.Models;

namespace AccesoDatos.Data
{
    public class AplicationDbContext:DbContext
    {
	public DbSet <Autor> Autor { get; set; }
	public DbSet <Libro> Libro{ get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite("Data Source=C:\\databases\\BaseDeDatps.db");
	}
	
	}
}
