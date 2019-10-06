using Microsoft.BizTalk.Message.Interop;
using Microsoft.BizTalk.Operations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace BizTalk.API.Helpers
{
    public class BizTalkObject
    {
        private BizTalkOperations _BizTalkOperations;
        private TrackingDatabase _TrackingDatabase;
        private const string MANAGEMENTDBNAME = "BizTalkMgmtDb";
        private const string TRACKINGDBNAME = "BizTalkDTADb";

        public BizTalkObject(string serverName)
        {
            this._BizTalkOperations = new BizTalkOperations(mgmtDbServer: serverName, mgmtDbName: MANAGEMENTDBNAME);
            this._TrackingDatabase = new TrackingDatabase(dbServer: serverName, dbName: TRACKINGDBNAME);
        }

        public Stream GetMessageStream(string messageId)
        {
            var baseMessage = GetBizTalkMessage(messageId: messageId);
            Stream result = baseMessage.BodyPart.Data;
            return result;
        }

        public string GetMessageString(string messageId, Encoding encoding = null)
        {
            try
            {
                string result = GetMessageStream(messageId: messageId)
                          .ConvertToString(encoding: encoding);
                return result;
            }


            catch (OperationsArtifactNotFoundException)
            {

                return null;
            }
        }
        private IBaseMessage GetBizTalkMessage(string messageId)
        {
            var result = _BizTalkOperations.GetTrackedMessage(messageID: messageId.ToGuid());
            return result;

        }
    }
}