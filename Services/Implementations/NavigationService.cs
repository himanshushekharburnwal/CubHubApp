using CubHubApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CubHubApp.Services.Implementations
{
    public class NavigationService : INavigationService
    {
        public async Task GoToAsync(string route, bool animate = true)
        {
            try
            {
                await Shell.Current.GoToAsync(route, animate);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Navigation Error: {ex.Message}");
            }
        }

        public async Task GoToAsync(string route, IDictionary<string, object> parameters, bool animate = true)
        {
            try
            {
                await Shell.Current.GoToAsync(route, animate, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Navigation Error with Parameters: {ex.Message}");
            }
        }

        public async Task GoBackAsync()
        {
            try
            {
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GoBack Error: {ex.Message}");
            }
        }

        public async Task PopToRootAsync()
        {
            try
            {
                await Shell.Current.Navigation.PopToRootAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"PopToRoot Error: {ex.Message}");
            }
        }
    }
}
