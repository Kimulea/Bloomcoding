using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class GroupStart : BaseEntity
    {
        public DateTime HourMinute { get; set; }
        public DateTime DayOfWeek { get; set; }
        public int Groupid { get; set; }
        public Group Group { get; set; }
    }
}
