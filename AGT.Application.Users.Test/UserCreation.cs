using Microsoft.VisualStudio.TestTools.UnitTesting;
using AGT.Application.Users;
using Moq;
using AGT.Domain.Users;
using System;
using AGT.Contracts.DataAccess;

namespace AGT.Application.Users.Test
{
    [TestClass]
    public class UserCreation
    {
        private IUserService userService;
        private User user;
        private Mock<IBaseDataAccess<User>> userDataAccess;
        private Mock<IRolFactory> rolFactory;

        [TestInitialize]
        public void SetUp()
        {
            user = GetUser();
            userDataAccess = new Mock<IBaseDataAccess<User>>();
            rolFactory = new Mock<IRolFactory>();
            userService = new UserService(userDataAccess.Object, rolFactory.Object);
        }

        private User GetUser()
        {
            var user = new User("User1", "July", "Musk", "Pass", DateTime.Today);
            return user;
        }

        [TestMethod]
        public void SignUpTest()
        {
            userDataAccess.Setup(r => r.Exists(user)).Returns(false);

            userService.SignUp(user);

            userDataAccess.Verify(r => r.Add(user));
            userDataAccess.Verify(r => r.Exists(user));
        }

        [TestMethod]
        public void SignUpDefaultRolTest()
        {
            userDataAccess.Setup(r => r.Exists(user)).Returns(false);
            rolFactory.Setup(f => f.Create(RolEnum.DEFAULT));

            userService.SignUp(user);

            //To use VerifyNoOtherCalls we need to specify each Verify(method). VerifyAll or Verify() won't work
            userDataAccess.Verify(r => r.Add(user));
            userDataAccess.Verify(r => r.Exists(user));
            userDataAccess.VerifyNoOtherCalls();

            rolFactory.Verify(r => r.Create(RolEnum.DEFAULT));
            rolFactory.VerifyNoOtherCalls();

            Assert.IsTrue(user.Roles.Count == 1);
        }
    }
}
