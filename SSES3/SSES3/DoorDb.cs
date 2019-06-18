using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSES3
{
    class DoorDb
    {
        public static bool CheckForCredential(int CredentialID, string Value)
        {
            using (var context = new SSESEntities())
            {
                var tempUsersCredentials = (from a in context.UsersCredentials where a.CredentialsID == CredentialID && a.Value == Value select a);
                if (tempUsersCredentials == null)
                {
                    return false;
                }
                return true;
            }
        }

        public static void OpenDoor(int DoorID, string Value)
        {
            using (var context = new SSESEntities())
            {
                var tempUsersCredentials = (from a in context.UsersCredentials where a.CredentialsID == CredentialID && a.Value == Value select a);
                if (tempUsersCredentials == null)
                {
                    return false;
                }
                return true;
            }
        }
        public static bool IsAuthorized(int doorId, IEnumerable<Credential> credentials)
        {
            throw new NotImplementedException();
        }
        public static void LogAuthorizationAttempt(int doorId, int UserID, bool result)
        {
            throw new NotImplementedException();
        }
    }
}
}
