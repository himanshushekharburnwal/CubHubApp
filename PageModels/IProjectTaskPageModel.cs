using CommunityToolkit.Mvvm.Input;
using CubHubApp.Models;

namespace CubHubApp.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}