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
        switch (result)
        {
            case EOperationResult.Success:
                ShowSuccess("Success");
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
            case EOperationResult.BorrowedBookLimitExceeded:
                ShowInfo("Borrowed book limit exceeded");
                return;
            case EOperationResult.ReservedBookLimitExceeded:
                ShowInfo("Reserved book limit exceeded");
                return;
            case EOperationResult.RenewalLimitReached:
                ShowInfo("Renewal limit reached");
                return;
            default:
                ShowInfo("Unknown error");
                break;
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

    private static ToastMessage CreateToastMessage(ToastType toastType, string message)
    {
        return toastType switch
        {
            ToastType.Info => new ToastMessage
            {
                Type = toastType, Title = "Info", HelpText = $"{DateTime.Now}", Message = message
            },
            ToastType.Success => new ToastMessage
            {
                Type = toastType, Title = "Success", HelpText = $"{DateTime.Now}", Message = message
            },
            _ => new ToastMessage
            {
                Type = toastType, Title = "Warning", HelpText = $"{DateTime.Now}", Message = message
            }
        };
    }
}