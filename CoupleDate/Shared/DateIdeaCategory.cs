using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoupleDate.Shared
{
    public class DateIdeaCategory
    {
        public int DateIdeaId { get; set; }
        public DateIdea DateIdea { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

}
