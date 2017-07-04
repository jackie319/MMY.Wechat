using MMY.Wechat.WebApi.Models.Oauth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MMY.Wechat.WebApi.Controllers
{
    public class OauthController : Controller
    {
        // GET: Oauth
        public ActionResult Index(CodeViewModel model)
        {
            
            return View(model);
        }
    }
}