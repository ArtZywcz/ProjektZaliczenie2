using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rezerwacje {
    public class Rooms {


        public int roomNr { get; }
        public int roomCap { get; }
        public int roomNow { get; }

        public string[] reservations { get; }

        public Rooms(int roomNr, int roomCap, string[] reservations, int slotsOccupied) {
            this.roomNr = roomNr;
            this.roomCap = roomCap;

            this.reservations = reservations;

            this.roomNow = roomCap - slotsOccupied;

        }


    }
}
