using Microsoft.AspNetCore.Components;
using trpo2.Models;

namespace trpo2.Data
{
    public class UserService
    {
        private Customer currentUser;

        public void SetCurrentUser(Customer user)
        {
            currentUser = user;
        }

        public Customer GetCurrentUser()
        {
            return currentUser;
        }
    }
}
