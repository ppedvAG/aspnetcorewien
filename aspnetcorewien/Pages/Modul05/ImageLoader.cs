using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcorewien.Pages.Modul05
{
    public class ImageLoader
    {
        public ImageLoader(RequestDelegate next)
        {

        }
        public async Task Invoke(HttpContext context)
        {
            var img = context.Request.Query["img"][0];
            ///TODO: Thumbail 
            ///
            var pfad = AppDomain.CurrentDomain.GetData("wwwroot").ToString() + img;
            await context.Response.SendFileAsync(pfad);

        }



    }
    public static class ImageLoaderExtensions
    {
        public static IApplicationBuilder UseImageLoader(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ImageLoader>();
        }
    }

}
