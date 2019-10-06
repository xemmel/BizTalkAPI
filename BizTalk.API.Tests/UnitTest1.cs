using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BizTalk.API.Helpers;

namespace BizTalk.API.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string serverName = GeneralHelper.GetConfigurationValue("BizTalkSqlServer");

            BizTalkObject bizTalkObject = new BizTalkObject(serverName: serverName);
            string messageId = "A29E9D0C-7169-48ED-951F-7A2C94E68802";
            string messageBody = bizTalkObject.GetMessageString(messageId: messageId);
            Assert.IsNotNull(messageBody);
            messageId = "FF69A72B-47A7-4F82-BADC-FC964EE18832";
            messageBody = bizTalkObject.GetMessageString(messageId: messageId);
            Assert.IsNull(messageBody);

        }
    }
}
