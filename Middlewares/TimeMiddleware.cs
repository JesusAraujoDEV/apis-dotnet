public class TimeMiddlware
{
    readonly RequestDelegate _next;

    public TimeMiddlware(RequestDelegate nextRequest)
    {
        _next = nextRequest;
    }

    public async Task Invoke(HttpContext context)
    {
        await _next(context);

        if (context.Request.Query.Any(p => p.Key == "time"))
        {
            await context.Response.WriteAsync($"Current Time: {DateTime.Now}");
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