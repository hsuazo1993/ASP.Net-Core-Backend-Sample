using BusinessLogic;
using DataAccess.Utils;
using DTOs;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class FruitsBLTests
    {
        private IBLFruit _bLFruit;
        [SetUp]
        public void SetUp()
        {
            _bLFruit = new BLFruit();
        }


        [Test]
        public void ValidateFruitIsNotNull()
        {
            FruitDTO fruitDTO = null;
            string msg = string.Empty;
            bool fruitIsValid = _bLFruit.IsFruitValid(fruitDTO, out msg);


            Assert.That(fruitIsValid, Is.EqualTo(false));
            Assert.That(msg, Is.EqualTo("Fruit information not provided"));
        }

        [Test]
        public void ValidateFruitNameIsNotEmpty()
        {
            FruitDTO fruitDTO = new FruitDTO() 
            { 
                Name = "",
                Description = "Papaya is a delicious tropical fruit.",
                TypeId = (int)FruitTypes.TropicalAndExotic
            };
            string msg = string.Empty;
            bool fruitIsValid = _bLFruit.IsFruitValid(fruitDTO, out msg);


            Assert.That(fruitIsValid, Is.EqualTo(false));
            Assert.That(msg, Is.EqualTo("Fruit name is not valid"));
        }

        [Test]
        public void ValidateFruitDescriptionIsNotEmpty()
        {
            FruitDTO fruitDTO = new FruitDTO()
            {
                Name = "Papaya",
                Description = "",
                TypeId = (int)FruitTypes.TropicalAndExotic
            };
            string msg = string.Empty;
            bool fruitIsValid = _bLFruit.IsFruitValid(fruitDTO, out msg);


            Assert.That(fruitIsValid, Is.EqualTo(false));
            Assert.That(msg, Is.EqualTo("Fruit description is not valid"));
        }

        [Test]
        public void ValidateFruitTypeIsValid()
        {
            FruitDTO fruitDTO = new FruitDTO()
            {
                Name = "Papaya",
                Description = "",
                TypeId = default
            };
            string msg = string.Empty;
            bool fruitIsValid = _bLFruit.IsFruitValid(fruitDTO, out msg);


            Assert.That(fruitIsValid, Is.EqualTo(false));
            Assert.That(msg, Is.EqualTo("Fruit type is not valid"));
        }

        [Test]
        public void ValidateFruitDescriptionIsAtLeast25CharactersLong()
        {
            FruitDTO fruitDTO = new FruitDTO()
            {
                Name = "Papaya",
                Description = "Papaya",
                TypeId = (int)FruitTypes.TropicalAndExotic
            };
            string msg = string.Empty;
            bool fruitIsValid = _bLFruit.IsFruitValid(fruitDTO, out msg);


            Assert.That(fruitIsValid, Is.EqualTo(false));
            Assert.That(msg, Is.EqualTo("Fruit description must be at least 25 characters long"));
        }
    }
}
