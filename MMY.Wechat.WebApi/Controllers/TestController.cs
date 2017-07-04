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
            var mmyAppid = "wx19cdf29cb703455b";
            var mmyRedirecturl = System.Web.HttpUtility.HtmlEncode(url);
            string result = $"https://open.weixin.qq.com/connect/oauth2/authorize?appid={mmyAppid}&redirect_uri={mmyRedirecturl}&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect";
            ViewBag.result = result;
            return View();
        }
    }
}