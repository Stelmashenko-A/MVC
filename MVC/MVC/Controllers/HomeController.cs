using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Web.Mvc;
using DiGraph.MMAS;
using MVC.Models;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Graph g)
        {
            return null;
        }

        public ActionResult Input(Graph i)
        {
            return View("Index", i);
        }

        [HttpPost]
        public string InputFile(Graph i)
        {
            var file = Request.Files["inputFile"];
            if (file == null) return "";
            using (var reader = new StreamReader(file.InputStream))
            {
                var dataFromFile = reader.ReadToEnd();
                var str = dataFromFile;
                var minMaxAntSystem = new MinMaxAntSystem {Alfa = 0.5, Beta = 0.5, Ro = 0.1};

                List<int> path;
                double length;
                minMaxAntSystem.FindPath(CreateStreamFromString(str), out path, out length);
                return length.ToString(CultureInfo.InvariantCulture);
            }
        }

        private static Stream CreateStreamFromString(string str)
        {
            Stream stream = new MemoryStream();
            var sw = new StreamWriter(stream);
            sw.Write(str);
            sw.Flush();
            stream.Position = 0;
            return stream;
        }
    }

}
