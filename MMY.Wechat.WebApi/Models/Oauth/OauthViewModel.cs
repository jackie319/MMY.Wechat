using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMY.Wechat.WebApi.Models.Oauth
{
    public class OauthViewModel
    {
        public  string AppID { get; set; }

        public string RedirectUri { get; set; }
    }
}