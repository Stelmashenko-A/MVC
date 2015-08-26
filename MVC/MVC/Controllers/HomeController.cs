using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using DiGraph.MMAS;
using MVC.AOP;
using MVC.Models;
using MVC.Repository;

namespace MVC.Controllers
{
    [LogAspect]
    [Authorize]
    public class HomeController : ErrorController
    {
        public HomeController(IAlgorithm algorithm, IArrayRepository arrayRepository,
            IParametersRepository parametersRepository, IResultRepository resultRepository)
        {
            Algorithm = algorithm;
            _arrayRepository = arrayRepository;
            _parametersRepository = parametersRepository;
            _resultRepository = resultRepository;
        }

        // GET: Home
        private IAlgorithm Algorithm { get; set; }
        private IResultRepository _resultRepository;
        private readonly IArrayRepository _arrayRepository;
        private readonly IParametersRepository _parametersRepository;


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

        public ActionResult Index(Params p)
        {
            return View();
        }

        public ActionResult Error()
        {
            return View("Error");
        }

        [HttpPost]
        public ActionResult Input(Graph i)
        {
            if (!i.IsValid) return View("Index", i);
            var arrays = new Arrays {Matrix = ConvertListToMatrix(i.Array)};
            arrays.Id = arrays.GetHashCode();
            _arrayRepository.Add(arrays);
            return View("Index", i);
        }

        [HttpPost]
        public ActionResult InputParams(Parameters i)
        {

                throw new NotImplementedException();

            i.Id = i.GetHashCode();
            _parametersRepository.Add(i);
            return View("Index");
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

        private static List<List<double>> ConvertListToMatrix(List<double> arr)
        {
            var count = (int) Math.Sqrt(arr.Count);
            var result = new List<List<double>>();
            for (var i = 0; i < count; i++)
            {
                var tmp = new List<double>(arr.GetRange(i*count, count));
                result.Add(tmp);
            }
            return result;

        }

        protected override void OnException(ExceptionContext filterContext)
        {
            Exception exception = filterContext.Exception;
            //Logging the Exception
            filterContext.ExceptionHandled = true;


            filterContext.Result = this.RedirectToAction("Error", "Home");

        }
    }
}
