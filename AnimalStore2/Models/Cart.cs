using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalStore2.Models
{
    public class Cart
    {
        private List<Animal> lineCollection = new List<Animal>();

        public List<Animal> CetLine()
        {
            return lineCollection;
        }
        public void AddItem(Dog dog)
        {
            Animal line = lineCollection
                .Where(g => g.AnimalId == dog.AnimalId)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(dog);
            }
    
        }

        public void RemoveLine(Dog dog)
        {
            lineCollection.RemoveAll(l => l.AnimalId == dog.AnimalId);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Price);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public List<Animal> Lines
        {
            get { return lineCollection; }
        }
    }

    
}