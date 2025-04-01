namespace GymBookingSystem.Factory
{
    public class GymMember : IUser
    {
        public void ShowRole()
        {
            Console.WriteLine("I am a Gym Member, I can book classes.");
        }
    }
}
