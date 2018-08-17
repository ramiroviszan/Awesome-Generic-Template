using System;
using AGT.Domain.Sessions;

namespace AGT.WebApi.Models
{
    public class SessionModel : Model<Session, SessionModel>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string Device { get; set; }
        public string Agent { get; set; }
        public DateTime Creation { get; set; }
        public DateTime LastAccess { get; set; }

        protected override Session ToEntity()
        {
            var session = new Session();
            session.Username = Username;
            session.Password = Password;
            session.Device = Device;
            session.Agent = Agent;
            return session;
        }

        protected override SessionModel SetModel(Session entity)
        {
            Username = entity.Username;
            Token = entity.Token;
            Device = entity.Device;
            Agent = entity.Agent;
            Creation = entity.Creation;
            LastAccess = entity.LastAccess;
            return this;
        }
    }

}