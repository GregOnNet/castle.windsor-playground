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
