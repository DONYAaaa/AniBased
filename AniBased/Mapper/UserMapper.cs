using AniBased.DAL;
using AniBased.Model.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Mapper
{
    internal static class UserMapper
    {
        public static User ToBLL(this UserDAL entity) 
        {
            return User.Builder.AddId(entity.Id)
                               .AddName(entity.Nickname)
                               .AddEmail(entity.Mail)
                               .AddPassword(entity.PasswordHash)
                               .AddDateOfBirth(entity.DateOfBirth)
                               .Build();
        }

        public static UserDAL ToDAL(this User entity) 
        {
            return new UserDAL
            {
                Id = entity.Id,
                Nickname = entity.Name,
                Mail = entity.Email,
                PasswordHash = entity.Password,
                DateOfBirth = entity.DateOfBirth,
            };
        }
    }
}
