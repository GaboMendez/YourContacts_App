using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Essentials;


namespace YourContacts.ViewModels
{
    public class SetUpPageViewModel : ViewModelBase
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

                    }
                    else
                        await DialogService.DisplayAlertAsync("Passwords do not match! Try again!", null, "Ok");

                }
            });
        }
    }
}
