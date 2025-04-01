namespace GymBookingSystem.Factory
{
    public class Admin : IUser
    {
        public void ShowRole()
        {
            Console.WriteLine("I am an Admin, I manage users and payments.");
        }
    }
}
