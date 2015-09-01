using Castle.Core;
using System.Threading;

namespace Method.Intercetption
{
    [Interceptor(typeof(ConsoleLoggingInterceptor))]
    public class Service : IService
    {
        public void Do()
        {
            Thread.Sleep(3000);
        }
    }

    public interface IService
    {
        void Do();
    }
}
