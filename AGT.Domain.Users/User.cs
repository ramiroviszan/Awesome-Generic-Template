using System;
using System.Collections.Generic;

namespace AGT.Domain.Users
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string Password { get; set; }
        public ICollection<Rol> Roles { get; set; }

        public User() {
            Roles = new List<Rol>();
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
                var other = obj as User;
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
