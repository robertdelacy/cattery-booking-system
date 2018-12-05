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

namespace Solution
{
    public partial class form_registrationsystem : Form
    {

        string[,] registrationssorted;
        string selectedregistration = "";
        DateTime bookingarrivaldate;
        int bookingchalet = -1;
        string selectedbooking = "";

        public form_registrationsystem()
        {
            InitializeComponent();

            this.SuspendLayout();

            Rectangle resolution = Screen.PrimaryScreen.Bounds;

            double WidthScale = (double)resolution.Width / (double)this.Width;
            double HeightScale = (double)resolution.Height / (double)this.Height;

            this.Width = (int)(this.Width * WidthScale);
            this.Height = (int)(this.Height * HeightScale);

            MyGlobalClass.ScaleParent(HeightScale, WidthScale, this);

            this.ResumeLayout();
            this.PerformLayout();
        }

        private void timer_registrationsystem_Tick(object sender, EventArgs e)
        {
            MyGlobalClass.CheckFormCount(button_goback_registrationsystem);

            MyGlobalClass.CheckHeldBookings();

            int count = 0;
            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`potential changes`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                count++;
            }
            MyGlobalClass.new_connection.Close();

            if (count == 0)
            {
                button_home_registrationsystem.Text = "Home";
            }
            else
            {
                button_home_registrationsystem.Text = "Home (" + count + ")";
            }
        }

        private void button_home_registrationsystem_Click(object sender, EventArgs e)
        {
            MyGlobalClass.registrationquery = new string[0, 0];
            listbox_registrationqueryreult_regstrationsystem.Items.Clear();
            splitcontainer_registrationsearch_registrationsystem.Panel1Collapsed = true;
            text_registrationqueryresult_regstrationsystem.Clear();
            var newform = new form_initialscreen();
            MyGlobalClass.CloseForm(newform, this);
        }

