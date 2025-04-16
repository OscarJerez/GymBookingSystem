// Handles user registration and login logic
// This acts as a temporary mock database for user authentication

using System;
using System.Collections.Generic;
using System.Linq;
using GymBookingSystem.Domain;

namespace GymBookingSystem.Logic
{
    public static class AuthService
    {
        // In-memory user list to simulate a user database
        private static List<User> users = new List<User>
        {
            new User("Nemo", "1234", Role.Admin), // Admin account
            new User("Oscar", "1234", Role.Owner) // Owner account
        };

        // Allows a new gym member to register with username and password
        public static void RegisterNewMember()
        {
            Console.Write("Choose a username: ");
            string username = Console.ReadLine()!;

            // Check if username already exists
            if (users.Any(existingUser => existingUser.Username == username))
            {
                Console.WriteLine("Username already exists.");
                return;
            }

            Console.Write("Choose a password: ");
            string password = Console.ReadLine()!;

            users.Add(new User(username, password, Role.Member));
            Console.WriteLine("Registration successful. You can now log in.");
        }

        // Login method for any role (Member, Owner, Admin)
        public static User Login(Role requestedRole)
        {
            Console.Write("Username: ");
            string username = Console.ReadLine()!;

            Console.Write("Password: ");
            string password = Console.ReadLine()!;

            // Find a user that matches the credentials and role
            User? foundUser = users.FirstOrDefault(user =>
                user.Username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                user.Password == password &&
                user.Role == requestedRole);

            if (foundUser != null)
            {
                Console.WriteLine("Login successful.");
                return foundUser;
            }

            Console.WriteLine("Invalid credentials or role.");
            return null!;
        }
    }
}
