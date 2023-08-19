using Microsoft.Extensions.Logging;
using sommar_hobbyprojektet.Data;
using sommar_hobbyprojektet.Services;

namespace sommar_hobbyprojektet;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif
        // statements for adding TodoService as a singleton
        string dbPath = FileAccessHelper.GetLocalFilePath("tododata.db3");
        builder.Services.AddSingleton<TodoService>(s => ActivatorUtilities.CreateInstance<TodoService>(s, dbPath));        
		

		return builder.Build();
	}
}
