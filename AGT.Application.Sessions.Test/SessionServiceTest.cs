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
        private Session user;
        private Mock<IUnitOfWork> unitOfWork;
        private Mock<IHashGenerator> generator;

        [TestMethod]
        public void LoginSucessTest()
        {
            var databaseUser = new User("User1", "user@mail.com", "July", "Musk", "pass", DateTime.Today);
            var session = new Session() { Username = databaseUser.Username, Password = databaseUser.Password, Agent = "Chrome", Device = "Laptop" };

            var loginUser = It.IsAny<User>();
            loginUser.Username = session.Username;
            loginUser.Username = session.Password;

            unitOfWork.Setup(r => r.Users.Find(loginUser)).Returns(databaseUser);
            generator.Setup(g => g.GetHash(databaseUser.Password, databaseUser.PasswordSalt)).Returns(databaseUser.Password);

            unitOfWork.Setup(r => r.Sessions.Add(session));

            sessionService.Login(session);

            unitOfWork.Verify(r => r.Users.Find(loginUser));
            generator.Verify(g => g.GetHash(databaseUser.Password, databaseUser.PasswordSalt));
            generator.VerifyNoOtherCalls();
            unitOfWork.Verify(r => r.Sessions.Add(session));
            unitOfWork.VerifyNoOtherCalls();
        }
    }
}
