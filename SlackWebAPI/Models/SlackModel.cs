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
    }
}