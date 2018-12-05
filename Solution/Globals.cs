using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Data;

namespace Global
{
    public static class MyGlobalClass
    {
        public static Form previous_form_addnewbooking;
        public static Form previous_form_addnewregistration;
        public static bool navigation = false; //Indicates when the closing of a form is normal or not
        public static bool RunSetup = false;
        public static bool update_registration = false;
        public static bool initialform_open = false;

        public static string connectionsettingsfile = "";
        public static string connection_to_database = "";
        public static MySqlConnection new_connection = new MySqlConnection(connection_to_database);
        public static MySqlDataReader SQL_Alter_Database;
        public static MySqlCommand SQL_Command;

        public static string registration_addnewregistration = ""; //Indicates if and what registration is being edited
        public static string registration_registrationsystem = ""; //Indicates if and what registration to select in the registration system
        public static string registration_booking = ""; //Indicates if and what registration is being used for the new booking
        public static string selectedregistrationquery = ""; //Indicates which registration is selected from the registration query results
        public static string[] booking_addnewbooking = new string[4] { "", "", "", "" }; //Indicates what booking is being edited
        public static bool booking_edit = false; //Stores whether a booking is being edited
        public static bool booking_deleted = false; //Indicates whether a booking has been deleted for editing
        public static bool navigationfailure = false; //Stops the old form from closing if it can't show the new form

        public static string[,] selectedregistration = new string[21, 2]; //Stores the information of the selected registration, excluding the cat information
        public static string[,] selectedregistrationcats = new string[9, 12]; //Stores the information of the selected registration's cats
        public static string[,] selectedregistrationbookings = new string[0, 0]; //Stores the bookings made by the selected registration for the registration system
        public static string[,] registrationquery = new string[0, 0]; //Stores the registration query results
        public static string registrationquerystring; //The searched string for a registration search
        public static string[,] bookingquery = new string[0, 0]; //Stores the booking query results
        public static string bookingquerystring; //The searched string for a booking search
        public static string[,] futurebookings = new string[0, 0]; //Stores the future bookings for a registration
        public static string[,] registrationquery_addnewbooking = new string[0, 0]; //Store the registration query results when for adding a booking
        public static string registrationquerystring_addnewbooking; //The searched string for a registration search for a new booking
        public static bool[] maintainselected = new bool[2] { false, false };
        //Index 1 stores whether to re-select a registration when returning to the registration system; Index 2 stops the deselection of a registration if already selected

        public static bool updateaddnewbooking = true; //Stores whether to update the 'Add New Booking' form.
        public static bool updateaddnewregistration = false; //Stores whether to update the 'Add New Registration' form.
        public static bool[] shownchaletbookings = new bool[0]; //Stores which chalets are shown in the booking system form
        public static DateTime bookingsystemdate = DateTime.Today; //Stores the first date at the top of the booking system form to be updated when needed
        public static bool updatebookingsystemdatetimepickers = false; //Stores whether to update the dates at the top of the booking system form
        public static bool offsetconnectionsettings = false;
        //Do I need a variable for the Home form??

        public static int totalchalets;
        public static int bookingmargin = 15;
        public static double ResolutionHeightScale = -1;
        public static double ResolutionWidthScale = -1;

        public static void OpenForm(Form newform)
        {
            if (Application.OpenForms.Count < 3) //Checks that the new form won't take the number of open forms over 3
            {
                bool found = false; //Initialize Boolean Variable for use later on
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    Form openform = Application.OpenForms[i];
                    openform.WindowState = FormWindowState.Maximized;
                    if (openform.Name == newform.Name) //Checks if the requested new form is already open
                    {
                        navigation = true; //Stops the application from closing
                        newform.Close(); //Closes the new instance of the form
                        navigation = false; //Allows the application to close if necessary
                        openform.Activate(); //Shows the already open form on top
                        found = true; //States that the requested form has been found and is shown on top
                    }
                }
                if (found == false) // Checks if the requested form has been found and is shown on top
                {
                    newform.Show(); //If the requested new form is not already open, show the new instance of the form
                }
            }
            else
            {
                for (int i = 0; i < Application.OpenForms.Count; i++) //If the new form will take the number of open forms over 3, initialize for loop
                {
                    Form openform = Application.OpenForms[i];
                    if (openform.Name != "form_addnewbooking" && openform.Name != "form_addnewregistration") //Look in all open forms for a form that is not the 'Add New Booking'
                    { //or 'Add New Registration' form
                        navigation = true;
                        openform.Close(); //Closes the open form
                        navigation = false;
                        OpenForm(newform); //Performs the OpenForm method again to try and open the requested form
                        break;
                    }
                }
            }
        }

