using Microsoft.AspNetCore.Mvc.Filters;

namespace APIBanHang.Filter
{
    public class AsyncResultFilter : IAsyncResultFilter
    {
        private readonly ILogger<AsyncResultFilter> logger_;
        public AsyncResultFilter(ILogger<AsyncResultFilter> logger) 
        { 
            logger_ = logger;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            logger_.LogInformation($"kết quả bộ lọc trước.");
            await next();
            logger_.LogInformation($"kết quả bộ lọc sau.");
        }
    }
}
