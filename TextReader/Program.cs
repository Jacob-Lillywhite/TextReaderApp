using System;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms;
using TextReader.Services;
using System.Runtime.InteropServices;

namespace TextReader
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var ttsService = serviceProvider.GetRequiredService<ITtsService>();
            var formCapture = serviceProvider.GetRequiredService<ISnippingForm>();
            var formOverlay = new MainForm(formCapture, ttsService);
            
            Application.Run(formOverlay);
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<ITtsService, TtsService>();
            services.AddTransient<ISnippingForm, SnippingForm>();
        }
    }
}
