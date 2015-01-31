using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Text;

namespace v0._1.Models.Extensions
{
    public class Helper
    {

    }

    public class WebPage
    {
        private WebContext _context;
        private Uri _uri;
        private string _content;
    }

    public class WebContext
    {
        CookieContainer _cookies;
    }

    public class BavcWebRequest
    {
        private WebPage _page;

        /// <summary>
        /// Получить страницу (текстом)
        /// </summary>
        /// <param name="uri">Ссылка на страницу</param>
        /// <returns>string (content)</returns>
        public string GetPageContent(Uri uri,Encoding encoding)
        {
            string result;
            HttpWebResponse response = GetAnser(uri);

            using (StreamReader stream=new StreamReader(response.GetResponseStream(), encoding))
            {
                result = stream.ReadToEnd();
            }
            return result;
        }

        /// <summary>
        /// Получить страницу (текстом)
        /// </summary>
        /// <param name="uri">Ссылка на страницу</param>
        /// <returns>WebPage (class)</returns>
        public WebPage GetPage(Uri uri)
        {
            return null;
        }

        /// <summary>
        /// Получить ответ сервера
        /// </summary>
        /// <param name="uri">Ссылка</param>
        /// <returns></returns>
        private HttpWebResponse GetAnser(Uri uri)
        {
            HttpWebRequest _request;
            HttpWebResponse _response;
            _request = (HttpWebRequest)WebRequest.Create(uri);
            _response = (HttpWebResponse)_request.GetResponse();
            return _response;
        }
    }

}