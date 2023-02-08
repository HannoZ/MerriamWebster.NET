namespace MerriamWebster.NET.Example
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews()
                .AddRazorRuntimeCompilation(); // it's ok to do this in a demo app ;-)

            builder.Services.AddMemoryCache();

            // a real app would have the config section with the api key in appsettings
            // but for this demo app the key should be provided as part of the search request
            var config = new MerriamWebsterConfig();
            builder.Services.RegisterMerriamWebster(config);

            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();
            
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}