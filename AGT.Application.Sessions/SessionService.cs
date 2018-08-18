using AGT.Application.Sessions.Exceptions;
using AGT.Contracts.Application.Sessions;
using AGT.Contracts.Application.Users;
using AGT.Contracts.CrossCutting;
using AGT.Contracts.Repository;
using AGT.Domain.Sessions;
using AGT.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;

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
           try {
               return TryLogin(session);
           } catch (RepositoryException e) {
               throw new LoginFailedException(e);
           }
        }
        protected virtual Session TryLogin(Session session) {
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
            catch (RepositoryException)
            {
                throw new InvalidLoginCredentialsException();
            }
        }
        private void CreateSession(Session session)
        {
            session.Password = null;
            var sessionSalt = hashGenerator.GetRandomSalt();
            session.Token = hashGenerator.GetHash(session.Username, sessionSalt);
            session.Creation = DateTime.Now;
            session.LastAccess = session.Creation;
            repositories.Sessions.Add(session);
            repositories.Complete();
        }

        public int Logout(Session session)
        {
            try
            {
                session = TryLogout(session);
                return GetSessionCountLeft(session);
            }
            catch (RepositoryException e)
            {
                throw new LogoutFailedException(e);
            }
        }
        protected virtual Session TryLogout(Session session)
        {
            session = repositories.Sessions.Find(session);
            session.Deleted = true;
            repositories.Complete();
            return session;
        }
        protected virtual int GetSessionCountLeft(Session session) {
            try
            {
              return TryGetSessionCountLeft(session);
            }
            catch (RepositoryException)
            {
                return -1;     
            }
        }
        private int TryGetSessionCountLeft(Session session)
        {
            var count = repositories.Sessions.FindAllByFilter(s => session.Username.Equals(s.Username) && !s.Deleted);
            return count.Count();
        }
    }
}
