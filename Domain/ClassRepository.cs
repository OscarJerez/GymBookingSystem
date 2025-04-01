using System;
using System.Collections.Generic;

namespace GymBookingSystem.Domain
{
    // Provides a mock list of weekly gym classes
    public static class ClassRepository
    {
        public static List<GymClass> GetWeeklySchedule()
        {
            return new List<GymClass>
            {
                new GymClass("Yoga", DateTime.Today.AddHours(8), DateTime.Today.AddHours(9), 5),
                new GymClass("Zumba", DateTime.Today.AddDays(1).AddHours(9), DateTime.Today.AddDays(1).AddHours(10), 5),
                new GymClass("HIIT", DateTime.Today.AddDays(2).AddHours(10), DateTime.Today.AddDays(2).AddHours(11), 4),
                new GymClass("Pilates", DateTime.Today.AddDays(3).AddHours(17), DateTime.Today.AddDays(3).AddHours(18), 6),
                new GymClass("Spinning", DateTime.Today.AddDays(4).AddHours(18), DateTime.Today.AddDays(4).AddHours(19), 6)
            };
        }
    }
}
