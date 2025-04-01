using System.Collections.Generic;
using System.Linq;

namespace GymBookingSystem.Algorithms
{
    // Greedy algorithm to optimize class schedule based on earliest ending time
    public class ScheduleOptimizer
    {
        public List<ClassSession> GetOptimizedSchedule(List<ClassSession> sessions)
        {
            // Sort the sessions by their ending time
            List<ClassSession> sorted = sessions.OrderBy(s => s.EndTime).ToList();
            List<ClassSession> result = new List<ClassSession>();

            int currentEndTime = 0;

            foreach (var session in sorted)
            {
                // If the session starts after or when the previous ends, include it
                if (session.StartTime >= currentEndTime)
                {
                    result.Add(session);
                    currentEndTime = session.EndTime;
                }
            }

            return result;
        }
    }
}
