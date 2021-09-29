using BirthdayService;
using BirthdayWishes.Controllers;
using Moq;
using NUnit.Framework;
using System;


namespace BirthdayWishes.Tests.ControllersTests
{
    [TestFixture]
    public class BirthdayControllerTests
    {
        BirthdayController _birthdayController;
        Mock<IBirthdayWishesService> _birthdayWishesService;

        [SetUp]
        public void setup()
        {
            _birthdayWishesService = new Mock<IBirthdayWishesService>();
            _birthdayController = new BirthdayController(_birthdayWishesService.Object);
        }

        [Test]
        public void getEmployeeBirthday_NoWishes_EmptyString()
        {
            _birthdayWishesService.Setup(bs => bs.getEmployeeBirthday()).Returns("");

            var result = _birthdayController.GetBirthdays();
            Assert.That(result, Is.EqualTo(String.Empty));
        }

        [Test]
        public void getEmployeeBirthday_NewWishes_ReturnNewWish()
        {
            _birthdayWishesService.Setup(bs => bs.getEmployeeBirthday()).Returns("Happy birthday Delmer");

            var result = _birthdayController.GetBirthdays();
            Assert.That(result, Is.EqualTo("Happy birthday Delmer"));
        }
    }
}
