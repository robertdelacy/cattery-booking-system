using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Global; //Allows me to use the global class

namespace Solution
{
    public partial class form_initialscreen : Form
    {
        string[] Arrivals = new string[0];
        string[] Departures = new string[0];
        string[] Vaccinations = new string[0];
        string[,] Changes = new string[0, 0];
        string[,] HeldBookings = new string[0, 0];
        string selectedbooking = "";
        string selectedregistration = "";
        string selectedchange = "";
        int[,] selectedindex = new int[2, 2] { { -1, -1 }, { -1, -1 } };
        int[,] listboxitemcount = new int[2, 2] { { 0, 0 }, { 0, 0 } };

        public form_initialscreen()
        {
            InitializeComponent();

            this.SuspendLayout();

            Rectangle resolution = Screen.PrimaryScreen.Bounds;

            double WidthScale = (double)resolution.Width / (double)this.Width;
            double HeightScale = (double)resolution.Height / (double)this.Height;
            MyGlobalClass.ResolutionWidthScale = WidthScale;
            MyGlobalClass.ResolutionHeightScale = HeightScale;

            this.Width = (int)(this.Width * WidthScale);
            this.Height = (int)(this.Height * HeightScale);

            dateTimePicker_homedate.Value = DateTime.Today;
            update_home();

            MyGlobalClass.ScaleParent(HeightScale, WidthScale, this);

            this.ResumeLayout();
            this.PerformLayout();
        }

        private void update_home()
        {
            this.SuspendLayout();
            listbox_showarrivals.SelectedIndexChanged -= listbox_showarrivals_SelectedIndexChanged;
            listbox_showdepartures.SelectedIndexChanged -= listbox_showdepartures_SelectedIndexChanged;
            listbox_vaccinations.SelectedIndexChanged -= listbox_vaccinations_SelectedIndexChanged;
            listBox_potentialrearrangings.SelectedIndexChanged -= listBox_potentialrearrangings_SelectedIndexChanged;
            string[,] ampmlookup = new string[0, 0];
            string[,] arrivals = new string[0, 0];
            string[,] departures = new string[0, 0];
            string[,] vaccinations = new string[0, 0];
            string[,] changes = new string[0, 0];
            string[,] rearrangearray = new string[0, 0];
            int heldbookingcount = 0;
            int count = 0;

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`arrival/departure times`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                count++;
            }
            MyGlobalClass.new_connection.Close();
            ampmlookup = new string[count, 2];
            count = 0;
            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`arrival/departure times`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                ampmlookup[count, 0] = MyGlobalClass.SQL_Alter_Database["Arrival/Departure Time ID"].ToString();
                ampmlookup[count, 1] = MyGlobalClass.SQL_Alter_Database["Arrival/Departure Time"].ToString();
                count++;
            }
            MyGlobalClass.new_connection.Close();
            count = 0;

