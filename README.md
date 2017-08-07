# Delegating.AspNet

[![Build Status][build-badge]][builds]
[![NuGet][nuget-badge]][nuget-pkg]
[![MyGet][myget-badge]][edge-pkgs]

This is a .NET class library that provides delegating implementations of
common interfaces, typically those with a single method only, used in ASP.NET
applications. The actual implementation is delegated to an `Action` or a
function (`Func<>`, `Func<,>` and so on depending on the arity of the original
method).

See also the [Delegating][Delegating] library.


## Motivation

The .NET Framework has many interfaces with a single method, like
[`IDisposable`][IDisposable], that require the same and tedious boilerplate
class declaration and code each time. With closures and lambdas, such
interfaces can be implemented once and which delegate the actual
implementation to, well (surprise, surprise), [a delegate][delegate]! When
such interfaces need to be supplied, an implementation can be expressed more
succinctly.

Yes, this will be somewhat useless the day C# gains [object expressions like
F#][fsobjexpr].


## Implementations

Delegated implementations are available for the following interfaces:

- [`IHttpHandler`][IHttpHandler]
- [`IHttpAsyncHandler`][IHttpAsyncHandler]
- [`IHttpModule`][IHttpModule]


## Building

Building the solution requires MSBuild 15. On a Windows host, run `build.cmd`
to build the solution and `pack.cmd` to build and pack.


[build-badge]: https://img.shields.io/appveyor/ci/raboof/delegating-aspnet.svg
[myget-badge]: https://img.shields.io/myget/raboof/v/Delegating.AspNet.svg?label=myget
[edge-pkgs]: https://www.myget.org/feed/raboof/package/nuget/Delegating.AspNet
[nuget-badge]: https://img.shields.io/nuget/v/Delegating.AspNet.svg
[nuget-pkg]: https://www.nuget.org/packages/Delegating.AspNet
[builds]: https://ci.appveyor.com/project/raboof/delegating.aspnet
[IDisposable]: https://docs.microsoft.com/en-us/dotnet/api/system.idisposable
[Delegating]: https://www.nuget.org/packages/Delegating
[IHttpHandler]: https://docs.microsoft.com/en-us/dotnet/api/system.web.ihttphandler
[IHttpAsyncHandler]: https://docs.microsoft.com/en-us/dotnet/api/system.web.ihttpasynchandler
[IHttpModule]: https://docs.microsoft.com/en-us/dotnet/api/system.web.ihttpmodule
[delegate]: https://docs.microsoft.com/en-us/dotnet/api/system.delegate
[fsobjexpr]: https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/object-expressions
