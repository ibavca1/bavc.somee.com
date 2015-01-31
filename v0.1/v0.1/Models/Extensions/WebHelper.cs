using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using HtmlAgilityPack;

namespace v0._1.Models.Extensions
{
    #region WebPage
    public class WebPage
    {
        private WebContext _context;
        private Uri _uri;
        private string _content;
        private Page _page;
    }
    #endregion

    #region Page
    public class Page
    {
        private string _head;
        private string _body;
        private string _footer;
        private List<Tuple<int,string>> _options;
    }
    #endregion

    #region Класс контекста страницы
    public class WebContext
    {
        CookieContainer _cookies;
    }
    #endregion

    #region Класс запроса к серверу
    public class BavcWebRequest
    {
        #region Переменные
        private WebPage _page;
        private Encoding _encoding;
        private string _content;
        private Uri _uri;
        #endregion

        #region Содержание страницы в HTML
        /// <summary>
        /// Получить страницу (текстом)
        /// </summary>
        /// <param name="uri">Ссылка на страницу</param>
        /// <returns>string (content)</returns>
        public string GetPageContent(Uri uri,Encoding encoding)
        {
            string result;
            //добавил ссылку
            _uri = uri;
            HttpWebResponse response = GetAnser(uri);

            using (StreamReader stream=new StreamReader(response.GetResponseStream(), encoding))
            {
                result = stream.ReadToEnd();
            }
            return result;
        }
        #endregion

        #region Пока не работает (заглушка)
        /// <summary>
        /// Получить страницу (текстом)
        /// </summary>
        /// <param name="uri">Ссылка на страницу</param>
        /// <returns>WebPage (class)</returns>
        public WebPage GetPage(Uri uri)
        {
            return null;
        }
        #endregion

        #region Запрос к серверу (возвращает ответ)
        /// <summary>
        /// Получить ответ сервера
        /// </summary>
        /// <param name="uri">Ссылка</param>
        /// <returns>HttpWebResponse</returns>
        private HttpWebResponse GetAnser(Uri uri)
        {
            HttpWebRequest _request;
            HttpWebResponse _response;
            _request = (HttpWebRequest)WebRequest.Create(uri);
            _response = (HttpWebResponse)_request.GetResponse();
            return _response;
        }
        #endregion

        #region Получить заголовок
        public void GetHeadDocument(Encoding encoding)
        {
            _uri = new Uri("http://randstuff.ru/number/");
            HtmlDocument doc = new HtmlDocument();
            string content = GetPageContent(_uri, encoding);
            encoding = doc.DetectEncodingHtml(content);
            doc.LoadHtml(content);
            GetHeadDocument(doc);
        }

        public HtmlNode GetHeadDocument(HtmlDocument doc)
        {
            var encoding = doc.DeclaredEncoding;
            HtmlNode head = doc.DocumentNode.SelectSingleNode(@"//head");
            var tt = head.InnerText;
            StreamReader reader = new StreamReader(new MemoryStream(encoding.GetBytes(tt)), Encoding.Default);
            tt = reader.ReadToEnd();
            StreamWriter writer = new StreamWriter("E:\\Temp\\utf.txt", false, Encoding.UTF8);
            return head;
        }
        #endregion
    }
    #endregion
}