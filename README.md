# Gym Booking System 🏋️‍♂️

> A digital console-based gym booking system that allows members to register, log in, book classes, and more. Owners and Admins have specialized menus and privileges.

---

## 🚀 Project Overview

### **Scenario**
Many gyms lack an efficient booking system, leading to frustration and overcrowding. This console application provides a user-friendly interface for booking, managing classes, and future expansion into web/API systems.

### **Goals**
✅ Role-based user login and registration  
✅ Member class booking and search  
✅ Owner class management (add/remove)  
✅ Admin control panel (placeholder)  
✅ Design patterns and algorithm implementations  
✅ Clean menu interface with persistent user flow

---

## 👥 Roles & Authentication

| Role      | Abilities                           |
|-----------|-------------------------------------|
| Member    | Register, Login, Book/Search Classes |
| Owner     | Login, Manage Class Schedule         |
| Admin     | Login, System Overview (placeholder) |

- **Predefined Accounts:**
  - Admin: `Nemo / 1234`
  - Owner: `Oscar / 1234`
  - Members must register at first run

---

## 📖 User Stories

```yaml
As a new gym member,
I want to register and log in,
So that I can book classes.

As a gym owner,
I want to add or remove classes,
So that I can control the weekly schedule.

As an admin,
I want access to system info,
So that I can manage everything centrally.
```

---

## 🧰 Design Patterns Used

### 1️⃣ Factory Pattern  
**Used in:** `UserFactory`  
**Purpose:** Dynamically create role-specific user objects.  
**Improves:** Scalability and separation of responsibilities.

### 2️⃣ Singleton Pattern  
**Used in:** `BookingManager`  
**Purpose:** Maintain a central list of all bookings.  
**Improves:** Ensures global access point for booking data.

### 3️⃣ Observer Pattern  
**Used in:** `BookingSystem` with `EmailNotifier` & `SMSNotifier`  
**Purpose:** Notify users when bookings are made.  
**Improves:** Decouples notifications from booking logic.

---

## 📈 Algorithms Used

### 🔍 Binary Search  
**Used in:** `SearchClass()`  
**Purpose:** Quickly search sorted class list by name.

### ⚡ Greedy Algorithm  
**Used in:** `OptimizeSchedule()`  
**Purpose:** Schedule non-overlapping class sessions for max efficiency.

---

## 🔐 Features (Console UI)

- Clean interface with `Console.Clear()`
- Press-any-key pauses for user feedback
- Console auto refreshes between steps
- Logged-in user shown in menu headers
- Error handling for invalid input/roles

---

## 📌 Use Cases

### 1️⃣ Book a Class (Member)
- Pre-condition: Member logged in
- Flow: View schedule → Choose class → Confirm booking

### 2️⃣ Manage Classes (Owner)
- Pre-condition: Owner logged in
- Flow: Add or remove classes → View changes

### 3️⃣ Login/Register
- Pre-condition: Application started
- Flow: Select role → Enter credentials → Load menu

---

## 🧱 Folder Structure

```bash
/Domain          # Core business logic (User, GymClass, etc)
/Logic           # Login and authentication logic
/Factory         # UserFactory (Factory Pattern)
/Observer        # Notification system (Observer Pattern)
/Singleton       # Centralized Booking Manager (Singleton)
/Algorithms      # Search and Optimization algorithms
/Runner          # Main AppRunner and Console UI logic
```

---

## 💻 Tech Stack
- Language: C# (.NET 8 Console App)
- Architecture: OOP, Layered
- Future Plan: SQL integration + ASP.NET Web API

---

## 🔄 Development Workflow
- ✅ Clean architecture and naming
- ✅ Descriptive variables & comments
- ✅ No emojis/special symbols in UI
- ✅ Prepares for real-world system design

---

## 📝 License
MIT License

---

## ✨ Final Words
> This project is built with scalability, clarity, and real-world extension in mind. Built by a student, for learning — but ready to grow into something more.

Let's build it better — together. 💪
