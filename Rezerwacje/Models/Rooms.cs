using System;
using System.Collections.Generic;

namespace Rezerwacje.Models
{
    public partial class Rooms
    {
        public int RoomId { get; set; }
        public int MaxCapacity { get; set; }
        public int Price { get; set; }
        public bool HasBathroom { get; set; }
    }
}
