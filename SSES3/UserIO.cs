using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSES3
{
    public static class UserIO
    {
        public static void  Start()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine();
            Console.WriteLine("1: Create new User:");
            Console.WriteLine("2: Create new Door:");
            Console.WriteLine("3: Create new Credential:");
            Console.WriteLine("4: Add Credential to User:");
            Console.WriteLine("5: Add Credential to Door:");
            Console.WriteLine("6: Get Suspicious Activity in the past 7 days:");
            Console.WriteLine("7: Get User ID:");
            Console.WriteLine("8: Get Door ID:");
            Console.WriteLine();
            Console.WriteLine("9: Open Door:");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Please enter a First Name");
                    string FirstName = Console.ReadLine();
                    Console.WriteLine("Please enter a Sur-Name");
                    string LastName = Console.ReadLine();
                    Console.WriteLine("Please enter a Date of Birth(First the Year then press enter then month and then the day)");
                    int year =Convert.ToInt32( Console.ReadLine());
                    int month = Convert.ToInt32(Console.ReadLine());
                    int day = Convert.ToInt32(Console.ReadLine());
                    DateTime DOB = new DateTime(year,month,day);

                    DbC.CreateNewUser(FirstName, LastName, DOB);
                    break;
                case "2":
                    Console.WriteLine("Please enter a First Name");
                    string Name = Console.ReadLine();
                    DbC.CreateNewDoor(Name);
                    break;
                case "3":
                    Name= Console.ReadLine();
                    DbC.CreateNewCredential(Name);
                    break;
                case "4":
                    Console.WriteLine("Please enter a UserID");
                    int UserID= Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please enter a CredentialID");
                    int CredentialID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please enter a Value");
                    string value = Console.ReadLine();
                    DbC.AddCredentialToUser(UserID, CredentialID, value);
                    break;
                case "5":
                    Console.WriteLine("Please enter a DoorID");
                    int DoorID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please enter a CredentialID");
                    CredentialID = Convert.ToInt32(Console.ReadLine());
                    DbC.AddCredentialToDoor(DoorID, CredentialID);
                    break;
                case "6":
                    var a=SecurityRepository.GetSuspiciousActivity(DateTime.Now.AddDays(-7), DateTime.Now);
                    foreach (var row in a)
                    {
                        Console.WriteLine("Doors ID: "+row.DoorsID+" Users ID: "+ row.UsersID + " AccessDate:" + row.AccessDate);
                    }
                    break;
                case "7":
                    Console.WriteLine("Please enter the First Name");
                    FirstName = Console.ReadLine();
                    Console.WriteLine("Please enter the Sur-Name");
                    LastName = Console.ReadLine();

                    DbR.GetUserID(LastName, FirstName);
                    break;
                case "8":
                    Console.WriteLine("Please enter the Name of the Door");
                    Name = Console.ReadLine();

                    DbR.GetDoorID(Name);
                    break;
                case "9":
                    Console.WriteLine("Do you know the id?(y/n)");
                    int id;
                    if (Console.ReadLine().ToLower()=="y")
                    {
                        Console.WriteLine("Please enter the ID");
                        id= Convert.ToInt32(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine("Please enter the name of the Door");
                        id=DbR.GetDoorID(Console.ReadLine());
                    }
                    
                    IEnumerable<UsersCredential> credential= DbR.PrintAndGetDoorCredential(id);
                    SecurityRepository.GrantAccess(id, credential);
                    break;
                default:
                    break;
            }
            Console.WriteLine("Done?");
        }
        
    }
}
