namespace DecorationMarket.Middleware
{
    public class ResponseMiddleware
    {
        private readonly RequestDelegate next;

        public ResponseMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch(Exception ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new { Success = false, ex.Message });
            }
        }
    }
}
