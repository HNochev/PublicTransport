# PublicTransport
 Public transport website built with ASP.NET Core for course at Software University
# Overview
 Application made for clients and fans of Trolleybus Transport Haskovo, with actual schedules that have real time marking of where exactly the trolleybus is at the moment(on which stop). There is option for the fans to see timeline of every trolleybus we have owned with photos and information for it. Every user can upload photos of the vehicles. Of course there are news with up to date information for the transport in the town. The web application has multiple roles like Administrator, Moderator, Photo-Moderator and more. It has system to order a subscription card, recieve it and then have info in your profile for the remaining period of days of it.
# Technologies Used
  - .NET Core 6
  - ASP .NET Core 6
  - Entity Framework Core 6
  - MSSQL Server
  - SignalR
  - Blazor
  - xUnit
  - Moq
  - JavaScript
  - jQuery
  - Bootstrap
  - HTML 5
  - CSS
# Database Schema
![TrolleybusWebsiteMSSQLDiagram](https://user-images.githubusercontent.com/81227461/166421619-5aaf1e1b-97cf-431a-9b6f-bf6334cac01f.png)
# Application Screenshots
(Almost all screenshots are made from Administrator profile)
## Home page
![localhost_7087_ (1)](https://user-images.githubusercontent.com/81227461/163695976-daa45d4e-e028-4279-9ac7-90a543cb2e39.png)
## All News page
![localhost_7087_News_All](https://user-images.githubusercontent.com/81227461/163695992-2be7fc78-b2ea-4de8-9ae6-a9a31a876630.png)
## Specific news page with all comments for it
![localhost_7087_News_Details_086634a2-0d4c-451a-b371-8e47356a1b94 (1)](https://user-images.githubusercontent.com/81227461/163696005-771f3441-f57f-403d-91bb-1ed6baea31b8.png)
## Rolling stock of the company
![localhost_7087_Vehicles_All](https://user-images.githubusercontent.com/81227461/163696040-388ac35c-dacb-4d46-9fbf-20f3d220c244.png)
## Specific vehicle page with all photos timeline
![localhost_7087_Vehicles_Details_fe0e2837-9477-4bf4-a525-0532f63d9563](https://user-images.githubusercontent.com/81227461/163701597-79c2b9f2-5c5d-4b7e-90f5-f6a961a8789b.png)
## Specific photo of vehicle with all coments for it
![localhost_7087_Photos_Details_a6ff5f72-03cd-4f4b-9911-77b1db84d238](https://user-images.githubusercontent.com/81227461/163701604-f5be0169-e3f5-457a-af0e-591fbb8d3420.png)
## Uploding new photo
![localhost_7087_Vehicles_AddPhoto_1eafa486-5be5-489e-824d-949be6eec6f7](https://user-images.githubusercontent.com/81227461/163701621-4787b82f-8a88-4469-89da-099f2c46b482.png)
## All pending photos to approve only seen by administrator
![localhost_7087_Admin_ApprovePhotos](https://user-images.githubusercontent.com/81227461/163701734-0acba62b-19b9-4e24-89d7-af39c953e679.png)
## All photos with their current  status uploaded by a specific user
![localhost_7087_User_MyPhotos_p=1 s=10](https://user-images.githubusercontent.com/81227461/163701742-1d40d535-c7d4-4ca6-9812-ef0d563eb96d.png)
## Schedules page
![localhost_7087_Lines_All (1)](https://user-images.githubusercontent.com/81227461/163701752-fe8700f1-9a5b-4918-932e-913ebc55c6be.png)
## Schedule for specific line
![localhost_7087_Lines_Schedule_8748fbc6-10d0-48a3-8d79-4da59c3f27b5 (3)](https://user-images.githubusercontent.com/81227461/163701777-447491b5-61a1-4cee-8a21-2ae54830d49b.png)
## All Contacts
![localhost_7087_Contacts_All](https://user-images.githubusercontent.com/81227461/163701862-c2152750-3959-4964-b7d2-3a0a3379c4dc.png)
## All PDF files for download
![localhost_7087_Downloads_All](https://user-images.githubusercontent.com/81227461/163701809-1f2e36bc-fb48-4a1a-91cb-dbf2ecca1c84.png)
## SignalR Chat
![localhost_7087_User_Chat](https://user-images.githubusercontent.com/81227461/163701876-97eb345c-964e-4f6d-ab9d-59dac52d2486.png)
## Cards and Tickets page for Administrator
![localhost_7087_Cards_All](https://user-images.githubusercontent.com/81227461/166418934-743d6a79-cfd4-41a1-b31d-c16b5a5bb73c.png)
## Cards and Tickets page for User
![localhost_7087_Cards_All (1)](https://user-images.githubusercontent.com/81227461/166419021-d5d8db9f-0288-4ffb-bded-da2e24257250.png)
## Order a Card
![localhost_7087_Cards_Order_9a63c6a7-e7a3-4c3f-a4c2-f3582fb67073](https://user-images.githubusercontent.com/81227461/166419369-87325a3d-5a43-4d00-b987-9e6000c0e92d.png)
## User Profile
![localhost_7087_User_UserProfile_424031b3-0587-46ca-ae9b-7d4994ee0821 (1)](https://user-images.githubusercontent.com/81227461/166419151-f6ce9477-eb82-4e6c-ac93-b45ffd9dc77a.png)
## Subscription of user part of Trolleybus Transport Crew
![localhost_7087_User_UserProfile_424031b3-0587-46ca-ae9b-7d4994ee0821 (3)](https://user-images.githubusercontent.com/81227461/166419159-e655dad9-a238-4e33-b8cb-d7c636e07dd0.png)
## Subscription of basic user
![localhost_7087_User_UserProfile_0e5e60eb-73f7-4ff3-b262-e37179a77873](https://user-images.githubusercontent.com/81227461/166419301-02e303e8-d560-4366-a3cd-9ef3394bb146.png)
## Administrator options
![localhost_7087_ (1)](https://user-images.githubusercontent.com/81227461/166420289-cb1ca980-3ca0-45cd-95ec-0a23c14bd041.png)
## Administrator panel
![localhost_7087_RoleManage_UserRole_ManageUsers](https://user-images.githubusercontent.com/81227461/166420132-471433a3-2116-499b-a99c-5e23cd111e18.png)
## Roles control
![localhost_7087_RoleManage_UserRole_Roles_0526cd85-3333-4cae-92a9-6adf7c897811](https://user-images.githubusercontent.com/81227461/166420138-d6522df5-0135-4d72-9e1a-f98965adf0d3.png)
# Azure link
https://haskovotrolleybus.azurewebsites.net/
# License
This project is licensed under the MIT License - see the LICENSE.md file for details
