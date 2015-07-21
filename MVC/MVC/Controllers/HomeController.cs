using System;
using System.IO;
using System.Web.Mvc;
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
        public ActionResult InputFile(Graph i)
        {
            var file = Request.Files["inputFile"];
            if (file == null) return null;
            using (var reader = new StreamReader(file.InputStream))
            {
                var dataFromFile = reader.ReadToEnd();
                var str = dataFromFile;
                var strs = str.Split(' ');
                var size = (int) Math.Sqrt(strs.Length);
                var array=new double[size,size];
                for (var k = 0; k < size; k++)
                {
                    for (var n = 0; n < size; n++)
                    {
                        array[k,n] = double.Parse(strs[k*size+n]);
                    }
                }
                return Json(array);

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
