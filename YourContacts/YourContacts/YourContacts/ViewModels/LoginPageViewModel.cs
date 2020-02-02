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
    public class LoginPageViewModel : ViewModelBase, IInitializeAsync
    {
        //Properties
        protected NetworkAccess CurrentConnection;
        public string MyUserCredential { get; set; }
        public string MyPasswordCredential { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        //Commands
        public DelegateCommand LoginCommand { get; set; }

        public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) 
            : base(navigationService, pageDialogService)
        {

            LoginCommand = new DelegateCommand( async () =>
            {
                CurrentConnection = Connectivity.NetworkAccess;
                if (CurrentConnection.Equals(NetworkAccess.Internet))
                {
                    if (String.IsNullOrEmpty(Username) || String.IsNullOrEmpty(Password))
                    {
                        await DialogService.DisplayAlertAsync("Fields can not be empty! Try again!", null, "Ok");
                    }
                    else
                    {
                        if (Username.Equals(MyUserCredential) && Password.Equals(MyPasswordCredential))
                        {
                            await DialogService.DisplayAlertAsync($"Welcome '{Username.ToUpper()}' to \nYourContacts App!", null, "Ok");

                            await NavigationService.NavigateAsync(new Uri($"/{Constants.Navigation}/{Constants.TabbedPage}?selectedTab={Constants.Contact}", UriKind.Absolute));

                        }
                        else
                            await DialogService.DisplayAlertAsync("Invalid Login Credentials! Try again!", null, "Ok");

                    }
                }
                else
                    await DialogService.DisplayAlertAsync("Check your internet Connection and Try Again!", null, "Ok");
            });

        }
        
        public async Task InitializeAsync(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            MyUserCredential = await SecureStorage.GetAsync("Username");
            MyPasswordCredential = await SecureStorage.GetAsync("Password");
        }
    }
}
