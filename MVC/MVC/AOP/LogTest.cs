namespace MVC.AOP
{
    public class LogTest
    {
        [LogAspect]
        public int Test(int i)
        {
            return i*2;
        }
    }
}