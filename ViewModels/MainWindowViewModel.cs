using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Controls;
using AvaloniaUITheSeriesFBDRM.Messages;
using AvaloniaUITheSeriesFBDRM.Models;
using AvaloniaUITheSeriesFBDRM.ViewModels.SplitViewPane;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace AvaloniaUITheSeriesFBDRM.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel(IMessenger messenger)
    {
        messenger.Register<MainWindowViewModel, LoginSuccessMessage>(this, (_, message) =>
        {
            CurrentPage = new SecretViewModel(message.Value);
        });

        Items = new ObservableCollection<ListItemTemplate>(_templates);

        SelectedListItem = Items.First(vm => vm.ModelType == typeof(HomePageViewModel));
    }

    private readonly List<ListItemTemplate> _templates =
    [
        new ListItemTemplate(typeof(HomePageViewModel), "HomeRegular", "Home"),
        new ListItemTemplate(typeof(DataAcquisitionPageViewModel), "TextColumnThreeRegular", "Data Acquisition"), //TextColumnThreeRegular
        new ListItemTemplate(typeof(ButtonPageViewModel), "CursorHoverRegular", "Buttons"),
        new ListItemTemplate(typeof(TextPageViewModel), "TextNumberFormatRegular", "Text"),
        new ListItemTemplate(typeof(ValueSelectionPageViewModel), "CalendarCheckmarkRegular", "Value Selection"),
        new ListItemTemplate(typeof(ImagePageViewModel), "ImageRegular", "Images"),
        new ListItemTemplate(typeof(GridPageViewModel), "GridRegular", "Grids"),
        new ListItemTemplate(typeof(DragAndDropPageViewModel), "TapDoubleRegular", "Drang And Drop"),
        //new ListItemTemplate(typeof(CustomSplashScreenViewModel), "BatSplashScreen", "Bat Splash Screen"),
        new ListItemTemplate(typeof(LoginPageViewModel), "LockRegular", "Login Form"),
        new ListItemTemplate(typeof(ChartsPageViewModel), "PollRegular", "Charts"),
    ];

    public MainWindowViewModel() : this(new WeakReferenceMessenger()) { }

    [ObservableProperty]
    private bool _isPaneOpen;

    [ObservableProperty]
    private ViewModelBase _currentPage = new HomePageViewModel();

    [ObservableProperty]
    private ListItemTemplate? _selectedListItem;

    partial void OnSelectedListItemChanged(ListItemTemplate? value)
    {
        if (value is null) return;

        var vm = Design.IsDesignMode
            ? Activator.CreateInstance(value.ModelType)
            : Ioc.Default.GetService(value.ModelType);

        if (vm is not ViewModelBase vmb) return;

        CurrentPage = vmb;
    }

    public ObservableCollection<ListItemTemplate> Items { get; }

    [RelayCommand]
    private void TriggerPane()
    {
        IsPaneOpen = !IsPaneOpen;
    }
}
