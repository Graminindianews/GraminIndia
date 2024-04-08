using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Website.Models;

namespace GraminIndia.Service
{
    public class UserService : LoginModel
    {
        private readonly HttpContext _currentUser;
        public UserService(HttpContext httpContext)
        {
            _currentUser = httpContext;
        }
    }
}