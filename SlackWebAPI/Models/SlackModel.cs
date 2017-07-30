using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlackWebAPI.Models
{
    public class SlackModel
    {
        /// <summary>
        /// 傳入Slack訊息的物件模型
        /// </summary>
        public class SlackMessageQuery
        {
            public string text { get; set; }
        }

        public class SlackOutgoingContent
        {
            public string token { get; set; }
            public string team_id { get; set; }
            public string team_domain { get; set; }
            public string channel_id { get; set; }
            public string channel_name { get; set; }
            public string timestamp { get; set; }
            public string user_id { get; set; }
            public string username { get; set; }
            public string text { get; set; }
            public string trigger_word { get; set; }
        }
    }
}