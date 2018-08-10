using System;

namespace AGT.Domain.Sessions
{
    public class Session
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string Device { get; set; }
        public string Agent { get; set; }
        public DateTime Creation {get;set;}
        public DateTime LastAccess { get; set; }

        public override bool Equals(object obj)
        {
            if(obj is Session)
            {
                var other = obj as Session;
                return Token.Equals(obj);
            }
            return false;
        }
    }
}
