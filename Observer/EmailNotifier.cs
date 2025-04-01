using System;

namespace GymBookingSystem.Observer
{
    public class EmailNotifier : IObserver
    {
        public void Update(string message)
        {
            Console.WriteLine($"📧 Email Notification: {message}");
        }
    }
}
