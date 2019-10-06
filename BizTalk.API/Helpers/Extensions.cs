using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace BizTalk.API.Helpers
{
    public static class Extensions
    {
        public static Guid ToGuid(this string input)
        {
            var result = new Guid(input);
            return result;
        }

        public static string ConvertToString(this Stream stream, Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;
            StreamReader sr = new StreamReader(stream: stream, encoding: encoding);
            string result = sr.ReadToEnd();
            return result;
        }
    }
}