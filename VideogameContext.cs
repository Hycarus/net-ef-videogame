using System;
using Microsoft.EntityFrameworkCore;

namespace net_ef_videogame
{
	public class VideogameContext : DbContext
	{
		public DbSet<Videogame> Videogames { get; set; }
		public DbSet<SoftwareHouse> SoftwareHouses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
			optionsBuilder.UseSqlServer("Data Source=localhost,1433;Database=videogames2_db;User Id=sa;Password=dockerStrongPwd123;TrustServerCertificate=True");
        }
	}
}

