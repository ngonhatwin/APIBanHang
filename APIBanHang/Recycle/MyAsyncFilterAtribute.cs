//using Microsoft.AspNetCore.Mvc.Filters;

//namespace APIBanHang.Recycle
//{
//    public class MyAsyncFilterAtribute
//    {
//        private readonly string _name;
//        public MyAsyncFilterAtribute(string name)
//        {
//            _name = name;
//        }
//        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
//        {
//            Console.WriteLine($"Bo loc khoi dong -Truoc khi thuc thi khong dong bo - {_name}");
//            await next();
//            Console.WriteLine($"Bo loc khoi dong -Sau khi thuc thi khong dong bo -{_name}");

//        }
//    }
//}
