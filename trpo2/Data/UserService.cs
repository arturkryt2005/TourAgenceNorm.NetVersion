using Microsoft.AspNetCore.Components;
using trpo2.Models;

namespace trpo2.Data
{
    public class UserService
    {
        public Customer CurrentUser { get; set; } = null!;
    }
}
