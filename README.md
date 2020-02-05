# YourContacts
Xamarin Mobile App that is consuming Random User API. Link: "https://randomuser.me/"

## Table of contents

* [Screenshots](#screenshots)
* [Setup](#technologies)
* [Functionality](#functionality)
* [Technologies](#technologies)
* [Packages Used](#packages-used)

## Screenshots

<p aling="center">
<img src="/ScreenShots/Screen01.jpg" width="30%" /> <img src="/ScreenShots/Screen02.jpg" width="30%" /> 
<img src="/ScreenShots/Screen03.jpg" width="30%" /> <img src="/ScreenShots/Screen04.jpg" width="30%" /> 
<img src="/ScreenShots/Screen05.jpg" width="30%" /> <img src="/ScreenShots/Screen06.jpg" width="30%" /> 
</p>

## Setup

1. Clone the project into a directory, with the following command.
```sh
$ git clone https://github.com/GaboMendez/YourContacts_App.git
```
2. Enter the created folder and go to the 'YourContacts_App' file.
3. Locate the **.apk** file in the project.
4. Download or Transfer the **.apk** file to the Android device.
5. Install **YourContacts** App.

## Functionality

- (**Sign Up**): It allows to create your credentials for using this App.
- (**Login**): It allows to use your credentials for using this App.
- (**Home**): This screens show the first 5 contact that returns the API.
- (**Pull to Refresh**): It allows to do Pull to Refresh to the ListView for updating the Contact List.
- (**Search Bar**): It allows you to search with the Contact ID and it shows the detail of this Contact ID.
- (**Cancel Bar**): It allows you to cancel the found Contact and it will update your Contact List with others 5 Contact.
- (**Detail Contact**): It allows you to see the Details from the selected contact of the List in another Page.
- (**Info**): This screens show the Developer Info and the App Info.
- (**HiperLink**): It allows you to go to "https://randomuser.me/" through Info Page.
- (**Log Out**): It allows you to Log Out through Info Page.
- (**Configuration**): It allows you to update your credentials through Info Page.

## Technologies

* Visual Studio 2019
* Xamarin Forms
* Prism 
* XAML
* C#

## Packages Used   

* V: 3.2 | PropertyChanged.Fody        
* V: 7.2 | Prism.Unity.Forms           
* V: 1.3 | Xamarin.Essentias           
* V: 4.4 | Xamarin.Forms              
* V: 1.3 | Xamarin.Forms.PancakeView   
* V: 12.0 | Newtonsoft.Json 
