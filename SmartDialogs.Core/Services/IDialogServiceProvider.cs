namespace SmartDialogs.Core.Services
{
    public interface IDialogServiceProvider
    {
        IDialogService GetDialogService(string key);
    }
}