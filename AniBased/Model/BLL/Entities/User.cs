using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AniBased.Model.BLL.Entities.Anime;

namespace AniBased.Model.BLL.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateOnly DateOfBirth { get; private set; }

        public Library Library { get; set; }

        public static UserBuilder Builder => new UserBuilder();

        private User() { }


        public class UserBuilder
        {
            User user;


            public UserBuilder()
            {
                user = new();
                user.Library = new();
            }

            public NameUserBuilder AddId(int Id)
            {
                user.Id = Id;
                return new NameUserBuilder(user);
            }

            public class NameUserBuilder
            {
                public User user;

                public NameUserBuilder(User user)
                {
                    this.user = user;
                }

                public EmailUserBuilder AddName(string name)
                {
                    user.Name = name;
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

                        public FinalUserBuilder AddPassword(string password)
                        {
                            user.Password = password;
                            return new FinalUserBuilder(user);
                        }

                        public class FinalUserBuilder
                        {
                            public User user;

                            public FinalUserBuilder(User user)
                            {
                                this.user = user;
                            }

                            public FinalUserBuilder AddDateOfBirth(DateOnly dateOfBirth)
                            {
                                user.DateOfBirth = dateOfBirth;
                                return this;
                            }

                            public User Build() { return user; }
                        }

                    }
                }
            }
        }
    }
}
