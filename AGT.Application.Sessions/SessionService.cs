using AGT.Application.Sessions.Exceptions;
using AGT.Contracts.Application.Sessions;
using AGT.Contracts.Application.Users;
using AGT.Contracts.CrossCutting;
using AGT.Contracts.Repository;
using AGT.Domain.Sessions;
using AGT.Domain.Users;
using System;
using System.Collections.Generic;

namespace AGT.Application.Sessions
{
    public class SessionService : ISessionService
    {
        private IUnitOfWork repositories;
        private IHashGenerator hashGenerator;

        public SessionService(IUnitOfWork unit, IHashGenerator generator)
        {
            repositories = unit;
            hashGenerator = generator;
        }

        public IEnumerable<Session> GetAllSessions(Session session)
        {
            throw new NotImplementedException();
        }

        public Session Login(Session session)
        {
            var databaseUser = GetUserFromDatabase(session);
            var password = hashGenerator.GetHash(session.Password, databaseUser.PasswordSalt);

            if (password.Equals(databaseUser.Password))
            {
                CreateSession(session);
            }
            else
            {
                throw new InvalidLoginCredentialsException();
            }
            return session;
        }

        private User GetUserFromDatabase(Session session)
        {
            try
            {
                var databaseUser = repositories.Users.Find(new User() { Username = session.Username });
                return databaseUser;
            }
            catch (RepositoryException ex)
            {
                throw new InvalidLoginCredentialsException();
            }
        }

        private void CreateSession(Session session)
        {
            session.Password = null;
            var sessionSalt = hashGenerator.GetRandomSalt();
            session.Token = hashGenerator.GetHash(session.Username, sessionSalt);
            repositories.Sessions.Add(session);
            repositories.Complete();
        }

        public int Logout(Session session)
        {
            throw new NotImplementedException();
        }
    }
}
