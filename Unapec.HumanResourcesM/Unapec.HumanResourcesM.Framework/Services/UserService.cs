using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unapec.HumanResourcesM.Framework.Data;
using Unapec.HumanResourcesM.Framework.Entities;

namespace Unapec.HumanResourcesM.Framework.Services
{
    public class UserService
    {

        private readonly DataContext _context;

        public UserService()
        {
            _context = new DataContext();
        }

        public Employee DoLogin(string username, string password)
        {
            var id = int.Parse(username);
            username = UserNamePadding(id);
            var decrypted = Decrypt(password);
            var user = _context.Users.SingleOrDefault(p => p.Username == username && p.Password == decrypted);
            return user?.Employee;
        }

        public bool IsFirstLoginAttempt(string username)
        {
            var user = _context.Users.SingleOrDefault(p => p.Username == username);
            return user != null && user.ChangePassword;
        }

        public bool Create(User user, int employeeId)
        {
            user.Employee = _context.Employees.SingleOrDefault(s => s.Id == employeeId);
            user.Username = "UNASIGNED";
            user.Password = "UNASIGNED";
            user.ChangePassword = true;
            user = _context.Users.Add(user);
            _context.SaveChanges();
            user.Username = UserNamePadding(user.Id);
            user.Password = user.Employee.Identification;
            _context.SaveChanges();
            return user.Id > 0;
        }

        public void Delete(int userId)
        {
            var user = _context.Users.Find(userId);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public IEnumerable<Permission> GetPermissions()
        {
            return _context.Permissions.ToList();
        }

        public void UpdatePermissions(int userId, IEnumerable<int> permissions)
        {
            var user = _context.Users.SingleOrDefault(p => p.Id == userId);
            var assignedPermissions = _context.Permissions.Where(p => permissions.Contains(p.Id));
            foreach (var item in assignedPermissions)
            {
                _context.UserPermissions.Add(new UserPermission
                {
                    UserId = user.Id,
                    PermissionId = item.Id
                });
            }
            _context.SaveChanges();
        }

        public void SetPassword(string username, string password, string newPassword)
        {
            var user = _context.Users.SingleOrDefault(p => p.Username == username && p.Password == password);
            if (user != null)
            {
                user.Password = Encrypt(newPassword);
            }
        }

        private static string UserNamePadding(int value)
        {
            return string.Format("{0:00000}", value);
        }

        internal string Encrypt(string value)
        {
            return value;
        }

        internal string Decrypt(string value)
        {
            return value;
        }

    }
}
