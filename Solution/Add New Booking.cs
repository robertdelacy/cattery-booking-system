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
    public partial class form_addnewbooking : Form
    {
        string selectedregistration = "";
        string[] vaccinationdates = new string[6];
        string[] booking = new string[20];
        string[,] freechaletssorted;
        string[,] bookingcount = new string[0, 0];
        int records = 0;
        string checkedin = "";
        string checkedout = "";
        string editregistration = "";

        public form_addnewbooking()
        {
            InitializeComponent();

            this.SuspendLayout();

            FormCollection formcollection = Application.OpenForms; //This section of code is similar to the OpenForm method
            bool AddNewBookingFound = false;
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                Form openform = Application.OpenForms[i];
                openform.WindowState = FormWindowState.Maximized;
                if (openform.Name == "form_addnewbooking")
                {
                    AddNewBookingFound = true;
                }
            }
            if (AddNewBookingFound == false)
            {
                MyGlobalClass.updateaddnewbooking = true;
            }

            Rectangle resolution = Screen.PrimaryScreen.Bounds;

            double WidthScale = (double)resolution.Width / (double)this.Width;
            double HeightScale = (double)resolution.Height / (double)this.Height;

            this.Width = (int)(this.Width * WidthScale);
            this.Height = (int)(this.Height * HeightScale);

            MyGlobalClass.ScaleParent(HeightScale, WidthScale, this);

            foreach (ColumnStyle Width in tableLayoutPanel_registrationbuttons_addnewbooking.ColumnStyles)
            {
                Width.Width = tableLayoutPanel_registrationbuttons_addnewbooking.Width / 3;
            }

            this.ResumeLayout();
            this.PerformLayout();
        }

        private void button_cancelnewbooking_addnewbooking_Click(object sender, EventArgs e)
        {
            var previous_form = MyGlobalClass.previous_form_addnewbooking; //Initializes new var variable as the form stored in the previous_form_addnewbooking variable
            try //Try Catch insures no errors occur 
            {
                string text = "Are you sure you want to cancel the New Booking?";
                if (button_cancelnewbooking_addnewbooking.Text == "Cancel Booking Edit")
                {
                    text = "Are you sure you want to cancel the editing of the Booking?";
                }
                if (MessageBox.Show(text, "Cancel?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    selectedregistration = "";
                    MyGlobalClass.registration_booking = "";
                    MyGlobalClass.navigation = true;
                    MyGlobalClass.CloseForm(previous_form, this); //CloseForm method using the previous form
                    MyGlobalClass.navigation = false;
                }
            }
            catch
            {
            }
        }

        private void button_minimizeform_addnewbooking_Click(object sender, EventArgs e)
        {
            MyGlobalClass.MinimizeApplication();
        }

        private void button_closeform_addnewbooking_Click(object sender, EventArgs e)
        {
            MyGlobalClass.CloseApplication(this);
        }

        private void button_home_addnewbooking_Click(object sender, EventArgs e)
        {
            var newform = new form_initialscreen();
            MyGlobalClass.OpenForm(newform);
        }

        private void button_bookings_addnewbooking_Click(object sender, EventArgs e)
        {
            var newform = new form_bookingsystem();
            MyGlobalClass.OpenForm(newform);
        }

        private void button_registrations_addnewbooking_Click(object sender, EventArgs e)
        {
            var newform = new form_registrationsystem();
            MyGlobalClass.OpenForm(newform);
        }

        private void button_searchbookings_addnewbooking_Click(object sender, EventArgs e)
        {
            var newform = new form_bookingsystem();
            MyGlobalClass.FillQuery(text_bookingquery_addnewbooking.Text, true, true, false);
            MyGlobalClass.OpenForm(newform);
        }

        private void button_searchregistrations_addnewbooking_Click(object sender, EventArgs e)
        {
            MyGlobalClass.registrationquery = MyGlobalClass.FillQuery(text_registrationquery_addnewbooking.Text, true, false, true);
            var newform = new form_registrationsystem();
            MyGlobalClass.OpenForm(newform);
        }

        private void button_addnewregistration_addnewbooking_Click(object sender, EventArgs e)
        {
            var newform = new form_addnewregistration();
            MyGlobalClass.previous_form_addnewregistration = new form_addnewbooking();
            MyGlobalClass.OpenForm(newform);
        }

        private void button_goback_addnewbooking_Click(object sender, EventArgs e)
        {
            MyGlobalClass.GoBack(this);
        }

        private void timer_addnewbooking_Tick(object sender, EventArgs e)
        {
            MyGlobalClass.CheckFormCount(button_goback_addnewbooking);

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
                button_home_addnewbooking.Text = "Home";
            }
            else
            {
                button_home_addnewbooking.Text = "Home (" + count + ")";
            }
        }

        private void form_addnewbooking_Load(object sender, EventArgs e)
        {

        }

        private void text_ownerconfirmationdetails_addnewbooking_TextChanged(object sender, EventArgs e)
        {
            if (text_ownerconfirmationdetails_addnewbooking.Text != "")
            {
                text_ownerconfirmationdetails_addnewbooking.Enabled = true;
                checkedlistbox_catsstaying_addnewbooking.Enabled = true;
                datetimepicker_arrivaldate_addnewbooking.Enabled = true;
                datetimepicker_departuredate_addnewbooking.Enabled = true;
                combobox_arrivaltime_addnewbooking.Enabled = true;
                combobox_departuretime_addnewbooking.Enabled = true;
                button_confirmbooking_addnewbooking.Enabled = true;
            }
            else
            {
                text_ownerconfirmationdetails_addnewbooking.Enabled = false;
                checkedlistbox_catsstaying_addnewbooking.Enabled = false;
                datetimepicker_arrivaldate_addnewbooking.Enabled = false;
                datetimepicker_departuredate_addnewbooking.Enabled = false;
                combobox_arrivaltime_addnewbooking.Enabled = false;
                combobox_departuretime_addnewbooking.Enabled = false;
                button_confirmbooking_addnewbooking.Enabled = false;
            }
        }

        private void button_searchowner_addnewbooking_Click(object sender, EventArgs e)
        {
            MyGlobalClass.registrationquery_addnewbooking = MyGlobalClass.FillQuery(text_ownersearch_addnewbooking.Text, true, false, false);
            if (MyGlobalClass.registrationquery_addnewbooking.GetLength(0) > 0)
            {
                listbox_ownersearchresults_addnewbooking.Items.Clear();
                if (MyGlobalClass.registrationquerystring_addnewbooking != "")
                {
                    for (int i = 0; i < MyGlobalClass.registrationquery_addnewbooking.GetLength(0); i++)
                    {
                        if (MyGlobalClass.registrationquery_addnewbooking[i, 0] != "")
                        {
                            listbox_ownersearchresults_addnewbooking.Items.Add(MyGlobalClass.registrationquery_addnewbooking[i, 0]);
                        }
                    }
                }
                splitcontainer_ownerandcat_addnewbooking.Panel1Collapsed = false;
                text_showownersearch_addnewbooking.Text = "'" + MyGlobalClass.registrationquerystring_addnewbooking + "'";
            }
            MyGlobalClass.updatelistboxwidth(listbox_ownersearchresults_addnewbooking, 0, 420);
            button_confirmowner_addnewbooking.Text = "Exit Registration Search";
            button_confirmowner_addnewbooking.Enabled = true;
        }

        private void listbox_ownersearchresults_addnewbooking_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbox_ownersearchresults_addnewbooking.SelectedIndex > -1)
            {
                if (MyGlobalClass.registration_registrationsystem == MyGlobalClass.registrationquery_addnewbooking[listbox_ownersearchresults_addnewbooking.SelectedIndex, 1])
                {
                    MyGlobalClass.registration_registrationsystem = "";
                    listbox_ownersearchresults_addnewbooking.SetSelected(listbox_ownersearchresults_addnewbooking.SelectedIndex, false);
                    button_viewregistrationrecord_addnewbooking.Enabled = false;
                    button_confirmowner_addnewbooking.Text = "Exit Registration Search";
                    button_viewbookingrecord_addnewbooking.Enabled = false;
                    button_viewbookingrecord_addnewbooking.Visible = false;
                }
                else
                {
                    MyGlobalClass.registration_registrationsystem = MyGlobalClass.registrationquery_addnewbooking[listbox_ownersearchresults_addnewbooking.SelectedIndex, 1];
                    button_viewregistrationrecord_addnewbooking.Enabled = true;
                    button_confirmowner_addnewbooking.Enabled = true;
                    button_confirmowner_addnewbooking.Text = "Confirm Registration";
                    bookingcount = new string[0, 0];
                    int bookingtotal = 0;
                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Registration ID` = '" + MyGlobalClass.registration_registrationsystem + "'", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        if (DateTime.Today < DateTime.Parse(MyGlobalClass.SQL_Alter_Database["Arrival Date"].ToString()) && MyGlobalClass.SQL_Alter_Database["Booking ID"].ToString() != MyGlobalClass.booking_addnewbooking[0])
                        {
                            bookingtotal++;
                        }
                    }
                    MyGlobalClass.new_connection.Close();

                    if (bookingtotal > 0)
                    {
                        bookingcount = new string[bookingtotal, 3];
                        bookingtotal = 0;

                        MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Registration ID` = '" + MyGlobalClass.registration_registrationsystem + "'", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        while (MyGlobalClass.SQL_Alter_Database.Read())
                        {
                            if (DateTime.Today < DateTime.Parse(MyGlobalClass.SQL_Alter_Database["Arrival Date"].ToString()) && MyGlobalClass.SQL_Alter_Database["Booking ID"].ToString() != MyGlobalClass.booking_addnewbooking[0])
                            {
                                bookingcount[bookingtotal, 0] = MyGlobalClass.SQL_Alter_Database["Booking ID"].ToString();
                                bookingcount[bookingtotal, 1] = MyGlobalClass.SQL_Alter_Database["Arrival Date"].ToString();
                                bookingcount[bookingtotal, 2] = MyGlobalClass.SQL_Alter_Database["Chalet"].ToString();
                                bookingtotal++;
                            }
                        }
                        MyGlobalClass.new_connection.Close();
                        if (bookingcount.GetLength(0) > 0)
                        {
                            button_viewbookingrecord_addnewbooking.Enabled = true;
                            button_viewbookingrecord_addnewbooking.Visible = true;
                            if (bookingcount.GetLength(0) > 1)
                            {
                                button_viewbookingrecord_addnewbooking.Text = "View Booking Records (" + bookingcount.GetLength(0) + ")";
                            }
                            else
                            {
                                button_viewbookingrecord_addnewbooking.Text = "View Booking Record";
                            }
                        }
                        else
                        {
                            button_viewbookingrecord_addnewbooking.Enabled = false;
                            button_viewbookingrecord_addnewbooking.Visible = false;
                        }
                    }
                }
            }
        }

        private void button_viewregistrationrecord_addnewbooking_Click(object sender, EventArgs e)
        {
            MyGlobalClass.registration_registrationsystem = MyGlobalClass.registrationquery_addnewbooking[listbox_ownersearchresults_addnewbooking.SelectedIndex, 1];
            MyGlobalClass.maintainselected[1] = true;
            var newform = new form_registrationsystem();
            MyGlobalClass.OpenForm(newform);
        }

        private void button_confirmowner_addnewbooking_Click(object sender, EventArgs e)
        {
            if (listbox_ownersearchresults_addnewbooking.SelectedIndex > -1)
            {
                MyGlobalClass.registration_registrationsystem = MyGlobalClass.registrationquery_addnewbooking[listbox_ownersearchresults_addnewbooking.SelectedIndex, 1];
                bool Continue = false;
                if (bookingcount.GetLength(0) > 0)
                {
                    if (bookingcount.GetLength(0) > 1)
                    {
                        if (MessageBox.Show("There are " + bookingcount.GetLength(0) + " future bookings for this registration. Do you wish to continue?", "Future Bookings", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Continue = true;
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("There is a future booking for this registration. Do you wish to continue?", "Future Booking", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Continue = true;
                        }
                    }
                }
                else
                {
                    Continue = true;
                }
                if (Continue == true)
                {
                    MyGlobalClass.registration_booking = MyGlobalClass.registration_registrationsystem;
                    splitcontainer_ownerandcat_addnewbooking.Panel1Collapsed = true;
                    MyGlobalClass.registration_registrationsystem = "";
                    listbox_ownersearchresults_addnewbooking.SetSelected(listbox_ownersearchresults_addnewbooking.SelectedIndex, false);
                    button_viewregistrationrecord_addnewbooking.Enabled = false;
                    button_confirmowner_addnewbooking.Enabled = false;
                    button_viewbookingrecord_addnewbooking.Enabled = false;
                    button_viewbookingrecord_addnewbooking.Visible = false;
                    bool registrationvalid = false;
                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = '" + MyGlobalClass.registration_booking + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read() && registrationvalid == false)
                    {
                        registrationvalid = true;
                    }
                    MyGlobalClass.new_connection.Close();
                    if (registrationvalid == false)
                    {
                        MyGlobalClass.registration_booking = "";
                    }
                    if (MyGlobalClass.registration_booking != "" && MyGlobalClass.registration_booking != selectedregistration)
                    {
                        selectedregistration = MyGlobalClass.registration_booking;
                        splitcontainer_ownerandcat_addnewbooking.Panel1Collapsed = true;
                        MyGlobalClass.selectedregistration = new string[21, 2];
                        MyGlobalClass.selectedregistrationcats = new string[9, 12];
                        text_ownerconfirmationdetails_addnewbooking.Text = MyGlobalClass.retrieveregistrationdata(selectedregistration, true);
                        checkedlistbox_catsstaying_addnewbooking.Items.Clear();
                        for (int i = 0; i < MyGlobalClass.selectedregistrationcats.GetLength(0); i = i + 2)
                        {
                            if (MyGlobalClass.selectedregistrationcats[0, i] != "" && MyGlobalClass.selectedregistrationcats[0, i] != null)
                            {
                                checkedlistbox_catsstaying_addnewbooking.Items.Add(MyGlobalClass.selectedregistrationcats[0, i]);
                            }
                            if (MyGlobalClass.selectedregistrationcats[3, i] != "" && MyGlobalClass.selectedregistrationcats[3, i] != null)
                            {
                                switch (i)
                                {
                                    case 0:
                                        datetimepicker_vaccinationupdate1_addnewbooking.Value = DateTime.Parse(MyGlobalClass.selectedregistrationcats[3, i]);
                                        datetimepicker_vaccinationupdate1_addnewbooking.Enabled = true;
                                        datetimepicker_vaccinationupdate1_addnewbooking.Visible = true;
                                        text_cat1_addnewbooking.Visible = true;
                                        text_cat1_addnewbooking.Enabled = true;
                                        if (DateTime.Parse(MyGlobalClass.selectedregistrationcats[3, i]) < DateTime.Today)
                                        {
                                            text_cat1_addnewbooking.Text = "" + MyGlobalClass.selectedregistrationcats[0, i] + " (Out of Date)";
                                        }
                                        else
                                        {
                                            text_cat1_addnewbooking.Text = MyGlobalClass.selectedregistrationcats[0, i];
                                        }
                                        break;
                                    case 2:
                                        datetimepicker_vaccinationupdate2_addnewbooking.Value = DateTime.Parse(MyGlobalClass.selectedregistrationcats[3, i]);
                                        datetimepicker_vaccinationupdate2_addnewbooking.Enabled = true;
                                        datetimepicker_vaccinationupdate2_addnewbooking.Visible = true;
                                        text_cat2_addnewbooking.Visible = true;
                                        text_cat2_addnewbooking.Enabled = true;
                                        if (DateTime.Parse(MyGlobalClass.selectedregistrationcats[3, i]) < DateTime.Today)
                                        {
                                            text_cat2_addnewbooking.Text = "" + MyGlobalClass.selectedregistrationcats[0, i] + " (Out of Date)";
                                        }
                                        else
                                        {
                                            text_cat2_addnewbooking.Text = MyGlobalClass.selectedregistrationcats[0, i];
                                        }
                                        break;
                                    case 4:
                                        datetimepicker_vaccinationupdate3_addnewbooking.Value = DateTime.Parse(MyGlobalClass.selectedregistrationcats[3, i]);
                                        datetimepicker_vaccinationupdate3_addnewbooking.Enabled = true;
                                        datetimepicker_vaccinationupdate3_addnewbooking.Visible = true;
                                        text_cat3_addnewbooking.Visible = true;
                                        text_cat3_addnewbooking.Enabled = true;
                                        if (DateTime.Parse(MyGlobalClass.selectedregistrationcats[3, i]) < DateTime.Today)
                                        {
                                            text_cat3_addnewbooking.Text = "" + MyGlobalClass.selectedregistrationcats[0, i] + " (Out of Date)";
                                        }
                                        else
                                        {
                                            text_cat3_addnewbooking.Text = MyGlobalClass.selectedregistrationcats[0, i];
                                        }
                                        break;
                                    case 6:
                                        datetimepicker_vaccinationupdate4_addnewbooking.Value = DateTime.Parse(MyGlobalClass.selectedregistrationcats[3, i]);
                                        datetimepicker_vaccinationupdate4_addnewbooking.Enabled = true;
                                        datetimepicker_vaccinationupdate4_addnewbooking.Visible = true;
                                        text_cat4_addnewbooking.Visible = true;
                                        text_cat4_addnewbooking.Enabled = true;
                                        if (DateTime.Parse(MyGlobalClass.selectedregistrationcats[3, i]) < DateTime.Today)
                                        {
                                            text_cat4_addnewbooking.Text = "" + MyGlobalClass.selectedregistrationcats[0, i] + " (Out of Date)";
                                        }
                                        else
                                        {
                                            text_cat4_addnewbooking.Text = MyGlobalClass.selectedregistrationcats[0, i];
                                        }
                                        break;
                                    case 8:
                                        datetimepicker_vaccinationupdate5_addnewbooking.Value = DateTime.Parse(MyGlobalClass.selectedregistrationcats[3, i]);
                                        datetimepicker_vaccinationupdate5_addnewbooking.Enabled = true;
                                        datetimepicker_vaccinationupdate5_addnewbooking.Visible = true;
                                        text_cat5_addnewbooking.Visible = true;
                                        text_cat5_addnewbooking.Enabled = true;
                                        if (DateTime.Parse(MyGlobalClass.selectedregistrationcats[3, i]) < DateTime.Today)
                                        {
                                            text_cat5_addnewbooking.Text = "" + MyGlobalClass.selectedregistrationcats[0, i] + " (Out of Date)";
                                        }
                                        else
                                        {
                                            text_cat5_addnewbooking.Text = MyGlobalClass.selectedregistrationcats[0, i];
                                        }
                                        break;
                                    case 10:
                                        datetimepicker_vaccinationupdate6_addnewbooking.Value = DateTime.Parse(MyGlobalClass.selectedregistrationcats[3, i]);
                                        datetimepicker_vaccinationupdate6_addnewbooking.Enabled = true;
                                        datetimepicker_vaccinationupdate6_addnewbooking.Visible = true;
                                        text_cat6_addnewbooking.Visible = true;
                                        text_cat6_addnewbooking.Enabled = true;
                                        if (DateTime.Parse(MyGlobalClass.selectedregistrationcats[3, i]) < DateTime.Today)
                                        {
                                            text_cat6_addnewbooking.Text = "" + MyGlobalClass.selectedregistrationcats[0, i] + " (Out of Date)";
                                        }
                                        else
                                        {
                                            text_cat6_addnewbooking.Text = MyGlobalClass.selectedregistrationcats[0, i];
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                switch (i)
                                {
                                    case 0:
                                        text_cat1_addnewbooking.Visible = false;
                                        text_cat1_addnewbooking.Enabled = false;
                                        datetimepicker_vaccinationupdate1_addnewbooking.Enabled = false;
                                        datetimepicker_vaccinationupdate1_addnewbooking.Visible = false;
                                        break;
                                    case 2:
                                        text_cat2_addnewbooking.Visible = false;
                                        text_cat2_addnewbooking.Enabled = false;
                                        datetimepicker_vaccinationupdate2_addnewbooking.Enabled = false;
                                        datetimepicker_vaccinationupdate2_addnewbooking.Visible = false;
                                        break;
                                    case 4:
                                        text_cat3_addnewbooking.Visible = false;
                                        text_cat3_addnewbooking.Enabled = false;
                                        datetimepicker_vaccinationupdate3_addnewbooking.Enabled = false;
                                        datetimepicker_vaccinationupdate3_addnewbooking.Visible = false;
                                        break;
                                    case 6:
                                        text_cat4_addnewbooking.Visible = false;
                                        text_cat4_addnewbooking.Enabled = false;
                                        datetimepicker_vaccinationupdate4_addnewbooking.Enabled = false;
                                        datetimepicker_vaccinationupdate4_addnewbooking.Visible = false;
                                        break;
                                    case 8:
                                        text_cat5_addnewbooking.Visible = false;
                                        text_cat5_addnewbooking.Enabled = false;
                                        datetimepicker_vaccinationupdate5_addnewbooking.Enabled = false;
                                        datetimepicker_vaccinationupdate5_addnewbooking.Visible = false;
                                        break;
                                    case 10:
                                        text_cat6_addnewbooking.Visible = false;
                                        text_cat6_addnewbooking.Enabled = false;
                                        datetimepicker_vaccinationupdate6_addnewbooking.Enabled = false;
                                        datetimepicker_vaccinationupdate6_addnewbooking.Visible = false;
                                        break;
                                }
                            }
                        }
                        for (int i = 0; i < checkedlistbox_catsstaying_addnewbooking.Items.Count; i++)
                        {
                            checkedlistbox_catsstaying_addnewbooking.SetItemCheckState(i, CheckState.Checked);
                        }
                    }
                    else if (MyGlobalClass.registration_booking != selectedregistration)
                    {
                        splitcontainer_ownerandcat_addnewbooking.Panel1Collapsed = true;
                        splitcontainer_datetimeandchalet_addnewbooking.Panel2Collapsed = true;
                        text_ownerconfirmationdetails_addnewbooking.Text = "";
                        checkedlistbox_catsstaying_addnewbooking.Items.Clear();
                        text_cat1_addnewbooking.Visible = false;
                        text_cat1_addnewbooking.Enabled = false;
                        datetimepicker_vaccinationupdate1_addnewbooking.Enabled = false;
                        datetimepicker_vaccinationupdate1_addnewbooking.Visible = false;
                        text_cat2_addnewbooking.Visible = false;
                        text_cat2_addnewbooking.Enabled = false;
                        datetimepicker_vaccinationupdate2_addnewbooking.Enabled = false;
                        datetimepicker_vaccinationupdate2_addnewbooking.Visible = false;
                        text_cat3_addnewbooking.Visible = false;
                        text_cat3_addnewbooking.Enabled = false;
                        datetimepicker_vaccinationupdate3_addnewbooking.Enabled = false;
                        datetimepicker_vaccinationupdate3_addnewbooking.Visible = false;
                        text_cat4_addnewbooking.Visible = false;
                        text_cat4_addnewbooking.Enabled = false;
                        datetimepicker_vaccinationupdate4_addnewbooking.Enabled = false;
                        datetimepicker_vaccinationupdate4_addnewbooking.Visible = false;
                        text_cat5_addnewbooking.Visible = false;
                        text_cat5_addnewbooking.Enabled = false;
                        datetimepicker_vaccinationupdate5_addnewbooking.Enabled = false;
                        datetimepicker_vaccinationupdate5_addnewbooking.Visible = false;
                        text_cat6_addnewbooking.Visible = false;
                        text_cat6_addnewbooking.Enabled = false;
                        datetimepicker_vaccinationupdate6_addnewbooking.Enabled = false;
                        datetimepicker_vaccinationupdate6_addnewbooking.Visible = false;
                    }

                    DialogResult ContinueEditing = DialogResult.Yes;
                    if (MyGlobalClass.registration_booking == editregistration)
                    {
                        ContinueEditing = MessageBox.Show("Do you wish to continue editing the Booking?", "Continue Editing?", MessageBoxButtons.YesNo);
                    }
                    if (MyGlobalClass.registration_booking != editregistration || ContinueEditing == DialogResult.No)
                    {
                        MyGlobalClass.booking_addnewbooking = new string[4] { "", "", "", "" };
                        MyGlobalClass.updateaddnewbooking = false;
                        editregistration = "";
                        button_cancelnewbooking_addnewbooking.Text = "Cancel New Booking";
                        button_confirmbooking_addnewbooking.Text = "Confirm New Booking";
                        combobox_arrivaltime_addnewbooking.SelectedIndex = -1;
                        combobox_arrivaltime_addnewbooking.Text = "";
                        combobox_departuretime_addnewbooking.SelectedIndex = -1;
                        combobox_departuretime_addnewbooking.Text = "";
                        datetimepicker_arrivaldate_addnewbooking.Value = DateTime.Today;
                        datetimepicker_departuredate_addnewbooking.Value = DateTime.Today;
                    }
                }
            }
            else
            {
                splitcontainer_ownerandcat_addnewbooking.Panel1Collapsed = true;
                button_viewregistrationrecord_addnewbooking.Enabled = false;
                button_confirmowner_addnewbooking.Enabled = false;
                button_viewbookingrecord_addnewbooking.Enabled = false;
                button_viewbookingrecord_addnewbooking.Visible = false;
            }
        }

        private void button_viewbookingrecord_addnewbooking_Click(object sender, EventArgs e)
        {
            var newform = new form_bookingsystem();
            if (bookingcount.GetLength(0) > 1)
            {
                MyGlobalClass.futurebookings = new string[bookingcount.GetLength(0), 4];
                for (int booking = 0; booking < bookingcount.GetLength(0); booking++)
                {
                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Booking ID` = '" + bookingcount[booking, 0] + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        MyGlobalClass.futurebookings[booking, 0] = "" + DateTime.Parse(MyGlobalClass.SQL_Alter_Database["Arrival Date"].ToString()).ToString("dd/MM/yyyy") + " - " + DateTime.Parse(MyGlobalClass.SQL_Alter_Database["Departure Date"].ToString()).ToString("dd/MM/yyyy") + " ";

                        MySqlConnection new_connection = new MySqlConnection(MyGlobalClass.connection_to_database);
                        MySqlCommand SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = '" + MyGlobalClass.SQL_Alter_Database["Registration ID"].ToString() + "';", new_connection);
                        new_connection.Open();
                        MySqlDataReader SQL_Alter_Database = SQL_Command.ExecuteReader();
                        while (SQL_Alter_Database.Read())
                        {
                            int i = 1;
                            bool end = false;
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
                                            MyGlobalClass.futurebookings[booking, 0] = MyGlobalClass.futurebookings[booking, 0] + readownername["Contact Name"].ToString();
                                        }
                                        else if (i > 1)
                                        {
                                            MyGlobalClass.futurebookings[booking, 0] = MyGlobalClass.futurebookings[booking, 0] + ", " + readownername["Contact Name"].ToString() + "";
                                        }
                                    }
                                    ownername.Close();
                                }
                                else
                                {
                                    if (i > 1)
                                    {
                                        MyGlobalClass.futurebookings[booking, 0] = MyGlobalClass.futurebookings[booking, 0] + " ";
                                        end = true;
                                    }
                                }
                                i++;
                            } while (i <= 6 && end == false);
                            if (end == false)
                            {
                                MyGlobalClass.futurebookings[booking, 0] = MyGlobalClass.futurebookings[booking, 0] + " ";
                            }
                        }
                        int n = 1;
                        for (int i = 1; i <= 6; i++)
                        {
                            if (MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString() != "NULL")
                            {
                                if (n == 1)
                                {
                                    MyGlobalClass.futurebookings[booking, 0] = MyGlobalClass.futurebookings[booking, 0] + "(" + MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString() + "";
                                }
                                else
                                {
                                    MyGlobalClass.futurebookings[booking, 0] = MyGlobalClass.futurebookings[booking, 0] + ", " + MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString() + "";
                                }
                                n++;
                            }
                        }
                        MyGlobalClass.futurebookings[booking, 0] = MyGlobalClass.futurebookings[booking, 0] + ")";
                        MyGlobalClass.futurebookings[booking, 1] = MyGlobalClass.SQL_Alter_Database["Arrival Date"].ToString();
                        MyGlobalClass.futurebookings[booking, 2] = MyGlobalClass.SQL_Alter_Database["Chalet"].ToString();
                        MyGlobalClass.futurebookings[booking, 3] = MyGlobalClass.SQL_Alter_Database["Booking ID"].ToString();
                    }
                    MyGlobalClass.new_connection.Close();
                }
            }
            else
            {
                MyGlobalClass.updatechaletnumber(false, MyGlobalClass.totalchalets, true);
                MyGlobalClass.shownchaletbookings = new bool[MyGlobalClass.totalchalets];
                for (int i = 0; i < MyGlobalClass.totalchalets; i++)
                {
                    if (i == (int.Parse(bookingcount[0, 2]) - 1))
                    {
                        MyGlobalClass.shownchaletbookings[i] = true;
                    }
                    else
                    {
                        MyGlobalClass.shownchaletbookings[i] = false;
                    }
                }
                MyGlobalClass.bookingsystemdate = DateTime.Parse(bookingcount[0, 1]);
                MyGlobalClass.updatebookingsystemdatetimepickers = true;
            }

            MyGlobalClass.OpenForm(newform);
        }

        private void button_confirmbooking_addnewbooking_Click(object sender, EventArgs e)
        {
            string[,] availablechalets;
            bool Continue = true;

            #region validationchecks
            if (checkedlistbox_catsstaying_addnewbooking.CheckedItems.Count == 0) //Checks if at least one cat is checked
            {
                MessageBox.Show("No cats have been checked. Please check at least one cat.", "No Cats", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Continue = false;
            }
            else
            {
                vaccinationdates = new string[6];
                for (int i = 1; i <= 6; i++)
                {
                    if (Continue == true) //Checks validation of the vaccination dates
                    {
                        switch (i)
                        {
                            case 1:
                                if (datetimepicker_vaccinationupdate1_addnewbooking.Visible == true)
                                {
                                    vaccinationdates[0] = datetimepicker_vaccinationupdate1_addnewbooking.Value.ToString("yyyy-MM-dd");
                                    if (DateTime.Today > datetimepicker_vaccinationupdate1_addnewbooking.Value)
                                    {
                                        if (MessageBox.Show("The vaccination date for the first cat is in the past. Would you like to continue?", "Invalid Next Vaccination Date", MessageBoxButtons.YesNo) == DialogResult.No)
                                        {
                                            Continue = false;
                                        }
                                    }
                                }
                                break;
                            case 2:
                                if (datetimepicker_vaccinationupdate2_addnewbooking.Visible == true)
                                {
                                    vaccinationdates[1] = datetimepicker_vaccinationupdate2_addnewbooking.Value.ToString("yyyy-MM-dd");
                                    if (DateTime.Today > datetimepicker_vaccinationupdate2_addnewbooking.Value)
                                    {
                                        if (MessageBox.Show("The vaccination date for the second cat is in the past. Would you like to continue?", "Invalid Next Vaccination Date", MessageBoxButtons.YesNo) == DialogResult.No)
                                        {
                                            Continue = false;
                                        }
                                    }
                                }
                                break;
                            case 3:
                                if (datetimepicker_vaccinationupdate3_addnewbooking.Visible == true)
                                {
                                    vaccinationdates[2] = datetimepicker_vaccinationupdate3_addnewbooking.Value.ToString("yyyy-MM-dd");
                                    if (DateTime.Today > datetimepicker_vaccinationupdate3_addnewbooking.Value)
                                    {
                                        if (MessageBox.Show("The vaccination date for the third cat is in the past. Would you like to continue?", "Invalid Next Vaccination Date", MessageBoxButtons.YesNo) == DialogResult.No)
                                        {
                                            Continue = false;
                                        }
                                    }
                                }
                                break;
                            case 4:
                                if (datetimepicker_vaccinationupdate4_addnewbooking.Visible == true)
                                {
                                    vaccinationdates[3] = datetimepicker_vaccinationupdate4_addnewbooking.Value.ToString("yyyy-MM-dd");
                                    if (DateTime.Today > datetimepicker_vaccinationupdate4_addnewbooking.Value)
                                    {
                                        if (MessageBox.Show("The vaccination date for the fourth cat is in the past. Would you like to continue?", "Invalid Next Vaccination Date", MessageBoxButtons.YesNo) == DialogResult.No)
                                        {
                                            Continue = false;
                                        }
                                    }
                                }
                                break;
                            case 5:
                                if (datetimepicker_vaccinationupdate5_addnewbooking.Visible == true)
                                {
                                    vaccinationdates[4] = datetimepicker_vaccinationupdate5_addnewbooking.Value.ToString("yyyy-MM-dd");
                                    if (DateTime.Today > datetimepicker_vaccinationupdate5_addnewbooking.Value)
                                    {
                                        if (MessageBox.Show("The vaccination date for the fifth cat is in the past. Would you like to continue?", "Invalid Next Vaccination Date", MessageBoxButtons.YesNo) == DialogResult.No)
                                        {
                                            Continue = false;
                                        }
                                    }
                                }
                                break;
                            case 6:
                                if (datetimepicker_vaccinationupdate6_addnewbooking.Visible == true)
                                {
                                    vaccinationdates[5] = datetimepicker_vaccinationupdate6_addnewbooking.Value.ToString("yyyy-MM-dd");
                                    if (DateTime.Today > datetimepicker_vaccinationupdate6_addnewbooking.Value)
                                    {
                                        if (MessageBox.Show("The vaccination date for the sixth cat is in the past. Would you like to continue?", "Invalid Next Vaccination Date", MessageBoxButtons.YesNo) == DialogResult.No)
                                        {
                                            Continue = false;
                                        }
                                    }
                                }
                                break;
                        }
                    }
                }
                if (Continue == true) //Checks validation of the arrival and departure dates
                {
                    if (DateTime.Today > datetimepicker_arrivaldate_addnewbooking.Value)
                    {
                        if (MessageBox.Show("The Arrival date is in the past. Would you like to continue?", "Invalid Date", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            Continue = false;
                        }
                    }
                }
                if (Continue == true)
                {
                    if (DateTime.Today > datetimepicker_departuredate_addnewbooking.Value)
                    {
                        if (MessageBox.Show("The Departure date is in the past. Would you like to continue?", "Invalid Date", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            Continue = false;
                        }
                    }
                }
                if (Continue == true)
                {
                    if (datetimepicker_departuredate_addnewbooking.Value < datetimepicker_arrivaldate_addnewbooking.Value)
                    {
                        if (MessageBox.Show("The Departure date is set before the Arrival date. The values are to be swapped.", "Invalid Dates", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            DateTime Arrival = datetimepicker_departuredate_addnewbooking.Value;
                            DateTime Departure = datetimepicker_arrivaldate_addnewbooking.Value;
                            datetimepicker_arrivaldate_addnewbooking.Value = Arrival;
                            datetimepicker_departuredate_addnewbooking.Value = Departure;
                        }
                        else
                        {
                            Continue = false;
                        }
                    }
                }
            }
            if (Continue == true)
            {
                if (datetimepicker_arrivaldate_addnewbooking.Value == datetimepicker_departuredate_addnewbooking.Value)
                {
                    if (MessageBox.Show("The arrival and departure dates are the same. Would you like to continue?", "Equal Arrival and Departure dates", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        Continue = false;
                    }
                }
            }
            if (Continue == true) //Checks whether the registration has any future bookings
            {
                bookingcount = new string[0, 0];
                int bookingtotal = 0;
                MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Registration ID` = '" + MyGlobalClass.registration_booking + "'", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                while (MyGlobalClass.SQL_Alter_Database.Read())
                {
                    if (DateTime.Today < DateTime.Parse(MyGlobalClass.SQL_Alter_Database["Arrival Date"].ToString()) && MyGlobalClass.SQL_Alter_Database["Booking ID"].ToString() != MyGlobalClass.booking_addnewbooking[0])
                    {
                        bookingtotal++;
                    }
                }
                MyGlobalClass.new_connection.Close();

                if (bookingtotal > 0)
                {
                    bookingcount = new string[bookingtotal, 3];
                    bookingtotal = 0;

                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Registration ID` = '" + MyGlobalClass.registration_booking + "'", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        if (DateTime.Today < DateTime.Parse(MyGlobalClass.SQL_Alter_Database["Arrival Date"].ToString()) && MyGlobalClass.SQL_Alter_Database["Booking ID"].ToString() != MyGlobalClass.booking_addnewbooking[0])
                        {
                            bookingcount[bookingtotal, 0] = MyGlobalClass.SQL_Alter_Database["Booking ID"].ToString();
                            bookingcount[bookingtotal, 1] = MyGlobalClass.SQL_Alter_Database["Arrival Date"].ToString();
                            bookingcount[bookingtotal, 2] = MyGlobalClass.SQL_Alter_Database["Chalet"].ToString();
                            bookingtotal++;
                        }
                    }
                    MyGlobalClass.new_connection.Close();

                    if (bookingcount.GetLength(0) > 1)
                    { //If more that one future booking, ask if the user wishes to view the bookings.
                        DialogResult messagebox = MessageBox.Show("There are " + bookingcount.GetLength(0) + " future bookings for this registration. Do you wish to view the bookings?", "Future Bookings", MessageBoxButtons.YesNoCancel);
                        if (messagebox == DialogResult.Yes)
                        {// If yes, the future bookings are shown in the search results list box in the booking system.
                            var newform = new form_bookingsystem();
                            MyGlobalClass.futurebookings = new string[bookingcount.GetLength(0), 4];
                            for (int booking = 0; booking < bookingcount.GetLength(0); booking++)
                            {
                                MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Booking ID` = '" + bookingcount[booking, 0] + "';", MyGlobalClass.new_connection);
                                MyGlobalClass.new_connection.Open();
                                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                while (MyGlobalClass.SQL_Alter_Database.Read())
                                {
                                    MyGlobalClass.futurebookings[booking, 0] = "" + DateTime.Parse(MyGlobalClass.SQL_Alter_Database["Arrival Date"].ToString()).ToString("dd/MM/yyyy") + " - " + DateTime.Parse(MyGlobalClass.SQL_Alter_Database["Departure Date"].ToString()).ToString("dd/MM/yyyy") + " ";
                                    MySqlConnection new_connection = new MySqlConnection(MyGlobalClass.connection_to_database);
                                    MySqlCommand SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = '" + MyGlobalClass.SQL_Alter_Database["Registration ID"].ToString() + "';", new_connection);
                                    new_connection.Open();
                                    MySqlDataReader SQL_Alter_Database = SQL_Command.ExecuteReader();
                                    while (SQL_Alter_Database.Read())
                                    {
                                        int i = 1;
                                        bool end = false;
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
                                                        MyGlobalClass.futurebookings[booking, 0] = MyGlobalClass.futurebookings[booking, 0] + readownername["Contact Name"].ToString();
                                                    }
                                                    else if (i > 1)
                                                    {
                                                        MyGlobalClass.futurebookings[booking, 0] = MyGlobalClass.futurebookings[booking, 0] + ", " + readownername["Contact Name"].ToString() + "";
                                                    }
                                                }
                                                ownername.Close();
                                            }
                                            else
                                            {
                                                if (i > 1)
                                                {
                                                    MyGlobalClass.futurebookings[booking, 0] = MyGlobalClass.futurebookings[booking, 0] + " ";
                                                    end = true;
                                                }
                                            }
                                            i++;
                                        } while (i <= 6 && end == false);
                                        if (end == false)
                                        {
                                            MyGlobalClass.futurebookings[booking, 0] = MyGlobalClass.futurebookings[booking, 0] + " ";
                                        }
                                    }
                                    int n = 1;
                                    for (int i = 1; i <= 6; i++)
                                    {
                                        if (MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString() != "NULL")
                                        {
                                            if (n == 1)
                                            {
                                                MyGlobalClass.futurebookings[booking, 0] = MyGlobalClass.futurebookings[booking, 0] + MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString();
                                            }
                                            else
                                            {
                                                MyGlobalClass.futurebookings[booking, 0] = MyGlobalClass.futurebookings[booking, 0] + ", " + MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString() + "";
                                            }
                                            n++;
                                        }
                                    }
                                    MyGlobalClass.futurebookings[booking, 0] = MyGlobalClass.futurebookings[booking, 0] + ")";
                                    MyGlobalClass.futurebookings[booking, 1] = MyGlobalClass.SQL_Alter_Database["Arrival Date"].ToString();
                                    MyGlobalClass.futurebookings[booking, 2] = MyGlobalClass.SQL_Alter_Database["Chalet"].ToString();
                                    MyGlobalClass.futurebookings[booking, 3] = MyGlobalClass.SQL_Alter_Database["Booking ID"].ToString();
                                }
                                MyGlobalClass.new_connection.Close();
                            }
                            MyGlobalClass.OpenForm(newform);
                        }
                        else if (messagebox == DialogResult.Cancel)
                        {
                            Continue = false;
                        }
                    }
                    else if (bookingcount.GetLength(0) == 1) //If only one future booking, ask if the user wishes to view the booking.
                    {
                        DialogResult messagebox = MessageBox.Show("There is a future booking for this registration. Do you wish to view the booking?", "Future Booking", MessageBoxButtons.YesNoCancel);
                        if (messagebox == DialogResult.Yes)
                        {// If yes, simply show the booking in the booking system.
                            var newform = new form_bookingsystem();
                            MyGlobalClass.updatechaletnumber(false, MyGlobalClass.totalchalets, true);
                            MyGlobalClass.shownchaletbookings = new bool[MyGlobalClass.totalchalets];
                            for (int i = 0; i < MyGlobalClass.totalchalets; i++)
                            {
                                if (i == (int.Parse(bookingcount[0, 2]) - 1))
                                {
                                    MyGlobalClass.shownchaletbookings[i] = true;
                                }
                                else
                                {
                                    MyGlobalClass.shownchaletbookings[i] = false;
                                }
                            }
                            MyGlobalClass.bookingsystemdate = DateTime.Parse(bookingcount[0, 1]);
                            MyGlobalClass.updatebookingsystemdatetimepickers = true;
                            MyGlobalClass.OpenForm(newform);
                        }
                        else if (messagebox == DialogResult.Cancel)
                        {
                            Continue = false;
                        }
                    }
                }
            }
            #endregion
            #region settingupthebooking
            if (Continue == true)
            { //Inserts all information into an array which will be used later for inserting the booking data
                booking[0] = selectedregistration; //Inserts the registration used for the booking
                for (int i = 0; i < 6; i++) //Inserts the cats staying or "NULL" if the cat is not staying (or if there is no more cats)
                {
                    if (i < checkedlistbox_catsstaying_addnewbooking.Items.Count)
                    {
                        if (checkedlistbox_catsstaying_addnewbooking.GetItemChecked(i) == true)
                        {
                            booking[i + 1] = checkedlistbox_catsstaying_addnewbooking.Items[i].ToString();
                        }
                        else
                        {
                            booking[i + 1] = "NULL";
                        }
                    }
                    else
                    {
                        booking[i + 1] = "NULL";
                    }
                }
                booking[7] = datetimepicker_arrivaldate_addnewbooking.Value.ToString("yyyy-MM-dd"); //Inserts the arrival and departure dates
                booking[8] = datetimepicker_departuredate_addnewbooking.Value.ToString("yyyy-MM-dd");

                MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`arrival/departure times` WHERE `Arrival/Departure Time` = '" + combobox_arrivaltime_addnewbooking.Text + "';", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                records = 0;
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                while (MyGlobalClass.SQL_Alter_Database.Read())
                {
                    booking[9] = MyGlobalClass.SQL_Alter_Database["Arrival/Departure Time ID"].ToString(); //Finds the id for AM/PM/_ for inserting the arrival and departure time
                    records++;
                }
                MyGlobalClass.new_connection.Close();
                if (records == 0)
                {
                    MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`arrival/departure times` (`Arrival/Departure Time`) VALUES ('" + combobox_arrivaltime_addnewbooking.Text + "'); SELECT * FROM `chichester_cattery_booking_system`.`arrival/departure times` WHERE `Arrival/Departure Time ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        booking[9] = MyGlobalClass.SQL_Alter_Database["Arrival/Departure Time ID"].ToString();
                    }
                    MyGlobalClass.new_connection.Close();
                }
                else if (records > 1)
                {
                    MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`arrival/departure times` WHERE `Arrival/Departure Time` = '" + combobox_departuretime_addnewbooking.Text + "';", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                records = 0;
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                while (MyGlobalClass.SQL_Alter_Database.Read())
                {
                    booking[10] = MyGlobalClass.SQL_Alter_Database["Arrival/Departure Time ID"].ToString();
                    records++;
                }
                MyGlobalClass.new_connection.Close();
                if (records == 0)
                {
                    MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`arrival/departure times` (`Arrival/Departure Time`) VALUES ('" + combobox_departuretime_addnewbooking.Text + "'); SELECT * FROM `chichester_cattery_booking_system`.`arrival/departure times` WHERE `Arrival/Departure Time ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        booking[10] = MyGlobalClass.SQL_Alter_Database["Arrival/Departure Time ID"].ToString();
                    }
                    MyGlobalClass.new_connection.Close();
                }
                else if (records > 1)
                {
                    MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                if (MyGlobalClass.booking_addnewbooking[0] != "" && (bool.Parse(checkedin) == true || bool.Parse(checkedout) == true))
                {
                    if (MessageBox.Show("Do you wish to reset the 'Check In/Out' Status'?", "Reset?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        booking[11] = "0";
                        booking[12] = "0";
                    }
                    else
                    {
                        booking[11] = Convert.ToInt32(bool.Parse(checkedin)).ToString();
                        booking[12] = Convert.ToInt32(bool.Parse(checkedout)).ToString();
                    }
                }
                else
                {
                    booking[11] = "0";
                    booking[12] = "0";
                }

                for (int i = 0; i < 6; i++)
                {
                    if (vaccinationdates[i] != "" && booking[i + 1] != "NULL")
                    {
                        if (DateTime.Parse(vaccinationdates[i]) >= DateTime.Parse(booking[7]) && DateTime.Parse(vaccinationdates[i]) <= DateTime.Parse(booking[8]))
                        {
                            booking[i + 14] = "0";
                        }
                        else
                        {
                            booking[i + 14] = "1";
                        }
                    }
                    else
                    {
                        booking[i + 14] = "1";
                    }
                }
            #endregion
                Continue = MyGlobalClass.updatechaletnumber(false, MyGlobalClass.totalchalets, true); //Checks the total number of chalets. If no chalets, the code doesn't continue.
            }

            if (Continue == true)
            {
                this.SuspendLayout();
                if (MyGlobalClass.booking_addnewbooking[0] != "") //If altering a booking, the booking is deleted from it's chalet so the chalet can be used when looking at it's efficiency
                {
                    for (DateTime date = DateTime.Parse(MyGlobalClass.booking_addnewbooking[1]); date <= DateTime.Parse(MyGlobalClass.booking_addnewbooking[2]); date = date.AddDays(1))
                    {
                        MyGlobalClass.SQL_Command = new MySqlCommand("DELETE FROM `chichester_cattery_booking_system`.`" + MyGlobalClass.booking_addnewbooking[3] + "` WHERE `Date`='" + date.ToString("yyyy-MM-dd") + "';", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        MyGlobalClass.new_connection.Close();
                        MyGlobalClass.booking_deleted = true; //Indicates that the booking has been deleted
                    }
                }

                availablechalets = new string[MyGlobalClass.totalchalets, 4]; //Initial array for the available bookings
                int freechalets = 0;
                int minimum = 0;
                for (int i = 1; i <= 6; i++)
                {
                    if (booking[i] != "NULL") //Counts up the number of cats staying
                    {
                        minimum++;
                    }
                }
                for (int chaletnumber = 1; chaletnumber <= MyGlobalClass.totalchalets; chaletnumber++)
                {
                    bool freechalet = true;
                    DateTime date = DateTime.Parse(booking[7]);
                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`chalets` WHERE `Chalet` = '" + chaletnumber + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        if (int.Parse(MyGlobalClass.SQL_Alter_Database["Maximum Number of Cats"].ToString()) < minimum) //Checks if chalet can hold the number of cats staying
                        {
                            freechalet = false;
                        }
                    }
                    MyGlobalClass.new_connection.Close();
                    while (freechalet == true && date <= DateTime.Parse(booking[8]))
                    { //Checks each chalet on all days of the new booking. As soon as it hits an existing booking, it stops looking
                        MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`" + chaletnumber + "` WHERE `Date` = '" + date.ToString("yyyy-MM-dd") + "';", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        records = 0;
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        while (MyGlobalClass.SQL_Alter_Database.Read())
                        {
                            freechalet = false;
                            records++;
                        }
                        MyGlobalClass.new_connection.Close();
                        if (records > 1)
                        {
                            MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Continue = false;
                        }
                        date = date.AddDays(1);
                    }
                    if (freechalet == true)//If the chalet is available, the chalet is added to the available chalet array and a counter is used to count the number of free chalets for the sorted array
                    {
                        freechalets++;
                        availablechalets[freechalets - 1, 0] = chaletnumber.ToString();
                    }
                }
                freechaletssorted = new string[freechalets, 4]; //The array for the sorted chalets
                for (int arraypointer = 0; arraypointer < freechalets; arraypointer++) //The gaps on each side of the new booking is found for each available chalet
                {
                    int dayssincedeparture = MyGlobalClass.countdayssincedeparture(DateTime.Parse(booking[7]), availablechalets[arraypointer, 0]);
                    availablechalets[arraypointer, 1] = dayssincedeparture.ToString();
                    int daystoarrival = MyGlobalClass.countdaystoarrival(DateTime.Parse(booking[8]), availablechalets[arraypointer, 0]);
                    availablechalets[arraypointer, 2] = daystoarrival.ToString();
                    int sum = dayssincedeparture + daystoarrival;
                    if (sum == 2 && dayssincedeparture != 1) //If 2 and 0, sum is set as 2.5 to distinguish the different 2s as it is better than 3 but worse that 0 - 2
                    {
                        availablechalets[arraypointer, 3] = "2.5";
                    }
                    else
                    {
                        availablechalets[arraypointer, 3] = sum.ToString();
                    }
                }
                for (int unsorted = 0; unsorted < freechalets; unsorted++)
                {
                    bool inserted = false;
                    for (int sorted = 0; sorted < freechalets && inserted == false; sorted++)
                    {
                        if (freechaletssorted[sorted, 3] == null) //If the sorted item is empty, insert the unsorted item
                        {
                            freechaletssorted[sorted, 0] = availablechalets[unsorted, 0];
                            freechaletssorted[sorted, 1] = availablechalets[unsorted, 1];
                            freechaletssorted[sorted, 2] = availablechalets[unsorted, 2];
                            freechaletssorted[sorted, 3] = availablechalets[unsorted, 3];
                            inserted = true;
                        }
                        else
                        {
                            double unsortedvalue = double.Parse(availablechalets[unsorted, 3]); //Gets the two comparable values
                            double sortedvalue = double.Parse(freechaletssorted[sorted, 3]);
                            if (unsortedvalue == 2 && availablechalets[unsorted, 1] == "1" && sortedvalue != 2)
                            {//Inserts the chalet where the new booking is sandwiched, first and below any other potential sandwiching
                                for (int move = freechalets - 2; move >= 0; move = move - 1)
                                {
                                    freechaletssorted[move + 1, 0] = freechaletssorted[move, 0];
                                    freechaletssorted[move + 1, 1] = freechaletssorted[move, 1];
                                    freechaletssorted[move + 1, 2] = freechaletssorted[move, 2];
                                    freechaletssorted[move + 1, 3] = freechaletssorted[move, 3];
                                }
                                freechaletssorted[sorted, 0] = availablechalets[unsorted, 0];
                                freechaletssorted[sorted, 1] = availablechalets[unsorted, 1];
                                freechaletssorted[sorted, 2] = availablechalets[unsorted, 2];
                                freechaletssorted[sorted, 3] = availablechalets[unsorted, 3];
                                inserted = true;
                            }
                            else if (unsortedvalue == 1 && sortedvalue != 1 && sortedvalue != 2)
                            {//Inserts the chalet where the new booking has a gap bigger than the margin, on one side, after any potential sandwiching or similar chalet conditions
                                for (int move = freechalets - 2; move >= sorted; move = move - 1)
                                {
                                    freechaletssorted[move + 1, 0] = freechaletssorted[move, 0];
                                    freechaletssorted[move + 1, 1] = freechaletssorted[move, 1];
                                    freechaletssorted[move + 1, 2] = freechaletssorted[move, 2];
                                    freechaletssorted[move + 1, 3] = freechaletssorted[move, 3];
                                }
                                freechaletssorted[sorted, 0] = availablechalets[unsorted, 0];
                                freechaletssorted[sorted, 1] = availablechalets[unsorted, 1];
                                freechaletssorted[sorted, 2] = availablechalets[unsorted, 2];
                                freechaletssorted[sorted, 3] = availablechalets[unsorted, 3];
                                inserted = true;
                            }
                            else if (unsortedvalue < sortedvalue && sortedvalue != 2 && sortedvalue != 1)
                            {//Inserts the other conditions in numeric order following the two special conditions
                                for (int move = freechalets - 2; move >= sorted; move = move - 1)
                                {
                                    freechaletssorted[move + 1, 0] = freechaletssorted[move, 0];
                                    freechaletssorted[move + 1, 1] = freechaletssorted[move, 1];
                                    freechaletssorted[move + 1, 2] = freechaletssorted[move, 2];
                                    freechaletssorted[move + 1, 3] = freechaletssorted[move, 3];
                                }
                                freechaletssorted[sorted, 0] = availablechalets[unsorted, 0];
                                freechaletssorted[sorted, 1] = availablechalets[unsorted, 1];
                                freechaletssorted[sorted, 2] = availablechalets[unsorted, 2];
                                freechaletssorted[sorted, 3] = availablechalets[unsorted, 3];
                                inserted = true;
                            }
                        }
                    }
                }
                splitcontainer_datetimeandchalet_addnewbooking.Panel2Collapsed = false; //Expand the right panel
                splitcontainer_datetimeandchalet_addnewbooking.Panel1.Enabled = false;
                listbox_potentialchalets_addnewbooking.Items.Clear();
                for (int i = 0; i < freechaletssorted.GetLength(0); i++)
                { //Adds the chalets to the list box with the required chalet type preceeding the chalet number and the level of recommendation succeeding the chalet number
                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`chalets` WHERE `Chalet` = '" + freechaletssorted[i, 0] + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        string chalettype = "";
                        if (MyGlobalClass.SQL_Alter_Database["Maximum Number of Cats"].ToString() == "2")
                        {
                            chalettype = "Chalet";
                        }
                        else if (MyGlobalClass.SQL_Alter_Database["Maximum Number of Cats"].ToString() == "4")
                        {
                            chalettype = "Family Chalet";
                        }
                        else if (MyGlobalClass.SQL_Alter_Database["Maximum Number of Cats"].ToString() == "6")
                        {
                            chalettype = "Large Family Chalet";
                        }
                        if (double.Parse(freechaletssorted[i, 3]) == 2 && double.Parse(freechaletssorted[i, 1]) == 1)
                        {
                            listbox_potentialchalets_addnewbooking.Items.Add("" + chalettype + " " + freechaletssorted[i, 0] + " (Perfect fit between two other chalets)");
                        }
                        else if (double.Parse(freechaletssorted[i, 3]) < 2)
                        {
                            listbox_potentialchalets_addnewbooking.Items.Add("" + chalettype + " " + freechaletssorted[i, 0] + " (Recommended)");
                        }
                        else
                        {
                            listbox_potentialchalets_addnewbooking.Items.Add("" + chalettype + " " + freechaletssorted[i, 0] + "");
                        }
                    }
                    MyGlobalClass.new_connection.Close();
                }
                MyGlobalClass.updatelistboxwidth(listbox_potentialchalets_addnewbooking, 0, listbox_potentialchalets_addnewbooking.Width); //Update the width of the list box
                this.ResumeLayout();
                this.PerformLayout();
            }
        }

        private void button_editbooking_addnewbooking_Click(object sender, EventArgs e)
        {
            booking[13] = "";
            listbox_potentialchalets_addnewbooking.SelectedIndex = -1;
            button_viewchaletbookings_addnewbooking.Enabled = false;
            button_confirmchalet_addnewbooking.Enabled = false;
            splitcontainer_datetimeandchalet_addnewbooking.Panel2Collapsed = true;
            splitcontainer_datetimeandchalet_addnewbooking.Panel1.Enabled = true;
            bool registrationvalid = false;
            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = '" + MyGlobalClass.registration_booking + "';", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read() && registrationvalid == false)
            {
                registrationvalid = true;
            }
            MyGlobalClass.new_connection.Close();
            if (registrationvalid == false)
            {
                MyGlobalClass.registration_booking = "";
            }
            if (MyGlobalClass.registration_booking != "" && MyGlobalClass.registration_booking != selectedregistration)
            {
                selectedregistration = MyGlobalClass.registration_booking;
                splitcontainer_ownerandcat_addnewbooking.Panel1Collapsed = true;
                text_ownerconfirmationdetails_addnewbooking.Text = MyGlobalClass.retrieveregistrationdata(selectedregistration, true);
                checkedlistbox_catsstaying_addnewbooking.Items.Clear();
                for (int i = 0; i < MyGlobalClass.selectedregistrationcats.GetLength(0); i = i + 2)
                {
                    if (MyGlobalClass.selectedregistrationcats[0, i] != "" && MyGlobalClass.selectedregistrationcats[0, i] != null)
                    {
                        checkedlistbox_catsstaying_addnewbooking.Items.Add(MyGlobalClass.selectedregistrationcats[0, i]);
                    }
                }

                for (int i = 0; i < checkedlistbox_catsstaying_addnewbooking.Items.Count; i++)
                {
                    checkedlistbox_catsstaying_addnewbooking.SetItemCheckState(i, CheckState.Checked);
                    if (vaccinationdates[i] != "")
                    {
                        switch (i)
                        {
                            case 0:
                                text_cat1_addnewbooking.Visible = true;
                                text_cat1_addnewbooking.Enabled = true;
                                if (DateTime.Parse(vaccinationdates[i]) < DateTime.Today)
                                {
                                    text_cat1_addnewbooking.Text = "" + MyGlobalClass.selectedregistrationcats[0, (2 * i)] + " (Out of Date)";
                                }
                                else
                                {
                                    text_cat1_addnewbooking.Text = MyGlobalClass.selectedregistrationcats[0, (2 * i)];
                                }
                                datetimepicker_vaccinationupdate1_addnewbooking.Enabled = true;
                                datetimepicker_vaccinationupdate1_addnewbooking.Visible = true;
                                datetimepicker_vaccinationupdate1_addnewbooking.Value = DateTime.Parse(vaccinationdates[i]);
                                break;
                            case 1:
                                text_cat2_addnewbooking.Visible = true;
                                text_cat2_addnewbooking.Enabled = true;
                                if (DateTime.Parse(vaccinationdates[i]) < DateTime.Today)
                                {
                                    text_cat2_addnewbooking.Text = "" + MyGlobalClass.selectedregistrationcats[0, (2 * i)] + " (Out of Date)";
                                }
                                else
                                {
                                    text_cat2_addnewbooking.Text = MyGlobalClass.selectedregistrationcats[0, (2 * i)];
                                }
                                datetimepicker_vaccinationupdate2_addnewbooking.Enabled = true;
                                datetimepicker_vaccinationupdate2_addnewbooking.Visible = true;
                                datetimepicker_vaccinationupdate2_addnewbooking.Value = DateTime.Parse(vaccinationdates[i]);
                                break;
                            case 2:
                                text_cat3_addnewbooking.Visible = true;
                                text_cat3_addnewbooking.Enabled = true;
                                if (DateTime.Parse(vaccinationdates[i]) < DateTime.Today)
                                {
                                    text_cat3_addnewbooking.Text = "" + MyGlobalClass.selectedregistrationcats[0, (2 * i)] + " (Out of Date)";
                                }
                                else
                                {
                                    text_cat3_addnewbooking.Text = MyGlobalClass.selectedregistrationcats[0, (2 * i)];
                                }
                                datetimepicker_vaccinationupdate3_addnewbooking.Enabled = true;
                                datetimepicker_vaccinationupdate3_addnewbooking.Visible = true;
                                datetimepicker_vaccinationupdate3_addnewbooking.Value = DateTime.Parse(vaccinationdates[i]);
                                break;
                            case 3:
                                text_cat4_addnewbooking.Visible = true;
                                text_cat4_addnewbooking.Enabled = true;
                                if (DateTime.Parse(vaccinationdates[i]) < DateTime.Today)
                                {
                                    text_cat4_addnewbooking.Text = "" + MyGlobalClass.selectedregistrationcats[0, (2 * i)] + " (Out of Date)";
                                }
                                else
                                {
                                    text_cat4_addnewbooking.Text = MyGlobalClass.selectedregistrationcats[0, (2 * i)];
                                }
                                datetimepicker_vaccinationupdate4_addnewbooking.Enabled = true;
                                datetimepicker_vaccinationupdate4_addnewbooking.Visible = true;
                                datetimepicker_vaccinationupdate4_addnewbooking.Value = DateTime.Parse(vaccinationdates[i]);
                                break;
                            case 4:
                                text_cat5_addnewbooking.Visible = true;
                                text_cat5_addnewbooking.Enabled = true;
                                if (DateTime.Parse(vaccinationdates[i]) < DateTime.Today)
                                {
                                    text_cat5_addnewbooking.Text = "" + MyGlobalClass.selectedregistrationcats[0, (2 * i)] + " (Out of Date)";
                                }
                                else
                                {
                                    text_cat5_addnewbooking.Text = MyGlobalClass.selectedregistrationcats[0, (2 * i)];
                                }
                                datetimepicker_vaccinationupdate5_addnewbooking.Enabled = true;
                                datetimepicker_vaccinationupdate5_addnewbooking.Visible = true;
                                datetimepicker_vaccinationupdate5_addnewbooking.Value = DateTime.Parse(vaccinationdates[i]);
                                break;
                            case 5:
                                text_cat6_addnewbooking.Visible = true;
                                text_cat6_addnewbooking.Enabled = true;
                                if (DateTime.Parse(vaccinationdates[i]) < DateTime.Today)
                                {
                                    text_cat6_addnewbooking.Text = "" + MyGlobalClass.selectedregistrationcats[0, (2 * i)] + " (Out of Date)";
                                }
                                else
                                {
                                    text_cat6_addnewbooking.Text = MyGlobalClass.selectedregistrationcats[0, (2 * i)];
                                }
                                datetimepicker_vaccinationupdate6_addnewbooking.Enabled = true;
                                datetimepicker_vaccinationupdate6_addnewbooking.Visible = true;
                                datetimepicker_vaccinationupdate6_addnewbooking.Value = DateTime.Parse(vaccinationdates[i]);
                                break;
                        }
                    }
                    else
                    {
                        switch (i)
                        {
                            case 0:
                                text_cat1_addnewbooking.Visible = false;
                                text_cat1_addnewbooking.Enabled = false;
                                datetimepicker_vaccinationupdate1_addnewbooking.Enabled = false;
                                datetimepicker_vaccinationupdate1_addnewbooking.Visible = false;
                                break;
                            case 1:
                                text_cat2_addnewbooking.Visible = false;
                                text_cat2_addnewbooking.Enabled = false;
                                datetimepicker_vaccinationupdate2_addnewbooking.Enabled = false;
                                datetimepicker_vaccinationupdate2_addnewbooking.Visible = false;
                                break;
                            case 2:
                                text_cat3_addnewbooking.Visible = false;
                                text_cat3_addnewbooking.Enabled = false;
                                datetimepicker_vaccinationupdate3_addnewbooking.Enabled = false;
                                datetimepicker_vaccinationupdate3_addnewbooking.Visible = false;
                                break;
                            case 3:
                                text_cat4_addnewbooking.Visible = false;
                                text_cat4_addnewbooking.Enabled = false;
                                datetimepicker_vaccinationupdate4_addnewbooking.Enabled = false;
                                datetimepicker_vaccinationupdate4_addnewbooking.Visible = false;
                                break;
                            case 4:
                                text_cat5_addnewbooking.Visible = false;
                                text_cat5_addnewbooking.Enabled = false;
                                datetimepicker_vaccinationupdate5_addnewbooking.Enabled = false;
                                datetimepicker_vaccinationupdate5_addnewbooking.Visible = false;
                                break;
                            case 5:
                                text_cat6_addnewbooking.Visible = false;
                                text_cat6_addnewbooking.Enabled = false;
                                datetimepicker_vaccinationupdate6_addnewbooking.Enabled = false;
                                datetimepicker_vaccinationupdate6_addnewbooking.Visible = false;
                                break;
                        }
                    }
                }
            }
        }

        private void datetimepicker_vaccinationupdate1_addnewbooking_ValueChanged(object sender, EventArgs e)
        {
            if (datetimepicker_vaccinationupdate1_addnewbooking.Value < DateTime.Today)
            {
                text_cat1_addnewbooking.Text = "" + MyGlobalClass.selectedregistrationcats[0, 0] + " (Out of Date)";
            }
            else
            {
                text_cat1_addnewbooking.Text = MyGlobalClass.selectedregistrationcats[0, 0];
            }
        }

        private void datetimepicker_vaccinationupdate2_addnewbooking_ValueChanged(object sender, EventArgs e)
        {
            if (datetimepicker_vaccinationupdate2_addnewbooking.Value < DateTime.Today)
            {
                text_cat2_addnewbooking.Text = "" + MyGlobalClass.selectedregistrationcats[0, 2] + " (Out of Date)";
            }
            else
            {
                text_cat2_addnewbooking.Text = MyGlobalClass.selectedregistrationcats[0, 2];
            }
        }

        private void datetimepicker_vaccinationupdate3_addnewbooking_ValueChanged(object sender, EventArgs e)
        {
            if (datetimepicker_vaccinationupdate3_addnewbooking.Value < DateTime.Today)
            {
                text_cat3_addnewbooking.Text = "" + MyGlobalClass.selectedregistrationcats[0, 4] + " (Out of Date)";
            }
            else
            {
                text_cat3_addnewbooking.Text = MyGlobalClass.selectedregistrationcats[0, 4];
            }
        }

        private void datetimepicker_vaccinationupdate4_addnewbooking_ValueChanged(object sender, EventArgs e)
        {
            if (datetimepicker_vaccinationupdate4_addnewbooking.Value < DateTime.Today)
            {
                text_cat4_addnewbooking.Text = "" + MyGlobalClass.selectedregistrationcats[0, 6] + " (Out of Date)";
            }
            else
            {
                text_cat4_addnewbooking.Text = MyGlobalClass.selectedregistrationcats[0, 6];
            }
        }

        private void datetimepicker_vaccinationupdate5_addnewbooking_ValueChanged(object sender, EventArgs e)
        {
            if (datetimepicker_vaccinationupdate5_addnewbooking.Value < DateTime.Today)
            {
                text_cat5_addnewbooking.Text = "" + MyGlobalClass.selectedregistrationcats[0, 8] + " (Out of Date)";
            }
            else
            {
                text_cat5_addnewbooking.Text = MyGlobalClass.selectedregistrationcats[0, 8];
            }
        }

        private void datetimepicker_vaccinationupdate6_addnewbooking_ValueChanged(object sender, EventArgs e)
        {
            if (datetimepicker_vaccinationupdate6_addnewbooking.Value < DateTime.Today)
            {
                text_cat6_addnewbooking.Text = "" + MyGlobalClass.selectedregistrationcats[0, 10] + " (Out of Date)";
            }
            else
            {
                text_cat6_addnewbooking.Text = MyGlobalClass.selectedregistrationcats[0, 10];
            }
        }

        private void listbox_potentialchalets_addnewbooking_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbox_potentialchalets_addnewbooking.SelectedIndex > -1)
            {
                if (freechaletssorted[listbox_potentialchalets_addnewbooking.SelectedIndex, 0] == booking[13])
                {
                    booking[13] = "";
                    listbox_potentialchalets_addnewbooking.SelectedIndex = -1;
                    button_viewchaletbookings_addnewbooking.Enabled = false;
                    button_confirmchalet_addnewbooking.Enabled = false;
                }
                else
                {
                    booking[13] = freechaletssorted[listbox_potentialchalets_addnewbooking.SelectedIndex, 0];
                    button_viewchaletbookings_addnewbooking.Enabled = true;
                    button_confirmchalet_addnewbooking.Enabled = true;
                }
            }
        }

        private void button_confirmchalet_addnewbooking_Click(object sender, EventArgs e)
        {
            string bookingid = "";
            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = '" + booking[0] + "';", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read()) //Update the vaccination dates on the database if it has been changed
            {
                for (int i = 0; i < 6; i++)
                {
                    if (vaccinationdates[i] != null)
                    {
                        if (DateTime.Parse(vaccinationdates[i]) != DateTime.Parse(MyGlobalClass.selectedregistrationcats[3, 2 * i]))
                        {
                            MySqlConnection vaccinationdateconnection = new MySqlConnection(MyGlobalClass.connection_to_database);
                            MySqlCommand vaccinationdate = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`cats` SET `Next Vaccination Date`='" + vaccinationdates[i] + "' WHERE `Cat ID`='" + MyGlobalClass.SQL_Alter_Database["Cat " + (i + 1) + " ID"] + "';", vaccinationdateconnection);
                            vaccinationdateconnection.Open();
                            MySqlDataReader vaccinationdateupdate = vaccinationdate.ExecuteReader();
                            vaccinationdateconnection.Close();
                        }
                    }
                }
            }
            MyGlobalClass.new_connection.Close();
            if (MyGlobalClass.booking_addnewbooking[0] != "")
            { //Deletes the booking from the booking database if editing a booking
                MyGlobalClass.removebookingdata(MyGlobalClass.booking_addnewbooking[0]);
                MyGlobalClass.booking_deleted = false; //Indicates that a booking has been deleted but is about to be added as a new, altered booking
                MyGlobalClass.booking_addnewbooking = new string[4] { "", "", "", "" };
            }

            MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`bookings` (`Registration ID`, `Cat 1 Staying`, `Cat 2 Staying`, `Cat 3 Staying`, `Cat 4 Staying`, `Cat 5 Staying`, `Cat 6 Staying`, `Arrival Date`, `Departure Date`, `Arrival Time ID`, `Departure Time ID`, `Checked In`, `Checked Out`, `Chalet`, `Cat 1 Vaccination`, `Cat 2 Vaccination`, `Cat 3 Vaccination`, `Cat 4 Vaccination`, `Cat 5 Vaccination`, `Cat 6 Vaccination`) VALUES ('" + booking[0] + "', '" + booking[1] + "', '" + booking[2] + "', '" + booking[3] + "', '" + booking[4] + "', '" + booking[5] + "', '" + booking[6] + "', '" + booking[7] + "', '" + booking[8] + "', '" + booking[9] + "', '" + booking[10] + "', '" + booking[11] + "', '" + booking[12] + "', '" + booking[13] + "', '" + booking[14] + "', '" + booking[15] + "', '" + booking[16] + "', '" + booking[17] + "', '" + booking[18] + "', '" + booking[19] + "'); SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Booking ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open(); //Inserts the new booking into the database
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                bookingid = MyGlobalClass.SQL_Alter_Database["Booking ID"].ToString();
            }
            MyGlobalClass.new_connection.Close();
            for (DateTime date = DateTime.Parse(booking[7]); date <= DateTime.Parse(booking[8]); date = date.AddDays(1))
            { //Inserts the booking into the database
                MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`" + booking[13] + "` (`Date`, `Booking ID`) VALUES ('" + date.ToString("yyyy-MM-dd") + "', '" + bookingid + "');", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                MyGlobalClass.new_connection.Close();
            }

            MyGlobalClass.potentialrearranging(DateTime.Parse(booking[7]), DateTime.Parse(booking[8]), booking[13]); //Checks for potential rearrangings

            var newform = new form_bookingsystem();
            MyGlobalClass.navigation = true;

            MyGlobalClass.updatechaletnumber(false, MyGlobalClass.totalchalets, true);
            MyGlobalClass.shownchaletbookings = new bool[MyGlobalClass.totalchalets];
            for (int i = 0; i < MyGlobalClass.totalchalets; i++) //Sets up the booking system for showing the new booking
            {
                if (i == (int.Parse(booking[13]) - 1))
                {
                    MyGlobalClass.shownchaletbookings[i] = true;
                }
                else
                {
                    MyGlobalClass.shownchaletbookings[i] = false;
                }
            }
            MyGlobalClass.bookingsystemdate = DateTime.Parse(booking[7]);
            MyGlobalClass.updatebookingsystemdatetimepickers = true;

            MyGlobalClass.CloseForm(newform, this);
            MyGlobalClass.navigation = false;
        }

        private void button_viewchaletbookings_addnewbooking_Click(object sender, EventArgs e)
        {
            var newform = new form_bookingsystem();

            MyGlobalClass.updatechaletnumber(false, MyGlobalClass.totalchalets, true);
            MyGlobalClass.shownchaletbookings = new bool[MyGlobalClass.totalchalets];
            for (int i = 0; i < MyGlobalClass.totalchalets; i++)
            {
                if (i == (int.Parse(booking[13]) - 1))
                {
                    MyGlobalClass.shownchaletbookings[i] = true;
                }
                else
                {
                    MyGlobalClass.shownchaletbookings[i] = false;
                }
            }
            MyGlobalClass.bookingsystemdate = DateTime.Parse(booking[7]);
            MyGlobalClass.updatebookingsystemdatetimepickers = true;

            MyGlobalClass.OpenForm(newform);
        }

        private void form_addnewbooking_Activated(object sender, EventArgs e)
        {
            bool registrationvalid = false;
            if (MyGlobalClass.updateaddnewbooking == true)
            {
                if (MyGlobalClass.booking_edit == false)
                {
                    combobox_arrivaltime_addnewbooking.SelectedIndex = -1;
                    combobox_arrivaltime_addnewbooking.Text = "";
                    combobox_departuretime_addnewbooking.SelectedIndex = -1;
                    combobox_departuretime_addnewbooking.Text = "";
                    button_cancelnewbooking_addnewbooking.Text = "Cancel New Booking";
                    button_confirmbooking_addnewbooking.Text = "Confirm New Booking";
                    MyGlobalClass.booking_addnewbooking = new string[4] { "", "", "", "" };
                    editregistration = "";
                    datetimepicker_arrivaldate_addnewbooking.Value = DateTime.Today;
                    datetimepicker_departuredate_addnewbooking.Value = DateTime.Today;
                }
                MyGlobalClass.maintainselected[1] = false;

                if (MyGlobalClass.booking_edit == true)
                {
                    string arrivaltime = "";
                    string departuretime = "";
                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Booking ID` = '" + MyGlobalClass.booking_addnewbooking[0] + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        MyGlobalClass.booking_addnewbooking[3] = MyGlobalClass.SQL_Alter_Database["Chalet"].ToString();
                        MyGlobalClass.booking_addnewbooking[1] = MyGlobalClass.SQL_Alter_Database["Arrival Date"].ToString();
                        MyGlobalClass.booking_addnewbooking[2] = MyGlobalClass.SQL_Alter_Database["Departure Date"].ToString();
                        arrivaltime = MyGlobalClass.SQL_Alter_Database["Arrival Time ID"].ToString();
                        departuretime = MyGlobalClass.SQL_Alter_Database["Departure Time ID"].ToString();
                        MyGlobalClass.registration_booking = MyGlobalClass.SQL_Alter_Database["Registration ID"].ToString();
                        editregistration = MyGlobalClass.SQL_Alter_Database["Registration ID"].ToString();
                        datetimepicker_arrivaldate_addnewbooking.Value = DateTime.Parse(MyGlobalClass.booking_addnewbooking[1]);
                        datetimepicker_departuredate_addnewbooking.Value = DateTime.Parse(MyGlobalClass.booking_addnewbooking[2]);
                        checkedin = MyGlobalClass.SQL_Alter_Database["Checked In"].ToString();
                        checkedout = MyGlobalClass.SQL_Alter_Database["Checked Out"].ToString();
                    }
                    MyGlobalClass.new_connection.Close();

                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`arrival/departure times` WHERE `Arrival/Departure Time ID` = '" + arrivaltime + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        combobox_arrivaltime_addnewbooking.Text = MyGlobalClass.SQL_Alter_Database["Arrival/Departure Time"].ToString();
                    }
                    MyGlobalClass.new_connection.Close();

                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`arrival/departure times` WHERE `Arrival/Departure Time ID` = '" + departuretime + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        combobox_departuretime_addnewbooking.Text = MyGlobalClass.SQL_Alter_Database["Arrival/Departure Time"].ToString();
                    }
                    MyGlobalClass.new_connection.Close();
                    button_cancelnewbooking_addnewbooking.Text = "Cancel Booking Edit";
                    button_confirmbooking_addnewbooking.Text = "Confirm Booking Edit";
                }
                MyGlobalClass.updateaddnewbooking = false;
            }

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = '" + MyGlobalClass.registration_booking + "';", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Close();
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read() && registrationvalid == false)
            {
                registrationvalid = true;
            }
            MyGlobalClass.new_connection.Close();
            if (registrationvalid == false)
            {
                MyGlobalClass.registration_booking = "";
            }
            if (MyGlobalClass.registration_booking != "" && MyGlobalClass.registration_booking != selectedregistration)
            {
                selectedregistration = MyGlobalClass.registration_booking;
                splitcontainer_ownerandcat_addnewbooking.Panel1Collapsed = true;
                MyGlobalClass.selectedregistration = new string[21, 2]; //The arrays used for storing cats and registration data are now cleared
                MyGlobalClass.selectedregistrationcats = new string[9, 12];
                text_ownerconfirmationdetails_addnewbooking.Text = MyGlobalClass.retrieveregistrationdata(selectedregistration, true);
                checkedlistbox_catsstaying_addnewbooking.Items.Clear();
                for (int i = 0; i < MyGlobalClass.selectedregistrationcats.GetLength(1); i = i + 2)
                {
                    if (MyGlobalClass.selectedregistrationcats[0, i] != "" && MyGlobalClass.selectedregistrationcats[0, i] != null)
                    {
                        checkedlistbox_catsstaying_addnewbooking.Items.Add(MyGlobalClass.selectedregistrationcats[0, i]);
                    }
                    if (MyGlobalClass.selectedregistrationcats[3, i] != "" && MyGlobalClass.selectedregistrationcats[3, i] != null)
                    {
                        switch (i)
                        {
                            case 0:
                                datetimepicker_vaccinationupdate1_addnewbooking.Value = DateTime.Parse(MyGlobalClass.selectedregistrationcats[3, i]);
                                datetimepicker_vaccinationupdate1_addnewbooking.Enabled = true;
                                datetimepicker_vaccinationupdate1_addnewbooking.Visible = true;
                                text_cat1_addnewbooking.Visible = true;
                                text_cat1_addnewbooking.Enabled = true;
                                if (DateTime.Parse(MyGlobalClass.selectedregistrationcats[3, i]) < DateTime.Today)
                                {
                                    text_cat1_addnewbooking.Text = "" + MyGlobalClass.selectedregistrationcats[0, i] + " (Out of Date)";
                                }
                                else
                                {
                                    text_cat1_addnewbooking.Text = MyGlobalClass.selectedregistrationcats[0, i];
                                }
                                break;
                            case 2:
                                datetimepicker_vaccinationupdate2_addnewbooking.Value = DateTime.Parse(MyGlobalClass.selectedregistrationcats[3, i]);
                                datetimepicker_vaccinationupdate2_addnewbooking.Enabled = true;
                                datetimepicker_vaccinationupdate2_addnewbooking.Visible = true;
                                text_cat2_addnewbooking.Visible = true;
                                text_cat2_addnewbooking.Enabled = true;
                                if (DateTime.Parse(MyGlobalClass.selectedregistrationcats[3, i]) < DateTime.Today)
                                {
                                    text_cat2_addnewbooking.Text = "" + MyGlobalClass.selectedregistrationcats[0, i] + " (Out of Date)";
                                }
                                else
                                {
                                    text_cat2_addnewbooking.Text = MyGlobalClass.selectedregistrationcats[0, i];
                                }
                                break;
                            case 4:
                                datetimepicker_vaccinationupdate3_addnewbooking.Value = DateTime.Parse(MyGlobalClass.selectedregistrationcats[3, i]);
                                datetimepicker_vaccinationupdate3_addnewbooking.Enabled = true;
                                datetimepicker_vaccinationupdate3_addnewbooking.Visible = true;
                                text_cat3_addnewbooking.Visible = true;
                                text_cat3_addnewbooking.Enabled = true;
                                if (DateTime.Parse(MyGlobalClass.selectedregistrationcats[3, i]) < DateTime.Today)
                                {
                                    text_cat3_addnewbooking.Text = "" + MyGlobalClass.selectedregistrationcats[0, i] + " (Out of Date)";
                                }
                                else
                                {
                                    text_cat3_addnewbooking.Text = MyGlobalClass.selectedregistrationcats[0, i];
                                }
                                break;
                            case 6:
                                datetimepicker_vaccinationupdate4_addnewbooking.Value = DateTime.Parse(MyGlobalClass.selectedregistrationcats[3, i]);
                                datetimepicker_vaccinationupdate4_addnewbooking.Enabled = true;
                                datetimepicker_vaccinationupdate4_addnewbooking.Visible = true;
                                text_cat4_addnewbooking.Visible = true;
                                text_cat4_addnewbooking.Enabled = true;
                                if (DateTime.Parse(MyGlobalClass.selectedregistrationcats[3, i]) < DateTime.Today)
                                {
                                    text_cat4_addnewbooking.Text = "" + MyGlobalClass.selectedregistrationcats[0, i] + " (Out of Date)";
                                }
                                else
                                {
                                    text_cat4_addnewbooking.Text = MyGlobalClass.selectedregistrationcats[0, i];
                                }
                                break;
                            case 8:
                                datetimepicker_vaccinationupdate5_addnewbooking.Value = DateTime.Parse(MyGlobalClass.selectedregistrationcats[3, i]);
                                datetimepicker_vaccinationupdate5_addnewbooking.Enabled = true;
                                datetimepicker_vaccinationupdate5_addnewbooking.Visible = true;
                                text_cat5_addnewbooking.Visible = true;
                                text_cat5_addnewbooking.Enabled = true;
                                if (DateTime.Parse(MyGlobalClass.selectedregistrationcats[3, i]) < DateTime.Today)
                                {
                                    text_cat5_addnewbooking.Text = "" + MyGlobalClass.selectedregistrationcats[0, i] + " (Out of Date)";
                                }
                                else
                                {
                                    text_cat5_addnewbooking.Text = MyGlobalClass.selectedregistrationcats[0, i];
                                }
                                break;
                            case 10:
                                datetimepicker_vaccinationupdate6_addnewbooking.Value = DateTime.Parse(MyGlobalClass.selectedregistrationcats[3, i]);
                                datetimepicker_vaccinationupdate6_addnewbooking.Enabled = true;
                                datetimepicker_vaccinationupdate6_addnewbooking.Visible = true;
                                text_cat6_addnewbooking.Visible = true;
                                text_cat6_addnewbooking.Enabled = true;
                                if (DateTime.Parse(MyGlobalClass.selectedregistrationcats[3, i]) < DateTime.Today)
                                {
                                    text_cat6_addnewbooking.Text = "" + MyGlobalClass.selectedregistrationcats[0, i] + " (Out of Date)";
                                }
                                else
                                {
                                    text_cat6_addnewbooking.Text = MyGlobalClass.selectedregistrationcats[0, i];
                                }
                                break;
                        }
                    }
                    else
                    {
                        switch (i)
                        {
                            case 0:
                                text_cat1_addnewbooking.Visible = false;
                                text_cat1_addnewbooking.Enabled = false;
                                datetimepicker_vaccinationupdate1_addnewbooking.Enabled = false;
                                datetimepicker_vaccinationupdate1_addnewbooking.Visible = false;
                                break;
                            case 2:
                                text_cat2_addnewbooking.Visible = false;
                                text_cat2_addnewbooking.Enabled = false;
                                datetimepicker_vaccinationupdate2_addnewbooking.Enabled = false;
                                datetimepicker_vaccinationupdate2_addnewbooking.Visible = false;
                                break;
                            case 4:
                                text_cat3_addnewbooking.Visible = false;
                                text_cat3_addnewbooking.Enabled = false;
                                datetimepicker_vaccinationupdate3_addnewbooking.Enabled = false;
                                datetimepicker_vaccinationupdate3_addnewbooking.Visible = false;
                                break;
                            case 6:
                                text_cat4_addnewbooking.Visible = false;
                                text_cat4_addnewbooking.Enabled = false;
                                datetimepicker_vaccinationupdate4_addnewbooking.Enabled = false;
                                datetimepicker_vaccinationupdate4_addnewbooking.Visible = false;
                                break;
                            case 8:
                                text_cat5_addnewbooking.Visible = false;
                                text_cat5_addnewbooking.Enabled = false;
                                datetimepicker_vaccinationupdate5_addnewbooking.Enabled = false;
                                datetimepicker_vaccinationupdate5_addnewbooking.Visible = false;
                                break;
                            case 10:
                                text_cat6_addnewbooking.Visible = false;
                                text_cat6_addnewbooking.Enabled = false;
                                datetimepicker_vaccinationupdate6_addnewbooking.Enabled = false;
                                datetimepicker_vaccinationupdate6_addnewbooking.Visible = false;
                                break;
                        }
                    }
                }

                for (int i = 0; i < checkedlistbox_catsstaying_addnewbooking.Items.Count; i++)
                {
                    if (MyGlobalClass.booking_edit == true)
                    {
                        MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Booking ID` = '" + MyGlobalClass.booking_addnewbooking[0] + "';", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        bool match = false;
                        while (MyGlobalClass.SQL_Alter_Database.Read())
                        {
                            for (int cat = 1; cat <= 6 && match == false; cat++)
                            {
                                if (MyGlobalClass.SQL_Alter_Database["Cat " + cat + " Staying"].ToString() == checkedlistbox_catsstaying_addnewbooking.Items[i].ToString())
                                {
                                    match = true;
                                }
                            }
                        }
                        MyGlobalClass.new_connection.Close();

                        if (match == true)
                        {
                            checkedlistbox_catsstaying_addnewbooking.SetItemCheckState(i, CheckState.Checked);
                        }
                        else
                        {
                            checkedlistbox_catsstaying_addnewbooking.SetItemCheckState(i, CheckState.Unchecked);
                        }
                    }
                    else
                    {
                        checkedlistbox_catsstaying_addnewbooking.SetItemCheckState(i, CheckState.Checked);
                    }
                }
            }
            else if (MyGlobalClass.registration_booking != selectedregistration)
            {
                splitcontainer_ownerandcat_addnewbooking.Panel1Collapsed = true;
                splitcontainer_datetimeandchalet_addnewbooking.Panel2Collapsed = true;
                text_ownerconfirmationdetails_addnewbooking.Text = "";
                checkedlistbox_catsstaying_addnewbooking.Items.Clear();
                text_cat1_addnewbooking.Visible = false;
                text_cat1_addnewbooking.Enabled = false;
                datetimepicker_vaccinationupdate1_addnewbooking.Enabled = false;
                datetimepicker_vaccinationupdate1_addnewbooking.Visible = false;
                text_cat2_addnewbooking.Visible = false;
                text_cat2_addnewbooking.Enabled = false;
                datetimepicker_vaccinationupdate2_addnewbooking.Enabled = false;
                datetimepicker_vaccinationupdate2_addnewbooking.Visible = false;
                text_cat3_addnewbooking.Visible = false;
                text_cat3_addnewbooking.Enabled = false;
                datetimepicker_vaccinationupdate3_addnewbooking.Enabled = false;
                datetimepicker_vaccinationupdate3_addnewbooking.Visible = false;
                text_cat4_addnewbooking.Visible = false;
                text_cat4_addnewbooking.Enabled = false;
                datetimepicker_vaccinationupdate4_addnewbooking.Enabled = false;
                datetimepicker_vaccinationupdate4_addnewbooking.Visible = false;
                text_cat5_addnewbooking.Visible = false;
                text_cat5_addnewbooking.Enabled = false;
                datetimepicker_vaccinationupdate5_addnewbooking.Enabled = false;
                datetimepicker_vaccinationupdate5_addnewbooking.Visible = false;
                text_cat6_addnewbooking.Visible = false;
                text_cat6_addnewbooking.Enabled = false;
                datetimepicker_vaccinationupdate6_addnewbooking.Enabled = false;
                datetimepicker_vaccinationupdate6_addnewbooking.Visible = false;
            }
            MyGlobalClass.booking_edit = false;
        }

        private void text_ownersearch_addnewbooking_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_searchowner_addnewbooking_Click(sender, new EventArgs());
            }
        }

        private void text_bookingquery_addnewbooking_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_searchbookings_addnewbooking_Click(sender, new EventArgs());
            }
        }

        private void text_registrationquery_addnewbooking_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_searchregistrations_addnewbooking_Click(sender, new EventArgs());
            }
        }

        private void text_ownersearch_addnewbooking_Enter(object sender, EventArgs e)
        {
            button_searchowner_addnewbooking.Font = new Font(Font.FontFamily, button_searchowner_addnewbooking.Font.Size, FontStyle.Bold);
        }

        private void text_ownersearch_addnewbooking_Leave(object sender, EventArgs e)
        {
            button_searchowner_addnewbooking.Font = new Font(Font.FontFamily, button_searchowner_addnewbooking.Font.Size, FontStyle.Regular);
        }

        private void text_bookingquery_addnewbooking_Enter(object sender, EventArgs e)
        {
            button_searchbookings_addnewbooking.Font = new Font(Font.FontFamily, button_searchbookings_addnewbooking.Font.Size, FontStyle.Bold);
        }

        private void text_bookingquery_addnewbooking_Leave(object sender, EventArgs e)
        {
            button_searchbookings_addnewbooking.Font = new Font(Font.FontFamily, button_searchbookings_addnewbooking.Font.Size, FontStyle.Regular);
        }

        private void text_registrationquery_addnewbooking_Enter(object sender, EventArgs e)
        {
            button_searchregistrations_addnewbooking.Font = new Font(Font.FontFamily, button_searchregistrations_addnewbooking.Font.Size, FontStyle.Bold);
        }

        private void text_registrationquery_addnewbooking_Leave(object sender, EventArgs e)
        {
            button_searchregistrations_addnewbooking.Font = new Font(Font.FontFamily, button_searchregistrations_addnewbooking.Font.Size, FontStyle.Regular);
        }
    }
}