            #region arrivalsanddepartures

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Arrival Date` = '" + dateTimePicker_homedate.Value.ToString("yyyy-MM-dd") + "';", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                count++;
            }
            MyGlobalClass.new_connection.Close();
            arrivals = new string[count, 3];
            count = 0;
            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Arrival Date` = '" + dateTimePicker_homedate.Value.ToString("yyyy-MM-dd") + "';", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                arrivals[count, 0] = MyGlobalClass.SQL_Alter_Database["Booking ID"].ToString();
                for (int i = 0; i < ampmlookup.GetLength(0); i++)
                {
                    if (MyGlobalClass.SQL_Alter_Database["Arrival Time ID"].ToString() == ampmlookup[i, 0])
                    {
                        arrivals[count, 1] = ampmlookup[i, 1];
                    }
                }
                arrivals[count, 2] = MyGlobalClass.SQL_Alter_Database["Chalet"].ToString();
                count++;
            }
            MyGlobalClass.new_connection.Close();
            count = 0;

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Departure Date` = '" + dateTimePicker_homedate.Value.ToString("yyyy-MM-dd") + "';", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                count++;
            }
            MyGlobalClass.new_connection.Close();
            departures = new string[count, 3];
            count = 0;
            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Departure Date` = '" + dateTimePicker_homedate.Value.ToString("yyyy-MM-dd") + "';", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                departures[count, 0] = MyGlobalClass.SQL_Alter_Database["Booking ID"].ToString();
                for (int i = 0; i < ampmlookup.GetLength(0); i++)
                {
                    if (MyGlobalClass.SQL_Alter_Database["Departure Time ID"].ToString() == ampmlookup[i, 0])
                    {
                        departures[count, 1] = ampmlookup[i, 1];
                    }
                }
                departures[count, 2] = MyGlobalClass.SQL_Alter_Database["Chalet"].ToString();
                count++;
            }
            MyGlobalClass.new_connection.Close();
            count = 0;

            #region arrivalrearranging

            rearrangearray = new string[arrivals.GetLength(0), 3];
            for (int booking = 0; booking < arrivals.GetLength(0); booking++)
            {
                if (arrivals[booking, 1] == "AM")
                {
                    rearrangearray[count, 0] = arrivals[booking, 0];
                    rearrangearray[count, 1] = arrivals[booking, 1];
                    rearrangearray[count, 2] = arrivals[booking, 2];
                    count++;
                }
            }
            for (int booking = 0; booking < arrivals.GetLength(0); booking++)
            {
                if (arrivals[booking, 1] == "PM")
                {
                    rearrangearray[count, 0] = arrivals[booking, 0];
                    rearrangearray[count, 1] = arrivals[booking, 1];
                    rearrangearray[count, 2] = arrivals[booking, 2];
                    count++;
                }
            }
            for (int booking = 0; booking < arrivals.GetLength(0); booking++)
            {
                if (arrivals[booking, 1] != "AM" && arrivals[booking, 1] != "PM")
                {
                    rearrangearray[count, 0] = arrivals[booking, 0];
                    rearrangearray[count, 1] = arrivals[booking, 1];
                    rearrangearray[count, 2] = arrivals[booking, 2];
                    count++;
                }
            }
            arrivals = new string[rearrangearray.GetLength(0), 3];
            for (int booking = 0; booking < rearrangearray.GetLength(0); booking++)
            {
                bool inserted = false;
                if (rearrangearray[booking, 1] != "AM")
                {
                    inserted = true;
                }
                for (int slot = 0; slot < arrivals.GetLength(0) && inserted == false; slot++)
                {
                    if (arrivals[slot, 0] == null)
                    {
                        arrivals[slot, 0] = rearrangearray[booking, 0];
                        arrivals[slot, 1] = rearrangearray[booking, 1];
                        arrivals[slot, 2] = rearrangearray[booking, 2];
                        inserted = true;
                    }
                    else
                    {
                        int chalet = int.Parse(rearrangearray[booking, 2]);
                        int chaletcompare = int.Parse(arrivals[slot, 2]);
                        if (chalet < chaletcompare)
                        {
                            for (int move = arrivals.GetLength(0) - 2; move >= slot; move = move - 1)
                            {
                                arrivals[move + 1, 0] = arrivals[move, 0];
                                arrivals[move + 1, 1] = arrivals[move, 1];
                                arrivals[move + 1, 2] = arrivals[move, 2];
                            }
                            arrivals[slot, 0] = rearrangearray[booking, 0];
                            arrivals[slot, 1] = rearrangearray[booking, 1];
                            arrivals[slot, 2] = rearrangearray[booking, 2];
                            inserted = true;
                        }
                    }
                }
            }
            for (int booking = 0; booking < rearrangearray.GetLength(0); booking++)
            {
                bool inserted = false;
                if (rearrangearray[booking, 1] != "PM")
                {
                    inserted = true;
                }
                for (int slot = 0; slot < arrivals.GetLength(0) && inserted == false; slot++)
                {
                    if (arrivals[slot, 1] != "PM" && arrivals[slot, 1] != null)
                    {
                        //Ignore
                    }
                    else if (arrivals[slot, 0] == null)
                    {
                        arrivals[slot, 0] = rearrangearray[booking, 0];
                        arrivals[slot, 1] = rearrangearray[booking, 1];
                        arrivals[slot, 2] = rearrangearray[booking, 2];
                        inserted = true;
                    }
                    else
                    {
                        int chalet = int.Parse(rearrangearray[booking, 2]);
                        int chaletcompare = int.Parse(arrivals[slot, 2]);
                        if (chalet < chaletcompare)
                        {
                            for (int move = arrivals.GetLength(0) - 2; move >= slot; move = move - 1)
                            {
                                arrivals[move + 1, 0] = arrivals[move, 0];
                                arrivals[move + 1, 1] = arrivals[move, 1];
                                arrivals[move + 1, 2] = arrivals[move, 2];
                            }
                            arrivals[slot, 0] = rearrangearray[booking, 0];
                            arrivals[slot, 1] = rearrangearray[booking, 1];
                            arrivals[slot, 2] = rearrangearray[booking, 2];
                            inserted = true;
                        }
                    }
                }
            }
            for (int booking = 0; booking < rearrangearray.GetLength(0); booking++)
            {
                bool inserted = false;
                if (rearrangearray[booking, 1] == "AM" || rearrangearray[booking, 1] == "PM")
                {
                    inserted = true;
                }
                for (int slot = 0; slot < arrivals.GetLength(0) && inserted == false; slot++)
                {
                    if (arrivals[slot, 1] == "AM" || arrivals[slot, 1] == "PM")
                    {
                        //Ignore
                    }
                    else if (arrivals[slot, 0] == null)
                    {
                        arrivals[slot, 0] = rearrangearray[booking, 0];
                        arrivals[slot, 1] = rearrangearray[booking, 1];
                        arrivals[slot, 2] = rearrangearray[booking, 2];
                        inserted = true;
                    }
                    else
                    {
                        int chalet = int.Parse(rearrangearray[booking, 2]);
                        int chaletcompare = int.Parse(arrivals[slot, 2]);
                        if (chalet < chaletcompare)
                        {
                            for (int move = arrivals.GetLength(0) - 2; move >= slot; move = move - 1)
                            {
                                arrivals[move + 1, 0] = arrivals[move, 0];
                                arrivals[move + 1, 1] = arrivals[move, 1];
                                arrivals[move + 1, 2] = arrivals[move, 2];
                            }
                            arrivals[slot, 0] = rearrangearray[booking, 0];
                            arrivals[slot, 1] = rearrangearray[booking, 1];
                            arrivals[slot, 2] = rearrangearray[booking, 2];
                            inserted = true;
                        }
                    }
                }
            }
            count = 0;

            #endregion
            #region departurerearranging

            rearrangearray = new string[departures.GetLength(0), 3];
            for (int booking = 0; booking < departures.GetLength(0); booking++)
            {
                if (departures[booking, 1] == "AM")
                {
                    rearrangearray[count, 0] = departures[booking, 0];
                    rearrangearray[count, 1] = departures[booking, 1];
                    rearrangearray[count, 2] = departures[booking, 2];
                    count++;
                }
            }
            for (int booking = 0; booking < departures.GetLength(0); booking++)
            {
                if (departures[booking, 1] == "PM")
                {
                    rearrangearray[count, 0] = departures[booking, 0];
                    rearrangearray[count, 1] = departures[booking, 1];
                    rearrangearray[count, 2] = departures[booking, 2];
                    count++;
                }
            }
            for (int booking = 0; booking < departures.GetLength(0); booking++)
            {
                if (departures[booking, 1] != "AM" && departures[booking, 1] != "PM")
                {
                    rearrangearray[count, 0] = departures[booking, 0];
                    rearrangearray[count, 1] = departures[booking, 1];
                    rearrangearray[count, 2] = departures[booking, 2];
                    count++;
                }
            }
            departures = new string[rearrangearray.GetLength(0), 3];
            for (int booking = 0; booking < rearrangearray.GetLength(0); booking++)
            {
                bool inserted = false;
                if (rearrangearray[booking, 1] != "AM")
                {
                    inserted = true;
                }
                for (int slot = 0; slot < departures.GetLength(0) && inserted == false; slot++)
                {
                    if (departures[slot, 0] == null)
                    {
                        departures[slot, 0] = rearrangearray[booking, 0];
                        departures[slot, 1] = rearrangearray[booking, 1];
                        departures[slot, 2] = rearrangearray[booking, 2];
                        inserted = true;
                    }
                    else
                    {
                        int chalet = int.Parse(rearrangearray[booking, 2]);
                        int chaletcompare = int.Parse(departures[slot, 2]);
                        if (chalet < chaletcompare)
                        {
                            for (int move = departures.GetLength(0) - 2; move >= slot; move = move - 1)
                            {
                                departures[move + 1, 0] = departures[move, 0];
                                departures[move + 1, 1] = departures[move, 1];
                                departures[move + 1, 2] = departures[move, 2];
                            }
                            departures[slot, 0] = rearrangearray[booking, 0];
                            departures[slot, 1] = rearrangearray[booking, 1];
                            departures[slot, 2] = rearrangearray[booking, 2];
                            inserted = true;
                        }
                    }
                }
            }
            for (int booking = 0; booking < rearrangearray.GetLength(0); booking++)
            {
                bool inserted = false;
                if (rearrangearray[booking, 1] != "PM")
                {
                    inserted = true;
                }
                for (int slot = 0; slot < departures.GetLength(0) && inserted == false; slot++)
                {
                    if (departures[slot, 1] != "PM" && departures[slot, 1] != null)
                    {
                        //Ignore
                    }
                    else if (departures[slot, 0] == null)
                    {
                        departures[slot, 0] = rearrangearray[booking, 0];
                        departures[slot, 1] = rearrangearray[booking, 1];
                        departures[slot, 2] = rearrangearray[booking, 2];
                        inserted = true;
                    }
                    else
                    {
                        int chalet = int.Parse(rearrangearray[booking, 2]);
                        int chaletcompare = int.Parse(departures[slot, 2]);
                        if (chalet < chaletcompare)
                        {
                            for (int move = departures.GetLength(0) - 2; move >= slot; move = move - 1)
                            {
                                departures[move + 1, 0] = departures[move, 0];
                                departures[move + 1, 1] = departures[move, 1];
                                departures[move + 1, 2] = departures[move, 2];
                            }
                            departures[slot, 0] = rearrangearray[booking, 0];
                            departures[slot, 1] = rearrangearray[booking, 1];
                            departures[slot, 2] = rearrangearray[booking, 2];
                            inserted = true;
                        }
                    }
                }
            }
            for (int booking = 0; booking < rearrangearray.GetLength(0); booking++)
            {
                bool inserted = false;
                if (rearrangearray[booking, 1] == "AM" || rearrangearray[booking, 1] == "PM")
                {
                    inserted = true;
                }
                for (int slot = 0; slot < departures.GetLength(0) && inserted == false; slot++)
                {
                    if (departures[slot, 1] == "AM" || departures[slot, 1] == "PM")
                    {
                        //Ignore
                    }
                    else if (departures[slot, 0] == null)
                    {
                        departures[slot, 0] = rearrangearray[booking, 0];
                        departures[slot, 1] = rearrangearray[booking, 1];
                        departures[slot, 2] = rearrangearray[booking, 2];
                        inserted = true;
                    }
                    else
                    {
                        int chalet = int.Parse(rearrangearray[booking, 2]);
                        int chaletcompare = int.Parse(departures[slot, 2]);
                        if (chalet < chaletcompare)
                        {
                            for (int move = departures.GetLength(0) - 2; move >= slot; move = move - 1)
                            {
                                departures[move + 1, 0] = departures[move, 0];
                                departures[move + 1, 1] = departures[move, 1];
                                departures[move + 1, 2] = departures[move, 2];
                            }
                            departures[slot, 0] = rearrangearray[booking, 0];
                            departures[slot, 1] = rearrangearray[booking, 1];
                            departures[slot, 2] = rearrangearray[booking, 2];
                            inserted = true;
                        }
                    }
                }
            }
            count = 0;

            #endregion

            bool Continue = false;
            listbox_showarrivals.Items.Clear();
            for (int booking = 0; booking < arrivals.GetLength(0); booking++)
            {
                if (arrivals[booking, 1] == "AM")
                {
                    Continue = true;
                    string text = "" + arrivals[booking, 1] + "\t" + arrivals[booking, 2] + "\t";

                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Booking ID` = '" + arrivals[booking, 0] + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        MySqlConnection new_connection = new MySqlConnection(MyGlobalClass.connection_to_database);
                        MySqlCommand SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = '" + MyGlobalClass.SQL_Alter_Database["Registration ID"].ToString() + "';", new_connection);
                        new_connection.Open();
                        MySqlDataReader SQL_Alter_Database = SQL_Command.ExecuteReader();
                        int i = 1;
                        int n = 1;
                        bool end = false;
                        while (SQL_Alter_Database.Read())
                        {
                            end = false;
                            i = 1;
                            do
                            {
                                if (MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString() != "NULL")
                                {
                                    if (n > 1)
                                    {
                                        text = text + ", " + MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString() + "";
                                    }
                                    else if (n == 1)
                                    {
                                        text = text + MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString();
                                    }
                                    n++;
                                }
                                i++;
                            } while (i <= 6);
                            text = text + " ";
                            i = 1;
                            end = false;
                            do
                            {
                                if (SQL_Alter_Database["Owner " + i + " ID"].ToString() != "")
                                {
                                    MySqlConnection ownername = new MySqlConnection(MyGlobalClass.connection_to_database);
                                    MySqlCommand ownernamequery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact names` WHERE `Contact Name ID` = '" + SQL_Alter_Database["Owner " + i + " ID"].ToString() + "' ;", ownername);
                                    ownername.Open();
                                    MySqlDataReader readownername = ownernamequery.ExecuteReader();
                                    while (readownername.Read())
                                    {
                                        if (i == 1)
                                        {
                                            text = text + "(" + readownername["Contact Name"].ToString() + "";
                                        }
                                        else if (i > 1)
                                        {
                                            text = text + ", " + readownername["Contact Name"].ToString() + "";
                                        }
                                    }
                                    ownername.Close();
                                }
                                else
                                {
                                    if (i > 1)
                                    {
                                        text = text + ")";
                                        end = true;
                                    }
                                }
                                i++;
                            } while (i <= 6 && end == false);
                            if (end == false)
                            {
                                text = text + ")";
                            }
                        }
                        new_connection.Close();
                        if ((bool)MyGlobalClass.SQL_Alter_Database["Checked In"] == true)
                        {
                            text = text + " (Checked In)";
                        }
                    }
                    MyGlobalClass.new_connection.Close();

                    listbox_showarrivals.Items.Add(text);
                    count++;
                }
            }
            if (Continue == true)
            {
                listbox_showarrivals.Items.Add("");
                count++;
                Continue = false;
            }
            for (int booking = 0; booking < arrivals.GetLength(0); booking++)
            {
                if (arrivals[booking, 1] == "PM")
                {
                    Continue = true;
                    string text = "" + arrivals[booking, 1] + "\t" + arrivals[booking, 2] + "\t";

                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Booking ID` = '" + arrivals[booking, 0] + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        MySqlConnection new_connection = new MySqlConnection(MyGlobalClass.connection_to_database);
                        MySqlCommand SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = '" + MyGlobalClass.SQL_Alter_Database["Registration ID"].ToString() + "';", new_connection);
                        new_connection.Open();
                        MySqlDataReader SQL_Alter_Database = SQL_Command.ExecuteReader();
                        int i = 1;
                        int n = 1;
                        bool end = false;
                        while (SQL_Alter_Database.Read())
                        {
                            end = false;
                            i = 1;
                            do
                            {
                                if (MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString() != "NULL")
                                {
                                    if (n > 1)
                                    {
                                        text = text + ", " + MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString() + "";
                                    }
                                    else if (n == 1)
                                    {
                                        text = text + MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString();
                                    }
                                    n++;
                                }
                                i++;
                            } while (i <= 6);
                            text = text + " ";
                            i = 1;
                            end = false;
                            do
                            {
                                if (SQL_Alter_Database["Owner " + i + " ID"].ToString() != "")
                                {
                                    MySqlConnection ownername = new MySqlConnection(MyGlobalClass.connection_to_database);
                                    MySqlCommand ownernamequery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact names` WHERE `Contact Name ID` = '" + SQL_Alter_Database["Owner " + i + " ID"].ToString() + "' ;", ownername);
                                    ownername.Open();
                                    MySqlDataReader readownername = ownernamequery.ExecuteReader();
                                    while (readownername.Read())
                                    {
                                        if (i == 1)
                                        {
                                            text = text + "(" + readownername["Contact Name"].ToString() + "";
                                        }
                                        else if (i > 1)
                                        {
                                            text = text + ", " + readownername["Contact Name"].ToString() + "";
                                        }
                                    }
                                    ownername.Close();
                                }
                                else
                                {
                                    if (i > 1)
                                    {
                                        text = text + ")";
                                        end = true;
                                    }
                                }
                                i++;
                            } while (i <= 6 && end == false);
                            if (end == false)
                            {
                                text = text + ")";
                            }
                        }
                        new_connection.Close();
                        if ((bool)MyGlobalClass.SQL_Alter_Database["Checked In"] == true)
                        {
                            text = text + " (Checked In)";
                        }
                    }
                    MyGlobalClass.new_connection.Close();

                    listbox_showarrivals.Items.Add(text);
                    count++;
                }
            }
            if (Continue == true)
            {
                listbox_showarrivals.Items.Add("");
                count++;
                Continue = false;
            }
            for (int booking = 0; booking < arrivals.GetLength(0); booking++)
            {
                if (arrivals[booking, 1] != "AM" && arrivals[booking, 1] != "PM")
                {
                    string text = "" + arrivals[booking, 1] + "\t" + arrivals[booking, 2] + "\t";

                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Booking ID` = '" + arrivals[booking, 0] + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        MySqlConnection new_connection = new MySqlConnection(MyGlobalClass.connection_to_database);
                        MySqlCommand SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = '" + MyGlobalClass.SQL_Alter_Database["Registration ID"].ToString() + "';", new_connection);
                        new_connection.Open();
                        MySqlDataReader SQL_Alter_Database = SQL_Command.ExecuteReader();
                        int i = 1;
                        int n = 1;
                        bool end = false;
                        while (SQL_Alter_Database.Read())
                        {
                            end = false;
                            i = 1;
                            do
                            {
                                if (MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString() != "NULL")
                                {
                                    if (n > 1)
                                    {
                                        text = text + ", " + MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString() + "";
                                    }
                                    else if (n == 1)
                                    {
                                        text = text + MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString();
                                    }
                                    n++;
                                }
                                i++;
                            } while (i <= 6);
                            text = text + " ";
                            i = 1;
                            end = false;
                            do
                            {
                                if (SQL_Alter_Database["Owner " + i + " ID"].ToString() != "")
                                {
                                    MySqlConnection ownername = new MySqlConnection(MyGlobalClass.connection_to_database);
                                    MySqlCommand ownernamequery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact names` WHERE `Contact Name ID` = '" + SQL_Alter_Database["Owner " + i + " ID"].ToString() + "' ;", ownername);
                                    ownername.Open();
                                    MySqlDataReader readownername = ownernamequery.ExecuteReader();
                                    while (readownername.Read())
                                    {
                                        if (i == 1)
                                        {
                                            text = text + "(" + readownername["Contact Name"].ToString() + "";
                                        }
                                        else if (i > 1)
                                        {
                                            text = text + ", " + readownername["Contact Name"].ToString() + "";
                                        }
                                    }
                                    ownername.Close();
                                }
                                else
                                {
                                    if (i > 1)
                                    {
                                        text = text + ")";
                                        end = true;
                                    }
                                }
                                i++;
                            } while (i <= 6 && end == false);
                            if (end == false)
                            {
                                text = text + ")";
                            }
                        }
                        new_connection.Close();
                        if ((bool)MyGlobalClass.SQL_Alter_Database["Checked In"] == true)
                        {
                            text = text + " (Checked In)";
                        }
                    }
                    MyGlobalClass.new_connection.Close();

                    listbox_showarrivals.Items.Add(text);
                    count++;
                }
            }
            MyGlobalClass.updatelistboxwidth(listbox_showarrivals, 2, 658);
            Arrivals = new string[count];
            count = 0;
            Continue = false;
            for (int booking = 0; booking < arrivals.GetLength(0); booking++)
            {
                if (arrivals[booking, 1] == "AM")
                {
                    Continue = true;
                    Arrivals[count] = arrivals[booking, 0];
                    count++;
                }
            }
            if (Continue == true)
            {
                count++;
                Continue = false;
            }
            for (int booking = 0; booking < arrivals.GetLength(0); booking++)
            {
                if (arrivals[booking, 1] == "PM")
                {
                    Continue = true;
                    Arrivals[count] = arrivals[booking, 0];
                    count++;
                }
            }
            if (Continue == true)
            {
                count++;
                Continue = false;
            }
            for (int booking = 0; booking < arrivals.GetLength(0); booking++)
            {
                if (arrivals[booking, 1] != "AM" && arrivals[booking, 1] != "PM")
                {
                    Arrivals[count] = arrivals[booking, 0];
                    count++;
                }
            }
            count = 0;

            Continue = false;
            listbox_showdepartures.Items.Clear();
            for (int booking = 0; booking < departures.GetLength(0); booking++)
            {
                if (departures[booking, 1] == "AM")
                {
                    Continue = true;
                    string text = "" + departures[booking, 1] + "\t" + departures[booking, 2] + "\t";

                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Booking ID` = '" + departures[booking, 0] + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        MySqlConnection new_connection = new MySqlConnection(MyGlobalClass.connection_to_database);
                        MySqlCommand SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = '" + MyGlobalClass.SQL_Alter_Database["Registration ID"].ToString() + "';", new_connection);
                        new_connection.Open();
                        MySqlDataReader SQL_Alter_Database = SQL_Command.ExecuteReader();
                        int i = 1;
                        int n = 1;
                        bool end = false;
                        while (SQL_Alter_Database.Read())
                        {
                            end = false;
                            i = 1;
                            do
                            {
                                if (MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString() != "NULL")
                                {
                                    if (n > 1)
                                    {
                                        text = text + ", " + MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString() + "";
                                    }
                                    else if (n == 1)
                                    {
                                        text = text + MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString();
                                    }
                                    n++;
                                }
                                i++;
                            } while (i <= 6);
                            text = text + " ";
                            i = 1;
                            end = false;
                            do
                            {
                                if (SQL_Alter_Database["Owner " + i + " ID"].ToString() != "")
                                {
                                    MySqlConnection ownername = new MySqlConnection(MyGlobalClass.connection_to_database);
                                    MySqlCommand ownernamequery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact names` WHERE `Contact Name ID` = '" + SQL_Alter_Database["Owner " + i + " ID"].ToString() + "' ;", ownername);
                                    ownername.Open();
                                    MySqlDataReader readownername = ownernamequery.ExecuteReader();
                                    while (readownername.Read())
                                    {
                                        if (i == 1)
                                        {
                                            text = text + "(" + readownername["Contact Name"].ToString() + "";
                                        }
                                        else if (i > 1)
                                        {
                                            text = text + ", " + readownername["Contact Name"].ToString() + "";
                                        }
                                    }
                                    ownername.Close();
                                }
                                else
                                {
                                    if (i > 1)
                                    {
                                        text = text + ")";
                                        end = true;
                                    }
                                }
                                i++;
                            } while (i <= 6 && end == false);
                            if (end == false)
                            {
                                text = text + ")";
                            }
                        }
                        new_connection.Close();
                        if ((bool)MyGlobalClass.SQL_Alter_Database["Checked Out"] == true)
                        {
                            text = text + " (Checked Out)";
                        }
                    }
                    MyGlobalClass.new_connection.Close();

                    listbox_showdepartures.Items.Add(text);
                    count++;
                }
            }
            if (Continue == true)
            {
                listbox_showdepartures.Items.Add("");
                count++;
                Continue = false;
            }
            for (int booking = 0; booking < departures.GetLength(0); booking++)
            {
                if (departures[booking, 1] == "PM")
                {
                    Continue = true;
                    string text = "" + departures[booking, 1] + "\t" + departures[booking, 2] + "\t";

                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Booking ID` = '" + departures[booking, 0] + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        MySqlConnection new_connection = new MySqlConnection(MyGlobalClass.connection_to_database);
                        MySqlCommand SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = '" + MyGlobalClass.SQL_Alter_Database["Registration ID"].ToString() + "';", new_connection);
                        new_connection.Open();
                        MySqlDataReader SQL_Alter_Database = SQL_Command.ExecuteReader();
                        int i = 1;
                        int n = 1;
                        bool end = false;
                        while (SQL_Alter_Database.Read())
                        {
                            end = false;
                            i = 1;
                            do
                            {
                                if (MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString() != "NULL")
                                {
                                    if (n > 1)
                                    {
                                        text = text + ", " + MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString() + "";
                                    }
                                    else if (n == 1)
                                    {
                                        text = text + MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString();
                                    }
                                    n++;
                                }
                                i++;
                            } while (i <= 6);
                            text = text + " ";
                            i = 1;
                            end = false;
                            do
                            {
                                if (SQL_Alter_Database["Owner " + i + " ID"].ToString() != "")
                                {
                                    MySqlConnection ownername = new MySqlConnection(MyGlobalClass.connection_to_database);
                                    MySqlCommand ownernamequery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact names` WHERE `Contact Name ID` = '" + SQL_Alter_Database["Owner " + i + " ID"].ToString() + "' ;", ownername);
                                    ownername.Open();
                                    MySqlDataReader readownername = ownernamequery.ExecuteReader();
                                    while (readownername.Read())
                                    {
                                        if (i == 1)
                                        {
                                            text = text + "(" + readownername["Contact Name"].ToString() + "";
                                        }
                                        else if (i > 1)
                                        {
                                            text = text + ", " + readownername["Contact Name"].ToString() + "";
                                        }
                                    }
                                    ownername.Close();
                                }
                                else
                                {
                                    if (i > 1)
                                    {
                                        text = text + ")";
                                        end = true;
                                    }
                                }
                                i++;
                            } while (i <= 6 && end == false);
                            if (end == false)
                            {
                                text = text + ")";
                            }
                        }
                        new_connection.Close();
                        if ((bool)MyGlobalClass.SQL_Alter_Database["Checked Out"] == true)
                        {
                            text = text + " (Checked Out)";
                        }
                    }
                    MyGlobalClass.new_connection.Close();

                    listbox_showdepartures.Items.Add(text);
                    count++;
                }
            }
            if (Continue == true)
            {
                listbox_showdepartures.Items.Add("");
                count++;
                Continue = false;
            }
            for (int booking = 0; booking < departures.GetLength(0); booking++)
            {
                if (departures[booking, 1] != "AM" && departures[booking, 1] != "PM")
                {
                    string text = "" + departures[booking, 1] + "\t" + departures[booking, 2] + "\t";

                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Booking ID` = '" + departures[booking, 0] + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        MySqlConnection new_connection = new MySqlConnection(MyGlobalClass.connection_to_database);
                        MySqlCommand SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = '" + MyGlobalClass.SQL_Alter_Database["Registration ID"].ToString() + "';", new_connection);
                        new_connection.Open();
                        MySqlDataReader SQL_Alter_Database = SQL_Command.ExecuteReader();
                        int i = 1;
                        int n = 1;
                        bool end = false;
                        while (SQL_Alter_Database.Read())
                        {
                            end = false;
                            i = 1;
                            do
                            {
                                if (MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString() != "NULL")
                                {
                                    if (n > 1)
                                    {
                                        text = text + ", " + MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString() + "";
                                    }
                                    else if (n == 1)
                                    {
                                        text = text + MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString();
                                    }
                                    n++;
                                }
                                i++;
                            } while (i <= 6);
                            text = text + " ";
                            i = 1;
                            end = false;
                            do
                            {
                                if (SQL_Alter_Database["Owner " + i + " ID"].ToString() != "")
                                {
                                    MySqlConnection ownername = new MySqlConnection(MyGlobalClass.connection_to_database);
                                    MySqlCommand ownernamequery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact names` WHERE `Contact Name ID` = '" + SQL_Alter_Database["Owner " + i + " ID"].ToString() + "' ;", ownername);
                                    ownername.Open();
                                    MySqlDataReader readownername = ownernamequery.ExecuteReader();
                                    while (readownername.Read())
                                    {
                                        if (i == 1)
                                        {
                                            text = text + "(" + readownername["Contact Name"].ToString() + "";
                                        }
                                        else if (i > 1)
                                        {
                                            text = text + ", " + readownername["Contact Name"].ToString() + "";
                                        }
                                    }
                                    ownername.Close();
                                }
                                else
                                {
                                    if (i > 1)
                                    {
                                        text = text + ")";
                                        end = true;
                                    }
                                }
                                i++;
                            } while (i <= 6 && end == false);
                            if (end == false)
                            {
                                text = text + ")";
                            }
                        }
                        new_connection.Close();
                        if ((bool)MyGlobalClass.SQL_Alter_Database["Checked Out"] == true)
                        {
                            text = text + " (Checked Out)";
                        }
                    }
                    MyGlobalClass.new_connection.Close();

                    listbox_showdepartures.Items.Add(text);
                    count++;
                }
            }
            MyGlobalClass.updatelistboxwidth(listbox_showdepartures, 2, 662);
            Departures = new string[count];
            count = 0;
            Continue = false;
            for (int booking = 0; booking < departures.GetLength(0); booking++)
            {
                if (departures[booking, 1] == "AM")
                {
                    Continue = true;
                    Departures[count] = departures[booking, 0];
                    count++;
                }
            }
            if (Continue == true)
            {
                count++;
                Continue = false;
            }
            for (int booking = 0; booking < departures.GetLength(0); booking++)
            {
                if (departures[booking, 1] == "PM")
                {
                    Continue = true;
                    Departures[count] = departures[booking, 0];
                    count++;
                }
            }
            if (Continue == true)
            {
                count++;
                Continue = false;
            }
            for (int booking = 0; booking < departures.GetLength(0); booking++)
            {
                if (departures[booking, 1] != "AM" && departures[booking, 1] != "PM")
                {
                    Departures[count] = departures[booking, 0];
                    count++;
                }
            }
            count = 0;

            #endregion
            #region vaccinations

            MyGlobalClass.updatechaletnumber(false, MyGlobalClass.totalchalets, true);
            for (int chalet = 1; chalet <= MyGlobalClass.totalchalets; chalet++)
            {
                MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`" + chalet + "` WHERE `Date` = '" + (dateTimePicker_homedate.Value.ToString("yyyy-MM-dd")) + "';", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                while (MyGlobalClass.SQL_Alter_Database.Read())
                {
                    count++;
                }
                MyGlobalClass.new_connection.Close();
            }
            vaccinations = new string[count, 10];
            count = 0;
            for (int chalet = 1; chalet <= MyGlobalClass.totalchalets; chalet++)
            {
                MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`" + chalet + "` WHERE `Date` = '" + (dateTimePicker_homedate.Value.ToString("yyyy-MM-dd")) + "';", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                while (MyGlobalClass.SQL_Alter_Database.Read())
                {
                    vaccinations[count, 0] = MyGlobalClass.SQL_Alter_Database["Booking ID"].ToString();
                    count++;
                }
                MyGlobalClass.new_connection.Close();
            }
            count = 0;

            rearrangearray = new string[vaccinations.GetLength(0), 10];
            for (int booking = 0; booking < vaccinations.GetLength(0); booking++)
            {
                bool vaccination = false;
                MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Booking ID` = '" + vaccinations[booking, 0] + "';", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                while (MyGlobalClass.SQL_Alter_Database.Read())
                {
                    for (int i = 1; i <= 6; i++)
                    {
                        try
                        {
                            if ((bool)MyGlobalClass.SQL_Alter_Database["Cat " + i + " Vaccination"] != true)
                            {
                                vaccination = true;
                            }
                        }
                        catch
                        {
                            vaccination = true;
                        }
                    }
                    if (vaccination == true)
                    {
                        rearrangearray[count, 0] = vaccinations[booking, 0];
                        for (int i = 1; i <= 6; i++)
                        {
                            try
                            {
                                if ((bool)MyGlobalClass.SQL_Alter_Database["Cat " + i + " Vaccination"] != true)
                                {
                                    rearrangearray[count, i] = MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString();
                                }
                            }
                            catch
                            {
                                rearrangearray[count, i] = MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString();
                                rearrangearray[count, 7] = "(Done)";
                            }
                        }
                        rearrangearray[count, 8] = MyGlobalClass.SQL_Alter_Database["Chalet"].ToString();
                        rearrangearray[count, 9] = MyGlobalClass.SQL_Alter_Database["Registration ID"].ToString();
                        count++;
                    }
                }
                MyGlobalClass.new_connection.Close();
            }
            vaccinations = new string[count, 10];
            count = 0;
            for (int booking = 0; booking < vaccinations.GetLength(0); booking++)
            {
                MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = '" + rearrangearray[booking, 9] + "'", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                while (MyGlobalClass.SQL_Alter_Database.Read())
                {
                    for (int i = 1; i <= 6; i++)
                    {
                        if (MyGlobalClass.SQL_Alter_Database["Cat " + i + " ID"].ToString() != "")
                        {
                            MySqlConnection newconnection = new MySqlConnection(MyGlobalClass.connection_to_database);
                            MySqlCommand command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`cats` WHERE `Cat ID` = '" + MyGlobalClass.SQL_Alter_Database["Cat " + i + " ID"].ToString() + "'", newconnection);
                            newconnection.Open();
                            MySqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                if (DateTime.Parse(reader["Next Vaccination Date"].ToString()) > dateTimePicker_homedate.Value)
                                {
                                    rearrangearray[booking, i] = null;
                                }
                                else if (DateTime.Parse(reader["Next Vaccination Date"].ToString()) < dateTimePicker_homedate.Value && rearrangearray[booking, 7] == "(Done)")
                                {
                                    rearrangearray[booking, i] = null;
                                }
                            }
                            newconnection.Close();
                        }
                    }
                }
                MyGlobalClass.new_connection.Close();
                bool catremaining = false;
                for (int i = 1; i <= 6; i++)
                {
                    if (rearrangearray[booking, i] != null)
                    {
                        catremaining = true;
                    }
                }
                if (catremaining == true)
                {
                    vaccinations[count, 0] = rearrangearray[booking, 0];
                    vaccinations[count, 1] = rearrangearray[booking, 1];
                    vaccinations[count, 2] = rearrangearray[booking, 2];
                    vaccinations[count, 3] = rearrangearray[booking, 3];
                    vaccinations[count, 4] = rearrangearray[booking, 4];
                    vaccinations[count, 5] = rearrangearray[booking, 5];
                    vaccinations[count, 6] = rearrangearray[booking, 6];
                    vaccinations[count, 7] = rearrangearray[booking, 7];
                    vaccinations[count, 8] = rearrangearray[booking, 8];
                    vaccinations[count, 9] = rearrangearray[booking, 9];
                    count++;
                }
            }
            Vaccinations = new string[count];
            count = 0;
            listbox_vaccinations.Items.Clear();
            for (int booking = 0; booking < Vaccinations.GetLength(0); booking++)
            {
                count = 0;
                Vaccinations[booking] = vaccinations[booking, 0];
                string text = "" + vaccinations[booking, 8] + "\t\t";
                for (int cat = 1; cat <= 6; cat++)
                {
                    if (vaccinations[booking, cat] != null)
                    {
                        if (count == 0)
                        {
                            text = text + vaccinations[booking, cat];
                        }
                        else
                        {
                            text = text + ", " + vaccinations[booking, cat] + "";
                        }
                        count++;
                    }
                }
                text = text + " ";
                int i = 1;
                bool end = false;
                do
                {
                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = '" + vaccinations[booking, 9] + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        if (MyGlobalClass.SQL_Alter_Database["Owner " + i + " ID"].ToString() != "")
                        {
                            MySqlConnection ownername = new MySqlConnection(MyGlobalClass.connection_to_database);
                            MySqlCommand ownernamequery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact names` WHERE `Contact Name ID` = '" + MyGlobalClass.SQL_Alter_Database["Owner " + i + " ID"].ToString() + "' ;", ownername);
                            ownername.Open();
                            MySqlDataReader readownername = ownernamequery.ExecuteReader();
                            while (readownername.Read())
                            {
                                if (i == 1)
                                {
                                    text = text + "(" + readownername["Contact Name"].ToString() + "";
                                }
                                else if (i > 1)
                                {
                                    text = text + ", " + readownername["Contact Name"].ToString() + "";
                                }
                            }
                            ownername.Close();
                        }
                        else
                        {
                            if (i > 1)
                            {
                                text = text + ")";
                                end = true;
                            }
                        }
                        i++;
                    }
                    MyGlobalClass.new_connection.Close();
                } while (i <= 6 && end == false);
                if (end == false)
                {
                    text = text + ")";
                }
                text = text + vaccinations[booking, 7];
                listbox_vaccinations.Items.Add(text);
            }
            MyGlobalClass.updatelistboxwidth(listbox_vaccinations, 2, 658);
            count = 0;

            #endregion
            #region changes

            MyGlobalClass.CheckHeldBookings();

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`potential changes`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                if (MyGlobalClass.SQL_Alter_Database["New Chalet"].ToString() != "-1")
                {
                    count++;
                }
                else
                {
                    heldbookingcount++;
                }
            }
            MyGlobalClass.new_connection.Close();
            changes = new string[count, 4];
            HeldBookings = new string[heldbookingcount, 9];
            count = 0;
            heldbookingcount = 0;
            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`potential changes`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                if (MyGlobalClass.SQL_Alter_Database["New Chalet"].ToString() != "-1")
                {
                    changes[count, 0] = MyGlobalClass.SQL_Alter_Database["New Chalet"].ToString();
                    changes[count, 1] = MyGlobalClass.SQL_Alter_Database["Arrival Date"].ToString();
                    changes[count, 2] = MyGlobalClass.SQL_Alter_Database["Departure Date"].ToString();
                    changes[count, 3] = MyGlobalClass.SQL_Alter_Database["Pair"].ToString();
                    count++;
                }
                else
                {
                    HeldBookings[heldbookingcount, 0] = MyGlobalClass.SQL_Alter_Database["Booking ID"].ToString();
                    HeldBookings[heldbookingcount, 8] = MyGlobalClass.SQL_Alter_Database["ID"].ToString();
                    heldbookingcount++;
                }
            }
            MyGlobalClass.new_connection.Close();

            rearrangearray = new string[changes.GetLength(0), 4];
            count = 0;
            for (int booking = 0; booking < changes.GetLength(0); booking++)
            {
                bool duplicate = false;
                for (int safebooking = 0; safebooking < rearrangearray.GetLength(0); safebooking++)
                {
                    if (changes[booking, 0] == rearrangearray[safebooking, 0]
                        && changes[booking, 1] == rearrangearray[safebooking, 1]
                        && changes[booking, 2] == rearrangearray[safebooking, 2])
                    {
                        duplicate = true;
                    }
                }
                if (duplicate == false)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        rearrangearray[count, i] = changes[booking, i];
                    }
                    count++;
                }
                else
                {
                    MyGlobalClass.SQL_Command = new MySqlCommand("DELETE FROM `chichester_cattery_booking_system`.`potential changes` WHERE `Pair` = '" + changes[booking, 3] + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    MyGlobalClass.new_connection.Close();
                }
            }
            changes = new string[count, 5];

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    changes[i, j] = rearrangearray[i, j];
                }
            }

            rearrangearray = new string[HeldBookings.GetLength(0), 8];
            count = 0;
            for (int held = 0; held < HeldBookings.GetLength(0); held++)
            {
                bool duplicate = false;
                for (int safeheld = 0; safeheld < rearrangearray.GetLength(0); safeheld++)
                {
                    if (HeldBookings[held, 0] == rearrangearray[safeheld, 0])
                    {
                        duplicate = true;
                    }
                }
                if (duplicate == false)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        rearrangearray[count, i] = HeldBookings[held, i];
                    }
                    count++;
                }
                else
                {
                    MyGlobalClass.SQL_Command = new MySqlCommand("DELETE FROM `chichester_cattery_booking_system`.`potential changes` WHERE `ID` = '" + HeldBookings[held, 8] + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    MyGlobalClass.new_connection.Close();
                }
            }
            HeldBookings = new string[count, 8];

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    HeldBookings[i, j] = rearrangearray[i, j];
                }
            }

            for (int booking = 0; booking < changes.GetLength(0); booking++)
            {
                MyGlobalClass.SQL_Command = new MySqlCommand("DELETE FROM `chichester_cattery_booking_system`.`potential changes` WHERE `Pair` = '" + changes[booking, 3] + "';", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                MyGlobalClass.new_connection.Close();

                MyGlobalClass.potentialrearranging(DateTime.Parse(changes[booking, 1]), DateTime.Parse(changes[booking, 2]), changes[booking, 0]);
            }
            count = 0;

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`potential changes`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                if (MyGlobalClass.SQL_Alter_Database["New Chalet"].ToString() != "-1")
                {
                    count++;
                }
            }
            MyGlobalClass.new_connection.Close();
            changes = new string[count, 11];
            count = 0;
            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`potential changes`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                if (MyGlobalClass.SQL_Alter_Database["New Chalet"].ToString() != "-1")
                {
                    changes[count, 0] = MyGlobalClass.SQL_Alter_Database["Booking ID"].ToString();
                    changes[count, 2] = MyGlobalClass.SQL_Alter_Database["New Chalet"].ToString();
                    changes[count, 10] = MyGlobalClass.SQL_Alter_Database["Change Improvement"].ToString();
                    count++;
                }
            }
            MyGlobalClass.new_connection.Close();
            count = 0;

            bool[] valid = new bool[changes.GetLength(0)];
            for (int booking = 0; booking < changes.GetLength(0); booking++)
            {
                MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Booking ID` = '" + changes[booking, 0] + "';", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                while (MyGlobalClass.SQL_Alter_Database.Read())
                {
                    changes[booking, 1] = MyGlobalClass.SQL_Alter_Database["Chalet"].ToString();
                    for (int i = 1; i <= 6; i++)
                    {
                        changes[booking, (i + 2)] = MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString();
                    }
                    changes[booking, 9] = MyGlobalClass.SQL_Alter_Database["Registration ID"].ToString();
                    if ((bool)MyGlobalClass.SQL_Alter_Database["Checked In"] == true)
                    {
                        valid[booking] = false;
                    }
                    else
                    {
                        valid[booking] = true;
                    }
                }
                MyGlobalClass.new_connection.Close();
            }
            for (int heldbooking = 0; heldbooking < HeldBookings.GetLength(0); heldbooking++)
            {
                MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Booking ID` = '" + HeldBookings[heldbooking, 0] + "';", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                while (MyGlobalClass.SQL_Alter_Database.Read())
                {
                    for (int i = 1; i <= 6; i++)
                    {
                        HeldBookings[heldbooking, (i + 1)] = MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString();
                    }
                    HeldBookings[heldbooking, 1] = MyGlobalClass.SQL_Alter_Database["Registration ID"].ToString();
                }
                MyGlobalClass.new_connection.Close();
            }

            rearrangearray = new string[changes.GetLength(0), 11];

            for (int booking = 0; booking < changes.GetLength(0); booking++)
            {
                bool inserted = false;
                if (valid[booking] == false)
                {
                    inserted = true;
                }
                for (int slot = 0; slot < rearrangearray.GetLength(0) && inserted == false; slot++)
                {
                    if (rearrangearray[slot, 0] == null)
                    {
                        for (int i = 0; i < 11; i++)
                        {
                            rearrangearray[slot, i] = changes[booking, i];
                        }
                        inserted = true;
                        count++;
                    }
                    else
                    {
                        int changeimprovement = int.Parse(changes[booking, 10]);
                        int comparison = int.Parse(rearrangearray[slot, 10]);
                        if (changeimprovement > comparison)
                        {
                            for (int move = rearrangearray.GetLength(0) - 2; move >= slot; move = move - 1)
                            {
                                for (int i = 0; i < 11; i++)
                                {
                                    rearrangearray[move + 1, i] = rearrangearray[move, i];
                                }
                            }
                            for (int i = 0; i < 11; i++)
                            {
                                rearrangearray[slot, i] = changes[booking, i];
                            }
                            inserted = true;
                            count++;
                        }
                    }
                }
            }
            changes = new string[count, 11];
            count = 0;

            for (int booking = 0; booking < changes.GetLength(0); booking++)
            {
                for (int i = 0; i < 11; i++)
                {
                    changes[booking, i] = rearrangearray[booking, i];
                }
            }

            Changes = new string[changes.GetLength(0), 3];
            listBox_potentialrearrangings.Items.Clear();
            for (int booking = 0; booking < changes.GetLength(0); booking++)
            {
                count = 0;
                Changes[booking, 0] = changes[booking, 0];
                Changes[booking, 1] = changes[booking, 1];
                Changes[booking, 2] = changes[booking, 2];
                string text = "" + changes[booking, 1] + " → " + changes[booking, 2] + "\t";
                for (int cat = 3; cat <= 8; cat++)
                {
                    if (changes[booking, cat] != "NULL")
                    {
                        if (count == 0)
                        {
                            text = text + changes[booking, cat];
                        }
                        else
                        {
                            text = text + ", " + changes[booking, cat] + "";
                        }
                        count++;
                    }
                }
                text = text + " ";
                int i = 1;
                bool end = false;
                do
                {
                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = '" + changes[booking, 9] + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        if (MyGlobalClass.SQL_Alter_Database["Owner " + i + " ID"].ToString() != "")
                        {
                            MySqlConnection ownername = new MySqlConnection(MyGlobalClass.connection_to_database);
                            MySqlCommand ownernamequery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact names` WHERE `Contact Name ID` = '" + MyGlobalClass.SQL_Alter_Database["Owner " + i + " ID"].ToString() + "';", ownername);
                            ownername.Open();
                            MySqlDataReader readownername = ownernamequery.ExecuteReader();
                            while (readownername.Read())
                            {
                                if (i == 1)
                                {
                                    text = text + "(" + readownername["Contact Name"].ToString() + "";
                                }
                                else if (i > 1)
                                {
                                    text = text + ", " + readownername["Contact Name"].ToString() + "";
                                }
                            }
                            ownername.Close();
                        }
                        else
                        {
                            if (i > 1)
                            {
                                text = text + ")";
                                end = true;
                            }
                        }
                        i++;
                    }
                    MyGlobalClass.new_connection.Close();
                } while (i <= 6 && end == false);
                if (end == false)
                {
                    text = text + ")";
                }
                listBox_potentialrearrangings.Items.Add(text);
            }
            for (int heldbooking = 0; heldbooking < HeldBookings.GetLength(0); heldbooking++)
            {
                count = 0;
                string text = "";
                for (int cat = 2; cat <= 7; cat++)
                {
                    if (HeldBookings[heldbooking, cat] != "NULL")
                    {
                        if (count == 0)
                        {
                            text = text + HeldBookings[heldbooking, cat];
                        }
                        else
                        {
                            text = text + ", " + HeldBookings[heldbooking, cat] + "";
                        }
                        count++;
                    }
                }
                text = text + " ";
                int i = 1;
                bool end = false;
                do
                {
                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = '" + HeldBookings[heldbooking, 1] + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        if (MyGlobalClass.SQL_Alter_Database["Owner " + i + " ID"].ToString() != "")
                        {
                            MySqlConnection ownername = new MySqlConnection(MyGlobalClass.connection_to_database);
                            MySqlCommand ownernamequery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact names` WHERE `Contact Name ID` = '" + MyGlobalClass.SQL_Alter_Database["Owner " + i + " ID"].ToString() + "';", ownername);
                            ownername.Open();
                            MySqlDataReader readownername = ownernamequery.ExecuteReader();
                            while (readownername.Read())
                            {
                                if (i == 1)
                                {
                                    text = text + "(" + readownername["Contact Name"].ToString() + "";
                                }
                                else if (i > 1)
                                {
                                    text = text + ", " + readownername["Contact Name"].ToString() + "";
                                }
                            }
                            ownername.Close();
                        }
                        else
                        {
                            if (i > 1)
                            {
                                text = text + ")";
                                end = true;
                            }
                        }
                        i++;
                    }
                    MyGlobalClass.new_connection.Close();
                } while (i <= 6 && end == false);
                if (end == false)
                {
                    text = text + ")";
                }
                listBox_potentialrearrangings.Items.Add(text);
            }

            MyGlobalClass.updatelistboxwidth(listBox_potentialrearrangings, 1, 658);
            count = 0;

            #endregion
            if (listbox_showarrivals.Items.Count != listboxitemcount[0, 0])
            {
                selectedindex[0, 0] = -1;
                listboxitemcount[0, 0] = listbox_showarrivals.Items.Count;
                splitcontainer_info_main.Panel1Collapsed = true;
            }
            if (listbox_showdepartures.Items.Count != listboxitemcount[0, 1])
            {
                selectedindex[0, 1] = -1;
                listboxitemcount[0, 1] = listbox_showdepartures.Items.Count;
                splitcontainer_info_main.Panel1Collapsed = true;
            }
            if (listbox_vaccinations.Items.Count != listboxitemcount[1, 0])
            {
                selectedindex[1, 0] = -1;
                listboxitemcount[1, 0] = listbox_vaccinations.Items.Count;
                splitcontainer_info_main.Panel1Collapsed = true;
            }
            if (listBox_potentialrearrangings.Items.Count != listboxitemcount[1, 1])
            {
                selectedindex[1, 1] = -1;
                listboxitemcount[1, 1] = listBox_potentialrearrangings.Items.Count;
                splitcontainer_info_main.Panel1Collapsed = true;
            }
            listbox_showarrivals.SelectedIndex = selectedindex[0, 0];
            listbox_showdepartures.SelectedIndex = selectedindex[0, 1];
            listbox_vaccinations.SelectedIndex = selectedindex[1, 0];
            listBox_potentialrearrangings.SelectedIndex = selectedindex[1, 1];
            listbox_showarrivals.SelectedIndexChanged += listbox_showarrivals_SelectedIndexChanged;
            listbox_showdepartures.SelectedIndexChanged += listbox_showdepartures_SelectedIndexChanged;
            listbox_vaccinations.SelectedIndexChanged += listbox_vaccinations_SelectedIndexChanged;
            listBox_potentialrearrangings.SelectedIndexChanged += listBox_potentialrearrangings_SelectedIndexChanged;
            this.ResumeLayout();
            this.PerformLayout();
        }

        private void update_infotextbox(string booking, bool dynamicchalet, bool showchalet)
        {
            string[,] cats = new string[6,2];
            string chalet = "";
            string text = "";
            if (dynamicchalet == true)
            {
                chalet = "Chalet: " + Changes[listBox_potentialrearrangings.SelectedIndex, 1] + " → " + Changes[listBox_potentialrearrangings.SelectedIndex, 2] + "";
            }
            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Booking ID` = '" + booking + "';", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                selectedregistration = MyGlobalClass.SQL_Alter_Database["Registration ID"].ToString();
                for (int i = 0; i < 6; i++)
                {
                    cats[i, 0] = MyGlobalClass.SQL_Alter_Database["Cat " + (i + 1) + " Staying"].ToString();
                    cats[i, 1] = MyGlobalClass.SQL_Alter_Database["Cat " + (i + 1) + " Vaccination"].ToString();
                }
                if (dynamicchalet == false && showchalet == true)
                {
                    chalet = "Chalet: " + MyGlobalClass.SQL_Alter_Database["Chalet"].ToString() + "";
                }
            }
            MyGlobalClass.new_connection.Close();
            text = MyGlobalClass.retrieveregistrationdata(selectedregistration, true);
            text = text + "\r\n\r\nCats:\r\n";
            int count = 0;
            for (int i = 0; i < cats.GetLength(0); i++)
            {
                if (cats[i,0] != "NULL")
                {
                    if (count == 0)
                    {
                        text = text + cats[i,0];
                    }
                    else
                    {
                        text = text + "\r\n" + cats[i,0] + "";
                    }
                    try
                    {
                        if (bool.Parse(cats[i,1]) != true)
                        {
                            text = text + " (Vaccination not done)";
                        }
                    }
                    catch
                    {
                        text = text + " (Vaccination done)";
                    }
                    count++;
                }
            }
            text = text + "\r\n\r\n" + chalet + "";
            text_mulitline_extrainfo.Text = text;
        }

        private void button_addbooking_Click(object sender, EventArgs e)
        {
            var newform = new form_addnewbooking(); //Initializes a new instance of the requested new form
            MyGlobalClass.previous_form_addnewbooking = new form_initialscreen(); //Sets the global previous_form_addnewbooking variable as the initialscreen form
            MyGlobalClass.CloseForm(newform, this); //Performs the CloseForm method
        }

        private void button_closeform_Click(object sender, EventArgs e)
        {
            MyGlobalClass.CloseApplication(this);//Performs the CloseApplication method
        }

        private void button_minimizeform_Click(object sender, EventArgs e)
        {
            MyGlobalClass.MinimizeApplication();//Performs the MinimizeApplication method
        }

        private void timer_initialscreen_Tick(object sender, EventArgs e)
        {
            MyGlobalClass.CheckFormCount(button_goback); //Performs the CheckFormCount method on button_goback
        }

        private void button_goback_Click(object sender, EventArgs e)
        {
            MyGlobalClass.GoBack(this); //Performs the GoBack method on the current form
        }

        private void button_search_registrations_Click(object sender, EventArgs e)
        {
            MyGlobalClass.registrationquery = MyGlobalClass.FillQuery(text_registration_query.Text, true, false, true);
            var newform = new form_registrationsystem();
            MyGlobalClass.CloseForm(newform, this);
        }

        private void button_search_bookings_Click(object sender, EventArgs e)
        {
            var newform = new form_bookingsystem();
            MyGlobalClass.FillQuery(text_booking_query.Text, true, true, false);
            MyGlobalClass.CloseForm(newform, this);
        }

        private void button_backup_Click(object sender, EventArgs e)
        {
            var newform = new form_backupandchalets();
            bool found = false;
            for (int i = 0; i < Application.OpenForms.Count; i++) //Shouldn't be necessary but checks if the 'Backup' form is already open
            {
                Form openform = Application.OpenForms[i];
                if (openform.Name == newform.Name)
                {
                    newform.Close();
                    openform.BringToFront();
                    found = true;
                }
            }
            if (found == false)
            {
                newform.ShowDialog(this); //If the requested new form is not already open, show a dialog above the 'Home' form
            }
        }

        private void button_registrations_Click(object sender, EventArgs e)
        {
            var newform = new form_registrationsystem();
            MyGlobalClass.CloseForm(newform, this);
        }

        private void button_bookings_Click(object sender, EventArgs e)
        {
            var newform = new form_bookingsystem();
            MyGlobalClass.CloseForm(newform, this);
        }

        private void button_minusoneday_Click(object sender, EventArgs e)
        {
            dateTimePicker_homedate.Value = dateTimePicker_homedate.Value.AddDays(-1);
        }

        private void dateTimePicker_homedate_ValueChanged(object sender, EventArgs e)
        {
            selectedindex = new int[2, 2] { { -1, -1 }, { -1, -1 } };
            update_home();
            selectedbooking = "";
            selectedregistration = "";
            splitcontainer_info_main.Panel1Collapsed = true;
            button_viewregistrationrecord.Text = "View Registration Record";
            button_viewbookingrecord.Text = "View Booking Record";
            button_check_inout.Text = "Check In/Out";
        }

        private void button_plusoneday_Click(object sender, EventArgs e)
        {
            dateTimePicker_homedate.Value = dateTimePicker_homedate.Value.AddDays(1);
        }

        private void listbox_vaccinations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbox_vaccinations.SelectedIndex > -1)
            {
                if (listbox_showarrivals.SelectedIndex > -1)
                {
                    listbox_showarrivals.SelectedIndex = -1;
                    selectedbooking = "";
                    selectedregistration = "";
                    selectedindex[0, 0] = -1;
                }
                else if (listbox_showdepartures.SelectedIndex > -1)
                {
                    listbox_showdepartures.SelectedIndex = -1;
                    selectedbooking = "";
                    selectedregistration = "";
                    selectedindex[0, 1] = -1;
                }
                else if (listBox_potentialrearrangings.SelectedIndex > -1)
                {
                    listBox_potentialrearrangings.SelectedIndex = -1;
                    selectedbooking = "";
                    selectedregistration = "";
                    selectedindex[1, 1] = -1;
                }

                if (selectedbooking == Vaccinations[listbox_vaccinations.SelectedIndex] || Vaccinations[listbox_vaccinations.SelectedIndex] == null)
                {
                    listbox_vaccinations.SelectedIndex = -1;
                    selectedindex[1, 0] = -1;
                    selectedbooking = "";
                    selectedregistration = "";
                    splitcontainer_info_main.Panel1Collapsed = true;
                    button_viewregistrationrecord.Text = "View Registration Record";
                    button_viewbookingrecord.Text = "View Booking Record";
                    button_check_inout.Text = "Check In/Out";
                }
                else
                {
                    selectedbooking = Vaccinations[listbox_vaccinations.SelectedIndex];
                    selectedindex[1, 0] = listbox_vaccinations.SelectedIndex;
                    update_infotextbox(selectedbooking, false, true);
                    button_viewregistrationrecord.Text = "View Registration Record";
                    button_viewbookingrecord.Text = "View Booking Record";
                    button_check_inout.Text = "Mark Done";

                    bool[] vaccinations = new bool[6];
                    bool done = false;
                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Booking ID`='" + selectedbooking + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            try
                            {
                                vaccinations[i] = (bool)MyGlobalClass.SQL_Alter_Database["Cat " + (i + 1) + " Vaccination"];
                            }
                            catch
                            {
                                done = true;
                            }
                        }
                    }
                    MyGlobalClass.new_connection.Close();

                    if (done == true)
                    {
                        button_check_inout.Enabled = false;
                    }
                    else
                    {
                        button_check_inout.Enabled = true;
                    }

                    splitcontainer_info_main.Panel1Collapsed = false;
                }
            }
        }

        private void listBox_potentialrearrangings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_potentialrearrangings.SelectedIndex > -1)
            {
                if (listbox_showarrivals.SelectedIndex > -1)
                {
                    listbox_showarrivals.SelectedIndex = -1;
                    selectedbooking = "";
                    selectedregistration = "";
                    selectedindex[0, 0] = -1;
                }
                else if (listbox_showdepartures.SelectedIndex > -1)
                {
                    listbox_showdepartures.SelectedIndex = -1;
                    selectedbooking = "";
                    selectedregistration = "";
                    selectedindex[0, 1] = -1;
                }
                else if (listbox_vaccinations.SelectedIndex > -1)
                {
                    listbox_vaccinations.SelectedIndex = -1;
                    selectedbooking = "";
                    selectedregistration = "";
                    selectedindex[1, 0] = -1;
                }

                if (listBox_potentialrearrangings.SelectedIndex < Changes.GetLength(0))
                {
                    if (selectedbooking == Changes[listBox_potentialrearrangings.SelectedIndex, 0] || Changes[listBox_potentialrearrangings.SelectedIndex, 0] == null)
                    {
                        selectedchange = "";
                        listBox_potentialrearrangings.SelectedIndex = -1;
                        selectedindex[1, 1] = -1;
                        selectedbooking = "";
                        selectedregistration = "";
                        splitcontainer_info_main.Panel1Collapsed = true;
                        button_viewregistrationrecord.Text = "View Registration Record";
                        button_viewbookingrecord.Text = "View Booking Record";
                        button_check_inout.Text = "Check In/Out";
                    }
                    else
                    {
                        selectedchange = listBox_potentialrearrangings.SelectedIndex.ToString();
                        selectedbooking = Changes[listBox_potentialrearrangings.SelectedIndex, 0];
                        selectedindex[1, 1] = listBox_potentialrearrangings.SelectedIndex;
                        selectedregistration = "";
                        update_infotextbox(selectedbooking, true, true);
                        button_viewregistrationrecord.Text = "Move";
                        button_viewbookingrecord.Text = "View Potential Change";
                        button_check_inout.Text = "Ignore";
                        button_check_inout.Enabled = true;
                        splitcontainer_info_main.Panel1Collapsed = false;
                    }
                }
                else
                {
                    if (selectedbooking == HeldBookings[listBox_potentialrearrangings.SelectedIndex - Changes.GetLength(0), 0])
                    {
                        selectedchange = "";
                        listBox_potentialrearrangings.SelectedIndex = -1;
                        selectedindex[1, 1] = -1;
                        selectedbooking = "";
                        selectedregistration = "";
                        splitcontainer_info_main.Panel1Collapsed = true;
                        button_viewregistrationrecord.Text = "View Registration Record";
                        button_viewbookingrecord.Text = "View Booking Record";
                        button_check_inout.Text = "Check In/Out";
                    }
                    else
                    {
                        selectedchange = "";
                        selectedbooking = HeldBookings[listBox_potentialrearrangings.SelectedIndex - Changes.GetLength(0), 0];
                        selectedregistration = HeldBookings[listBox_potentialrearrangings.SelectedIndex - Changes.GetLength(0), 1];
                        selectedindex[1, 1] = listBox_potentialrearrangings.SelectedIndex;
                        update_infotextbox(selectedbooking, false, false);
                        button_viewregistrationrecord.Text = "View Registration Record";
                        button_viewbookingrecord.Text = "Edit Booking Record";
                        button_check_inout.Text = "Delete Booking Record";
                        button_check_inout.Enabled = true;
                        splitcontainer_info_main.Panel1Collapsed = false;
                    }
                }
            }
        }

        private void listbox_showarrivals_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbox_showarrivals.SelectedIndex > -1)
            {
                if (listbox_showdepartures.SelectedIndex > -1)
                {
                    listbox_showdepartures.SelectedIndex = -1;
                    selectedbooking = "";
                    selectedregistration = "";
                    selectedindex[0, 1] = -1;
                }
                else if (listbox_vaccinations.SelectedIndex > -1)
                {
                    listbox_vaccinations.SelectedIndex = -1;
                    selectedbooking = "";
                    selectedregistration = "";
                    selectedindex[1, 0] = -1;
                }
                else if (listBox_potentialrearrangings.SelectedIndex > -1)
                {
                    listBox_potentialrearrangings.SelectedIndex = -1;
                    selectedbooking = "";
                    selectedregistration = "";
                    selectedindex[1, 1] = -1;
                }

                if (selectedbooking == Arrivals[listbox_showarrivals.SelectedIndex] || Arrivals[listbox_showarrivals.SelectedIndex] == null)
                {
                    listbox_showarrivals.SelectedIndex = -1;
                    selectedindex[0, 0] = -1;
                    selectedbooking = "";
                    selectedregistration = "";
                    splitcontainer_info_main.Panel1Collapsed = true;
                    button_viewregistrationrecord.Text = "View Registration Record";
                    button_viewbookingrecord.Text = "View Booking Record";
                    button_check_inout.Text = "Check In/Out";
                }
                else
                {
                    selectedbooking = Arrivals[listbox_showarrivals.SelectedIndex];
                    selectedindex[0, 0] = listbox_showarrivals.SelectedIndex;
                    update_infotextbox(selectedbooking, false, true);
                    button_viewregistrationrecord.Text = "View Registration Record";
                    button_viewbookingrecord.Text = "View Booking Record";
                    button_check_inout.Text = "Check In";

                    bool checkedin = false;
                    DateTime arrivaldate = DateTime.Today;
                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Booking ID`='" + selectedbooking + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        checkedin = (bool)MyGlobalClass.SQL_Alter_Database["Checked In"];
                        arrivaldate = DateTime.Parse(MyGlobalClass.SQL_Alter_Database["Arrival Date"].ToString());
                    }
                    MyGlobalClass.new_connection.Close();

                    if (checkedin == true)
                    {
                        button_check_inout.Enabled = false;
                    }
                    else
                    {
                        button_check_inout.Enabled = true;
                        if (DateTime.Today < arrivaldate)
                        {
                            button_check_inout.Enabled = false;
                        }
                    }

                    splitcontainer_info_main.Panel1Collapsed = false;
                }
            }
        }

        private void listbox_showdepartures_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbox_showdepartures.SelectedIndex > -1)
            {
                if (listbox_showarrivals.SelectedIndex > -1)
                {
                    listbox_showarrivals.SelectedIndex = -1;
                    selectedbooking = "";
                    selectedregistration = "";
                    selectedindex[0, 0] = -1;
                }
                else if (listbox_vaccinations.SelectedIndex > -1)
                {
                    listbox_vaccinations.SelectedIndex = -1;
                    selectedbooking = "";
                    selectedregistration = "";
                    selectedindex[1, 0] = -1;
                }
                else if (listBox_potentialrearrangings.SelectedIndex > -1)
                {
                    listBox_potentialrearrangings.SelectedIndex = -1;
                    selectedbooking = "";
                    selectedregistration = "";
                    selectedindex[1, 1] = -1;
                }

                if (selectedbooking == Departures[listbox_showdepartures.SelectedIndex] || Departures[listbox_showdepartures.SelectedIndex] == null)
                {
                    listbox_showdepartures.SelectedIndex = -1;
                    selectedindex[0, 1] = -1;
                    selectedbooking = "";
                    selectedregistration = "";
                    splitcontainer_info_main.Panel1Collapsed = true;
                    button_viewregistrationrecord.Text = "View Registration Record";
                    button_viewbookingrecord.Text = "View Booking Record";
                    button_check_inout.Text = "Check In/Out";
                }
                else
                {
                    selectedbooking = Departures[listbox_showdepartures.SelectedIndex];
                    selectedindex[0, 1] = listbox_showdepartures.SelectedIndex;
                    update_infotextbox(selectedbooking, false, true);
                    button_viewregistrationrecord.Text = "View Registration Record";
                    button_viewbookingrecord.Text = "View Booking Record";
                    button_check_inout.Text = "Check In/Out";

                    bool checkedin = false;
                    bool checkedout = false;
                    DateTime arrivaldate = DateTime.Today;
                    DateTime departuredate = DateTime.Today;
                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Booking ID`='" + selectedbooking + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        checkedin = (bool)MyGlobalClass.SQL_Alter_Database["Checked In"];
                        checkedout = (bool)MyGlobalClass.SQL_Alter_Database["Checked Out"];
                        arrivaldate = DateTime.Parse(MyGlobalClass.SQL_Alter_Database["Arrival Date"].ToString());
                        departuredate = DateTime.Parse(MyGlobalClass.SQL_Alter_Database["Departure Date"].ToString());
                    }
                    MyGlobalClass.new_connection.Close();

                    if (checkedin == false)
                    {
                        button_check_inout.Text = "Check In";
                        button_check_inout.Enabled = true;
                        if (DateTime.Today < arrivaldate)
                        {
                            button_check_inout.Enabled = false;
                        }
                    }
                    else
                    {
                        button_check_inout.Text = "Check Out";
                        if (checkedout == true)
                        {
                            button_check_inout.Enabled = false;
                        }
                        else
                        {
                            button_check_inout.Enabled = true;
                            if (DateTime.Today < departuredate)
                            {
                                button_check_inout.Enabled = false;
                            }
                        }
                    }

                    splitcontainer_info_main.Panel1Collapsed = false;
                }
            }
        }

        private void form_initialscreen_Activated(object sender, EventArgs e)
        {
            update_home();
            MyGlobalClass.maintainselected[1] = false;
        }

        private void text_mulitline_extrainfo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_viewregistrationrecord_Click(object sender, EventArgs e)
        {
            int potentialchangeindex;
            if (int.TryParse(selectedchange, out potentialchangeindex) == true)
            {
                if (MessageBox.Show("Are you sure you wish to move the booking?", "Move?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string arrivaldate = "";
                    string departuredate = "";
                    MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`bookings` SET `Chalet`='" + Changes[potentialchangeindex, 2] + "' WHERE `Booking ID`='" + selectedbooking + "'; SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Booking ID` = '" + selectedbooking + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        arrivaldate = MyGlobalClass.SQL_Alter_Database["Arrival Date"].ToString();
                        departuredate = MyGlobalClass.SQL_Alter_Database["Departure Date"].ToString();
                    }
                    MyGlobalClass.new_connection.Close();

                    for (DateTime date = DateTime.Parse(arrivaldate); date <= DateTime.Parse(departuredate); date = date.AddDays(1))
                    {
                        MyGlobalClass.SQL_Command = new MySqlCommand("DELETE FROM `chichester_cattery_booking_system`.`" + Changes[potentialchangeindex, 1] + "` WHERE `Date`='" + date.ToString("yyyy-MM-dd") + "'; INSERT INTO `chichester_cattery_booking_system`.`" + Changes[potentialchangeindex, 2] + "` (`Date`, `Booking ID`) VALUES ('" + date.ToString("yyyy-MM-dd") + "', '" + selectedbooking + "');", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        MyGlobalClass.new_connection.Close();
                    }

                    int count = 0;
                    MyGlobalClass.SQL_Command = new MySqlCommand("DELETE FROM `chichester_cattery_booking_system`.`potential changes` WHERE `Booking ID`='" + selectedbooking + "' AND `New Chalet` = '" + Changes[potentialchangeindex, 2] + "'; SELECT * FROM chichester_cattery_booking_system.`potential changes`;", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        count++;
                    }
                    MyGlobalClass.new_connection.Close();

                    if (count == 0)
                    {
                        MyGlobalClass.SQL_Command = new MySqlCommand("ALTER TABLE `chichester_cattery_booking_system`.`potential changes` AUTO_INCREMENT = 1;", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        MyGlobalClass.new_connection.Close();
                    }

                    MyGlobalClass.potentialrearranging(DateTime.Parse(arrivaldate), DateTime.Parse(departuredate), Changes[potentialchangeindex, 2]);

                    selectedindex[1, 1] = -1;
                    update_home();
                    selectedbooking = "";
                    selectedregistration = "";
                    splitcontainer_info_main.Panel1Collapsed = true;
                    button_viewregistrationrecord.Text = "View Registration Record";
                    button_viewbookingrecord.Text = "View Booking Record";
                    button_check_inout.Text = "Check In/Out";
                }
            }
            else
            {
                MyGlobalClass.registration_registrationsystem = selectedregistration;
                MyGlobalClass.maintainselected[1] = true;
                var newform = new form_registrationsystem();
                MyGlobalClass.OpenForm(newform);
            }
        }

        private void button_viewbookingrecord_Click(object sender, EventArgs e)
        {
            if (listBox_potentialrearrangings.SelectedIndex > -1)
            {
                if (listBox_potentialrearrangings.SelectedIndex < Changes.GetLength(0))
                {
                    DateTime bookingarrivaldate = DateTime.Today;
                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Booking ID` = '" + selectedbooking + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        bookingarrivaldate = DateTime.Parse(MyGlobalClass.SQL_Alter_Database["Arrival Date"].ToString());
                    }
                    MyGlobalClass.new_connection.Close();

                    var newform = new form_bookingsystem();

                    MyGlobalClass.updatechaletnumber(false, MyGlobalClass.totalchalets, true);
                    MyGlobalClass.shownchaletbookings = new bool[MyGlobalClass.totalchalets];
                    for (int i = 0; i < MyGlobalClass.totalchalets; i++)
                    {
                        if (i == (int.Parse(Changes[listBox_potentialrearrangings.SelectedIndex, 1])) - 1 || i == (int.Parse(Changes[listBox_potentialrearrangings.SelectedIndex, 2])) - 1)
                        {
                            MyGlobalClass.shownchaletbookings[i] = true;
                        }
                        else
                        {
                            MyGlobalClass.shownchaletbookings[i] = false;
                        }
                    }
                    MyGlobalClass.bookingsystemdate = bookingarrivaldate;
                    MyGlobalClass.updatebookingsystemdatetimepickers = true;

                    MyGlobalClass.OpenForm(newform);
                }
                else
                {
                    MyGlobalClass.booking_addnewbooking[0] = selectedbooking;
                    MyGlobalClass.booking_edit = true;
                    MyGlobalClass.updateaddnewbooking = true;
                    var newform = new form_addnewbooking();
                    MyGlobalClass.previous_form_addnewbooking = new form_bookingsystem();
                    MyGlobalClass.CloseForm(newform, this);
                }
            }
            else
            {
                int bookingchalet = 0;
                DateTime bookingarrivaldate = DateTime.Today;
                MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Booking ID` = '" + selectedbooking + "';", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                while (MyGlobalClass.SQL_Alter_Database.Read())
                {
                    bookingarrivaldate = DateTime.Parse(MyGlobalClass.SQL_Alter_Database["Arrival Date"].ToString());
                    bookingchalet = int.Parse(MyGlobalClass.SQL_Alter_Database["Chalet"].ToString());
                }
                MyGlobalClass.new_connection.Close();

                var newform = new form_bookingsystem();

                MyGlobalClass.updatechaletnumber(false, MyGlobalClass.totalchalets, true);
                MyGlobalClass.shownchaletbookings = new bool[MyGlobalClass.totalchalets];
                for (int i = 0; i < MyGlobalClass.totalchalets; i++)
                {
                    if (i == (bookingchalet - 1))
                    {
                        MyGlobalClass.shownchaletbookings[i] = true;
                    }
                    else
                    {
                        MyGlobalClass.shownchaletbookings[i] = false;
                    }
                }
                MyGlobalClass.bookingsystemdate = bookingarrivaldate;
                MyGlobalClass.updatebookingsystemdatetimepickers = true;

                MyGlobalClass.OpenForm(newform);
            }
        }

        private void button_check_inout_Click(object sender, EventArgs e)
        {
            bool checkinout = false;
            if (listbox_vaccinations.SelectedIndex > -1)
            {
                if (MessageBox.Show("Mark Vaccinations as Done?", "Vaccinations Done?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string[] cats = new string[6];
                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Booking ID`='" + selectedbooking + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            cats[i] = MyGlobalClass.SQL_Alter_Database["Cat " + (i + 1) + " Staying"].ToString();
                        }
                    }
                    MyGlobalClass.new_connection.Close();

                    for (int i = 0; i < 6; i++)
                    {
                        if (cats[i] != "NULL")
                        {
                            MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`bookings` SET `Cat " + (i + 1) + " Vaccination`= NULL WHERE `Booking ID`='" + selectedbooking + "';", MyGlobalClass.new_connection);
                            MyGlobalClass.new_connection.Open();
                            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                            MyGlobalClass.new_connection.Close();
                        }
                    }
                }
            }
            else if (listBox_potentialrearrangings.SelectedIndex > -1)
            {
                if (listBox_potentialrearrangings.SelectedIndex < Changes.GetLength(0))
                {
                    int SelectedID = listBox_potentialrearrangings.SelectedIndex;
                    if (MessageBox.Show("Are you sure you do not wish to move the booking?", "Ignore?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int count = 0;
                        MyGlobalClass.SQL_Command = new MySqlCommand("DELETE FROM `chichester_cattery_booking_system`.`potential changes` WHERE `Booking ID`='" + selectedbooking + "' AND `New Chalet` = '" + Changes[SelectedID, 2] + "'; SELECT * FROM chichester_cattery_booking_system.`potential changes`;", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        while (MyGlobalClass.SQL_Alter_Database.Read())
                        {
                            count++;
                        }
                        MyGlobalClass.new_connection.Close();

                        if (count == 0)
                        {
                            MyGlobalClass.SQL_Command = new MySqlCommand("ALTER TABLE `chichester_cattery_booking_system`.`potential changes` AUTO_INCREMENT = 1;", MyGlobalClass.new_connection);
                            MyGlobalClass.new_connection.Open();
                            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                            MyGlobalClass.new_connection.Close();
                        }
                        selectedindex[1, 1] = -1;
                        update_home();
                        listBox_potentialrearrangings.SelectedIndex = -1;
                    }
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to delete this Booking?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        MyGlobalClass.removebookingdata(selectedbooking);
                        selectedindex[1, 1] = -1;
                        update_home();
                        listBox_potentialrearrangings.SelectedIndex = -1;
                    }
                }
            }
            else
            {
                bool checkedin = false;
                DateTime departuredate = DateTime.Today;
                MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Booking ID`='" + selectedbooking + "';", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                while (MyGlobalClass.SQL_Alter_Database.Read())
                {
                    checkedin = (bool)MyGlobalClass.SQL_Alter_Database["Checked In"];
                    departuredate = DateTime.Parse(MyGlobalClass.SQL_Alter_Database["Departure Date"].ToString());
                }
                MyGlobalClass.new_connection.Close();
                if (checkedin == false)
                {
                    MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`bookings` SET `Checked In`='1' WHERE `Booking ID`='" + selectedbooking + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    MyGlobalClass.new_connection.Close();

                    if (DateTime.Today < departuredate)
                    {
                        button_check_inout.Enabled = false;
                    }

                    if (listbox_showdepartures.SelectedIndex > -1)
                    {
                        button_check_inout.Text = "Check Out";
                        checkinout = true;
                    }
                }
                else
                {
                    button_check_inout.Enabled = false;
                    MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`bookings` SET `Checked Out`='1' WHERE `Booking ID`='" + selectedbooking + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    MyGlobalClass.new_connection.Close();
                }
            }

            if (checkinout == false)
            {
                update_home();
                if (listbox_showarrivals.SelectedIndex > -1)
                {
                    listbox_showarrivals.SelectedIndex = -1;
                    selectedbooking = "";
                    selectedregistration = "";
                }
                else if (listbox_showdepartures.SelectedIndex > -1)
                {
                    listbox_showdepartures.SelectedIndex = -1;
                    selectedbooking = "";
                    selectedregistration = "";
                }
                else if (listbox_vaccinations.SelectedIndex > -1)
                {
                    listbox_vaccinations.SelectedIndex = -1;
                    selectedbooking = "";
                    selectedregistration = "";
                }
                else if (listBox_potentialrearrangings.SelectedIndex > -1)
                {
                    listBox_potentialrearrangings.SelectedIndex = -1;
                    selectedbooking = "";
                    selectedregistration = "";
                }
                splitcontainer_info_main.Panel1Collapsed = true;
                button_viewregistrationrecord.Text = "View Registration Record";
                button_viewbookingrecord.Text = "View Booking Record";
                button_check_inout.Text = "Check In/Out";
            }
        }

        private void text_booking_query_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_search_bookings_Click(sender, new EventArgs());
            }
        }

        private void text_registration_query_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_search_registrations_Click(sender, new EventArgs());
            }
        }

        private void text_booking_query_Enter(object sender, EventArgs e)
        {
            button_search_bookings.Font = new Font(Font.FontFamily, button_search_bookings.Font.Size, FontStyle.Bold);
        }

        private void text_booking_query_Leave(object sender, EventArgs e)
        {
            button_search_bookings.Font = new Font(Font.FontFamily, button_search_bookings.Font.Size, FontStyle.Regular);
        }

        private void text_registration_query_Enter(object sender, EventArgs e)
        {
            button_search_registrations.Font = new Font(Font.FontFamily, button_search_registrations.Font.Size, FontStyle.Bold);
        }

        private void text_registration_query_Leave(object sender, EventArgs e)
        {
            button_search_registrations.Font = new Font(Font.FontFamily, button_search_registrations.Font.Size, FontStyle.Regular);
        }
    }
}
