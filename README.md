# ParkAhead

ParkAhead is an innovative parking management application designed to simplify the process of finding and reserving parking spots. With real-time updates and advanced reservation features, ParkAhead ensures a smooth and efficient parking experience.

![1](https://github.com/user-attachments/assets/60169041-a81b-471a-b44d-2c9b0ca3ae01)

# Table of contents
* [Get started](#get-started)
* [Technologies](#technologies)
* [Functionalities](#functionalities)
* [Era model](#era-model)
* [Timer trigger](#timer-trigger)
* [User interface](#user-interface)

## Get started

Clone the repository or download the files.

### Backend

Open the solution in Visual studio.

Set multiple startup projects (API and CheckReservations (Timer trigger)).

Start the backend project.

![image](https://github.com/user-attachments/assets/02926000-0c15-4eb7-b9f2-8c917f2eb747)

### Frontend

Open terminal on project ParkAhead.UI, write the command bellow.

```
ng serve
```

## Technologies
### Backend

- [.NET 8](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-8/overview) 
- [Entity Framework Core 8](https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-8.0/whatsnew)
- REST API
- [Azure functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-versions?tabs=isolated-process%2Cv4&pivots=programming-language-csharp)

### Frontend

- [Angular 18.2.0](https://www.angulararchitects.io/blog/whats-new-in-angular-18/)
- TypeScript
- HTML
- CSS
- [OpenStreetMap](https://www.openstreetmap.org/help)

### Tools

- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
- Node.js & npm
- Git

Database

- [SQL Server Management Studio 20 (SSMS)](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)

## Functionalities

| Id | Feature    | Description    |
| :---: | :--- | :--- |
| 1 | User registration | Allows new users to create a profile. |
| 2 | User login | Enables existing users to log into the application using their username and password. |
| 3 | All parkings | Displays a list of all available parking lots. |
| 4 | All parking spots | Provides a detailed view of all individual parking spots within a selected parking lot. |
| 5 | Make a reservation on image of parking lot and on a real map | Allows users to select a specific parking spot from the available options and make a reservation. |
| 6 | Cancel reservation | Allows users to cancel a reservation within a 5-minute window after making it. |
| 7 | Arrive at parking spot | After arriving at the reserved parking spot, users can notify the application by pressing a button, triggering the system to automatically "open the parking ramp or gate (This is just the idea, there are no real parking ramps involved... yet :) )". |

## Era model

<img src="https://github.com/user-attachments/assets/875115cd-c2f7-4da1-87ae-b2115d12c240" width="600">

## Timer trigger

A timer-triggered function has been created using Azure Functions to check reservation times. This function runs every minute and queries the database to identify any reservations that have expired.

## User interface

You can click on the image to expand it for a better view.

### 1 User registration  
<img src="https://github.com/user-attachments/assets/eb1bd131-5f9c-40a2-996a-d67a382014a0" width="600"> 

### 2 User login 
<img src="https://github.com/user-attachments/assets/6a64dc58-8f05-456c-b6ea-503780bc9626" width="600"> 

### 3 All parkings
<img src="https://github.com/user-attachments/assets/47d70279-fcd7-4d71-9177-f54ba153c3d4" width="600"> 

### 4 All parking spots 
<img src="https://github.com/user-attachments/assets/bc205180-db01-4f42-a5f4-53c6af1af422" width="600"> 

### 5 Make a reservation 
<img src="https://github.com/user-attachments/assets/eab9dc39-1251-4677-9001-05934918449c" width="600"> 

<img src="https://github.com/user-attachments/assets/7db724d9-7f6b-49bc-8233-40a665d1857a" width="600"> 

### 6 and 7  Cancel reservation and arrive at parking spot 
<img src="https://github.com/user-attachments/assets/4c3d5494-cbbb-4f89-9a43-88ff872fd2ae" width="600"> 
