using CapSoft.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CapSoft.Core.ViewModels;
using CapSoft.Core.Models;

namespace CapSoft.API.Controllers
{
    [RoutePrefix("test")]
    public class TestController : ApiController
    {

        private IUserRepository _IUserRepository;
        public TestController(IUserRepository _IUserRepo)
        {
            _IUserRepository = _IUserRepo;
        }

        // GET: api/Test
        [Route("~/")]
        [HttpGet]
        public String Get()
        {
            return "API is Running";

        }

        
    }
}
