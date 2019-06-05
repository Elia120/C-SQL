using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
static class DbCRUD
    {
        public static string ConnString = @"Data Source=DEBORAHSPC\SQLEXPRESS;Initial Catalog=SSES;Integrated Security=True";

        public static void AddUser(string Name, string SurName, string DOB, int AcsessLevel, string CardNr)
        {
            using (SqlConnection conn=new SqlConnection(ConnString))
            {
                string sqlString = string.Format("INSERT INTO Users (LastName, FirstName, DOB, AccsessLevel, CardID) VALUES('{0}', '{1}', '{2}', '{3}', '{4}')",Name,SurName,DOB,AcsessLevel,CardNr);
                SqlCommand sqlCommand = new SqlCommand(sqlString, conn);
                sqlCommand.Connection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
        public static void AddUser(string Name, string SurName, string DOB, int AcsessLevel, string CardNr, string Fingerprint){
            using (SqlConnection conn=new SqlConnection(ConnString))
            {
                string sqlString = string.Format("INSERT INTO Users (LastName, FirstName, DOB, AccsessLevel, CardID, Fingerprint) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",Name,SurName,DOB,AcsessLevel,CardNr,Fingerprint);
                SqlCommand sqlCommand = new SqlCommand(sqlString, conn);
                sqlCommand.Connection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
        public static void AddFinger(string Fingerprint, int ID)
        {
            using (SqlConnection conn=new SqlConnection(ConnString))
            {
                
                string sqlString = string.Format("UPDATE Users SET Fingerprint = {0},WHERE UsersID={1}",Fingerprint,ID);
                SqlCommand sqlCommand = new SqlCommand(sqlString, conn);
                sqlCommand.Connection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
        public static void ChangeUser(string propToChange,string val, int ID)
        {
           
            using (SqlConnection conn=new SqlConnection(ConnString))
            {
                string sqlString = string.Format("UPDATE Users SET {0} = {1},WHERE UsersID={2}",propToChange,val ,ID);
                SqlCommand sqlCommand = new SqlCommand(sqlString, conn);
                sqlCommand.Connection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
        public static void GetUser(int ID)
        {
            public string Name { get; set; }
            public string SurName { get; set; }
            public string DOB { get; set; }
            public int AccessLevel { get; set; }
            public string CardID { get; set; }
            public string Fingerprint { get; set; }

            using (SqlConnection conn= new SqlConnection(ConnString))
            using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Customers WHERE CustomerID={0}",ID)
                {
                    connection.Open();  
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                            {
                                Name=reader["Name"].ToString();
                                SurName=reader["SurName"].ToString();
                                DOB=reader["DOB"].ToString();
                                AccessLevel=(int)reader["AccessLevel"].ToString();
                                CardID=reader["CardID"].ToString();
                                Fingerprint=reader["Fingerprint"].ToString();
                            }
                    }
                }
                
        }

    }
