﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMY.Wechat.WebApi.Models.Oauth
{
    public class CodeViewModel
    {
        public string Code { get; set; }

        public string State { get; set; }

        public string RedirectUrl { get; set; }
    }
}