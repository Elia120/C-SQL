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
                var tempUsers = (from User in context.Users where User.LastName==LastName && User.FirstName==FirstName select User).FirstOrDefault() ;
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
      
}
