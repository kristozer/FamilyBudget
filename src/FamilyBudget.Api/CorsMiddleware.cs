using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FamilyBudget.Api
{
    public class CorsMiddleware
    {
        private readonly RequestDelegate next;

        public CorsMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        
        public Task InvokeAsync(HttpContext context)
        {
            string originHeader = context.Request.Headers["Origin"];

            context.Response.Headers.Add("Access-Control-Allow-Origin", originHeader ?? "*");
            context.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            context.Response.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");

            if (context.Request.Method == "OPTIONS")
            {
                context.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, PATCH");
                context.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept, Cache-control, pragma");
                context.Response.Headers.Add("Access-Control-Max-Age", "1728000");
                return context.Response.WriteAsync("");
            }

            return next(context);
        }
    }
}