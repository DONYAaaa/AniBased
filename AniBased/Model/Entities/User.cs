using AniBased.Model.Entities.EntitiesOfLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Model.Entities
{
    internal class User
    {
        private int Id { get; set; }
        private string Name { get; set; }
        private string Email { get; set; }
        private string Password { get; set; }

        private Library Library { get; set; }

        private User() { }


        public class UserBuilder
        {
            User user;

            public UserBuilder()
            {
                this.user = new();
                user.Library = new();
            }

            public NameUserBuilder AddId (int Id) 
            { 
                user.Id = Id;
                return new NameUserBuilder(user);
            }

            public class NameUserBuilder
            {
                public User user;

                public NameUserBuilder (User user) 
                {
                    this.user = user;
                }

                public EmailUserBuilder AddName(string name) 
                {
                    this.user.Name = name;
                    return new EmailUserBuilder(user);
                }

                public class EmailUserBuilder
                {
                    public User user;

                    public EmailUserBuilder(User user)
                    {
                        this.user = user; 
                    }

                    public PasswordUserBuilder AddEmail(string email)
                    {
                        user.Email = email;
                        return new PasswordUserBuilder(user);
                    }

                    public class PasswordUserBuilder
                    {
                        public User user;

                        public PasswordUserBuilder(User user)
                        {
                            this.user = user;
                        }

                        public PasswordUserBuilder AddPassword(string password)
                        {
                            user.Password = password;
                            return this;
                        }

                        public User Build() {return this.user;}
                    }
                }
            }
        }
    }
}
