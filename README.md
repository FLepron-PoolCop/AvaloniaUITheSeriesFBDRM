This repository is the conversion on the repository git@github.com:MammaMiaDev/avaloniaui-the-series.git from Mamma Mia Dev / avaloniaui-the-series : YouTube Avalonia tutorial Series https://www.youtube.com/watch?v=1mzM6N4drCU&list=PLJYo8bcmfTDF6ROxC8QMVw9Zr_3Lx4Lgd to a VS Code Torizon project using the Avalonia **UI Frame Buffer** or **Direct Rendering Mode** template and which works on a Verdin i.MX 8M Plus Tordadex's SOM on a Dahlia Board with a 10.1" touchscreen

As soon as you've made a clone of this repo in one of your directories, go in the directory where the files have been downloaded:
1. Add the following Nuget source
```bash
#update package list
sudo apt-get update && sudo apt-get install

#process this command if nuget utility is not yet installed
sudo apt-get install nuget

#add Nuget source https://pkgs.dev.azure.com/dotnet/CommunityToolkit/_packaging/CommunityToolkit-Labs/nuget/v3/index.json
nuget sources Add -Name "CommunityToolkit-Labs" -Source "https://pkgs.dev.azure.com/dotnet/CommunityToolkit/_packaging/CommunityToolkit-Labs/nuget/v3/index.json"

#verify it has been added the the Nuget source repositoris (by default, https://www.nuget.org/api/v2/ is always there)
nuget sources list
Registered Sources:

  1.  https://www.nuget.org/api/v2/ [Enabled]
      https://www.nuget.org/api/v2/
  2.  CommunityToolkit-Labs [Enabled]
      https://pkgs.dev.azure.com/dotnet/CommunityToolkit/_packaging/CommunityToolkit-Labs/nuget/v3/index.json
```
2. Restore projet so that it will download the Nuget packages needed
```bash
dotnet restore
```

```xml
<PackageReference Include="Avalonia" Version="11.0.11" />
<PackageReference Include="Avalonia.Skia" Version="11.0.11" />
<PackageReference Include="Avalonia.Controls.ItemsRepeater" Version="11.0.11" />
<PackageReference Include="Avalonia.LinuxFramebuffer" Version="11.0.11" />
<PackageReference Include="Avalonia.Desktop" Version="11.0.11" />
<PackageReference Include="Avalonia.Themes.Fluent" Version="11.0.11" />
<PackageReference Include="Avalonia.Fonts.Inter" Version="11.0.11" />
<!--Condition below is needed to remove Avalonia.Diagnostics package from build output in Release configuration.-->
<PackageReference Condition="'$(Configuration)' == 'Debug'" Include="Avalonia.Diagnostics" Version="11.0.11" />
<!-- <PackageReference Include="Avalonia.ReactiveUI" Version="11.0.11" /> -->
<PackageReference Include="CommunityToolkit.Labs.Extensions.DependencyInjection" Version="0.1.240305-build.1659"/>
<PackageReference Include="CommunityToolkit.Mvvm" Version="8.2.2" />
<!-- <PackageReference Include="LiveChartsCore" Version="2.0.0-rc2" /> -->
<PackageReference Include="LiveChartsCore.SkiaSharpView.Avalonia" Version="2.0.0-rc2" />
<PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="8.0.0" />
<PackageReference Include="Microsoft.Extensions.Http" Version="8.0.0" />
```

The Avalonia.ReactiveUI is not used because this is the translation of the project of Mamma Mia Dev / avaloniaui-the-series, but one of the improvements is to migrate this project to use Avalonia.ReactiveUI.