        public static void CloseForm(Form newform, Form oldform)
        {
            FormCollection formcollection = Application.OpenForms; //This section of code is similar to the OpenForm method
            bool found = false;
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                Form openform = Application.OpenForms[i];
                openform.WindowState = FormWindowState.Maximized;
                if (openform.Name == newform.Name)
                {
                    navigation = true; //Stops the application from closing
                    newform.Close();
                    navigation = false; //Allows the application to close if necessary
                    openform.Activate();
                    found = true;
                }
            }
            if (found == false)
            {
                try
                {
                    newform.Show();
                }
                catch
                {
                    navigationfailure = true;
                }
            }
            if (navigationfailure == false)
            {
                navigation = true;
                oldform.Close(); //Closes the old form after opening the new form
                navigation = false;
            }
            else
            {
                navigationfailure = false;
            }
        }

        public static void CloseApplication(Form oldform)//Method of closing the application
        {
            if (oldform.Name == "form_addnewbooking" || oldform.Name == "form_addnewregistration")
            {
                oldform.Close(); //Close the oldform with the messageboxshown variable as false; closing all forms in turn
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to exit?", "Exit?", MessageBoxButtons.YesNo) == DialogResult.Yes)//Shows a messagebox and checks if the answer is yes
                {
                    oldform.Close(); //If the answer is yes, close the oldform with the messageboxshown variable as false; closing all forms in turn 
                }
            }
        }

        public static void MinimizeApplication()//Method of minimizing the application
        {
            FormCollection formcollection = Application.OpenForms; // Collect all open forms
            foreach (Form openform in formcollection) //Look at each open form
            {
                openform.WindowState = FormWindowState.Minimized; //Minimize each open form
            }
        }

        public static void CheckFormCount(Button gobackbutton) //Method of checking whether to show and enable the Go Back button.
        { //The button that requires toggling goes in the brakets
            if (Application.OpenForms.Count > 1) //Checks if more than one window is open
            {
                gobackbutton.Enabled = true; //Shows and Enables the go back button if more than one window open
                gobackbutton.Visible = true;
            }
            else
            {
                gobackbutton.Enabled = false;//Hides and Disables the go back button if only one window open
                gobackbutton.Visible = false;
            }
        }

        public static void GoBack(Form oldform) //Method of closing the form when a 'Go Back' Button is clicked
        {
            if (MessageBox.Show("Are you sure you want to go back?", "Go Back?", MessageBoxButtons.YesNo) == DialogResult.Yes) //MessageBox asking for confirmation
            {
                navigation = true; //MessageBox shown so another one does not need to be shown
                oldform.Close(); //If yes, close the oldform
                navigation = false; //Reset the variable when form has been closed
                for (int i = 0; i < Application.OpenForms.Count; i++) //For loop
                {
                    Form openform = Application.OpenForms[i]; //Looks at each open form
                    openform.WindowState = FormWindowState.Maximized; //Maximizes all open forms
                }
            }
        }
        public static string[,] FillQuery(string query, bool search, bool bookingsearch, bool registrationsearch) //Global method of searching for a registration (or a booking)
        {
            int records = 0;
            string[] registrationsstring;
            string[] registrationsid;
            //string[] ownerstrings = new string[0];
            if (search == false)
            {
                #region NoQuery
                SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations`;", new_connection);
                new_connection.Open();
                SQL_Alter_Database = SQL_Command.ExecuteReader();
                records = 0;
                while (SQL_Alter_Database.Read())
                {
                    records++;
                }
                new_connection.Close();
                registrationsstring = new string[records];
                registrationsid = new string[records];
                SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations`;", new_connection);
                new_connection.Open();
                SQL_Alter_Database = SQL_Command.ExecuteReader();
                int n = -1;
                while (SQL_Alter_Database.Read())
                {
                    n++;
                    string listboxitem = "";
                    int i;
                    bool end = false;
                    i = 1;
                    do
                    {
                        if (SQL_Alter_Database["Owner " + i + " ID"].ToString() != "") //If the owner name id is not empty, get the owner name and add to the string
                        {
                            MySqlConnection ownername = new MySqlConnection(connection_to_database);
                            MySqlCommand ownernamequery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact names` WHERE `Contact Name ID` = '" + SQL_Alter_Database["Owner " + i + " ID"].ToString() + "' ;", ownername);
                            ownername.Open();
                            MySqlDataReader readownername = ownernamequery.ExecuteReader();
                            while (readownername.Read())
                            {
                                if (i == 1)
                                {
                                    listboxitem = readownername["Contact Name"].ToString(); //No need to add the owner to the string as nothing in the string
                                }
                                else if (i > 1)
                                {
                                    listboxitem = listboxitem + ", " + readownername["Contact Name"].ToString() + ""; //Commas to separate the owners
                                }
                            }
                            ownername.Close();
                        }
                        else //As there will never be a gap between two owners, as soon as a gap is found, there can be no more owners
                        {
                            if (i > 1)
                            {
                                listboxitem = listboxitem + " "; //Gap before the brackets
                                end = true; //The loop ends
                            }
                        }
                        i++;
                    } while (i <= 6 && end == false);
                    if (end == false) //If there were 6 owners, add a gap
                    {
                        listboxitem = listboxitem + " ";
                    }
                    i = 1;
                    end = false;
                    do
                    {
                        if (SQL_Alter_Database["Cat " + i + " ID"].ToString() != "") //If the cat id is not empty, get the cat
                        {
                            MySqlConnection cat = new MySqlConnection(connection_to_database);
                            MySqlCommand catquery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`cats` WHERE `Cat ID` = '" + SQL_Alter_Database["Cat " + i + " ID"].ToString() + "' ;", cat);
                            cat.Open();
                            MySqlDataReader readcat = catquery.ExecuteReader();
                            while (readcat.Read()) //Assuming all cats have a name (a validation check in the'Add New Registration' form, get the cat name and add it to the string
                            {
                                MySqlConnection catname = new MySqlConnection(connection_to_database);
                                MySqlCommand catnamequery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`cat names` WHERE `Cat Name ID` = '" + readcat["Cat Name ID"].ToString() + "' ;", catname);
                                catname.Open();
                                MySqlDataReader readcatname = catnamequery.ExecuteReader();
                                while (readcatname.Read())
                                {
                                    if (i > 1)
                                    {
                                        listboxitem = listboxitem + ", " + readcatname["Cat Name"].ToString() + ""; //Commas to separate the cats
                                    }
                                    else if (i == 1)
                                    {
                                        listboxitem = listboxitem + "(" + readcatname["Cat Name"].ToString() + ""; //Open brackets for the first cat
                                    }
                                }
                                catname.Close();
                            }
                            cat.Close();
                        }
                        else
                        {
                            if (i > 1)
                            {
                                listboxitem = listboxitem + ")"; //Close brackets for the last cat
                                end = true; //As soon as a gap in the cat ids is found, the loop ends
                            }
                        }
                        i++;
                    } while (i <= 6 && end == false);
                    if (end == false) //Close bracket if there were 6 cats
                    {
                        listboxitem = listboxitem + ")";
                    }
                    registrationsstring[n] = listboxitem;
                    registrationsid[n] = SQL_Alter_Database["Registration ID"].ToString();
                }
                new_connection.Close();
                #endregion
            }

            else //If a search was made
            {
                #region Query
                if (bookingsearch == false && registrationsearch == true)
                {
                    registrationquerystring = query; //Stores the searched text
                }
                else if (bookingsearch == true && registrationsearch == false)
                {
                    bookingquerystring = query;
                }
                else
                {
                    registrationquerystring_addnewbooking = query;
                }
                string[] owner_id = new string[0];
                string[] catname_id;
                string[] cat_id = new string[0];
                int contactname = 0;
                int catname = 0;
                int cat = 0;
                records = 0;
                SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`contact names` WHERE INSTR(`Contact Name`,'" + query + "') > 0;", new_connection);
                new_connection.Open();
                SQL_Alter_Database = SQL_Command.ExecuteReader();
                while (SQL_Alter_Database.Read())
                {
                    contactname++;
                }
                new_connection.Close();

                if (contactname > 0)
                {
                    owner_id = new string[contactname];
                    contactname = 0;
                    SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`contact names` WHERE INSTR(`Contact Name`,'" + query + "') > 0;", new_connection);
                    new_connection.Open();
                    SQL_Alter_Database = SQL_Command.ExecuteReader();
                    while (SQL_Alter_Database.Read())
                    {
                        owner_id[contactname] = SQL_Alter_Database["Contact Name ID"].ToString();
                        contactname++;
                    }
                    new_connection.Close();

                    for (contactname = 0; contactname < owner_id.Length; contactname++)
                    {
                        for (int owner = 1; owner <= 6; owner++)
                        {
                            SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Owner " + owner + " ID` = '" + owner_id[contactname] + "';", new_connection);
                            new_connection.Open();
                            SQL_Alter_Database = SQL_Command.ExecuteReader();
                            while (SQL_Alter_Database.Read())
                            {
                                records++;
                            }
                            new_connection.Close();
                        }
                    }
                }

                SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`cat names` WHERE INSTR(`Cat Name`,'" + query + "') > 0;", new_connection);
                new_connection.Open();
                SQL_Alter_Database = SQL_Command.ExecuteReader();
                while (SQL_Alter_Database.Read())
                {
                    catname++;
                }
                new_connection.Close();

                if (catname > 0)
                {
                    catname_id = new string[catname];
                    catname = 0;
                    SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`cat names` WHERE INSTR(`Cat Name`,'" + query + "') > 0;", new_connection);
                    new_connection.Open();
                    SQL_Alter_Database = SQL_Command.ExecuteReader();
                    while (SQL_Alter_Database.Read())
                    {
                        catname_id[catname] = SQL_Alter_Database["Cat Name ID"].ToString();
                        catname++;
                    }
                    new_connection.Close();

                    for (catname = 0; catname < catname_id.Length; catname++)
                    {
                        SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`cats` WHERE `Cat Name ID` = '" + catname_id[catname] + "';", new_connection);
                        new_connection.Open();
                        SQL_Alter_Database = SQL_Command.ExecuteReader();
                        while (SQL_Alter_Database.Read())
                        {
                            cat++;
                        }
                        new_connection.Close();

                        if (cat > 0)
                        {
                            cat_id = new string[cat];
                            cat = 0;
                            SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`cats` WHERE `Cat Name ID` = '" + catname_id[catname] + "';", new_connection);
                            new_connection.Open();
                            SQL_Alter_Database = SQL_Command.ExecuteReader();
                            while (SQL_Alter_Database.Read())
                            {
                                cat_id[cat] = SQL_Alter_Database["Cat ID"].ToString();
                                cat++;
                            }
                            new_connection.Close();

                            for (cat = 0; cat < cat_id.Length; cat++)
                            {
                                for (int catpointer = 1; catpointer <= 6; catpointer++)
                                {
                                    SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Cat " + catpointer + " ID` = '" + cat_id[cat] + "';", new_connection);
                                    new_connection.Open();
                                    SQL_Alter_Database = SQL_Command.ExecuteReader();
                                    while (SQL_Alter_Database.Read())
                                    {
                                        records++;
                                    }
                                    new_connection.Close();
                                }
                            }
                        }
                    }
                }

                if (records > 0)
                {
                    string[] registrations = new string[records];
                    int n = 0;
                    for (contactname = 0; contactname < owner_id.Length; contactname++)
                    {
                        for (int owner = 1; owner <= 6; owner++)
                        {
                            SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Owner " + owner + " ID` = '" + owner_id[contactname] + "';", new_connection);
                            new_connection.Open();
                            SQL_Alter_Database = SQL_Command.ExecuteReader();
                            while (SQL_Alter_Database.Read())
                            {
                                int arraypointer = 0;
                                bool add = true;
                                while (arraypointer < registrations.Length && add == true)
                                {
                                    if (SQL_Alter_Database["Registration ID"].ToString() == registrations[arraypointer])
                                    {
                                        add = false;
                                    }
                                    arraypointer++;
                                }
                                if (add == true)
                                {
                                    registrations[n] = SQL_Alter_Database["Registration ID"].ToString();
                                    n++;
                                }
                            }
                            new_connection.Close();
                        }
                    }
                    for (cat = 0; cat < cat_id.Length; cat++)
                    {
                        for (int catpointer = 1; catpointer <= 6; catpointer++)
                        {
                            SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Cat " + catpointer + " ID` = '" + cat_id[cat] + "';", new_connection);
                            new_connection.Open();
                            SQL_Alter_Database = SQL_Command.ExecuteReader();
                            while (SQL_Alter_Database.Read())
                            {
                                int arraypointer = 0;
                                bool add = true;
                                while (arraypointer < registrations.Length && add == true)
                                {
                                    if (SQL_Alter_Database["Registration ID"].ToString() == registrations[arraypointer])
                                    {
                                        add = false;
                                    }
                                    arraypointer++;
                                }
                                if (add == true)
                                {
                                    registrations[n] = SQL_Alter_Database["Registration ID"].ToString();
                                    n++;
                                }
                            }
                            new_connection.Close();
                        }
                    }
                    records = 0;
                    for (int i = 0; i < registrations.GetLength(0); i++)
                    {
                        if (registrations[i] != null)
                        {
                            records++;
                        }
                    }
                    registrationsstring = new string[records];
                    registrationsid = new string[records];
                    for (int arraypointer = 0; arraypointer < registrations.Length; arraypointer++)
                    {
                        if (registrations[arraypointer] != null)
                        {
                            registrationsid[arraypointer] = registrations[arraypointer];
                        }
                    }
                    for (int registrationidpointer = 0; registrationidpointer < registrationsid.Length; registrationidpointer++)
                    {
                        SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = '" + registrationsid[registrationidpointer] + "';", new_connection);
                        new_connection.Open();
                        SQL_Alter_Database = SQL_Command.ExecuteReader();
                        while (SQL_Alter_Database.Read())
                        {
                            string listboxitem = "";
                            int i = 1;
                            bool end = false;
                            do
                            {
                                if (SQL_Alter_Database["Owner " + i + " ID"].ToString() != "")
                                {
                                    MySqlConnection ownername = new MySqlConnection(connection_to_database);
                                    MySqlCommand ownernamequery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact names` WHERE `Contact Name ID` = '" + SQL_Alter_Database["Owner " + i + " ID"].ToString() + "' ;", ownername);
                                    ownername.Open();
                                    MySqlDataReader readownername = ownernamequery.ExecuteReader();
                                    while (readownername.Read())
                                    {
                                        if (i == 1)
                                        {
                                            listboxitem = readownername["Contact Name"].ToString();
                                        }
                                        else if (i > 1)
                                        {
                                            listboxitem = listboxitem + ", " + readownername["Contact Name"].ToString() + "";
                                        }
                                    }
                                    ownername.Close();
                                }
                                else
                                {
                                    if (i > 1)
                                    {
                                        listboxitem = listboxitem + " ";
                                        end = true;
                                    }
                                }
                                i++;
                            } while (i <= 6 && end == false);
                            if (end == false)
                            {
                                listboxitem = listboxitem + " ";
                            }
                            string ownerstring = listboxitem;
                            i = 1;
                            end = false;
                            do
                            {
                                if (SQL_Alter_Database["Cat " + i + " ID"].ToString() != "")
                                {
                                    MySqlConnection catconnection = new MySqlConnection(connection_to_database);
                                    MySqlCommand catquery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`cats` WHERE `Cat ID` = '" + SQL_Alter_Database["Cat " + i + " ID"].ToString() + "' ;", catconnection);
                                    catconnection.Open();
                                    MySqlDataReader readcat = catquery.ExecuteReader();
                                    while (readcat.Read())
                                    {
                                        MySqlConnection catnameconnection = new MySqlConnection(connection_to_database);
                                        MySqlCommand catnamequery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`cat names` WHERE `Cat Name ID` = '" + readcat["Cat Name ID"].ToString() + "' ;", catnameconnection);
                                        catnameconnection.Open();
                                        MySqlDataReader readcatname = catnamequery.ExecuteReader();
                                        while (readcatname.Read())
                                        {
                                            if (i > 1)
                                            {
                                                listboxitem = listboxitem + ", " + readcatname["Cat Name"].ToString() + "";
                                            }
                                            else if (i == 1)
                                            {
                                                listboxitem = listboxitem + "(" + readcatname["Cat Name"].ToString() + "";
                                            }
                                        }
                                        catnameconnection.Close();
                                    }
                                    catconnection.Close();
                                }
                                else
                                {
                                    if (i > 1)
                                    {
                                        listboxitem = listboxitem + ")";
                                        end = true;
                                    }
                                }
                                i++;
                            } while (i <= 6 && end == false);
                            if (end == false)
                            {
                                listboxitem = listboxitem + ")";
                            }
                            registrationsstring[registrationidpointer] = listboxitem;
                        }
                        new_connection.Close();
                    }
                }
                else
                { //If a blank search was made or nothing was found
                    registrationsid = new string[1] { "" }; //Add a blank item to the arrays but not null
                    registrationsstring = new string[1] { "" };
                    if (bookingsearch == true)
                    {
                        bookingquery = new string[1, 1] { { "" } };
                        bookingsearch = false;
                    }
                }
                #endregion
            }
            Array.Sort(registrationsstring, registrationsid);
            string[,] registrationssorted = new string[registrationsid.Length, 2];
            for (int i = 0; i < registrationsstring.Length; i++)
            {
                registrationssorted[i, 0] = registrationsstring[i];
                registrationssorted[i, 1] = registrationsid[i];
            }

            if (bookingsearch == true)
            {
                #region bookingsearch
                int bookingresults = 0;
                for (int registrationidpointer = 0; registrationidpointer < registrationsid.Length; registrationidpointer++)
                {
                    SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Registration ID` = '" + registrationsid[registrationidpointer] + "';", new_connection);
                    new_connection.Open();
                    SQL_Alter_Database = SQL_Command.ExecuteReader();
                    while (SQL_Alter_Database.Read())
                    {
                        bookingresults++;
                    }
                    new_connection.Close();
                }
                bookingquery = new string[bookingresults, 4]; //Array is empty if no bookings found for the registrations found
                if (bookingresults == 0) //If no bookings found, add a blank item to the arrays but not null
                {
                    bookingquery = new string[1, 1] { { "" } };
                }
                else
                {
                    bookingresults = 0;
                    for (int registrationidpointer = 0; registrationidpointer < registrationsid.Length; registrationidpointer++)
                    {
                        string ownerstring = "";
                        SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = '" + registrationsid[registrationidpointer] + "';", new_connection);
                        new_connection.Open();
                        SQL_Alter_Database = SQL_Command.ExecuteReader();
                        while (SQL_Alter_Database.Read())
                        {
                            int i = 1;
                            bool end = false;
                            do
                            {
                                if (SQL_Alter_Database["Owner " + i + " ID"].ToString() != "")
                                {
                                    MySqlConnection ownername = new MySqlConnection(connection_to_database);
                                    MySqlCommand ownernamequery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact names` WHERE `Contact Name ID` = '" + SQL_Alter_Database["Owner " + i + " ID"].ToString() + "' ;", ownername);
                                    ownername.Open();
                                    MySqlDataReader readownername = ownernamequery.ExecuteReader();
                                    while (readownername.Read())
                                    {
                                        if (i == 1)
                                        {
                                            ownerstring = readownername["Contact Name"].ToString();
                                        }
                                        else if (i > 1)
                                        {
                                            ownerstring = ownerstring + ", " + readownername["Contact Name"].ToString() + "";
                                        }
                                    }
                                    ownername.Close();
                                }
                                else
                                {
                                    if (i > 1)
                                    {
                                        ownerstring = ownerstring + " ";
                                        end = true;
                                    }
                                }
                                i++;
                            } while (i <= 6 && end == false);
                            if (end == false)
                            {
                                ownerstring = ownerstring + " ";
                            }
                        }
                        new_connection.Close();
                        SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Registration ID` = '" + registrationsid[registrationidpointer] + "';", new_connection);
                        new_connection.Open();
                        SQL_Alter_Database = SQL_Command.ExecuteReader();
                        while (SQL_Alter_Database.Read())
                        {
                            bookingquery[bookingresults, 0] = "" + DateTime.Parse(SQL_Alter_Database["Arrival Date"].ToString()).ToString("dd/MM/yyyy") + " - " + DateTime.Parse(SQL_Alter_Database["Departure Date"].ToString()).ToString("dd/MM/yyyy") + " " + ownerstring + "(";
                            int n = 1;
                            for (int i = 1; i <= 6; i++)
                            {
                                if (SQL_Alter_Database["Cat " + i + " Staying"].ToString() != "NULL")
                                {
                                    if (n == 1)
                                    {
                                        bookingquery[bookingresults, 0] = bookingquery[bookingresults, 0] + SQL_Alter_Database["Cat " + i + " Staying"].ToString();
                                    }
                                    else
                                    {
                                        bookingquery[bookingresults, 0] = bookingquery[bookingresults, 0] + ", " + SQL_Alter_Database["Cat " + i + " Staying"].ToString() + "";
                                    }
                                    n++;
                                }
                            }
                            bookingquery[bookingresults, 0] = bookingquery[bookingresults, 0] + ")";
                            bookingquery[bookingresults, 1] = SQL_Alter_Database["Arrival Date"].ToString();
                            bookingquery[bookingresults, 2] = SQL_Alter_Database["Chalet"].ToString();
                            bookingquery[bookingresults, 3] = SQL_Alter_Database["Booking ID"].ToString();
                            bookingresults++;
                        }
                        new_connection.Close();
                    }
                }
                #endregion
            }

            return registrationssorted;

        }

        public static string retrieveregistrationdata(string registrationid, bool preview)
        {
            string data = "";
            string previewdata = "";
            selectedregistration = new string[21, 2]; //The arrays used for storing cats and registration data are now cleared
            selectedregistrationcats = new string[9, 12];
            SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = '" + registrationid + "';", new_connection);
            new_connection.Open();
            SQL_Alter_Database = SQL_Command.ExecuteReader();
            while (SQL_Alter_Database.Read())
            {
                data = "Owner(s):";
                bool end = false;
                int i = 1;
                do
                {
                    if (SQL_Alter_Database["Owner " + i + " ID"].ToString() != "")
                    {
                        MySqlConnection ownername = new MySqlConnection(connection_to_database);
                        MySqlCommand ownernamequery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact names` WHERE `Contact Name ID` = '" + SQL_Alter_Database["Owner " + i + " ID"].ToString() + "' ;", ownername);
                        ownername.Open();
                        MySqlDataReader readownername = ownernamequery.ExecuteReader();
                        while (readownername.Read())
                        {
                            data = data + "\r\n" + readownername["Contact Name"].ToString() + ""; //Adding information to the string, using "\r\n" to move to a new line
                            selectedregistration[i - 1, 0] = readownername["Contact Name"].ToString(); //Adding the information to an array
                            selectedregistration[i - 1, 1] = SQL_Alter_Database["Owner " + i + " ID"].ToString(); //Adding the ids to an array
                        }
                        ownername.Close();
                    }
                    else
                    {
                        end = true;
                    }
                    i++;
                } while (i <= 6 && end == false);
                i = 1;
                end = false;
                if (SQL_Alter_Database["Address ID"].ToString() != "")
                {
                    MySqlConnection address = new MySqlConnection(connection_to_database);
                    MySqlCommand addressquery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`addresses` WHERE `Address ID` = '" + SQL_Alter_Database["Address ID"].ToString() + "' ;", address);
                    address.Open();
                    MySqlDataReader readaddress = addressquery.ExecuteReader();
                    while (readaddress.Read())
                    {
                        data = data + "\r\nAddress: " + readaddress["Address"].ToString() + "";
                        selectedregistration[6, 0] = readaddress["Address"].ToString();
                        selectedregistration[6, 1] = SQL_Alter_Database["Address ID"].ToString();
                        if (readaddress["Town ID"].ToString() != "")
                        {
                            MySqlConnection town = new MySqlConnection(connection_to_database);
                            MySqlCommand townquery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`towns` WHERE `Town ID` = '" + readaddress["Town ID"].ToString() + "';", town);
                            town.Open();
                            MySqlDataReader readtown = townquery.ExecuteReader();
                            while (readtown.Read())
                            {
                                data = data + "\r\nTown: " + readtown["Town"].ToString() + "";
                                selectedregistration[7, 0] = readtown["Town"].ToString();
                                selectedregistration[7, 1] = readaddress["Town ID"].ToString();
                            }
                            town.Close();
                        }
                        if (readaddress["Postcode ID"].ToString() != "")
                        {
                            MySqlConnection postcode = new MySqlConnection(connection_to_database);
                            MySqlCommand postcodequery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`postcodes` WHERE `Postcode ID` = '" + readaddress["Postcode ID"].ToString() + "';", postcode);
                            postcode.Open();
                            MySqlDataReader readpostcode = postcodequery.ExecuteReader();
                            while (readpostcode.Read())
                            {
                                data = data + "\r\nPostcode: " + readpostcode["Postcode"].ToString() + "";
                                selectedregistration[8, 0] = readpostcode["Postcode"].ToString();
                                selectedregistration[8, 1] = readaddress["Postcode ID"].ToString();
                            }
                            postcode.Close();
                        }
                    }
                    address.Close();
                }
                if (SQL_Alter_Database["Home Telephone ID"].ToString() != "")
                {
                    MySqlConnection hometelephone = new MySqlConnection(connection_to_database);
                    MySqlCommand hometelephonequery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact telephones` WHERE `Contact Telephone ID` = '" + SQL_Alter_Database["Home Telephone ID"].ToString() + "' ;", hometelephone);
                    hometelephone.Open();
                    MySqlDataReader readhometelephone = hometelephonequery.ExecuteReader();
                    while (readhometelephone.Read())
                    {
                        data = data + "\r\nHome Telephone: " + readhometelephone["Contact Telephone"].ToString() + "";
                        selectedregistration[9, 0] = readhometelephone["Contact Telephone"].ToString();
                        selectedregistration[9, 1] = SQL_Alter_Database["Home Telephone ID"].ToString();
                    }
                    hometelephone.Close();
                }
                do
                {
                    if (SQL_Alter_Database["Mobile " + i + " ID"].ToString() != "")
                    {
                        if (i == 1)
                        {
                            data = data + "\r\nMobile(s):";
                        }
                        MySqlConnection mobile = new MySqlConnection(connection_to_database);
                        MySqlCommand mobilequery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact telephones` WHERE `Contact Telephone ID` = '" + SQL_Alter_Database["Mobile " + i + " ID"].ToString() + "' ;", mobile);
                        mobile.Open();
                        MySqlDataReader readmobile = mobilequery.ExecuteReader();
                        while (readmobile.Read())
                        {
                            data = data + "\r\n" + readmobile["Contact Telephone"].ToString() + "";
                            selectedregistration[9 + i, 0] = readmobile["Contact Telephone"].ToString();
                            selectedregistration[9 + i, 1] = SQL_Alter_Database["Mobile " + i + " ID"].ToString();
                        }
                        mobile.Close();
                    }
                    else
                    {
                        data = data + "\r\n";
                        end = true;
                    }
                    i++;
                } while (i <= 6 && end == false);
                i = 1;
                end = false;

                if (preview == true)
                {
                    char[] chararray = data.ToCharArray();
                    Array.Resize<char>(ref chararray, chararray.GetLength(0) - 2);
                    data = new string(chararray);
                    previewdata = data;
                }

                if (SQL_Alter_Database["Absence Contact ID"].ToString() != "")
                {
                    data = data + "\r\nPerson to contact in Absence:";
                    selectedregistration[20, 0] = SQL_Alter_Database["Absence Contact ID"].ToString();
                    MySqlConnection absencecontact = new MySqlConnection(connection_to_database);
                    MySqlCommand absencecontactquery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`absence contacts` WHERE `Absence Contact ID` = '" + SQL_Alter_Database["Absence Contact ID"].ToString() + "' ;", absencecontact);
                    absencecontact.Open();
                    MySqlDataReader readabsencecontact = absencecontactquery.ExecuteReader();
                    while (readabsencecontact.Read())
                    {
                        if (readabsencecontact["Contact Name ID"].ToString() != "")
                        {
                            MySqlConnection contactname = new MySqlConnection(connection_to_database);
                            MySqlCommand contactnamequery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact names` WHERE `Contact Name ID` = '" + readabsencecontact["Contact Name ID"].ToString() + "';", contactname);
                            contactname.Open();
                            MySqlDataReader readcontactname = contactnamequery.ExecuteReader();
                            while (readcontactname.Read())
                            {
                                data = data + "\r\nName: " + readcontactname["Contact Name"].ToString() + "";
                                selectedregistration[16, 0] = readcontactname["Contact Name"].ToString();
                                selectedregistration[16, 1] = readabsencecontact["Contact Name ID"].ToString();
                            }
                            contactname.Close();
                        }
                        if (readabsencecontact["Contact Telephone ID"].ToString() != "")
                        {
                            MySqlConnection contacttelephone = new MySqlConnection(connection_to_database);
                            MySqlCommand contacttelephonequery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact telephones` WHERE `Contact Telephone ID` = '" + readabsencecontact["Contact Telephone ID"].ToString() + "';", contacttelephone);
                            contacttelephone.Open();
                            MySqlDataReader readcontacttelephone = contacttelephonequery.ExecuteReader();
                            while (readcontacttelephone.Read())
                            {
                                data = data + "\r\nPhone: " + readcontacttelephone["Contact Telephone"].ToString() + "\r\n";
                                selectedregistration[17, 0] = readcontacttelephone["Contact Telephone"].ToString();
                                selectedregistration[17, 1] = readabsencecontact["Contact Telephone ID"].ToString();
                            }
                            contacttelephone.Close();
                        }
                    }
                    absencecontact.Close();
                }
                if (SQL_Alter_Database["Vet ID"].ToString() != "")
                {
                    data = data + "\r\nVet:";
                    selectedregistration[20, 1] = SQL_Alter_Database["Vet ID"].ToString();
                    MySqlConnection vet = new MySqlConnection(connection_to_database);
                    MySqlCommand vetquery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`vets` WHERE `Vet ID` = '" + SQL_Alter_Database["Vet ID"].ToString() + "' ;", vet);
                    vet.Open();
                    MySqlDataReader readvet = vetquery.ExecuteReader();
                    while (readvet.Read())
                    {
                        if (readvet["Contact Name ID"].ToString() != "")
                        {
                            MySqlConnection contactname = new MySqlConnection(connection_to_database);
                            MySqlCommand contactnamequery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact names` WHERE `Contact Name ID` = '" + readvet["Contact Name ID"].ToString() + "';", contactname);
                            contactname.Open();
                            MySqlDataReader readcontactname = contactnamequery.ExecuteReader();
                            while (readcontactname.Read())
                            {
                                data = data + "\r\nName: " + readcontactname["Contact Name"].ToString() + "";
                                selectedregistration[18, 0] = readcontactname["Contact Name"].ToString();
                                selectedregistration[18, 1] = readvet["Contact Name ID"].ToString();
                            }
                            contactname.Close();
                        }
                        if (readvet["Contact Telephone ID"].ToString() != "")
                        {
                            MySqlConnection contacttelephone = new MySqlConnection(connection_to_database);
                            MySqlCommand contacttelephonequery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact telephones` WHERE `Contact Telephone ID` = '" + readvet["Contact Telephone ID"].ToString() + "';", contacttelephone);
                            contacttelephone.Open();
                            MySqlDataReader readcontacttelephone = contacttelephonequery.ExecuteReader();
                            while (readcontacttelephone.Read())
                            {
                                data = data + "\r\nPhone: " + readcontacttelephone["Contact Telephone"].ToString() + "\r\n";
                                selectedregistration[19, 0] = readcontacttelephone["Contact Telephone"].ToString();
                                selectedregistration[19, 1] = readvet["Contact Telephone ID"].ToString();
                            }
                            contacttelephone.Close();
                        }
                    }
                    vet.Close();
                }
                do
                {
                    if (SQL_Alter_Database["Cat " + i + " ID"].ToString() != "")
                    {
                        if (i == 1)
                        {
                            data = data + "\r\nCat(s):";
                        }
                        else
                        {
                            data = data + "\r\n";
                        }
                        MySqlConnection cat = new MySqlConnection(connection_to_database);
                        MySqlCommand catquery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`cats` WHERE `Cat ID` = '" + SQL_Alter_Database["Cat " + i + " ID"].ToString() + "' ;", cat);
                        cat.Open();
                        MySqlDataReader readcat = catquery.ExecuteReader();
                        while (readcat.Read())
                        {
                            MySqlConnection catname = new MySqlConnection(connection_to_database);
                            MySqlCommand catnamequery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`cat names` WHERE `Cat Name ID` = '" + readcat["Cat Name ID"].ToString() + "' ;", catname);
                            catname.Open();
                            MySqlDataReader readcatname = catnamequery.ExecuteReader();
                            while (readcatname.Read())
                            {
                                data = data + "\r\nName: " + readcatname["Cat Name"].ToString() + "";
                                selectedregistrationcats[0, (2 * i) - 2] = readcatname["Cat Name"].ToString();
                                selectedregistrationcats[0, (2 * i) - 1] = readcat["Cat Name ID"].ToString();
                                if (readcat["Sex ID"].ToString() != "")
                                {
                                    MySqlConnection catsex = new MySqlConnection(connection_to_database);
                                    MySqlCommand catsexquery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`sexes` WHERE `Sex ID` = '" + readcat["Sex ID"].ToString() + "';", catsex);
                                    catsex.Open();
                                    MySqlDataReader readcatsex = catsexquery.ExecuteReader();
                                    while (readcatsex.Read())
                                    {
                                        data = data + "\r\nSex: " + readcatsex["Sex"].ToString() + "";
                                        selectedregistrationcats[2, (2 * i) - 2] = readcatsex["Sex"].ToString();
                                        selectedregistrationcats[2, (2 * i) - 1] = readcat["Sex ID"].ToString();
                                    }
                                    catsex.Close();
                                }
                            }
                            catname.Close();
                            data = data + "\r\nDate Of Birth: " + DateTime.Parse(readcat["Date Of Birth"].ToString()).ToString("dd/MM/yyyy") + "";
                            selectedregistrationcats[1, (2 * i) - 2] = DateTime.Parse(readcat["Date Of Birth"].ToString()).ToString("dd/MM/yyyy");
                            selectedregistrationcats[1, (2 * i) - 1] = SQL_Alter_Database["Cat " + i + " ID"].ToString();
                            data = data + "\r\nNext Vaccination Date: " + DateTime.Parse(readcat["Next Vaccination Date"].ToString()).ToString("dd/MM/yyyy") + "";
                            selectedregistrationcats[3, (2 * i) - 2] = DateTime.Parse(readcat["Next Vaccination Date"].ToString()).ToString("dd/MM/yyyy");
                            selectedregistrationcats[3, (2 * i) - 1] = SQL_Alter_Database["Cat " + i + " ID"].ToString();
                            if (readcat["Description ID"].ToString() != "")
                            {
                                MySqlConnection catdescription = new MySqlConnection(connection_to_database);
                                MySqlCommand catdescriptionquery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`descriptions` WHERE `Description ID` = '" + readcat["Description ID"].ToString() + "';", catdescription);
                                catdescription.Open();
                                MySqlDataReader readcatdescription = catdescriptionquery.ExecuteReader();
                                while (readcatdescription.Read())
                                {
                                    data = data + "\r\nDescription: " + readcatdescription["Description"].ToString() + "";
                                    selectedregistrationcats[4, (2 * i) - 2] = readcatdescription["Description"].ToString();
                                    selectedregistrationcats[4, (2 * i) - 1] = readcat["Description ID"].ToString();
                                }
                                catdescription.Close();
                            }
                            if (readcat["Food ID"].ToString() != "")
                            {
                                MySqlConnection catfood = new MySqlConnection(connection_to_database);
                                MySqlCommand catfoodquery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`foods` WHERE `Food ID` = '" + readcat["Food ID"].ToString() + "';", catfood);
                                catfood.Open();
                                MySqlDataReader readcatfood = catfoodquery.ExecuteReader();
                                while (readcatfood.Read())
                                {
                                    data = data + "\r\nFood: " + readcatfood["Food"].ToString() + "";
                                    selectedregistrationcats[5, (2 * i) - 2] = readcatfood["Food"].ToString();
                                    selectedregistrationcats[5, (2 * i) - 1] = readcat["Food ID"].ToString();
                                }
                                catfood.Close();
                            }
                            data = data + "\r\nFoods To Be Avoided: " + readcat["Foods To Be Avoided"].ToString() + "";
                            selectedregistrationcats[6, (2 * i) - 2] = readcat["Foods To Be Avoided"].ToString();
                            selectedregistrationcats[6, (2 * i) - 1] = SQL_Alter_Database["Cat " + i + " ID"].ToString();
                            data = data + "\r\nAllergies: " + readcat["Allergies"].ToString() + "";
                            selectedregistrationcats[7, (2 * i) - 2] = readcat["Allergies"].ToString();
                            selectedregistrationcats[7, (2 * i) - 1] = SQL_Alter_Database["Cat " + i + " ID"].ToString();
                            data = data + "\r\nSpecial Treatment: " + readcat["Special Treatment"].ToString() + "";
                            selectedregistrationcats[8, (2 * i) - 2] = readcat["Special Treatment"].ToString();
                            selectedregistrationcats[8, (2 * i) - 1] = SQL_Alter_Database["Cat " + i + " ID"].ToString();

                        }
                        cat.Close();
                    }
                    else
                    {
                        end = true;
                    }
                    i++;
                } while (i <= 6 && end == false);
            }
            new_connection.Close();

            int records = 0;
            SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Registration ID` = '" + registrationid + "';", new_connection);
            new_connection.Open();
            SQL_Alter_Database = SQL_Command.ExecuteReader();
            while (SQL_Alter_Database.Read())
            {
                records++;
            }
            new_connection.Close();

            selectedregistrationbookings = new string[records, 10];
            records = 0;
            SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Registration ID` = '" + registrationid + "' ORDER BY `Booking ID`;", new_connection);
            new_connection.Open();
            SQL_Alter_Database = SQL_Command.ExecuteReader();
            while (SQL_Alter_Database.Read())
            {
                selectedregistrationbookings[records, 0] = SQL_Alter_Database["Booking ID"].ToString();
                selectedregistrationbookings[records, 1] = DateTime.Parse(SQL_Alter_Database["Arrival Date"].ToString()).ToString("dd/MM/yyyy");
                selectedregistrationbookings[records, 2] = DateTime.Parse(SQL_Alter_Database["Departure Date"].ToString()).ToString("dd/MM/yyyy");
                selectedregistrationbookings[records, 3] = SQL_Alter_Database["Cat 1 Staying"].ToString();
                selectedregistrationbookings[records, 4] = SQL_Alter_Database["Cat 2 Staying"].ToString();
                selectedregistrationbookings[records, 5] = SQL_Alter_Database["Cat 3 Staying"].ToString();
                selectedregistrationbookings[records, 6] = SQL_Alter_Database["Cat 4 Staying"].ToString();
                selectedregistrationbookings[records, 7] = SQL_Alter_Database["Cat 5 Staying"].ToString();
                selectedregistrationbookings[records, 8] = SQL_Alter_Database["Cat 6 Staying"].ToString();
                selectedregistrationbookings[records, 9] = SQL_Alter_Database["Chalet"].ToString();
                records++;
            }
            new_connection.Close();
            if (preview == true)
            {
                data = previewdata;
            }
            return data;
        }

        public static void removeredundantregistrationvalues() //Removes unused data from the database
        {
            bool delete = true;
            int records = 0;

            for (int arraypointer = 0; arraypointer < 6; arraypointer++)
            {
                if (selectedregistration[arraypointer, 1] != null)
                {
                    for (int owner = 1; owner <= 6; owner++)
                    {
                        SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`registrations` WHERE `Owner " + owner + " ID` = '" + selectedregistration[arraypointer, 1] + "'", new_connection);
                        new_connection.Open();
                        SQL_Alter_Database = SQL_Command.ExecuteReader();
                        while (SQL_Alter_Database.Read())
                        {
                            records++;
                        }
                        new_connection.Close();
                        if (records > 0) //Checks if the data is used elsewhere. If found, it will not be deleted
                        {
                            delete = false;
                        }
                        records = 0; //Resets the record counter
                    }

                    records = 0;

                    SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`absence contacts` WHERE `Contact Name ID` = '" + selectedregistration[arraypointer, 1] + "'", new_connection);
                    new_connection.Open();
                    SQL_Alter_Database = SQL_Command.ExecuteReader();
                    while (SQL_Alter_Database.Read())
                    {
                        records++;
                    }
                    new_connection.Close();
                    if (records > 0)
                    {
                        delete = false;
                    }

                    records = 0;

                    SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`vets` WHERE `Contact Name ID` = '" + selectedregistration[arraypointer, 1] + "'", new_connection);
                    new_connection.Open();
                    SQL_Alter_Database = SQL_Command.ExecuteReader();
                    while (SQL_Alter_Database.Read())
                    {
                        records++;
                    }
                    new_connection.Close();
                    if (records > 0)
                    {
                        delete = false;
                    }

                    if (delete == true)
                    {
                        SQL_Command = new MySqlCommand("DELETE FROM `chichester_cattery_booking_system`.`contact names` WHERE `Contact Name ID`='" + selectedregistration[arraypointer, 1] + "';", new_connection);
                        new_connection.Open();
                        SQL_Alter_Database = SQL_Command.ExecuteReader();
                        new_connection.Close();
                    }
                    delete = true;
                    records = 0;
                }
            }

            delete = true;
            records = 0;

            SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`registrations` WHERE `Address ID` = '" + selectedregistration[6, 1] + "'", new_connection);
            new_connection.Open();
            SQL_Alter_Database = SQL_Command.ExecuteReader();
            while (SQL_Alter_Database.Read())
            {
                records++;
            }
            new_connection.Close();
            if (records == 0)
            {
                SQL_Command = new MySqlCommand("DELETE FROM `chichester_cattery_booking_system`.`addresses` WHERE `Address ID`='" + selectedregistration[6, 1] + "';", new_connection);
                new_connection.Open();
                SQL_Alter_Database = SQL_Command.ExecuteReader();
                new_connection.Close();
            }

            records = 0;

            SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`addresses` WHERE `Town ID` = '" + selectedregistration[7, 1] + "'", new_connection);
            new_connection.Open();
            SQL_Alter_Database = SQL_Command.ExecuteReader();
            while (SQL_Alter_Database.Read())
            {
                records++;
            }
            new_connection.Close();
            if (records == 0)
            {
                SQL_Command = new MySqlCommand("DELETE FROM `chichester_cattery_booking_system`.`towns` WHERE `Town ID`='" + selectedregistration[7, 1] + "';", new_connection);
                new_connection.Open();
                SQL_Alter_Database = SQL_Command.ExecuteReader();
                new_connection.Close();
            }

            records = 0;

            SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`addresses` WHERE `Postcode ID` = '" + selectedregistration[8, 1] + "'", new_connection);
            new_connection.Open();
            SQL_Alter_Database = SQL_Command.ExecuteReader();
            while (SQL_Alter_Database.Read())
            {
                records++;
            }
            new_connection.Close();
            if (records == 0)
            {
                SQL_Command = new MySqlCommand("DELETE FROM `chichester_cattery_booking_system`.`postcodes` WHERE `Postcode ID`='" + selectedregistration[8, 1] + "';", new_connection);
                new_connection.Open();
                SQL_Alter_Database = SQL_Command.ExecuteReader();
                new_connection.Close();
            }

            records = 0;

            for (int arraypointer = 9; arraypointer <= 15; arraypointer++)
            {
                if (selectedregistration[arraypointer, 1] != null)
                {
                    SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`absence contacts` WHERE `Contact Telephone ID` = '" + selectedregistration[arraypointer, 1] + "'", new_connection);
                    new_connection.Open();
                    SQL_Alter_Database = SQL_Command.ExecuteReader();
                    while (SQL_Alter_Database.Read())
                    {
                        records++;
                    }
                    new_connection.Close();
                    if (records > 0)
                    {
                        delete = false;
                    }

                    records = 0;

                    SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`vets` WHERE `Contact Telephone ID` = '" + selectedregistration[arraypointer, 1] + "'", new_connection);
                    new_connection.Open();
                    SQL_Alter_Database = SQL_Command.ExecuteReader();
                    while (SQL_Alter_Database.Read())
                    {
                        records++;
                    }
                    new_connection.Close();
                    if (records > 0)
                    {
                        delete = false;
                    }

                    records = 0;

                    SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`registrations` WHERE `Home Telephone ID` = '" + selectedregistration[arraypointer, 1] + "'", new_connection);
                    new_connection.Open();
                    SQL_Alter_Database = SQL_Command.ExecuteReader();
                    while (SQL_Alter_Database.Read())
                    {
                        records++;
                    }
                    new_connection.Close();
                    if (records > 0)
                    {
                        delete = false;
                    }

                    records = 0;

                    for (int mobile = 1; mobile <= 6; mobile++)
                    {
                        SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`registrations` WHERE `Mobile " + mobile + " ID` = '" + selectedregistration[arraypointer, 1] + "'", new_connection);
                        new_connection.Open();
                        SQL_Alter_Database = SQL_Command.ExecuteReader();
                        while (SQL_Alter_Database.Read())
                        {
                            records++;
                        }
                        new_connection.Close();
                        if (records > 0)
                        {
                            delete = false;
                        }
                        records = 0;
                    }

                    if (delete == true)
                    {
                        SQL_Command = new MySqlCommand("DELETE FROM `chichester_cattery_booking_system`.`contact telephones` WHERE `Contact Telephone ID`='" + selectedregistration[arraypointer, 1] + "';", new_connection);
                        new_connection.Open();
                        SQL_Alter_Database = SQL_Command.ExecuteReader();
                        new_connection.Close();
                    }
                    delete = true;
                    records = 0;
                }
            }

            delete = true;
            records = 0;

            SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`registrations` WHERE `Absence Contact ID` = '" + selectedregistration[20, 0] + "'", new_connection);
            new_connection.Open();
            SQL_Alter_Database = SQL_Command.ExecuteReader();
            while (SQL_Alter_Database.Read())
            {
                records++;
            }
            new_connection.Close();
            if (records == 0)
            {
                SQL_Command = new MySqlCommand("DELETE FROM `chichester_cattery_booking_system`.`absence contacts` WHERE `Absence Contact ID`='" + selectedregistration[20, 0] + "';", new_connection);
                new_connection.Open();
                SQL_Alter_Database = SQL_Command.ExecuteReader();
                new_connection.Close();
            }

            records = 0;

            for (int owner = 1; owner <= 6; owner++)
            {
                SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`registrations` WHERE `Owner " + owner + " ID` = '" + selectedregistration[16, 1] + "'", new_connection);
                new_connection.Open();
                SQL_Alter_Database = SQL_Command.ExecuteReader();
                while (SQL_Alter_Database.Read())
                {
                    records++;
                }
                new_connection.Close();
                if (records > 0)
                {
                    delete = false;
                }
                records = 0;
            }

            records = 0;

            SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`absence contacts` WHERE `Contact Name ID` = '" + selectedregistration[16, 1] + "'", new_connection);
            new_connection.Open();
            SQL_Alter_Database = SQL_Command.ExecuteReader();
            while (SQL_Alter_Database.Read())
            {
                records++;
            }
            new_connection.Close();
            if (records > 0)
            {
                delete = false;
            }

            records = 0;

            SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`vets` WHERE `Contact Name ID` = '" + selectedregistration[16, 1] + "'", new_connection);
            new_connection.Open();
            SQL_Alter_Database = SQL_Command.ExecuteReader();
            while (SQL_Alter_Database.Read())
            {
                records++;
            }
            new_connection.Close();
            if (records > 0)
            {
                delete = false;
            }

            if (delete == true)
            {
                SQL_Command = new MySqlCommand("DELETE FROM `chichester_cattery_booking_system`.`contact names` WHERE `Contact Name ID`='" + selectedregistration[16, 1] + "';", new_connection);
                new_connection.Open();
                SQL_Alter_Database = SQL_Command.ExecuteReader();
                new_connection.Close();
            }

            delete = true;
            records = 0;

            SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`absence contacts` WHERE `Contact Telephone ID` = '" + selectedregistration[17, 1] + "'", new_connection);
            new_connection.Open();
            SQL_Alter_Database = SQL_Command.ExecuteReader();
            while (SQL_Alter_Database.Read())
            {
                records++;
            }
            new_connection.Close();
            if (records > 0)
            {
                delete = false;
            }

            records = 0;

            SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`vets` WHERE `Contact Telephone ID` = '" + selectedregistration[17, 1] + "'", new_connection);
            new_connection.Open();
            SQL_Alter_Database = SQL_Command.ExecuteReader();
            while (SQL_Alter_Database.Read())
            {
                records++;
            }
            new_connection.Close();
            if (records > 0)
            {
                delete = false;
            }

            records = 0;

            SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`registrations` WHERE `Home Telephone ID` = '" + selectedregistration[17, 1] + "'", new_connection);
            new_connection.Open();
            SQL_Alter_Database = SQL_Command.ExecuteReader();
            while (SQL_Alter_Database.Read())
            {
                records++;
            }
            new_connection.Close();
            if (records > 0)
            {
                delete = false;
            }

            records = 0;

            for (int mobile = 1; mobile <= 6; mobile++)
            {
                SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`registrations` WHERE `Mobile " + mobile + " ID` = '" + selectedregistration[17, 1] + "'", new_connection);
                new_connection.Open();
                SQL_Alter_Database = SQL_Command.ExecuteReader();
                while (SQL_Alter_Database.Read())
                {
                    records++;
                }
                new_connection.Close();
                if (records > 0)
                {
                    delete = false;
                }
                records = 0;
            }

            if (delete == true)
            {
                SQL_Command = new MySqlCommand("DELETE FROM `chichester_cattery_booking_system`.`contact telephones` WHERE `Contact Telephone ID`='" + selectedregistration[17, 1] + "';", new_connection);
                new_connection.Open();
                SQL_Alter_Database = SQL_Command.ExecuteReader();
                new_connection.Close();
            }

            delete = true;
            records = 0;

            SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`registrations` WHERE `Vet ID` = '" + selectedregistration[20, 1] + "'", new_connection);
            new_connection.Open();
            SQL_Alter_Database = SQL_Command.ExecuteReader();
            while (SQL_Alter_Database.Read())
            {
                records++;
            }
            new_connection.Close();
            if (records == 0)
            {
                SQL_Command = new MySqlCommand("DELETE FROM `chichester_cattery_booking_system`.`vets` WHERE `Vet ID`='" + selectedregistration[20, 1] + "';", new_connection);
                new_connection.Open();
                SQL_Alter_Database = SQL_Command.ExecuteReader();
                new_connection.Close();
            }

            records = 0;

            for (int owner = 1; owner <= 6; owner++)
            {
                SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`registrations` WHERE `Owner " + owner + " ID` = '" + selectedregistration[18, 1] + "'", new_connection);
                new_connection.Open();
                SQL_Alter_Database = SQL_Command.ExecuteReader();
                while (SQL_Alter_Database.Read())
                {
                    records++;
                }
                new_connection.Close();
                if (records > 0)
                {
                    delete = false;
                }
                records = 0;
            }

            records = 0;

            SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`absence contacts` WHERE `Contact Name ID` = '" + selectedregistration[18, 1] + "'", new_connection);
            new_connection.Open();
            SQL_Alter_Database = SQL_Command.ExecuteReader();
            while (SQL_Alter_Database.Read())
            {
                records++;
            }
            new_connection.Close();
            if (records > 0)
            {
                delete = false;
            }

            records = 0;

            SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`vets` WHERE `Contact Name ID` = '" + selectedregistration[18, 1] + "'", new_connection);
            new_connection.Open();
            SQL_Alter_Database = SQL_Command.ExecuteReader();
            while (SQL_Alter_Database.Read())
            {
                records++;
            }
            new_connection.Close();
            if (records > 0)
            {
                delete = false;
            }

            if (delete == true)
            {
                SQL_Command = new MySqlCommand("DELETE FROM `chichester_cattery_booking_system`.`contact names` WHERE `Contact Name ID`='" + selectedregistration[18, 1] + "';", new_connection);
                new_connection.Open();
                SQL_Alter_Database = SQL_Command.ExecuteReader();
                new_connection.Close();
            }

            delete = true;
            records = 0;

            SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`absence contacts` WHERE `Contact Telephone ID` = '" + selectedregistration[19, 1] + "'", new_connection);
            new_connection.Open();
            SQL_Alter_Database = SQL_Command.ExecuteReader();
            while (SQL_Alter_Database.Read())
            {
                records++;
            }
            new_connection.Close();
            if (records > 0)
            {
                delete = false;
            }

            records = 0;

            SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`vets` WHERE `Contact Telephone ID` = '" + selectedregistration[19, 1] + "'", new_connection);
            new_connection.Open();
            SQL_Alter_Database = SQL_Command.ExecuteReader();
            while (SQL_Alter_Database.Read())
            {
                records++;
            }
            new_connection.Close();
            if (records > 0)
            {
                delete = false;
            }

            records = 0;

            SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`registrations` WHERE `Home Telephone ID` = '" + selectedregistration[19, 1] + "'", new_connection);
            new_connection.Open();
            SQL_Alter_Database = SQL_Command.ExecuteReader();
            while (SQL_Alter_Database.Read())
            {
                records++;
            }
            new_connection.Close();
            if (records > 0)
            {
                delete = false;
            }

            records = 0;

            for (int mobile = 1; mobile <= 6; mobile++)
            {
                SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`registrations` WHERE `Mobile " + mobile + " ID` = '" + selectedregistration[19, 1] + "'", new_connection);
                new_connection.Open();
                SQL_Alter_Database = SQL_Command.ExecuteReader();
                while (SQL_Alter_Database.Read())
                {
                    records++;
                }
                new_connection.Close();
                if (records > 0)
                {
                    delete = false;
                }
                records = 0;
            }

            if (delete == true)
            {
                SQL_Command = new MySqlCommand("DELETE FROM `chichester_cattery_booking_system`.`contact telephones` WHERE `Contact Telephone ID`='" + selectedregistration[19, 1] + "';", new_connection);
                new_connection.Open();
                SQL_Alter_Database = SQL_Command.ExecuteReader();
                new_connection.Close();
            }

            for (int catpointer = 1; catpointer < 12; catpointer = catpointer + 2)
            {
                delete = true;
                records = 0;
                if (selectedregistrationcats[1, catpointer] != null)
                {
                    for (int i = 1; i <= 6; i++)
                    {
                        SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`registrations` WHERE `Cat " + i + " ID` = '" + selectedregistrationcats[1, catpointer] + "'", new_connection);
                        new_connection.Open();
                        SQL_Alter_Database = SQL_Command.ExecuteReader();
                        while (SQL_Alter_Database.Read())
                        {
                            records++;
                        }
                        new_connection.Close();

                        if (records > 0)
                        {
                            delete = false;
                        }
                        records = 0;
                    }

                    if (delete == true)
                    {
                        SQL_Command = new MySqlCommand("DELETE FROM `chichester_cattery_booking_system`.`cats` WHERE `Cat ID`='" + selectedregistrationcats[1, catpointer] + "';", new_connection);
                        new_connection.Open();
                        SQL_Alter_Database = SQL_Command.ExecuteReader();
                        new_connection.Close();
                    }

                    delete = true;
                    records = 0;

                    SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`cats` WHERE `Cat Name ID` = '" + selectedregistrationcats[0, catpointer] + "'", new_connection);
                    new_connection.Open();
                    SQL_Alter_Database = SQL_Command.ExecuteReader();
                    while (SQL_Alter_Database.Read())
                    {
                        records++;
                    }
                    new_connection.Close();

                    if (records == 0)
                    {
                        SQL_Command = new MySqlCommand("DELETE FROM `chichester_cattery_booking_system`.`cat names` WHERE `Cat Name ID`='" + selectedregistrationcats[0, catpointer] + "';", new_connection);
                        new_connection.Open();
                        SQL_Alter_Database = SQL_Command.ExecuteReader();
                        new_connection.Close();
                    }

                    records = 0;

                    SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`cats` WHERE `Sex ID` = '" + selectedregistrationcats[2, catpointer] + "'", new_connection);
                    new_connection.Open();
                    SQL_Alter_Database = SQL_Command.ExecuteReader();
                    while (SQL_Alter_Database.Read())
                    {
                        records++;
                    }
                    new_connection.Close();

                    if (records == 0)
                    {
                        SQL_Command = new MySqlCommand("DELETE FROM `chichester_cattery_booking_system`.`sexes` WHERE `Sex ID`='" + selectedregistrationcats[2, catpointer] + "';", new_connection);
                        new_connection.Open();
                        SQL_Alter_Database = SQL_Command.ExecuteReader();
                        new_connection.Close();
                    }

                    records = 0;

                    SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`cats` WHERE `Description ID` = '" + selectedregistrationcats[4, catpointer] + "'", new_connection);
                    new_connection.Open();
                    SQL_Alter_Database = SQL_Command.ExecuteReader();
                    while (SQL_Alter_Database.Read())
                    {
                        records++;
                    }
                    new_connection.Close();

                    if (records == 0)
                    {
                        SQL_Command = new MySqlCommand("DELETE FROM `chichester_cattery_booking_system`.`descriptions` WHERE `Description ID`='" + selectedregistrationcats[4, catpointer] + "';", new_connection);
                        new_connection.Open();
                        SQL_Alter_Database = SQL_Command.ExecuteReader();
                        new_connection.Close();
                    }

                    records = 0;

                    SQL_Command = new MySqlCommand("SELECT * FROM chichester_cattery_booking_system.`cats` WHERE `Food ID` = '" + selectedregistrationcats[5, catpointer] + "'", new_connection);
                    new_connection.Open();
                    SQL_Alter_Database = SQL_Command.ExecuteReader();
                    while (SQL_Alter_Database.Read())
                    {
                        records++;
                    }
                    new_connection.Close();

                    if (records == 0)
                    {
                        SQL_Command = new MySqlCommand("DELETE FROM `chichester_cattery_booking_system`.`foods` WHERE `Food ID`='" + selectedregistrationcats[5, catpointer] + "';", new_connection);
                        new_connection.Open();
                        SQL_Alter_Database = SQL_Command.ExecuteReader();
                        new_connection.Close();
                    }

                    records = 0;
                }
            }
            selectedregistration = new string[21, 2];
            selectedregistrationcats = new string[9, 12];
        }

        public static void removebookingdata(string bookingid)
        {
            string chalet = "";
            SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Booking ID` = '" + bookingid + "';", new_connection);
            new_connection.Open();
            SQL_Alter_Database = SQL_Command.ExecuteReader();
            while (SQL_Alter_Database.Read())
            {
                chalet = SQL_Alter_Database["Chalet"].ToString();
            }
            new_connection.Close();

            SQL_Command = new MySqlCommand("DELETE FROM `chichester_cattery_booking_system`.`" + chalet + "` WHERE `Booking ID`='" + bookingid + "';", new_connection);
            new_connection.Open();
            SQL_Alter_Database = SQL_Command.ExecuteReader();
            new_connection.Close();

            SQL_Command = new MySqlCommand("DELETE FROM `chichester_cattery_booking_system`.`bookings` WHERE `Booking ID`='" + bookingid + "';", new_connection);
            new_connection.Open();
            SQL_Alter_Database = SQL_Command.ExecuteReader();
            new_connection.Close();
        }

        public static bool updatechaletnumber(bool change, int newvalue, bool showmessagebox) //The chalet is either checked or updated. A boolean value is returned in case there are no chalets.
        {
            bool Continue = true;
            if (change == false) //If checking
            {
                SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`backup directories`;", new_connection);
                new_connection.Open();
                SQL_Alter_Database = SQL_Command.ExecuteReader();
                while (SQL_Alter_Database.Read())
                {
                    totalchalets = int.Parse(SQL_Alter_Database["Total Chalets"].ToString()); //Total chalets read from database
                }
                new_connection.Close();

                if (totalchalets < 1) //If value not set yet, a message box asks for it to be set
                {
                    if (showmessagebox == true && RunSetup == false)
                    {
                        MessageBox.Show("Please set a value for the number of chalets in the Backup window.", "No value for the number of chalets", MessageBoxButtons.OK);
                    }
                    Continue = false;
                }
                else
                {
                    RunSetup = false;
                }
            }
            else
            { //If changing the value
                if (newvalue > 0)
                {
                    RunSetup = false;
                    if (newvalue > totalchalets)
                    { //If increasing
                        for (int i = 1; i <= (newvalue - totalchalets); i++)
                        { //For each new chalet
                            SQL_Command = new MySqlCommand("CREATE TABLE `chichester_cattery_booking_system`.`" + (totalchalets + i) + "`(`Date` DATE,`Booking ID` INT(11),PRIMARY KEY (`Date`),CONSTRAINT `Booking " + (totalchalets + i) + "` FOREIGN KEY (`Booking ID`)REFERENCES `Chichester_Cattery_Booking_System`.`Bookings` (`Booking ID`),INDEX `Booking " + (totalchalets + i) + "` (`Booking ID` ASC), UNIQUE INDEX `Date UNIQUE " + (totalchalets + i) + "` (`Date` ASC));", new_connection);
                            new_connection.Open(); //Create a table for the chalet
                            SQL_Alter_Database = SQL_Command.ExecuteReader();
                            new_connection.Close();
                            SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`chalets` (`Chalet`, `Maximum Number of Cats`) VALUES ('" + (totalchalets + i) + "', '2');", new_connection);
                            new_connection.Open(); //Add chalet to the chalet table
                            SQL_Alter_Database = SQL_Command.ExecuteReader();
                            new_connection.Close();
                        }
                    }
                    else if (newvalue < totalchalets)
                    { //If decreasing
                        for (int i = 0; i < (totalchalets - newvalue); i++)
                        {
                            SQL_Command = new MySqlCommand("DROP TABLE `chichester_cattery_booking_system`.`" + (totalchalets - i) + "`;", new_connection);
                            new_connection.Open(); //Delete the chalet table
                            SQL_Alter_Database = SQL_Command.ExecuteReader();
                            new_connection.Close();
                            SQL_Command = new MySqlCommand("DELETE FROM `chichester_cattery_booking_system`.`chalets` WHERE `Chalet`='" + (totalchalets - i) + "';", new_connection);
                            new_connection.Open(); //Delete chalet from the chalet table
                            SQL_Alter_Database = SQL_Command.ExecuteReader();
                            new_connection.Close();
                        }
                    }
                    totalchalets = newvalue; //Update total chalets stored on program
                    SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`backup directories` SET `Total Chalets`= '" + newvalue + "' WHERE `ID` = '1';", new_connection);
                    new_connection.Open(); //Update total chalets stored on database
                    SQL_Alter_Database = SQL_Command.ExecuteReader();
                    new_connection.Close();
                }
                else if (showmessagebox == true && RunSetup == false)
                {
                    MessageBox.Show("The value for the number of chalets must be at least one.", "The number of chalets cannot be reduced to zero.", MessageBoxButtons.OK);
                } //If value less than 1, message box shows
            }
            return Continue;
        }

        public static int countdayssincedeparture(DateTime arrivaldate, string chalet)
        {
            int count = 0;
            bool found = false;
            while (found == false && count <= bookingmargin)
            {
                count++;
                DateTime date = arrivaldate.AddDays(-(count));
                SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`" + chalet + "` WHERE `Date` = '" + date.ToString("yyyy-MM-dd") + "';", new_connection);
                new_connection.Open();
                SQL_Alter_Database = SQL_Command.ExecuteReader();
                while (SQL_Alter_Database.Read())
                {
                    found = true;
                }
                new_connection.Close();
            }
            if (found == false)
            {
                count = 0;
            }
            return count;
        }

        public static int countdaystoarrival(DateTime departuredate, string chalet)
        {
            int count = 0;
            bool found = false;
            while (found == false && count <= bookingmargin)
            {
                count++;
                DateTime date = departuredate.AddDays(count);
                SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`" + chalet + "` WHERE `Date` = '" + date.ToString("yyyy-MM-dd") + "';", new_connection);
                new_connection.Open();
                SQL_Alter_Database = SQL_Command.ExecuteReader();
                while (SQL_Alter_Database.Read())
                {
                    found = true;
                }
                new_connection.Close();
            }
            if (found == false)
            {
                count = 0;
            }
            return count;
        }

        public static void potentialrearranging(DateTime arrivaldate, DateTime departuredate, string chalet)
        {
            int bookings = 0;
            string[,] pastbookings = new string[0, 0];
            string[,] futurebookings = new string[0, 0];
            string[,] rearrangingarray = new string[0, 0];

            #region bookingsinrange
            while (true) //Past Bookings
            {
                bookings = 0;
                pastbookings = new string[0, 0];
                rearrangingarray = new string[0, 0];
                for (DateTime date = arrivaldate.AddDays(-1); date > arrivaldate.AddDays(-(bookingmargin)); date = date.AddDays(-1))
                {
                    SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Departure Date` = '" + date.ToString("yyyy-MM-dd") + "';", new_connection);
                    new_connection.Open();
                    SQL_Alter_Database = SQL_Command.ExecuteReader();
                    while (SQL_Alter_Database.Read())
                    {
                        bookings++;
                    }
                    new_connection.Close();
                }
                if (bookings > 0)
                {
                    pastbookings = new string[bookings, 6];
                    bookings = 0;
                }
                else
                {
                    break;
                }
                for (DateTime date = arrivaldate.AddDays(-1); date > arrivaldate.AddDays(-(bookingmargin)); date = date.AddDays(-1))
                {
                    SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Departure Date` = '" + date.ToString("yyyy-MM-dd") + "';", new_connection);
                    new_connection.Open();
                    SQL_Alter_Database = SQL_Command.ExecuteReader();
                    while (SQL_Alter_Database.Read())
                    {
                        pastbookings[bookings, 0] = SQL_Alter_Database["Booking ID"].ToString();
                        pastbookings[bookings, 1] = SQL_Alter_Database["Arrival Date"].ToString();
                        pastbookings[bookings, 2] = SQL_Alter_Database["Departure Date"].ToString();
                        pastbookings[bookings, 3] = SQL_Alter_Database["Chalet"].ToString();
                        bookings++;
                    }
                    new_connection.Close();
                }
                break;
            }
            while (true) //Future Bookings
            {
                bookings = 0;
                futurebookings = new string[0, 0];
                rearrangingarray = new string[0, 0];
                for (DateTime date = departuredate.AddDays(1); date < departuredate.AddDays(bookingmargin); date = date.AddDays(1))
                {
                    SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Arrival Date` = '" + date.ToString("yyyy-MM-dd") + "';", new_connection);
                    new_connection.Open();
                    SQL_Alter_Database = SQL_Command.ExecuteReader();
                    while (SQL_Alter_Database.Read())
                    {
                        bookings++;
                    }
                    new_connection.Close();
                }
                if (bookings > 0)
                {
                    futurebookings = new string[bookings, 6];
                    bookings = 0;
                }
                else
                {
                    break;
                }
                for (DateTime date = departuredate.AddDays(1); date < departuredate.AddDays(bookingmargin); date = date.AddDays(1))
                {
                    SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Arrival Date` = '" + date.ToString("yyyy-MM-dd") + "';", new_connection);
                    new_connection.Open();
                    SQL_Alter_Database = SQL_Command.ExecuteReader();
                    while (SQL_Alter_Database.Read())
                    {
                        futurebookings[bookings, 0] = SQL_Alter_Database["Booking ID"].ToString();
                        futurebookings[bookings, 1] = SQL_Alter_Database["Arrival Date"].ToString();
                        futurebookings[bookings, 2] = SQL_Alter_Database["Departure Date"].ToString();
                        futurebookings[bookings, 3] = SQL_Alter_Database["Chalet"].ToString();
                        bookings++;
                    }
                    new_connection.Close();
                }
                break;
            }
            #endregion
            #region bookingsthatfit
            if (pastbookings.GetLength(0) > 0)
            {
                bookings = 0;
                rearrangingarray = new string[pastbookings.GetLength(0), 6];
                for (int pastbookingid = 0; pastbookingid < pastbookings.GetLength(0); pastbookingid++)
                {
                    bool fit = true;
                    for (DateTime date = DateTime.Parse(pastbookings[pastbookingid, 1]); date <= DateTime.Parse(pastbookings[pastbookingid, 2]); date = date.AddDays(1))
                    {
                        SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`" + chalet + "` WHERE `Date` = '" + date.ToString("yyyy-MM-dd") + "';", new_connection);
                        new_connection.Open();
                        SQL_Alter_Database = SQL_Command.ExecuteReader();
                        while (SQL_Alter_Database.Read())
                        {
                            fit = false;
                        }
                        new_connection.Close();
                        if (fit == false)
                        {
                            break;
                        }
                    }
                    if (fit == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            rearrangingarray[bookings, i] = pastbookings[pastbookingid, i];
                        }
                        bookings++;
                    }
                }
                pastbookings = new string[bookings, 6];
                for (int a = 0; a < pastbookings.GetLength(0); a++)
                {
                    for (int b = 0; b < 6; b++)
                    {
                        pastbookings[a, b] = rearrangingarray[a, b];
                    }
                }
            }
            if (futurebookings.GetLength(0) > 0)
            {
                bookings = 0;
                rearrangingarray = new string[futurebookings.GetLength(0), 6];
                for (int futurebookingid = 0; futurebookingid < futurebookings.GetLength(0); futurebookingid++)
                {
                    bool fit = true;
                    for (DateTime date = DateTime.Parse(futurebookings[futurebookingid, 1]); date <= DateTime.Parse(futurebookings[futurebookingid, 2]); date = date.AddDays(1))
                    {
                        SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`" + chalet + "` WHERE `Date` = '" + date.ToString("yyyy-MM-dd") + "';", new_connection);
                        new_connection.Open();
                        SQL_Alter_Database = SQL_Command.ExecuteReader();
                        while (SQL_Alter_Database.Read())
                        {
                            fit = false;
                        }
                        new_connection.Close();
                        if (fit == false)
                        {
                            break;
                        }
                    }
                    if (fit == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            rearrangingarray[bookings, i] = futurebookings[futurebookingid, i];
                        }
                        bookings++;
                    }
                }
                futurebookings = new string[bookings, 6];
                for (int a = 0; a < futurebookings.GetLength(0); a++)
                {
                    for (int b = 0; b < 6; b++)
                    {
                        futurebookings[a, b] = rearrangingarray[a, b];
                    }
                }
            }
            #endregion
            #region bookingsthattightenthebookingsystem
            if (pastbookings.GetLength(0) > 0)
            {
                bookings = 0;
                rearrangingarray = new string[pastbookings.GetLength(0), 7];
                for (int pastbookingid = 0; pastbookingid < pastbookings.GetLength(0); pastbookingid++)
                {
                    int currentdayssincedeparture = countdayssincedeparture(DateTime.Parse(pastbookings[pastbookingid, 1]), pastbookings[pastbookingid, 3]);
                    int currentdaystillarrival = countdaystoarrival(DateTime.Parse(pastbookings[pastbookingid, 2]), pastbookings[pastbookingid, 3]);
                    int currentsum = currentdayssincedeparture + currentdaystillarrival;
                    if (currentsum == 2 && currentdayssincedeparture == 1)
                    {
                        continue;
                    }
                    int potentialdayssincedeparture = countdayssincedeparture(DateTime.Parse(pastbookings[pastbookingid, 1]), chalet);
                    int potentialdaystillarrival = countdaystoarrival(DateTime.Parse(pastbookings[pastbookingid, 2]), chalet);
                    int potentialsum = potentialdayssincedeparture + potentialdaystillarrival;
                    if (currentsum == 1 && potentialsum != 2 && potentialdayssincedeparture != 1)
                    {
                        continue;
                    }
                    if (currentsum == 0 || currentsum == 1)
                    {
                        if (currentsum == 0)
                        {
                            currentsum = 1;
                        }
                        else
                        {
                            currentsum = 0;
                        }
                    }
                    if (potentialsum == 2 && potentialdayssincedeparture == 1)
                    {
                        potentialsum = -1;
                    }
                    if (potentialsum == 0 || potentialsum == 1)
                    {
                        if (potentialsum == 0)
                        {
                            potentialsum = 1;
                        }
                        else
                        {
                            potentialsum = 0;
                        }
                    }
                    if (currentsum <= potentialsum)
                    {
                        continue;
                    }

                    bool Continue = false;
                    SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`potential changes`;", new_connection);
                    new_connection.Open();
                    SQL_Alter_Database = SQL_Command.ExecuteReader();
                    while (SQL_Alter_Database.Read())
                    {
                        if (SQL_Alter_Database["Booking ID"].ToString() == pastbookings[pastbookingid, 0])
                        {
                            if ((currentsum - potentialsum) < int.Parse((SQL_Alter_Database["Change Improvement"].ToString())))
                            {
                                Continue = true;
                            }
                            else if (currentsum <= int.Parse((SQL_Alter_Database["Current Sum"].ToString())))
                            {
                                Continue = true;
                            }
                        }
                    }
                    new_connection.Close();
                    if (Continue == true)
                    {
                        continue;
                    }

                    for (int Move = 0; Move < 6; Move++)
                    {
                        rearrangingarray[bookings, Move] = pastbookings[pastbookingid, Move];
                    }

                    rearrangingarray[bookings, 4] = currentsum.ToString();
                    rearrangingarray[bookings, 5] = potentialsum.ToString();
                    rearrangingarray[bookings, 6] = (currentsum - potentialsum).ToString();

                    bookings++;
                }
                pastbookings = new string[bookings, 7];
                for (int Booking = 0; Booking < bookings; Booking++)
                {
                    for (int Move = 0; Move < 7; Move++)
                    {
                        pastbookings[Booking, Move] = rearrangingarray[Booking, Move];
                    }
                }
            }
            if (futurebookings.GetLength(0) > 0)
            {
                bookings = 0;
                rearrangingarray = new string[futurebookings.GetLength(0), 7];
                for (int futurebookingid = 0; futurebookingid < futurebookings.GetLength(0); futurebookingid++)
                {
                    int currentdayssincedeparture = countdayssincedeparture(DateTime.Parse(futurebookings[futurebookingid, 1]), futurebookings[futurebookingid, 3]);
                    int currentdaystillarrival = countdaystoarrival(DateTime.Parse(futurebookings[futurebookingid, 2]), futurebookings[futurebookingid, 3]);
                    int currentsum = currentdayssincedeparture + currentdaystillarrival;
                    if (currentsum == 2 && currentdayssincedeparture == 1)
                    {
                        continue;
                    }
                    int potentialdayssincedeparture = countdayssincedeparture(DateTime.Parse(futurebookings[futurebookingid, 1]), chalet);
                    int potentialdaystillarrival = countdaystoarrival(DateTime.Parse(futurebookings[futurebookingid, 2]), chalet);
                    int potentialsum = potentialdayssincedeparture + potentialdaystillarrival;
                    if (currentsum == 1 && potentialsum != 2 && potentialdayssincedeparture != 1)
                    {
                        continue;
                    }
                    if (currentsum == 0 || currentsum == 1)
                    {
                        if (currentsum == 0)
                        {
                            currentsum = 1;
                        }
                        else
                        {
                            currentsum = 0;
                        }
                    }
                    if (potentialsum == 2 && potentialdayssincedeparture == 1)
                    {
                        potentialsum = -1;
                    }
                    if (potentialsum == 0 || potentialsum == 1)
                    {
                        if (potentialsum == 0)
                        {
                            potentialsum = 1;
                        }
                        else
                        {
                            potentialsum = 0;
                        }
                    }
                    if (currentsum <= potentialsum)
                    {
                        continue;
                    }

                    bool Continue = false;
                    SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`potential changes`;", new_connection);
                    new_connection.Open();
                    SQL_Alter_Database = SQL_Command.ExecuteReader();
                    while (SQL_Alter_Database.Read())
                    {
                        if (SQL_Alter_Database["Booking ID"].ToString() == futurebookings[futurebookingid, 0])
                        {
                            if ((currentsum - potentialsum) < int.Parse((SQL_Alter_Database["Change Improvement"].ToString())))
                            {
                                Continue = true;
                            }
                            else if (currentsum <= int.Parse((SQL_Alter_Database["Current Sum"].ToString())))
                            {
                                Continue = true;
                            }
                        }
                    }
                    new_connection.Close();
                    if (Continue == true)
                    {
                        continue;
                    }

                    for (int Move = 0; Move < 6; Move++)
                    {
                        rearrangingarray[bookings, Move] = futurebookings[futurebookingid, Move];
                    }

                    rearrangingarray[bookings, 4] = currentsum.ToString();
                    rearrangingarray[bookings, 5] = potentialsum.ToString();
                    rearrangingarray[bookings, 6] = (currentsum - potentialsum).ToString();

                    bookings++;
                }
                futurebookings = new string[bookings, 7];
                for (int Booking = 0; Booking < bookings; Booking++)
                {
                    for (int Move = 0; Move < 7; Move++)
                    {
                        futurebookings[Booking, Move] = rearrangingarray[Booking, Move];
                    }
                }
            }
            #endregion
            #region thebestbookings
            int pair = -1;
            if (pastbookings.GetLength(0) > 0)
            {
                string[] BestBooking = new string[2] { pastbookings[0, 6], "0" };
                for (int PastBookingId = 1; PastBookingId < pastbookings.GetLength(0); PastBookingId++)
                {
                    if (int.Parse(pastbookings[PastBookingId, 6]) > int.Parse(BestBooking[0]))
                    {
                        BestBooking[0] = pastbookings[PastBookingId, 6];
                        BestBooking[1] = PastBookingId.ToString();
                    }
                    else if (int.Parse(pastbookings[PastBookingId, 6]) == int.Parse(BestBooking[0]))
                    {
                        if (int.Parse(pastbookings[PastBookingId, 4]) > int.Parse(pastbookings[int.Parse(BestBooking[1]), 4]))
                        {
                            BestBooking[0] = pastbookings[PastBookingId, 6];
                            BestBooking[1] = PastBookingId.ToString();
                        }
                    }
                }

                pair = 1;
                while (true)
                {
                    bool PairFound = true;
                    SQL_Command = new MySqlCommand("SELECT * FROM `Chichester_Cattery_Booking_System`.`Potential Changes` WHERE `Pair` = '" + pair + "'", new_connection);
                    new_connection.Open();
                    SQL_Alter_Database = SQL_Command.ExecuteReader();
                    while (SQL_Alter_Database.Read())
                    {
                        pair++;
                        PairFound = false;
                    }
                    new_connection.Close();

                    if (PairFound == true)
                    {
                        break;
                    }
                }
                int ID = 1;
                while (true)
                {
                    bool IDFound = true;
                    SQL_Command = new MySqlCommand("SELECT * FROM `Chichester_Cattery_Booking_System`.`Potential Changes` WHERE `ID` = '" + ID + "'", new_connection);
                    new_connection.Open();
                    SQL_Alter_Database = SQL_Command.ExecuteReader();
                    while (SQL_Alter_Database.Read())
                    {
                        ID++;
                        IDFound = false;
                    }
                    new_connection.Close();

                    if (IDFound == true)
                    {
                        break;
                    }
                }
                SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`potential changes` (`ID`, `Booking ID`, `New Chalet`, `Arrival Date`, `Departure Date`, `Pair`, `Current Sum`, `Change Improvement`) VALUES ('" + ID + "', '" + pastbookings[int.Parse(BestBooking[1]), 0] + "', '" + chalet + "', '" + arrivaldate.ToString("yyyy-MM-dd") + "', '" + departuredate.ToString("yyyy-MM-dd") + "', '" + pair + "', '" + pastbookings[int.Parse(BestBooking[1]), 4] + "', '" + pastbookings[int.Parse(BestBooking[1]), 6] + "');", new_connection);
                new_connection.Open();
                SQL_Alter_Database = SQL_Command.ExecuteReader();
                new_connection.Close();
            }
            if (futurebookings.GetLength(0) > 0)
            {
                string[] BestBooking = new string[2] { futurebookings[0, 6], "0" };
                for (int FutureBookingId = 1; FutureBookingId < futurebookings.GetLength(0); FutureBookingId++)
                {
                    if (int.Parse(futurebookings[FutureBookingId, 6]) > int.Parse(BestBooking[0]))
                    {
                        BestBooking[0] = futurebookings[FutureBookingId, 6];
                        BestBooking[1] = FutureBookingId.ToString();
                    }
                    else if (int.Parse(futurebookings[FutureBookingId, 6]) == int.Parse(BestBooking[0]))
                    {
                        if (int.Parse(futurebookings[FutureBookingId, 4]) > int.Parse(futurebookings[int.Parse(BestBooking[1]), 4]))
                        {
                            BestBooking[0] = futurebookings[FutureBookingId, 6];
                            BestBooking[1] = FutureBookingId.ToString();
                        }
                    }
                }

                if (pair == -1)
                {
                    pair = 1;
                    while (true)
                    {
                        bool PairFound = true;
                        SQL_Command = new MySqlCommand("SELECT * FROM `Chichester_Cattery_Booking_System`.`Potential Changes` WHERE `Pair` = '" + pair + "'", new_connection);
                        new_connection.Open();
                        SQL_Alter_Database = SQL_Command.ExecuteReader();
                        while (SQL_Alter_Database.Read())
                        {
                            pair++;
                            PairFound = false;
                        }
                        new_connection.Close();

                        if (PairFound == true)
                        {
                            break;
                        }
                    }
                }
                int ID = 1;
                while (true)
                {
                    bool IDFound = true;
                    SQL_Command = new MySqlCommand("SELECT * FROM `Chichester_Cattery_Booking_System`.`Potential Changes` WHERE `ID` = '" + ID + "'", new_connection);
                    new_connection.Open();
                    SQL_Alter_Database = SQL_Command.ExecuteReader();
                    while (SQL_Alter_Database.Read())
                    {
                        ID++;
                        IDFound = false;
                    }
                    new_connection.Close();

                    if (IDFound == true)
                    {
                        break;
                    }
                }
                SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`potential changes` (`ID`, `Booking ID`, `New Chalet`, `Arrival Date`, `Departure Date`, `Pair`, `Current Sum`, `Change Improvement`) VALUES ('" + ID + "', '" + futurebookings[int.Parse(BestBooking[1]), 0] + "', '" + chalet + "', '" + arrivaldate.ToString("yyyy-MM-dd") + "', '" + departuredate.ToString("yyyy-MM-dd") + "', '" + pair + "', '" + futurebookings[int.Parse(BestBooking[1]), 4] + "', '" + futurebookings[int.Parse(BestBooking[1]), 6] + "');", new_connection);
                new_connection.Open();
                SQL_Alter_Database = SQL_Command.ExecuteReader();
                new_connection.Close();
            }
            #endregion
        }

        public static void updatelistboxwidth(ListBox listbox, int tabs, int minimumwidth)
        {//Method for re-sizing the width of a list box. Taking into account whether tabs were used to separate information and the width of the control the list box is in
            double Multiplier = 0.6875 * listbox.Font.Size;
            int CharacterMulti = (int)Multiplier + 1; //The width of a character
            Multiplier = 0.5 * listbox.Font.Size;
            int TabMulti = (int)Multiplier; //The width of a tab

            int MaxWidth = minimumwidth;
            for (int i = 0; i < listbox.Items.Count; i++)
            {//Takes each list box item, finding the width that would fit that string
                char[] itemchar = listbox.Items[i].ToString().ToCharArray();
                int Width = CharacterMulti * (itemchar.GetLength(0) + (TabMulti * tabs));
                if (Width > minimumwidth)
                {
                    MaxWidth = Width;
                }
            }
            listbox.Width = MaxWidth; //Once the maximum width for all list box items is found, the width is updated
        }

        public static void ScaleParent(double HeightScale, double WidthScale, Control Parent)
        {
            Parent.SuspendLayout();

            foreach (Control Ctrl in Parent.Controls)
            {
                string Name = Ctrl.Name;
                double newheight = Ctrl.Height * HeightScale;
                double newY = Ctrl.Top * HeightScale;
                double newwidth = Ctrl.Width * WidthScale;
                double newX = Ctrl.Left * WidthScale;


                Ctrl.Size = new System.Drawing.Size((int)newwidth, (int)newheight);
                Ctrl.Location = new System.Drawing.Point((int)newX, (int)newY);
                try
                {
                    double NewFontSize = 16;
                    if (HeightScale < WidthScale)
                    {
                        NewFontSize = Ctrl.Font.Size * HeightScale;
                    }
                    else
                    {
                        NewFontSize = Ctrl.Font.Size * WidthScale;
                    }
                    if (!(Ctrl is NumericUpDown))
                    {
                        Ctrl.Font = new Font(Ctrl.Font.FontFamily.Name, (int)NewFontSize);
                    }
                }
                catch
                {
                }
                if (Ctrl.Controls.Count > 0)
                {
                    ScaleParent(HeightScale, WidthScale, Ctrl);
                }
            }

            Parent.ResumeLayout();
            Parent.PerformLayout();
        }

        public static void CheckHeldBookings()
        {
            int count = 0;
            string[,] Temporary = new string[0, 0];
            string[,] LimboBookings = new string[0, 0];
            string[,] HeldBookings = new string[0, 0];
            SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings`;", new_connection);
            new_connection.Open();
            SQL_Alter_Database = SQL_Command.ExecuteReader();
            while (SQL_Alter_Database.Read())
            {
                count++;
            }
            new_connection.Close();

            Temporary = new string[count, 3];
            count = 0;

            SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings`;", new_connection);
            new_connection.Open();
            SQL_Alter_Database = SQL_Command.ExecuteReader();
            while (SQL_Alter_Database.Read())
            {
                Temporary[count, 0] = SQL_Alter_Database["Booking ID"].ToString();
                Temporary[count, 1] = SQL_Alter_Database["Chalet"].ToString();
                Temporary[count, 2] = DateTime.Parse(SQL_Alter_Database["Arrival Date"].ToString()).ToString("yyyy-MM-dd");
                count++;
            }
            new_connection.Close();

            HeldBookings = new string[Temporary.GetLength(0), 3];
            count = 0;
            for (int Booking = 0; Booking < Temporary.GetLength(0); Booking++)
            {
                if (Temporary[Booking, 1] == "")
                {
                    for (int i = 0; i < 3; i++)
                    {
                        HeldBookings[count, i] = Temporary[Booking, i];
                    }
                    count++;
                }
                else
                {
                    bool held = true;
                    SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`" + Temporary[Booking, 1] + "` WHERE `Date` = '" + Temporary[Booking, 2] + "';", new_connection);
                    new_connection.Open();
                    SQL_Alter_Database = SQL_Command.ExecuteReader();
                    while (SQL_Alter_Database.Read())
                    {
                        held = false;
                    }
                    new_connection.Close();
                    if (held == true)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            HeldBookings[count, i] = Temporary[Booking, i];
                        }
                        count++;
                    }
                }
            }

            LimboBookings = new string[count, 3];
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    LimboBookings[i, j] = HeldBookings[i, j];
                }
            }
            count = 0;

            SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`potential changes`;", new_connection);
            new_connection.Open();
            SQL_Alter_Database = SQL_Command.ExecuteReader();
            while (SQL_Alter_Database.Read())
            {
                if (SQL_Alter_Database["New Chalet"].ToString() == "-1")
                {
                    count++;
                }
            }
            new_connection.Close();

            HeldBookings = new string[count, 2];
            count = 0;

            SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`potential changes`;", new_connection);
            new_connection.Open();
            SQL_Alter_Database = SQL_Command.ExecuteReader();
            while (SQL_Alter_Database.Read())
            {
                if (SQL_Alter_Database["New Chalet"].ToString() == "-1")
                {
                    HeldBookings[count, 0] = SQL_Alter_Database["Booking ID"].ToString();
                    HeldBookings[count, 1] = SQL_Alter_Database["ID"].ToString();
                    count++;
                }
            }
            new_connection.Close();

            for (int Held = 0; Held < HeldBookings.GetLength(0); Held++)
            {
                bool Matched = false;
                for (int Limbo = 0; Limbo < LimboBookings.GetLength(0) && Matched == false; Limbo++)
                {
                    if (HeldBookings[Held, 0] == LimboBookings[Limbo, 0])
                    {
                        Matched = true;
                    }
                }
                if (Matched == false)
                {
                    SQL_Command = new MySqlCommand("DELETE FROM `chichester_cattery_booking_system`.`potential changes` WHERE `ID` = '" + HeldBookings[Held, 1] + "';", new_connection);
                    new_connection.Open();
                    SQL_Alter_Database = SQL_Command.ExecuteReader();
                    new_connection.Close();
                }
            }

            for (int Limbo = 0; Limbo < LimboBookings.GetLength(0); Limbo++)
            {
                bool Matched = false;
                for (int Held = 0; Held < HeldBookings.GetLength(0) && Matched == false; Held++)
                {
                    if (LimboBookings[Limbo, 0] == HeldBookings[Held, 0])
                    {
                        Matched = true;
                    }
                }
                if (Matched == false)
                {
                    int ID = 1;
                    while (true)
                    {
                        bool IDFound = true;
                        SQL_Command = new MySqlCommand("SELECT * FROM `Chichester_Cattery_Booking_System`.`Potential Changes` WHERE `ID` = '" + ID + "'", new_connection);
                        new_connection.Open();
                        SQL_Alter_Database = SQL_Command.ExecuteReader();
                        while (SQL_Alter_Database.Read())
                        {
                            ID++;
                            IDFound = false;
                        }
                        new_connection.Close();

                        if (IDFound == true)
                        {
                            break;
                        }
                    }
                    SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`potential changes` (`ID`, `Booking ID`, `New Chalet`) VALUES ('" + ID + "', '" + LimboBookings[Limbo, 0] + "', '-1')", new_connection);
                    new_connection.Open();
                    SQL_Alter_Database = SQL_Command.ExecuteReader();
                    new_connection.Close();
                }
            }
        }
    }
}