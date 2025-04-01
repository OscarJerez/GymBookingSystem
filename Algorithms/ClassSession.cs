namespace GymBookingSystem.Algorithms
{
    // Represents a class session with a name and time range
    public class ClassSession
    {
        public string Name { get; set; }
        public int StartTime { get; set; }  // Example: 9 for 9:00
        public int EndTime { get; set; }    // Example: 10 for 10:00

        public ClassSession(string name, int startTime, int endTime)
        {
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
