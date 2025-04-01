using System;
using System.Collections.Generic;

namespace GymBookingSystem.Observer
{
    public class BookingSystem
    {
        // List to store who should be notified
        private List<IObserver> observers = new List<IObserver>();

        // Add someone to the notification list
        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        // Remove someone from the notification list
        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        // Tell everyone on the list about the booking
        public void Notify(string message)
        {
            foreach (IObserver observer in observers)
            {
                observer.Update(message);
            }
        }

        // Book a class and send notification
        public void BookClass(string className)
        {
            Console.WriteLine("✅ Class '" + className + "' booked successfully!");
            Notify("Class '" + className + "' has been booked.");
        }
    }
}
