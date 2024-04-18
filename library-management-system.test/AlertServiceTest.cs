using BlazorBootstrap;
using library_management_system.Services;

namespace library_management_system.test;

public class AlertServiceTest
{
    [Fact]
    public void TestShowInfo()
    {
        var alert = new AlertService();
        alert.ShowInfo("Info");
        Assert.Single(alert.Messages);
        Assert.Equal("Info", alert.Messages[0].Message);
        Assert.Equal(ToastType.Info, alert.Messages[0].Type);
    }

    [Fact]
    public void TestShowSuccess()
    {
        var alert = new AlertService();
        alert.ShowSuccess("Success");
        Assert.Single(alert.Messages);
        Assert.Equal("Success", alert.Messages[0].Message);
        Assert.Equal(ToastType.Success, alert.Messages[0].Type);
    }

    [Fact]
    public void TestShowWarning()
    {
        var alert = new AlertService();
        alert.ShowWarning("Warning");
        Assert.Single(alert.Messages);
        Assert.Equal("Warning", alert.Messages[0].Message);
        Assert.Equal(ToastType.Warning, alert.Messages[0].Type);
    }

    [Fact]
    public void TestClearMessages()
    {
        var alert = new AlertService();
        alert.ShowWarning("Warning");
        alert.ClearMessages();
        Assert.Empty(alert.Messages);
    }

    [Fact]
    public void TestMultipleMessages()
    {
        var alert = new AlertService();
        alert.ShowWarning("Warning");
        alert.ShowInfo("Info");
        alert.ShowSuccess("Success");

        Assert.Equal(3, alert.Messages.Count);

        Assert.Equal("Warning", alert.Messages[0].Message);
        Assert.Equal(ToastType.Warning, alert.Messages[0].Type);

        Assert.Equal("Info", alert.Messages[1].Message);
        Assert.Equal(ToastType.Info, alert.Messages[1].Type);

        Assert.Equal("Success", alert.Messages[2].Message);
        Assert.Equal(ToastType.Success, alert.Messages[2].Type);
    }
}