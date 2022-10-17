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
        public void Garden_ValidSize_SizeInit()
        {
            //Arrage
            const int VALID_SIZE = 1;

            //Act
            var garden = new Garden(VALID_SIZE);

            //Assert
            Assert.AreEqual(VALID_SIZE, garden.Size);
        }
    }
}
