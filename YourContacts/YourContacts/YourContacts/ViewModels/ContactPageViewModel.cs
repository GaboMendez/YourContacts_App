using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using YourContacts.Models;
using YourContacts.Services;

namespace YourContacts.ViewModels
{
    public class ContactPageViewModel : ViewModelBase, IInitializeAsync
    {
        // Properties
        protected IApiService ApiService { get; set; }
        protected NetworkAccess CurrentConnection;

        public Contact Contact { get; set; }
        //Commands

        public ContactPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) 
            : base(navigationService, pageDialogService)
        {
            ApiService = new ApiService();

        }

        public async Task InitializeAsync(INavigationParameters parameters)
        {
            CurrentConnection = Connectivity.NetworkAccess;
            if (CurrentConnection.Equals(NetworkAccess.Internet))
            {
                Contact = await ApiService.GetContacts();
            }
        }
    }
}
