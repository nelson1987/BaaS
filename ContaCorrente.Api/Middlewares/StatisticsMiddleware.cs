namespace ContaCorrente.Api.Middlewares;

public class StatisticsMiddleware
{
    private readonly RequestDelegate? _next;
    //private readonly IDateTimeService _dateTimeService;
    //private readonly IConnectionHelper

    public StatisticsMiddleware(
        RequestDelegate? next)
    {
        _next = next;
    }
    public async void InvokeAsync(HttpContext httpContext)
    {
        //var visit = new Visit();
        //if (httpContext.Connection.RemoteIpAddress != null)
        //{
        //    visit.Ip = httpContext.Connection.RemoteIpAddress.ToString();
        //    visit.CountryName = await _conn
        //}
        await _next(httpContext);
    }
}
