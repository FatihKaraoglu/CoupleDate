using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoupleDate.Shared
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string Role { get; set; } = "Free"; // Default role
        public bool IsSubscribed { get; set; } = false; // Default subscription status
        public int? CoupleId { get; set; } // Couple identifier

        // Navigation property to UserSwipes
        public List<UserSwipe> UserSwipes { get; set; }
    }
}
