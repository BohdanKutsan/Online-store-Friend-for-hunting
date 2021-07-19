using AnimalStore2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalStore2.Repository
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private AnimalRepository animalRepository;
        private DogRepository dogRepository;
        private OrderRepository orderRepository;

        public AnimalRepository Animals
        {
            get
            {
                if (animalRepository == null)
                    animalRepository = new AnimalRepository(db);
                return animalRepository;
            }
        }

        public DogRepository Dogs
        {
            get
            {
                if (dogRepository == null)
                    dogRepository = new DogRepository(db);
                return dogRepository;
            }
        }

        public OrderRepository Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}