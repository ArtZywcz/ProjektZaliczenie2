using Rezerwacje.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rezerwacje {
    class Database {
        
        static string connectionString = "Data Source=DESKTOP-7TDH2OL\\SQLEXPRESS;Initial Catalog = MountainHut; Integrated Security = SSPI";
        SqlConnection connection = new SqlConnection(connectionString);


        public Employees getUserData(string login, string password) {


            using (var db = new MountainHutContext()) {
                var test = db.Employees
                    .Where(e => e.EmployeeLogin == login && e.EmployeePassword == password)
                    .ToList();

                if (test.Count == 0) return null;
                return test[0];
            }
        }

        public Rooms getRoomData(int roomId, DateTime date){
            int slotsOccupied = 0;
            string[] reservationList;
            Rooms thisRoom;
            using (var db = new MountainHutContext()) {
                var test = db.Reservations
                    .Where(r => r.RoomId == roomId  && r.Date == date)
                    .ToList();

                int maxCapacity = db.Rooms
                        .Where(r => r.RoomId == roomId)
                        .Select(r => r.MaxCapacity)
                        .SingleOrDefault();

                if (test.Count == 0) {
                    

                    return new Rooms(roomId, maxCapacity, new string[] { }, 0);
                }

                reservationList = new string[test.Count];
                for (int i = 0; i<test.Count; i++) {
                    reservationList[i] = test[i].SlotsQuantity + "os " + test[i].Name + ' ' + test[i].Surname + ' ' + test[i].PhoneNumber;
                    slotsOccupied += test[i].SlotsQuantity;
                }
                
                thisRoom = new Rooms(test[0].RoomId, maxCapacity, reservationList, slotsOccupied);
                return thisRoom;
            }
            
        }

        public Employees getEmployeeDetails(string[] reservation, DateTime? date) {
            using (var db = new MountainHutContext()) {
                var test = db.Reservations.Join(db.Employees, r => r.EmployeeId, e => e.EmployeeId, (r,e) => new {r,e})
                    .Where(re => re.r.Name == reservation[1] && re.r.Date == date && re.r.Surname == reservation[2] && re.r.SlotsQuantity == int.Parse(reservation[0]) && re.r.PhoneNumber == reservation[3])
                    .Select(em => new { em.e.Name, em.e.Surname })
                    .ToList();

                Employees thisGuy = new Employees();
                thisGuy.Name = test[0].Name;
                thisGuy.Surname = test[0].Surname;

                return thisGuy;
            }



        }

        public void addReservation(Reservations reservation) 
        {
            using (var db = new MountainHutContext()) {
                db.Add(reservation);
                db.SaveChanges();
            }

        }

        public int getRoomPrice(int id)
        {
            using (var db = new MountainHutContext()) {
                var test = db.Rooms
                    .Where(r => r.RoomId == id)
                    .Select(r => r.Price)
                    .FirstOrDefault();

                return test;
            }

            
        }

        public void removeReservation(Reservations reservation)
        {
            using (var db = new MountainHutContext()) {

                var test = db.Reservations
                    .Where(r => r.Name == reservation.Name && r.Surname == reservation.Surname && r.Date == reservation.Date && r.PhoneNumber == reservation.PhoneNumber)
                    .SingleOrDefault();
                ;
                db.Remove(test);
                db.SaveChanges();
            }
            
            
        }

        
    }

}
