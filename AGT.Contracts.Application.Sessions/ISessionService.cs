using AGT.Domain.Sessions;
using System;
using System.Collections.Generic;

namespace AGT.Contracts.Application.Sessions
{
    public interface ISessionService
    {
        Session Login(Session session);
        int Logout(Session session);
        IEnumerable<Session> GetAllSessions(Session session);
    }
}
