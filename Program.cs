using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
//²using Avalonia.ReactiveUI;
using Avalonia.Logging;
using Avalonia.Controls;
using Avalonia.Skia;
using Avalonia.Dialogs;

namespace AvaloniaUITheSeriesFBDRM;

class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static int Main(string[] args)
    {
        var builder = BuildAvaloniaApp();

        if (Environment.GetEnvironmentVariable("AVALONIA_FB") == "true") {
            // avalonia direct to framebuffer
            return builder.StartLinuxFbDev(args, "/dev/fb0", 1);
        } else if (Environment.GetEnvironmentVariable("AVALONIA_DRM") == "true") {
            // let's use the DRM with EGL
            // FIXME: the index of the /dev/dri/cardX is not always 1 (it's depending on the hardware)
            return builder.StartLinuxDrm(args, "/dev/dri/card0", 1);
        }

        throw new Exception("Please set AVALONIA_FB or AVALONIA_DRM environment variables to true");
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .UseSkia()
            .LogToTrace()
            .UseManagedSystemDialogs();

        // => AppBuilder.Configure<App>()
        //     .UsePlatformDetect()
        //     .UseSkia()
        //     .WithInterFont()
        //     .UseReactiveUI()
        //     .LogToTrace()
        //     .UseManagedSystemDialogs();

}
