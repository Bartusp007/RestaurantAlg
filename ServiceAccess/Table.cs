
using System.Collections;
using System.Collections.Generic;

namespace Calendar.Model
{
    public class Table
    {
        public int TableId { get; set; }
        public int Capacity { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}