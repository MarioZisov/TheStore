using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheStore.Site.Models
{
    public class TheStoreContext : IdentityDbContext<ApplicationUser>
    {
        public TheStoreContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static TheStoreContext Create()
        {
            return new TheStoreContext();
        }
    }
}