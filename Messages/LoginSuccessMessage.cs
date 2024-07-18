using AvaloniaUITheSeriesFBDRM.Services;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace AvaloniaUITheSeriesFBDRM.Messages;

public class LoginSuccessMessage(AuthenticationResult result) : ValueChangedMessage<AuthenticationResult>(result);
