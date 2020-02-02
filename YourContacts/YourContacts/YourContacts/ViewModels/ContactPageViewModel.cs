using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace YourContacts.ViewModels
{
    public class ContactPageViewModel : ViewModelBase
    {
        public ContactPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) 
            : base(navigationService, pageDialogService)
        {
        }
    }
}
