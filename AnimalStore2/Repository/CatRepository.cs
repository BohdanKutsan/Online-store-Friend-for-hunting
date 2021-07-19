using AnimalStore2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AnimalStore2.Repository
{
    public class CatRepository : IRepository<Cat>
    {
        private ApplicationDbContext db;

        public CatRepository(ApplicationDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<Cat> GetAll()
        {
            return db.Cats;
        }

        public Cat Get(int id)
        {
            return db.Cats.Find(id);
        }

        public void Create(Cat cat)
        {
            db.Cats.Add(cat);
        }

        public void Update(Cat cat)
        {
            db.Entry(cat).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Cat cat = db.Cats.Find(id);
            if (cat != null)
                db.Cats.Remove(cat);
        }
    }
}