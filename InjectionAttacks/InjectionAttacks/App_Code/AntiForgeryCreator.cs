using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InjectionAttacks
{
    public static class AntiForgeryCreator
    {
        public static void ValidateOrCreate(Page page, HiddenField hiddenField)
        {
            if (!page.IsPostBack)
            {
                Guid guid = Guid.NewGuid();
                page.Session["token"] = guid;
                hiddenField.Value = guid.ToString();
            }
            else
            {
                var requestedToken = hiddenField.Value;
                var savedToken = (Guid)page.Session["token"];
                if (requestedToken != savedToken.ToString())
                {
                    throw new Exception("Yakaladık seniiii");
                }

            }
        }
    }
}