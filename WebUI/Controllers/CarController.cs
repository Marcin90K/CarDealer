using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;
using Domain.Abstract;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CarController : Controller
    {
        private ICarRepository repository;
        public int PageSize = 3;

        public CarController(ICarRepository carRepository)
        {
            repository = carRepository;
        }

        //
        // GET: /Car/
        public ViewResult List(string carType, int page = 1)
        {
            CarListViewModel model = new CarListViewModel
            {
                Cars = repository.Cars
                .Where(c => carType == null || c.Type == carType )
                .OrderBy(c => c.Id)
                .Skip(PageSize * (page - 1))
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = carType == null ?
                    repository.Cars.Count() : repository.Cars.Where(c => c.Type == carType).Count()
                },
                CarType = carType
            };

            return View(model);
        }

        [HttpPost]
        public ViewResult Search(string brand, string model, int? manufactDateMin,
            int? manufactDateMax, int? priceMin, int? priceMax, int? engineCapMin,
            int? engineCapMax, string engineType, int page = 1)
        {

            IEnumerable<Car> foundItems = repository.Cars
                .Where(c => (brand == "" || c.Brand == brand) &&
                (model == "" || c.Model == model) &&
                ((manufactDateMin == null || manufactDateMax == null || (c.ManufactDate.Year >= manufactDateMin) && (c.ManufactDate.Year < manufactDateMax)) &&
                (priceMin == null || priceMax == null || (c.Price >= priceMin) && (c.Price < priceMax))) &&
                (engineCapMin == null || engineCapMax == null || (c.EngineCapacity >= engineCapMin) && (c.EngineCapacity < engineCapMax)) &&
                (engineType == "" || c.EngineType == engineType));
              

            CarListViewModel VMmodel = new CarListViewModel
            {
                Cars = foundItems,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = foundItems.Count(),
                },
                CarType = null
            };

            return View("List", VMmodel);
        }


        public FileContentResult GetImage(int Id)
        {
            Car car = repository.Cars.FirstOrDefault(c => c.Id == Id);
            if (car != null)
            {
                return File(car.ImageData, car.ImageMimeType);
            }
            else
            {
                return null;
            }
        }


        public ViewResult CarDetails(int Id)
        {
            Car car = repository.Cars.FirstOrDefault(c => c.Id == Id);

            return View(car);
        }


        public ViewResult SearchForm()
        {
            return View();
        }

        
       
	}
}