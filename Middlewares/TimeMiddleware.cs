public class TimeMiddlware
{
    readonly RequestDelegate _next;

    public TimeMiddlware(RequestDelegate nextRequest)
    {
        _next = nextRequest;
    }

    public async Task Invoke(HttpContext context)
    {
        

        if (context.Request.Query.Any(p => p.Key == "time"))
        {
            await context.Response.WriteAsync($"Current Time: {DateTime.Now}");
        }

        if (!context.Response.HasStarted)
        {
            await _next(context);
        }
        
    }
}

public static class TimeMiddlwareExtensions
{
    public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<TimeMiddlware>();
    }
}