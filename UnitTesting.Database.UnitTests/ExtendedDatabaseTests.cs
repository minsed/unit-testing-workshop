using System;
using System.Collections.Generic;
using System.Text;
using UnitTesting.Database.Repository;
using Xunit;

namespace UnitTesting.Database.UnitTests
{
    public class ExtendedDatabaseTests
    {
        [Fact]
        public void GivenExtendedDatabase_WhenFindWithNegativeId_ThenThrowsException()
        {
            //Arrange
            var id = -1;
            var database = new ExtendedDatabase();

            //Act
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => database.Find(id));
        }
    }
}
