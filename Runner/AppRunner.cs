// AppRunner.cs (Updated for clean console UX)

using System;
using System.Collections.Generic;
using System.Linq;
using GymBookingSystem.Factory;
using GymBookingSystem.Observer;
using GymBookingSystem.Singleton;
using GymBookingSystem.Algorithms;
using GymBookingSystem.Domain;
using GymBookingSystem.Logic;

namespace GymBookingSystem.Runner
{
    public static class AppRunner
    {
        private static List<GymClass> schedule = ClassRepository.GetWeeklySchedule();
        private static User currentUser = null!;

        public static void Run()
        {
            while (true)
            {
                ShowLoginMenu();

                if (currentUser != null)
                {
                    switch (currentUser.Role)
                    {
                        case Role.Member:
                            ShowMemberMenu();
                            break;
                        case Role.Owner:
                            ShowOwnerMenu();
                            break;
                        case Role.Admin:
                            ShowAdminMenu();
                            break;
                    }

                    currentUser = null!;
                }
            }
        }

        private static void ShowLoginMenu()
        {
            bool loggingIn = true;
            while (loggingIn)
            {
                Console.Clear();
                Console.WriteLine("--- Welcome to the Gym Booking System ---");
                Console.WriteLine("1. Register as New Member");
                Console.WriteLine("2. Member Login");
                Console.WriteLine("3. Owner Login");
                Console.WriteLine("4. Admin Login");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");

                string input = Console.ReadLine()!;
                switch (input)
                {
                    case "1": AuthService.RegisterNewMember(); Pause(); break;
                    case "2": currentUser = AuthService.Login(Role.Member); loggingIn = currentUser == null; break;
                    case "3": currentUser = AuthService.Login(Role.Owner); loggingIn = currentUser == null; break;
                    case "4": currentUser = AuthService.Login(Role.Admin); loggingIn = currentUser == null; break;
                    case "0": Environment.Exit(0); break;
                    default: Console.WriteLine(" Invalid option. Try again."); Pause(); break;
                }
            }
        }

        private static void ShowMemberMenu()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("--- Member Menu ---");
                Console.WriteLine("1. Book a Class");
                Console.WriteLine("2. View Bookings");
                Console.WriteLine("3. Search Class");
                Console.WriteLine("4. Optimize Schedule");
                Console.WriteLine("0. Logout");
                Console.Write("Select an option: ");

                string input = Console.ReadLine()!;
                switch (input)
                {
                    case "1": BookClass(); Pause(); break;
                    case "2": BookingManager.Instance.ShowBookings(); Pause(); break;
                    case "3": SearchClass(); Pause(); break;
                    case "4": OptimizeSchedule(); Pause(); break;
                    case "0": running = false; Console.WriteLine("🔒 Logged out."); Pause(); break;
                    default: Console.WriteLine("❌ Invalid option."); Pause(); break;
                }
            }
        }

        private static void ShowOwnerMenu()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("--- Owner Menu ---");
                Console.WriteLine("1. View Weekly Class Schedule");
                Console.WriteLine("2. View All Bookings");
                Console.WriteLine("3. Add a New Class");
                Console.WriteLine("4. Remove a Class");
                Console.WriteLine("0. Logout");
                Console.Write("Select an option: ");

                string input = Console.ReadLine()!;
                switch (input)
                {
                    case "1":
                        Console.WriteLine("\n Weekly Schedule:");
                        foreach (var c in schedule)
                            Console.WriteLine($"{c.Name} ({c.GetTimeRange()}) - {c.GetStatus()}");
                        Pause();
                        break;
                    case "2": BookingManager.Instance.ShowBookings(); Pause(); break;
                    case "3":
                        Console.Write("Enter class name: ");
                        string name = Console.ReadLine()!;
                        Console.Write("Start hour (0-23): ");
                        int start = int.Parse(Console.ReadLine()!);
                        Console.Write("End hour (0-23): ");
                        int end = int.Parse(Console.ReadLine()!);
                        Console.Write("Capacity: ");
                        int cap = int.Parse(Console.ReadLine()!);
                        schedule.Add(new GymClass(name, DateTime.Today.AddHours(start), DateTime.Today.AddHours(end), cap));
                        Console.WriteLine(" Class added.");
                        Pause();
                        break;
                    case "4":
                        for (int i = 0; i < schedule.Count; i++)
                            Console.WriteLine($"{i + 1}. {schedule[i].Name} ({schedule[i].GetTimeRange()})");
                        Console.Write("Enter number to remove: ");
                        if (int.TryParse(Console.ReadLine()!, out int index) && index > 0 && index <= schedule.Count)
                        {
                            Console.WriteLine($" Removed: {schedule[index - 1].Name}");
                            schedule.RemoveAt(index - 1);
                        }
                        else Console.WriteLine(" Invalid selection.");
                        Pause();
                        break;
                    case "0": running = false; Console.WriteLine("🔒 Logged out."); Pause(); break;
                    default: Console.WriteLine(" Invalid option."); Pause(); break;
                }
            }
        }

        private static void ShowAdminMenu()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("--- Admin Menu ---");
                Console.WriteLine("1. View System Info (placeholder)");
                Console.WriteLine("0. Logout");
                Console.Write("Select an option: ");

                string input = Console.ReadLine()!;
                switch (input)
                {
                    case "1": Console.WriteLine("System running in demo mode. DB/API coming soon."); Pause(); break;
                    case "0": running = false; Console.WriteLine("🔒 Logged out."); Pause(); break;
                    default: Console.WriteLine(" Invalid option."); Pause(); break;
                }
            }
        }

        private static void BookClass()
        {
            Console.WriteLine("\nAvailable Classes:");
            for (int i = 0; i < schedule.Count; i++)
                Console.WriteLine($"{i + 1}. {schedule[i].Name} ({schedule[i].GetTimeRange()}) - {schedule[i].GetStatus()}");

            Console.Write("Enter class number to book: ");
            if (int.TryParse(Console.ReadLine()!, out int choice) && choice > 0 && choice <= schedule.Count)
            {
                var selectedClass = schedule[choice - 1];
                if (selectedClass.IsFull) { Console.WriteLine(" Class is full."); return; }

                selectedClass.Booked++;
                var system = new BookingSystem();
                system.Attach(new EmailNotifier());
                system.Attach(new SMSNotifier());
                system.BookClass(selectedClass.Name);
                BookingManager.Instance.Book(selectedClass.Name);
            }
            else Console.WriteLine(" Invalid input.");
        }

        private static void SearchClass()
        {
            var classNames = schedule.Select(c => c.Name).ToList();
            classNames.Sort();

            Console.Write("Search class name: ");
            string className = Console.ReadLine()!;

            var search = new Search();
            int index = search.BinarySearch(classNames, className);

            if (index != -1)
                Console.WriteLine($" Found '{className}' at index {index}.");
            else
                Console.WriteLine(" Not found.");
        }

        private static void OptimizeSchedule()
        {
            var optimizer = new ScheduleOptimizer();
            var sessions = new List<ClassSession>
            {
                new ClassSession("Spin", 9, 10),
                new ClassSession("HIIT", 10, 11),
                new ClassSession("Yoga", 8, 9)
            };

            var optimized = optimizer.GetOptimizedSchedule(sessions);
            Console.WriteLine("\nOptimized Schedule:");
            foreach (var session in optimized)
                Console.WriteLine($"{session.Name} ({session.StartTime}:00 - {session.EndTime}:00)");
        }

        private static void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
