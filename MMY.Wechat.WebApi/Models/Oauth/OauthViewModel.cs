using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMY.Wechat.WebApi.Models.Oauth
{
    public class OauthViewModel
    {
        /// <summary>
        /// 原访问地址
        /// </summary>
        public string RedirectUrl { get; set; }

        public string State { get; set; }

    }
}