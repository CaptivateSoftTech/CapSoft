using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CapSoft.Core;
using CapSoft.Core.Models;
using CapSoft.Core.ViewModels;
using CapSoft.Core.Interfaces;
using AutoMapper;

namespace CapSoft.API.Controllers
{
    [RoutePrefix("users")]
    public class UsersController : ApiController
    {
        private IUserRepository _IUserRepository;
        public UsersController(IUserRepository _IUserRepo)
        {
            _IUserRepository = _IUserRepo;
        }

        // GET: api/Users
        [HttpGet]
        [Route]
        public IEnumerable<UserViewModel> GetUsers()
        {
            var users =_IUserRepository.GetAll();

            IEnumerable<UserViewModel> _users = Mapper.Map<IEnumerable<UserViewModel>>(users);
            return _users;
        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(UserViewModel))]
        public IHttpActionResult GetUser(int id)
        {
            User user = _IUserRepository.GetById(id);

            UserViewModel _user = Mapper.Map<UserViewModel>(user);

            if (_user == null)
            {
                return NotFound();
            }

            return Ok(_user);
        }
        
       

       
    }
}