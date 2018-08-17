
using System;
using AGT.Domain.Users;

namespace AGT.WebApi.Models
{
    public class UserModel : Model<User, UserModel>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string ProfileImage { get; set; }
        public string Password { get; set; }

        protected override User ToEntity()
        {
            return new User(Username, Email, Name, Surname, Password, Birthday);
        }

        protected override UserModel SetModel(User entity)
        {
            Username = entity.Username;
            Email = entity.Email;
            Name = entity.Name;
            Surname = entity.Surname;
            Birthday = entity.Birthday;
            ProfileImage = entity.ProfileImage;
            return this;
        }
    }
}