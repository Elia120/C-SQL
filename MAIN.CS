
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSES
{
    class Program
    {
        static void Main(string[] args)
        {
            DbCRUD.AddUser("Mami", "Mami", "1998-10-16", 2, "123613");
            Console.ReadLine();
      }
    }

    
   