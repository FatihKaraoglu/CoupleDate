using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoupleDate.Shared
{
    public class UserSwipe
    {
        public int Id { get; set; }
        public int DateIdeaId { get; set; }
        public bool Liked { get; set; }
        public int UserId { get; set; }
        public int CoupleId { get; set; }

        public User User { get; set; }
    }

}
