using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
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
            ///TODO: Thumbail  System.Drawing.Common
            ///
            var pfad = AppDomain.CurrentDomain.GetData("wwwroot").ToString() + img;
           // await context.Response.SendFileAsync(pfad);



            using (FileStream sr = new FileStream(pfad, FileMode.Open, FileAccess.Read))
            using (var image = new Bitmap(sr))
            {
                var resized = new Bitmap(300, 200);
                using (var graphics = Graphics.FromImage(resized))
                {
                    graphics.CompositingQuality = CompositingQuality.HighSpeed;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.DrawImage(image, 0, 0, 300, 200);
                    //resized.Save(...., ImageFormat.Png);
                    var ms = new MemoryStream();
                    resized.Save(ms, ImageFormat.Png);
                    context.Response.Body.Write(ms.ToArray());
                   

                }
            }
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
