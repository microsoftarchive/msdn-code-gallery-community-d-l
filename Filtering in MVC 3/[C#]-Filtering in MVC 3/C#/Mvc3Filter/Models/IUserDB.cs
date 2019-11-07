using System.Collections.Generic;

namespace Mvc3Filter.Models {
    public interface IUserDB {
        List<User> GetAllUsers { get; }
        bool UserExists(string UserName);
        void CreateNewUser(User newUser);
        User GetUser(string uid);
        void Remove(string usrName);
        void Update(User userToUpdate);
    }
}