        private void button_addnewbooking_registrationsystem_Click(object sender, EventArgs e)
        {
            MyGlobalClass.registrationquery = new string[0, 0];
            listbox_registrationqueryreult_regstrationsystem.Items.Clear();
            splitcontainer_registrationsearch_registrationsystem.Panel1Collapsed = true;
            text_registrationqueryresult_regstrationsystem.Clear();
            MyGlobalClass.booking_edit = false;
            var newform = new form_addnewbooking();
            MyGlobalClass.previous_form_addnewbooking = new form_registrationsystem();
            if (selectedregistration != "")
            {
                if (MessageBox.Show("Do you wish to use the selected registration for the new booking?", "Selected Registration", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    MyGlobalClass.registration_booking = selectedregistration;
                    MyGlobalClass.booking_addnewbooking = new string[4] { "", "", "", "" };
                    MyGlobalClass.updateaddnewbooking = true;
                }
            }
            MyGlobalClass.CloseForm(newform, this);
        }

        private void button_bookings_registrationsystem_Click(object sender, EventArgs e)
        {
            MyGlobalClass.registrationquery = new string[0, 0];
            listbox_registrationqueryreult_regstrationsystem.Items.Clear();
            splitcontainer_registrationsearch_registrationsystem.Panel1Collapsed = true;
            text_registrationqueryresult_regstrationsystem.Clear();
            var newform = new form_bookingsystem();
            MyGlobalClass.CloseForm(newform, this);
        }

        private void button_searchbookings_registrationsystem_Click(object sender, EventArgs e)
        {
            MyGlobalClass.registrationquery = new string[0, 0];
            listbox_registrationqueryreult_regstrationsystem.Items.Clear();
            splitcontainer_registrationsearch_registrationsystem.Panel1Collapsed = true;
            text_registrationqueryresult_regstrationsystem.Clear();
            var newform = new form_bookingsystem();
            MyGlobalClass.FillQuery(text_bookingquery_registrationsystem.Text, true, true, false);
            MyGlobalClass.CloseForm(newform, this);
        }

        private void button_searchregistrations_registrationsystem_Click(object sender, EventArgs e)
        {
            MyGlobalClass.registrationquery = MyGlobalClass.FillQuery(text_registrationquery_regstrationsystem.Text, true, false, true); //Search registrations and add to global array
            if (MyGlobalClass.registrationquery.GetLength(0) > 0) //If array has any items (why a blank item is added if no results)
            {
                listbox_registrationqueryreult_regstrationsystem.Items.Clear();
                if (MyGlobalClass.registrationquerystring != "") //If the searched string is not blank
                {
                    for (int i = 0; i < MyGlobalClass.registrationquery.GetLength(0); i++)
                    {
                        if (MyGlobalClass.registrationquery[i, 0] != "")
                        {
                            listbox_registrationqueryreult_regstrationsystem.Items.Add(MyGlobalClass.registrationquery[i, 0]);
                        }
                    }
                }
                splitcontainer_registrationsearch_registrationsystem.Panel1Collapsed = false;
                text_registrationqueryresult_regstrationsystem.Text = "'" + MyGlobalClass.registrationquerystring + "'";
            }
            else
            {
                splitcontainer_registrationsearch_registrationsystem.Panel1Collapsed = true;
            }
            MyGlobalClass.updatelistboxwidth(listbox_registrationqueryreult_regstrationsystem, 0, 350); //Re-sizing of the search results list box
        }

        private void button_goback_registrationsystem_Click(object sender, EventArgs e)
        {
            MyGlobalClass.GoBack(this);
        }

        private void button_minimizeform_registrationsystem_Click(object sender, EventArgs e)
        {
            MyGlobalClass.MinimizeApplication();
        }

        private void button_closeform_registrationsystem_Click(object sender, EventArgs e)
        {
            MyGlobalClass.CloseApplication(this);
        }

        private void button_addnewregistration_registrationsystem_Click(object sender, EventArgs e)
        {
            MyGlobalClass.registrationquery = new string[0, 0];
            MyGlobalClass.registration_addnewregistration = "";
            listbox_registrationqueryreult_regstrationsystem.Items.Clear();
            splitcontainer_registrationsearch_registrationsystem.Panel1Collapsed = true;
            text_registrationqueryresult_regstrationsystem.Clear();

            FormCollection formcollection = Application.OpenForms;
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                Form openform = Application.OpenForms[i];
                openform.WindowState = FormWindowState.Maximized;
                if (openform.Name == "form_addnewregistration")
                {
                    MyGlobalClass.updateaddnewregistration = true;
                }
            }

            var newform = new form_addnewregistration();
            MyGlobalClass.previous_form_addnewregistration = new form_registrationsystem();
            MyGlobalClass.CloseForm(newform, this);
        }

