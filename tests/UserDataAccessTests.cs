using DataAccess;
using investigation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mysqlx.Crud;
using System;

namespace DataAccess
{
    [TestClass]
    public class UserDataAccessTests
    {
        private string testUsername = "UnitTestUser_" + DateTime.Now.Ticks;

        [TestMethod]
        public void Test_AddUser_ShouldCreateUser()
        {
            // Act
            int userId = UserDataAccess.AddUser(testUsername);

            // Assert
            Assert.IsTrue(userId > 0, "User ID should be greater than 0 after creation.");
        }

        [TestMethod]
        public void Test_GetUserByUsername_ShouldReturnUser()
        {
            // Arrange - קודם נוסיף את המשתמש
            int userId = UserDataAccess.AddUser(testUsername);

            // Act
            var user = UserDataAccess.GetUserByUsername(testUsername);

            // Assert
            Assert.IsNotNull(user, "User should not be null.");
            Assert.AreEqual(testUsername, user.Username, "Username should match.");
            Assert.IsTrue(user.Id > 0, "User ID should be valid.");
        }
    }
}