using System;

namespace GymBookingSystem.Domain
{
    // Represents a class that members can book
    public class GymClass
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Capacity { get; set; }
        public int Booked { get; set; }

        public GymClass(string name, DateTime start, DateTime end, int capacity)
        {
            Name = name;
            StartTime = start;
            EndTime = end;
            Capacity = capacity;
            Booked = 0;
        }
        // Checks if class is fully booked
        public bool IsFull => Booked >= Capacity;
        // Returns booking status like "Spots left: 2" or "FULL"
        public string GetStatus()
        {
            if (IsFull)
                return "FULL";

            int spotsLeft = Capacity - Booked;
            return $"Spots left: {spotsLeft}";
        }
        // Returns the time range in a friendly format
        public string GetTimeRange()
        {
            return $"{StartTime:dddd HH:mm} - {EndTime:HH:mm}";
        }
    }
}
