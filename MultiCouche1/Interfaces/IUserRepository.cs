using System;
using System.Collections.Generic;

namespace MultiCouche1
{
    public interface IUserRepository
    {
        void Add(User user, Action< IEnumerable<User>> callBack);
        IEnumerable<User> GetAll();
        void Delete(User user, Action<IEnumerable<User>> callBack);
        void Delete(IEnumerable<User> user, Action<IEnumerable<User>> callBack);
        void Set(User oldUser, User newUser, Action<IEnumerable<User>> callBack);
        IEnumerable<User> Find(Func<User, bool> predicate, Action<IEnumerable<User>> callBack);
    }
}