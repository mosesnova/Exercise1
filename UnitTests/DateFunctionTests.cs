using Utils;

namespace UnitTests
{
    [TestClass]
    public class DateFunctionTests
    {
        [TestMethod]
        public void AddBusinessDays_Test1()
        {
            //Arrange
            DateTime startDate = new DateTime(2022, 4, 5); // Tuesday April the 4th 2022

            //Act
            DateTime finishDate = DateFunctions.AddBusinessDays(startDate, 5);

            //Assert
            Assert.AreEqual(new DateTime(2022, 4, 12), finishDate);
        }

        [TestMethod]
        public void AddBusinessDays_Test2()
        {
            //Arrange
            DateTime startDate = new DateTime(2022, 4, 9); // Saturday April the 9th 2022

            //Act
            DateTime finishDate = DateFunctions.AddBusinessDays(startDate, 2);

            //Assert
            Assert.AreEqual(new DateTime(2022, 4, 13), finishDate);
        }

        [TestMethod]
        public void AddBusinessDays_Test3()
        {
            //Arrange
            DateTime startDate = new DateTime(2022, 4, 9); // Saturday April the 9th 2022

            //Act
            DateTime finishDate = DateFunctions.AddBusinessDays(startDate, 20);

            //Assert
            Assert.AreEqual(new DateTime(2022, 5, 9), finishDate);
        }
    }
}