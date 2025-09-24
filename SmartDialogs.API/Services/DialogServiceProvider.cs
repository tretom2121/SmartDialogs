using Autofac.Features.Indexed;
using SmartDialogs.Core.Services;

namespace SmartDialogs.API.Services
{
    public class DialogServiceProvider(IIndex<string, IDialogService> dialogServiceIndex) : IDialogServiceProvider
    {
        public IDialogService GetDialogService(string key)
        {
            if (dialogServiceIndex.TryGetValue(key, out var dialogService))
            {
                return dialogService;
            }

            throw new ArgumentException($"Dialog service with key '{key}' not found.");
        }
    }
}