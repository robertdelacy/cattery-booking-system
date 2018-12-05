using System.Windows.Forms;
using System;
using MySql.Data.MySqlClient;
using Global;

namespace Solution
{
    partial class form_bookingsystem
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
            //for (int i = 0; i < Application.OpenForms.Count; i++)
            //{
            //    Form openform = Application.OpenForms[i];
            //    if (openform.Name == "form_addnewbooking")
            //    {
            //        found = true;
            //    }
            //}
            if (MyGlobalClass.navigation == false)
            {
                this.WindowState = FormWindowState.Maximized;
                this.TopMost = true;
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
                if (openform.Name == "form_bookingsystem")
                {
                    found = true;
                }
            }
            if (found == false)
            {
                MyGlobalClass.shownchaletbookings = new bool[0];
                MyGlobalClass.bookingsystemdate = System.DateTime.Today;
                MyGlobalClass.bookingquery = new string[0, 0];
                MyGlobalClass.futurebookings = new string[0, 0];
                MyGlobalClass.bookingquerystring = "";
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_bookingsystem));
            this.checkedlistbox_chaletsshown_bookingsystem = new System.Windows.Forms.CheckedListBox();
            this.datetimepicker_bookingdate6_bookingsystem = new System.Windows.Forms.DateTimePicker();
            this.button_view_bookingsystem = new System.Windows.Forms.Button();
            this.datetimepicker_bookingdate1_bookingsystem = new System.Windows.Forms.DateTimePicker();
            this.datetimepicker_bookingdate2_bookingsystem = new System.Windows.Forms.DateTimePicker();
            this.datetimepicker_bookingdate3_bookingsystem = new System.Windows.Forms.DateTimePicker();
            this.datetimepicker_bookingdate4_bookingsystem = new System.Windows.Forms.DateTimePicker();
            this.datetimepicker_bookingdate5_bookingsystem = new System.Windows.Forms.DateTimePicker();
            this.listbox_bookingqueryresult_bookingsystem = new System.Windows.Forms.ListBox();
            this.button_searchbookings_bookingsystem = new System.Windows.Forms.Button();
            this.text_changeviewqueryresults_bookingsystem = new System.Windows.Forms.TextBox();
            this.label_bookingcheckedout_bookingsystem = new System.Windows.Forms.Label();
            this.button_exitsearchresults_bookingsystem = new System.Windows.Forms.Button();
            this.button_changechaletview_bookingsystem = new System.Windows.Forms.Button();
            this.checkbox_checkedout_bookingsystem = new System.Windows.Forms.CheckBox();
            this.text_bookingquery_bookingsystem = new System.Windows.Forms.TextBox();
            this.text_registrationquery_bookingsystem = new System.Windows.Forms.TextBox();
            this.button_home_bookingsystem = new System.Windows.Forms.Button();
            this.checkbox_checkedin_bookingsystem = new System.Windows.Forms.CheckBox();
            this.label_bookingcheckedin_bookingsystem = new System.Windows.Forms.Label();
            this.label_bookingdeparturedate_bookingsystem = new System.Windows.Forms.Label();
            this.label_bookingarrivaldate_bookingsystem = new System.Windows.Forms.Label();
            this.label_registrationsearch_bookingsystem = new System.Windows.Forms.Label();
            this.label_bookingsearch_bookingsystem = new System.Windows.Forms.Label();
            this.label_bookingcats_bookingsystem = new System.Windows.Forms.Label();
            this.label_bookingowners_bookingsystem = new System.Windows.Forms.Label();
            this.label_bookinginformation_bookingsystem = new System.Windows.Forms.Label();
            this.listbox_selectedcats_bookingsystem = new System.Windows.Forms.ListBox();
            this.splitcontainer_bookinginformation_bookingsystem = new System.Windows.Forms.SplitContainer();
            this.button_undocheckinout_bookingsystem = new System.Windows.Forms.Button();
            this.listbox_selectedowners_bookingsystem = new System.Windows.Forms.ListBox();
            this.text_departuredateextrainfo_bookingsystem = new System.Windows.Forms.TextBox();
            this.text_arrivaldateextrainfo_bookingsystem = new System.Windows.Forms.TextBox();
            this.button_holdbooking_bookingsystem = new System.Windows.Forms.Button();
            this.button_deletebooking_bookingsystem = new System.Windows.Forms.Button();
            this.button_exitbookinginfo_bookingsystem = new System.Windows.Forms.Button();
            this.button_editbooking_bookingsystem = new System.Windows.Forms.Button();
            this.button_checkinout_bookingsystem = new System.Windows.Forms.Button();
            this.button_viewregistrationrecord_bookingsystem = new System.Windows.Forms.Button();
            this.splitcontainer_bookingcalender_bookingsystem = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel_datetimepickers_bookinsystem = new System.Windows.Forms.TableLayoutPanel();
            this.datetimepicker_bookingdate7_bookingsystem = new System.Windows.Forms.DateTimePicker();
            this.panel_bookingcalender_bookingsystem = new System.Windows.Forms.Panel();
            this.tablelayoutpanel_bookingcalender_bookingsystem = new System.Windows.Forms.TableLayoutPanel();
            this.button_searchregistrations_bookingsystem = new System.Windows.Forms.Button();
            this.button_closeform_bookingsystem = new System.Windows.Forms.Button();
            this.timer_bookingsystem = new System.Windows.Forms.Timer(this.components);
            this.button_goback_bookingsystem = new System.Windows.Forms.Button();
            this.picturebox_logo_regstrationsystem = new System.Windows.Forms.PictureBox();
            this.button_addnewbooking_bookingsystem = new System.Windows.Forms.Button();
            this.panel_banner_bookingsystem = new System.Windows.Forms.Panel();
            this.label_titlebookingsystem = new System.Windows.Forms.Label();
            this.button_minusoneday_bookingsystem = new System.Windows.Forms.Button();
            this.button_plusoneday_bookingsystem = new System.Windows.Forms.Button();
            this.button_registrations_bookingsystem = new System.Windows.Forms.Button();
            this.button_minimizeform_bookingsystem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitcontainer_bookinginformation_bookingsystem)).BeginInit();
            this.splitcontainer_bookinginformation_bookingsystem.Panel1.SuspendLayout();
            this.splitcontainer_bookinginformation_bookingsystem.Panel2.SuspendLayout();
            this.splitcontainer_bookinginformation_bookingsystem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitcontainer_bookingcalender_bookingsystem)).BeginInit();
            this.splitcontainer_bookingcalender_bookingsystem.Panel1.SuspendLayout();
            this.splitcontainer_bookingcalender_bookingsystem.Panel2.SuspendLayout();
            this.splitcontainer_bookingcalender_bookingsystem.SuspendLayout();
            this.tableLayoutPanel_datetimepickers_bookinsystem.SuspendLayout();
            this.panel_bookingcalender_bookingsystem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_logo_regstrationsystem)).BeginInit();
            this.panel_banner_bookingsystem.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkedlistbox_chaletsshown_bookingsystem
            // 
            this.checkedlistbox_chaletsshown_bookingsystem.BackColor = System.Drawing.Color.Blue;
            this.checkedlistbox_chaletsshown_bookingsystem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedlistbox_chaletsshown_bookingsystem.CheckOnClick = true;
            this.checkedlistbox_chaletsshown_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedlistbox_chaletsshown_bookingsystem.ForeColor = System.Drawing.Color.White;
            this.checkedlistbox_chaletsshown_bookingsystem.FormattingEnabled = true;
            this.checkedlistbox_chaletsshown_bookingsystem.Items.AddRange(new object[] {
            "All"});
            this.checkedlistbox_chaletsshown_bookingsystem.Location = new System.Drawing.Point(3, 35);
            this.checkedlistbox_chaletsshown_bookingsystem.Name = "checkedlistbox_chaletsshown_bookingsystem";
            this.checkedlistbox_chaletsshown_bookingsystem.Size = new System.Drawing.Size(436, 432);
            this.checkedlistbox_chaletsshown_bookingsystem.TabIndex = 4;
            this.checkedlistbox_chaletsshown_bookingsystem.TabStop = false;
            this.checkedlistbox_chaletsshown_bookingsystem.SelectedIndexChanged += new System.EventHandler(this.checkedlistbox_chaletsshown_bookingsystem_SelectedIndexChanged);
            // 
            // datetimepicker_bookingdate6_bookingsystem
            // 
            this.datetimepicker_bookingdate6_bookingsystem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.datetimepicker_bookingdate6_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datetimepicker_bookingdate6_bookingsystem.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datetimepicker_bookingdate6_bookingsystem.Location = new System.Drawing.Point(1005, 18);
            this.datetimepicker_bookingdate6_bookingsystem.Name = "datetimepicker_bookingdate6_bookingsystem";
            this.datetimepicker_bookingdate6_bookingsystem.Size = new System.Drawing.Size(161, 32);
            this.datetimepicker_bookingdate6_bookingsystem.TabIndex = 92;
            this.datetimepicker_bookingdate6_bookingsystem.TabStop = false;
            this.datetimepicker_bookingdate6_bookingsystem.ValueChanged += new System.EventHandler(this.datetimepicker_bookingdate6_bookingsystem_ValueChanged);
            // 
            // button_view_bookingsystem
            // 
            this.button_view_bookingsystem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_view_bookingsystem.BackColor = System.Drawing.Color.White;
            this.button_view_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_view_bookingsystem.Location = new System.Drawing.Point(46, 17);
            this.button_view_bookingsystem.Name = "button_view_bookingsystem";
            this.button_view_bookingsystem.Size = new System.Drawing.Size(75, 34);
            this.button_view_bookingsystem.TabIndex = 1;
            this.button_view_bookingsystem.TabStop = false;
            this.button_view_bookingsystem.Text = "View";
            this.button_view_bookingsystem.UseVisualStyleBackColor = false;
            this.button_view_bookingsystem.Click += new System.EventHandler(this.button_view_bookingsystem_Click);
            // 
            // datetimepicker_bookingdate1_bookingsystem
            // 
            this.datetimepicker_bookingdate1_bookingsystem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.datetimepicker_bookingdate1_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datetimepicker_bookingdate1_bookingsystem.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datetimepicker_bookingdate1_bookingsystem.Location = new System.Drawing.Point(170, 18);
            this.datetimepicker_bookingdate1_bookingsystem.Name = "datetimepicker_bookingdate1_bookingsystem";
            this.datetimepicker_bookingdate1_bookingsystem.Size = new System.Drawing.Size(161, 32);
            this.datetimepicker_bookingdate1_bookingsystem.TabIndex = 91;
            this.datetimepicker_bookingdate1_bookingsystem.TabStop = false;
            this.datetimepicker_bookingdate1_bookingsystem.ValueChanged += new System.EventHandler(this.datetimepicker_bookingdate1_bookingsystem_ValueChanged);
            // 
            // datetimepicker_bookingdate2_bookingsystem
            // 
            this.datetimepicker_bookingdate2_bookingsystem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.datetimepicker_bookingdate2_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datetimepicker_bookingdate2_bookingsystem.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datetimepicker_bookingdate2_bookingsystem.Location = new System.Drawing.Point(337, 18);
            this.datetimepicker_bookingdate2_bookingsystem.Name = "datetimepicker_bookingdate2_bookingsystem";
            this.datetimepicker_bookingdate2_bookingsystem.Size = new System.Drawing.Size(161, 32);
            this.datetimepicker_bookingdate2_bookingsystem.TabIndex = 91;
            this.datetimepicker_bookingdate2_bookingsystem.TabStop = false;
            this.datetimepicker_bookingdate2_bookingsystem.ValueChanged += new System.EventHandler(this.datetimepicker_bookingdate2_bookingsystem_ValueChanged);
            // 
            // datetimepicker_bookingdate3_bookingsystem
            // 
            this.datetimepicker_bookingdate3_bookingsystem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.datetimepicker_bookingdate3_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datetimepicker_bookingdate3_bookingsystem.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datetimepicker_bookingdate3_bookingsystem.Location = new System.Drawing.Point(504, 18);
            this.datetimepicker_bookingdate3_bookingsystem.Name = "datetimepicker_bookingdate3_bookingsystem";
            this.datetimepicker_bookingdate3_bookingsystem.Size = new System.Drawing.Size(161, 32);
            this.datetimepicker_bookingdate3_bookingsystem.TabIndex = 91;
            this.datetimepicker_bookingdate3_bookingsystem.TabStop = false;
            this.datetimepicker_bookingdate3_bookingsystem.ValueChanged += new System.EventHandler(this.datetimepicker_bookingdate3_bookingsystem_ValueChanged);
            // 
            // datetimepicker_bookingdate4_bookingsystem
            // 
            this.datetimepicker_bookingdate4_bookingsystem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.datetimepicker_bookingdate4_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datetimepicker_bookingdate4_bookingsystem.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datetimepicker_bookingdate4_bookingsystem.Location = new System.Drawing.Point(671, 18);
            this.datetimepicker_bookingdate4_bookingsystem.Name = "datetimepicker_bookingdate4_bookingsystem";
            this.datetimepicker_bookingdate4_bookingsystem.Size = new System.Drawing.Size(161, 32);
            this.datetimepicker_bookingdate4_bookingsystem.TabIndex = 91;
            this.datetimepicker_bookingdate4_bookingsystem.TabStop = false;
            this.datetimepicker_bookingdate4_bookingsystem.ValueChanged += new System.EventHandler(this.datetimepicker_bookingdate4_bookingsystem_ValueChanged);
            // 
            // datetimepicker_bookingdate5_bookingsystem
            // 
            this.datetimepicker_bookingdate5_bookingsystem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.datetimepicker_bookingdate5_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datetimepicker_bookingdate5_bookingsystem.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datetimepicker_bookingdate5_bookingsystem.Location = new System.Drawing.Point(838, 18);
            this.datetimepicker_bookingdate5_bookingsystem.Name = "datetimepicker_bookingdate5_bookingsystem";
            this.datetimepicker_bookingdate5_bookingsystem.Size = new System.Drawing.Size(161, 32);
            this.datetimepicker_bookingdate5_bookingsystem.TabIndex = 91;
            this.datetimepicker_bookingdate5_bookingsystem.TabStop = false;
            this.datetimepicker_bookingdate5_bookingsystem.ValueChanged += new System.EventHandler(this.datetimepicker_bookingdate5_bookingsystem_ValueChanged);
            // 
            // listbox_bookingqueryresult_bookingsystem
            // 
            this.listbox_bookingqueryresult_bookingsystem.BackColor = System.Drawing.Color.Blue;
            this.listbox_bookingqueryresult_bookingsystem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listbox_bookingqueryresult_bookingsystem.Enabled = false;
            this.listbox_bookingqueryresult_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listbox_bookingqueryresult_bookingsystem.ForeColor = System.Drawing.Color.White;
            this.listbox_bookingqueryresult_bookingsystem.FormattingEnabled = true;
            this.listbox_bookingqueryresult_bookingsystem.ItemHeight = 25;
            this.listbox_bookingqueryresult_bookingsystem.Location = new System.Drawing.Point(3, 35);
            this.listbox_bookingqueryresult_bookingsystem.Name = "listbox_bookingqueryresult_bookingsystem";
            this.listbox_bookingqueryresult_bookingsystem.Size = new System.Drawing.Size(456, 425);
            this.listbox_bookingqueryresult_bookingsystem.TabIndex = 3;
            this.listbox_bookingqueryresult_bookingsystem.TabStop = false;
            this.listbox_bookingqueryresult_bookingsystem.Visible = false;
            this.listbox_bookingqueryresult_bookingsystem.SelectedIndexChanged += new System.EventHandler(this.listbox_bookingqueryresult_bookingsystem_SelectedIndexChanged);
            // 
            // button_searchbookings_bookingsystem
            // 
            this.button_searchbookings_bookingsystem.BackColor = System.Drawing.Color.White;
            this.button_searchbookings_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_searchbookings_bookingsystem.Location = new System.Drawing.Point(578, 79);
            this.button_searchbookings_bookingsystem.Name = "button_searchbookings_bookingsystem";
            this.button_searchbookings_bookingsystem.Size = new System.Drawing.Size(181, 64);
            this.button_searchbookings_bookingsystem.TabIndex = 1;
            this.button_searchbookings_bookingsystem.Text = "Search Booking System";
            this.button_searchbookings_bookingsystem.UseVisualStyleBackColor = false;
            this.button_searchbookings_bookingsystem.Click += new System.EventHandler(this.button_searchbookings_bookingsystem_Click);
            // 
            // text_changeviewqueryresults_bookingsystem
            // 
            this.text_changeviewqueryresults_bookingsystem.BackColor = System.Drawing.Color.Blue;
            this.text_changeviewqueryresults_bookingsystem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_changeviewqueryresults_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_changeviewqueryresults_bookingsystem.ForeColor = System.Drawing.Color.White;
            this.text_changeviewqueryresults_bookingsystem.Location = new System.Drawing.Point(3, 4);
            this.text_changeviewqueryresults_bookingsystem.Name = "text_changeviewqueryresults_bookingsystem";
            this.text_changeviewqueryresults_bookingsystem.ReadOnly = true;
            this.text_changeviewqueryresults_bookingsystem.Size = new System.Drawing.Size(436, 25);
            this.text_changeviewqueryresults_bookingsystem.TabIndex = 2;
            this.text_changeviewqueryresults_bookingsystem.TabStop = false;
            this.text_changeviewqueryresults_bookingsystem.Text = "Change Chalet View";
            this.text_changeviewqueryresults_bookingsystem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_bookingcheckedout_bookingsystem
            // 
            this.label_bookingcheckedout_bookingsystem.AutoSize = true;
            this.label_bookingcheckedout_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_bookingcheckedout_bookingsystem.ForeColor = System.Drawing.Color.White;
            this.label_bookingcheckedout_bookingsystem.Location = new System.Drawing.Point(188, 388);
            this.label_bookingcheckedout_bookingsystem.Name = "label_bookingcheckedout_bookingsystem";
            this.label_bookingcheckedout_bookingsystem.Size = new System.Drawing.Size(145, 26);
            this.label_bookingcheckedout_bookingsystem.TabIndex = 3;
            this.label_bookingcheckedout_bookingsystem.Text = "Checked Out:";
            // 
            // button_exitsearchresults_bookingsystem
            // 
            this.button_exitsearchresults_bookingsystem.BackColor = System.Drawing.Color.White;
            this.button_exitsearchresults_bookingsystem.Enabled = false;
            this.button_exitsearchresults_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_exitsearchresults_bookingsystem.Location = new System.Drawing.Point(140, 487);
            this.button_exitsearchresults_bookingsystem.Name = "button_exitsearchresults_bookingsystem";
            this.button_exitsearchresults_bookingsystem.Size = new System.Drawing.Size(156, 72);
            this.button_exitsearchresults_bookingsystem.TabIndex = 1;
            this.button_exitsearchresults_bookingsystem.TabStop = false;
            this.button_exitsearchresults_bookingsystem.Text = "Exit Search Results";
            this.button_exitsearchresults_bookingsystem.UseVisualStyleBackColor = false;
            this.button_exitsearchresults_bookingsystem.Visible = false;
            this.button_exitsearchresults_bookingsystem.Click += new System.EventHandler(this.button_exitsearchresults_bookingsystem_Click);
            // 
            // button_changechaletview_bookingsystem
            // 
            this.button_changechaletview_bookingsystem.BackColor = System.Drawing.Color.White;
            this.button_changechaletview_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_changechaletview_bookingsystem.Location = new System.Drawing.Point(140, 487);
            this.button_changechaletview_bookingsystem.Name = "button_changechaletview_bookingsystem";
            this.button_changechaletview_bookingsystem.Size = new System.Drawing.Size(156, 72);
            this.button_changechaletview_bookingsystem.TabIndex = 0;
            this.button_changechaletview_bookingsystem.TabStop = false;
            this.button_changechaletview_bookingsystem.Text = "Change Chalet View";
            this.button_changechaletview_bookingsystem.UseVisualStyleBackColor = false;
            this.button_changechaletview_bookingsystem.Click += new System.EventHandler(this.button_changechaletview_bookingsystem_Click);
            // 
            // checkbox_checkedout_bookingsystem
            // 
            this.checkbox_checkedout_bookingsystem.AutoCheck = false;
            this.checkbox_checkedout_bookingsystem.AutoSize = true;
            this.checkbox_checkedout_bookingsystem.Location = new System.Drawing.Point(253, 417);
            this.checkbox_checkedout_bookingsystem.Name = "checkbox_checkedout_bookingsystem";
            this.checkbox_checkedout_bookingsystem.Size = new System.Drawing.Size(15, 14);
            this.checkbox_checkedout_bookingsystem.TabIndex = 4;
            this.checkbox_checkedout_bookingsystem.TabStop = false;
            this.checkbox_checkedout_bookingsystem.UseVisualStyleBackColor = true;
            // 
            // text_bookingquery_bookingsystem
            // 
            this.text_bookingquery_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_bookingquery_bookingsystem.Location = new System.Drawing.Point(578, 42);
            this.text_bookingquery_bookingsystem.Name = "text_bookingquery_bookingsystem";
            this.text_bookingquery_bookingsystem.Size = new System.Drawing.Size(181, 31);
            this.text_bookingquery_bookingsystem.TabIndex = 0;
            this.text_bookingquery_bookingsystem.Enter += new System.EventHandler(this.text_bookingquery_bookingsystem_Enter);
            this.text_bookingquery_bookingsystem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_bookingquery_bookingsystem_KeyDown);
            this.text_bookingquery_bookingsystem.Leave += new System.EventHandler(this.text_bookingquery_bookingsystem_Leave);
            // 
            // text_registrationquery_bookingsystem
            // 
            this.text_registrationquery_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_registrationquery_bookingsystem.Location = new System.Drawing.Point(765, 42);
            this.text_registrationquery_bookingsystem.Name = "text_registrationquery_bookingsystem";
            this.text_registrationquery_bookingsystem.Size = new System.Drawing.Size(218, 31);
            this.text_registrationquery_bookingsystem.TabIndex = 2;
            this.text_registrationquery_bookingsystem.Enter += new System.EventHandler(this.text_registrationquery_bookingsystem_Enter);
            this.text_registrationquery_bookingsystem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_registrationquery_bookingsystem_KeyDown);
            this.text_registrationquery_bookingsystem.Leave += new System.EventHandler(this.text_registrationquery_bookingsystem_Leave);
            // 
            // button_home_bookingsystem
            // 
            this.button_home_bookingsystem.BackColor = System.Drawing.Color.White;
            this.button_home_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_home_bookingsystem.Location = new System.Drawing.Point(10, 10);
            this.button_home_bookingsystem.Name = "button_home_bookingsystem";
            this.button_home_bookingsystem.Size = new System.Drawing.Size(136, 136);
            this.button_home_bookingsystem.TabIndex = 0;
            this.button_home_bookingsystem.TabStop = false;
            this.button_home_bookingsystem.Text = "Home";
            this.button_home_bookingsystem.UseVisualStyleBackColor = false;
            this.button_home_bookingsystem.Click += new System.EventHandler(this.button_home_bookingsystem_Click);
            // 
            // checkbox_checkedin_bookingsystem
            // 
            this.checkbox_checkedin_bookingsystem.AutoCheck = false;
            this.checkbox_checkedin_bookingsystem.AutoSize = true;
            this.checkbox_checkedin_bookingsystem.Location = new System.Drawing.Point(62, 417);
            this.checkbox_checkedin_bookingsystem.Name = "checkbox_checkedin_bookingsystem";
            this.checkbox_checkedin_bookingsystem.Size = new System.Drawing.Size(15, 14);
            this.checkbox_checkedin_bookingsystem.TabIndex = 4;
            this.checkbox_checkedin_bookingsystem.TabStop = false;
            this.checkbox_checkedin_bookingsystem.UseVisualStyleBackColor = true;
            // 
            // label_bookingcheckedin_bookingsystem
            // 
            this.label_bookingcheckedin_bookingsystem.AutoSize = true;
            this.label_bookingcheckedin_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_bookingcheckedin_bookingsystem.ForeColor = System.Drawing.Color.White;
            this.label_bookingcheckedin_bookingsystem.Location = new System.Drawing.Point(5, 388);
            this.label_bookingcheckedin_bookingsystem.Name = "label_bookingcheckedin_bookingsystem";
            this.label_bookingcheckedin_bookingsystem.Size = new System.Drawing.Size(128, 26);
            this.label_bookingcheckedin_bookingsystem.TabIndex = 3;
            this.label_bookingcheckedin_bookingsystem.Text = "Checked In:";
            // 
            // label_bookingdeparturedate_bookingsystem
            // 
            this.label_bookingdeparturedate_bookingsystem.AutoSize = true;
            this.label_bookingdeparturedate_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_bookingdeparturedate_bookingsystem.ForeColor = System.Drawing.Color.White;
            this.label_bookingdeparturedate_bookingsystem.Location = new System.Drawing.Point(177, 331);
            this.label_bookingdeparturedate_bookingsystem.Name = "label_bookingdeparturedate_bookingsystem";
            this.label_bookingdeparturedate_bookingsystem.Size = new System.Drawing.Size(166, 26);
            this.label_bookingdeparturedate_bookingsystem.TabIndex = 3;
            this.label_bookingdeparturedate_bookingsystem.Text = "Departure Date:";
            // 
            // label_bookingarrivaldate_bookingsystem
            // 
            this.label_bookingarrivaldate_bookingsystem.AutoSize = true;
            this.label_bookingarrivaldate_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_bookingarrivaldate_bookingsystem.ForeColor = System.Drawing.Color.White;
            this.label_bookingarrivaldate_bookingsystem.Location = new System.Drawing.Point(3, 331);
            this.label_bookingarrivaldate_bookingsystem.Name = "label_bookingarrivaldate_bookingsystem";
            this.label_bookingarrivaldate_bookingsystem.Size = new System.Drawing.Size(132, 26);
            this.label_bookingarrivaldate_bookingsystem.TabIndex = 3;
            this.label_bookingarrivaldate_bookingsystem.Text = "Arrival Date:";
            // 
            // label_registrationsearch_bookingsystem
            // 
            this.label_registrationsearch_bookingsystem.AutoSize = true;
            this.label_registrationsearch_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_registrationsearch_bookingsystem.ForeColor = System.Drawing.Color.White;
            this.label_registrationsearch_bookingsystem.Location = new System.Drawing.Point(765, 14);
            this.label_registrationsearch_bookingsystem.Name = "label_registrationsearch_bookingsystem";
            this.label_registrationsearch_bookingsystem.Size = new System.Drawing.Size(218, 25);
            this.label_registrationsearch_bookingsystem.TabIndex = 1;
            this.label_registrationsearch_bookingsystem.Text = "Search Registrations:";
            // 
            // label_bookingsearch_bookingsystem
            // 
            this.label_bookingsearch_bookingsystem.AutoSize = true;
            this.label_bookingsearch_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_bookingsearch_bookingsystem.ForeColor = System.Drawing.Color.White;
            this.label_bookingsearch_bookingsystem.Location = new System.Drawing.Point(578, 14);
            this.label_bookingsearch_bookingsystem.Name = "label_bookingsearch_bookingsystem";
            this.label_bookingsearch_bookingsystem.Size = new System.Drawing.Size(181, 25);
            this.label_bookingsearch_bookingsystem.TabIndex = 1;
            this.label_bookingsearch_bookingsystem.Text = "Search Bookings:";
            // 
            // label_bookingcats_bookingsystem
            // 
            this.label_bookingcats_bookingsystem.AutoSize = true;
            this.label_bookingcats_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_bookingcats_bookingsystem.ForeColor = System.Drawing.Color.White;
            this.label_bookingcats_bookingsystem.Location = new System.Drawing.Point(144, 109);
            this.label_bookingcats_bookingsystem.Name = "label_bookingcats_bookingsystem";
            this.label_bookingcats_bookingsystem.Size = new System.Drawing.Size(63, 26);
            this.label_bookingcats_bookingsystem.TabIndex = 3;
            this.label_bookingcats_bookingsystem.Text = "Cats:";
            // 
            // label_bookingowners_bookingsystem
            // 
            this.label_bookingowners_bookingsystem.AutoSize = true;
            this.label_bookingowners_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_bookingowners_bookingsystem.ForeColor = System.Drawing.Color.White;
            this.label_bookingowners_bookingsystem.Location = new System.Drawing.Point(128, 27);
            this.label_bookingowners_bookingsystem.Name = "label_bookingowners_bookingsystem";
            this.label_bookingowners_bookingsystem.Size = new System.Drawing.Size(93, 26);
            this.label_bookingowners_bookingsystem.TabIndex = 3;
            this.label_bookingowners_bookingsystem.Text = "Owners:";
            // 
            // label_bookinginformation_bookingsystem
            // 
            this.label_bookinginformation_bookingsystem.AutoSize = true;
            this.label_bookinginformation_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_bookinginformation_bookingsystem.ForeColor = System.Drawing.Color.White;
            this.label_bookinginformation_bookingsystem.Location = new System.Drawing.Point(69, 1);
            this.label_bookinginformation_bookingsystem.Name = "label_bookinginformation_bookingsystem";
            this.label_bookinginformation_bookingsystem.Size = new System.Drawing.Size(212, 26);
            this.label_bookinginformation_bookingsystem.TabIndex = 3;
            this.label_bookinginformation_bookingsystem.Text = "Booking Information:";
            // 
            // listbox_selectedcats_bookingsystem
            // 
            this.listbox_selectedcats_bookingsystem.BackColor = System.Drawing.Color.Blue;
            this.listbox_selectedcats_bookingsystem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listbox_selectedcats_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listbox_selectedcats_bookingsystem.ForeColor = System.Drawing.Color.White;
            this.listbox_selectedcats_bookingsystem.FormattingEnabled = true;
            this.listbox_selectedcats_bookingsystem.ItemHeight = 25;
            this.listbox_selectedcats_bookingsystem.Location = new System.Drawing.Point(88, 138);
            this.listbox_selectedcats_bookingsystem.Name = "listbox_selectedcats_bookingsystem";
            this.listbox_selectedcats_bookingsystem.Size = new System.Drawing.Size(174, 100);
            this.listbox_selectedcats_bookingsystem.Sorted = true;
            this.listbox_selectedcats_bookingsystem.TabIndex = 2;
            this.listbox_selectedcats_bookingsystem.TabStop = false;
            // 
            // splitcontainer_bookinginformation_bookingsystem
            // 
            this.splitcontainer_bookinginformation_bookingsystem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitcontainer_bookinginformation_bookingsystem.Location = new System.Drawing.Point(0, 155);
            this.splitcontainer_bookinginformation_bookingsystem.Name = "splitcontainer_bookinginformation_bookingsystem";
            // 
            // splitcontainer_bookinginformation_bookingsystem.Panel1
            // 
            this.splitcontainer_bookinginformation_bookingsystem.Panel1.AutoScroll = true;
            this.splitcontainer_bookinginformation_bookingsystem.Panel1.BackColor = System.Drawing.Color.Blue;
            this.splitcontainer_bookinginformation_bookingsystem.Panel1.Controls.Add(this.button_undocheckinout_bookingsystem);
            this.splitcontainer_bookinginformation_bookingsystem.Panel1.Controls.Add(this.checkbox_checkedout_bookingsystem);
            this.splitcontainer_bookinginformation_bookingsystem.Panel1.Controls.Add(this.checkbox_checkedin_bookingsystem);
            this.splitcontainer_bookinginformation_bookingsystem.Panel1.Controls.Add(this.label_bookingcheckedout_bookingsystem);
            this.splitcontainer_bookinginformation_bookingsystem.Panel1.Controls.Add(this.label_bookingcheckedin_bookingsystem);
            this.splitcontainer_bookinginformation_bookingsystem.Panel1.Controls.Add(this.label_bookingdeparturedate_bookingsystem);
            this.splitcontainer_bookinginformation_bookingsystem.Panel1.Controls.Add(this.label_bookingarrivaldate_bookingsystem);
            this.splitcontainer_bookinginformation_bookingsystem.Panel1.Controls.Add(this.label_bookingcats_bookingsystem);
            this.splitcontainer_bookinginformation_bookingsystem.Panel1.Controls.Add(this.label_bookingowners_bookingsystem);
            this.splitcontainer_bookinginformation_bookingsystem.Panel1.Controls.Add(this.label_bookinginformation_bookingsystem);
            this.splitcontainer_bookinginformation_bookingsystem.Panel1.Controls.Add(this.listbox_selectedcats_bookingsystem);
            this.splitcontainer_bookinginformation_bookingsystem.Panel1.Controls.Add(this.listbox_selectedowners_bookingsystem);
            this.splitcontainer_bookinginformation_bookingsystem.Panel1.Controls.Add(this.text_departuredateextrainfo_bookingsystem);
            this.splitcontainer_bookinginformation_bookingsystem.Panel1.Controls.Add(this.text_arrivaldateextrainfo_bookingsystem);
            this.splitcontainer_bookinginformation_bookingsystem.Panel1.Controls.Add(this.button_holdbooking_bookingsystem);
            this.splitcontainer_bookinginformation_bookingsystem.Panel1.Controls.Add(this.button_deletebooking_bookingsystem);
            this.splitcontainer_bookinginformation_bookingsystem.Panel1.Controls.Add(this.button_exitbookinginfo_bookingsystem);
            this.splitcontainer_bookinginformation_bookingsystem.Panel1.Controls.Add(this.button_editbooking_bookingsystem);
            this.splitcontainer_bookinginformation_bookingsystem.Panel1.Controls.Add(this.button_checkinout_bookingsystem);
            this.splitcontainer_bookinginformation_bookingsystem.Panel1.Controls.Add(this.button_viewregistrationrecord_bookingsystem);
            this.splitcontainer_bookinginformation_bookingsystem.Panel1Collapsed = true;
            // 
            // splitcontainer_bookinginformation_bookingsystem.Panel2
            // 
            this.splitcontainer_bookinginformation_bookingsystem.Panel2.Controls.Add(this.splitcontainer_bookingcalender_bookingsystem);
            this.splitcontainer_bookinginformation_bookingsystem.Size = new System.Drawing.Size(1366, 573);
            this.splitcontainer_bookinginformation_bookingsystem.SplitterDistance = 350;
            this.splitcontainer_bookinginformation_bookingsystem.SplitterWidth = 2;
            this.splitcontainer_bookinginformation_bookingsystem.TabIndex = 13;
            this.splitcontainer_bookinginformation_bookingsystem.TabStop = false;
            // 
            // button_undocheckinout_bookingsystem
            // 
            this.button_undocheckinout_bookingsystem.BackColor = System.Drawing.Color.White;
            this.button_undocheckinout_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_undocheckinout_bookingsystem.Location = new System.Drawing.Point(208, 445);
            this.button_undocheckinout_bookingsystem.Name = "button_undocheckinout_bookingsystem";
            this.button_undocheckinout_bookingsystem.Size = new System.Drawing.Size(78, 36);
            this.button_undocheckinout_bookingsystem.TabIndex = 5;
            this.button_undocheckinout_bookingsystem.TabStop = false;
            this.button_undocheckinout_bookingsystem.Text = "Undo";
            this.button_undocheckinout_bookingsystem.UseVisualStyleBackColor = false;
            this.button_undocheckinout_bookingsystem.Click += new System.EventHandler(this.button_undocheckinout_bookingsystem_Click);
            // 
            // listbox_selectedowners_bookingsystem
            // 
            this.listbox_selectedowners_bookingsystem.BackColor = System.Drawing.Color.Blue;
            this.listbox_selectedowners_bookingsystem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listbox_selectedowners_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listbox_selectedowners_bookingsystem.ForeColor = System.Drawing.Color.White;
            this.listbox_selectedowners_bookingsystem.FormattingEnabled = true;
            this.listbox_selectedowners_bookingsystem.ItemHeight = 25;
            this.listbox_selectedowners_bookingsystem.Location = new System.Drawing.Point(88, 56);
            this.listbox_selectedowners_bookingsystem.Name = "listbox_selectedowners_bookingsystem";
            this.listbox_selectedowners_bookingsystem.Size = new System.Drawing.Size(174, 50);
            this.listbox_selectedowners_bookingsystem.Sorted = true;
            this.listbox_selectedowners_bookingsystem.TabIndex = 2;
            this.listbox_selectedowners_bookingsystem.TabStop = false;
            // 
            // text_departuredateextrainfo_bookingsystem
            // 
            this.text_departuredateextrainfo_bookingsystem.BackColor = System.Drawing.Color.Blue;
            this.text_departuredateextrainfo_bookingsystem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_departuredateextrainfo_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_departuredateextrainfo_bookingsystem.ForeColor = System.Drawing.Color.White;
            this.text_departuredateextrainfo_bookingsystem.Location = new System.Drawing.Point(210, 360);
            this.text_departuredateextrainfo_bookingsystem.Name = "text_departuredateextrainfo_bookingsystem";
            this.text_departuredateextrainfo_bookingsystem.ReadOnly = true;
            this.text_departuredateextrainfo_bookingsystem.Size = new System.Drawing.Size(110, 25);
            this.text_departuredateextrainfo_bookingsystem.TabIndex = 1;
            this.text_departuredateextrainfo_bookingsystem.TabStop = false;
            this.text_departuredateextrainfo_bookingsystem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // text_arrivaldateextrainfo_bookingsystem
            // 
            this.text_arrivaldateextrainfo_bookingsystem.BackColor = System.Drawing.Color.Blue;
            this.text_arrivaldateextrainfo_bookingsystem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_arrivaldateextrainfo_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_arrivaldateextrainfo_bookingsystem.ForeColor = System.Drawing.Color.White;
            this.text_arrivaldateextrainfo_bookingsystem.Location = new System.Drawing.Point(19, 360);
            this.text_arrivaldateextrainfo_bookingsystem.Name = "text_arrivaldateextrainfo_bookingsystem";
            this.text_arrivaldateextrainfo_bookingsystem.ReadOnly = true;
            this.text_arrivaldateextrainfo_bookingsystem.Size = new System.Drawing.Size(110, 25);
            this.text_arrivaldateextrainfo_bookingsystem.TabIndex = 1;
            this.text_arrivaldateextrainfo_bookingsystem.TabStop = false;
            this.text_arrivaldateextrainfo_bookingsystem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_holdbooking_bookingsystem
            // 
            this.button_holdbooking_bookingsystem.BackColor = System.Drawing.Color.White;
            this.button_holdbooking_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_holdbooking_bookingsystem.Location = new System.Drawing.Point(177, 565);
            this.button_holdbooking_bookingsystem.Name = "button_holdbooking_bookingsystem";
            this.button_holdbooking_bookingsystem.Size = new System.Drawing.Size(156, 72);
            this.button_holdbooking_bookingsystem.TabIndex = 0;
            this.button_holdbooking_bookingsystem.TabStop = false;
            this.button_holdbooking_bookingsystem.Text = "Hold Booking";
            this.button_holdbooking_bookingsystem.UseVisualStyleBackColor = false;
            this.button_holdbooking_bookingsystem.Click += new System.EventHandler(this.button_holdbooking_bookingsystem_Click);
            // 
            // button_deletebooking_bookingsystem
            // 
            this.button_deletebooking_bookingsystem.BackColor = System.Drawing.Color.White;
            this.button_deletebooking_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_deletebooking_bookingsystem.Location = new System.Drawing.Point(3, 565);
            this.button_deletebooking_bookingsystem.Name = "button_deletebooking_bookingsystem";
            this.button_deletebooking_bookingsystem.Size = new System.Drawing.Size(168, 72);
            this.button_deletebooking_bookingsystem.TabIndex = 0;
            this.button_deletebooking_bookingsystem.TabStop = false;
            this.button_deletebooking_bookingsystem.Text = "Delete Booking Record";
            this.button_deletebooking_bookingsystem.UseVisualStyleBackColor = false;
            this.button_deletebooking_bookingsystem.Click += new System.EventHandler(this.button_deletebooking_bookingsystem_Click);
            // 
            // button_exitbookinginfo_bookingsystem
            // 
            this.button_exitbookinginfo_bookingsystem.BackColor = System.Drawing.Color.White;
            this.button_exitbookinginfo_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_exitbookinginfo_bookingsystem.Location = new System.Drawing.Point(184, 487);
            this.button_exitbookinginfo_bookingsystem.Name = "button_exitbookinginfo_bookingsystem";
            this.button_exitbookinginfo_bookingsystem.Size = new System.Drawing.Size(156, 72);
            this.button_exitbookinginfo_bookingsystem.TabIndex = 0;
            this.button_exitbookinginfo_bookingsystem.TabStop = false;
            this.button_exitbookinginfo_bookingsystem.Text = "Exit Booking Information";
            this.button_exitbookinginfo_bookingsystem.UseVisualStyleBackColor = false;
            this.button_exitbookinginfo_bookingsystem.Click += new System.EventHandler(this.button_exitbookinginfo_bookingsystem_Click);
            // 
            // button_editbooking_bookingsystem
            // 
            this.button_editbooking_bookingsystem.BackColor = System.Drawing.Color.White;
            this.button_editbooking_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_editbooking_bookingsystem.Location = new System.Drawing.Point(3, 487);
            this.button_editbooking_bookingsystem.Name = "button_editbooking_bookingsystem";
            this.button_editbooking_bookingsystem.Size = new System.Drawing.Size(156, 72);
            this.button_editbooking_bookingsystem.TabIndex = 0;
            this.button_editbooking_bookingsystem.TabStop = false;
            this.button_editbooking_bookingsystem.Text = "Edit Booking Record";
            this.button_editbooking_bookingsystem.UseVisualStyleBackColor = false;
            this.button_editbooking_bookingsystem.Click += new System.EventHandler(this.button_editbooking_bookingsystem_Click);
            // 
            // button_checkinout_bookingsystem
            // 
            this.button_checkinout_bookingsystem.BackColor = System.Drawing.Color.White;
            this.button_checkinout_bookingsystem.Enabled = false;
            this.button_checkinout_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_checkinout_bookingsystem.Location = new System.Drawing.Point(54, 445);
            this.button_checkinout_bookingsystem.Name = "button_checkinout_bookingsystem";
            this.button_checkinout_bookingsystem.Size = new System.Drawing.Size(148, 36);
            this.button_checkinout_bookingsystem.TabIndex = 0;
            this.button_checkinout_bookingsystem.TabStop = false;
            this.button_checkinout_bookingsystem.Text = "Check In/Out";
            this.button_checkinout_bookingsystem.UseVisualStyleBackColor = false;
            this.button_checkinout_bookingsystem.Click += new System.EventHandler(this.button_checkinout_bookingsystem_Click);
            // 
            // button_viewregistrationrecord_bookingsystem
            // 
            this.button_viewregistrationrecord_bookingsystem.BackColor = System.Drawing.Color.White;
            this.button_viewregistrationrecord_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_viewregistrationrecord_bookingsystem.Location = new System.Drawing.Point(78, 260);
            this.button_viewregistrationrecord_bookingsystem.Name = "button_viewregistrationrecord_bookingsystem";
            this.button_viewregistrationrecord_bookingsystem.Size = new System.Drawing.Size(194, 68);
            this.button_viewregistrationrecord_bookingsystem.TabIndex = 0;
            this.button_viewregistrationrecord_bookingsystem.TabStop = false;
            this.button_viewregistrationrecord_bookingsystem.Text = "View Registration Record";
            this.button_viewregistrationrecord_bookingsystem.UseVisualStyleBackColor = false;
            this.button_viewregistrationrecord_bookingsystem.Click += new System.EventHandler(this.button_viewregistrationrecord_bookingsystem_Click);
            // 
            // splitcontainer_bookingcalender_bookingsystem
            // 
            this.splitcontainer_bookingcalender_bookingsystem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitcontainer_bookingcalender_bookingsystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitcontainer_bookingcalender_bookingsystem.Location = new System.Drawing.Point(0, 0);
            this.splitcontainer_bookingcalender_bookingsystem.Name = "splitcontainer_bookingcalender_bookingsystem";
            // 
            // splitcontainer_bookingcalender_bookingsystem.Panel1
            // 
            this.splitcontainer_bookingcalender_bookingsystem.Panel1.AutoScroll = true;
            this.splitcontainer_bookingcalender_bookingsystem.Panel1.Controls.Add(this.tableLayoutPanel_datetimepickers_bookinsystem);
            this.splitcontainer_bookingcalender_bookingsystem.Panel1.Controls.Add(this.panel_bookingcalender_bookingsystem);
            this.splitcontainer_bookingcalender_bookingsystem.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitcontainer_bookingcalender_bookingsystem_Panel1_Paint);
            // 
            // splitcontainer_bookingcalender_bookingsystem.Panel2
            // 
            this.splitcontainer_bookingcalender_bookingsystem.Panel2.AutoScroll = true;
            this.splitcontainer_bookingcalender_bookingsystem.Panel2.BackColor = System.Drawing.Color.Blue;
            this.splitcontainer_bookingcalender_bookingsystem.Panel2.Controls.Add(this.checkedlistbox_chaletsshown_bookingsystem);
            this.splitcontainer_bookingcalender_bookingsystem.Panel2.Controls.Add(this.listbox_bookingqueryresult_bookingsystem);
            this.splitcontainer_bookingcalender_bookingsystem.Panel2.Controls.Add(this.text_changeviewqueryresults_bookingsystem);
            this.splitcontainer_bookingcalender_bookingsystem.Panel2.Controls.Add(this.button_exitsearchresults_bookingsystem);
            this.splitcontainer_bookingcalender_bookingsystem.Panel2.Controls.Add(this.button_changechaletview_bookingsystem);
            this.splitcontainer_bookingcalender_bookingsystem.Panel2Collapsed = true;
            this.splitcontainer_bookingcalender_bookingsystem.Size = new System.Drawing.Size(1366, 573);
            this.splitcontainer_bookingcalender_bookingsystem.SplitterDistance = 900;
            this.splitcontainer_bookingcalender_bookingsystem.SplitterWidth = 2;
            this.splitcontainer_bookingcalender_bookingsystem.TabIndex = 0;
            this.splitcontainer_bookingcalender_bookingsystem.TabStop = false;
            // 
            // tableLayoutPanel_datetimepickers_bookinsystem
            // 
            this.tableLayoutPanel_datetimepickers_bookinsystem.AutoSize = true;
            this.tableLayoutPanel_datetimepickers_bookinsystem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel_datetimepickers_bookinsystem.ColumnCount = 8;
            this.tableLayoutPanel_datetimepickers_bookinsystem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel_datetimepickers_bookinsystem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel_datetimepickers_bookinsystem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel_datetimepickers_bookinsystem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel_datetimepickers_bookinsystem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel_datetimepickers_bookinsystem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel_datetimepickers_bookinsystem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel_datetimepickers_bookinsystem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel_datetimepickers_bookinsystem.Controls.Add(this.datetimepicker_bookingdate7_bookingsystem, 7, 0);
            this.tableLayoutPanel_datetimepickers_bookinsystem.Controls.Add(this.datetimepicker_bookingdate6_bookingsystem, 6, 0);
            this.tableLayoutPanel_datetimepickers_bookinsystem.Controls.Add(this.datetimepicker_bookingdate2_bookingsystem, 2, 0);
            this.tableLayoutPanel_datetimepickers_bookinsystem.Controls.Add(this.datetimepicker_bookingdate5_bookingsystem, 5, 0);
            this.tableLayoutPanel_datetimepickers_bookinsystem.Controls.Add(this.datetimepicker_bookingdate3_bookingsystem, 3, 0);
            this.tableLayoutPanel_datetimepickers_bookinsystem.Controls.Add(this.datetimepicker_bookingdate4_bookingsystem, 4, 0);
            this.tableLayoutPanel_datetimepickers_bookinsystem.Controls.Add(this.button_view_bookingsystem, 0, 0);
            this.tableLayoutPanel_datetimepickers_bookinsystem.Controls.Add(this.datetimepicker_bookingdate1_bookingsystem, 1, 0);
            this.tableLayoutPanel_datetimepickers_bookinsystem.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_datetimepickers_bookinsystem.Name = "tableLayoutPanel_datetimepickers_bookinsystem";
            this.tableLayoutPanel_datetimepickers_bookinsystem.RowCount = 1;
            this.tableLayoutPanel_datetimepickers_bookinsystem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel_datetimepickers_bookinsystem.Size = new System.Drawing.Size(1336, 68);
            this.tableLayoutPanel_datetimepickers_bookinsystem.TabIndex = 1;
            // 
            // datetimepicker_bookingdate7_bookingsystem
            // 
            this.datetimepicker_bookingdate7_bookingsystem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.datetimepicker_bookingdate7_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datetimepicker_bookingdate7_bookingsystem.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datetimepicker_bookingdate7_bookingsystem.Location = new System.Drawing.Point(1172, 18);
            this.datetimepicker_bookingdate7_bookingsystem.Name = "datetimepicker_bookingdate7_bookingsystem";
            this.datetimepicker_bookingdate7_bookingsystem.Size = new System.Drawing.Size(161, 32);
            this.datetimepicker_bookingdate7_bookingsystem.TabIndex = 93;
            this.datetimepicker_bookingdate7_bookingsystem.TabStop = false;
            this.datetimepicker_bookingdate7_bookingsystem.ValueChanged += new System.EventHandler(this.datetimepicker_bookingdate7_bookingsystem_ValueChanged);
            // 
            // panel_bookingcalender_bookingsystem
            // 
            this.panel_bookingcalender_bookingsystem.AutoScroll = true;
            this.panel_bookingcalender_bookingsystem.AutoScrollMinSize = new System.Drawing.Size(1335, 460);
            this.panel_bookingcalender_bookingsystem.Controls.Add(this.tablelayoutpanel_bookingcalender_bookingsystem);
            this.panel_bookingcalender_bookingsystem.Location = new System.Drawing.Point(0, 68);
            this.panel_bookingcalender_bookingsystem.Name = "panel_bookingcalender_bookingsystem";
            this.panel_bookingcalender_bookingsystem.Size = new System.Drawing.Size(1358, 481);
            this.panel_bookingcalender_bookingsystem.TabIndex = 94;
            this.panel_bookingcalender_bookingsystem.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_bookingcalender_bookingsystem_Paint);
            // 
            // tablelayoutpanel_bookingcalender_bookingsystem
            // 
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
            // 
            // button_searchregistrations_bookingsystem
            // 
            this.button_searchregistrations_bookingsystem.BackColor = System.Drawing.Color.White;
            this.button_searchregistrations_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_searchregistrations_bookingsystem.Location = new System.Drawing.Point(765, 79);
            this.button_searchregistrations_bookingsystem.Name = "button_searchregistrations_bookingsystem";
            this.button_searchregistrations_bookingsystem.Size = new System.Drawing.Size(218, 64);
            this.button_searchregistrations_bookingsystem.TabIndex = 3;
            this.button_searchregistrations_bookingsystem.Text = "Search Registration System";
            this.button_searchregistrations_bookingsystem.UseVisualStyleBackColor = false;
            this.button_searchregistrations_bookingsystem.Click += new System.EventHandler(this.button_searchregistrations_bookingsystem_Click);
            // 
            // button_closeform_bookingsystem
            // 
            this.button_closeform_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_closeform_bookingsystem.Location = new System.Drawing.Point(1287, 3);
            this.button_closeform_bookingsystem.Name = "button_closeform_bookingsystem";
            this.button_closeform_bookingsystem.Size = new System.Drawing.Size(57, 36);
            this.button_closeform_bookingsystem.TabIndex = 5;
            this.button_closeform_bookingsystem.TabStop = false;
            this.button_closeform_bookingsystem.Text = "Exit";
            this.button_closeform_bookingsystem.UseVisualStyleBackColor = true;
            this.button_closeform_bookingsystem.Click += new System.EventHandler(this.button_closeform_bookingsystem_Click);
            // 
            // timer_bookingsystem
            // 
            this.timer_bookingsystem.Enabled = true;
            this.timer_bookingsystem.Interval = 10;
            this.timer_bookingsystem.Tick += new System.EventHandler(this.timer_bookingsystem_Tick);
            // 
            // button_goback_bookingsystem
            // 
            this.button_goback_bookingsystem.Enabled = false;
            this.button_goback_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_goback_bookingsystem.Location = new System.Drawing.Point(1134, 3);
            this.button_goback_bookingsystem.Name = "button_goback_bookingsystem";
            this.button_goback_bookingsystem.Size = new System.Drawing.Size(105, 36);
            this.button_goback_bookingsystem.TabIndex = 6;
            this.button_goback_bookingsystem.TabStop = false;
            this.button_goback_bookingsystem.Text = "Go Back";
            this.button_goback_bookingsystem.UseVisualStyleBackColor = true;
            this.button_goback_bookingsystem.Visible = false;
            this.button_goback_bookingsystem.Click += new System.EventHandler(this.button_goback_bookingsystem_Click);
            // 
            // picturebox_logo_regstrationsystem
            // 
            this.picturebox_logo_regstrationsystem.Image = ((System.Drawing.Image)(resources.GetObject("picturebox_logo_regstrationsystem.Image")));
            this.picturebox_logo_regstrationsystem.Location = new System.Drawing.Point(996, 60);
            this.picturebox_logo_regstrationsystem.Name = "picturebox_logo_regstrationsystem";
            this.picturebox_logo_regstrationsystem.Size = new System.Drawing.Size(362, 38);
            this.picturebox_logo_regstrationsystem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturebox_logo_regstrationsystem.TabIndex = 12;
            this.picturebox_logo_regstrationsystem.TabStop = false;
            // 
            // button_addnewbooking_bookingsystem
            // 
            this.button_addnewbooking_bookingsystem.BackColor = System.Drawing.Color.White;
            this.button_addnewbooking_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_addnewbooking_bookingsystem.Location = new System.Drawing.Point(152, 10);
            this.button_addnewbooking_bookingsystem.Name = "button_addnewbooking_bookingsystem";
            this.button_addnewbooking_bookingsystem.Size = new System.Drawing.Size(136, 136);
            this.button_addnewbooking_bookingsystem.TabIndex = 8;
            this.button_addnewbooking_bookingsystem.TabStop = false;
            this.button_addnewbooking_bookingsystem.Text = "Add New Booking";
            this.button_addnewbooking_bookingsystem.UseVisualStyleBackColor = false;
            this.button_addnewbooking_bookingsystem.Click += new System.EventHandler(this.button_addnewbooking_bookingsystem_Click);
            // 
            // panel_banner_bookingsystem
            // 
            this.panel_banner_bookingsystem.BackColor = System.Drawing.Color.Blue;
            this.panel_banner_bookingsystem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_banner_bookingsystem.Controls.Add(this.label_titlebookingsystem);
            this.panel_banner_bookingsystem.Controls.Add(this.button_minusoneday_bookingsystem);
            this.panel_banner_bookingsystem.Controls.Add(this.button_plusoneday_bookingsystem);
            this.panel_banner_bookingsystem.Controls.Add(this.picturebox_logo_regstrationsystem);
            this.panel_banner_bookingsystem.Controls.Add(this.button_addnewbooking_bookingsystem);
            this.panel_banner_bookingsystem.Controls.Add(this.button_registrations_bookingsystem);
            this.panel_banner_bookingsystem.Controls.Add(this.button_goback_bookingsystem);
            this.panel_banner_bookingsystem.Controls.Add(this.button_minimizeform_bookingsystem);
            this.panel_banner_bookingsystem.Controls.Add(this.button_closeform_bookingsystem);
            this.panel_banner_bookingsystem.Controls.Add(this.button_searchregistrations_bookingsystem);
            this.panel_banner_bookingsystem.Controls.Add(this.button_searchbookings_bookingsystem);
            this.panel_banner_bookingsystem.Controls.Add(this.text_registrationquery_bookingsystem);
            this.panel_banner_bookingsystem.Controls.Add(this.text_bookingquery_bookingsystem);
            this.panel_banner_bookingsystem.Controls.Add(this.label_registrationsearch_bookingsystem);
            this.panel_banner_bookingsystem.Controls.Add(this.label_bookingsearch_bookingsystem);
            this.panel_banner_bookingsystem.Controls.Add(this.button_home_bookingsystem);
            this.panel_banner_bookingsystem.Location = new System.Drawing.Point(0, 0);
            this.panel_banner_bookingsystem.Name = "panel_banner_bookingsystem";
            this.panel_banner_bookingsystem.Size = new System.Drawing.Size(1366, 155);
            this.panel_banner_bookingsystem.TabIndex = 12;
            // 
            // label_titlebookingsystem
            // 
            this.label_titlebookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_titlebookingsystem.ForeColor = System.Drawing.Color.White;
            this.label_titlebookingsystem.Location = new System.Drawing.Point(1021, 101);
            this.label_titlebookingsystem.Name = "label_titlebookingsystem";
            this.label_titlebookingsystem.Size = new System.Drawing.Size(264, 42);
            this.label_titlebookingsystem.TabIndex = 14;
            this.label_titlebookingsystem.Text = "Booking System";
            this.label_titlebookingsystem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_minusoneday_bookingsystem
            // 
            this.button_minusoneday_bookingsystem.BackColor = System.Drawing.Color.White;
            this.button_minusoneday_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_minusoneday_bookingsystem.Location = new System.Drawing.Point(1291, 115);
            this.button_minusoneday_bookingsystem.Name = "button_minusoneday_bookingsystem";
            this.button_minusoneday_bookingsystem.Size = new System.Drawing.Size(31, 33);
            this.button_minusoneday_bookingsystem.TabIndex = 13;
            this.button_minusoneday_bookingsystem.TabStop = false;
            this.button_minusoneday_bookingsystem.Text = "◄";
            this.button_minusoneday_bookingsystem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_minusoneday_bookingsystem.UseVisualStyleBackColor = false;
            this.button_minusoneday_bookingsystem.Click += new System.EventHandler(this.button_minusoneday_bookingsystem_Click);
            // 
            // button_plusoneday_bookingsystem
            // 
            this.button_plusoneday_bookingsystem.BackColor = System.Drawing.Color.White;
            this.button_plusoneday_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_plusoneday_bookingsystem.Location = new System.Drawing.Point(1328, 115);
            this.button_plusoneday_bookingsystem.Name = "button_plusoneday_bookingsystem";
            this.button_plusoneday_bookingsystem.Size = new System.Drawing.Size(31, 33);
            this.button_plusoneday_bookingsystem.TabIndex = 13;
            this.button_plusoneday_bookingsystem.TabStop = false;
            this.button_plusoneday_bookingsystem.Text = "►";
            this.button_plusoneday_bookingsystem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_plusoneday_bookingsystem.UseVisualStyleBackColor = false;
            this.button_plusoneday_bookingsystem.Click += new System.EventHandler(this.button_plusoneday_bookingsystem_Click);
            // 
            // button_registrations_bookingsystem
            // 
            this.button_registrations_bookingsystem.BackColor = System.Drawing.Color.White;
            this.button_registrations_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_registrations_bookingsystem.Location = new System.Drawing.Point(294, 10);
            this.button_registrations_bookingsystem.Name = "button_registrations_bookingsystem";
            this.button_registrations_bookingsystem.Size = new System.Drawing.Size(136, 136);
            this.button_registrations_bookingsystem.TabIndex = 0;
            this.button_registrations_bookingsystem.TabStop = false;
            this.button_registrations_bookingsystem.Text = "Registration System";
            this.button_registrations_bookingsystem.UseVisualStyleBackColor = false;
            this.button_registrations_bookingsystem.Click += new System.EventHandler(this.button_registrations_bookingsystem_Click);
            // 
            // button_minimizeform_bookingsystem
            // 
            this.button_minimizeform_bookingsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_minimizeform_bookingsystem.Location = new System.Drawing.Point(1245, 3);
            this.button_minimizeform_bookingsystem.Name = "button_minimizeform_bookingsystem";
            this.button_minimizeform_bookingsystem.Size = new System.Drawing.Size(36, 36);
            this.button_minimizeform_bookingsystem.TabIndex = 5;
            this.button_minimizeform_bookingsystem.TabStop = false;
            this.button_minimizeform_bookingsystem.Text = "_";
            this.button_minimizeform_bookingsystem.UseVisualStyleBackColor = true;
            this.button_minimizeform_bookingsystem.Click += new System.EventHandler(this.button_minimizeform_bookingsystem_Click);
            // 
            // form_bookingsystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1362, 728);
            this.Controls.Add(this.splitcontainer_bookinginformation_bookingsystem);
            this.Controls.Add(this.panel_banner_bookingsystem);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "form_bookingsystem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chichester Cattery Booking System : Booking System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.form_bookingsystem_Activated);
            this.Load += new System.EventHandler(this.form_bookingsystem_Load);
            this.splitcontainer_bookinginformation_bookingsystem.Panel1.ResumeLayout(false);
            this.splitcontainer_bookinginformation_bookingsystem.Panel1.PerformLayout();
            this.splitcontainer_bookinginformation_bookingsystem.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitcontainer_bookinginformation_bookingsystem)).EndInit();
            this.splitcontainer_bookinginformation_bookingsystem.ResumeLayout(false);
            this.splitcontainer_bookingcalender_bookingsystem.Panel1.ResumeLayout(false);
            this.splitcontainer_bookingcalender_bookingsystem.Panel1.PerformLayout();
            this.splitcontainer_bookingcalender_bookingsystem.Panel2.ResumeLayout(false);
            this.splitcontainer_bookingcalender_bookingsystem.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitcontainer_bookingcalender_bookingsystem)).EndInit();
            this.splitcontainer_bookingcalender_bookingsystem.ResumeLayout(false);
            this.tableLayoutPanel_datetimepickers_bookinsystem.ResumeLayout(false);
            this.panel_bookingcalender_bookingsystem.ResumeLayout(false);
            this.panel_bookingcalender_bookingsystem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_logo_regstrationsystem)).EndInit();
            this.panel_banner_bookingsystem.ResumeLayout(false);
            this.panel_banner_bookingsystem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedlistbox_chaletsshown_bookingsystem;
        private System.Windows.Forms.DateTimePicker datetimepicker_bookingdate6_bookingsystem;
        private System.Windows.Forms.Button button_view_bookingsystem;
        private System.Windows.Forms.DateTimePicker datetimepicker_bookingdate2_bookingsystem;
        private System.Windows.Forms.DateTimePicker datetimepicker_bookingdate3_bookingsystem;
        private System.Windows.Forms.DateTimePicker datetimepicker_bookingdate4_bookingsystem;
        private System.Windows.Forms.DateTimePicker datetimepicker_bookingdate5_bookingsystem;
        private System.Windows.Forms.ListBox listbox_bookingqueryresult_bookingsystem;
        private System.Windows.Forms.Button button_searchbookings_bookingsystem;
        private System.Windows.Forms.TextBox text_changeviewqueryresults_bookingsystem;
        private System.Windows.Forms.Label label_bookingcheckedout_bookingsystem;
        private System.Windows.Forms.Button button_exitsearchresults_bookingsystem;
        private System.Windows.Forms.Button button_changechaletview_bookingsystem;
        private System.Windows.Forms.CheckBox checkbox_checkedout_bookingsystem;
        private System.Windows.Forms.TextBox text_bookingquery_bookingsystem;
        private System.Windows.Forms.TextBox text_registrationquery_bookingsystem;
        private System.Windows.Forms.Button button_home_bookingsystem;
        private System.Windows.Forms.CheckBox checkbox_checkedin_bookingsystem;
        private System.Windows.Forms.Label label_bookingcheckedin_bookingsystem;
        private System.Windows.Forms.Label label_bookingdeparturedate_bookingsystem;
        private System.Windows.Forms.Label label_bookingarrivaldate_bookingsystem;
        private System.Windows.Forms.Label label_registrationsearch_bookingsystem;
        private System.Windows.Forms.Label label_bookingsearch_bookingsystem;
        private System.Windows.Forms.Label label_bookingcats_bookingsystem;
        private System.Windows.Forms.Label label_bookingowners_bookingsystem;
        private System.Windows.Forms.Label label_bookinginformation_bookingsystem;
        private System.Windows.Forms.ListBox listbox_selectedcats_bookingsystem;
        private System.Windows.Forms.ListBox listbox_selectedowners_bookingsystem;
        private System.Windows.Forms.TextBox text_departuredateextrainfo_bookingsystem;
        private System.Windows.Forms.TextBox text_arrivaldateextrainfo_bookingsystem;
        private System.Windows.Forms.Button button_deletebooking_bookingsystem;
        private System.Windows.Forms.Button button_exitbookinginfo_bookingsystem;
        private System.Windows.Forms.Button button_editbooking_bookingsystem;
        private System.Windows.Forms.Button button_checkinout_bookingsystem;
        private System.Windows.Forms.Button button_viewregistrationrecord_bookingsystem;
        private System.Windows.Forms.SplitContainer splitcontainer_bookingcalender_bookingsystem;
        private System.Windows.Forms.Button button_searchregistrations_bookingsystem;
        private System.Windows.Forms.Button button_closeform_bookingsystem;
        private System.Windows.Forms.Timer timer_bookingsystem;
        private System.Windows.Forms.Button button_goback_bookingsystem;
        private System.Windows.Forms.PictureBox picturebox_logo_regstrationsystem;
        private System.Windows.Forms.Button button_addnewbooking_bookingsystem;
        private System.Windows.Forms.Panel panel_banner_bookingsystem;
        private System.Windows.Forms.Button button_registrations_bookingsystem;
        private System.Windows.Forms.Button button_minimizeform_bookingsystem;
        private DateTimePicker datetimepicker_bookingdate7_bookingsystem;
        private TableLayoutPanel tablelayoutpanel_bookingcalender_bookingsystem;
        private Panel panel_bookingcalender_bookingsystem;
        private TableLayoutPanel tableLayoutPanel_datetimepickers_bookinsystem;
        private DateTimePicker datetimepicker_bookingdate1_bookingsystem;
        private Button button_minusoneday_bookingsystem;
        private Button button_plusoneday_bookingsystem;
        private Button button_undocheckinout_bookingsystem;
        private SplitContainer splitcontainer_bookinginformation_bookingsystem;
        private Label label_titlebookingsystem;
        private Button button_holdbooking_bookingsystem;
    }
}