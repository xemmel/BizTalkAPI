using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BizTalk.API.Helpers
{
    public class GeneralHelper
    {
        public static string GetConfigurationValue(string key)
        {
            return ConfigurationManager.AppSettings[name: key];
        }
    }
}