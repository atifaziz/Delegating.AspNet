#region Copyright (C) 2017 Atif Aziz. All rights reserved.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
//
#endregion

namespace Delegating.AspNet
{
    using System;
    using System.Web;

    static partial class Delegate
    {
        public static IHttpHandler HttpHandler(Action<HttpContext> requestProcessor) =>
            new DelegatingHttpHandler(requestProcessor);

        public static IHttpModule HttpModule(Func<HttpApplication, IDisposable> initializer) =>
            new DelegatingHttpModule(initializer);
    }
}

#if ASYNC_HTTP_HANDLER

namespace Delegating.AspNet
{
    using System;
    using System.Threading.Tasks;
    using System.Web;

    static partial class Delegate
    {
        public static HttpTaskAsyncHandler HttpTaskAsyncHandler(Func<HttpContext, Task> requestProcessor) =>
            new DelegatingHttpTaskAsyncHandler(requestProcessor);
    }
}

#endif
