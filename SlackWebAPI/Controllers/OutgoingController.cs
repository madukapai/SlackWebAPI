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
        public HttpResponseMessage Post(SlackOutgoingContent query)
        {
            // 找出內容
            string strContent = query.text;
            strContent = strContent.Replace("賈維斯", "");
            strContent = strContent.Replace(" ", "");

            string strReply = "";

            // 找出指令
            if (strContent.Contains("網路速度"))
            {
                strReply = "網路速度的偵測還沒作好喔";
            }

            if (strContent.Contains("你好") || strContent.Contains("安安") || strContent.ToLower().Contains("hi"))
            {
                strReply = "你好，今天過得安好順利嗎?";
            }

            if (strReply != "")
            {

                SlackMessageQuery objReply = new SlackMessageQuery()
                {
                    text = strReply,
                };

                string strResult = new SlackMessageObj().SendMessage(objReply);
                return Request.CreateResponse(HttpStatusCode.OK, strResult);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NoContent, "");
            }
        }


        public class SlackOutgoingContent
        {
            public string token { get; set; }
            public string team_id { get; set; }
            public string team_domain { get; set; }
            public string channel_id { get; set; }
            public string channel_name { get; set; }
            public string    timestamp { get; set; }
            public string user_id { get; set; }
            public string username { get; set; }
            public string text { get; set; }
            public string trigger_word { get; set; }
        }
    }
}
