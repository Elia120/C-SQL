﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSES3
{
    public static class DbC
    {
        public static void CreateNewUser(string FirstName, string LastName, DateTime DOB)
        {
            var tempUser = new User
            {
                FirstName = FirstName,
                LastName = LastName,
                DOB=DOB,
            };
            using (var context = new SSESEntities())
            {
                context.Users.Add(tempUser); 
                context.SaveChanges(); 
            }
        }
        public static void CreateNewDoor(string Name)
        {
            var tempDoor = new Door
            {
                Name=Name
            };
            using (var context = new SSESEntities())
            {
                context.Doors.Add(tempDoor);
                context.SaveChanges();
            }
        }
        public static void CreateNewCredential(string Name)
        {
            var tempCredential = new Credential
            {
                Name = Name,    
            };
            using (var context = new SSESEntities())
            {
                context.Credentials.Add(tempCredential);
                context.SaveChanges();
            }
        }
        public static void AddCredentialToUser(int UserID, int CredentialID, string Value)
        {
            var tempAddCredentialToUser = new UsersCredential
            {
                UsersID=UserID,
                CredentialsID=CredentialID,
                Value=Value
            };
            using (var context = new SSESEntities())
            {
                context.UsersCredentials.Add(tempAddCredentialToUser);
                context.SaveChanges();
            }
        }
        public static void AddCredentialToDoor(int DoorsID,int CredentialID)
        {
            var AddCredentialToDoor = new DoorsCredential
            {
                DoorsID=DoorsID,
                CredentialsID=CredentialID
            };
            using (var context = new SSESEntities())
            {
                context.DoorsCredentials.Add(AddCredentialToDoor);
                context.SaveChanges();
            }
        }
    }
}
