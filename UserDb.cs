using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class UserDb
    { 
        public string Name { get; set; }
        public string SurName { get; set; }
        public string DOB { get; set; }
        public int AccessLevel { get; set; }
        public string CardID { get; set; }
        public string Fingerprint { get; set; }

        UserDb()
        {
            Console.WriteLine("What do you want to do? (A)ddUser Add(F)ingerprint (C)hangeUser Add(D)oor (E)nterDoor Add(Cr)edetial");
            switch (Console.ReadLine().ToLower)
            {
                case "a":
                Console.WriteLine("Please enter the first Name");
                Name=Console.ReadLine();
                Console.WriteLine("Please enter the Surname");
                SurName=Console.ReadLine();
                System.Console.WriteLine("Please enter the D.O.B. Fist the year and press enter then the month and enter and then the day and then again enter");
                DOB=string.Format("{0}-{1}-{2}",Console.ReadLine(),Console.ReadLine(),Console.ReadLine())
                Console.WriteLine("Plaese enter the Accsess Level(1-5)");
                AccessLevel=int32.parse(Console.ReadLine());
                Console.WriteLine("Please scan the CardID");
                CardID=Console.ReadLine();
                Console.WriteLine("Do you want the scan a Fingerprint now?");
                if (Console.ReadLine().ToLower()="y")
                {
                    Console.WriteLine("Scan the finger now");
                    Fingerprint=Console.ReadLine();
                    AddUser( Name, SurName, DOB, AcsessLevel, CardID, Fingerprint);
                    
                }else
                {
                    AddUser( Name, SurName, DOB, AcsessLevel, CardID);
                }
                break;
                case "f":
                break;
                case "c":
                break;
                case "d":
                break;
                case "e":
                break;
                case "cr":
                break;
                
                default:
                Console.WriteLine("Error, Please try again");
            }
        }

    }
}