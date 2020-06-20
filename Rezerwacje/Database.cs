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


        public string[] getUserData(string login, string password) {

            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT * FROM Employees WHERE EmployeeLogin = '");
            sb.Append(login);
            sb.Append("' AND EmployeePassword = '");
            sb.Append(password);
            sb.Append("';");

            string com = sb.ToString();

            connection.Open();
            SqlCommand command = new SqlCommand(com, connection);


            if (command.ExecuteScalar() == null) {
                connection.Close();
                return null; 
            }


            string[] list;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                list = new string[reader.FieldCount];
                while (reader.Read())
                {
                    for (int i = 0; i<reader.FieldCount; i++) list[i] = reader.GetValue(i).ToString();
                }
            }

            connection.Close();

            return list;
        }

        public Rooms getRoomData(int roomId, DateTime date){
            //Rezerwacje do tablicy stringów start
            string[] reservationList;
            int slotsOccupied = 0;

            //liczy kolumny
            StringBuilder sb = new StringBuilder(); 
            sb.Append("SELECT COUNT(*) FROM Reservations WHERE RoomID = '");
            sb.Append(roomId);
            sb.Append("' AND Date = '");
            sb.Append(date.ToString("yyyy/MM/dd"));
            sb.Append("';");

            string com = sb.ToString();
            connection.Open();
            SqlCommand command = new SqlCommand(com, connection);


            int rowCount = (int)command.ExecuteScalar();
            //if (command.ExecuteScalar() == null) rowCount = 0;
            //else rowCount = (int)command.ExecuteScalar();

            connection.Close();

            if (rowCount == 0) { //Nie ma rezerwacji w tym dniu
                StringBuilder sb3 = new StringBuilder();

                sb3.Append("SELECT MaxCapacity FROM Rooms WHERE RoomID = '");
                sb3.Append(roomId);
                sb3.Append("';");

                string com3 = sb3.ToString();
                connection.Open();
                SqlCommand command3 = new SqlCommand(com3, connection);

                int maxCapacity = (int)command3.ExecuteScalar();
                connection.Close();
                return new Rooms(roomId, maxCapacity, new string[] { }, 0); 
            }
            //koniec liczenia kolumn

            //Pobiera konkretne kolumny
            StringBuilder sb1 = new StringBuilder();
            sb1.Append("SELECT * FROM Reservations WHERE RoomID = '"); 
            sb1.Append(roomId);
            sb1.Append("' AND Date = '");
            sb1.Append(date.ToString("yyyy/MM/dd"));
            sb1.Append("';");

            string com1 = sb1.ToString();
            connection.Open();
            SqlCommand command1 = new SqlCommand(com1, connection);

            using (SqlDataReader reader = command1.ExecuteReader())
            {
                reservationList = new string[rowCount]; 
                for (int i = 0; reader.Read(); i++)
                {
                    reservationList[i] = reader.GetInt32(5) + "os " + reader.GetString(2) + ' ' + reader.GetString(3) + ' ' + reader.GetString(6);
                    slotsOccupied += reader.GetInt32(5);
                }
            }
            connection.Close();
            //Rezerwacje do tablicy stringów koniec

            //Info o pokoju i rezerwacajch do klasy Rooms start
            StringBuilder sb2 = new StringBuilder();

            sb2.Append("SELECT * FROM Rooms WHERE RoomID = '");
            sb2.Append(roomId);
            sb2.Append("';");

            string com2 = sb2.ToString();
            connection.Open();
            SqlCommand command2 = new SqlCommand(com2, connection);

            
            Rooms thisRoom;

            using (SqlDataReader reader = command2.ExecuteReader())
            {
                reader.Read();
                thisRoom = new Rooms((int)reader.GetValue(0), (int)reader.GetValue(1), reservationList, slotsOccupied);
    
            }
            connection.Close();
            //Info o pokoju i rezerwacajch do klasy Rooms koniec


            return thisRoom;
        }

        public string[] getEmployeeDetails(string[] reservation)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT e.Name, e.Surname FROM Employees e INNER JOIN Reservations r ON r.EmployeeID = e.EmployeeID WHERE r.Name = '");
            sb.Append(reservation[1]);
            sb.Append("' AND r.Surname = '");
            sb.Append(reservation[2]);
            sb.Append("' AND r.SlotsQuantity = '");
            sb.Append(reservation[0]);
            sb.Append("' AND r.PhoneNumber = '");
            sb.Append(reservation[3]);
            sb.Append("';");

            string com = sb.ToString();
            connection.Open();
            SqlCommand command = new SqlCommand(com, connection);
            string[] result = new string[2];
            using (SqlDataReader reader = command.ExecuteReader())
            {
                reader.Read();
                result[0] = reader.GetString(0);
                result[1] = reader.GetString(1);
                
            }
            connection.Close();

            return result;

        }
    }
}
