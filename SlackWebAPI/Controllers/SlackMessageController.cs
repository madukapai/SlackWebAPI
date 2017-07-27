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
            string strUrl = "[Slack Web Hook Url]";
            string strResult = this.CallAPI(strUrl, "POST", JsonConvert.SerializeObject(query), out code);
            return Request.CreateResponse(code, strResult);
        }

        /// <summary>
        /// 呼叫WebAPI
        /// </summary>
        /// <param name="strUrl"></param>
        /// <param name="strHttpMethod"></param>
        /// <param name="strPostContent"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        protected string CallAPI(string strUrl, string strHttpMethod, string strPostContent, out HttpStatusCode code)
        {
            HttpWebRequest request = HttpWebRequest.Create(strUrl) as HttpWebRequest;
            request.Method = strHttpMethod;
            code = HttpStatusCode.OK;

            if (strPostContent != "" && strPostContent != string.Empty)
            {
                request.KeepAlive = true;
                request.ContentType = "application/json";

                byte[] bs = Encoding.UTF8.GetBytes(strPostContent);
                Stream reqStream = request.GetRequestStream();
                reqStream.Write(bs, 0, bs.Length);
            }

            string strReturn = "";
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var respStream = response.GetResponseStream();
                strReturn = new StreamReader(respStream).ReadToEnd();
            }
            catch (Exception e)
            {
                strReturn = e.Message;
                code = HttpStatusCode.NotFound;
            }

            return strReturn;
        }

        /// <summary>
        /// 傳入Slack訊息的物件模型
        /// </summary>
        public class SlackMessageQuery
        {
            public string text { get; set; }
        }
    }
}
