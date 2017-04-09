using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Entities;

namespace Todo.Web.UI.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Count { get; set; }

        public static explicit operator UserEntity (UserModel userModel)
        {
            UserEntity userEntity = new UserEntity()
            {
                Id = userModel.Id,
                Title = userModel.Title,
                Count = userModel.Count
            };
            return userEntity;
        }

        public static explicit operator UserModel(UserEntity userEntity)
        {
            UserModel userModel = new UserModel()
            {
                Id = userEntity.Id,
                Title = userEntity.Title,
                Count = userEntity.Count
            };
            return userModel;
        }
    }
}
