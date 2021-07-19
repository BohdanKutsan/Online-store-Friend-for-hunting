using AnimalStore2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AnimalStore2.Repository
{
    public class OrderRepository : IRepository<Order>
    {
        private ApplicationDbContext db;

        public OrderRepository(ApplicationDbContext context)
        {
            this.db = context;
        }
        //
       
        public IEnumerable<Order> GetAll()
        {
            return db.Orders;
        }

        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }

        public void Create(Order order)
        {
            db.Orders.Add(order);
        }

        public void Update(Order order)
        {
            db.Entry(order).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Order order = db.Orders.Find(id);
            if (order != null)
                db.Orders.Remove(order);
        }
    }
}