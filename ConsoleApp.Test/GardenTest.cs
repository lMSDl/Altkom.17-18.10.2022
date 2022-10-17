using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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


    }
}
