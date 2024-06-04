using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.DAL
{
    internal class UserDAL
    {
        public int Id { get; set; } 
        public string Nickname { get; set; }
        public string PasswordHash{ get; set; }
        public DateOnly DateOfBirth { get; set; }
        public DateTime ActionDate { get; set; }
        public string Mail { get; set; }
    }
}
