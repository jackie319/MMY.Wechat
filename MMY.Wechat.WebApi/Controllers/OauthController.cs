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
        private string RedirectUrl { get; set; }
    
        /// <summary>
        /// 想要进行微信授权的项目跳转到此地址
        /// 传入返回的页面地址
        /// </summary>
        /// <returns></returns>
        public ActionResult GetCode(OauthViewModel model)
        {
            RedirectUrl = model.RedirectUri;
            //同一个公众号的项目共用授权
            string url = "http://wx.maimaiyin.cn/Oauth";
            var appid = "wx19cdf29cb703455b ";
            var redirecturl = System.Web.HttpUtility.HtmlEncode(url);
            string result = $"https://open.weixin.qq.com/connect/oauth2/authorize?appid={appid}&redirect_uri={redirecturl}&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect";
            return Redirect(result);
        }


        /// <summary>
        /// 收到code后跳转到上面Action收到的跳转地址并返回code
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Index(CodeViewModel model)
        {
            //跳转到RedirectUrl带上code
            return View(model);
        }
    }
}