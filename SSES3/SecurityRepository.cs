using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSES3
{
    public static class SecurityRepository
    {
        /// <summary>
        /// Get a list of all authorization attempts between the two dates.  This includes both successes
        /// and failures.
        /// </summary>
        /// <param name="from">Start date</param>
        /// <param name="to">End date</param>
        /// <returns>Attempts</returns>
        public static IQueryable<DoorsDeatail> GetActivity(DateTime From, DateTime To)
        {
            using (var context = new SSESEntities())
            {
                var tempDoorsDeatail = (from a in context.DoorsDeatails where (a.AccessDate > From) && (a.AccessDate < To) select a).ToList();
               
                return (IQueryable < DoorsDeatail > )tempDoorsDeatail;
            }
        }

        /// <summary>
        /// Gets a list of only authorization attempts for a specific door by ID.
        /// </summary>
        /// <param name="from">Start date</param>
        /// <param name="to">End date</param>
        /// <param name="doorId">The door to check</param>
        /// <returns></returns>
        public static IQueryable<DoorsDeatail> GetDoorActivity(DateTime From, DateTime To, int doorId)
        {
            using (var context = new SSESEntities())
            {
                var tempDoorsDeatail = (from a in context.DoorsDeatails where (a.AccessDate > From) && (a.AccessDate < To) &&(a.DoorsID==doorId) select a).ToList();

                return (IQueryable<DoorsDeatail>)tempDoorsDeatail;
            }
        }

        /// <summary>
        /// Get a list of only "suspicious" authorization attempts.  An attempt is suspicious if it fails AND
        /// there's not a subsequent success within two minutes.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static List<DoorsDeatail> GetSuspiciousActivity(DateTime From, DateTime To)
        {
            List<DoorsDeatail> tempDoorsDeat=new List<DoorsDeatail>();
            using (var context = new SSESEntities())
            {
                var tempDoorsDeatail = (from a in context.DoorsDeatails where (a.AccessDate > From) && (a.AccessDate < To) && (a.AccessGranted == false) select a).ToList();

                // Check for 2 minutes
                foreach (var DoorDeatail in tempDoorsDeatail)
                {
                    bool flag= CheckFor2Minutes((DateTime)DoorDeatail.AccessDate, ((DateTime)DoorDeatail.AccessDate).AddMinutes(2), (int)DoorDeatail.DoorsID);
                    if (flag)
                    {
                        tempDoorsDeat.Add(DoorDeatail);
                    }
                    
                }
            }
            return tempDoorsDeat;
        }

        /// <summary>
        /// Grant access to the specified door using the specified set of credentials.  Credentials
        /// always work in SETS.  You need all the credentials in the set for the authorization to pass.
        /// Make sure to store this information in the database in a way that you can query entire sets
        /// at a time in the IsAuthorized method.
        /// </summary>
        /// <param name="doorId">The door to grant access to</param>
        /// <param name="credentials">The credentials to be used</param>
        public static void GrantAccess(int doorId, IEnumerable<UsersCredential> credentials)
        {
            if (IsAuthorized(doorId, credentials))
            {
                Console.WriteLine("Door is beeing opened");
            }
            else
            {
                Console.WriteLine("Accsess Denied");
            }
        }

        /// <summary>
        /// Determine if the authentication items (ie security badge, key code) are valid to open the
        /// door with the specified ID.  This query should look up the authentication requirements for
        /// the door with specified ID and check if the supplied items meet those requirements.
        /// 
        /// This method should also automatically log the attempted authorization and the result.  You
        /// should call the LogAuthorizationAttempt method to log this.
        /// </summary>
        /// <param name="doorId">Database ID of the door to authorize.</param>
        /// <param name="credentials">Items being used to perform the auth (eg security badge, key code)</param>
        /// <returns>true if the request is authorized, otherwise false</returns>
        public static bool IsAuthorized(int doorId, IEnumerable<UsersCredential> credentials)
        {
            bool flag = true;
            int ?UsID = null;
            using (var context = new SSESEntities())
            {
                foreach (var Cred in credentials)
                {

                    var tempDoorsDeatail = (from a in context.UsersCredentials where (a.Value == Cred.Value) &&(a.CredentialsID == Cred.CredentialsID) select a).FirstOrDefault();
                    if (tempDoorsDeatail == null)
                    {
                        flag = false;
                    }
                    else
                    {
                        UsID = tempDoorsDeatail.UsersID;
                    }

                }
            }
            LogAuthorizationAttempt(doorId, flag, UsID);
            if (flag)
            {
                return true;
            }
            else
            {
                return false;
            }
          
        }

        /// <summary>
        /// Log an attempt to open a door.  This does not validate the attempt, it only stores the result
        /// in the database.
        /// </summary>
        /// <param name="doorId">The door being accessed</param>
        /// <param name="credentials">The items presented to authorize entry</param>
        /// <param name="result">Whether or not entry was allowed</param>
        public static void LogAuthorizationAttempt(int doorId, bool result, int? Id)
        {
            var TempLog = new DoorsDeatail
            {
                AccessDate = DateTime.Now,
                DoorsID = doorId,
                AccessGranted = result,
                UsersID = Id
            };
        }

        public static bool CheckFor2Minutes(DateTime From, DateTime To, int doorID)
        {
            using (var context = new SSESEntities())
            {
                var tempDoorsDeatail = (from a in context.DoorsDeatails where (a.AccessDate > From) && (a.AccessDate < To) && (a.DoorsID==doorID)&&(a.AccessGranted == true) select a).ToList();
                if (tempDoorsDeatail.Count==0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    //    /// <summary>
    //    /// Reverse a grant access operation.  When you revoke access for a single credential it revokes
    //    /// access for any group of credentials that credential was in.
    //    /// NB: In a "real" app, you would need a much more complex grant / revoke access system to
    //    /// accomodate changes to individual credentials that don't affect other credentials.
    //    /// </summary>
    //    /// <param name="doorId">The door being accessed</param>
    //    /// <param name="credential">The credential</param>
    //    public static void RevokeAccess(int doorId, Credential credential)
    //    {
    //        throw new NotImplementedException();
    //    }
    }
}
