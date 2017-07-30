using System;
using System.Collections.Generic;
using System.Linq;


namespace SlackWebAPI.Controllers
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Newtonsoft.Json;
    using System.IO;
    using System.Text;
    using static SlackWebAPI.Models.SlackModel;

    public class SlackMessageController : ApiController
    {
        HttpStatusCode code = HttpStatusCode.OK;

        /// <summary>
        /// Post進Slack訊息的動作
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public HttpResponseMessage Post(SlackMessageQuery query)
        {
            string strResult = new SlackMessageObj().SendMessage(query);
            return Request.CreateResponse(code, strResult);
        }
    }
}