        private void listbox_registrationslist_regstrationsystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbox_registrationslist_regstrationsystem.SelectedIndex > -1)//Checks whether a registration has been selected (or deselected)
            {
                if (listbox_registrationqueryreult_regstrationsystem.SelectedIndex > -1)
                { //If there is a registration selected from the search results                  //Stops the registration search results list box from deselecting when it's selection is changed
                    if (MyGlobalClass.registrationquery[listbox_registrationqueryreult_regstrationsystem.SelectedIndex, 1] == selectedregistration)
                    { //Stops the 'Extra Information' from being updated in the database when selecting a different registration
                        text_extrainfo_registrationsystem.TextChanged -= text_extrainfo_registrationsystem_TextChanged;
                        selectedregistration = registrationssorted[listbox_registrationslist_regstrationsystem.SelectedIndex, 1]; //Update the selected registration
                        MyGlobalClass.selectedregistration = new string[21, 2];
                        MyGlobalClass.selectedregistrationcats = new string[9, 12]; //Clear the information arrays
                        text_multilineallinfo_regstrationsystem.Text = MyGlobalClass.retrieveregistrationdata(selectedregistration, false); //Update the information text box and arrays
                        listbox_registrationqueryreult_regstrationsystem.SetSelected(listbox_registrationqueryreult_regstrationsystem.SelectedIndex, false);
                        //Deselect the search list box
                        MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = '" + selectedregistration + "';", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        while (MyGlobalClass.SQL_Alter_Database.Read())
                        {
                            text_extrainfo_registrationsystem.Text = MyGlobalClass.SQL_Alter_Database["Extra Information"].ToString(); //Update the 'Extra Information' text box
                        }
                        MyGlobalClass.new_connection.Close();
                        text_extrainfo_registrationsystem.TextChanged += text_extrainfo_registrationsystem_TextChanged;
                        //Allows the 'Extra Information' from being updated in the database when changing the text
                    }
                }
                else if (registrationssorted[listbox_registrationslist_regstrationsystem.SelectedIndex, 1] == selectedregistration)
                {//If selecting the same registration, deselect it and clear all variables for a selected registration
                    if (MyGlobalClass.maintainselected[0] == false)
                    {
                        selectedregistration = "";
                        MyGlobalClass.selectedregistration = new string[21, 2];
                        MyGlobalClass.selectedregistrationcats = new string[9, 12];
                        text_multilineallinfo_regstrationsystem.Clear();
                        listbox_registrationpastbookings_registrationsystem.Items.Clear();
                        text_extrainfo_registrationsystem.TextChanged -= text_extrainfo_registrationsystem_TextChanged;
                        text_extrainfo_registrationsystem.Clear();
                        text_extrainfo_registrationsystem.TextChanged += text_extrainfo_registrationsystem_TextChanged;
                        listbox_registrationslist_regstrationsystem.SetSelected(listbox_registrationslist_regstrationsystem.SelectedIndex, false);
                    }
                }
                else
                {//When selecting a different registration
                    text_extrainfo_registrationsystem.TextChanged -= text_extrainfo_registrationsystem_TextChanged;
                    selectedregistration = registrationssorted[listbox_registrationslist_regstrationsystem.SelectedIndex, 1]; //Updating the selected registration
                    MyGlobalClass.selectedregistration = new string[21, 2];
                    MyGlobalClass.selectedregistrationcats = new string[9, 12];
                    text_multilineallinfo_regstrationsystem.Text = MyGlobalClass.retrieveregistrationdata(selectedregistration, false);
                    //Update the information text box and arrays
                    #region bookings
                    listbox_registrationpastbookings_registrationsystem.Items.Clear();
                    for (int booking = 0; booking < MyGlobalClass.selectedregistrationbookings.GetLength(0); booking++)
                    {
                        string text = "" + MyGlobalClass.selectedregistrationbookings[booking, 1] + " to " + MyGlobalClass.selectedregistrationbookings[booking, 2] + ": ";
                        int i = 3;
                        int count = 1;
                        do
                        {
                            if (MyGlobalClass.selectedregistrationbookings[booking, i].ToString() != "NULL")
                            {
                                if (count == 1)
                                {
                                    text = text + MyGlobalClass.selectedregistrationcats[0, (i - 3) * 2];
                                }
                                else
                                {
                                    text = text + ", " + MyGlobalClass.selectedregistrationcats[0, (i - 3) * 2] + "";
                                }
                                count++;
                            }
                            i++;
                        } while (i <= 8);

                        listbox_registrationpastbookings_registrationsystem.Items.Add(text);
                    }
                    #endregion
                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = '" + selectedregistration + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        text_extrainfo_registrationsystem.Text = MyGlobalClass.SQL_Alter_Database["Extra Information"].ToString(); //Update the 'Extra Information' text box
                    }
                    MyGlobalClass.new_connection.Close();
                    text_extrainfo_registrationsystem.TextChanged += text_extrainfo_registrationsystem_TextChanged;
                }
            }
        }

        private void text_extrainfo_registrationsystem_TextChanged(object sender, EventArgs e)
        {
            this.SuspendLayout();
            MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`registrations` SET `Extra Information`='" + this.text_extrainfo_registrationsystem.Text + "' WHERE `Registration ID`='" + selectedregistration + "'; SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = '" + selectedregistration + "';", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                text_extrainfo_registrationsystem.Text = MyGlobalClass.SQL_Alter_Database["Extra Information"].ToString();
            }
            MyGlobalClass.new_connection.Close();
            this.ResumeLayout();
            this.PerformLayout();
        }

        private void button_deleteregistration_regstrationsystem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Registration?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            { //Double checks whether deletion is required
                MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Registration ID` = '" + selectedregistration + "';", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                while (MyGlobalClass.SQL_Alter_Database.Read())
                {
                    MyGlobalClass.removebookingdata(MyGlobalClass.SQL_Alter_Database["Booking ID"].ToString()); //Removes booking data
                }
                MyGlobalClass.new_connection.Close();

                MyGlobalClass.SQL_Command = new MySqlCommand("DELETE FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID`='" + selectedregistration + "';", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open(); //Deletes registration record
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                MyGlobalClass.new_connection.Close();

                MyGlobalClass.removeredundantregistrationvalues(); //Calls the global method of removing the unused data

                if (selectedregistration == MyGlobalClass.registration_booking)
                {
                    MyGlobalClass.selectedregistration = new string[21, 2]; //Clears the arrays
                    MyGlobalClass.selectedregistrationcats = new string[9, 12];
                }
                selectedregistration = "";
                text_multilineallinfo_regstrationsystem.Clear();
                listbox_registrationpastbookings_registrationsystem.Items.Clear();
                text_extrainfo_registrationsystem.TextChanged -= text_extrainfo_registrationsystem_TextChanged;
                text_extrainfo_registrationsystem.Clear();                                                           //Clears the information as if deselecting the registration
                text_extrainfo_registrationsystem.TextChanged += text_extrainfo_registrationsystem_TextChanged;
                listbox_registrationslist_regstrationsystem.SelectedIndex = -1;

                registrationssorted = MyGlobalClass.FillQuery("", false, false, false); //Updates the registration system
                listbox_registrationslist_regstrationsystem.Items.Clear();
                for (int i = 0; i < registrationssorted.GetLength(0); i++)
                {
                    listbox_registrationslist_regstrationsystem.Items.Add(registrationssorted[i, 0]);
                    if (registrationssorted[i, 1] == MyGlobalClass.registration_registrationsystem)
                    {
                        listbox_registrationslist_regstrationsystem.SelectedIndex = i;
                        MyGlobalClass.registration_registrationsystem = "";
                    }
                }

                if (MyGlobalClass.registrationquery.GetLength(0) > 0)  //If a search has been previously made
                {
                    MyGlobalClass.registrationquery = MyGlobalClass.FillQuery(MyGlobalClass.registrationquerystring, true, false, true);
                    if (MyGlobalClass.registrationquery.GetLength(0) > 0)  //Re-search registrations and re-add the results to the search results list box
                    {
                        listbox_registrationqueryreult_regstrationsystem.Items.Clear();
                        if (MyGlobalClass.registrationquerystring != "")
                        {
                            for (int i = 0; i < MyGlobalClass.registrationquery.GetLength(0); i++)
                            {
                                if (MyGlobalClass.registrationquery[i, 0] != "")
                                {
                                    listbox_registrationqueryreult_regstrationsystem.Items.Add(MyGlobalClass.registrationquery[i, 0]);
                                }
                            }
                        }
                        splitcontainer_registrationsearch_registrationsystem.Panel1Collapsed = false;
                        text_registrationqueryresult_regstrationsystem.Text = "'" + MyGlobalClass.registrationquerystring + "'";
                    }
                    else
                    {
                        splitcontainer_registrationsearch_registrationsystem.Panel1Collapsed = true;
                    }
                    MyGlobalClass.updatelistboxwidth(listbox_registrationqueryreult_regstrationsystem, 0, 350); //Re-sizing of the search results list box
                }
            }
        }

        private void text_multilineallinfo_regstrationsystem_TextChanged(object sender, EventArgs e)
        {
            if (text_multilineallinfo_regstrationsystem.Text != "")
            {
                splitcontainer_registrationinfo_registrationsystem.Panel1.Enabled = true;
            }
            else
            {
                splitcontainer_registrationinfo_registrationsystem.Panel1.Enabled = false;
            }
        }

        private void button_editregistration_registrationsystem_Click(object sender, EventArgs e)
        {
            FormCollection formcollection = Application.OpenForms;
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                Form openform = Application.OpenForms[i];
                openform.WindowState = FormWindowState.Maximized;
                if (openform.Name == "form_addnewregistration")
                {
                    MyGlobalClass.updateaddnewregistration = true;
                }
            }

            MyGlobalClass.registration_addnewregistration = selectedregistration; //Set the altered registration as the selected registration
            var newform = new form_addnewregistration();
            MyGlobalClass.previous_form_addnewregistration = new form_registrationsystem(); //Set the previous form variable for cancelling or adding the new registration
            MyGlobalClass.CloseForm(newform, this);
        }

        private void form_registrationsystem_Load(object sender, EventArgs e)
        {
            MyGlobalClass.maintainselected[0] = true;
            registrationssorted = MyGlobalClass.FillQuery("", false, false, false); // Calling the global method
            listbox_registrationslist_regstrationsystem.Items.Clear(); //Clear the registrations list box
            for (int i = 0; i < registrationssorted.GetLength(0); i++)
            {
                listbox_registrationslist_regstrationsystem.Items.Add(registrationssorted[i, 0]); //Add all registrations to the list box
                if (registrationssorted[i, 1] == MyGlobalClass.registration_registrationsystem && listbox_registrationslist_regstrationsystem.SelectedIndex != i) //Selected the required registration
                {
                    listbox_registrationslist_regstrationsystem.SelectedIndex = i;
                    if (MyGlobalClass.maintainselected[1] == false) //Clear the 'altered_registration' if it doesn't require re-selecting
                    {
                        MyGlobalClass.registration_registrationsystem = ""; //Clear the 'altered_registration
                    }
                }
            }
            if (MyGlobalClass.registrationquery.GetLength(0) > 0) //If there a search has been made, add the search results to the list box
            {
                listbox_registrationqueryreult_regstrationsystem.Items.Clear(); //Clear the list box
                if (MyGlobalClass.registrationquerystring != "")
                {
                    for (int i = 0; i < MyGlobalClass.registrationquery.GetLength(0); i++)
                    {
                        if (MyGlobalClass.registrationquery[i, 0] != "")
                        {
                            listbox_registrationqueryreult_regstrationsystem.Items.Add(MyGlobalClass.registrationquery[i, 0]);
                            if (MyGlobalClass.registrationquery[i, 1] == MyGlobalClass.selectedregistrationquery)
                            {
                                listbox_registrationqueryreult_regstrationsystem.SelectedIndex = i;
                                MyGlobalClass.selectedregistrationquery = "";
                            }
                        }
                    }
                }
                splitcontainer_registrationsearch_registrationsystem.Panel1Collapsed = false; //Expand the panel
                text_registrationqueryresult_regstrationsystem.Text = "'" + MyGlobalClass.registrationquerystring + "'"; //Add the searched text to the text box
            }
            else
            {
                splitcontainer_registrationsearch_registrationsystem.Panel1Collapsed = true; //Collapse the panel if no search
            }
            MyGlobalClass.maintainselected[0] = false;

            MyGlobalClass.updatelistboxwidth(listbox_registrationslist_regstrationsystem, 0, 650);
            MyGlobalClass.updatelistboxwidth(listbox_registrationqueryreult_regstrationsystem, 0, 350); //Re-size the list boxes
        }

        private void button_exitsearchresults_registrationsystem_Click(object sender, EventArgs e)
        {
            MyGlobalClass.registrationquery = new string[0, 0];
            listbox_registrationqueryreult_regstrationsystem.Items.Clear();
            splitcontainer_registrationsearch_registrationsystem.Panel1Collapsed = true;
            text_registrationqueryresult_regstrationsystem.Clear();
            if (listbox_registrationslist_regstrationsystem.SelectedIndex < 0)
            {
                selectedregistration = "";
                MyGlobalClass.selectedregistration = new string[21, 2];
                MyGlobalClass.selectedregistrationcats = new string[9, 12];
                text_multilineallinfo_regstrationsystem.Clear();
                listbox_registrationpastbookings_registrationsystem.Items.Clear();
                text_extrainfo_registrationsystem.TextChanged -= text_extrainfo_registrationsystem_TextChanged;
                text_extrainfo_registrationsystem.Clear();
                text_extrainfo_registrationsystem.TextChanged += text_extrainfo_registrationsystem_TextChanged;
            }
            listbox_registrationqueryreult_regstrationsystem.SelectedIndex = -1;
        }

        private void listbox_registrationqueryreult_regstrationsystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbox_registrationqueryreult_regstrationsystem.SelectedIndex > -1)
            {
                if (listbox_registrationslist_regstrationsystem.SelectedIndex > -1)
                {
                    if (registrationssorted[listbox_registrationslist_regstrationsystem.SelectedIndex, 1] == selectedregistration)
                    {
                        text_extrainfo_registrationsystem.TextChanged -= text_extrainfo_registrationsystem_TextChanged;
                        selectedregistration = MyGlobalClass.registrationquery[listbox_registrationqueryreult_regstrationsystem.SelectedIndex, 1];
                        MyGlobalClass.selectedregistration = new string[21, 2];
                        MyGlobalClass.selectedregistrationcats = new string[9, 12];
                        text_multilineallinfo_regstrationsystem.Text = MyGlobalClass.retrieveregistrationdata(selectedregistration, false);
                        listbox_registrationslist_regstrationsystem.SetSelected(listbox_registrationslist_regstrationsystem.SelectedIndex, false);

                        MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = '" + selectedregistration + "';", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        while (MyGlobalClass.SQL_Alter_Database.Read())
                        {
                            text_extrainfo_registrationsystem.Text = MyGlobalClass.SQL_Alter_Database["Extra Information"].ToString();
                        }
                        MyGlobalClass.new_connection.Close();
                        text_extrainfo_registrationsystem.TextChanged += text_extrainfo_registrationsystem_TextChanged;
                    }
                }
                else if (MyGlobalClass.registrationquery[listbox_registrationqueryreult_regstrationsystem.SelectedIndex, 1] == selectedregistration)
                {
                    if (MyGlobalClass.maintainselected[0] == false)
                    {
                        selectedregistration = "";
                        MyGlobalClass.selectedregistration = new string[21, 2];
                        MyGlobalClass.selectedregistrationcats = new string[9, 12];
                        text_multilineallinfo_regstrationsystem.Clear();
                        listbox_registrationpastbookings_registrationsystem.Items.Clear();
                        text_extrainfo_registrationsystem.TextChanged -= text_extrainfo_registrationsystem_TextChanged;
                        text_extrainfo_registrationsystem.Clear();
                        text_extrainfo_registrationsystem.TextChanged += text_extrainfo_registrationsystem_TextChanged;
                        listbox_registrationqueryreult_regstrationsystem.SetSelected(listbox_registrationqueryreult_regstrationsystem.SelectedIndex, false);
                    }
                }
                else
                {
                    text_extrainfo_registrationsystem.TextChanged -= text_extrainfo_registrationsystem_TextChanged;
                    selectedregistration = MyGlobalClass.registrationquery[listbox_registrationqueryreult_regstrationsystem.SelectedIndex, 1];
                    MyGlobalClass.selectedregistration = new string[21, 2];
                    MyGlobalClass.selectedregistrationcats = new string[9, 12];
                    text_multilineallinfo_regstrationsystem.Text = MyGlobalClass.retrieveregistrationdata(selectedregistration, false);

                    listbox_registrationpastbookings_registrationsystem.Items.Clear();
                    for (int booking = 0; booking < MyGlobalClass.selectedregistrationbookings.GetLength(0); booking++)
                    {
                        string text = "" + MyGlobalClass.selectedregistrationbookings[booking, 1] + " to " + MyGlobalClass.selectedregistrationbookings[booking, 2] + ": ";
                        int i = 3;
                        do
                        {
                            if (MyGlobalClass.selectedregistrationbookings[booking, i].ToString() != "NULL")
                            {
                                if (i == 3)
                                {
                                    text = text + MyGlobalClass.selectedregistrationcats[0, (i - 3) * 2];
                                }
                                else
                                {
                                    text = text + ", " + MyGlobalClass.selectedregistrationcats[0, (i - 3) * 2] + "";
                                }
                            }
                            i++;
                        } while (i <= 8);

                        listbox_registrationpastbookings_registrationsystem.Items.Add(text);
                    }

                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = '" + selectedregistration + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        text_extrainfo_registrationsystem.Text = MyGlobalClass.SQL_Alter_Database["Extra Information"].ToString();
                    }
                    MyGlobalClass.new_connection.Close();
                    text_extrainfo_registrationsystem.TextChanged += text_extrainfo_registrationsystem_TextChanged;
                }
            }
        }

        private void form_registrationsystem_activated(object sender, EventArgs e)
        {
            if (listbox_registrationslist_regstrationsystem.SelectedIndex > -1 && MyGlobalClass.registration_registrationsystem == "")
            {
                MyGlobalClass.registration_registrationsystem = registrationssorted[listbox_registrationslist_regstrationsystem.SelectedIndex, 1];
            }
            if (listbox_registrationqueryreult_regstrationsystem.SelectedIndex > -1 && MyGlobalClass.selectedregistrationquery == "")
            {
                MyGlobalClass.selectedregistrationquery = MyGlobalClass.registrationquery[listbox_registrationqueryreult_regstrationsystem.SelectedIndex, 1];
            }
            form_registrationsystem_Load(sender, e);
            MyGlobalClass.maintainselected[1] = false;
        }

        private void listbox_registrationpastbookings_registrationsystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbox_registrationpastbookings_registrationsystem.SelectedIndex > -1)
            {
                if (MyGlobalClass.selectedregistrationbookings[listbox_registrationpastbookings_registrationsystem.SelectedIndex, 0] == selectedbooking)
                {
                    selectedbooking = "";
                    listbox_registrationpastbookings_registrationsystem.SelectedIndex = -1;
                }
                else
                {
                    selectedbooking = MyGlobalClass.selectedregistrationbookings[listbox_registrationpastbookings_registrationsystem.SelectedIndex, 0];
                    bookingchalet = int.Parse(MyGlobalClass.selectedregistrationbookings[listbox_registrationpastbookings_registrationsystem.SelectedIndex, 9]);
                    bookingarrivaldate = DateTime.Parse(MyGlobalClass.selectedregistrationbookings[listbox_registrationpastbookings_registrationsystem.SelectedIndex, 1]);
                    button_viewbooking_registrationsystem.Enabled = true;
                    button_viewbooking_registrationsystem.Visible = true;
                }
            }
            else
            {
                button_viewbooking_registrationsystem.Enabled = false;
                button_viewbooking_registrationsystem.Visible = false;
            }
        }

        private void button_viewbooking_registrationsystem_Click(object sender, EventArgs e)
        {
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

        private void text_bookingquery_registrationsystem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_searchbookings_registrationsystem_Click(sender, new EventArgs());
            }
        }

        private void text_registrationquery_regstrationsystem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_searchregistrations_registrationsystem_Click(sender, new EventArgs());
            }
        }

        private void listbox_registrationpastbookings_registrationsystem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && button_viewbooking_registrationsystem.Enabled == true)
            {
                button_viewbooking_registrationsystem_Click(sender, new EventArgs());
            }
        }

        private void text_bookingquery_registrationsystem_Enter(object sender, EventArgs e)
        {
            button_searchbookings_registrationsystem.Font = new Font(Font.FontFamily, button_searchbookings_registrationsystem.Font.Size, FontStyle.Bold);
        }

        private void text_bookingquery_registrationsystem_Leave(object sender, EventArgs e)
        {
            button_searchbookings_registrationsystem.Font = new Font(Font.FontFamily, button_searchbookings_registrationsystem.Font.Size, FontStyle.Regular);
        }

        private void text_registrationquery_regstrationsystem_Enter(object sender, EventArgs e)
        {
            button_searchregistrations_registrationsystem.Font = new Font(Font.FontFamily, button_searchregistrations_registrationsystem.Font.Size, FontStyle.Bold);
        }

        private void text_registrationquery_regstrationsystem_Leave(object sender, EventArgs e)
        {
            button_searchregistrations_registrationsystem.Font = new Font(Font.FontFamily, button_searchregistrations_registrationsystem.Font.Size, FontStyle.Regular);
        }
    }
}
