using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCouche1
{
    public class UserRepoInFile : IUserRepository
    {
        public void Add(User user, Action<IEnumerable<User>> callBack)
        {
            Console.WriteLine("Save in file");
            //throw new NotImplementedException();
        }

        public void Delete(User user, Action<IEnumerable<User>> callBack)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<User> users, Action<IEnumerable<User>> callBack)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Find(Func<User, bool> predicate, Action<IEnumerable<User>> callBack)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Set(User oldUser, User newUser, Action<IEnumerable<User>> loadGrid)
        {
            throw new NotImplementedException();
        }

        //void IUserRepository.Find(Func<User, bool> predicate, Action<IEnumerable<User>> callBack)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
