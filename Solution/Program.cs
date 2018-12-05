using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Global;
using System.Security.Permissions;
using MySql.Data.MySqlClient;

namespace Solution
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                string directory = "" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Chichester Cattery Booking System Connection Settings";
                FileIOPermission permissions = new FileIOPermission(FileIOPermissionAccess.Read, directory);
                permissions.AddPathList(FileIOPermissionAccess.Write | FileIOPermissionAccess.Read, directory + "\\ConnectionSettings.txt");

                try
                {
                    permissions.Demand();
                }
                catch (System.Security.SecurityException s)
                {
                    Console.WriteLine(s.Message);
                }

                string[] ConnectionSettings = new string[0];
                int count = 0;
                using (System.IO.StreamReader connectionsettings = new System.IO.StreamReader(directory + "\\ConnectionSettings.txt"))
                {
                    while (connectionsettings.ReadLine() != null)
                    {
                        count++;
                    }
                }
                ConnectionSettings = new string[count];
                count = 0;

                using (System.IO.StreamReader connectionsettings = new System.IO.StreamReader(directory + "\\ConnectionSettings.txt"))
                {
                    string line = "";
                    while ((line = connectionsettings.ReadLine()) != null)
                    {
                        ConnectionSettings[count] = line;
                        count++;
                    }
                }

                MyGlobalClass.connection_to_database = "datasource=" + ConnectionSettings[0] + "; port=" + ConnectionSettings[1] + "; username=" + ConnectionSettings[2] + "; password=" + ConnectionSettings[3] + "";
                MyGlobalClass.new_connection = new MySqlConnection(MyGlobalClass.connection_to_database);

                MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`backup directories`;", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                while (MyGlobalClass.SQL_Alter_Database.Read())
                {
                    MyGlobalClass.totalchalets = int.Parse(MyGlobalClass.SQL_Alter_Database["Total Chalets"].ToString());
                }
                MyGlobalClass.new_connection.Close();

                if (MyGlobalClass.totalchalets > 0)
                {
                    var newform = new form_initialscreen();
                    MyGlobalClass.OpenForm(newform);
                    MyGlobalClass.initialform_open = true;
                }
                else
                {
                    MyGlobalClass.RunSetup = true;
                    var newform = new form_backupandchalets();
                    MyGlobalClass.OpenForm(newform);
                }
            }
            catch
            {
                MyGlobalClass.RunSetup = true;
                var newform = new form_connectionsettings();
                MyGlobalClass.OpenForm(newform);
            }
            Application.Run();
        }
    }
}

