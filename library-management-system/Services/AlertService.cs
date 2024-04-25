using BlazorBootstrap;
using library_management_system.Model;

namespace library_management_system.Services;

public class AlertService
{
    public List<ToastMessage> Messages { get; } = new();

    public void ClearMessages()
    {
        Messages.Clear();
    }

    public void ShowOperationResult(EOperationResult result)
    {
        switch (result)
        {
            case EOperationResult.Success:
                ShowSuccess("Book borrowed");
                return;
            case EOperationResult.DatabaseError:
                ShowWarning("Database error");
                return;
            case EOperationResult.UnexpectedError:
                ShowWarning("Unexpected error");
                return;
            case EOperationResult.NoAvailableCopies:
                ShowInfo("No available copies");
                return;
        }
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

    private ToastMessage CreateToastMessage(ToastType toastType, string message)
    {
        switch (toastType)
        {
            case ToastType.Info:
                return new ToastMessage
                {
                    Type = toastType,
                    Title = "Info",
                    HelpText = $"{DateTime.Now}",
                    Message = message
                };
            case ToastType.Success:
                return new ToastMessage
                {
                    Type = toastType,
                    Title = "Success",
                    HelpText = $"{DateTime.Now}",
                    Message = message
                };
            default:
                return new ToastMessage
                {
                    Type = toastType,
                    Title = "Warning",
                    HelpText = $"{DateTime.Now}",
                    Message = message
                };
        }
    }
}