using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Global;
using MySql.Data.MySqlClient;
using System.Security.Permissions;

namespace Solution
{
    public partial class form_connectionsettings : Form
    {
        bool initiallycorrect = true;
        public form_connectionsettings()
        {
            InitializeComponent();

            this.SuspendLayout();

            if (MyGlobalClass.ResolutionHeightScale == -1 || MyGlobalClass.ResolutionWidthScale == -1)
            {
                Form ComparisonForm = null;
                try
                {
                    ComparisonForm = new form_initialscreen();
                    ComparisonForm.Close();
                }
                catch
                {

                }
            }

            this.Width = (int)(this.Width * MyGlobalClass.ResolutionWidthScale);
            this.Height = (int)(this.Height * MyGlobalClass.ResolutionHeightScale);

            MyGlobalClass.ScaleParent(MyGlobalClass.ResolutionHeightScale, MyGlobalClass.ResolutionWidthScale, this);

            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            if (MyGlobalClass.offsetconnectionsettings == true)
            {
                double newX = (resolution.Width / 2) - (this.Width / 2) + (0.05 * resolution.Width);
                double newY = (resolution.Height / 2) - (this.Height / 2) + (0.05 * resolution.Height);
                this.Location = new System.Drawing.Point((int)newX, (int)newY);
            }
            else
            {
                double newX = (resolution.Width / 2) - (this.Width / 2);
                double newY = (resolution.Height / 2) - (this.Height / 2);
                this.Location = new System.Drawing.Point((int)newX, (int)newY);
            }

            this.ResumeLayout();
            this.PerformLayout();
        }

        private void TestConnection()
        {
            try
            {
                MyGlobalClass.connection_to_database = "datasource=" + text_datasource_connectionsettings.Text + "; port=" + text_port_connectionsettings.Text + "; username=" + text_username_connectionsettings.Text + "; password=" + text_password_connectionsettings.Text + "";
                MyGlobalClass.new_connection = new MySqlConnection(MyGlobalClass.connection_to_database);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.new_connection.Close();

                MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`backup directories`;", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                MyGlobalClass.new_connection.Close();

                string directory = "" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Chichester Cattery Booking System Connection Settings";
                System.IO.Directory.CreateDirectory(@directory);
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

                using (System.IO.StreamWriter connectionsettings = new System.IO.StreamWriter(directory + "\\ConnectionSettings.txt", false))
                {
                    connectionsettings.WriteLine(text_datasource_connectionsettings.Text);
                    connectionsettings.WriteLine(text_port_connectionsettings.Text);
                    connectionsettings.WriteLine(text_username_connectionsettings.Text);
                    connectionsettings.WriteLine(text_password_connectionsettings.Text);
                }

                MessageBox.Show("Connection to Database Successful", "Successful", MessageBoxButtons.OK);

                if (MyGlobalClass.initialform_open == false)
                {
                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`backup directories`;", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        MyGlobalClass.totalchalets = int.Parse(MyGlobalClass.SQL_Alter_Database["Total Chalets"].ToString());
                    }
                    MyGlobalClass.new_connection.Close();

                    bool found = false;
                    for (int i = 0; i < Application.OpenForms.Count; i++)
                    {
                        Form openform = Application.OpenForms[i];
                        if (openform.Name == "form_backupandchalets")
                        {
                            found = true;
                        }
                    }

                    if (found == false)
                    {
                        if (MyGlobalClass.totalchalets > 0)
                        {
                            var newform = new form_initialscreen();
                            MyGlobalClass.CloseForm(newform, this);
                            MyGlobalClass.initialform_open = true;
                        }
                        else
                        {
                            var newform = new form_backupandchalets();
                            newform.Show();
                            MyGlobalClass.navigation = true;
                            this.Close();
                            MyGlobalClass.navigation = false;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Connection to Database Unsuccessful", "Unsuccessful", MessageBoxButtons.OK);
                MyGlobalClass.new_connection.Close();

                if (initiallycorrect == true)
                {
                    UpdateConnectionSettings();
                }
            }
        }

        private void UpdateConnectionSettings()
        {
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

                text_datasource_connectionsettings.Text = ConnectionSettings[0];
                text_port_connectionsettings.Text = ConnectionSettings[1];
                text_username_connectionsettings.Text = ConnectionSettings[2];
                text_password_connectionsettings.Text = ConnectionSettings[3];
            }
            catch
            {
                initiallycorrect = false;
            }
        }

        private void button_testconnection_connectionsettings_Click(object sender, EventArgs e)
        {
            TestConnection();
        }

        private void form_connectionsettings_Load(object sender, EventArgs e)
        {
            UpdateConnectionSettings();
        }

        private void button_exitconnectionsettings_connectionsettings_Click(object sender, EventArgs e)
        {
            MyGlobalClass.offsetconnectionsettings = false;
            try
            {
                MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`backup directories`;", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                MyGlobalClass.new_connection.Close();
                try
                {
                    if (MyGlobalClass.initialform_open == false)
                    {
                        bool found = false;
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            Form openform = Application.OpenForms[i];
                            if (openform.Name == "form_backupandchalets")
                            {
                                found = true;
                            }
                        }

                        if (found == false)
                        {
                            if (MyGlobalClass.totalchalets > 0)
                            {
                                var newform = new form_initialscreen();
                                MyGlobalClass.CloseForm(newform, this);
                                MyGlobalClass.initialform_open = true;
                            }
                            else
                            {
                                var newform = new form_backupandchalets();
                                newform.Show();
                                MyGlobalClass.navigation = true;
                                this.Close();
                                MyGlobalClass.navigation = false;
                            }
                        }
                        else
                        {
                            MyGlobalClass.navigation = true;
                            this.Close();
                            MyGlobalClass.navigation = false;
                        }
                    }
                    else
                    {
                        MyGlobalClass.navigation = true;
                        this.Close();
                        MyGlobalClass.navigation = false;
                    }
                }
                catch
                {
                    MyGlobalClass.navigation = true;
                    this.Close();
                    MyGlobalClass.navigation = false;
                }
                if (Application.OpenForms.Count < 1)
                {
                    Application.Exit();
                }
            }
            catch
            {
                MyGlobalClass.new_connection.Close();
                if (MessageBox.Show("Please enter the correct Connection Settings. Do you wish to exit the program?", "Incorrect Connection Settings", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }

        private void connectionsettings_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TestConnection();
            }
        }

        private void text_ConnectionSettings_Enter(object sender, EventArgs e)
        {
            button_testconnection_connectionsettings.Font = new Font(Font.FontFamily, button_testconnection_connectionsettings.Font.Size, FontStyle.Bold);
        }

        private void text_ConnectionSettings_Leave(object sender, EventArgs e)
        {
            button_testconnection_connectionsettings.Font = new Font(Font.FontFamily, button_testconnection_connectionsettings.Font.Size, FontStyle.Regular);
        }
    }
}
