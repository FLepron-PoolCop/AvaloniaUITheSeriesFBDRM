using AvaloniaUITheSeriesFBDRM.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaUITheSeriesFBDRM.ViewModels;

public partial class SecretViewModel : ViewModelBase
{
    [ObservableProperty] private string _token;

    public SecretViewModel(AuthenticationResult authResult)
    {
        Token = authResult.Token;
    }
}
