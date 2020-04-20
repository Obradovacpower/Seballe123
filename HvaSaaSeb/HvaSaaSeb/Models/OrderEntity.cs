using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HvaSaaSeb.Models
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public DateTime Day { get; set; }
        public bool CheckIn { get; set; }
        public bool DoneEating { get; set; }
        //nav props
        public GuestEntity Guest { get; set; }
        public int GuestId { get; set; }
    }
}
