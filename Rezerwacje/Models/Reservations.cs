using System;
using System.Collections.Generic;

namespace Rezerwacje.Models
{
    public partial class Reservations
    {
        public int ReservationId { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int RoomId { get; set; }
        public int SlotsQuantity { get; set; }
        public string PhoneNumber { get; set; }
        public int EmployeeId { get; set; }
    }
}
