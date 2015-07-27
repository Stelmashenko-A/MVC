using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using DiGraph.MMAS;
using MVC.Models;
using MVC.Repository;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IAlgorithm algorithm)
        {
            Algorithm = algorithm;
            ArrayRepository r = new ArrayRepository();
            var str = r.Get(1);
            Console.Write(str);
            var strs = r.GetAll();
        }

        // GET: Home
        private IAlgorithm Algorithm { get; set; }
        
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

        /*[HttpPost]
        public ActionResult GetNames()
        {
            return Json(Repository.Get().ToArray());
        }*/
        public ActionResult Input(Graph i)
        {
            Algorithm.Alfa = double.Parse(i.Alpha);
            Algorithm.Beta = double.Parse(i.Beta);
            Algorithm.Ro = double.Parse(i.Ro);
            List<int> path;
            double length;
            Algorithm.FindPath(CreateStreamFromArray(i.Array.ToArray()), out path, out length);
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
                var array = new double[size, size];
                for (var k = 0; k < size; k++)
                {
                    for (var n = 0; n < size; n++)
                    {
                        array[k, n] = double.Parse(strs[k*size + n]);
                    }
                }
                return Json(array);

            }
        }

        private static Stream CreateStreamFromArray(double[] arr)
        {
            Stream stream = new MemoryStream();
            var sw = new StreamWriter(stream);
            foreach (var VARIABLE in arr)
            {
                sw.Write(VARIABLE);
                sw.Write(" ");
            }
            sw.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
