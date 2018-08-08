using Microsoft.VisualStudio.TestTools.UnitTesting;
using AGT.Application.Users;
using Moq;
using AGT.Domain.Users;
using System;
using AGT.Contracts.DataAccess;
using AGT.Contracts.Application.Users;
using AGT.Application.Users.Exceptions;

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
            var user = new User("User1", "user@mail.com", "July", "Musk", "Pass", DateTime.Today);
            return user;
        }

        [TestMethod]
        public void SignUpTest()
        {
            userDataAccess.Setup(r => r.Find(user));

            userService.SignUp(user);

            userDataAccess.Verify(r => r.Create(user));
            userDataAccess.Verify(r => r.Find(user));
        }

        [TestMethod]
        public void SignUpDefaultRolTest()
        {
            userDataAccess.Setup(r => r.Find(user));
            rolFactory.Setup(f => f.Create(RolEnum.DEFAULT));

            userService.SignUp(user);

            //To use VerifyNoOtherCalls we need to specify each Verify(method). VerifyAll or Verify() won't work
            userDataAccess.Verify(r => r.Create(user));
            userDataAccess.Verify(r => r.Find(user));
            userDataAccess.VerifyNoOtherCalls();

            rolFactory.Verify(r => r.Create(RolEnum.DEFAULT));
            rolFactory.VerifyNoOtherCalls();

            Assert.IsTrue(user.Roles.Count == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationUsersException), AllowDerivedTypes = true)]
        public void SignUpDuplicatedParentExceptionTest()
        {
            userDataAccess.Setup(r => r.Find(user)).Throws(new Exception());

            userService.SignUp(user);
        }

        [TestMethod]
        [ExpectedException(typeof(UserAlreadyExistsException), AllowDerivedTypes = true)]
        public void SignUpDuplicatedChildExceptionTest()
        {
            userDataAccess.Setup(r => r.Find(user)).Throws(new Exception());

            userService.SignUp(user);
        }
    }
}
