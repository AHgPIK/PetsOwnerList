using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Entities;

namespace Todo.Repositories
{
    public class FakeUserRepository : IUserRepository
    {
        #region Data

        private static readonly List<UserEntity> users;
        private static int lastGeneratedId;

        static FakeUserRepository() 
        {
            users = new List<UserEntity>()
            {
                new UserEntity { Id = 1, Title = "Bob", Count = 3 },
                new UserEntity { Id = 2, Title = "Simpson", Count = 2 },
                new UserEntity { Id = 3, Title = "Michael", Count = 4 },
                new UserEntity { Id = 4, Title = "Mariya", Count = 1 },
            };
            lastGeneratedId = 4;
        }

        private int GenerateNextId()
        {
            lastGeneratedId += 1;
            return lastGeneratedId;
        }

        #endregion

        #region IUserRepository

        public IEnumerable<UserEntity> GetAll()
        {
            return users;
        }
        
        public UserEntity Add(UserEntity user)
        {
            user.Id = GenerateNextId();
            users.Add(user);
            return user;
        }

        public UserEntity Delete(UserEntity user)
        {
            var existingUser = users
                .Select((t, i) => new { User = t, Index = i })
                .Where(r => r.User.Id == user.Id)
                .Single();
            users.Remove(existingUser.User);
            return user;
        }
        
        #endregion
    }
}