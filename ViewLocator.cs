using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using AvaloniaUITheSeriesFBDRM.ViewModels;
using AvaloniaUITheSeriesFBDRM.ViewModels.SplitViewPane;
using AvaloniaUITheSeriesFBDRM.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;

namespace AvaloniaUITheSeriesFBDRM;
public class ViewLocator : IDataTemplate
{
    private readonly Dictionary<Type, Func<Control?>> _locator = new();

    public ViewLocator()
    {
        RegisterViewFactory<MainViewModel, MainWindow>();
        RegisterViewFactory<HomePageViewModel, HomePageView>();
        RegisterViewFactory<DataAcquisitionPageViewModel, DataAcquisitionPageView>();
        RegisterViewFactory<ButtonPageViewModel, ButtonPageView>();
        RegisterViewFactory<TextPageViewModel, TextPageView>();
        RegisterViewFactory<ValueSelectionPageViewModel, ValueSelectionPageView>();
        RegisterViewFactory<ImagePageViewModel, ImagePageView>();
        RegisterViewFactory<GridPageViewModel, GridPageView>();
        RegisterViewFactory<DragAndDropPageViewModel, DragAndDropPageView>();
        RegisterViewFactory<CustomSplashScreenViewModel, CustomSplashScreenView>();
        RegisterViewFactory<LoginPageViewModel, LoginPageView>();
        RegisterViewFactory<SecretViewModel, SecretView>();
        RegisterViewFactory<ChartsPageViewModel, ChartsPageView>();
    }

    public Control Build(object? data)
    {
        if (data is null)
        {
            return new TextBlock { Text = "No VM provided" };
        }

        _locator.TryGetValue(data.GetType(), out var factory);

        return factory?.Invoke() ?? new TextBlock { Text = $"VM Not Registered: {data.GetType()}" };
    }

    public bool Match(object? data)
    {
        return data is ObservableObject;
    }

    private void RegisterViewFactory<TViewModel, TView>()
        where TViewModel : class
        where TView : Control
        => _locator.Add(
            typeof(TViewModel),
            Design.IsDesignMode
                ? Activator.CreateInstance<TView>
                : Ioc.Default.GetService<TView>);
}
