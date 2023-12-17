using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YourNamespace.Tests // Replace with your test namespace
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void User_PropertiesTest()
        {
            // Arrange
            var user = new User();

            // Act - No specific action needed for property tests

            // Assert
            Assert.AreEqual(default(int), user.Id); // Id should default to 0 for int
            Assert.IsNull(user.Name); // Name should default to null for string
            Assert.IsNull(user.Group); // Group should default to null for string
        }

        // Add more tests if you have additional business logic or constraints in the User class
    }
}
