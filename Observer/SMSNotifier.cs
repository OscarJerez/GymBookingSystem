using System;

namespace GymBookingSystem.Observer
{
    public class SMSNotifier : IObserver
    {
        public void Update(string message)
        {
            Console.WriteLine($"📱 SMS Notification: {message}");
        }
    }
}
