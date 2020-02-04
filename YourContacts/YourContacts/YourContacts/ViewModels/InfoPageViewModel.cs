using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;

namespace YourContacts.ViewModels
{
    public class InfoPageViewModel : ViewModelBase
    {

        //Commands
        public DelegateCommand SettingsCommand { get; set; }
        public DelegateCommand LogoutCommand { get; set; }

        public InfoPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) 
            : base(navigationService, pageDialogService)
        {

            SettingsCommand = new DelegateCommand(async () =>
            {
                var answer = await DialogService.DisplayAlertAsync("Are you sure you want to configure your credentials?", null, "Yes", "No");
                if (answer)
                {
                    var SettingsParameters = new NavigationParameters();
                    SettingsParameters.Add("BoolConfiguration", true);

                    await NavigationService.NavigateAsync(new Uri($"/{Constants.Navigation}/{Constants.SetUp}", UriKind.Absolute), SettingsParameters);
                }
            });

            LogoutCommand = new DelegateCommand(async () =>
            {
                var answer = await DialogService.DisplayAlertAsync("Are you sure you want to \nlog out?", null, "Yes", "No");
                if (answer)
                {
                    await NavigationService.NavigateAsync(new Uri($"/{Constants.Navigation}/{Constants.Login}", UriKind.Absolute));
                }
            });
        }
    }
}
