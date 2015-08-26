using System.Reflection.Emit;
using System.Web.Http;
using MVC.AOP;

namespace MVC.Controllers
{
    public class WebApiController : ApiController
    {
        [LogAspect]
        [HttpGet]
        public int CreateItem()
        {
            int i = 13;
            var test = new LogTest();
            for (int v = 0; v < 2000; v++)
            {
                test.Test(v);
            }
            return i;
        }

    /*    [HttpGet]
        public void CreateItem1()
        {
            int i = 0;

        }*/
    }
}
