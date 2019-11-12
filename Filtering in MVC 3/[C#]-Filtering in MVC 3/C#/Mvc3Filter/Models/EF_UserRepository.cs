using System.Collections.Generic;
using System.Linq;

namespace Mvc3Filter.Models {
    public class EF_UserRepository : Mvc3Filter.Models.IUserDB {

        private UserDatabaseEntities _db = new UserDatabaseEntities();

        #region IUserDB Members

        public bool UserExists(string UserName) {
            var usr = _db.Users.FirstOrDefault(d => d.UserName == UserName);
            return (usr != null);
        }

        public List<User> GetAllUsers {
            get { return _db.Users.ToList(); }
        }

        public void CreateNewUser(User newUser) {
            _db.AddToUsers(newUser);
            _db.SaveChanges();
        }

        public User GetUser(string uid) {
            return _db.Users.FirstOrDefault(d => d.UserName == uid);
        }

        public void Remove(string usrName) {
            var userToRemove = GetUser(usrName);
            _db.Users.DeleteObject(userToRemove);
            _db.SaveChanges();
        }

        public void Update(User userToUpdate) {
            _db.SaveChanges();
        }

        #endregion
    }
}