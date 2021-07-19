using AnimalStore2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AnimalStore2.Repository
{
    public class DogRepository : IRepository<Dog>
    {
        private ApplicationDbContext db;

        public DogRepository(ApplicationDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<Dog> GetAll()
        {
            return db.Dogs;
        }


        public Dog Get(int id)
        {
            return db.Dogs.Find(id);
        }

        public void Create(Dog dog)
        {
            db.Dogs.Add(dog);
        }

        public void Update(Dog dog)
        {
            db.Entry(dog).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Dog dog = db.Dogs.Find(id);
            if (dog != null)
                db.Dogs.Remove(dog);
        }
    }
}