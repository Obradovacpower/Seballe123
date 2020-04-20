using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HvaSaaSeb.Models
{
    public class RoomEntity
    {
        public int Id { get; set; }
        public ICollection<GuestEntity> Guests { get; set; } = new HashSet<GuestEntity>();
    }
}
