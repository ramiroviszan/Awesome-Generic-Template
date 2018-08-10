using AGT.Application.Sessions.Exceptions;
using AGT.Contracts.Application.Sessions;
using AGT.Contracts.CrossCutting;
using AGT.Contracts.Repository;
using AGT.Domain.Sessions;
using AGT.Domain.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;


namespace AGT.Application.Sessions.Test
{
    [TestClass]
    public class SessionServiceTest
    {
        private ISessionService sessionService;
        private User databaseUser;
        private Mock<IUnitOfWork> unitOfWork;
        private Mock<IHashGenerator> generator;

        [TestInitialize]
        public void SetUp()
        {
            unitOfWork = new Mock<IUnitOfWork>();
            generator = new Mock<IHashGenerator>();
            databaseUser = new User("User1", "user@mail.com", "July", "Musk", "pass", DateTime.Today);
            sessionService = new SessionService(unitOfWork.Object, generator.Object);
        }

        [TestMethod]
        public void LoginSucessTest()
        {
            var session = new Session() { Username = databaseUser.Username, Password = databaseUser.Password, Agent = "Chrome", Device = "Laptop" };

            unitOfWork.Setup(r => r.Users.Find(It.IsAny<User>())).Returns(databaseUser);
            generator.Setup(g => g.GetHash(databaseUser.Password, databaseUser.PasswordSalt)).Returns(databaseUser.Password);
            generator.Setup(g => g.GetRandomSalt()).Returns(It.IsAny<byte[]>());
            generator.Setup(g => g.GetHash(session.Username, It.IsAny<byte[]>())).Returns("token");
            unitOfWork.Setup(r => r.Sessions.Add(session));

            session = sessionService.Login(session);

            unitOfWork.Verify(r => r.Users.Find(It.IsAny<User>()));
            generator.Verify(g => g.GetHash(databaseUser.Password, databaseUser.PasswordSalt));
            generator.Verify(g => g.GetRandomSalt());
            generator.Verify(g => g.GetHash(session.Username, It.IsAny<byte[]>()));
            generator.VerifyNoOtherCalls();
            unitOfWork.Verify(r => r.Sessions.Add(session));
            unitOfWork.Verify(r => r.Complete());
            unitOfWork.VerifyNoOtherCalls();

            Assert.AreEqual("token", session.Token);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationSessionsException), AllowDerivedTypes = true)]
        public void LoginFailedParentExceptionTest()
        {
            var session = new Session() { Username = databaseUser.Username, Password = databaseUser.Password, Agent = "Chrome", Device = "Laptop" };

            unitOfWork.Setup(r => r.Users.Find(It.IsAny<User>())).Returns(databaseUser);
            generator.Setup(g => g.GetHash(databaseUser.Password, databaseUser.PasswordSalt)).Returns("other");
            session = sessionService.Login(session);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidLoginCredentialsException), AllowDerivedTypes = true)]
        public void LoginFailedChildExceptionTest()
        {
            var session = new Session() { Username = databaseUser.Username, Password = databaseUser.Password, Agent = "Chrome", Device = "Laptop" };

            unitOfWork.Setup(r => r.Users.Find(It.IsAny<User>())).Returns(databaseUser);
            generator.Setup(g => g.GetHash(databaseUser.Password, databaseUser.PasswordSalt)).Returns("other");
            session = sessionService.Login(session);
        }
    }
}
