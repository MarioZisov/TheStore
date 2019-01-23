using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using TheStore.Site.Authentication;

namespace TheStore.Site.Base
{
    public abstract class SiteViewPage<TModel> : WebViewPage<TModel>
    {
        protected SiteUser CurrentUser => new SiteUser(this.User as ClaimsPrincipal);
    }

    public abstract class SiteViewPage : SiteViewPage<dynamic>
    {

    }
}