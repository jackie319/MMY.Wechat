using log4net;
using MMY.Wechat.WebApi.Models.Oauth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MMY.Wechat.WebApi.Controllers
{
    /// <summary>
    /// 微信授权代理
    /// </summary>
    public class OauthController : Controller
    {
        private ILog _log;
        public OauthController()
        {
            _log=LogManager.GetLogger(typeof(OauthController));
        }
        /// <summary>
        /// 想要进行微信授权的项目跳转到此地址
        /// 传入返回的页面地址
        /// </summary>
        /// <returns></returns>
        public ActionResult GetCode(OauthViewModel model)
        {
            string redirectUrl = "";
            string state = "STATE";
            if (!string.IsNullOrEmpty(model.RedirectUrl))
            {
                redirectUrl = model.RedirectUrl;
            }
          
            if (!string.IsNullOrEmpty(model.State))
            {
                state = model.State;
            }
            string url = $"http://wx.maimaiyin.cn/Oauth?RedirectUrl={redirectUrl}";
            var mmyAppid = "wx19cdf29cb703455b";//TODO:
            var mmyRedirecturl = System.Web.HttpUtility.HtmlEncode(url);
            string result = $"https://open.weixin.qq.com/connect/oauth2/authorize?appid={mmyAppid}&redirect_uri={mmyRedirecturl}&response_type=code&scope=snsapi_userinfo&state={state}#wechat_redirect";
            //没有出现授权页面，而是白屏，基本上是地址result 拼写错误，大小写，空格等。
            //尤其注意：由于授权操作安全等级较高，所以在发起授权请求时，
            //微信会对授权链接做正则强匹配校验，如果链接的参数顺序不对，授权页面将无法正常访问
            return Redirect(result);
        }


        /// <summary>
        /// 收到code后跳转到上面Action收到的跳转地址并返回code
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Index(CodeViewModel model)
        {
            //跳转到State带上code
            var redirectUrl = "";;
            if (model.State.Contains("?"))
            {
                redirectUrl = $"{model.RedirectUrl}&code={model.Code}&state={model.State}";
            }
            else{
                redirectUrl = $"{model.RedirectUrl}?code={model.Code}&state={model.State}";
            }
            _log.Info("Index的RedirectUrl=" + redirectUrl);
            return Redirect(redirectUrl);
           //return View(model);
        }
    }
}