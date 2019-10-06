using BizTalk.API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace BizTalk.API.Controllers
{
    [RoutePrefix("Messages")]
    public class MessagesController : ApiController
    {
        private BizTalkObject _bizTalkObject = null;
        public MessagesController()
        {
            string serverName = GeneralHelper.GetConfigurationValue("BizTalkSqlServer");
            _bizTalkObject = new BizTalkObject(serverName: serverName);
        }
        [Route("GetMessage/{messageId}/{encoding?}")]
        public string GetMessage(string messageId, string encoding = null)
        {
            Encoding enc = null;
            if (!string.IsNullOrWhiteSpace(encoding))
            {
                enc = Encoding.GetEncoding(name: encoding);
            }
            string result = _bizTalkObject.GetMessageString(messageId: messageId,encoding: enc);
            return result;

        }
    }
}
