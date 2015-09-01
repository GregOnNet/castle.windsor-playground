# Interceptors with Castle.Windsor

This demo contains a simple console application.
The component `Service` uses a interceptor called `ConsoleLoggingInterceptor` used to setup a simple logging.

My goal was to remove the [crosscutting concern](https://msdn.microsoft.com/en-us/library/ee658105.aspx) of logging. Looking for an alternative to [PostSharp](https://www.postsharp.net) I read about [Castle.Windsor](https://github.com/castleproject/Windsor)'s concept of [DynamicProxy](https://github.com/castleproject/Core/blob/master/docs/dynamicproxy.md). 

## Setup

```cmd
$ .paket/paket.bootstrapper.exe
$ .paket/paket.exe install
$
# After that run the project in Visual Studio
```

## Benefit

### Before

Without interception I needed to write the code for logging where the logic is defined.

```csharp
public class Service : IService
{
  public void Do()
  {
    var stopwatch = new Stopwatch();
    stopwatch.Start();

    Thread.Sleep(3000);

    stopwatch.Stop();
    Console.WriteLine("Operation finished after {0} ms", stopwatch.ElapsedMilliseconds);
  }
}
```

### After

The logging mechanism is completly removed form the `Service`...

```csharp
public class Service : IService
{
  public void Do()
  {
    Thread.Sleep(3000);
  }
}
```

... It has been moved to the interceptor.
`invocation.Proceed` calls the intercepted method (In this case `Do()`)...

```csharp
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
```

... The interceptor can be plugged in when the `Component` is registered in the `WindsorContainer`.

```csharp
container.Register(
  // Register the interceptor
  Component
    .For<ConsoleLoggingInterceptor>(),
  // Register the service
  Component
    .For<IService>()
    .ImplementedBy<Service>()
    .Interceptors<ConsoleLoggingInterceptor>());
```
