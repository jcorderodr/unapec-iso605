using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unapec.HumanResourcesM.Framework.Data;

namespace Unapec.HumanResourcesM.Framework.Services
{
    public class UserService
    {

        private readonly DataContext _context;

        public UserService()
        {
            _context = new DataContext();
        }

        public User DoLogin(string username, string password)
        {
            var decrypted = password;

            var user = _context.Users.SingleOrDefault(p => p.Username == username && p.Password == decrypted);
            return user;
        }

        public bool Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.Id > 0;
        }

        public void Delete(int userId)
        {
            var user = _context.Users.Find(userId);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

    }
}
