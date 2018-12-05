using System.Windows.Forms;
using Global;

namespace Solution
{
    partial class form_initialscreen
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
            if (MyGlobalClass.navigation == false) //Checks if the disposing of the form is a navigation or a closing
            {
                this.WindowState = FormWindowState.Maximized; //If the disposing is a closing, maximise the current form
                this.TopMost = true; //Shows the current form on top
                if (disposing && (components != null)) //Current form diposed
                {
                    components.Dispose();
                }
                base.Dispose(disposing);

                if (Application.OpenForms.Count < 1)
                {
                    Application.Exit(); //Exit the application
                }
                else if (Application.OpenForms.Count >= 1)
                {//If not the last form:
                    Application.OpenForms[Application.OpenForms.Count - 1].BringToFront(); //Brings to front the form below the current form
                    Application.OpenForms[Application.OpenForms.Count - 1].WindowState = FormWindowState.Maximized; //Maximises the form below the current form
                    Application.OpenForms[Application.OpenForms.Count - 1].Close(); //Closes the next form
                }
            }
            else if (MyGlobalClass.navigation == true)
            {//If a disposing is a navigation:
                if (disposing && (components != null)) //Current form diposed
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_initialscreen));
            this.button_goback = new System.Windows.Forms.Button();
            this.button_minimizeform = new System.Windows.Forms.Button();
            this.button_closeform = new System.Windows.Forms.Button();
            this.picturebox_logo = new System.Windows.Forms.PictureBox();
            this.button_search_registrations = new System.Windows.Forms.Button();
            this.button_search_bookings = new System.Windows.Forms.Button();
            this.text_registration_query = new System.Windows.Forms.TextBox();
            this.text_booking_query = new System.Windows.Forms.TextBox();
            this.label_registrationsearch = new System.Windows.Forms.Label();
            this.label_bookingsearch = new System.Windows.Forms.Label();
            this.button_backupandchalets = new System.Windows.Forms.Button();
            this.button_registrations = new System.Windows.Forms.Button();
            this.button_bookings = new System.Windows.Forms.Button();
            this.splitcontainer_info_main = new System.Windows.Forms.SplitContainer();
            this.text_mulitline_extrainfo = new System.Windows.Forms.TextBox();
            this.button_check_inout = new System.Windows.Forms.Button();
            this.button_viewbookingrecord = new System.Windows.Forms.Button();
            this.button_viewregistrationrecord = new System.Windows.Forms.Button();
            this.label_extrainfo = new System.Windows.Forms.Label();
            this.splitcontainer_arrivaldepartures = new System.Windows.Forms.SplitContainer();
            this.listbox_vaccinations = new System.Windows.Forms.ListBox();
            this.label_arrivalslist = new System.Windows.Forms.Label();
            this.label_vaccinations = new System.Windows.Forms.Label();
            this.listbox_showarrivals = new System.Windows.Forms.ListBox();
            this.listBox_potentialrearrangings = new System.Windows.Forms.ListBox();
            this.listbox_showdepartures = new System.Windows.Forms.ListBox();
            this.label_potentialchanges = new System.Windows.Forms.Label();
            this.label_departureslist = new System.Windows.Forms.Label();
            this.button_addbooking = new System.Windows.Forms.Button();
            this.panel_banner_main = new System.Windows.Forms.Panel();
            this.label_titlehome = new System.Windows.Forms.Label();
            this.timer_initialscreen = new System.Windows.Forms.Timer(this.components);
            this.dateTimePicker_homedate = new System.Windows.Forms.DateTimePicker();
            this.button_minusoneday = new System.Windows.Forms.Button();
            this.button_plusoneday = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitcontainer_info_main)).BeginInit();
            this.splitcontainer_info_main.Panel1.SuspendLayout();
            this.splitcontainer_info_main.Panel2.SuspendLayout();
            this.splitcontainer_info_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitcontainer_arrivaldepartures)).BeginInit();
            this.splitcontainer_arrivaldepartures.Panel1.SuspendLayout();
            this.splitcontainer_arrivaldepartures.Panel2.SuspendLayout();
            this.splitcontainer_arrivaldepartures.SuspendLayout();
            this.panel_banner_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_goback
            // 
            this.button_goback.Enabled = false;
            this.button_goback.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_goback.Location = new System.Drawing.Point(1134, 3);
            this.button_goback.Name = "button_goback";
            this.button_goback.Size = new System.Drawing.Size(105, 36);
            this.button_goback.TabIndex = 6;
            this.button_goback.TabStop = false;
            this.button_goback.Text = "Go Back";
            this.button_goback.UseVisualStyleBackColor = true;
            this.button_goback.Visible = false;
            this.button_goback.Click += new System.EventHandler(this.button_goback_Click);
            // 
            // button_minimizeform
            // 
            this.button_minimizeform.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_minimizeform.Location = new System.Drawing.Point(1245, 3);
            this.button_minimizeform.Name = "button_minimizeform";
            this.button_minimizeform.Size = new System.Drawing.Size(36, 36);
            this.button_minimizeform.TabIndex = 5;
            this.button_minimizeform.TabStop = false;
            this.button_minimizeform.Text = "_";
            this.button_minimizeform.UseVisualStyleBackColor = true;
            this.button_minimizeform.Click += new System.EventHandler(this.button_minimizeform_Click);
            // 
            // button_closeform
            // 
            this.button_closeform.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_closeform.Location = new System.Drawing.Point(1287, 3);
            this.button_closeform.Name = "button_closeform";
            this.button_closeform.Size = new System.Drawing.Size(57, 36);
            this.button_closeform.TabIndex = 5;
            this.button_closeform.TabStop = false;
            this.button_closeform.Text = "Exit";
            this.button_closeform.UseVisualStyleBackColor = true;
            this.button_closeform.Click += new System.EventHandler(this.button_closeform_Click);
            // 
            // picturebox_logo
            // 
            this.picturebox_logo.Image = ((System.Drawing.Image)(resources.GetObject("picturebox_logo.Image")));
            this.picturebox_logo.Location = new System.Drawing.Point(996, 60);
            this.picturebox_logo.Name = "picturebox_logo";
            this.picturebox_logo.Size = new System.Drawing.Size(363, 38);
            this.picturebox_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturebox_logo.TabIndex = 4;
            this.picturebox_logo.TabStop = false;
            // 
            // button_search_registrations
            // 
            this.button_search_registrations.BackColor = System.Drawing.Color.White;
            this.button_search_registrations.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_search_registrations.Location = new System.Drawing.Point(765, 79);
            this.button_search_registrations.Name = "button_search_registrations";
            this.button_search_registrations.Size = new System.Drawing.Size(218, 64);
            this.button_search_registrations.TabIndex = 3;
            this.button_search_registrations.Text = "Search Registration System";
            this.button_search_registrations.UseVisualStyleBackColor = false;
            this.button_search_registrations.Click += new System.EventHandler(this.button_search_registrations_Click);
            // 
            // button_search_bookings
            // 
            this.button_search_bookings.BackColor = System.Drawing.Color.White;
            this.button_search_bookings.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_search_bookings.Location = new System.Drawing.Point(578, 79);
            this.button_search_bookings.Name = "button_search_bookings";
            this.button_search_bookings.Size = new System.Drawing.Size(181, 64);
            this.button_search_bookings.TabIndex = 1;
            this.button_search_bookings.Text = "Search Booking System";
            this.button_search_bookings.UseVisualStyleBackColor = false;
            this.button_search_bookings.Click += new System.EventHandler(this.button_search_bookings_Click);
            // 
            // text_registration_query
            // 
            this.text_registration_query.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_registration_query.Location = new System.Drawing.Point(765, 42);
            this.text_registration_query.Name = "text_registration_query";
            this.text_registration_query.Size = new System.Drawing.Size(218, 31);
            this.text_registration_query.TabIndex = 2;
            this.text_registration_query.Enter += new System.EventHandler(this.text_registration_query_Enter);
            this.text_registration_query.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_registration_query_KeyDown);
            this.text_registration_query.Leave += new System.EventHandler(this.text_registration_query_Leave);
            // 
            // text_booking_query
            // 
            this.text_booking_query.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_booking_query.Location = new System.Drawing.Point(578, 42);
            this.text_booking_query.Name = "text_booking_query";
            this.text_booking_query.Size = new System.Drawing.Size(181, 31);
            this.text_booking_query.TabIndex = 0;
            this.text_booking_query.Enter += new System.EventHandler(this.text_booking_query_Enter);
            this.text_booking_query.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_booking_query_KeyDown);
            this.text_booking_query.Leave += new System.EventHandler(this.text_booking_query_Leave);
            // 
            // label_registrationsearch
            // 
            this.label_registrationsearch.AutoSize = true;
            this.label_registrationsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_registrationsearch.ForeColor = System.Drawing.Color.White;
            this.label_registrationsearch.Location = new System.Drawing.Point(765, 14);
            this.label_registrationsearch.Name = "label_registrationsearch";
            this.label_registrationsearch.Size = new System.Drawing.Size(218, 25);
            this.label_registrationsearch.TabIndex = 1;
            this.label_registrationsearch.Text = "Search Registrations:";
            // 
            // label_bookingsearch
            // 
            this.label_bookingsearch.AutoSize = true;
            this.label_bookingsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_bookingsearch.ForeColor = System.Drawing.Color.White;
            this.label_bookingsearch.Location = new System.Drawing.Point(578, 14);
            this.label_bookingsearch.Name = "label_bookingsearch";
            this.label_bookingsearch.Size = new System.Drawing.Size(181, 25);
            this.label_bookingsearch.TabIndex = 1;
            this.label_bookingsearch.Text = "Search Bookings:";
            // 
            // button_backupandchalets
            // 
            this.button_backupandchalets.BackColor = System.Drawing.Color.White;
            this.button_backupandchalets.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_backupandchalets.Location = new System.Drawing.Point(436, 10);
            this.button_backupandchalets.Name = "button_backupandchalets";
            this.button_backupandchalets.Size = new System.Drawing.Size(136, 136);
            this.button_backupandchalets.TabIndex = 0;
            this.button_backupandchalets.TabStop = false;
            this.button_backupandchalets.Text = "Backup and Chalets";
            this.button_backupandchalets.UseVisualStyleBackColor = false;
            this.button_backupandchalets.Click += new System.EventHandler(this.button_backup_Click);
            // 
            // button_registrations
            // 
            this.button_registrations.BackColor = System.Drawing.Color.White;
            this.button_registrations.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_registrations.Location = new System.Drawing.Point(294, 10);
            this.button_registrations.Name = "button_registrations";
            this.button_registrations.Size = new System.Drawing.Size(136, 136);
            this.button_registrations.TabIndex = 0;
            this.button_registrations.TabStop = false;
            this.button_registrations.Text = "Registration System";
            this.button_registrations.UseVisualStyleBackColor = false;
            this.button_registrations.Click += new System.EventHandler(this.button_registrations_Click);
            // 
            // button_bookings
            // 
            this.button_bookings.BackColor = System.Drawing.Color.White;
            this.button_bookings.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_bookings.Location = new System.Drawing.Point(152, 10);
            this.button_bookings.Name = "button_bookings";
            this.button_bookings.Size = new System.Drawing.Size(136, 136);
            this.button_bookings.TabIndex = 0;
            this.button_bookings.TabStop = false;
            this.button_bookings.Text = "Booking System";
            this.button_bookings.UseVisualStyleBackColor = false;
            this.button_bookings.Click += new System.EventHandler(this.button_bookings_Click);
            // 
            // splitcontainer_info_main
            // 
            this.splitcontainer_info_main.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitcontainer_info_main.Location = new System.Drawing.Point(0, 199);
            this.splitcontainer_info_main.Name = "splitcontainer_info_main";
            // 
            // splitcontainer_info_main.Panel1
            // 
            this.splitcontainer_info_main.Panel1.AutoScroll = true;
            this.splitcontainer_info_main.Panel1.BackColor = System.Drawing.Color.Blue;
            this.splitcontainer_info_main.Panel1.Controls.Add(this.text_mulitline_extrainfo);
            this.splitcontainer_info_main.Panel1.Controls.Add(this.button_check_inout);
            this.splitcontainer_info_main.Panel1.Controls.Add(this.button_viewbookingrecord);
            this.splitcontainer_info_main.Panel1.Controls.Add(this.button_viewregistrationrecord);
            this.splitcontainer_info_main.Panel1.Controls.Add(this.label_extrainfo);
            this.splitcontainer_info_main.Panel1Collapsed = true;
            // 
            // splitcontainer_info_main.Panel2
            // 
            this.splitcontainer_info_main.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.splitcontainer_info_main.Panel2.Controls.Add(this.splitcontainer_arrivaldepartures);
            this.splitcontainer_info_main.Size = new System.Drawing.Size(1366, 529);
            this.splitcontainer_info_main.SplitterDistance = 450;
            this.splitcontainer_info_main.SplitterWidth = 2;
            this.splitcontainer_info_main.TabIndex = 7;
            this.splitcontainer_info_main.TabStop = false;
            // 
            // text_mulitline_extrainfo
            // 
            this.text_mulitline_extrainfo.BackColor = System.Drawing.Color.Blue;
            this.text_mulitline_extrainfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_mulitline_extrainfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_mulitline_extrainfo.ForeColor = System.Drawing.Color.White;
            this.text_mulitline_extrainfo.Location = new System.Drawing.Point(10, 32);
            this.text_mulitline_extrainfo.Multiline = true;
            this.text_mulitline_extrainfo.Name = "text_mulitline_extrainfo";
            this.text_mulitline_extrainfo.ReadOnly = true;
            this.text_mulitline_extrainfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.text_mulitline_extrainfo.Size = new System.Drawing.Size(446, 382);
            this.text_mulitline_extrainfo.TabIndex = 0;
            this.text_mulitline_extrainfo.TabStop = false;
            this.text_mulitline_extrainfo.Text = resources.GetString("text_mulitline_extrainfo.Text");
            this.text_mulitline_extrainfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_check_inout
            // 
            this.button_check_inout.BackColor = System.Drawing.Color.White;
            this.button_check_inout.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_check_inout.Location = new System.Drawing.Point(294, 420);
            this.button_check_inout.Name = "button_check_inout";
            this.button_check_inout.Size = new System.Drawing.Size(136, 91);
            this.button_check_inout.TabIndex = 3;
            this.button_check_inout.TabStop = false;
            this.button_check_inout.Text = "Check In/Out";
            this.button_check_inout.UseVisualStyleBackColor = false;
            this.button_check_inout.Click += new System.EventHandler(this.button_check_inout_Click);
            // 
            // button_viewbookingrecord
            // 
            this.button_viewbookingrecord.BackColor = System.Drawing.Color.White;
            this.button_viewbookingrecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_viewbookingrecord.Location = new System.Drawing.Point(152, 420);
            this.button_viewbookingrecord.Name = "button_viewbookingrecord";
            this.button_viewbookingrecord.Size = new System.Drawing.Size(136, 91);
            this.button_viewbookingrecord.TabIndex = 3;
            this.button_viewbookingrecord.TabStop = false;
            this.button_viewbookingrecord.Text = "View Booking Record";
            this.button_viewbookingrecord.UseVisualStyleBackColor = false;
            this.button_viewbookingrecord.Click += new System.EventHandler(this.button_viewbookingrecord_Click);
            // 
            // button_viewregistrationrecord
            // 
            this.button_viewregistrationrecord.BackColor = System.Drawing.Color.White;
            this.button_viewregistrationrecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_viewregistrationrecord.Location = new System.Drawing.Point(10, 420);
            this.button_viewregistrationrecord.Name = "button_viewregistrationrecord";
            this.button_viewregistrationrecord.Size = new System.Drawing.Size(136, 91);
            this.button_viewregistrationrecord.TabIndex = 3;
            this.button_viewregistrationrecord.TabStop = false;
            this.button_viewregistrationrecord.Text = "View Registration Record";
            this.button_viewregistrationrecord.UseVisualStyleBackColor = false;
            this.button_viewregistrationrecord.Click += new System.EventHandler(this.button_viewregistrationrecord_Click);
            // 
            // label_extrainfo
            // 
            this.label_extrainfo.AutoSize = true;
            this.label_extrainfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_extrainfo.ForeColor = System.Drawing.Color.White;
            this.label_extrainfo.Location = new System.Drawing.Point(81, 4);
            this.label_extrainfo.Name = "label_extrainfo";
            this.label_extrainfo.Size = new System.Drawing.Size(273, 25);
            this.label_extrainfo.TabIndex = 2;
            this.label_extrainfo.Text = "Cat and Owner Information:";
            // 
            // splitcontainer_arrivaldepartures
            // 
            this.splitcontainer_arrivaldepartures.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitcontainer_arrivaldepartures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitcontainer_arrivaldepartures.Location = new System.Drawing.Point(0, 0);
            this.splitcontainer_arrivaldepartures.Name = "splitcontainer_arrivaldepartures";
            // 
            // splitcontainer_arrivaldepartures.Panel1
            // 
            this.splitcontainer_arrivaldepartures.Panel1.AutoScroll = true;
            this.splitcontainer_arrivaldepartures.Panel1.BackColor = System.Drawing.Color.White;
            this.splitcontainer_arrivaldepartures.Panel1.Controls.Add(this.listbox_vaccinations);
            this.splitcontainer_arrivaldepartures.Panel1.Controls.Add(this.label_arrivalslist);
            this.splitcontainer_arrivaldepartures.Panel1.Controls.Add(this.label_vaccinations);
            this.splitcontainer_arrivaldepartures.Panel1.Controls.Add(this.listbox_showarrivals);
            // 
            // splitcontainer_arrivaldepartures.Panel2
            // 
            this.splitcontainer_arrivaldepartures.Panel2.AutoScroll = true;
            this.splitcontainer_arrivaldepartures.Panel2.BackColor = System.Drawing.Color.White;
            this.splitcontainer_arrivaldepartures.Panel2.Controls.Add(this.listBox_potentialrearrangings);
            this.splitcontainer_arrivaldepartures.Panel2.Controls.Add(this.listbox_showdepartures);
            this.splitcontainer_arrivaldepartures.Panel2.Controls.Add(this.label_potentialchanges);
            this.splitcontainer_arrivaldepartures.Panel2.Controls.Add(this.label_departureslist);
            this.splitcontainer_arrivaldepartures.Size = new System.Drawing.Size(1366, 529);
            this.splitcontainer_arrivaldepartures.SplitterDistance = 678;
            this.splitcontainer_arrivaldepartures.SplitterWidth = 2;
            this.splitcontainer_arrivaldepartures.TabIndex = 0;
            this.splitcontainer_arrivaldepartures.TabStop = false;
            // 
            // listbox_vaccinations
            // 
            this.listbox_vaccinations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listbox_vaccinations.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listbox_vaccinations.FormattingEnabled = true;
            this.listbox_vaccinations.HorizontalScrollbar = true;
            this.listbox_vaccinations.ItemHeight = 25;
            this.listbox_vaccinations.Items.AddRange(new object[] {
            "2\tMitzy, Felix (Lilley Broadbent)",
            "5\tCoco (Dex North, Janice North)"});
            this.listbox_vaccinations.Location = new System.Drawing.Point(10, 439);
            this.listbox_vaccinations.Name = "listbox_vaccinations";
            this.listbox_vaccinations.Size = new System.Drawing.Size(658, 75);
            this.listbox_vaccinations.TabIndex = 7;
            this.listbox_vaccinations.TabStop = false;
            this.listbox_vaccinations.SelectedIndexChanged += new System.EventHandler(this.listbox_vaccinations_SelectedIndexChanged);
            // 
            // label_arrivalslist
            // 
            this.label_arrivalslist.AutoSize = true;
            this.label_arrivalslist.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_arrivalslist.Location = new System.Drawing.Point(272, 4);
            this.label_arrivalslist.Name = "label_arrivalslist";
            this.label_arrivalslist.Size = new System.Drawing.Size(90, 25);
            this.label_arrivalslist.TabIndex = 6;
            this.label_arrivalslist.Text = "Arrivals:";
            // 
            // label_vaccinations
            // 
            this.label_vaccinations.AutoSize = true;
            this.label_vaccinations.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_vaccinations.Location = new System.Drawing.Point(269, 411);
            this.label_vaccinations.Name = "label_vaccinations";
            this.label_vaccinations.Size = new System.Drawing.Size(141, 25);
            this.label_vaccinations.TabIndex = 6;
            this.label_vaccinations.Text = "Vaccinations:";
            // 
            // listbox_showarrivals
            // 
            this.listbox_showarrivals.BackColor = System.Drawing.SystemColors.Window;
            this.listbox_showarrivals.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listbox_showarrivals.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listbox_showarrivals.FormattingEnabled = true;
            this.listbox_showarrivals.ItemHeight = 25;
            this.listbox_showarrivals.Items.AddRange(new object[] {
            "AM\t32\tMolly (David Lars)",
            "AM\t14\tGreg, Misty, Willow (Amy King)",
            "",
            "PM\t19\tPolly (Joe Sams)",
            "PM\t4\tJohnny, Snowball, Larry (Fred Smith, Molly Smith)",
            "",
            "\t1\tSasha (Gary Keates)"});
            this.listbox_showarrivals.Location = new System.Drawing.Point(10, 32);
            this.listbox_showarrivals.Name = "listbox_showarrivals";
            this.listbox_showarrivals.Size = new System.Drawing.Size(658, 350);
            this.listbox_showarrivals.TabIndex = 5;
            this.listbox_showarrivals.TabStop = false;
            this.listbox_showarrivals.SelectedIndexChanged += new System.EventHandler(this.listbox_showarrivals_SelectedIndexChanged);
            // 
            // listBox_potentialrearrangings
            // 
            this.listBox_potentialrearrangings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox_potentialrearrangings.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_potentialrearrangings.FormattingEnabled = true;
            this.listBox_potentialrearrangings.HorizontalScrollbar = true;
            this.listBox_potentialrearrangings.ItemHeight = 25;
            this.listBox_potentialrearrangings.Items.AddRange(new object[] {
            "2 → 16\tMitzy, Felix (Lilley Broadbent)",
            "5 → 26\tCoco (Dex North, Janice North)"});
            this.listBox_potentialrearrangings.Location = new System.Drawing.Point(14, 439);
            this.listBox_potentialrearrangings.Name = "listBox_potentialrearrangings";
            this.listBox_potentialrearrangings.Size = new System.Drawing.Size(658, 75);
            this.listBox_potentialrearrangings.TabIndex = 7;
            this.listBox_potentialrearrangings.TabStop = false;
            this.listBox_potentialrearrangings.SelectedIndexChanged += new System.EventHandler(this.listBox_potentialrearrangings_SelectedIndexChanged);
            // 
            // listbox_showdepartures
            // 
            this.listbox_showdepartures.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listbox_showdepartures.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listbox_showdepartures.FormattingEnabled = true;
            this.listbox_showdepartures.ItemHeight = 25;
            this.listbox_showdepartures.Items.AddRange(new object[] {
            "AM\t28\tArthur (Andy Anderson)",
            "AM\t45\tCasper, Timmy (Holly Hay)",
            "",
            "PM\t52\tChester, George, Branston (Ariana Gilbert)",
            "",
            "\t9\tSimba, Gizmo (Luke de Lacy)",
            "\t39\tYasmin, Poppy, Bella (Ben Cooper, Trudie Edwards)"});
            this.listbox_showdepartures.Location = new System.Drawing.Point(10, 32);
            this.listbox_showdepartures.Name = "listbox_showdepartures";
            this.listbox_showdepartures.Size = new System.Drawing.Size(662, 350);
            this.listbox_showdepartures.TabIndex = 6;
            this.listbox_showdepartures.TabStop = false;
            this.listbox_showdepartures.SelectedIndexChanged += new System.EventHandler(this.listbox_showdepartures_SelectedIndexChanged);
            // 
            // label_potentialchanges
            // 
            this.label_potentialchanges.AutoSize = true;
            this.label_potentialchanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_potentialchanges.Location = new System.Drawing.Point(246, 411);
            this.label_potentialchanges.Name = "label_potentialchanges";
            this.label_potentialchanges.Size = new System.Drawing.Size(194, 25);
            this.label_potentialchanges.TabIndex = 6;
            this.label_potentialchanges.Text = "Potential Changes:";
            // 
            // label_departureslist
            // 
            this.label_departureslist.AutoSize = true;
            this.label_departureslist.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_departureslist.Location = new System.Drawing.Point(291, 4);
            this.label_departureslist.Name = "label_departureslist";
            this.label_departureslist.Size = new System.Drawing.Size(124, 25);
            this.label_departureslist.TabIndex = 5;
            this.label_departureslist.Text = "Departures:";
            // 
            // button_addbooking
            // 
            this.button_addbooking.BackColor = System.Drawing.Color.White;
            this.button_addbooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_addbooking.Location = new System.Drawing.Point(10, 10);
            this.button_addbooking.Name = "button_addbooking";
            this.button_addbooking.Size = new System.Drawing.Size(136, 136);
            this.button_addbooking.TabIndex = 0;
            this.button_addbooking.TabStop = false;
            this.button_addbooking.Text = "Add New Booking";
            this.button_addbooking.UseVisualStyleBackColor = false;
            this.button_addbooking.Click += new System.EventHandler(this.button_addbooking_Click);
            // 
            // panel_banner_main
            // 
            this.panel_banner_main.BackColor = System.Drawing.Color.Blue;
            this.panel_banner_main.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_banner_main.Controls.Add(this.label_titlehome);
            this.panel_banner_main.Controls.Add(this.button_goback);
            this.panel_banner_main.Controls.Add(this.button_minimizeform);
            this.panel_banner_main.Controls.Add(this.button_closeform);
            this.panel_banner_main.Controls.Add(this.picturebox_logo);
            this.panel_banner_main.Controls.Add(this.button_search_registrations);
            this.panel_banner_main.Controls.Add(this.button_search_bookings);
            this.panel_banner_main.Controls.Add(this.text_registration_query);
            this.panel_banner_main.Controls.Add(this.text_booking_query);
            this.panel_banner_main.Controls.Add(this.label_registrationsearch);
            this.panel_banner_main.Controls.Add(this.label_bookingsearch);
            this.panel_banner_main.Controls.Add(this.button_backupandchalets);
            this.panel_banner_main.Controls.Add(this.button_registrations);
            this.panel_banner_main.Controls.Add(this.button_bookings);
            this.panel_banner_main.Controls.Add(this.button_addbooking);
            this.panel_banner_main.Location = new System.Drawing.Point(0, 0);
            this.panel_banner_main.Name = "panel_banner_main";
            this.panel_banner_main.Size = new System.Drawing.Size(1366, 155);
            this.panel_banner_main.TabIndex = 6;
            // 
            // label_titlehome
            // 
            this.label_titlehome.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_titlehome.ForeColor = System.Drawing.Color.White;
            this.label_titlehome.Location = new System.Drawing.Point(1116, 101);
            this.label_titlehome.Name = "label_titlehome";
            this.label_titlehome.Size = new System.Drawing.Size(124, 42);
            this.label_titlehome.TabIndex = 7;
            this.label_titlehome.Text = "Home";
            this.label_titlehome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer_initialscreen
            // 
            this.timer_initialscreen.Enabled = true;
            this.timer_initialscreen.Interval = 10;
            this.timer_initialscreen.Tick += new System.EventHandler(this.timer_initialscreen_Tick);
            // 
            // dateTimePicker_homedate
            // 
            this.dateTimePicker_homedate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_homedate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_homedate.Location = new System.Drawing.Point(605, 161);
            this.dateTimePicker_homedate.Name = "dateTimePicker_homedate";
            this.dateTimePicker_homedate.Size = new System.Drawing.Size(156, 32);
            this.dateTimePicker_homedate.TabIndex = 8;
            this.dateTimePicker_homedate.TabStop = false;
            this.dateTimePicker_homedate.ValueChanged += new System.EventHandler(this.dateTimePicker_homedate_ValueChanged);
            // 
            // button_minusoneday
            // 
            this.button_minusoneday.BackColor = System.Drawing.Color.White;
            this.button_minusoneday.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_minusoneday.Location = new System.Drawing.Point(568, 163);
            this.button_minusoneday.Name = "button_minusoneday";
            this.button_minusoneday.Size = new System.Drawing.Size(31, 33);
            this.button_minusoneday.TabIndex = 15;
            this.button_minusoneday.TabStop = false;
            this.button_minusoneday.Text = "◄";
            this.button_minusoneday.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_minusoneday.UseVisualStyleBackColor = false;
            this.button_minusoneday.Click += new System.EventHandler(this.button_minusoneday_Click);
            // 
            // button_plusoneday
            // 
            this.button_plusoneday.BackColor = System.Drawing.Color.White;
            this.button_plusoneday.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_plusoneday.Location = new System.Drawing.Point(767, 163);
            this.button_plusoneday.Name = "button_plusoneday";
            this.button_plusoneday.Size = new System.Drawing.Size(31, 33);
            this.button_plusoneday.TabIndex = 14;
            this.button_plusoneday.TabStop = false;
            this.button_plusoneday.Text = "►";
            this.button_plusoneday.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_plusoneday.UseVisualStyleBackColor = false;
            this.button_plusoneday.Click += new System.EventHandler(this.button_plusoneday_Click);
            // 
            // form_initialscreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1366, 728);
            this.Controls.Add(this.button_minusoneday);
            this.Controls.Add(this.button_plusoneday);
            this.Controls.Add(this.dateTimePicker_homedate);
            this.Controls.Add(this.splitcontainer_info_main);
            this.Controls.Add(this.panel_banner_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "form_initialscreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chichester Cattery Booking System: Home";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.form_initialscreen_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_logo)).EndInit();
            this.splitcontainer_info_main.Panel1.ResumeLayout(false);
            this.splitcontainer_info_main.Panel1.PerformLayout();
            this.splitcontainer_info_main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitcontainer_info_main)).EndInit();
            this.splitcontainer_info_main.ResumeLayout(false);
            this.splitcontainer_arrivaldepartures.Panel1.ResumeLayout(false);
            this.splitcontainer_arrivaldepartures.Panel1.PerformLayout();
            this.splitcontainer_arrivaldepartures.Panel2.ResumeLayout(false);
            this.splitcontainer_arrivaldepartures.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitcontainer_arrivaldepartures)).EndInit();
            this.splitcontainer_arrivaldepartures.ResumeLayout(false);
            this.panel_banner_main.ResumeLayout(false);
            this.panel_banner_main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_goback;
        private System.Windows.Forms.Button button_minimizeform;
        private System.Windows.Forms.Button button_closeform;
        private System.Windows.Forms.PictureBox picturebox_logo;
        private System.Windows.Forms.Button button_search_registrations;
        private System.Windows.Forms.Button button_search_bookings;
        private System.Windows.Forms.TextBox text_registration_query;
        private System.Windows.Forms.TextBox text_booking_query;
        private System.Windows.Forms.Label label_registrationsearch;
        private System.Windows.Forms.Label label_bookingsearch;
        private System.Windows.Forms.Button button_backupandchalets;
        private System.Windows.Forms.Button button_registrations;
        private System.Windows.Forms.Button button_bookings;
        private System.Windows.Forms.SplitContainer splitcontainer_info_main;
        private System.Windows.Forms.Button button_check_inout;
        private System.Windows.Forms.Button button_viewbookingrecord;
        private System.Windows.Forms.Button button_viewregistrationrecord;
        private System.Windows.Forms.Label label_extrainfo;
        private System.Windows.Forms.SplitContainer splitcontainer_arrivaldepartures;
        private System.Windows.Forms.ListBox listbox_vaccinations;
        private System.Windows.Forms.Label label_arrivalslist;
        private System.Windows.Forms.Label label_vaccinations;
        private System.Windows.Forms.ListBox listbox_showarrivals;
        private System.Windows.Forms.ListBox listbox_showdepartures;
        private System.Windows.Forms.Label label_departureslist;
        private System.Windows.Forms.Button button_addbooking;
        private System.Windows.Forms.Panel panel_banner_main;
        private System.Windows.Forms.Timer timer_initialscreen;
        private ListBox listBox_potentialrearrangings;
        private DateTimePicker dateTimePicker_homedate;
        private Button button_minusoneday;
        private Button button_plusoneday;
        private Label label_potentialchanges;
        private TextBox text_mulitline_extrainfo;
        private Label label_titlehome;
    }
}

