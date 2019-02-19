using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Concrete
{
    public class EFCarRepository : ICarRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Car> Cars
        {
            get { return context.Cars; }
        }

        public void SaveCar(Car car)
        {
            if (car.Id == 0)
            {
                context.Cars.Add(car);
            }
            else
            {
                Car dbEntry = context.Cars.Find(car.Id);
                if (dbEntry != null)
                {
                    dbEntry.Brand = car.Brand;
                    dbEntry.Model = car.Model;
                    dbEntry.ManufactDate = car.ManufactDate;
                    dbEntry.EngineCapacity = car.EngineCapacity;
                    dbEntry.Type = car.Type;
                    dbEntry.Price = car.Price;
                    dbEntry.Description = car.Description;
                    dbEntry.EngineType = car.EngineType;

                    dbEntry.ImageMimeType = car.ImageMimeType;
                    dbEntry.ImageData = car.ImageData;
                }
            }

            context.SaveChanges();
        }


        public Car DeleteCar(int carId)
        {
            Car dbEntry = context.Cars.Find(carId);
            if (dbEntry != null)
            {
                context.Cars.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }

    }
}
