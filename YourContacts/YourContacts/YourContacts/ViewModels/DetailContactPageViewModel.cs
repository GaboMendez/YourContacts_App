using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using YourContacts.Models;

namespace YourContacts.ViewModels
{
    public class DetailContactPageViewModel : ViewModelBase
    {
        //Properties
        public Result MyContact { get; set; }


        public DetailContactPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) 
            : base(navigationService, pageDialogService)
        {
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            if (parameters.ContainsKey("Contact"))
            {
                MyContact = (Result)parameters["Contact"];
                Console.WriteLine();
            }
        }
    }
}
