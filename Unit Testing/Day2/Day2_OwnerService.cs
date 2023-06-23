using CarAPI.Entities;
using CarAPI.Models;
using CarAPI.Payment;
using CarAPI.Repositories_DAL;
using CarAPI.Services_BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAPITests
{
    [TestClass]
    public class OwnerServiceLab
    {
        private static Mock<IOwnersRepository> _ownersRepositoryMock;
        private static Mock<ICarsRepository> _carsRepositoryMock;
        private static Mock<IPaymentService> _paymentServiceMock;
        private static OwnersService _ownersService;

        [ClassInitialize]
        public static void CreateOwnerService(TestContext context) {
            _ownersRepositoryMock = new Mock<IOwnersRepository>();
            _carsRepositoryMock = new Mock<ICarsRepository>();
            _paymentServiceMock = new Mock<IPaymentService>();
            _ownersService = new OwnersService(_ownersRepositoryMock.Object, _carsRepositoryMock.Object, _paymentServiceMock.Object);
        }

        [TestMethod]
        public void AddOwner_Added_True_Mocking()
        {
            var owner = new Owner(1, "Ahmed");
            _ownersRepositoryMock.Setup(o => o.AddOwner(owner)).Returns(true);

            //var expected = true;

            var result = _ownersService.AddOwner(owner);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void BuyCar_SoldCarId1Owner1_NotSold_Mocking()
        {
            var input = new BuyCarInput()
            {
                Amount = 200,
                CarId = 1,
                OwnerId = 1
            };

            var car = new Car(input.CarId, CarType.BMW, 0);
            _carsRepositoryMock.Setup(m => m.GetCarById(input.CarId)).Returns(car);

            var expected = "Owner doesn't exist";

            // Act
            var result = _ownersService.BuyCar(input);

            // Assert
            StringAssert.Contains(result, expected);
        }

        [TestMethod]
        public void GetById_FundOwnerId1_Found_Mocking()
        {
            var owner = new Owner()
            {
                Id = 1,
                Name = "Taha"
            };

            _ownersRepositoryMock.Setup(o => o.GetOwnerById(owner.Id)).Returns(owner);

            var result = _ownersService.GetById(owner.Id);

            Assert.AreEqual(result, owner);
        }
    }
}
