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
        public string Info01 { get; set; }
        public string Address01 { get; set; }
        public string Address02 { get; set; }
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
                Info01 = $"{MyContact.gender.ToUpper()} - {MyContact.dob.age}";
                Address01 = $"Country:\n   {MyContact.location.country.ToUpper()} \nCity:\n   {MyContact.location.city.ToUpper()}\nState: {MyContact.location.state.ToUpper()} \n\nZIP: {MyContact.location.postcode}\n";
                Address02 = $"Street: {MyContact.location.street.name.ToUpper()} - {MyContact.location.street.number}";

                Console.WriteLine();
            }
        }
    }
}
