using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

//Времменно для теста MySql
using MySql.Data.MySqlClient;

using v0._1.Models.Extensions;

namespace v0._1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            //GetConnectionString();
            BavcWebRequest bavcRequest = new BavcWebRequest();
            Test();
            string content = bavcRequest.GetPageContent(new Uri("http://randstuff.ru/number/"), Encoding.Default);
            return View((Object)GetConnectionString());
        }

        public string GetConnectionString()
        {
            Test();
            System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/");
            System.Configuration.ConnectionStringSettings connString;
            if (0 < rootWebConfig.ConnectionStrings.ConnectionStrings.Count)
            {
                connString =
                    rootWebConfig.ConnectionStrings.ConnectionStrings["db_9ba681_somee"];
                if (null != connString)
                    return connString.ConnectionString;
                else
                    return "Error";
            }
            return null;
        }

        public void Test()
        {
            BavcWebRequest bavcRequest = new BavcWebRequest();
            bavcRequest.GetHeadDocument(Encoding.Default);
        }
        public int GetCount()
        {
            return 1;
        }
    }
}
