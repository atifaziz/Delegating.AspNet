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

    partial class DelegatingHttpHandler : IHttpHandler
    {
        readonly Action<HttpContext> _requestProcessor;

        public DelegatingHttpHandler(Action<HttpContext> requestProcessor) =>
            _requestProcessor = requestProcessor ?? throw new ArgumentNullException(nameof(requestProcessor));

        public virtual void ProcessRequest(HttpContext context) =>
            _requestProcessor(context);

        public virtual bool IsReusable => false;
    }
}

#if ASYNC_HTTP_HANDLER

namespace Delegating.AspNet
{
    using System;
    using System.Threading.Tasks;
    using System.Web;

    partial class DelegatingHttpTaskAsyncHandler : HttpTaskAsyncHandler
    {
        readonly Func<HttpContext, Task> _requestProcessor;

        public DelegatingHttpTaskAsyncHandler(Func<HttpContext, Task> requestProcessor) =>
            _requestProcessor = requestProcessor ?? throw new ArgumentNullException(nameof(requestProcessor));

        public override Task ProcessRequestAsync(HttpContext context) =>
            _requestProcessor(context);
    }
}

#endif
