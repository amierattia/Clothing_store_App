using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;
using Tito_Store.DataBase;
namespace Tito_Store
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            DBContext oDBContext = new DBContext();
            oDBContext.Database.EnsureCreated();
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureSyncfusionCore()
                 .ConfigureFonts(fonts =>
                 {
                     fonts.AddFont("Cairo-Black.ttf", "Cairo-Black");
                     fonts.AddFont("Cairo-Medium.ttf", "Cairo-Medium");
                     fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                     fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                 });
               

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
