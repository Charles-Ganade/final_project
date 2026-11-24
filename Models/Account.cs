using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace final_project.Models
{
    public class Account : IdentityUser
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Customer? Customer { get; set; }

        public Store? Store { get; set; }
    }
}