using DataAccess;
using MySql.Data.MySqlClient;
using System;


namespace investigation
{
   
    class Program
    {
        static void Main()
        {
            DatabaseConnection.GetConnection(); 
            DatabaseConnection.InitializeDatabase();
            var investigator = new Investigator(); 
            investigator.StartInvestigation();
        }
    }

}

