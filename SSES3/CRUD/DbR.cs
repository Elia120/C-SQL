using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSES3
{
    public static class DbR
    {
        public static int GetUserID(string LastName, string FirstName)
        {
            using (var context = new SSESEntities())
            {
                var tempUsers = (from User in context.Users where User.LastName == LastName && User.FirstName == FirstName select User).FirstOrDefault();
                return tempUsers.UsersID;
            }
        }
        public static int GetDoorID(string Name)
        {
            using (var context = new SSESEntities())
            {
                var tempDoor = context.Doors.FirstOrDefault(a => a.Name == Name);
                return tempDoor.DoorsID;
            }
        }
        public static List<UsersCredential> PrintAndGetDoorCredential(int Id)
        {
            List<UsersCredential> CerdRe = new List<UsersCredential>();
            using (var context = new SSESEntities())
            {
                var tempDoor = (from Door in context.DoorsCredentials where Door.DoorsID == Id select Door);
                foreach (var door in tempDoor)
                {
                    Console.WriteLine("Please enter/scan your "+GetCredentialName(door.CredentialsID));

                    var tempAddCredentialToUser = new UsersCredential
                    {
                        CredentialsID = door.CredentialsID,
                        Value = Console.ReadLine()
                    };
                    CerdRe.Add(tempAddCredentialToUser);
                }
            }
            return CerdRe;
        }
        public static string GetCredentialName(int Id)
        {
            using (var context = new SSESEntities())
            {
                var tempDoor = (from Credentials in context.Credentials where Credentials.CredentialsID == Id select Credentials).FirstOrDefault();
                return tempDoor.Name;
            }
        }
    }
}
