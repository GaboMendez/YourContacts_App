using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;


namespace YourContacts.ViewModels
{
    public class SetUpPageViewModel : ViewModelBase, IInitializeAsync
    {
        //Properties
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        //Commands
        public DelegateCommand SaveCommand { get; set; }

        public SetUpPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) 
            : base(navigationService, pageDialogService)
        {
            Title = "INITIAL SET-UP";
            SaveCommand = new DelegateCommand(async () =>
            {
                if (String.IsNullOrEmpty(Username) || String.IsNullOrEmpty(Password) || String.IsNullOrEmpty(ConfirmPassword))
                {
                    await DialogService.DisplayAlertAsync("Fields can not be empty! Try again!", null, "Ok");
                }
                else
                {
                    if (Password.Equals(ConfirmPassword))
                    {
                        await SecureStorage.SetAsync("Username", Username);
                        await SecureStorage.SetAsync("Password", Password);

                        await DialogService.DisplayAlertAsync("Your credentials has been created successfully!", null, "Ok");
                        await NavigationService.NavigateAsync(new Uri($"/{Constants.Navigation}/{Constants.Login}", UriKind.Absolute));
                    }
                    else
                        await DialogService.DisplayAlertAsync("Passwords do not match! Try again!", null, "Ok");

                }
            });
        }

        public async Task InitializeAsync(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            if (parameters.ContainsKey("BoolConfiguration"))
            {
                bool value = (bool)parameters["BoolConfiguration"];
                if (value)
                {
                    Username = await SecureStorage.GetAsync("Username");
                    Title = "CONFIGURATION";
                }
            }
        }
    }
}
