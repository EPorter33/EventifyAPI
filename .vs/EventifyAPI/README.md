1. Overview
Eventify is a lightweight event‑management web application developed for the DAT6006 module. It enables users to create, view, and manage events through a clean, accessible interface styled with the NHS.UK Frontend design system.
The project demonstrates full‑stack development using ASP.NET Core, Entity Framework Core, and SQL Server.

2. How to Obtain the Project
Option A – Clone the Repository (recommended)
bash
git clone https://github.com/<your-username>/Eventify.git
Option B – Download ZIP
Open the GitHub repository.

Select Code → Download ZIP.

Extract the folder to your machine.

3. Prerequisites
Install the following:

.NET 8 SDK

SQL Server Express (or full SQL Server)

SQL Server Management Studio (SSMS)

A modern browser (Edge, Chrome, Firefox)

4. Project Structure
Code

Eventify/
│
├── Controllers/
│   └── EventController.cs
│
├── Data/
│   └── EventDbContext.cs
│
├── Models/
│   └── Event.cs
│
├── wwwroot/
│   ├── index.html
│   ├── add-event.html
│   ├── view-events.html
│   ├── about.html
│   ├── css/
│   ├── js/
│   └── NHS.UK frontend assets
│
├── appsettings.json
├── Program.cs
└── README.md

5. Database Setup (SQL Server)

1. Create the database

Open SSMS → connect to your SQL Server instance → run:

sql

CREATE DATABASE EventifyDB;
2. Update the connection string
In appsettings.json, update:

json
"ConnectionStrings": {
  "DefaultConnection": "Server=DESKTOP;Database=EventifyDB;Trusted_Connection=True;TrustServerCertificate=True;"
}


3. Apply migrations
If using EF Core migrations:

bash
dotnet ef database update
If not using migrations, EF will create the schema automatically on first run (depending on your configuration).

6. Running the Project
Start the API / Web App
From the project root:

bash
dotnet run
The application will start at:

Code
https://localhost:

Open the browser and navigate to the home page.

7. API Endpoints
GET all events
Code
GET /api/events
POST a new event
Code
POST /api/events
Body:
{
  "title": "Example Event",
  "date": "2026-04-20",
  "location": "Cardiff",
  "description": "Sample description"
}

8. How the View Events Page Works
The View Events page sends a GET request to:

Code
/api/events
The API retrieves event data from SQL Server, returns it as JSON, and the frontend renders it into a semantic HTML table styled with NHS.UK components.
This ensures the page always displays the latest events stored in the database.

9. Troubleshooting
SQL Server connection error
Ensure SQL Server Express is running

Confirm the instance name (e.g., SQLEXPRESS)

Check firewall settings

Verify the connection string

NHS styles not loading
Ensure the NHS.UK Frontend CDN link is included in <head>

API not starting
Confirm .NET 8 SDK is installed

Run dotnet --version to verify

10. Author
Elizabeth  
Cardiff Metropolitan University
DAT6006 – Full Stack Development