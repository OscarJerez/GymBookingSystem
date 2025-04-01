using System;

namespace GymBookingSystem.Factory
{
    public static class UserFactory
    {
        public static IUser CreateUser(string role)
        {
            return role.ToLower() switch
            {
                "member" => new GymMember(),
                "owner" => new GymOwner(),
                "admin" => new Admin(),
                _ => throw new ArgumentException("Invalid role")
            };
        }
    }
}
