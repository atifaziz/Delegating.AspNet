namespace Delegating.AspNet
{
    public static partial class Delegate {}
    public partial class DelegatingHttpHandler {}
#if ASYNC_HTTP_HANDLER
    public partial class DelegatingHttpTaskAsyncHandler {}
#endif
    public partial class DelegatingHttpModule {}
}
