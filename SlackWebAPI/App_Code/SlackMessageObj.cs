using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using static SlackWebAPI.Models.SlackModel;

namespace SlackWebAPI
{
    public class SlackMessageObj
    {
        HttpStatusCode code = HttpStatusCode.OK;

        public string SendMessage(SlackMessageQuery query)
        {
            string strUrl = "[Slack incomeing Web Hook Url]";
            string strResult = this.CallAPI(strUrl, "POST", JsonConvert.SerializeObject(query), out code);

            return strResult;
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

    }
}