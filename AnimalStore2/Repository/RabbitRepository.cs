using AnimalStore2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AnimalStore2.Repository
{
    public class RabbitRepository : IRepository<Rabbit>
    {
        private ApplicationDbContext db;

        public RabbitRepository(ApplicationDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<Rabbit> GetAll()
        {
            return db.Rabbits;
        }

        public Rabbit Get(int id)
        {
            return db.Rabbits.Find(id);
        }

        public void Create(Rabbit rabbit)
        {
            db.Rabbits.Add(rabbit);
        }

        public void Update(Rabbit rabbit)
        {
            db.Entry(rabbit).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Rabbit rabbit = db.Rabbits.Find(id);
            if (rabbit != null)
                db.Rabbits.Remove(rabbit);
        }
    }
}