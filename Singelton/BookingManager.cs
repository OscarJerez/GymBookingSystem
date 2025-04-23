using System;
using System.Collections.Generic;

namespace GymBookingSystem.Singleton
{
    // Singleton Pattern: Only one BookingManager exists for the entire app
    public class BookingManager
    {
        private static BookingManager instance; // Single instance
        private static readonly object lockObj = new object(); // Lock for thread safety

        private List<string> bookings = new List<string>(); // Stores booked class names

        // Private constructor so no one else can create it
        private BookingManager() { }

        // Public way to access the single instance
        public static BookingManager Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new BookingManager();
                    }
                    return instance;
                }
            }
        }

        // Add a new booking if it doesn't already exist
        public void Book(string className)
        {
            if (bookings.Contains(className))
            {
                Console.WriteLine(" This class is already booked.");
            }
            else
            {
                bookings.Add(className);
                Console.WriteLine(" '" + className + "' booked.");
            }
        }

        // Show all booked classes
        public void ShowBookings()
        {
            Console.WriteLine("\n Booked Classes:");

            if (bookings.Count == 0)
            {
                Console.WriteLine("(No bookings yet)");
            }
            else
            {
                foreach (string booking in bookings)
                {
                    Console.WriteLine("- " + booking);
                }
            }
        }
    }
}
