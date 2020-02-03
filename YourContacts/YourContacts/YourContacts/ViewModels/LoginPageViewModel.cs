using Prism.Commands;
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
    public class LoginPageViewModel : ViewModelBase, IInitializeAsync
    {
        //Properties
        protected IApiService ApiService { get; set; }
        protected NetworkAccess CurrentConnection;
        public string MyUserCredential { get; set; }
        public string MyPasswordCredential { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public Contact Contacts { get; set; }


        private bool _isBusy;
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                _isBusy = value;
                RaisePropertyChanged("IsBusy");
            }
        }


  
        //Commands
        public DelegateCommand LoginCommand { get; set; }

        public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) 
            : base(navigationService, pageDialogService)
        {
            ApiService = new ApiService();

            LoginCommand = new DelegateCommand( async () =>
            {
                IsBusy = true;
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
                          
                            Contacts = await ApiService.GetRandomContacts();
                            //Contacts = new Contact();
                            var ContactsParameters = new NavigationParameters();
                            ContactsParameters.Add("AllContacts", Contacts);

                            await DialogService.DisplayAlertAsync($"Welcome '{Username.ToUpper()}' to \nYourContacts App!", null, "Ok");

                            await NavigationService.NavigateAsync(new Uri($"/{Constants.Navigation}/{Constants.TabbedPage}?selectedTab={Constants.Contact}", 
                                                        UriKind.Absolute), ContactsParameters);



                        }
                        else
                            await DialogService.DisplayAlertAsync("Invalid Login Credentials! Try again!", null, "Ok");

                    }
                }
                else
                    await DialogService.DisplayAlertAsync("Check your internet Connection and Try Again!", null, "Ok");

                IsBusy = false;
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
