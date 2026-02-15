# 🎟 MVC Event Booking System (Production-Ready)

A modern **Event Booking & Management System** built with **ASP.NET Core MVC** and **Entity Framework Core**, featuring authentication, full event CRUD operations, and booking management with clean architecture principles.

This project simulates a real-world booking platform where users can browse events, view details, book seats, and manage their bookings.

---

## 📌 Project Highlights

- ✅ Register & Login system  
- ✅ Full Event Management (CRUD)  
- ✅ Book Events (User ↔ Event relationship)  
- ✅ My Bookings Dashboard  
- ✅ ViewModel Implementation for optimized UI rendering  
- ✅ Entity Framework Core + Migrations  
- ✅ SQL Server relational database design  
- ✅ Clean MVC Architecture + Organized Folder Structure  

---

## 🧠 System Architecture

This project follows the **MVC Design Pattern**:

- **Models** → represent database tables (Users, Events, Bookings)  
- **Controllers** → manage requests, logic, and responses  
- **Views** → Razor pages for UI rendering  
- **ViewModels** → combine multiple sources into one object for UI  

---

## 🛠 Tech Stack

### Backend
- ASP.NET Core MVC (.NET 8)
- Entity Framework Core (Code First)
- LINQ Queries
- SQL Server Database
- Migrations Support

### Frontend
- Razor Views
- HTML / CSS
- Bootstrap

---

## ✨ Features

### 🔐 Authentication System (Register / Login)

Users can:

- Create a new account using username and password
- Login using saved credentials
- See error messages for invalid login attempts

📌 After successful login, users are redirected to the Home page.

---

### 📅 Event Management (CRUD)

| Feature | Description |
|---------|------------|
| Index   | List all events in a table |
| Details | Display event details |
| Create  | Add new event |
| Edit    | Modify existing event |
| Delete  | Remove event |

Each event includes:

- Title  
- Date  
- Description  
- Organizer Name  

---

### 🎟 Booking System

From the event details page, users can book an event.

✔ Booking stores a new record in the **Bookings** table:

- UserId  
- EventId  

---

### 📌 MyBookings Page

Users can:

- View all booked events  
- Navigate back to the event details page  

---

## 🧩 ViewModel Implementation

The Event Details page uses a dedicated ViewModel:

| Property | Source |
|----------|--------|
| Title | Events Table |
| Description | Events Table |
| Date | Events Table |
| OrganizerName | Events Table |
| UserHasBooked (bool) | Bookings Table |

📌 `UserHasBooked = true` if the logged-in user already booked the event.  
This prevents duplicate bookings and improves UI logic.

---

## 🗂 Project Structure

```

MVC-Event
│
├── Controllers
│   ├── AccountController.cs
│   ├── EventController.cs
│   └── BookingController.cs
│
├── Models
│   ├── User.cs
│   ├── Event.cs
│   └── Booking.cs
│
├── ViewModel
│   └── EventDetailsViewModel.cs
│
├── Views
│   ├── Account
│   ├── Event
│   └── Booking
│
├── Migrations
├── wwwroot
├── Program.cs
├── appsettings.json
└── MVC-Event.csproj

````

---

## 🛢 Database Design

### 👤 Users Table

| Column | Type |
|--------|------|
| Id | int |
| UserName | string |
| Password | string |

---

### 📅 Events Table

| Column | Type |
|--------|------|
| Id | int |
| Title | string |
| Date | DateTime |
| Description | string |
| OrganizerName | string |

---

### 🎟 Bookings Table

| Column | Type |
|--------|------|
| Id | int |
| UserId | int (FK) |
| EventId | int (FK) |

---

### 🔗 Relationships

- One User → Many Bookings  
- One Event → Many Bookings  

---

## ⚙️ Setup & Installation

### ✅ Requirements
- .NET 8 SDK  
- SQL Server  
- Visual Studio 2022  

---

### 1️⃣ Clone Repository

```bash
git clone https://github.com/kholouddiaa/MVC-Event.git
````

### 2️⃣ Navigate to Project Directory

```bash
cd MVC-Event
```

### 3️⃣ Restore Dependencies

```bash
dotnet restore
```

### 4️⃣ Update Database

```bash
dotnet ef database update
```

### 5️⃣ Run the Project

```bash
dotnet run
```

App will run on:

```
https://localhost:7181
```

---

## 🔐 Security Notes

⚠ Passwords are currently stored in plain text (educational purpose only).

In production:

* ✅ Use password hashing (BCrypt / ASP.NET Identity)
* ✅ Use secure authentication middleware

---

## 🧪 Testing Scenarios

1. Register a new account
2. Login
3. Create a new event
4. View event list
5. Open event details
6. Book an event
7. Check MyBookings page

---

## 🚀 Future Enhancements

* Add ASP.NET Identity Authentication
* Add Role Management (Admin / User)
* Prevent duplicate bookings
* Add Search & Filter
* Add Pagination
* Improve UI (Responsive Design)
* Deploy to Azure

---

## 👩‍💻 Developer

**Kholoud Diaa**
ASP.NET Core Developer

---

## 📄 License

This project is created for educational and portfolio purposes.
