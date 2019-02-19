using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using Domain.Entities;

namespace WebUI.Controllers
{
    public class AdminController : Controller
    {
        private ICarRepository repository;

        public AdminController(ICarRepository repo)
        {
            repository = repo;
        }


        //
        // GET: /Admin/
        public ActionResult Index()
        {
            return View(repository.Cars);
        }

        public ActionResult Edit(int id)
        {
            Car car = repository.Cars.FirstOrDefault(c => c.Id == id);
            return View(car);
        }

        [HttpPost]
        public ActionResult Edit(Car car, HttpPostedFileBase image)
        {
            if (ModelState.IsValid == true)
            {
                if (image != null)
                {
                    car.ImageMimeType = image.ContentType;
                    car.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(car.ImageData, 0, image.ContentLength);
                }

                
                repository.SaveCar(car);
                TempData["message"] = string.Format("Zapisano pojazd {0} {1}",
                            car.Brand, car.Model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(car);  //Return when error
            }
        }


        public ViewResult Create()
        {
            Car car = new Car();
            return View("Edit", car);
        }

        
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            Car deletedCar = repository.DeleteCar(Id);
            
            /*if (deletedCar != null)
            {
                TempData["message"] = string.Format("Usunięto pojazd {0}", deletedCar);
            }*/

            return RedirectToAction("Index");
        }


       
	}
}