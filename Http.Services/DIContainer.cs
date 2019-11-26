using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Http.Services
{
    public static class DIContainer
    {
        public static void UseServices(this IServiceCollection services)
        {
            services.AddHttpClient<IPostService, PostService>();
        }
    }
}
