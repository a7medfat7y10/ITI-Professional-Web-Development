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
    public class CarLabTests
    {
        #region Exception
        [ExpectedException(typeof(NotImplementedException))]
        [TestMethod]
        public void Brake_CarFord_ThrowException()
        {
            var car = new Car()
            {
                Type = CarType.Ford
            };
            car.Brake();
        }
        #endregion


        #region Assert
        //1
        [TestCategory("Equality")]
        [TestMethod]
        public void Brake_CarMercedes_DecreaseVelocityWith20()
        {
            var car = new Car()
            {
                Type = CarType.Mercedes,
                Velocity = 20
            };
            car.Brake();
            Assert.AreEqual(0, car.Velocity);
        }

        //2
        [TestCategory("Equivalence")]
        [TestMethod]
        public void TwoCars_SameInstancesSameState_NotSame()
        {
            Car car1 = new Car(CarType.Mercedes, 150, DrivingMode.Reverse);
            Car car2 = new Car(CarType.Mercedes, 150, DrivingMode.Reverse);

            // Assert
            Assert.AreNotSame(car1, car2);
        }

        //3
        [TestMethod]
        public void IsStopped_Velocity0_True()
        {
            var car = new Car()
            {
                Velocity = 0
            };

            var result = car.IsStopped();

            Assert.IsTrue(result);
        }

        //4
        [TestMethod]
        public void GetMyCar_ExistingInstance_IsCarType()
        {
            // Arrange
            var car = new Car();

            // Act
            var actualCar = car.GetMyCar();

            // Assert
            Assert.IsInstanceOfType(actualCar, typeof(Car));
        }
        #endregion

        #region String Assert
        [TestMethod]
        public void GetDirection_Reverse_PrintReverse()
        {
            var car = new Car()
            {
                DrivingMode = DrivingMode.Reverse
            };

            var direction = car.GetDirection();

            StringAssert.Matches(direction, new System.Text.RegularExpressions.Regex("Reverse"));
        }

        public void GetDirection_Stopped_PrintStopped()
        {
            var car = new Car()
            {
                DrivingMode = DrivingMode.Stopped
            };

            var direction = car.GetDirection();

            StringAssert.Matches(direction, new System.Text.RegularExpressions.Regex("Stopped"));
        }
        #endregion


    }
}
