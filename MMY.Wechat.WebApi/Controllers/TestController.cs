using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MMY.Wechat.WebApi.Models.Oauth;

namespace MMY.Wechat.WebApi.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            string url = "http://wx.maimaiyin.cn/Oauth";
            OauthViewModel model = new OauthViewModel();
            model.AppID = "wx19cdf29cb703455b ";
            model.RedirectUri = System.Web.HttpUtility.HtmlEncode(url);
            return View(model);
        }
    }
}