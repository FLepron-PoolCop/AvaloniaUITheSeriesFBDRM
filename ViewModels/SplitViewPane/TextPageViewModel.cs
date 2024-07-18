using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaUITheSeriesFBDRM.ViewModels.SplitViewPane;

public partial class TextPageViewModel : ViewModelBase
{
    [ObservableProperty]
    private bool _isTextEnabled = true;
}
