using AutoMapper;
using FinanceHelper.Controllers;
using FinanceHelper.Models;
using FinanceHelper.Repository;
using Moq;
using NUnit.Framework;

namespace FinanceHelperTests {
	public class Tests {

		private UserController _userController;

		[SetUp]
		public void Setup() {
			_userController = new UserController(new Mock<IUserRepository>().Object, new Mock<IContactRepository>().Object);
		}

		[Test]
		public void Test1() {

			var user =_userController.ListUsersContactById(4);
			
			Assert.IsTrue(true);
		}
	}
}