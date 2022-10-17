using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp.Test
{
    [TestClass]
    public class GardenTest
    {
        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(int.MaxValue)]
        public void Garden_ValidSize_SizeInit(int validSize)
        {
            //Act
            var garden = new Garden(validSize);

            //Assert
            Assert.AreEqual(validSize, garden.Size);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(int.MinValue)]
        public void Garden_InvalidSize_Exception(int invalidSize)
        {
            //Act
            Action action = () => new Garden(invalidSize);

            //Assert
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(action);
            Assert.AreEqual("size", exception.ParamName);
        }

        [TestMethod]
        public void Plant_Name_True()
        {
            //Arrange
            string name = new Fixture().Create<string>();
            const int VALID_SIZE = 1;
            var garden = new Garden(VALID_SIZE);

            //Act
            var result = garden.Plant(name);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow("", 1)]
        [DataRow("  ", 1)]
        [DataRow(null, 1)]
        [DataRow("a", 0)]
        public void Plant_InvalidName_NotAddedToGarden(string name, int size)
        {
            //Arrange
            var garden = new Garden(size);

            //Act
            bool result;
            try
            {
                result = garden.Plant(name);
            }
            catch
            {
                result = false;
            }

            //Assert
            Assert.IsFalse(result);
            Assert.IsFalse(garden.GetPlants().Contains(name));
        }

        [TestMethod]
        public void Plant_NotEnoughSpace_False()
        {
            //Arrange
            string name = new Fixture().Create<string>();
            const int VALID_SIZE = 0;
            var garden = new Garden(VALID_SIZE);

            //Act
            var result = garden.Plant(name);

            //Assert
            Assert.IsFalse(result);
            //Assert.IsFalse(garden.GetPlants().Contains(name));
        }

        [TestMethod]
        public void Plant_Null_ArgumentNullException()
        {
            //Arrange
            const string NULL_NAME = null;
            const int VALID_SIZE = 0;
            var garden = new Garden(VALID_SIZE);

            //Act
            Action action = () => garden.Plant(NULL_NAME);

            //Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(action);
            Assert.AreEqual("plant", exception.ParamName);
            //Assert.IsFalse(garden.GetPlants().Contains(NULL_NAME));
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("   ")]
        [DataRow("\t")]
        public void Plant_InvalidName_ArgumentException(string invalidName)
        {
            //Arrange
            const int VALID_SIZE = 0;
            var garden = new Garden(VALID_SIZE);

            //Act
            Action action = () => garden.Plant(invalidName);

            //Assert
            var exception = Assert.ThrowsException<ArgumentException>(action);
            Assert.AreEqual("plant", exception.ParamName);
            Assert.IsTrue(exception.Message.Contains("Invalid name"));
        }

        [TestMethod]
        public void Plant_DuplicatedName_ArgumentException()
        {
            //Arrange
            const int VALID_SIZE = 1;
            string name = new Fixture().Create<string>();
            var garden = new Garden(VALID_SIZE);
            garden.Plant(name);

            //Act
            Action action = () => garden.Plant(name);

            //Assert
            var exception = Assert.ThrowsException<ArgumentException>(action);
            Assert.AreEqual("plant", exception.ParamName);
            Assert.IsTrue(exception.Message.Contains("Duplicated name"));
        }

        [TestMethod]
        public void Plant_Name_AddedToGarden()
        {
            //Arrange
            string name = new Fixture().Create<string>();
            const int VALID_SIZE = 1;
            var garden = new Garden(VALID_SIZE);

            //Act
            garden.Plant(name);

            //Assert
            Assert.IsTrue(garden.GetPlants().Contains(name));
        }

        [TestMethod]
        public void GetPlants_CopyOfPlantsCollection()
        {
            //Arrange
            const int VALID_SIZE = 0;
            var garden = new Garden(VALID_SIZE);

            //Act
            var result1 = garden.GetPlants();
            var result2 = garden.GetPlants();

            //Assert
            Assert.AreNotSame(result1, result2);
        }
    }
}
