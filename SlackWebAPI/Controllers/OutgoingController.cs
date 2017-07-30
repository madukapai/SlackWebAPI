using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
using System.Text;
using static SlackWebAPI.Models.SlackModel;

namespace SlackWebAPI.Controllers
{
    public class OutgoingController : ApiController
    {
        HttpStatusCode code = HttpStatusCode.OK;

        public HttpResponseMessage Post(SlackOutgoingContent query)
        {
            string strReplyMessage = $"你輸入的訊息是{query.text}";
            string strResult = "";

            // 呼叫回送至Slack的function
            try
            {
                SlackMessageQuery objReply = new SlackMessageQuery()
                {
                    text = strReplyMessage,
                };

                strResult = new SlackMessageObj().SendMessage(objReply);
            }
            catch (Exception e)
            {
                code = HttpStatusCode.BadRequest;
            }
            // 找出內容

            return Request.CreateResponse(HttpStatusCode.OK, strResult);
        }
    }
}
