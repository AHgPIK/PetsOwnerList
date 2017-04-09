using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Todo.Entities;
using Todo.Repositories;
using Todo.Web.UI.Models;

namespace Todo.Web.UI.Controllers
{
    public class UserController : Controller
    {
        #region Fields

        private readonly IUserRepository _userRepository;

        #endregion

        #region Constructors

        public UserController()
        {
            _userRepository = new FakeUserRepository();
        }

        #endregion

        #region Actions

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetUsers()
        {
            var users = _userRepository.GetAll();
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        //[HttpGet]
        //public ActionResult GetPages()
        //{
        //    var pages = _userRepository.GetPages();
        //    return Json(pages, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public ActionResult AddUser(UserModel user)
        {
            UserEntity userEntity = (UserEntity)user; // explicit type conversion operator defined within the UserModel class
            UserEntity addedUserEntity = _userRepository.Add(userEntity);            
            return Json(addedUserEntity);
        }

        [HttpPost]
        public ActionResult DeleteUser(UserModel user)
        {
            UserEntity userEntity = (UserEntity)user; // explicit type conversion operator defined within the UserModel class
            _userRepository.Delete(userEntity);
            return Json(user);
        }

        #endregion

        #region Helpers

        #endregion

    }
}