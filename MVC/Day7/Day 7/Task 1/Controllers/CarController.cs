using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task_1.Models;

namespace Task_1.Controllers
{
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult getAll()
        {
            List<Car> carLst = CarList.Cars;
            ViewBag.Cars = carLst;
            return View();
        }

        public ActionResult getByID(int id)
        {
            Car car = CarList.Cars.FirstOrDefault(e => e.Num == id);
            ViewBag.selectedCar = car;
            return View();
        }

        public ActionResult editByID(int id)
        {
            Car car = CarList.Cars.FirstOrDefault(e => e.Num == id);
            ViewBag.selectedCar = car;
            return View();
        }

        public ActionResult EditSave(int Num, string Color, string Model, string Manufacture)
        {
            Car editedCar = CarList.Cars.FirstOrDefault(e => e.Num == Num);
            editedCar.Color = Color;
            editedCar.Model = Model;
            editedCar.Manufacture = Manufacture;

            return RedirectToAction("getAll");
        }

        public ActionResult createCar()
        {
            return View();
        }

        public ActionResult CreateSave(int Num, string Color, string Model, string Manufacture)
        {
            Car car = new Car();
            car.Num = Num;
            car.Color = Color;
            car.Model = Model;
            car.Manufacture = Manufacture;

            CarList.Cars.Add(car);
            return RedirectToAction("getAll");
        }

        public ActionResult deleteByID(int id)
        {
            var deletedCar = CarList.Cars.FirstOrDefault(e => e.Num == id);
            CarList.Cars.Remove(deletedCar);
            return RedirectToAction("getAll");
        }
    }
}
