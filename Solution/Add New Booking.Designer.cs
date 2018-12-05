using System.Windows.Forms;
using System;
using MySql.Data.MySqlClient;
using Global;

namespace Solution
{
    partial class form_addnewbooking
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (MyGlobalClass.booking_deleted == true)
            { //The 'Add New Booking' form is closed for any reason and a booking has been deleted for editing, but not added back in, the old booking is added to the database
                try
                {//When editing a held booking, there is no chalet to insert into.
                    for (DateTime date = DateTime.Parse(MyGlobalClass.booking_addnewbooking[1]); date <= DateTime.Parse(MyGlobalClass.booking_addnewbooking[2]); date = date.AddDays(1))
                    {
                        MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`" + MyGlobalClass.booking_addnewbooking[3] + "` (`Date`, `Booking ID`) VALUES ('" + date.ToString("yyyy-MM-dd") + "', '" + MyGlobalClass.booking_addnewbooking[0] + "');", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        MyGlobalClass.new_connection.Close();
                    }
                }
                catch
                {
                }
            }
            if (MyGlobalClass.navigation == false)
            {
                this.WindowState = FormWindowState.Maximized;
                this.TopMost = true;
                if (MessageBox.Show("Are you sure you want to close the current window?","Close?",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (disposing && (components != null))
                    {
                        components.Dispose();
                    }
                    base.Dispose(disposing);

                    if (Application.OpenForms.Count < 1)
                    {
                        Application.Exit();
                    }
                    else if (Application.OpenForms.Count >= 1)
                    {
                        Application.OpenForms[Application.OpenForms.Count - 1].BringToFront();
                        Application.OpenForms[Application.OpenForms.Count - 1].WindowState = FormWindowState.Maximized;
                        Application.OpenForms[Application.OpenForms.Count - 1].Close();
                    }
                }
                else //If 'No' was clicked
                {
                    this.TopMost = false; //Set topmost to false
                    this.Hide(); //Hides form
                    this.Show(); //Shows form - this then makes the form count towards the openform count
                }
            }
            else if (MyGlobalClass.navigation == true)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            FormCollection formcollection = Application.OpenForms; //This section of code is similar to the OpenForm method
            bool found = false;
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                Form openform = Application.OpenForms[i];
                if (openform.Name == "form_addnewbooking")
                {
                    found = true;
                }
            }
            if (found == false)
            {
                MyGlobalClass.registration_booking = "";
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_addnewbooking));
            this.button_goback_addnewbooking = new System.Windows.Forms.Button();
            this.text_cat6_addnewbooking = new System.Windows.Forms.TextBox();
            this.listbox_ownersearchresults_addnewbooking = new System.Windows.Forms.ListBox();
            this.text_cat5_addnewbooking = new System.Windows.Forms.TextBox();
            this.splitcontainer_datetimeandchalet_addnewbooking = new System.Windows.Forms.SplitContainer();
            this.text_cat4_addnewbooking = new System.Windows.Forms.TextBox();
            this.text_cat3_addnewbooking = new System.Windows.Forms.TextBox();
            this.text_cat2_addnewbooking = new System.Windows.Forms.TextBox();
            this.text_cat1_addnewbooking = new System.Windows.Forms.TextBox();
            this.label_vaccinationsupdate_addnewbooking = new System.Windows.Forms.Label();
            this.text_ownerconfirmationdetails_addnewbooking = new System.Windows.Forms.TextBox();
            this.combobox_departuretime_addnewbooking = new System.Windows.Forms.ComboBox();
            this.combobox_arrivaltime_addnewbooking = new System.Windows.Forms.ComboBox();
            this.datetimepicker_departuredate_addnewbooking = new System.Windows.Forms.DateTimePicker();
            this.datetimepicker_vaccinationupdate4_addnewbooking = new System.Windows.Forms.DateTimePicker();
            this.datetimepicker_vaccinationupdate5_addnewbooking = new System.Windows.Forms.DateTimePicker();
            this.datetimepicker_vaccinationupdate1_addnewbooking = new System.Windows.Forms.DateTimePicker();
            this.datetimepicker_vaccinationupdate6_addnewbooking = new System.Windows.Forms.DateTimePicker();
            this.datetimepicker_vaccinationupdate2_addnewbooking = new System.Windows.Forms.DateTimePicker();
            this.datetimepicker_vaccinationupdate3_addnewbooking = new System.Windows.Forms.DateTimePicker();
            this.datetimepicker_arrivaldate_addnewbooking = new System.Windows.Forms.DateTimePicker();
            this.checkedlistbox_catsstaying_addnewbooking = new System.Windows.Forms.CheckedListBox();
            this.button_addnewregistration_addnewbooking = new System.Windows.Forms.Button();
            this.button_confirmbooking_addnewbooking = new System.Windows.Forms.Button();
            this.button_cancelnewbooking_addnewbooking = new System.Windows.Forms.Button();
            this.button_searchowner_addnewbooking = new System.Windows.Forms.Button();
            this.text_ownersearch_addnewbooking = new System.Windows.Forms.TextBox();
            this.label_departuretime_addnewbooking = new System.Windows.Forms.Label();
            this.label_arrivaltime_addnewbooking = new System.Windows.Forms.Label();
            this.label_departuredate_addnewbooking = new System.Windows.Forms.Label();
            this.label_arrivaldate_addnewbooking = new System.Windows.Forms.Label();
            this.label_catsstayingprompt_addnewbooking = new System.Windows.Forms.Label();
            this.label_ownerinfoprompt_addnewbooking = new System.Windows.Forms.Label();
            this.button_editbooking_addnewbooking = new System.Windows.Forms.Button();
            this.listbox_potentialchalets_addnewbooking = new System.Windows.Forms.ListBox();
            this.button_confirmchalet_addnewbooking = new System.Windows.Forms.Button();
            this.button_viewchaletbookings_addnewbooking = new System.Windows.Forms.Button();
            this.label_potentialchalets_addnewbooking = new System.Windows.Forms.Label();
            this.text_showownersearch_addnewbooking = new System.Windows.Forms.TextBox();
            this.splitcontainer_ownerandcat_addnewbooking = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel_registrationbuttons_addnewbooking = new System.Windows.Forms.TableLayoutPanel();
            this.button_confirmowner_addnewbooking = new System.Windows.Forms.Button();
            this.button_viewregistrationrecord_addnewbooking = new System.Windows.Forms.Button();
            this.button_viewbookingrecord_addnewbooking = new System.Windows.Forms.Button();
            this.button_minimizeform_addnewbooking = new System.Windows.Forms.Button();
            this.button_closeform_addnewbooking = new System.Windows.Forms.Button();
            this.button_searchregistrations_addnewbooking = new System.Windows.Forms.Button();
            this.text_registrationquery_addnewbooking = new System.Windows.Forms.TextBox();
            this.button_bookings_addnewbooking = new System.Windows.Forms.Button();
            this.button_home_addnewbooking = new System.Windows.Forms.Button();
            this.picturebox_logo_addnewbooking = new System.Windows.Forms.PictureBox();
            this.panel_banner_addnewbooking = new System.Windows.Forms.Panel();
            this.label_titleaddnewbooking = new System.Windows.Forms.Label();
            this.button_searchbookings_addnewbooking = new System.Windows.Forms.Button();
            this.text_bookingquery_addnewbooking = new System.Windows.Forms.TextBox();
            this.label_registrationsearch_addnewbooking = new System.Windows.Forms.Label();
            this.label_bookingsearch_addnewbooking = new System.Windows.Forms.Label();
            this.button_registrations_addnewbooking = new System.Windows.Forms.Button();
            this.timer_addnewbooking = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitcontainer_datetimeandchalet_addnewbooking)).BeginInit();
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.SuspendLayout();
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel2.SuspendLayout();
            this.splitcontainer_datetimeandchalet_addnewbooking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitcontainer_ownerandcat_addnewbooking)).BeginInit();
            this.splitcontainer_ownerandcat_addnewbooking.Panel1.SuspendLayout();
            this.splitcontainer_ownerandcat_addnewbooking.Panel2.SuspendLayout();
            this.splitcontainer_ownerandcat_addnewbooking.SuspendLayout();
            this.tableLayoutPanel_registrationbuttons_addnewbooking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_logo_addnewbooking)).BeginInit();
            this.panel_banner_addnewbooking.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_goback_addnewbooking
            // 
            this.button_goback_addnewbooking.Enabled = false;
            this.button_goback_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_goback_addnewbooking.Location = new System.Drawing.Point(1134, 3);
            this.button_goback_addnewbooking.Name = "button_goback_addnewbooking";
            this.button_goback_addnewbooking.Size = new System.Drawing.Size(105, 36);
            this.button_goback_addnewbooking.TabIndex = 6;
            this.button_goback_addnewbooking.TabStop = false;
            this.button_goback_addnewbooking.Text = "Go Back";
            this.button_goback_addnewbooking.UseVisualStyleBackColor = true;
            this.button_goback_addnewbooking.Visible = false;
            this.button_goback_addnewbooking.Click += new System.EventHandler(this.button_goback_addnewbooking_Click);
            // 
            // text_cat6_addnewbooking
            // 
            this.text_cat6_addnewbooking.BackColor = System.Drawing.Color.White;
            this.text_cat6_addnewbooking.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_cat6_addnewbooking.Enabled = false;
            this.text_cat6_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_cat6_addnewbooking.Location = new System.Drawing.Point(986, 227);
            this.text_cat6_addnewbooking.Name = "text_cat6_addnewbooking";
            this.text_cat6_addnewbooking.ReadOnly = true;
            this.text_cat6_addnewbooking.Size = new System.Drawing.Size(221, 23);
            this.text_cat6_addnewbooking.TabIndex = 24;
            this.text_cat6_addnewbooking.TabStop = false;
            this.text_cat6_addnewbooking.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.text_cat6_addnewbooking.Visible = false;
            // 
            // listbox_ownersearchresults_addnewbooking
            // 
            this.listbox_ownersearchresults_addnewbooking.BackColor = System.Drawing.Color.Blue;
            this.listbox_ownersearchresults_addnewbooking.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listbox_ownersearchresults_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listbox_ownersearchresults_addnewbooking.ForeColor = System.Drawing.Color.White;
            this.listbox_ownersearchresults_addnewbooking.FormattingEnabled = true;
            this.listbox_ownersearchresults_addnewbooking.ItemHeight = 25;
            this.listbox_ownersearchresults_addnewbooking.Location = new System.Drawing.Point(10, 37);
            this.listbox_ownersearchresults_addnewbooking.Name = "listbox_ownersearchresults_addnewbooking";
            this.listbox_ownersearchresults_addnewbooking.Size = new System.Drawing.Size(420, 375);
            this.listbox_ownersearchresults_addnewbooking.TabIndex = 0;
            this.listbox_ownersearchresults_addnewbooking.SelectedIndexChanged += new System.EventHandler(this.listbox_ownersearchresults_addnewbooking_SelectedIndexChanged);
            // 
            // text_cat5_addnewbooking
            // 
            this.text_cat5_addnewbooking.BackColor = System.Drawing.Color.White;
            this.text_cat5_addnewbooking.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_cat5_addnewbooking.Enabled = false;
            this.text_cat5_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_cat5_addnewbooking.Location = new System.Drawing.Point(986, 190);
            this.text_cat5_addnewbooking.Name = "text_cat5_addnewbooking";
            this.text_cat5_addnewbooking.ReadOnly = true;
            this.text_cat5_addnewbooking.Size = new System.Drawing.Size(221, 23);
            this.text_cat5_addnewbooking.TabIndex = 24;
            this.text_cat5_addnewbooking.TabStop = false;
            this.text_cat5_addnewbooking.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.text_cat5_addnewbooking.Visible = false;
            // 
            // splitcontainer_datetimeandchalet_addnewbooking
            // 
            this.splitcontainer_datetimeandchalet_addnewbooking.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitcontainer_datetimeandchalet_addnewbooking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitcontainer_datetimeandchalet_addnewbooking.Location = new System.Drawing.Point(0, 0);
            this.splitcontainer_datetimeandchalet_addnewbooking.Name = "splitcontainer_datetimeandchalet_addnewbooking";
            // 
            // splitcontainer_datetimeandchalet_addnewbooking.Panel1
            // 
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.AutoScroll = true;
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.Controls.Add(this.text_cat6_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.Controls.Add(this.text_cat5_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.Controls.Add(this.text_cat4_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.Controls.Add(this.text_cat3_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.Controls.Add(this.text_cat2_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.Controls.Add(this.text_cat1_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.Controls.Add(this.label_vaccinationsupdate_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.Controls.Add(this.text_ownerconfirmationdetails_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.Controls.Add(this.combobox_departuretime_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.Controls.Add(this.combobox_arrivaltime_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.Controls.Add(this.datetimepicker_departuredate_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.Controls.Add(this.datetimepicker_vaccinationupdate4_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.Controls.Add(this.datetimepicker_vaccinationupdate5_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.Controls.Add(this.datetimepicker_vaccinationupdate1_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.Controls.Add(this.datetimepicker_vaccinationupdate6_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.Controls.Add(this.datetimepicker_vaccinationupdate2_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.Controls.Add(this.datetimepicker_vaccinationupdate3_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.Controls.Add(this.datetimepicker_arrivaldate_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.Controls.Add(this.checkedlistbox_catsstaying_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.Controls.Add(this.button_addnewregistration_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.Controls.Add(this.button_confirmbooking_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.Controls.Add(this.button_cancelnewbooking_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.Controls.Add(this.button_searchowner_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.Controls.Add(this.text_ownersearch_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.Controls.Add(this.label_departuretime_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.Controls.Add(this.label_arrivaltime_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.Controls.Add(this.label_departuredate_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.Controls.Add(this.label_arrivaldate_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.Controls.Add(this.label_catsstayingprompt_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.Controls.Add(this.label_ownerinfoprompt_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // splitcontainer_datetimeandchalet_addnewbooking.Panel2
            // 
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel2.AutoScroll = true;
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel2.BackColor = System.Drawing.Color.Blue;
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel2.Controls.Add(this.button_editbooking_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel2.Controls.Add(this.listbox_potentialchalets_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel2.Controls.Add(this.button_confirmchalet_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel2.Controls.Add(this.button_viewchaletbookings_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel2.Controls.Add(this.label_potentialchalets_addnewbooking);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel2Collapsed = true;
            this.splitcontainer_datetimeandchalet_addnewbooking.Size = new System.Drawing.Size(1366, 573);
            this.splitcontainer_datetimeandchalet_addnewbooking.SplitterDistance = 875;
            this.splitcontainer_datetimeandchalet_addnewbooking.SplitterWidth = 2;
            this.splitcontainer_datetimeandchalet_addnewbooking.TabIndex = 0;
            this.splitcontainer_datetimeandchalet_addnewbooking.TabStop = false;
            // 
            // text_cat4_addnewbooking
            // 
            this.text_cat4_addnewbooking.BackColor = System.Drawing.Color.White;
            this.text_cat4_addnewbooking.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_cat4_addnewbooking.Enabled = false;
            this.text_cat4_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_cat4_addnewbooking.Location = new System.Drawing.Point(986, 153);
            this.text_cat4_addnewbooking.Name = "text_cat4_addnewbooking";
            this.text_cat4_addnewbooking.ReadOnly = true;
            this.text_cat4_addnewbooking.Size = new System.Drawing.Size(221, 23);
            this.text_cat4_addnewbooking.TabIndex = 24;
            this.text_cat4_addnewbooking.TabStop = false;
            this.text_cat4_addnewbooking.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.text_cat4_addnewbooking.Visible = false;
            // 
            // text_cat3_addnewbooking
            // 
            this.text_cat3_addnewbooking.BackColor = System.Drawing.Color.White;
            this.text_cat3_addnewbooking.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_cat3_addnewbooking.Enabled = false;
            this.text_cat3_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_cat3_addnewbooking.Location = new System.Drawing.Point(986, 116);
            this.text_cat3_addnewbooking.Name = "text_cat3_addnewbooking";
            this.text_cat3_addnewbooking.ReadOnly = true;
            this.text_cat3_addnewbooking.Size = new System.Drawing.Size(221, 23);
            this.text_cat3_addnewbooking.TabIndex = 24;
            this.text_cat3_addnewbooking.TabStop = false;
            this.text_cat3_addnewbooking.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.text_cat3_addnewbooking.Visible = false;
            // 
            // text_cat2_addnewbooking
            // 
            this.text_cat2_addnewbooking.BackColor = System.Drawing.Color.White;
            this.text_cat2_addnewbooking.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_cat2_addnewbooking.Enabled = false;
            this.text_cat2_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_cat2_addnewbooking.Location = new System.Drawing.Point(986, 79);
            this.text_cat2_addnewbooking.Name = "text_cat2_addnewbooking";
            this.text_cat2_addnewbooking.ReadOnly = true;
            this.text_cat2_addnewbooking.Size = new System.Drawing.Size(221, 23);
            this.text_cat2_addnewbooking.TabIndex = 24;
            this.text_cat2_addnewbooking.TabStop = false;
            this.text_cat2_addnewbooking.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.text_cat2_addnewbooking.Visible = false;
            // 
            // text_cat1_addnewbooking
            // 
            this.text_cat1_addnewbooking.BackColor = System.Drawing.Color.White;
            this.text_cat1_addnewbooking.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_cat1_addnewbooking.Enabled = false;
            this.text_cat1_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_cat1_addnewbooking.Location = new System.Drawing.Point(986, 42);
            this.text_cat1_addnewbooking.Name = "text_cat1_addnewbooking";
            this.text_cat1_addnewbooking.ReadOnly = true;
            this.text_cat1_addnewbooking.Size = new System.Drawing.Size(221, 23);
            this.text_cat1_addnewbooking.TabIndex = 24;
            this.text_cat1_addnewbooking.TabStop = false;
            this.text_cat1_addnewbooking.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.text_cat1_addnewbooking.Visible = false;
            // 
            // label_vaccinationsupdate_addnewbooking
            // 
            this.label_vaccinationsupdate_addnewbooking.AutoSize = true;
            this.label_vaccinationsupdate_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_vaccinationsupdate_addnewbooking.Location = new System.Drawing.Point(1016, 8);
            this.label_vaccinationsupdate_addnewbooking.Name = "label_vaccinationsupdate_addnewbooking";
            this.label_vaccinationsupdate_addnewbooking.Size = new System.Drawing.Size(312, 26);
            this.label_vaccinationsupdate_addnewbooking.TabIndex = 23;
            this.label_vaccinationsupdate_addnewbooking.Text = "Update Vaccination Due dates:";
            // 
            // text_ownerconfirmationdetails_addnewbooking
            // 
            this.text_ownerconfirmationdetails_addnewbooking.BackColor = System.Drawing.Color.White;
            this.text_ownerconfirmationdetails_addnewbooking.Enabled = false;
            this.text_ownerconfirmationdetails_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_ownerconfirmationdetails_addnewbooking.Location = new System.Drawing.Point(628, 27);
            this.text_ownerconfirmationdetails_addnewbooking.Multiline = true;
            this.text_ownerconfirmationdetails_addnewbooking.Name = "text_ownerconfirmationdetails_addnewbooking";
            this.text_ownerconfirmationdetails_addnewbooking.ReadOnly = true;
            this.text_ownerconfirmationdetails_addnewbooking.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.text_ownerconfirmationdetails_addnewbooking.Size = new System.Drawing.Size(352, 261);
            this.text_ownerconfirmationdetails_addnewbooking.TabIndex = 22;
            this.text_ownerconfirmationdetails_addnewbooking.TabStop = false;
            this.text_ownerconfirmationdetails_addnewbooking.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.text_ownerconfirmationdetails_addnewbooking.TextChanged += new System.EventHandler(this.text_ownerconfirmationdetails_addnewbooking_TextChanged);
            // 
            // combobox_departuretime_addnewbooking
            // 
            this.combobox_departuretime_addnewbooking.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.combobox_departuretime_addnewbooking.Enabled = false;
            this.combobox_departuretime_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combobox_departuretime_addnewbooking.FormattingEnabled = true;
            this.combobox_departuretime_addnewbooking.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.combobox_departuretime_addnewbooking.Location = new System.Drawing.Point(916, 326);
            this.combobox_departuretime_addnewbooking.Name = "combobox_departuretime_addnewbooking";
            this.combobox_departuretime_addnewbooking.Size = new System.Drawing.Size(64, 100);
            this.combobox_departuretime_addnewbooking.TabIndex = 6;
            // 
            // combobox_arrivaltime_addnewbooking
            // 
            this.combobox_arrivaltime_addnewbooking.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.combobox_arrivaltime_addnewbooking.Enabled = false;
            this.combobox_arrivaltime_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combobox_arrivaltime_addnewbooking.FormattingEnabled = true;
            this.combobox_arrivaltime_addnewbooking.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.combobox_arrivaltime_addnewbooking.Location = new System.Drawing.Point(628, 326);
            this.combobox_arrivaltime_addnewbooking.Name = "combobox_arrivaltime_addnewbooking";
            this.combobox_arrivaltime_addnewbooking.Size = new System.Drawing.Size(64, 100);
            this.combobox_arrivaltime_addnewbooking.TabIndex = 5;
            // 
            // datetimepicker_departuredate_addnewbooking
            // 
            this.datetimepicker_departuredate_addnewbooking.Enabled = false;
            this.datetimepicker_departuredate_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datetimepicker_departuredate_addnewbooking.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datetimepicker_departuredate_addnewbooking.Location = new System.Drawing.Point(224, 401);
            this.datetimepicker_departuredate_addnewbooking.Name = "datetimepicker_departuredate_addnewbooking";
            this.datetimepicker_departuredate_addnewbooking.Size = new System.Drawing.Size(200, 31);
            this.datetimepicker_departuredate_addnewbooking.TabIndex = 4;
            this.datetimepicker_departuredate_addnewbooking.Value = new System.DateTime(2014, 3, 17, 0, 0, 0, 0);
            // 
            // datetimepicker_vaccinationupdate4_addnewbooking
            // 
            this.datetimepicker_vaccinationupdate4_addnewbooking.Enabled = false;
            this.datetimepicker_vaccinationupdate4_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datetimepicker_vaccinationupdate4_addnewbooking.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datetimepicker_vaccinationupdate4_addnewbooking.Location = new System.Drawing.Point(1213, 148);
            this.datetimepicker_vaccinationupdate4_addnewbooking.Name = "datetimepicker_vaccinationupdate4_addnewbooking";
            this.datetimepicker_vaccinationupdate4_addnewbooking.Size = new System.Drawing.Size(145, 31);
            this.datetimepicker_vaccinationupdate4_addnewbooking.TabIndex = 19;
            this.datetimepicker_vaccinationupdate4_addnewbooking.TabStop = false;
            this.datetimepicker_vaccinationupdate4_addnewbooking.Value = new System.DateTime(2014, 3, 17, 0, 0, 0, 0);
            this.datetimepicker_vaccinationupdate4_addnewbooking.Visible = false;
            this.datetimepicker_vaccinationupdate4_addnewbooking.ValueChanged += new System.EventHandler(this.datetimepicker_vaccinationupdate4_addnewbooking_ValueChanged);
            // 
            // datetimepicker_vaccinationupdate5_addnewbooking
            // 
            this.datetimepicker_vaccinationupdate5_addnewbooking.Enabled = false;
            this.datetimepicker_vaccinationupdate5_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datetimepicker_vaccinationupdate5_addnewbooking.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datetimepicker_vaccinationupdate5_addnewbooking.Location = new System.Drawing.Point(1213, 185);
            this.datetimepicker_vaccinationupdate5_addnewbooking.Name = "datetimepicker_vaccinationupdate5_addnewbooking";
            this.datetimepicker_vaccinationupdate5_addnewbooking.Size = new System.Drawing.Size(145, 31);
            this.datetimepicker_vaccinationupdate5_addnewbooking.TabIndex = 19;
            this.datetimepicker_vaccinationupdate5_addnewbooking.TabStop = false;
            this.datetimepicker_vaccinationupdate5_addnewbooking.Value = new System.DateTime(2014, 3, 17, 0, 0, 0, 0);
            this.datetimepicker_vaccinationupdate5_addnewbooking.Visible = false;
            this.datetimepicker_vaccinationupdate5_addnewbooking.ValueChanged += new System.EventHandler(this.datetimepicker_vaccinationupdate5_addnewbooking_ValueChanged);
            // 
            // datetimepicker_vaccinationupdate1_addnewbooking
            // 
            this.datetimepicker_vaccinationupdate1_addnewbooking.Enabled = false;
            this.datetimepicker_vaccinationupdate1_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datetimepicker_vaccinationupdate1_addnewbooking.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datetimepicker_vaccinationupdate1_addnewbooking.Location = new System.Drawing.Point(1213, 37);
            this.datetimepicker_vaccinationupdate1_addnewbooking.Name = "datetimepicker_vaccinationupdate1_addnewbooking";
            this.datetimepicker_vaccinationupdate1_addnewbooking.Size = new System.Drawing.Size(145, 31);
            this.datetimepicker_vaccinationupdate1_addnewbooking.TabIndex = 19;
            this.datetimepicker_vaccinationupdate1_addnewbooking.TabStop = false;
            this.datetimepicker_vaccinationupdate1_addnewbooking.Value = new System.DateTime(2014, 3, 17, 0, 0, 0, 0);
            this.datetimepicker_vaccinationupdate1_addnewbooking.Visible = false;
            this.datetimepicker_vaccinationupdate1_addnewbooking.ValueChanged += new System.EventHandler(this.datetimepicker_vaccinationupdate1_addnewbooking_ValueChanged);
            // 
            // datetimepicker_vaccinationupdate6_addnewbooking
            // 
            this.datetimepicker_vaccinationupdate6_addnewbooking.Enabled = false;
            this.datetimepicker_vaccinationupdate6_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datetimepicker_vaccinationupdate6_addnewbooking.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datetimepicker_vaccinationupdate6_addnewbooking.Location = new System.Drawing.Point(1213, 222);
            this.datetimepicker_vaccinationupdate6_addnewbooking.Name = "datetimepicker_vaccinationupdate6_addnewbooking";
            this.datetimepicker_vaccinationupdate6_addnewbooking.Size = new System.Drawing.Size(145, 31);
            this.datetimepicker_vaccinationupdate6_addnewbooking.TabIndex = 19;
            this.datetimepicker_vaccinationupdate6_addnewbooking.TabStop = false;
            this.datetimepicker_vaccinationupdate6_addnewbooking.Value = new System.DateTime(2014, 3, 17, 0, 0, 0, 0);
            this.datetimepicker_vaccinationupdate6_addnewbooking.Visible = false;
            this.datetimepicker_vaccinationupdate6_addnewbooking.ValueChanged += new System.EventHandler(this.datetimepicker_vaccinationupdate6_addnewbooking_ValueChanged);
            // 
            // datetimepicker_vaccinationupdate2_addnewbooking
            // 
            this.datetimepicker_vaccinationupdate2_addnewbooking.Enabled = false;
            this.datetimepicker_vaccinationupdate2_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datetimepicker_vaccinationupdate2_addnewbooking.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datetimepicker_vaccinationupdate2_addnewbooking.Location = new System.Drawing.Point(1213, 74);
            this.datetimepicker_vaccinationupdate2_addnewbooking.Name = "datetimepicker_vaccinationupdate2_addnewbooking";
            this.datetimepicker_vaccinationupdate2_addnewbooking.Size = new System.Drawing.Size(145, 31);
            this.datetimepicker_vaccinationupdate2_addnewbooking.TabIndex = 19;
            this.datetimepicker_vaccinationupdate2_addnewbooking.TabStop = false;
            this.datetimepicker_vaccinationupdate2_addnewbooking.Value = new System.DateTime(2014, 3, 17, 0, 0, 0, 0);
            this.datetimepicker_vaccinationupdate2_addnewbooking.Visible = false;
            this.datetimepicker_vaccinationupdate2_addnewbooking.ValueChanged += new System.EventHandler(this.datetimepicker_vaccinationupdate2_addnewbooking_ValueChanged);
            // 
            // datetimepicker_vaccinationupdate3_addnewbooking
            // 
            this.datetimepicker_vaccinationupdate3_addnewbooking.Enabled = false;
            this.datetimepicker_vaccinationupdate3_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datetimepicker_vaccinationupdate3_addnewbooking.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datetimepicker_vaccinationupdate3_addnewbooking.Location = new System.Drawing.Point(1213, 111);
            this.datetimepicker_vaccinationupdate3_addnewbooking.Name = "datetimepicker_vaccinationupdate3_addnewbooking";
            this.datetimepicker_vaccinationupdate3_addnewbooking.Size = new System.Drawing.Size(145, 31);
            this.datetimepicker_vaccinationupdate3_addnewbooking.TabIndex = 19;
            this.datetimepicker_vaccinationupdate3_addnewbooking.TabStop = false;
            this.datetimepicker_vaccinationupdate3_addnewbooking.Value = new System.DateTime(2014, 3, 17, 0, 0, 0, 0);
            this.datetimepicker_vaccinationupdate3_addnewbooking.Visible = false;
            this.datetimepicker_vaccinationupdate3_addnewbooking.ValueChanged += new System.EventHandler(this.datetimepicker_vaccinationupdate3_addnewbooking_ValueChanged);
            // 
            // datetimepicker_arrivaldate_addnewbooking
            // 
            this.datetimepicker_arrivaldate_addnewbooking.Enabled = false;
            this.datetimepicker_arrivaldate_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datetimepicker_arrivaldate_addnewbooking.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datetimepicker_arrivaldate_addnewbooking.Location = new System.Drawing.Point(224, 310);
            this.datetimepicker_arrivaldate_addnewbooking.Name = "datetimepicker_arrivaldate_addnewbooking";
            this.datetimepicker_arrivaldate_addnewbooking.Size = new System.Drawing.Size(200, 31);
            this.datetimepicker_arrivaldate_addnewbooking.TabIndex = 3;
            this.datetimepicker_arrivaldate_addnewbooking.Value = new System.DateTime(2014, 3, 17, 0, 0, 0, 0);
            // 
            // checkedlistbox_catsstaying_addnewbooking
            // 
            this.checkedlistbox_catsstaying_addnewbooking.CheckOnClick = true;
            this.checkedlistbox_catsstaying_addnewbooking.Enabled = false;
            this.checkedlistbox_catsstaying_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedlistbox_catsstaying_addnewbooking.FormattingEnabled = true;
            this.checkedlistbox_catsstaying_addnewbooking.Location = new System.Drawing.Point(140, 103);
            this.checkedlistbox_catsstaying_addnewbooking.Name = "checkedlistbox_catsstaying_addnewbooking";
            this.checkedlistbox_catsstaying_addnewbooking.Size = new System.Drawing.Size(172, 166);
            this.checkedlistbox_catsstaying_addnewbooking.TabIndex = 2;
            // 
            // button_addnewregistration_addnewbooking
            // 
            this.button_addnewregistration_addnewbooking.BackColor = System.Drawing.Color.White;
            this.button_addnewregistration_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_addnewregistration_addnewbooking.Location = new System.Drawing.Point(402, 27);
            this.button_addnewregistration_addnewbooking.Name = "button_addnewregistration_addnewbooking";
            this.button_addnewregistration_addnewbooking.Size = new System.Drawing.Size(138, 58);
            this.button_addnewregistration_addnewbooking.TabIndex = 14;
            this.button_addnewregistration_addnewbooking.TabStop = false;
            this.button_addnewregistration_addnewbooking.Text = "Add New Registration";
            this.button_addnewregistration_addnewbooking.UseVisualStyleBackColor = false;
            this.button_addnewregistration_addnewbooking.Click += new System.EventHandler(this.button_addnewregistration_addnewbooking_Click);
            // 
            // button_confirmbooking_addnewbooking
            // 
            this.button_confirmbooking_addnewbooking.BackColor = System.Drawing.Color.White;
            this.button_confirmbooking_addnewbooking.Enabled = false;
            this.button_confirmbooking_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_confirmbooking_addnewbooking.Location = new System.Drawing.Point(753, 483);
            this.button_confirmbooking_addnewbooking.Name = "button_confirmbooking_addnewbooking";
            this.button_confirmbooking_addnewbooking.Size = new System.Drawing.Size(227, 35);
            this.button_confirmbooking_addnewbooking.TabIndex = 7;
            this.button_confirmbooking_addnewbooking.Text = "Confirm New Booking";
            this.button_confirmbooking_addnewbooking.UseVisualStyleBackColor = false;
            this.button_confirmbooking_addnewbooking.Click += new System.EventHandler(this.button_confirmbooking_addnewbooking_Click);
            // 
            // button_cancelnewbooking_addnewbooking
            // 
            this.button_cancelnewbooking_addnewbooking.BackColor = System.Drawing.Color.White;
            this.button_cancelnewbooking_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cancelnewbooking_addnewbooking.Location = new System.Drawing.Point(27, 483);
            this.button_cancelnewbooking_addnewbooking.Name = "button_cancelnewbooking_addnewbooking";
            this.button_cancelnewbooking_addnewbooking.Size = new System.Drawing.Size(227, 35);
            this.button_cancelnewbooking_addnewbooking.TabIndex = 16;
            this.button_cancelnewbooking_addnewbooking.TabStop = false;
            this.button_cancelnewbooking_addnewbooking.Text = "Cancel New Booking";
            this.button_cancelnewbooking_addnewbooking.UseVisualStyleBackColor = false;
            this.button_cancelnewbooking_addnewbooking.Click += new System.EventHandler(this.button_cancelnewbooking_addnewbooking_Click);
            // 
            // button_searchowner_addnewbooking
            // 
            this.button_searchowner_addnewbooking.BackColor = System.Drawing.Color.White;
            this.button_searchowner_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_searchowner_addnewbooking.Location = new System.Drawing.Point(306, 27);
            this.button_searchowner_addnewbooking.Name = "button_searchowner_addnewbooking";
            this.button_searchowner_addnewbooking.Size = new System.Drawing.Size(90, 58);
            this.button_searchowner_addnewbooking.TabIndex = 1;
            this.button_searchowner_addnewbooking.Text = "Search";
            this.button_searchowner_addnewbooking.UseVisualStyleBackColor = false;
            this.button_searchowner_addnewbooking.Click += new System.EventHandler(this.button_searchowner_addnewbooking_Click);
            // 
            // text_ownersearch_addnewbooking
            // 
            this.text_ownersearch_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_ownersearch_addnewbooking.Location = new System.Drawing.Point(140, 41);
            this.text_ownersearch_addnewbooking.Name = "text_ownersearch_addnewbooking";
            this.text_ownersearch_addnewbooking.Size = new System.Drawing.Size(160, 31);
            this.text_ownersearch_addnewbooking.TabIndex = 0;
            this.text_ownersearch_addnewbooking.Enter += new System.EventHandler(this.text_ownersearch_addnewbooking_Enter);
            this.text_ownersearch_addnewbooking.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_ownersearch_addnewbooking_KeyDown);
            this.text_ownersearch_addnewbooking.Leave += new System.EventHandler(this.text_ownersearch_addnewbooking_Leave);
            // 
            // label_departuretime_addnewbooking
            // 
            this.label_departuretime_addnewbooking.AutoSize = true;
            this.label_departuretime_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_departuretime_addnewbooking.Location = new System.Drawing.Point(744, 329);
            this.label_departuretime_addnewbooking.Name = "label_departuretime_addnewbooking";
            this.label_departuretime_addnewbooking.Size = new System.Drawing.Size(166, 25);
            this.label_departuretime_addnewbooking.TabIndex = 8;
            this.label_departuretime_addnewbooking.Text = "Departure Time:";
            // 
            // label_arrivaltime_addnewbooking
            // 
            this.label_arrivaltime_addnewbooking.AutoSize = true;
            this.label_arrivaltime_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_arrivaltime_addnewbooking.Location = new System.Drawing.Point(490, 329);
            this.label_arrivaltime_addnewbooking.Name = "label_arrivaltime_addnewbooking";
            this.label_arrivaltime_addnewbooking.Size = new System.Drawing.Size(132, 25);
            this.label_arrivaltime_addnewbooking.TabIndex = 7;
            this.label_arrivaltime_addnewbooking.Text = "Arrival Time:";
            // 
            // label_departuredate_addnewbooking
            // 
            this.label_departuredate_addnewbooking.AutoSize = true;
            this.label_departuredate_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_departuredate_addnewbooking.Location = new System.Drawing.Point(54, 406);
            this.label_departuredate_addnewbooking.Name = "label_departuredate_addnewbooking";
            this.label_departuredate_addnewbooking.Size = new System.Drawing.Size(164, 25);
            this.label_departuredate_addnewbooking.TabIndex = 6;
            this.label_departuredate_addnewbooking.Text = "Departure Date:";
            // 
            // label_arrivaldate_addnewbooking
            // 
            this.label_arrivaldate_addnewbooking.AutoSize = true;
            this.label_arrivaldate_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_arrivaldate_addnewbooking.Location = new System.Drawing.Point(54, 313);
            this.label_arrivaldate_addnewbooking.Name = "label_arrivaldate_addnewbooking";
            this.label_arrivaldate_addnewbooking.Size = new System.Drawing.Size(130, 25);
            this.label_arrivaldate_addnewbooking.TabIndex = 11;
            this.label_arrivaldate_addnewbooking.Text = "Arrival Date:";
            // 
            // label_catsstayingprompt_addnewbooking
            // 
            this.label_catsstayingprompt_addnewbooking.AutoSize = true;
            this.label_catsstayingprompt_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_catsstayingprompt_addnewbooking.Location = new System.Drawing.Point(54, 103);
            this.label_catsstayingprompt_addnewbooking.Name = "label_catsstayingprompt_addnewbooking";
            this.label_catsstayingprompt_addnewbooking.Size = new System.Drawing.Size(76, 25);
            this.label_catsstayingprompt_addnewbooking.TabIndex = 10;
            this.label_catsstayingprompt_addnewbooking.Text = "Cat(s):";
            // 
            // label_ownerinfoprompt_addnewbooking
            // 
            this.label_ownerinfoprompt_addnewbooking.AutoSize = true;
            this.label_ownerinfoprompt_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ownerinfoprompt_addnewbooking.Location = new System.Drawing.Point(54, 44);
            this.label_ownerinfoprompt_addnewbooking.Name = "label_ownerinfoprompt_addnewbooking";
            this.label_ownerinfoprompt_addnewbooking.Size = new System.Drawing.Size(86, 25);
            this.label_ownerinfoprompt_addnewbooking.TabIndex = 9;
            this.label_ownerinfoprompt_addnewbooking.Text = "Search:";
            // 
            // button_editbooking_addnewbooking
            // 
            this.button_editbooking_addnewbooking.BackColor = System.Drawing.Color.White;
            this.button_editbooking_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_editbooking_addnewbooking.Location = new System.Drawing.Point(164, 413);
            this.button_editbooking_addnewbooking.Name = "button_editbooking_addnewbooking";
            this.button_editbooking_addnewbooking.Size = new System.Drawing.Size(155, 91);
            this.button_editbooking_addnewbooking.TabIndex = 3;
            this.button_editbooking_addnewbooking.TabStop = false;
            this.button_editbooking_addnewbooking.Text = "Edit Booking";
            this.button_editbooking_addnewbooking.UseVisualStyleBackColor = false;
            this.button_editbooking_addnewbooking.Click += new System.EventHandler(this.button_editbooking_addnewbooking_Click);
            // 
            // listbox_potentialchalets_addnewbooking
            // 
            this.listbox_potentialchalets_addnewbooking.BackColor = System.Drawing.Color.Blue;
            this.listbox_potentialchalets_addnewbooking.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listbox_potentialchalets_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listbox_potentialchalets_addnewbooking.ForeColor = System.Drawing.Color.White;
            this.listbox_potentialchalets_addnewbooking.FormattingEnabled = true;
            this.listbox_potentialchalets_addnewbooking.ItemHeight = 25;
            this.listbox_potentialchalets_addnewbooking.Location = new System.Drawing.Point(9, 32);
            this.listbox_potentialchalets_addnewbooking.Name = "listbox_potentialchalets_addnewbooking";
            this.listbox_potentialchalets_addnewbooking.Size = new System.Drawing.Size(456, 375);
            this.listbox_potentialchalets_addnewbooking.TabIndex = 0;
            this.listbox_potentialchalets_addnewbooking.SelectedIndexChanged += new System.EventHandler(this.listbox_potentialchalets_addnewbooking_SelectedIndexChanged);
            // 
            // button_confirmchalet_addnewbooking
            // 
            this.button_confirmchalet_addnewbooking.BackColor = System.Drawing.Color.White;
            this.button_confirmchalet_addnewbooking.Enabled = false;
            this.button_confirmchalet_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_confirmchalet_addnewbooking.Location = new System.Drawing.Point(321, 413);
            this.button_confirmchalet_addnewbooking.Name = "button_confirmchalet_addnewbooking";
            this.button_confirmchalet_addnewbooking.Size = new System.Drawing.Size(155, 91);
            this.button_confirmchalet_addnewbooking.TabIndex = 1;
            this.button_confirmchalet_addnewbooking.Text = "Confirm Chalet";
            this.button_confirmchalet_addnewbooking.UseVisualStyleBackColor = false;
            this.button_confirmchalet_addnewbooking.Click += new System.EventHandler(this.button_confirmchalet_addnewbooking_Click);
            // 
            // button_viewchaletbookings_addnewbooking
            // 
            this.button_viewchaletbookings_addnewbooking.BackColor = System.Drawing.Color.White;
            this.button_viewchaletbookings_addnewbooking.Enabled = false;
            this.button_viewchaletbookings_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_viewchaletbookings_addnewbooking.Location = new System.Drawing.Point(3, 413);
            this.button_viewchaletbookings_addnewbooking.Name = "button_viewchaletbookings_addnewbooking";
            this.button_viewchaletbookings_addnewbooking.Size = new System.Drawing.Size(155, 91);
            this.button_viewchaletbookings_addnewbooking.TabIndex = 6;
            this.button_viewchaletbookings_addnewbooking.TabStop = false;
            this.button_viewchaletbookings_addnewbooking.Text = "View Current Booking State for Chalet";
            this.button_viewchaletbookings_addnewbooking.UseVisualStyleBackColor = false;
            this.button_viewchaletbookings_addnewbooking.Click += new System.EventHandler(this.button_viewchaletbookings_addnewbooking_Click);
            // 
            // label_potentialchalets_addnewbooking
            // 
            this.label_potentialchalets_addnewbooking.AutoSize = true;
            this.label_potentialchalets_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_potentialchalets_addnewbooking.ForeColor = System.Drawing.Color.White;
            this.label_potentialchalets_addnewbooking.Location = new System.Drawing.Point(135, 4);
            this.label_potentialchalets_addnewbooking.Name = "label_potentialchalets_addnewbooking";
            this.label_potentialchalets_addnewbooking.Size = new System.Drawing.Size(181, 25);
            this.label_potentialchalets_addnewbooking.TabIndex = 0;
            this.label_potentialchalets_addnewbooking.Text = "Potential Chalets:";
            // 
            // text_showownersearch_addnewbooking
            // 
            this.text_showownersearch_addnewbooking.BackColor = System.Drawing.Color.Blue;
            this.text_showownersearch_addnewbooking.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_showownersearch_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_showownersearch_addnewbooking.ForeColor = System.Drawing.Color.White;
            this.text_showownersearch_addnewbooking.Location = new System.Drawing.Point(10, 7);
            this.text_showownersearch_addnewbooking.Name = "text_showownersearch_addnewbooking";
            this.text_showownersearch_addnewbooking.ReadOnly = true;
            this.text_showownersearch_addnewbooking.Size = new System.Drawing.Size(433, 24);
            this.text_showownersearch_addnewbooking.TabIndex = 4;
            this.text_showownersearch_addnewbooking.TabStop = false;
            this.text_showownersearch_addnewbooking.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // splitcontainer_ownerandcat_addnewbooking
            // 
            this.splitcontainer_ownerandcat_addnewbooking.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitcontainer_ownerandcat_addnewbooking.Location = new System.Drawing.Point(0, 155);
            this.splitcontainer_ownerandcat_addnewbooking.Name = "splitcontainer_ownerandcat_addnewbooking";
            // 
            // splitcontainer_ownerandcat_addnewbooking.Panel1
            // 
            this.splitcontainer_ownerandcat_addnewbooking.Panel1.AutoScroll = true;
            this.splitcontainer_ownerandcat_addnewbooking.Panel1.BackColor = System.Drawing.Color.Blue;
            this.splitcontainer_ownerandcat_addnewbooking.Panel1.Controls.Add(this.tableLayoutPanel_registrationbuttons_addnewbooking);
            this.splitcontainer_ownerandcat_addnewbooking.Panel1.Controls.Add(this.listbox_ownersearchresults_addnewbooking);
            this.splitcontainer_ownerandcat_addnewbooking.Panel1.Controls.Add(this.text_showownersearch_addnewbooking);
            this.splitcontainer_ownerandcat_addnewbooking.Panel1Collapsed = true;
            // 
            // splitcontainer_ownerandcat_addnewbooking.Panel2
            // 
            this.splitcontainer_ownerandcat_addnewbooking.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.splitcontainer_ownerandcat_addnewbooking.Panel2.Controls.Add(this.splitcontainer_datetimeandchalet_addnewbooking);
            this.splitcontainer_ownerandcat_addnewbooking.Size = new System.Drawing.Size(1366, 573);
            this.splitcontainer_ownerandcat_addnewbooking.SplitterDistance = 456;
            this.splitcontainer_ownerandcat_addnewbooking.SplitterWidth = 2;
            this.splitcontainer_ownerandcat_addnewbooking.TabIndex = 9;
            this.splitcontainer_ownerandcat_addnewbooking.TabStop = false;
            // 
            // tableLayoutPanel_registrationbuttons_addnewbooking
            // 
            this.tableLayoutPanel_registrationbuttons_addnewbooking.ColumnCount = 3;
            this.tableLayoutPanel_registrationbuttons_addnewbooking.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel_registrationbuttons_addnewbooking.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel_registrationbuttons_addnewbooking.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel_registrationbuttons_addnewbooking.Controls.Add(this.button_confirmowner_addnewbooking, 2, 0);
            this.tableLayoutPanel_registrationbuttons_addnewbooking.Controls.Add(this.button_viewregistrationrecord_addnewbooking, 0, 0);
            this.tableLayoutPanel_registrationbuttons_addnewbooking.Controls.Add(this.button_viewbookingrecord_addnewbooking, 1, 0);
            this.tableLayoutPanel_registrationbuttons_addnewbooking.Location = new System.Drawing.Point(3, 438);
            this.tableLayoutPanel_registrationbuttons_addnewbooking.Name = "tableLayoutPanel_registrationbuttons_addnewbooking";
            this.tableLayoutPanel_registrationbuttons_addnewbooking.RowCount = 1;
            this.tableLayoutPanel_registrationbuttons_addnewbooking.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel_registrationbuttons_addnewbooking.Size = new System.Drawing.Size(447, 111);
            this.tableLayoutPanel_registrationbuttons_addnewbooking.TabIndex = 6;
            // 
            // button_confirmowner_addnewbooking
            // 
            this.button_confirmowner_addnewbooking.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_confirmowner_addnewbooking.BackColor = System.Drawing.Color.White;
            this.button_confirmowner_addnewbooking.Enabled = false;
            this.button_confirmowner_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_confirmowner_addnewbooking.Location = new System.Drawing.Point(307, 10);
            this.button_confirmowner_addnewbooking.Name = "button_confirmowner_addnewbooking";
            this.button_confirmowner_addnewbooking.Size = new System.Drawing.Size(136, 91);
            this.button_confirmowner_addnewbooking.TabIndex = 0;
            this.button_confirmowner_addnewbooking.Text = "Confirm Registration";
            this.button_confirmowner_addnewbooking.UseVisualStyleBackColor = false;
            this.button_confirmowner_addnewbooking.Click += new System.EventHandler(this.button_confirmowner_addnewbooking_Click);
            // 
            // button_viewregistrationrecord_addnewbooking
            // 
            this.button_viewregistrationrecord_addnewbooking.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_viewregistrationrecord_addnewbooking.BackColor = System.Drawing.Color.White;
            this.button_viewregistrationrecord_addnewbooking.Enabled = false;
            this.button_viewregistrationrecord_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_viewregistrationrecord_addnewbooking.Location = new System.Drawing.Point(5, 10);
            this.button_viewregistrationrecord_addnewbooking.Name = "button_viewregistrationrecord_addnewbooking";
            this.button_viewregistrationrecord_addnewbooking.Size = new System.Drawing.Size(140, 91);
            this.button_viewregistrationrecord_addnewbooking.TabIndex = 3;
            this.button_viewregistrationrecord_addnewbooking.TabStop = false;
            this.button_viewregistrationrecord_addnewbooking.Text = "View Registration Record";
            this.button_viewregistrationrecord_addnewbooking.UseVisualStyleBackColor = false;
            this.button_viewregistrationrecord_addnewbooking.Click += new System.EventHandler(this.button_viewregistrationrecord_addnewbooking_Click);
            // 
            // button_viewbookingrecord_addnewbooking
            // 
            this.button_viewbookingrecord_addnewbooking.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_viewbookingrecord_addnewbooking.BackColor = System.Drawing.Color.White;
            this.button_viewbookingrecord_addnewbooking.Enabled = false;
            this.button_viewbookingrecord_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_viewbookingrecord_addnewbooking.Location = new System.Drawing.Point(157, 10);
            this.button_viewbookingrecord_addnewbooking.Name = "button_viewbookingrecord_addnewbooking";
            this.button_viewbookingrecord_addnewbooking.Size = new System.Drawing.Size(136, 91);
            this.button_viewbookingrecord_addnewbooking.TabIndex = 3;
            this.button_viewbookingrecord_addnewbooking.TabStop = false;
            this.button_viewbookingrecord_addnewbooking.Text = "View Booking Record";
            this.button_viewbookingrecord_addnewbooking.UseVisualStyleBackColor = false;
            this.button_viewbookingrecord_addnewbooking.Visible = false;
            this.button_viewbookingrecord_addnewbooking.Click += new System.EventHandler(this.button_viewbookingrecord_addnewbooking_Click);
            // 
            // button_minimizeform_addnewbooking
            // 
            this.button_minimizeform_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_minimizeform_addnewbooking.Location = new System.Drawing.Point(1245, 3);
            this.button_minimizeform_addnewbooking.Name = "button_minimizeform_addnewbooking";
            this.button_minimizeform_addnewbooking.Size = new System.Drawing.Size(36, 36);
            this.button_minimizeform_addnewbooking.TabIndex = 5;
            this.button_minimizeform_addnewbooking.TabStop = false;
            this.button_minimizeform_addnewbooking.Text = "_";
            this.button_minimizeform_addnewbooking.UseVisualStyleBackColor = true;
            this.button_minimizeform_addnewbooking.Click += new System.EventHandler(this.button_minimizeform_addnewbooking_Click);
            // 
            // button_closeform_addnewbooking
            // 
            this.button_closeform_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_closeform_addnewbooking.Location = new System.Drawing.Point(1287, 3);
            this.button_closeform_addnewbooking.Name = "button_closeform_addnewbooking";
            this.button_closeform_addnewbooking.Size = new System.Drawing.Size(57, 36);
            this.button_closeform_addnewbooking.TabIndex = 5;
            this.button_closeform_addnewbooking.TabStop = false;
            this.button_closeform_addnewbooking.Text = "Exit";
            this.button_closeform_addnewbooking.UseVisualStyleBackColor = true;
            this.button_closeform_addnewbooking.Click += new System.EventHandler(this.button_closeform_addnewbooking_Click);
            // 
            // button_searchregistrations_addnewbooking
            // 
            this.button_searchregistrations_addnewbooking.BackColor = System.Drawing.Color.White;
            this.button_searchregistrations_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_searchregistrations_addnewbooking.Location = new System.Drawing.Point(765, 79);
            this.button_searchregistrations_addnewbooking.Name = "button_searchregistrations_addnewbooking";
            this.button_searchregistrations_addnewbooking.Size = new System.Drawing.Size(218, 64);
            this.button_searchregistrations_addnewbooking.TabIndex = 3;
            this.button_searchregistrations_addnewbooking.Text = "Search Registration System";
            this.button_searchregistrations_addnewbooking.UseVisualStyleBackColor = false;
            this.button_searchregistrations_addnewbooking.Click += new System.EventHandler(this.button_searchregistrations_addnewbooking_Click);
            // 
            // text_registrationquery_addnewbooking
            // 
            this.text_registrationquery_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_registrationquery_addnewbooking.Location = new System.Drawing.Point(765, 42);
            this.text_registrationquery_addnewbooking.Name = "text_registrationquery_addnewbooking";
            this.text_registrationquery_addnewbooking.Size = new System.Drawing.Size(218, 31);
            this.text_registrationquery_addnewbooking.TabIndex = 2;
            this.text_registrationquery_addnewbooking.Enter += new System.EventHandler(this.text_registrationquery_addnewbooking_Enter);
            this.text_registrationquery_addnewbooking.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_registrationquery_addnewbooking_KeyDown);
            this.text_registrationquery_addnewbooking.Leave += new System.EventHandler(this.text_registrationquery_addnewbooking_Leave);
            // 
            // button_bookings_addnewbooking
            // 
            this.button_bookings_addnewbooking.BackColor = System.Drawing.Color.White;
            this.button_bookings_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_bookings_addnewbooking.Location = new System.Drawing.Point(152, 10);
            this.button_bookings_addnewbooking.Name = "button_bookings_addnewbooking";
            this.button_bookings_addnewbooking.Size = new System.Drawing.Size(136, 136);
            this.button_bookings_addnewbooking.TabIndex = 0;
            this.button_bookings_addnewbooking.TabStop = false;
            this.button_bookings_addnewbooking.Text = "Booking System";
            this.button_bookings_addnewbooking.UseVisualStyleBackColor = false;
            this.button_bookings_addnewbooking.Click += new System.EventHandler(this.button_bookings_addnewbooking_Click);
            // 
            // button_home_addnewbooking
            // 
            this.button_home_addnewbooking.BackColor = System.Drawing.Color.White;
            this.button_home_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_home_addnewbooking.Location = new System.Drawing.Point(10, 10);
            this.button_home_addnewbooking.Name = "button_home_addnewbooking";
            this.button_home_addnewbooking.Size = new System.Drawing.Size(136, 136);
            this.button_home_addnewbooking.TabIndex = 0;
            this.button_home_addnewbooking.TabStop = false;
            this.button_home_addnewbooking.Text = "Home";
            this.button_home_addnewbooking.UseVisualStyleBackColor = false;
            this.button_home_addnewbooking.Click += new System.EventHandler(this.button_home_addnewbooking_Click);
            // 
            // picturebox_logo_addnewbooking
            // 
            this.picturebox_logo_addnewbooking.Image = ((System.Drawing.Image)(resources.GetObject("picturebox_logo_addnewbooking.Image")));
            this.picturebox_logo_addnewbooking.Location = new System.Drawing.Point(996, 60);
            this.picturebox_logo_addnewbooking.Name = "picturebox_logo_addnewbooking";
            this.picturebox_logo_addnewbooking.Size = new System.Drawing.Size(363, 38);
            this.picturebox_logo_addnewbooking.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturebox_logo_addnewbooking.TabIndex = 4;
            this.picturebox_logo_addnewbooking.TabStop = false;
            // 
            // panel_banner_addnewbooking
            // 
            this.panel_banner_addnewbooking.BackColor = System.Drawing.Color.Blue;
            this.panel_banner_addnewbooking.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_banner_addnewbooking.Controls.Add(this.label_titleaddnewbooking);
            this.panel_banner_addnewbooking.Controls.Add(this.button_goback_addnewbooking);
            this.panel_banner_addnewbooking.Controls.Add(this.button_minimizeform_addnewbooking);
            this.panel_banner_addnewbooking.Controls.Add(this.button_closeform_addnewbooking);
            this.panel_banner_addnewbooking.Controls.Add(this.picturebox_logo_addnewbooking);
            this.panel_banner_addnewbooking.Controls.Add(this.button_searchregistrations_addnewbooking);
            this.panel_banner_addnewbooking.Controls.Add(this.button_searchbookings_addnewbooking);
            this.panel_banner_addnewbooking.Controls.Add(this.text_registrationquery_addnewbooking);
            this.panel_banner_addnewbooking.Controls.Add(this.text_bookingquery_addnewbooking);
            this.panel_banner_addnewbooking.Controls.Add(this.label_registrationsearch_addnewbooking);
            this.panel_banner_addnewbooking.Controls.Add(this.label_bookingsearch_addnewbooking);
            this.panel_banner_addnewbooking.Controls.Add(this.button_registrations_addnewbooking);
            this.panel_banner_addnewbooking.Controls.Add(this.button_bookings_addnewbooking);
            this.panel_banner_addnewbooking.Controls.Add(this.button_home_addnewbooking);
            this.panel_banner_addnewbooking.Location = new System.Drawing.Point(0, 0);
            this.panel_banner_addnewbooking.Name = "panel_banner_addnewbooking";
            this.panel_banner_addnewbooking.Size = new System.Drawing.Size(1366, 155);
            this.panel_banner_addnewbooking.TabIndex = 8;
            // 
            // label_titleaddnewbooking
            // 
            this.label_titleaddnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_titleaddnewbooking.ForeColor = System.Drawing.Color.White;
            this.label_titleaddnewbooking.Location = new System.Drawing.Point(1033, 101);
            this.label_titleaddnewbooking.Name = "label_titleaddnewbooking";
            this.label_titleaddnewbooking.Size = new System.Drawing.Size(290, 42);
            this.label_titleaddnewbooking.TabIndex = 8;
            this.label_titleaddnewbooking.Text = "Add New Booking";
            this.label_titleaddnewbooking.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_searchbookings_addnewbooking
            // 
            this.button_searchbookings_addnewbooking.BackColor = System.Drawing.Color.White;
            this.button_searchbookings_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_searchbookings_addnewbooking.Location = new System.Drawing.Point(578, 79);
            this.button_searchbookings_addnewbooking.Name = "button_searchbookings_addnewbooking";
            this.button_searchbookings_addnewbooking.Size = new System.Drawing.Size(181, 64);
            this.button_searchbookings_addnewbooking.TabIndex = 1;
            this.button_searchbookings_addnewbooking.Text = "Search Booking System";
            this.button_searchbookings_addnewbooking.UseVisualStyleBackColor = false;
            this.button_searchbookings_addnewbooking.Click += new System.EventHandler(this.button_searchbookings_addnewbooking_Click);
            // 
            // text_bookingquery_addnewbooking
            // 
            this.text_bookingquery_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_bookingquery_addnewbooking.Location = new System.Drawing.Point(578, 42);
            this.text_bookingquery_addnewbooking.Name = "text_bookingquery_addnewbooking";
            this.text_bookingquery_addnewbooking.Size = new System.Drawing.Size(181, 31);
            this.text_bookingquery_addnewbooking.TabIndex = 0;
            this.text_bookingquery_addnewbooking.Enter += new System.EventHandler(this.text_bookingquery_addnewbooking_Enter);
            this.text_bookingquery_addnewbooking.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_bookingquery_addnewbooking_KeyDown);
            this.text_bookingquery_addnewbooking.Leave += new System.EventHandler(this.text_bookingquery_addnewbooking_Leave);
            // 
            // label_registrationsearch_addnewbooking
            // 
            this.label_registrationsearch_addnewbooking.AutoSize = true;
            this.label_registrationsearch_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_registrationsearch_addnewbooking.ForeColor = System.Drawing.Color.White;
            this.label_registrationsearch_addnewbooking.Location = new System.Drawing.Point(765, 14);
            this.label_registrationsearch_addnewbooking.Name = "label_registrationsearch_addnewbooking";
            this.label_registrationsearch_addnewbooking.Size = new System.Drawing.Size(218, 25);
            this.label_registrationsearch_addnewbooking.TabIndex = 1;
            this.label_registrationsearch_addnewbooking.Text = "Search Registrations:";
            // 
            // label_bookingsearch_addnewbooking
            // 
            this.label_bookingsearch_addnewbooking.AutoSize = true;
            this.label_bookingsearch_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_bookingsearch_addnewbooking.ForeColor = System.Drawing.Color.White;
            this.label_bookingsearch_addnewbooking.Location = new System.Drawing.Point(578, 14);
            this.label_bookingsearch_addnewbooking.Name = "label_bookingsearch_addnewbooking";
            this.label_bookingsearch_addnewbooking.Size = new System.Drawing.Size(181, 25);
            this.label_bookingsearch_addnewbooking.TabIndex = 1;
            this.label_bookingsearch_addnewbooking.Text = "Search Bookings:";
            // 
            // button_registrations_addnewbooking
            // 
            this.button_registrations_addnewbooking.BackColor = System.Drawing.Color.White;
            this.button_registrations_addnewbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_registrations_addnewbooking.Location = new System.Drawing.Point(294, 10);
            this.button_registrations_addnewbooking.Name = "button_registrations_addnewbooking";
            this.button_registrations_addnewbooking.Size = new System.Drawing.Size(136, 136);
            this.button_registrations_addnewbooking.TabIndex = 0;
            this.button_registrations_addnewbooking.TabStop = false;
            this.button_registrations_addnewbooking.Text = "Registration System";
            this.button_registrations_addnewbooking.UseVisualStyleBackColor = false;
            this.button_registrations_addnewbooking.Click += new System.EventHandler(this.button_registrations_addnewbooking_Click);
            // 
            // timer_addnewbooking
            // 
            this.timer_addnewbooking.Enabled = true;
            this.timer_addnewbooking.Interval = 10;
            this.timer_addnewbooking.Tick += new System.EventHandler(this.timer_addnewbooking_Tick);
            // 
            // form_addnewbooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1366, 728);
            this.Controls.Add(this.splitcontainer_ownerandcat_addnewbooking);
            this.Controls.Add(this.panel_banner_addnewbooking);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "form_addnewbooking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chichester Cattery Booking System : Add New Booking";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.form_addnewbooking_Activated);
            this.Load += new System.EventHandler(this.form_addnewbooking_Load);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.ResumeLayout(false);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel1.PerformLayout();
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel2.ResumeLayout(false);
            this.splitcontainer_datetimeandchalet_addnewbooking.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitcontainer_datetimeandchalet_addnewbooking)).EndInit();
            this.splitcontainer_datetimeandchalet_addnewbooking.ResumeLayout(false);
            this.splitcontainer_ownerandcat_addnewbooking.Panel1.ResumeLayout(false);
            this.splitcontainer_ownerandcat_addnewbooking.Panel1.PerformLayout();
            this.splitcontainer_ownerandcat_addnewbooking.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitcontainer_ownerandcat_addnewbooking)).EndInit();
            this.splitcontainer_ownerandcat_addnewbooking.ResumeLayout(false);
            this.tableLayoutPanel_registrationbuttons_addnewbooking.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_logo_addnewbooking)).EndInit();
            this.panel_banner_addnewbooking.ResumeLayout(false);
            this.panel_banner_addnewbooking.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_goback_addnewbooking;
        private System.Windows.Forms.TextBox text_cat6_addnewbooking;
        private System.Windows.Forms.ListBox listbox_ownersearchresults_addnewbooking;
        private System.Windows.Forms.TextBox text_cat5_addnewbooking;
        private System.Windows.Forms.SplitContainer splitcontainer_datetimeandchalet_addnewbooking;
        private System.Windows.Forms.TextBox text_cat4_addnewbooking;
        private System.Windows.Forms.TextBox text_cat3_addnewbooking;
        private System.Windows.Forms.TextBox text_cat2_addnewbooking;
        private System.Windows.Forms.TextBox text_cat1_addnewbooking;
        private System.Windows.Forms.Label label_vaccinationsupdate_addnewbooking;
        private System.Windows.Forms.TextBox text_ownerconfirmationdetails_addnewbooking;
        private System.Windows.Forms.ComboBox combobox_departuretime_addnewbooking;
        private System.Windows.Forms.ComboBox combobox_arrivaltime_addnewbooking;
        private System.Windows.Forms.DateTimePicker datetimepicker_departuredate_addnewbooking;
        private System.Windows.Forms.DateTimePicker datetimepicker_vaccinationupdate4_addnewbooking;
        private System.Windows.Forms.DateTimePicker datetimepicker_vaccinationupdate5_addnewbooking;
        private System.Windows.Forms.DateTimePicker datetimepicker_vaccinationupdate1_addnewbooking;
        private System.Windows.Forms.DateTimePicker datetimepicker_vaccinationupdate6_addnewbooking;
        private System.Windows.Forms.DateTimePicker datetimepicker_vaccinationupdate2_addnewbooking;
        private System.Windows.Forms.DateTimePicker datetimepicker_vaccinationupdate3_addnewbooking;
        private System.Windows.Forms.DateTimePicker datetimepicker_arrivaldate_addnewbooking;
        private System.Windows.Forms.CheckedListBox checkedlistbox_catsstaying_addnewbooking;
        private System.Windows.Forms.Button button_addnewregistration_addnewbooking;
        private System.Windows.Forms.Button button_confirmbooking_addnewbooking;
        private System.Windows.Forms.Button button_cancelnewbooking_addnewbooking;
        private System.Windows.Forms.Button button_searchowner_addnewbooking;
        private System.Windows.Forms.TextBox text_ownersearch_addnewbooking;
        private System.Windows.Forms.Label label_departuretime_addnewbooking;
        private System.Windows.Forms.Label label_arrivaltime_addnewbooking;
        private System.Windows.Forms.Label label_departuredate_addnewbooking;
        private System.Windows.Forms.Label label_arrivaldate_addnewbooking;
        private System.Windows.Forms.Label label_catsstayingprompt_addnewbooking;
        private System.Windows.Forms.Label label_ownerinfoprompt_addnewbooking;
        private System.Windows.Forms.ListBox listbox_potentialchalets_addnewbooking;
        private System.Windows.Forms.Button button_confirmchalet_addnewbooking;
        private System.Windows.Forms.Button button_viewchaletbookings_addnewbooking;
        private System.Windows.Forms.Label label_potentialchalets_addnewbooking;
        private System.Windows.Forms.TextBox text_showownersearch_addnewbooking;
        private System.Windows.Forms.SplitContainer splitcontainer_ownerandcat_addnewbooking;
        private System.Windows.Forms.Button button_confirmowner_addnewbooking;
        private System.Windows.Forms.Button button_viewbookingrecord_addnewbooking;
        private System.Windows.Forms.Button button_minimizeform_addnewbooking;
        private System.Windows.Forms.Button button_closeform_addnewbooking;
        private System.Windows.Forms.Button button_searchregistrations_addnewbooking;
        private System.Windows.Forms.TextBox text_registrationquery_addnewbooking;
        private System.Windows.Forms.Button button_bookings_addnewbooking;
        private System.Windows.Forms.Button button_home_addnewbooking;
        private System.Windows.Forms.PictureBox picturebox_logo_addnewbooking;
        private System.Windows.Forms.Panel panel_banner_addnewbooking;
        private System.Windows.Forms.Button button_searchbookings_addnewbooking;
        private System.Windows.Forms.TextBox text_bookingquery_addnewbooking;
        private System.Windows.Forms.Label label_registrationsearch_addnewbooking;
        private System.Windows.Forms.Label label_bookingsearch_addnewbooking;
        private System.Windows.Forms.Button button_registrations_addnewbooking;
        private System.Windows.Forms.Timer timer_addnewbooking;
        private Button button_editbooking_addnewbooking;
        private TableLayoutPanel tableLayoutPanel_registrationbuttons_addnewbooking;
        private Button button_viewregistrationrecord_addnewbooking;
        private Label label_titleaddnewbooking;
    }
}