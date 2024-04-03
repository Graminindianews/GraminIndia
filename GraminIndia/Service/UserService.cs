using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace GraminIndia.Service
{
    public class UserService
    {
        private readonly HttpContext _httpContext;
        public UserService(HttpContext httpContext)
        {
            _httpContext = httpContext;
        }
        public string GetUserId()
        {
            return _httpContext.Session.SessionID;
        }
    }
}