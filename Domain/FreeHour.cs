using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class FreeHour : BaseEntity
    {
        public DateTime HourMinute { get; set; }
        public DateTime DayOfWeek { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
