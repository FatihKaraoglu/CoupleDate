using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoupleDate.Shared
{
    public class UserProfile
    {
        public int UserId { get; set; }
        public List<UserSwipe> Swipes { get; set; } = new List<UserSwipe>();
    }
}
