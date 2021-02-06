using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{Id=1, BrandId=1, ColorId=1, ModelYear=2015, DailyPrice=220, Description="Supra Coupe 2.0"},
                new Car{Id=2, BrandId=1, ColorId=2, ModelYear=2020, DailyPrice=290, Description="Corolla Sedan 1.8"},
                new Car{Id=3, BrandId=2, ColorId=3, ModelYear=2018, DailyPrice=230, Description="Accent Sedan 1.6"},
                new Car{Id=4, BrandId=3, ColorId=1, ModelYear=2019, DailyPrice=280, Description="A 35 AMG Hatchback 2.0"},
                new Car{Id=5, BrandId=3, ColorId=2, ModelYear=2020, DailyPrice=270, Description="A 180 CDI Sedan 1.5"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.Id == car.Id);   // burada LİNQ uygulaması yapıldı
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Description = car.Description;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
        }
        public List<Car> GetAllByBrand(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
