using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using TestBlog.Models;

namespace TestBlog.Security
{
    public class CustomPrincipal : IPrincipal
    {
        public UserDetails userDetails;
        public CustomPrincipal(UserDetails userDetails)
        {
            this.userDetails = userDetails;
            this.Identity =new GenericIdentity(userDetails.email);
        }
        public IIdentity Identity
        {
            get;set;
        }

        public bool IsInRole(string role)
        {
            //var roles = role.Split(',');
            //roles.Any(x => userDetails.role.Contains(x));
            var roles = role.Split(new char[] { ',' });
            return roles.Any(r => this.userDetails.role.Contains(r));
        }
    }
}