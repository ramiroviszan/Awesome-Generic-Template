using System;
using System.Collections.Generic;

namespace AGT.Domain.Users
{
    public class User
    {
        public string Username { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public DateTime Birthday { get; private set; }
        private string Password { get; set; }
        public ICollection<IRol> Rols { get; private set; }

        public User() { 
            //Leave if for any Relfection based system that might need it
        }

        public User(string username, string name, string surname, string password, DateTime birthday)
        {
            Username = username;
            Name = name;
            Surname = surname;
            Password = password;
            Birthday = birthday;
            Rols = new List<IRol>();
        }

        public void AddRol(IRol rol)
        {
            Rols.Add(rol);
        }

        public override bool Equals(object obj)
        {
            if(obj is User)
            {
                User other = obj as User;
                return Username.Equals(other.Username) && Password.Equals(other.Password);
            }
            return false;
        }
    }
}
