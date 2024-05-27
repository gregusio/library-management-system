using BlazorBootstrap;
using library_management_system.Model;

namespace library_management_system.Services;

public class AlertService
{
    public List<ToastMessage> Messages { get; } = [];

    public void ClearMessages()
    {
        Messages.Clear();
    }

    public void ShowOperationResult(EOperationResult result)
    {
        ShowMessage(result.GetToastType(), result.GetMessage());
    }

    public void ShowInfo(string message)
    {
        ShowMessage(ToastType.Info, message);
    }

    public void ShowSuccess(string message)
    {
        ShowMessage(ToastType.Success, message);
    }

    public void ShowWarning(string message)
    {
        ShowMessage(ToastType.Warning, message);
    }

    private void ShowMessage(ToastType toastType, string message)
    {
        Messages.Add(CreateToastMessage(toastType, message));
    }

    private static ToastMessage CreateToastMessage(ToastType toastType, string message)
    {
        return new ToastMessage
        {
            Type = toastType,
            Title = toastType.ToString(),
            HelpText = $"{DateTime.Now}",
            Message = message
        };
    }
}