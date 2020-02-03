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

        public Contact CurrentContacts { get; set; }

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
                }
            }
        }
        //public Result SelectedContact { get; set; }
        private ObservableCollection<Result> _observableContacts;
        public ObservableCollection<Result> ObservableContacts
        {

            get { return _observableContacts; }
            private set
            {
                _observableContacts = value;
                RaisePropertyChanged();
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

        public ContactPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) 
            : base(navigationService, pageDialogService)
        {

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
                ObservableContacts = ToObservable(CurrentContacts.results);

            }
        }
    }

    
}
