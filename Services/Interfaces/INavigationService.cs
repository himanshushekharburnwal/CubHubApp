using System.Threading.Tasks;

namespace CubHubApp.Services.Interfaces
{
    public interface INavigationService
    {
        Task GoToAsync(string route, bool animate = true);
        Task GoToAsync(string route, IDictionary<string, object> parameters, bool animate = true);
        Task GoBackAsync();
        Task PopToRootAsync();
    }
}
