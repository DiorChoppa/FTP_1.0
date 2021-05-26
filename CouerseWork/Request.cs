using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouerseWork
{
    class Request
    {
        public static string Post(string rqst, string php)
        {
            string resource = "http://localhost/CW/" + php;

            HttpWebRequest webRequest = WebRequest.CreateHttp(resource);
            webRequest.Method = "POST";

            var content = Encoding.UTF8.GetBytes(rqst);
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ContentLength = content.Length;
            var resp = webRequest.GetRequestStream();
            resp.Write(content, 0, content.Length);
            resp.Close();

            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            string Response;
            Stream st = webResponse.GetResponseStream();
            StreamReader sr = new StreamReader(st);
            Response = sr.ReadToEnd();

            return Response;
        }
    }
}
