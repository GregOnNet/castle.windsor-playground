using System;
using System.Diagnostics;
using Castle.DynamicProxy;

namespace Method.Intercetption
{
    [Serializable]
    public class ConsoleLoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            invocation.Proceed();

            stopwatch.Stop();

            Console.WriteLine("Operation finished after {0} ms", stopwatch.ElapsedMilliseconds);
        }
    }
}
