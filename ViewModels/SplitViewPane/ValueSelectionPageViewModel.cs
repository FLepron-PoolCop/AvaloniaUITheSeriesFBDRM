using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaUITheSeriesFBDRM.ViewModels.SplitViewPane;

public partial class ValueSelectionPageViewModel : ViewModelBase
{
    [ObservableProperty]
    private bool _isValueSelectionEnabled = true;

    [ObservableProperty]
    private int _sliderValue;
}
