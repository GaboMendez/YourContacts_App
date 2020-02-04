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
        public InfoPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) 
            : base(navigationService, pageDialogService)
        {

            SettingsCommand = new DelegateCommand(async () =>
            {
                var answer = await DialogService.DisplayAlertAsync("Are you sure you want to configure your credentials?", null, "Si", "No");
                if (answer)
                {
                    var SettingsParameters = new NavigationParameters();
                    SettingsParameters.Add("Value", true);

                    await NavigationService.NavigateAsync(new Uri($"/{Constants.Navigation}/{Constants.SetUp}", UriKind.Relative), SettingsParameters);
                }
            });
        }
    }
}
