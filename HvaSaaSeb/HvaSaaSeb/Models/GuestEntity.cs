using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HvaSaaSeb.Models
{
    public class GuestEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public bool IsAdult { get; set; }
        public bool HasEatenToday { get; set; }
        public bool CheckIn { get; set; }
        public DateTime[] FoodOrders { get; set; }
        //nav props
        public RoomEntity Room { get; set; }
        public int RoomId { get; set; }
        public ICollection<OrderEntity> Orders { get; set; } = new HashSet<OrderEntity>();
    }
}
