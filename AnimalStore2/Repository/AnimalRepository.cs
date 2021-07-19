using AnimalStore2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AnimalStore2.Repository
{
    public class AnimalRepository : IRepository<Animal>
    {
        private ApplicationDbContext db;

        public AnimalRepository(ApplicationDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<Animal> GetAll()
        {
            return db.Animals;
        }

        public Animal Get(int id)
        {
            return db.Animals.Find(id);
        }

        public void Create(Animal animal)
        {
            db.Animals.Add(animal);
        }

        public void Update(Animal animal)
        {
            db.Entry(animal).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Animal animal = db.Animals.Find(id);
            if (animal != null)
                db.Animals.Remove(animal);
        }
    }
}