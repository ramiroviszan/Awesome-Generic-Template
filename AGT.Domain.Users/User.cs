using System;
using System.Collections.Generic;

namespace AGT.Domain.Users
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public DateTime Birthday { get; private set; }
        private string Password { get; set; }
        public ICollection<Rol> Roles { get; private set; }

        private User() { 
            //Leave if for any Relfection based system that might need it
        }

        public User(string username, string email, string name, string surname, string password, DateTime birthday)
        {
            Username = username;
            Email = email;
            Name = name;
            Surname = surname;
            Password = password;
            Birthday = birthday;
            Roles = new List<Rol>();
        }

        public void AddRol(Rol rol)
        {
            Roles.Add(rol);
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

        public override int GetHashCode()
        {
            return HashCode.Combine(Username);
        }
    }
}
