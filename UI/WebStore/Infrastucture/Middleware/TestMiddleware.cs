using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebStore.Infrastucture.Middleware
{
    public class TestMiddleware
    {
        private readonly RequestDelegate _NextAction;

        public TestMiddleware(RequestDelegate NextAction)
        {
            _NextAction = NextAction;
        }

        public async Task Invoke(HttpContext context)
        {

            await _NextAction(context);

        }
    }
}
