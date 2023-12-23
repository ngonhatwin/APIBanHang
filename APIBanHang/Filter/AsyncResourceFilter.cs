using Microsoft.AspNetCore.Mvc.Filters;

namespace APIBanHang.Filter
{
    public class AsyncResourceFilter : IAsyncResourceFilter
    {
        private readonly ILogger<AsyncResourceFilter> _logger;

        public AsyncResourceFilter(ILogger<AsyncResourceFilter> logger)
        {
            _logger = logger;
        }
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            _logger.LogInformation($"Đang lấy tài nguyên");
            await next();
            _logger.LogInformation($"Đã lấy tài nguyên");
        }
    }
}
