using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using YourContacts.Models;
using YourContacts.Services;

namespace YourContacts.ViewModels
{
    public class ContactPageViewModel : ViewModelBase
    {
        // Properties
        protected NetworkAccess CurrentConnection;
        protected IApiService ApiService { get; set; }

        public Result SearchContact { get; set; }
        // SearchContact Prop Detail
        public string FullName { get; set; }
        public string Address01 { get; set; }
        public string Address02 { get; set; }
        //
        public Contact CurrentContacts { get; set; }
        public string ContactID { get; set; }
        public bool Cancel { get; set; } = false;
        public bool FoundContact { get; set; } = false;
        public bool ShowContacts { get; set; } = true;

        //
        private Result _selectedContact;
        public Result SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                if (_selectedContact != value)
                {
                    _selectedContact = value;

                    // Detail Contact Nav with _selectedContact
                    _ = DetailContact(_selectedContact);
                }
            }
        }
        private ObservableCollection<Result> _observableContacts;
        public ObservableCollection<Result> ObservableContacts
        {

            get { return _observableContacts; }
            private set
            {
                _observableContacts = value;
                RaisePropertyChanged("ObservableContacts");
            }
        }

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                RaisePropertyChanged("IsRefreshing");
            }
        }
        //Commands

        public DelegateCommand RefreshCommand { get; set; }
        public DelegateCommand SearchCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        public ContactPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) 
            : base(navigationService, pageDialogService)
        {
            ApiService = new ApiService();

            RefreshCommand = new DelegateCommand(async () =>
            {
                IsRefreshing = true;

                CurrentConnection = Connectivity.NetworkAccess;
                if (CurrentConnection.Equals(NetworkAccess.Internet))
                {
                    await UpdateContacts();
                }

                IsRefreshing = false;
            });

            SearchCommand = new DelegateCommand(async () =>
            {
                if (FoundContact)
                {
                    FoundContact = false;
                }
                IsRefreshing = true;

                CurrentConnection = Connectivity.NetworkAccess;
                if (CurrentConnection.Equals(NetworkAccess.Internet))
                {
                    if (!String.IsNullOrEmpty(ContactID))
                    {
                        int id = Convert.ToInt32(ContactID);
                        if (id > 0)
                        {
                            SearchContact = await ApiService.GetContactsById(id);
                            if (SearchContact != null && !SearchContact.CatchError)
                            {
                                ShowContacts = false;
                                Cancel = true;
                                FoundContact = true;
                                FullName = $" {SearchContact.dob.age} | {SearchContact.name.ToString()} ";
                                Address01 = $"{SearchContact.location.city.ToUpper()}, {SearchContact.location.state.ToUpper()} \n{SearchContact.location.country.ToUpper()} - ZIP: {SearchContact.location.postcode} ";
                                Address02= $"{SearchContact.location.street.name} - {SearchContact.location.street.number} ";

                                IsRefreshing = false;
                                return;
                            }
                            else
                                await DialogService.DisplayAlertAsync("Connection Interruped! Try Again!", null, "Ok");
                            
                            ContactID = null;
                            Cancel = false;
                            FoundContact = false;
                        }
                        else
                            await DialogService.DisplayAlertAsync("Invalid Value! Try Again!", null, "Ok");
                        Console.WriteLine();
                    }
                    else
                        await DialogService.DisplayAlertAsync("Field can not be empty! Try again!", null, "OK");
                }

                IsRefreshing = false;
            });

            CancelCommand = new DelegateCommand( async () =>
            {
                IsRefreshing = true;
                FoundContact = false;

                if (!String.IsNullOrEmpty(ContactID))
                {
                    await UpdateContacts();
                    ContactID = null;
                    Cancel = false;
                    ShowContacts = true;
                }

                IsRefreshing = false;
            });

        }

        private async Task DetailContact(Result contact)
        {
            var DetailParameters = new NavigationParameters();
            DetailParameters.Add("Contact", _selectedContact);

            await NavigationService.NavigateAsync(new Uri($"/{Constants.DetailContact}", UriKind.Relative), DetailParameters);
        }
        private async Task UpdateContacts()
        {
            CurrentContacts = await ApiService.GetRandomContacts();
            ObservableContacts = ToObservable(CurrentContacts.results);
        }
        private ObservableCollection<Result> ToObservable(IEnumerable<Result> enumerable)
        {
            var ret = new ObservableCollection<Result>();
            foreach (var cur in enumerable)
            {
                ret.Add(cur);
            }
            return ret;
        }
        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            if (parameters.ContainsKey("AllContacts"))
            {
                CurrentContacts = (Contact)parameters["AllContacts"];
                if (CurrentContacts.results != null)
                {
                    ObservableContacts = ToObservable(CurrentContacts.results);
                }

            }
        }
    }

    
}
