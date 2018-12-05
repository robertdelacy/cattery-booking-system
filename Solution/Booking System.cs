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
    public partial class form_bookingsystem : Form
    {
        bool dateupdate = false;
        string selectedbooking = "";
        string selectedregistration = "";
        string deletedregistration = "";
        int defaultfontsize = 15;

        public form_bookingsystem()
        {
            this.SuspendLayout();

            InitializeComponent();

            datetimepicker_bookingdate1_bookingsystem.Value = MyGlobalClass.bookingsystemdate;
            dateupdate = true;

            update_bookingcalender();


            Rectangle resolution = Screen.PrimaryScreen.Bounds;

            double WidthScale = (double)resolution.Width / (double)this.Width;
            double HeightScale = (double)resolution.Height / (double)this.Height;

            if (WidthScale < HeightScale)
            {
                defaultfontsize = (int)(WidthScale * defaultfontsize);
            }
            else
            {
                defaultfontsize = (int)(HeightScale * defaultfontsize);
            }

            this.Width = (int)(this.Width * WidthScale);
            this.Height = (int)(this.Height * HeightScale);

            MyGlobalClass.ScaleParent(HeightScale, WidthScale, this);

            int TableLayoutPanelWidth = resolution.Width - 15;
            panel_bookingcalender_bookingsystem.Width = TableLayoutPanelWidth;

            foreach (RowStyle Height in this.tablelayoutpanel_bookingcalender_bookingsystem.RowStyles)
            {
                Height.SizeType = SizeType.Absolute;
                double NewHeight = (double)tablelayoutpanel_bookingcalender_bookingsystem.Height / (double)MyGlobalClass.totalchalets;
                Height.Height = (float)NewHeight;
            }
            foreach (RowStyle Height in this.tableLayoutPanel_datetimepickers_bookinsystem.RowStyles)
            {
                Height.SizeType = SizeType.Absolute;
                Height.Height = (float)tableLayoutPanel_datetimepickers_bookinsystem.Height;
            }
            foreach (ColumnStyle Width in this.tableLayoutPanel_datetimepickers_bookinsystem.ColumnStyles)
            {
                Width.SizeType = SizeType.Absolute;
                double NewWidth = (double)(resolution.Width - 30) / 8;
                Width.Width = (float)NewWidth;
            }
            foreach (ColumnStyle Width in this.tablelayoutpanel_bookingcalender_bookingsystem.ColumnStyles)
            {
                Width.SizeType = SizeType.Absolute;
                double NewWidth = (double)(resolution.Width - 30) / 8;
                Width.Width = (float)NewWidth;
            }

            this.ResumeLayout();
            this.PerformLayout();
        }

        public void update_bookingcalender()
        {
            tablelayoutpanel_bookingcalender_bookingsystem.Hide();
            tablelayoutpanel_bookingcalender_bookingsystem.SuspendLayout();
            MyGlobalClass.updatechaletnumber(false, MyGlobalClass.totalchalets, true);
            int difference = MyGlobalClass.totalchalets - tablelayoutpanel_bookingcalender_bookingsystem.RowStyles.Count;
            if (difference >= 0)
            {
                dateupdate = true;
                for (int i = 0; i < difference; i++)
                {
                    tablelayoutpanel_bookingcalender_bookingsystem.RowStyles.Add(new RowStyle(SizeType.Absolute, 65));
                }
                for (int column = 0; column < 8; column++)
                {
                    Control Ctrl = tablelayoutpanel_bookingcalender_bookingsystem.GetControlFromPosition(column, tablelayoutpanel_bookingcalender_bookingsystem.RowStyles.Count - (difference + 1));
                    if (Ctrl != null)
                    {
                        tablelayoutpanel_bookingcalender_bookingsystem.Controls.Remove(Ctrl);
                        Ctrl.Dispose();
                    }
                }
                for (int row = tablelayoutpanel_bookingcalender_bookingsystem.RowStyles.Count - (difference + 1); row < tablelayoutpanel_bookingcalender_bookingsystem.RowStyles.Count; row++)
                {
                    Label label;
                    label = new Label();
                    label.AutoSize = true;
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`chalets` WHERE `Chalet` = '" + (row + 1) + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        if (MyGlobalClass.SQL_Alter_Database["Maximum Number of Cats"].ToString() == "2")
                        {
                            label.Text = "Chalet " + (row + 1) + "";
                        }
                        else if (MyGlobalClass.SQL_Alter_Database["Maximum Number of Cats"].ToString() == "4")
                        {
                            label.Text = "Family Chalet " + (row + 1) + "";
                        }
                        else if (MyGlobalClass.SQL_Alter_Database["Maximum Number of Cats"].ToString() == "6")
                        {
                            label.Text = "Large Family Chalet " + (row + 1) + "";
                        }
                    }
                    MyGlobalClass.new_connection.Close();
                    label.Font = new Font(Font.FontFamily.Name, defaultfontsize);
                    tablelayoutpanel_bookingcalender_bookingsystem.Controls.Add(label, 0, row);
                    label.Anchor = AnchorStyles.None;
                    label.Name = "label_chalet" + row + "_bookingsystem";

                    for (int column = 1; column <= 7; column++)
                    {
                        label = new Label();
                        label.AutoSize = true;
                        label.TextAlign = ContentAlignment.MiddleCenter;
                        label.Font = new Font(Font.FontFamily.Name, defaultfontsize);
                        tablelayoutpanel_bookingcalender_bookingsystem.Controls.Add(label, column, row);
                        label.Anchor = AnchorStyles.None;
                        label.Click += new EventHandler(show_booking_information);
                        label.Name = "text_ownercatcalender_" + column + "_" + row + "_bookingsystem";
                    }
                }
            }
            else if (difference < 0)
            {
                update_tablelayoutpanel_bookingcalender_bookingsystem();
                dateupdate = true;
            }

            if (dateupdate == true)
            {
                dateupdate = false;
                for (int row = 0; row < tablelayoutpanel_bookingcalender_bookingsystem.RowStyles.Count; row++)
                {
                    for (int column = 1; column < 8; column++)
                    {
                        DateTimePicker datetimepicker = (DateTimePicker)tableLayoutPanel_datetimepickers_bookinsystem.GetControlFromPosition(column, 0);
                        string columndate = datetimepicker.Value.ToString("yyyy-MM-dd");
                        string text = "";
                        MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`" + (row + 1) + "` WHERE `Date` = '" + columndate + "';", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        while (MyGlobalClass.SQL_Alter_Database.Read())
                        {
                            MySqlConnection checkdate = new MySqlConnection(MyGlobalClass.connection_to_database);
                            MySqlCommand findregistration = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Booking ID` = '" + MyGlobalClass.SQL_Alter_Database["Booking ID"].ToString() + "';", checkdate);
                            checkdate.Open();
                            MySqlDataReader checkdatereader = findregistration.ExecuteReader();
                            while (checkdatereader.Read())
                            {
                                if (DateTime.Parse(checkdatereader["Arrival Date"].ToString()) == DateTime.Parse(columndate) || DateTime.Parse(checkdatereader["Departure Date"].ToString()) == DateTime.Parse(columndate))
                                {
                                    MySqlConnection new_connection = new MySqlConnection(MyGlobalClass.connection_to_database);
                                    MySqlCommand SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = '" + checkdatereader["Registration ID"].ToString() + "';", new_connection);
                                    new_connection.Open();
                                    MySqlDataReader SQL_Alter_Database = SQL_Command.ExecuteReader();
                                    int i = 1;
                                    int n = 1;
                                    bool end = false;
                                    while (SQL_Alter_Database.Read())
                                    {
                                        text = "";
                                        end = false;
                                        i = 1;
                                        do
                                        {
                                            if (checkdatereader["Cat " + i + " Staying"].ToString() != "NULL")
                                            {
                                                if (n > 1)
                                                {
                                                    text = text + ", " + checkdatereader["Cat " + i + " Staying"].ToString() + "";
                                                }
                                                else if (n == 1)
                                                {
                                                    text = checkdatereader["Cat " + i + " Staying"].ToString();
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
                                }
                                else
                                {
                                    text = "----------------------------------------------------";
                                }
                            }
                            checkdate.Close();
                        }
                        MyGlobalClass.new_connection.Close();
                        Label label = (Label)tablelayoutpanel_bookingcalender_bookingsystem.GetControlFromPosition(column, row);
                        label.Text = text;
                    }
                }
            }

            if (MyGlobalClass.shownchaletbookings.GetLength(0) == 0)
            {
                for (int i = 0; i < tablelayoutpanel_bookingcalender_bookingsystem.RowStyles.Count; i++)
                {
                    tablelayoutpanel_bookingcalender_bookingsystem.RowStyles[i].Height = 65;
                }
            }
            else
            {
                if (MyGlobalClass.shownchaletbookings.GetLength(0) != MyGlobalClass.totalchalets)
                {
                    int extrachalets = MyGlobalClass.totalchalets - MyGlobalClass.shownchaletbookings.GetLength(0);
                    Array.Resize<bool>(ref MyGlobalClass.shownchaletbookings, MyGlobalClass.shownchaletbookings.GetLength(0) + extrachalets);
                    if (MyGlobalClass.shownchaletbookings.GetLength(0) < MyGlobalClass.totalchalets)
                    {
                        for (int i = MyGlobalClass.shownchaletbookings.GetLength(0); i < MyGlobalClass.totalchalets; i++)
                        {
                            MyGlobalClass.shownchaletbookings[i] = true;
                        }
                    }
                }
                for (int i = 0; i < tablelayoutpanel_bookingcalender_bookingsystem.RowStyles.Count; i++)
                {
                    if (MyGlobalClass.shownchaletbookings[i] == false)
                    {
                        tablelayoutpanel_bookingcalender_bookingsystem.RowStyles[i].Height = 0;
                    }
                    else
                    {
                        tablelayoutpanel_bookingcalender_bookingsystem.RowStyles[i].Height = 65;
                    }
                }
            }

            if (MyGlobalClass.updatebookingsystemdatetimepickers == true)
            {
                MyGlobalClass.updatebookingsystemdatetimepickers = false;
                datetimepicker_bookingdate1_bookingsystem.Value = MyGlobalClass.bookingsystemdate;
            }

            tablelayoutpanel_bookingcalender_bookingsystem.ResumeLayout();
            this.PerformLayout();
            tablelayoutpanel_bookingcalender_bookingsystem.Show();
        }

        private void update_tablelayoutpanel_bookingcalender_bookingsystem()
        {
            this.tablelayoutpanel_bookingcalender_bookingsystem.SuspendLayout();
            this.tablelayoutpanel_bookingcalender_bookingsystem = new System.Windows.Forms.TableLayoutPanel();
            this.panel_bookingcalender_bookingsystem.Controls.Add(this.tablelayoutpanel_bookingcalender_bookingsystem);
            this.tablelayoutpanel_bookingcalender_bookingsystem.AutoSize = true;
            this.tablelayoutpanel_bookingcalender_bookingsystem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tablelayoutpanel_bookingcalender_bookingsystem.ColumnCount = 8;
            this.tablelayoutpanel_bookingcalender_bookingsystem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tablelayoutpanel_bookingcalender_bookingsystem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tablelayoutpanel_bookingcalender_bookingsystem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tablelayoutpanel_bookingcalender_bookingsystem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tablelayoutpanel_bookingcalender_bookingsystem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tablelayoutpanel_bookingcalender_bookingsystem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tablelayoutpanel_bookingcalender_bookingsystem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tablelayoutpanel_bookingcalender_bookingsystem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tablelayoutpanel_bookingcalender_bookingsystem.Location = new System.Drawing.Point(0, 0);
            this.tablelayoutpanel_bookingcalender_bookingsystem.Name = "tablelayoutpanel_bookingcalender_bookingsystem";
            this.tablelayoutpanel_bookingcalender_bookingsystem.RowCount = 1;
            this.tablelayoutpanel_bookingcalender_bookingsystem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tablelayoutpanel_bookingcalender_bookingsystem.Size = new System.Drawing.Size(1336, 68);
            this.tablelayoutpanel_bookingcalender_bookingsystem.TabIndex = 1;
            this.tablelayoutpanel_bookingcalender_bookingsystem.ResumeLayout(false);

            update_bookingcalender();
        }

        private void show_booking_information(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            int row = tablelayoutpanel_bookingcalender_bookingsystem.GetRow(label);
            int column = tablelayoutpanel_bookingcalender_bookingsystem.GetColumn(label);
            DateTimePicker datetimepicker = (DateTimePicker)tableLayoutPanel_datetimepickers_bookinsystem.GetControlFromPosition(column, 0);
            string columndate = datetimepicker.Value.ToString("yyyy-MM-dd");
            bool Continue = false;
            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`" + (row + 1) + "` WHERE `Date` = '" + columndate + "';", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                selectedbooking = MyGlobalClass.SQL_Alter_Database["Booking ID"].ToString();
                Continue = true;
            }
            MyGlobalClass.new_connection.Close();

            if (Continue == true)
            {
                MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Booking ID` = '" + selectedbooking + "';", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                while (MyGlobalClass.SQL_Alter_Database.Read())
                {
                    text_arrivaldateextrainfo_bookingsystem.Text = DateTime.Parse(MyGlobalClass.SQL_Alter_Database["Arrival Date"].ToString()).ToString("dd/MM/yyyy");
                    text_departuredateextrainfo_bookingsystem.Text = DateTime.Parse(MyGlobalClass.SQL_Alter_Database["Departure Date"].ToString()).ToString("dd/MM/yyyy");
                    button_undocheckinout_bookingsystem.Enabled = false;
                    if ((bool)MyGlobalClass.SQL_Alter_Database["Checked In"] == true)
                    {
                        checkbox_checkedin_bookingsystem.CheckState = CheckState.Checked;
                        button_undocheckinout_bookingsystem.Enabled = true;
                    }
                    else
                    {
                        checkbox_checkedin_bookingsystem.CheckState = CheckState.Unchecked;
                        if (DateTime.Today >= DateTime.Parse(MyGlobalClass.SQL_Alter_Database["Arrival Date"].ToString()))
                        {
                            button_checkinout_bookingsystem.Enabled = true;
                        }
                    }
                    if ((bool)MyGlobalClass.SQL_Alter_Database["Checked Out"] == true)
                    {
                        checkbox_checkedout_bookingsystem.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        checkbox_checkedout_bookingsystem.CheckState = CheckState.Unchecked;
                        if (DateTime.Today >= DateTime.Parse(MyGlobalClass.SQL_Alter_Database["Departure Date"].ToString()))
                        {
                            button_checkinout_bookingsystem.Enabled = true;
                        }
                    }
                    selectedregistration = MyGlobalClass.SQL_Alter_Database["Registration ID"].ToString();

                    listbox_selectedcats_bookingsystem.Items.Clear();
                    for (int i = 1; i <= 6; i++)
                    {
                        if (MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString() != "NULL")
                        {
                            listbox_selectedcats_bookingsystem.Items.Add(MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString());
                        }
                    }
                }
                MyGlobalClass.new_connection.Close();

                MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = '" + selectedregistration + "';", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                while (MyGlobalClass.SQL_Alter_Database.Read())
                {
                    bool end = false;
                    int i = 1;
                    listbox_selectedowners_bookingsystem.Items.Clear();
                    do
                    {
                        if (MyGlobalClass.SQL_Alter_Database["Owner " + i + " ID"].ToString() != "")
                        {
                            MySqlConnection ownername = new MySqlConnection(MyGlobalClass.connection_to_database);
                            MySqlCommand ownernamequery = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact names` WHERE `Contact Name ID` = '" + MyGlobalClass.SQL_Alter_Database["Owner " + i + " ID"].ToString() + "' ;", ownername);
                            ownername.Open();
                            MySqlDataReader readownername = ownernamequery.ExecuteReader();
                            while (readownername.Read())
                            {
                                listbox_selectedowners_bookingsystem.Items.Add(readownername["Contact Name"].ToString());
                            }
                            ownername.Close();
                        }
                        else
                        {
                            end = true;
                        }
                        i++;
                    } while (i <= 6 && end == false);
                }
                MyGlobalClass.new_connection.Close();

                splitcontainer_bookinginformation_bookingsystem.Panel1Collapsed = false;
                button_viewregistrationrecord_bookingsystem.Enabled = true;
                button_editbooking_bookingsystem.Enabled = true;
                button_exitbookinginfo_bookingsystem.Enabled = true;
                button_deletebooking_bookingsystem.Enabled = true;
            }
        }

        private void button_minimizeform_bookingsystem_Click(object sender, EventArgs e)
        {
            MyGlobalClass.MinimizeApplication();
        }

        private void button_closeform_bookingsystem_Click(object sender, EventArgs e)
        {
            MyGlobalClass.CloseApplication(this);
        }

        private void timer_bookingsystem_Tick(object sender, EventArgs e)
        {
            MyGlobalClass.CheckFormCount(button_goback_bookingsystem);
            MyGlobalClass.updatechaletnumber(false, MyGlobalClass.totalchalets, true);
            if (MyGlobalClass.totalchalets != tablelayoutpanel_bookingcalender_bookingsystem.RowStyles.Count)
            {
                update_bookingcalender();
            }

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
                button_home_bookingsystem.Text = "Home";
            }
            else
            {
                button_home_bookingsystem.Text = "Home (" + count + ")";
            }
        }

        private void button_home_bookingsystem_Click(object sender, EventArgs e)
        {
            var newform = new form_initialscreen();
            MyGlobalClass.CloseForm(newform, this);
        }

        private void button_addnewbooking_bookingsystem_Click(object sender, EventArgs e)
        {
            var newform = new form_addnewbooking();
            MyGlobalClass.previous_form_addnewbooking = new form_bookingsystem();
            MyGlobalClass.CloseForm(newform, this);
        }

        private void button_registrations_bookingsystem_Click(object sender, EventArgs e)
        {
            var newform = new form_registrationsystem();
            MyGlobalClass.CloseForm(newform, this);
        }

        private void button_searchbookings_bookingsystem_Click(object sender, EventArgs e)
        {
            MyGlobalClass.FillQuery(text_bookingquery_bookingsystem.Text, true, true, false);
            if (MyGlobalClass.bookingquery.GetLength(0) > 0)
            {
                listbox_bookingqueryresult_bookingsystem.Items.Clear();
                if (MyGlobalClass.bookingquerystring != "")
                {
                    for (int i = 0; i < MyGlobalClass.bookingquery.GetLength(0); i++)
                    {
                        if (MyGlobalClass.bookingquery[i, 0] != "")
                        {
                            listbox_bookingqueryresult_bookingsystem.Items.Add(MyGlobalClass.bookingquery[i, 0]);
                        }
                    }
                    MyGlobalClass.updatelistboxwidth(listbox_bookingqueryresult_bookingsystem, 0, 456);
                }
                splitcontainer_bookingcalender_bookingsystem.Panel2Collapsed = false;
                text_changeviewqueryresults_bookingsystem.Text = "'" + MyGlobalClass.bookingquerystring + "'";
                listbox_bookingqueryresult_bookingsystem.Visible = true;
                listbox_bookingqueryresult_bookingsystem.Enabled = true;
                button_exitsearchresults_bookingsystem.Visible = true;
                button_exitsearchresults_bookingsystem.Enabled = true;
                checkedlistbox_chaletsshown_bookingsystem.Visible = false;
                checkedlistbox_chaletsshown_bookingsystem.Enabled = false;
                button_changechaletview_bookingsystem.Visible = false;
                button_changechaletview_bookingsystem.Enabled = false;
            }
        }

        private void button_searchregistrations_bookingsystem_Click(object sender, EventArgs e)
        {
            MyGlobalClass.registrationquery = MyGlobalClass.FillQuery(text_registrationquery_bookingsystem.Text, true, false, true);
            var newform = new form_registrationsystem();
            MyGlobalClass.CloseForm(newform, this);
        }

        private void button_goback_bookingsystem_Click(object sender, EventArgs e)
        {
            MyGlobalClass.GoBack(this);
        }

        private void tablelayoutpanel_bookingcalender_bookingsystem_Paint(object sender, PaintEventArgs e)
        {

        }

        private void form_bookingsystem_Load(object sender, EventArgs e)
        {
            if (MyGlobalClass.bookingquery.GetLength(0) > 0)
            {
                listbox_bookingqueryresult_bookingsystem.Items.Clear();
                if (MyGlobalClass.bookingquerystring != "")
                {
                    for (int i = 0; i < MyGlobalClass.bookingquery.GetLength(0); i++)
                    {
                        if (MyGlobalClass.bookingquery[i, 0] != "")
                        {
                            listbox_bookingqueryresult_bookingsystem.Items.Add(MyGlobalClass.bookingquery[i, 0]);
                        }
                    }
                    MyGlobalClass.updatelistboxwidth(listbox_bookingqueryresult_bookingsystem, 0, 456);
                }
                splitcontainer_bookingcalender_bookingsystem.Panel2Collapsed = false;
                text_changeviewqueryresults_bookingsystem.Text = "'" + MyGlobalClass.bookingquerystring + "'";
                listbox_bookingqueryresult_bookingsystem.Visible = true;
                listbox_bookingqueryresult_bookingsystem.Enabled = true;
                button_exitsearchresults_bookingsystem.Visible = true;
                button_exitsearchresults_bookingsystem.Enabled = true;
                checkedlistbox_chaletsshown_bookingsystem.Visible = false;
                checkedlistbox_chaletsshown_bookingsystem.Enabled = false;
                button_changechaletview_bookingsystem.Visible = false;
                button_changechaletview_bookingsystem.Enabled = false;
            }
            if (MyGlobalClass.futurebookings.GetLength(0) > 0)
            {
                listbox_bookingqueryresult_bookingsystem.Items.Clear();
                for (int i = 0; i < MyGlobalClass.futurebookings.GetLength(0); i++)
                {
                    if (MyGlobalClass.futurebookings[i, 0] != "")
                    {
                        listbox_bookingqueryresult_bookingsystem.Items.Add(MyGlobalClass.futurebookings[i, 0]);
                    }
                }
                MyGlobalClass.updatelistboxwidth(listbox_bookingqueryresult_bookingsystem, 0, 456);
                splitcontainer_bookingcalender_bookingsystem.Panel2Collapsed = false;
                text_changeviewqueryresults_bookingsystem.Text = "Future Bookings";
                listbox_bookingqueryresult_bookingsystem.Visible = true;
                listbox_bookingqueryresult_bookingsystem.Enabled = true;
                button_exitsearchresults_bookingsystem.Visible = true;
                button_exitsearchresults_bookingsystem.Enabled = true;
                checkedlistbox_chaletsshown_bookingsystem.Visible = false;
                checkedlistbox_chaletsshown_bookingsystem.Enabled = false;
                button_changechaletview_bookingsystem.Visible = false;
                button_changechaletview_bookingsystem.Enabled = false;
            }
        }

        private void datetimepicker_bookingdate1_bookingsystem_ValueChanged(object sender, EventArgs e)
        {
            datetimepicker_bookingdate2_bookingsystem.Value = datetimepicker_bookingdate1_bookingsystem.Value.AddDays(1);
            dateupdate = true;
            update_bookingcalender();
        }

        private void datetimepicker_bookingdate2_bookingsystem_ValueChanged(object sender, EventArgs e)
        {
            if (datetimepicker_bookingdate1_bookingsystem.Value != datetimepicker_bookingdate2_bookingsystem.Value.AddDays(-1))
            {
                datetimepicker_bookingdate1_bookingsystem.Value = datetimepicker_bookingdate2_bookingsystem.Value.AddDays(-1);
            }

            datetimepicker_bookingdate3_bookingsystem.Value = datetimepicker_bookingdate2_bookingsystem.Value.AddDays(1);
        }

        private void datetimepicker_bookingdate3_bookingsystem_ValueChanged(object sender, EventArgs e)
        {
            if (datetimepicker_bookingdate1_bookingsystem.Value != datetimepicker_bookingdate3_bookingsystem.Value.AddDays(-2))
            {
                datetimepicker_bookingdate1_bookingsystem.Value = datetimepicker_bookingdate3_bookingsystem.Value.AddDays(-2);
            }

            datetimepicker_bookingdate4_bookingsystem.Value = datetimepicker_bookingdate3_bookingsystem.Value.AddDays(1);
        }

        private void datetimepicker_bookingdate4_bookingsystem_ValueChanged(object sender, EventArgs e)
        {
            if (datetimepicker_bookingdate1_bookingsystem.Value != datetimepicker_bookingdate4_bookingsystem.Value.AddDays(-3))
            {
                datetimepicker_bookingdate1_bookingsystem.Value = datetimepicker_bookingdate4_bookingsystem.Value.AddDays(-3);
            }

            datetimepicker_bookingdate5_bookingsystem.Value = datetimepicker_bookingdate4_bookingsystem.Value.AddDays(1);
        }

        private void datetimepicker_bookingdate5_bookingsystem_ValueChanged(object sender, EventArgs e)
        {
            if (datetimepicker_bookingdate1_bookingsystem.Value != datetimepicker_bookingdate5_bookingsystem.Value.AddDays(-4))
            {
                datetimepicker_bookingdate1_bookingsystem.Value = datetimepicker_bookingdate5_bookingsystem.Value.AddDays(-4);
            }

            datetimepicker_bookingdate6_bookingsystem.Value = datetimepicker_bookingdate5_bookingsystem.Value.AddDays(1);
        }

        private void datetimepicker_bookingdate6_bookingsystem_ValueChanged(object sender, EventArgs e)
        {
            if (datetimepicker_bookingdate1_bookingsystem.Value != datetimepicker_bookingdate6_bookingsystem.Value.AddDays(-5))
            {
                datetimepicker_bookingdate1_bookingsystem.Value = datetimepicker_bookingdate6_bookingsystem.Value.AddDays(-5);
            }

            datetimepicker_bookingdate7_bookingsystem.Value = datetimepicker_bookingdate6_bookingsystem.Value.AddDays(1);
        }

        private void datetimepicker_bookingdate7_bookingsystem_ValueChanged(object sender, EventArgs e)
        {
            if (datetimepicker_bookingdate1_bookingsystem.Value != datetimepicker_bookingdate7_bookingsystem.Value.AddDays(-6))
            {
                datetimepicker_bookingdate1_bookingsystem.Value = datetimepicker_bookingdate7_bookingsystem.Value.AddDays(-6);
            }
        }

        private void panel_bookingcalender_bookingsystem_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_minusoneday_bookingsystem_Click(object sender, EventArgs e)
        {
            datetimepicker_bookingdate1_bookingsystem.Value = datetimepicker_bookingdate1_bookingsystem.Value.AddDays(-1);
        }

        private void button_plusoneday_bookingsystem_Click(object sender, EventArgs e)
        {
            datetimepicker_bookingdate1_bookingsystem.Value = datetimepicker_bookingdate1_bookingsystem.Value.AddDays(1);
        }

        private void button_view_bookingsystem_Click(object sender, EventArgs e)
        {
            splitcontainer_bookingcalender_bookingsystem.Panel2Collapsed = false;
            text_changeviewqueryresults_bookingsystem.Text = "Change View";
            listbox_bookingqueryresult_bookingsystem.Visible = false;
            listbox_bookingqueryresult_bookingsystem.Enabled = false;
            button_exitsearchresults_bookingsystem.Visible = false;
            button_exitsearchresults_bookingsystem.Enabled = false;
            checkedlistbox_chaletsshown_bookingsystem.Visible = true;
            checkedlistbox_chaletsshown_bookingsystem.Enabled = true;
            button_changechaletview_bookingsystem.Visible = true;
            button_changechaletview_bookingsystem.Enabled = true;
            checkedlistbox_chaletsshown_bookingsystem.Items.Clear();
            checkedlistbox_chaletsshown_bookingsystem.Items.Add("All");
            MyGlobalClass.updatechaletnumber(false, MyGlobalClass.totalchalets, true);
            for (int i = 1; i <= MyGlobalClass.totalchalets; i++)
            {
                MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`chalets` WHERE `Chalet` = '" + i + "';", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                while (MyGlobalClass.SQL_Alter_Database.Read())
                {
                    if (MyGlobalClass.SQL_Alter_Database["Maximum Number of Cats"].ToString() == "2")
                    {
                        checkedlistbox_chaletsshown_bookingsystem.Items.Add("Chalet " + i + "");
                    }
                    else if (MyGlobalClass.SQL_Alter_Database["Maximum Number of Cats"].ToString() == "4")
                    {
                        checkedlistbox_chaletsshown_bookingsystem.Items.Add("Family Chalet " + i + "");
                    }
                    else if (MyGlobalClass.SQL_Alter_Database["Maximum Number of Cats"].ToString() == "6")
                    {
                        checkedlistbox_chaletsshown_bookingsystem.Items.Add("Large Family Chalet " + i + "");
                    }
                }
                MyGlobalClass.new_connection.Close();
            }

            if (MyGlobalClass.shownchaletbookings.GetLength(0) == 0)
            {
                for (int i = 0; i < checkedlistbox_chaletsshown_bookingsystem.Items.Count; i++)
                {
                    checkedlistbox_chaletsshown_bookingsystem.SetItemChecked(i, true);
                }
            }
            else
            {
                if (MyGlobalClass.shownchaletbookings.GetLength(0) != MyGlobalClass.totalchalets)
                {
                    int extrachalets = MyGlobalClass.totalchalets - MyGlobalClass.shownchaletbookings.GetLength(0);
                    Array.Resize<bool>(ref MyGlobalClass.shownchaletbookings, MyGlobalClass.shownchaletbookings.GetLength(0) + extrachalets);
                    if (MyGlobalClass.shownchaletbookings.GetLength(0) < MyGlobalClass.totalchalets)
                    {
                        for (int i = MyGlobalClass.shownchaletbookings.GetLength(0); i < MyGlobalClass.totalchalets; i++)
                        {
                            MyGlobalClass.shownchaletbookings[i] = true;
                        }
                    }
                }
                for (int i = 0; i < MyGlobalClass.shownchaletbookings.GetLength(0); i++)
                {
                    checkedlistbox_chaletsshown_bookingsystem.SetItemChecked((i + 1), MyGlobalClass.shownchaletbookings[i]);
                }
            }
        }

        private void checkedlistbox_chaletsshown_bookingsystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedlistbox_chaletsshown_bookingsystem.SelectedIndex == 0)
            {
                if (checkedlistbox_chaletsshown_bookingsystem.CheckedIndices.Contains(0))
                {
                    for (int i = 1; i < checkedlistbox_chaletsshown_bookingsystem.Items.Count; i++)
                    {
                        checkedlistbox_chaletsshown_bookingsystem.SetItemChecked(i, true);
                    }
                }
                else
                {
                    for (int i = 1; i < checkedlistbox_chaletsshown_bookingsystem.Items.Count; i++)
                    {
                        checkedlistbox_chaletsshown_bookingsystem.SetItemChecked(i, false);
                    }
                }
            }
            else if (checkedlistbox_chaletsshown_bookingsystem.SelectedIndex > 0)
            {
                if (checkedlistbox_chaletsshown_bookingsystem.CheckedIndices.Contains(checkedlistbox_chaletsshown_bookingsystem.SelectedIndex))
                {
                    if (checkedlistbox_chaletsshown_bookingsystem.CheckedItems.Count == (checkedlistbox_chaletsshown_bookingsystem.Items.Count - 1))
                    {
                        checkedlistbox_chaletsshown_bookingsystem.SetItemChecked(0, true);
                    }
                    else
                    {
                        checkedlistbox_chaletsshown_bookingsystem.SetItemChecked(0, false);
                    }
                }
                else
                {
                    checkedlistbox_chaletsshown_bookingsystem.SetItemChecked(0, false);
                }
            }
        }

        private void splitcontainer_bookingcalender_bookingsystem_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_changechaletview_bookingsystem_Click(object sender, EventArgs e)
        {
            MyGlobalClass.updatechaletnumber(false, MyGlobalClass.totalchalets, true);
            if (checkedlistbox_chaletsshown_bookingsystem.CheckedItems.Count == checkedlistbox_chaletsshown_bookingsystem.Items.Count)
            {
                MyGlobalClass.shownchaletbookings = new bool[0];
            }
            else
            {
                MyGlobalClass.shownchaletbookings = new bool[MyGlobalClass.totalchalets];
                for (int chalet = 1; chalet <= MyGlobalClass.totalchalets; chalet++)
                {
                    MyGlobalClass.shownchaletbookings[(chalet - 1)] = checkedlistbox_chaletsshown_bookingsystem.GetItemChecked(chalet);
                }
            }
            splitcontainer_bookingcalender_bookingsystem.Panel2Collapsed = true;
            checkedlistbox_chaletsshown_bookingsystem.Visible = false;
            checkedlistbox_chaletsshown_bookingsystem.Enabled = false;
            button_changechaletview_bookingsystem.Visible = false;
            button_changechaletview_bookingsystem.Enabled = false;
            text_changeviewqueryresults_bookingsystem.Clear();
            update_bookingcalender();
        }

        private void button_viewregistrationrecord_bookingsystem_Click(object sender, EventArgs e)
        {
            MyGlobalClass.registration_registrationsystem = selectedregistration;
            MyGlobalClass.maintainselected[1] = true;
            var newform = new form_registrationsystem();
            MyGlobalClass.OpenForm(newform);
        }

        private void button_checkinout_bookingsystem_Click(object sender, EventArgs e)
        {
            if (checkbox_checkedin_bookingsystem.CheckState == CheckState.Unchecked)
            {
                checkbox_checkedin_bookingsystem.CheckState = CheckState.Checked;
                button_undocheckinout_bookingsystem.Enabled = true;
                MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`bookings` SET `Checked In`='1' WHERE `Booking ID`='" + selectedbooking + "';", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                MyGlobalClass.new_connection.Close();
                if (DateTime.Today < DateTime.Parse(text_departuredateextrainfo_bookingsystem.Text))
                {
                    button_checkinout_bookingsystem.Enabled = false;
                }
            }
            else if (checkbox_checkedout_bookingsystem.CheckState == CheckState.Unchecked)
            {
                checkbox_checkedout_bookingsystem.CheckState = CheckState.Checked;
                button_checkinout_bookingsystem.Enabled = false;
                MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`bookings` SET `Checked Out`='1' WHERE `Booking ID`='" + selectedbooking + "';", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                MyGlobalClass.new_connection.Close();
            }
        }

        private void button_undocheckinout_bookingsystem_Click(object sender, EventArgs e)
        {
            if (checkbox_checkedout_bookingsystem.CheckState == CheckState.Checked)
            {
                checkbox_checkedout_bookingsystem.CheckState = CheckState.Unchecked;
                button_checkinout_bookingsystem.Enabled = true;
                MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`bookings` SET `Checked Out`='0' WHERE `Booking ID`='" + selectedbooking + "';", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                MyGlobalClass.new_connection.Close();
            }
            else if (checkbox_checkedin_bookingsystem.CheckState == CheckState.Checked)
            {
                checkbox_checkedin_bookingsystem.CheckState = CheckState.Unchecked;
                button_undocheckinout_bookingsystem.Enabled = false;
                button_checkinout_bookingsystem.Enabled = true;
                MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`bookings` SET `Checked In`='0' WHERE `Booking ID`='" + selectedbooking + "';", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                MyGlobalClass.new_connection.Close();
            }
        }

        private void button_editbooking_bookingsystem_Click(object sender, EventArgs e)
        {
            MyGlobalClass.booking_addnewbooking[0] = selectedbooking;
            MyGlobalClass.booking_edit = true;
            MyGlobalClass.updateaddnewbooking = true;
            var newform = new form_addnewbooking();
            MyGlobalClass.previous_form_addnewbooking = new form_bookingsystem();
            MyGlobalClass.CloseForm(newform, this);
        }

        private void button_exitbookinginfo_bookingsystem_Click(object sender, EventArgs e)
        {
            listbox_selectedcats_bookingsystem.Items.Clear();
            listbox_selectedowners_bookingsystem.Items.Clear();
            text_arrivaldateextrainfo_bookingsystem.Clear();
            text_departuredateextrainfo_bookingsystem.Clear();
            checkbox_checkedin_bookingsystem.CheckState = CheckState.Unchecked;
            checkbox_checkedout_bookingsystem.CheckState = CheckState.Unchecked;
            splitcontainer_bookinginformation_bookingsystem.Panel1Collapsed = true;
            selectedbooking = "";
        }

        private void button_deletebooking_bookingsystem_Click(object sender, EventArgs e)
        {
            deletedregistration = selectedregistration;
            if (MessageBox.Show("Are you sure you want to delete this Booking?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                MyGlobalClass.removebookingdata(selectedbooking);
                listbox_selectedcats_bookingsystem.Items.Clear();
                listbox_selectedowners_bookingsystem.Items.Clear();
                text_arrivaldateextrainfo_bookingsystem.Clear();
                text_departuredateextrainfo_bookingsystem.Clear();
                checkbox_checkedin_bookingsystem.CheckState = CheckState.Unchecked;
                checkbox_checkedout_bookingsystem.CheckState = CheckState.Unchecked;
                splitcontainer_bookinginformation_bookingsystem.Panel1Collapsed = true;
            }

            dateupdate = true;
            form_bookingsystem_Activated(sender, e);
            deletedregistration = "";
        }

        private void form_bookingsystem_Activated(object sender, EventArgs e)
        {
            if (MyGlobalClass.bookingquerystring != "" && MyGlobalClass.bookingquerystring != null)
            {
                MyGlobalClass.FillQuery(MyGlobalClass.bookingquerystring, true, true, false);
            }
            if (MyGlobalClass.futurebookings.GetLength(0) > 0)
            {
                string[,] bookingcount = new string[0, 0];
                int bookingtotal = 0;
                MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Registration ID` = '" + deletedregistration + "'", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                while (MyGlobalClass.SQL_Alter_Database.Read())
                {
                    if (DateTime.Today < DateTime.Parse(MyGlobalClass.SQL_Alter_Database["Arrival Date"].ToString()))
                    {
                        bookingtotal++;
                    }
                }
                MyGlobalClass.new_connection.Close();

                if (bookingtotal > 0)
                {
                    bookingcount = new string[bookingtotal, 3];
                    bookingtotal = 0;

                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Registration ID` = '" + deletedregistration + "'", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        if (DateTime.Today < DateTime.Parse(MyGlobalClass.SQL_Alter_Database["Arrival Date"].ToString()))
                        {
                            bookingcount[bookingtotal, 0] = MyGlobalClass.SQL_Alter_Database["Booking ID"].ToString();
                            bookingcount[bookingtotal, 1] = MyGlobalClass.SQL_Alter_Database["Arrival Date"].ToString();
                            bookingcount[bookingtotal, 2] = MyGlobalClass.SQL_Alter_Database["Chalet"].ToString();
                            bookingtotal++;
                        }
                    }
                    MyGlobalClass.new_connection.Close();

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
                }
            }
            MyGlobalClass.maintainselected[1] = false;
            update_bookingcalender();
            form_bookingsystem_Load(sender, e);
        }

        private void button_exitsearchresults_bookingsystem_Click(object sender, EventArgs e)
        {
            splitcontainer_bookingcalender_bookingsystem.Panel2Collapsed = true;
            listbox_bookingqueryresult_bookingsystem.Enabled = false;
            listbox_bookingqueryresult_bookingsystem.Visible = false;
            button_exitsearchresults_bookingsystem.Enabled = false;
            button_exitsearchresults_bookingsystem.Visible = false;
            listbox_bookingqueryresult_bookingsystem.Items.Clear();
            MyGlobalClass.bookingquery = new string[0, 0];
        }

        private void listbox_bookingqueryresult_bookingsystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbox_bookingqueryresult_bookingsystem.SelectedIndex > -1)
            {
                if (MyGlobalClass.futurebookings.GetLength(0) > 0)
                {
                    if (selectedbooking == MyGlobalClass.futurebookings[listbox_bookingqueryresult_bookingsystem.SelectedIndex, 3])
                    {
                        listbox_bookingqueryresult_bookingsystem.SelectedIndex = -1;
                    }
                    else
                    {
                        MyGlobalClass.updatechaletnumber(false, MyGlobalClass.totalchalets, true);
                        MyGlobalClass.shownchaletbookings = new bool[MyGlobalClass.totalchalets];
                        for (int i = 0; i < MyGlobalClass.totalchalets; i++)
                        {
                            if (i == (int.Parse(MyGlobalClass.futurebookings[listbox_bookingqueryresult_bookingsystem.SelectedIndex, 2]) - 1))
                            {
                                MyGlobalClass.shownchaletbookings[i] = true;
                            }
                            else
                            {
                                MyGlobalClass.shownchaletbookings[i] = false;
                            }
                        }
                        datetimepicker_bookingdate1_bookingsystem.Value = DateTime.Parse(MyGlobalClass.futurebookings[listbox_bookingqueryresult_bookingsystem.SelectedIndex, 1]);
                        update_bookingcalender();
                        Label label = (Label)tablelayoutpanel_bookingcalender_bookingsystem.GetControlFromPosition(1, (int.Parse(MyGlobalClass.futurebookings[listbox_bookingqueryresult_bookingsystem.SelectedIndex, 2]) - 1));
                        show_booking_information(label, e);
                    }
                }
                if (selectedbooking == MyGlobalClass.bookingquery[listbox_bookingqueryresult_bookingsystem.SelectedIndex, 3])
                {
                    listbox_bookingqueryresult_bookingsystem.SelectedIndex = -1;
                }
                else
                {
                    MyGlobalClass.updatechaletnumber(false, MyGlobalClass.totalchalets, true);
                    MyGlobalClass.shownchaletbookings = new bool[MyGlobalClass.totalchalets];
                    for (int i = 0; i < MyGlobalClass.totalchalets; i++)
                    {
                        if (i == (int.Parse(MyGlobalClass.bookingquery[listbox_bookingqueryresult_bookingsystem.SelectedIndex, 2]) - 1))
                        {
                            MyGlobalClass.shownchaletbookings[i] = true;
                        }
                        else
                        {
                            MyGlobalClass.shownchaletbookings[i] = false;
                        }
                    }
                    datetimepicker_bookingdate1_bookingsystem.Value = DateTime.Parse(MyGlobalClass.bookingquery[listbox_bookingqueryresult_bookingsystem.SelectedIndex, 1]);
                    update_bookingcalender();
                    Label label = (Label)tablelayoutpanel_bookingcalender_bookingsystem.GetControlFromPosition(1, (int.Parse(MyGlobalClass.bookingquery[listbox_bookingqueryresult_bookingsystem.SelectedIndex, 2]) - 1));
                    show_booking_information(label, e);
                }
            }
        }

        private void button_holdbooking_bookingsystem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to hold the booking?", "Hold Booking?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int ID = 1;
                while (true)
                {
                    bool IDFound = true;
                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `Chichester_Cattery_Booking_System`.`Potential Changes` WHERE `ID` = '" + ID + "'", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        ID++;
                        IDFound = false;
                    }
                    MyGlobalClass.new_connection.Close();

                    if (IDFound == true)
                    {
                        break;
                    }
                }
                MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`potential changes` (`ID`, `Booking ID`, `New Chalet`) VALUES ('" + ID + "', '" + selectedbooking + "', '-1')", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                MyGlobalClass.new_connection.Close();

                string ArrivalDate = DateTime.Today.ToString("yyyy-MM-dd");
                string DepartureDate = DateTime.Today.ToString("yyyy-MM-dd");
                string Chalet = "1";
                MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Booking ID` = '" + selectedbooking + "';", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                while (MyGlobalClass.SQL_Alter_Database.Read())
                {
                    ArrivalDate = MyGlobalClass.SQL_Alter_Database["Arrival Date"].ToString();
                    DepartureDate = MyGlobalClass.SQL_Alter_Database["Departure Date"].ToString();
                    Chalet = MyGlobalClass.SQL_Alter_Database["Chalet"].ToString();
                }
                MyGlobalClass.new_connection.Close();

                for (DateTime date = DateTime.Parse(ArrivalDate); date <= DateTime.Parse(DepartureDate); date = date.AddDays(1))
                {
                    MyGlobalClass.SQL_Command = new MySqlCommand("DELETE FROM `chichester_cattery_booking_system`.`" + Chalet + "` WHERE `Date`='" + date.ToString("yyyy-MM-dd") + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    MyGlobalClass.new_connection.Close();
                }
                listbox_selectedcats_bookingsystem.Items.Clear();
                listbox_selectedowners_bookingsystem.Items.Clear();
                text_arrivaldateextrainfo_bookingsystem.Clear();
                text_departuredateextrainfo_bookingsystem.Clear();
                checkbox_checkedin_bookingsystem.CheckState = CheckState.Unchecked;
                checkbox_checkedout_bookingsystem.CheckState = CheckState.Unchecked;
                splitcontainer_bookinginformation_bookingsystem.Panel1Collapsed = true;

                dateupdate = true;
                form_bookingsystem_Activated(sender, e);
            }
        }

        private void text_bookingquery_bookingsystem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_searchbookings_bookingsystem_Click(sender, new EventArgs());
            }
        }

        private void text_registrationquery_bookingsystem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_searchregistrations_bookingsystem_Click(sender, new EventArgs());
            }
        }

        private void text_bookingquery_bookingsystem_Enter(object sender, EventArgs e)
        {
            button_searchbookings_bookingsystem.Font = new Font(Font.FontFamily, button_searchbookings_bookingsystem.Font.Size, FontStyle.Bold);
        }

        private void text_bookingquery_bookingsystem_Leave(object sender, EventArgs e)
        {
            button_searchbookings_bookingsystem.Font = new Font(Font.FontFamily, button_searchbookings_bookingsystem.Font.Size, FontStyle.Regular);
        }

        private void text_registrationquery_bookingsystem_Enter(object sender, EventArgs e)
        {
            button_searchregistrations_bookingsystem.Font = new Font(Font.FontFamily, button_searchregistrations_bookingsystem.Font.Size, FontStyle.Bold);
        }

        private void text_registrationquery_bookingsystem_Leave(object sender, EventArgs e)
        {
            button_searchregistrations_bookingsystem.Font = new Font(Font.FontFamily, button_searchregistrations_bookingsystem.Font.Size, FontStyle.Regular);
        }
    }
}
