using Microsoft.VisualStudio.TestTools.UnitTesting;
using AGT.Application.Users;
using Moq;
using AGT.Domain.Users;
using System;
using AGT.Contracts.Application.Users;
using AGT.Application.Users.Exceptions;
using AGT.Contracts.Repository;
using AGT.Contracts.CrossCutting;

namespace AGT.Application.Users.Test
{
    [TestClass]
    public class UserCreationTest
    {
        private IUserService userService;
        private User user;
        private Mock<IUnitOfWork> unitOfWork;
        private Mock<IRolFactory> rolFactory;
        private Mock<IHashGenerator> generator;

        [TestInitialize]
        public void SetUp()
        {
            user = GetUser();
            unitOfWork = new Mock<IUnitOfWork>();
            rolFactory = new Mock<IRolFactory>();
            generator = new Mock<IHashGenerator>();
            userService = new UserService(unitOfWork.Object, rolFactory.Object, generator.Object);
        }

        private User GetUser()
        {
            var user = new User("User1", "user@mail.com", "July", "Musk", "Pass", DateTime.Today);
            return user;
        }

        [TestMethod]
        public void SignUpTest()
        {
            unitOfWork.Setup(r => r.Users.Exists(user)).Returns(false);

            userService.SignUp(user);

            unitOfWork.Verify(r => r.Users.Exists(user));
            unitOfWork.Verify(r => r.Users.Add(user));
        }

        [TestMethod]
        public void SignUpDefaultRolTest()
        {
            unitOfWork.Setup(r => r.Users.Exists(user)).Returns(false);
            rolFactory.Setup(f => f.Create(RolEnum.DEFAULT));

            userService.SignUp(user);

            //To use VerifyNoOtherCalls we need to specify each Verify(method). VerifyAll or Verify() won't work
            rolFactory.Verify(r => r.Create(RolEnum.DEFAULT));
            rolFactory.VerifyNoOtherCalls();
          
            unitOfWork.Verify(r => r.Users.Exists(user));
            unitOfWork.Verify(r => r.Users.Add(user));
            unitOfWork.Verify(r => r.Complete());
            unitOfWork.VerifyNoOtherCalls();

            Assert.IsTrue(user.Roles.Count == 1);
        }

        [TestMethod]
        public void SignUpPasswordTest()
        {
            unitOfWork.Setup(r => r.Users.Exists(user)).Returns(false);

            generator.Setup(g => g.GetRandomSalt());
            generator.Setup(g => g.GetHash(It.IsAny<string>(), It.IsAny<byte[]>()));

            userService.SignUp(user);

            generator.Verify(g => g.GetRandomSalt());
            generator.Verify(g => g.GetHash(It.IsAny<string>(), It.IsAny<byte[]>()));
            generator.VerifyNoOtherCalls();

        }

        [TestMethod]
        public void SignUpFullTest()
        {
            unitOfWork.Setup(r => r.Users.Exists(user)).Returns(false);
            rolFactory.Setup(f => f.Create(RolEnum.DEFAULT));

            generator.Setup(g => g.GetRandomSalt());
            generator.Setup(g => g.GetHash(It.IsAny<string>(), It.IsAny<byte[]>()));

            userService.SignUp(user);

            generator.Verify(g => g.GetRandomSalt());
            generator.Verify(g => g.GetHash(It.IsAny<string>(), It.IsAny<byte[]>()));
            generator.VerifyNoOtherCalls();

            rolFactory.Verify(r => r.Create(RolEnum.DEFAULT));
            rolFactory.VerifyNoOtherCalls();

            unitOfWork.Verify(r => r.Users.Exists(user));
            unitOfWork.Verify(r => r.Users.Add(user));
            unitOfWork.Verify(r => r.Complete());
            unitOfWork.VerifyNoOtherCalls();

            Assert.IsTrue(user.Roles.Count == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationUsersException), AllowDerivedTypes = true)]
        public void SignUpDuplicatedParentExceptionTest()
        {
            unitOfWork.Setup(r => r.Users.Exists(user)).Returns(true);

            userService.SignUp(user);
        }

        [TestMethod]
        [ExpectedException(typeof(UserAlreadyExistsException), AllowDerivedTypes = true)]
        public void SignUpDuplicatedChildExceptionTest()
        {
            unitOfWork.Setup(r => r.Users.Exists(user)).Returns(true);

            userService.SignUp(user);
        }
    }
}
