using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Entities;

namespace Todo.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<UserEntity> GetAll();
        UserEntity Add(UserEntity user);
        //UserEntity Update(UserEntity user);
        UserEntity Delete(UserEntity user);
    }
}
