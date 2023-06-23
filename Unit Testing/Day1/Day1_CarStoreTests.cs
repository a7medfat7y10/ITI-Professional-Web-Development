using CarsApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAppTests
{
    [TestClass]
    public class CarStoreLabTests
    {
        #region Collection Assert
        [TestMethod]
        public void GetAllStoreCars_AddCar_Contains()
        {
            var  c1 = new Car();
            var  c2 = new Car();
            var carStore = new CarStore(new List<Car> { c1, c2 });

            var cars = carStore.GetAllStoreCars();
            CollectionAssert.Contains(cars, c1);
        }

        [TestMethod]
        public void GetAllStoreCars_TwoInstancesSameTypes_AllItemsAreInstancesOfType()
        {
            var c1 = new Car();
            var c2 = new Car();
            var carStore = new CarStore(new List<Car> { c1, c2 });

            var cars = carStore.GetAllStoreCars();
            CollectionAssert.AllItemsAreInstancesOfType(cars, typeof(Car));
        }
        #endregion
    }
}
