using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaUITheSeriesFBDRM.ViewModels.SplitViewPane;

public partial class ButtonPageViewModel : ViewModelBase
{
    [ObservableProperty]
    private bool _isButtonEnabled = true;
}
