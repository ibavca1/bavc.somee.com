using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Времменно для теста MySql
using MySql.Data.MySqlClient;

namespace v0._1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            GetConnectionString();
            return View();
        }

        public string GetConnectionString()
        {
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

        public int GetCount()
        {
            return 1;
        }
    }
}
