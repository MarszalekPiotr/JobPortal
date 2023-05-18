using JobPortal.Domain.Interfaces;
using JobPortal.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {    
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public User GetUserById(string UserId)
        {
            User userFounded = _context.Users.FirstOrDefault(u => u.Id == UserId);

            if (userFounded == null) 
            {
                throw new Exception();
            }
            return userFounded;
        }
    }
}
