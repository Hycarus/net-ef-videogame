using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace net_ef_videogame

{
    [Table("videogames")]
    [Index(nameof(Name), IsUnique = true)]
    public class Videogame
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int SoftwareHouseId { get; set; }
        public SoftwareHouse SoftwareHouse { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Nome: {Name}, Descrizione: {Overview}, Data di rilascio: {ReleaseDate.ToString("dd/MM/yyyy")}";
        }
    }

    [Table("software_house")]
    [Index(nameof(Name), IsUnique = true)]
    public class SoftwareHouse
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }

        public List<Videogame> Videogames { get; set; }
    }

    public class VideogameManager
    {
        public void InsertVideogame(Videogame videogame)
        {
            using (var context = new VideogameContext())
            {
                context.Videogames.Add(videogame);
                context.SaveChanges();
                
            }
        }

        public Videogame GetVideogameById(int id)
        {
            using (var context = new VideogameContext())
            {
                return context.Videogames.Include(x => x.SoftwareHouse).FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Videogame> SearchVideogamesByName(string name)
        {
            using (var context = new VideogameContext())
            {
                return context.Videogames.Where(x => x.Name.Contains(name)).Include(x => x.SoftwareHouse).ToList();
            }
        }

        public void DeleteVideogame(int id)
        {
            using (var context = new VideogameContext())
            {
                var videogame = context.Videogames.Find(id);
                if(videogame != null)
                {
                    context.Videogames.Remove(videogame);
                    context.SaveChanges();
                }
            }
        }

        public void InsertSoftwareHouse(SoftwareHouse softwareHouse)
        {
            using (var context = new VideogameContext())
            {
                context.SoftwareHouses.Add(softwareHouse);
                context.SaveChanges();
            }

        }

        public List<Videogame> GetVideogamesBySoftwarehouseId(int id)
        {
            using(var context = new VideogameContext())
            {
                return context.Videogames.Where(x => x.SoftwareHouseId == id).Include(x => x.SoftwareHouse).ToList();
            }
        }
    }
}