# About the project
Desktop and mobile application which can be used to sell and buy tickets for events of every kind 
Desktop part of application is for administrators, while mobile app is for clients

## eTickets back-end REST API (ASP.NET Core 3.1)

Technical implementation of  [eTicketsApi](/eTickets/eTicketsAPI) :
* SQL Server database
* Service layer
* Content-Based Filtering 
* Automapper
* Basic auth


## eTickets Desktop Client (Windows Forms)
* Preview of all active or sold tickets
* Preview of all ticket request
* Preview of choosen request, options to accept or reject
* Preview of all users
* Add new user
* Preview of all categories and add/edit/delete (eg. sport, music, movies...)
* Preview of all subcategories and add/edit/delete ( eg. football, basketball, opera, hiphop...)

## eTickets Mobile (Xamarin)
* Customer registration and profile edit
* Active tickets (list of tickets which are available for buying)
* List of personal ticket requests (tickets which we wanna sell first needs to be accepted by administrator)
* List of bought tickets
* Preview of choosen ticket with all details
* Make new request, add picture of ticket

# Getting started

1. Clone/Download project
2. Open Visual Studio, right click the solution and go to "Properties". Select "Common Properties", "Startup Project". Select "Multiple startup projects", and set  eTickets.Mobile.UWP and eTickets.WinUI values to "Start"
3. While In solution "Properties", select "Configuration Properties". Check "Build" and "Deploy" checkboxes next to eTickets.Mobile.UWP
4. Start Docker Desktop
5. Open console, then open "eTickets" root folder in console
6. Run "docker-compose build"
7. Run "docker-compose up"
8. After a console message that the application has started appears, open http://localhost:65010/swagger/index.html in browser **NOTE: docker-compose build may take a few minutes**


# Login Credentials

## Administrator  
username : admin  
password : Reset1  

## User1  
username: user  
password: Reset1  

## User2
username: user2  
password: Reset1  

**One of users is hardcoded in seeding to have just active selling tickets, other is just with bought tickets for purpose of content based filtering**

# Online payment details 

If user wants to sell tickets he needs to have valid bank account number.

## Bank account numbers added in seeding of data   
1. bank account number(id) : 111111111111  
2. bank account number(id) : 222222222222  

## Credit cards added in seeding of data  

### Credit card 1  
Card number (id) : 1111111111111111  
ControlNumber : 111  
Owner : test  
Valid : 03/22  
Account : 111111111111  

### Credit card 2  
Card number (id) : 2222222222222222  
ControlNumber : 222  
Owner : test  
Valid : 03/22  
Account : 222222222222  
