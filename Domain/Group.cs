using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<GroupStart> GroupStarts { get; set; }
    }
}
