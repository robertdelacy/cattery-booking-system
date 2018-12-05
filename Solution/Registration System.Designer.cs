using System.Windows.Forms;
using Global;

namespace Solution
{
    partial class form_registrationsystem
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
            MyGlobalClass.registrationquery = new string[0, 0];
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
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_registrationsystem));
            this.label_extrainfo_registrationsystem = new System.Windows.Forms.Label();
            this.label_registrationpastbookings_registrationsystem = new System.Windows.Forms.Label();
            this.button_goback_registrationsystem = new System.Windows.Forms.Button();
            this.listbox_registrationpastbookings_registrationsystem = new System.Windows.Forms.ListBox();
            this.text_extrainfo_registrationsystem = new System.Windows.Forms.TextBox();
            this.splitcontainer_registrationinfo_registrationsystem = new System.Windows.Forms.SplitContainer();
            this.text_multilineallinfo_regstrationsystem = new System.Windows.Forms.TextBox();
            this.label_registrationinformation_regstrationsystem = new System.Windows.Forms.Label();
            this.button_viewbooking_registrationsystem = new System.Windows.Forms.Button();
            this.button_deleteregistration_regstrationsystem = new System.Windows.Forms.Button();
            this.button_editregistration_registrationsystem = new System.Windows.Forms.Button();
            this.listbox_registrationslist_regstrationsystem = new System.Windows.Forms.ListBox();
            this.label_registrations_regstrationsystem = new System.Windows.Forms.Label();
            this.button_addnewregistration_registrationsystem = new System.Windows.Forms.Button();
            this.button_exitsearchresults_registrationsystem = new System.Windows.Forms.Button();
            this.splitcontainer_registrationsearch_registrationsystem = new System.Windows.Forms.SplitContainer();
            this.listbox_registrationqueryreult_regstrationsystem = new System.Windows.Forms.ListBox();
            this.text_registrationqueryresult_regstrationsystem = new System.Windows.Forms.TextBox();
            this.button_addnewbooking_registrationsystem = new System.Windows.Forms.Button();
            this.button_bookings_registrationsystem = new System.Windows.Forms.Button();
            this.button_minimizeform_registrationsystem = new System.Windows.Forms.Button();
            this.panel_banner_registrationsystem = new System.Windows.Forms.Panel();
            this.label_titleRegistrationSystem = new System.Windows.Forms.Label();
            this.button_closeform_registrationsystem = new System.Windows.Forms.Button();
            this.picturebox_logo_regstrationsystem = new System.Windows.Forms.PictureBox();
            this.button_searchregistrations_registrationsystem = new System.Windows.Forms.Button();
            this.button_searchbookings_registrationsystem = new System.Windows.Forms.Button();
            this.text_registrationquery_regstrationsystem = new System.Windows.Forms.TextBox();
            this.text_bookingquery_registrationsystem = new System.Windows.Forms.TextBox();
            this.label_registrationsearch_regstrationsystem = new System.Windows.Forms.Label();
            this.label_bookingsearch_regstrationsystem = new System.Windows.Forms.Label();
            this.button_home_registrationsystem = new System.Windows.Forms.Button();
            this.timer_registrationsystem = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitcontainer_registrationinfo_registrationsystem)).BeginInit();
            this.splitcontainer_registrationinfo_registrationsystem.Panel1.SuspendLayout();
            this.splitcontainer_registrationinfo_registrationsystem.Panel2.SuspendLayout();
            this.splitcontainer_registrationinfo_registrationsystem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitcontainer_registrationsearch_registrationsystem)).BeginInit();
            this.splitcontainer_registrationsearch_registrationsystem.Panel1.SuspendLayout();
            this.splitcontainer_registrationsearch_registrationsystem.Panel2.SuspendLayout();
            this.splitcontainer_registrationsearch_registrationsystem.SuspendLayout();
            this.panel_banner_registrationsystem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_logo_regstrationsystem)).BeginInit();
            this.SuspendLayout();
            // 
            // label_extrainfo_registrationsystem
            // 
            this.label_extrainfo_registrationsystem.AutoSize = true;
            this.label_extrainfo_registrationsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_extrainfo_registrationsystem.Location = new System.Drawing.Point(258, 327);
            this.label_extrainfo_registrationsystem.Name = "label_extrainfo_registrationsystem";
            this.label_extrainfo_registrationsystem.Size = new System.Drawing.Size(184, 26);
            this.label_extrainfo_registrationsystem.TabIndex = 11;
            this.label_extrainfo_registrationsystem.Text = "Extra Information:";
            // 
            // label_registrationpastbookings_registrationsystem
            // 
            this.label_registrationpastbookings_registrationsystem.AutoSize = true;
            this.label_registrationpastbookings_registrationsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_registrationpastbookings_registrationsystem.Location = new System.Drawing.Point(294, 217);
            this.label_registrationpastbookings_registrationsystem.Name = "label_registrationpastbookings_registrationsystem";
            this.label_registrationpastbookings_registrationsystem.Size = new System.Drawing.Size(107, 25);
            this.label_registrationpastbookings_registrationsystem.TabIndex = 11;
            this.label_registrationpastbookings_registrationsystem.Text = "Bookings:";
            // 
            // button_goback_registrationsystem
            // 
            this.button_goback_registrationsystem.Enabled = false;
            this.button_goback_registrationsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_goback_registrationsystem.Location = new System.Drawing.Point(1134, 3);
            this.button_goback_registrationsystem.Name = "button_goback_registrationsystem";
            this.button_goback_registrationsystem.Size = new System.Drawing.Size(105, 36);
            this.button_goback_registrationsystem.TabIndex = 6;
            this.button_goback_registrationsystem.TabStop = false;
            this.button_goback_registrationsystem.Text = "Go Back";
            this.button_goback_registrationsystem.UseVisualStyleBackColor = true;
            this.button_goback_registrationsystem.Visible = false;
            this.button_goback_registrationsystem.Click += new System.EventHandler(this.button_goback_registrationsystem_Click);
            // 
            // listbox_registrationpastbookings_registrationsystem
            // 
            this.listbox_registrationpastbookings_registrationsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listbox_registrationpastbookings_registrationsystem.FormattingEnabled = true;
            this.listbox_registrationpastbookings_registrationsystem.ItemHeight = 25;
            this.listbox_registrationpastbookings_registrationsystem.Location = new System.Drawing.Point(2, 245);
            this.listbox_registrationpastbookings_registrationsystem.Name = "listbox_registrationpastbookings_registrationsystem";
            this.listbox_registrationpastbookings_registrationsystem.Size = new System.Drawing.Size(690, 79);
            this.listbox_registrationpastbookings_registrationsystem.TabIndex = 10;
            this.listbox_registrationpastbookings_registrationsystem.TabStop = false;
            this.listbox_registrationpastbookings_registrationsystem.SelectedIndexChanged += new System.EventHandler(this.listbox_registrationpastbookings_registrationsystem_SelectedIndexChanged);
            this.listbox_registrationpastbookings_registrationsystem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listbox_registrationpastbookings_registrationsystem_KeyDown);
            // 
            // text_extrainfo_registrationsystem
            // 
            this.text_extrainfo_registrationsystem.BackColor = System.Drawing.Color.White;
            this.text_extrainfo_registrationsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_extrainfo_registrationsystem.Location = new System.Drawing.Point(3, 356);
            this.text_extrainfo_registrationsystem.Multiline = true;
            this.text_extrainfo_registrationsystem.Name = "text_extrainfo_registrationsystem";
            this.text_extrainfo_registrationsystem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.text_extrainfo_registrationsystem.Size = new System.Drawing.Size(690, 107);
            this.text_extrainfo_registrationsystem.TabIndex = 9;
            this.text_extrainfo_registrationsystem.TabStop = false;
            this.text_extrainfo_registrationsystem.TextChanged += new System.EventHandler(this.text_extrainfo_registrationsystem_TextChanged);
            // 
            // splitcontainer_registrationinfo_registrationsystem
            // 
            this.splitcontainer_registrationinfo_registrationsystem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitcontainer_registrationinfo_registrationsystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitcontainer_registrationinfo_registrationsystem.Location = new System.Drawing.Point(0, 0);
            this.splitcontainer_registrationinfo_registrationsystem.Name = "splitcontainer_registrationinfo_registrationsystem";
            // 
            // splitcontainer_registrationinfo_registrationsystem.Panel1
            // 
            this.splitcontainer_registrationinfo_registrationsystem.Panel1.AutoScroll = true;
            this.splitcontainer_registrationinfo_registrationsystem.Panel1.Controls.Add(this.label_extrainfo_registrationsystem);
            this.splitcontainer_registrationinfo_registrationsystem.Panel1.Controls.Add(this.label_registrationpastbookings_registrationsystem);
            this.splitcontainer_registrationinfo_registrationsystem.Panel1.Controls.Add(this.listbox_registrationpastbookings_registrationsystem);
            this.splitcontainer_registrationinfo_registrationsystem.Panel1.Controls.Add(this.text_extrainfo_registrationsystem);
            this.splitcontainer_registrationinfo_registrationsystem.Panel1.Controls.Add(this.text_multilineallinfo_regstrationsystem);
            this.splitcontainer_registrationinfo_registrationsystem.Panel1.Controls.Add(this.label_registrationinformation_regstrationsystem);
            this.splitcontainer_registrationinfo_registrationsystem.Panel1.Controls.Add(this.button_viewbooking_registrationsystem);
            this.splitcontainer_registrationinfo_registrationsystem.Panel1.Controls.Add(this.button_deleteregistration_regstrationsystem);
            this.splitcontainer_registrationinfo_registrationsystem.Panel1.Controls.Add(this.button_editregistration_registrationsystem);
            this.splitcontainer_registrationinfo_registrationsystem.Panel1.Enabled = false;
            // 
            // splitcontainer_registrationinfo_registrationsystem.Panel2
            // 
            this.splitcontainer_registrationinfo_registrationsystem.Panel2.AutoScroll = true;
            this.splitcontainer_registrationinfo_registrationsystem.Panel2.BackColor = System.Drawing.Color.Blue;
            this.splitcontainer_registrationinfo_registrationsystem.Panel2.Controls.Add(this.listbox_registrationslist_regstrationsystem);
            this.splitcontainer_registrationinfo_registrationsystem.Panel2.Controls.Add(this.label_registrations_regstrationsystem);
            this.splitcontainer_registrationinfo_registrationsystem.Panel2.Controls.Add(this.button_addnewregistration_registrationsystem);
            this.splitcontainer_registrationinfo_registrationsystem.Size = new System.Drawing.Size(1366, 573);
            this.splitcontainer_registrationinfo_registrationsystem.SplitterDistance = 697;
            this.splitcontainer_registrationinfo_registrationsystem.SplitterWidth = 2;
            this.splitcontainer_registrationinfo_registrationsystem.TabIndex = 0;
            this.splitcontainer_registrationinfo_registrationsystem.TabStop = false;
            // 
            // text_multilineallinfo_regstrationsystem
            // 
            this.text_multilineallinfo_regstrationsystem.BackColor = System.Drawing.Color.White;
            this.text_multilineallinfo_regstrationsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_multilineallinfo_regstrationsystem.Location = new System.Drawing.Point(3, 30);
            this.text_multilineallinfo_regstrationsystem.Multiline = true;
            this.text_multilineallinfo_regstrationsystem.Name = "text_multilineallinfo_regstrationsystem";
            this.text_multilineallinfo_regstrationsystem.ReadOnly = true;
            this.text_multilineallinfo_regstrationsystem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.text_multilineallinfo_regstrationsystem.Size = new System.Drawing.Size(690, 184);
            this.text_multilineallinfo_regstrationsystem.TabIndex = 9;
            this.text_multilineallinfo_regstrationsystem.TabStop = false;
            this.text_multilineallinfo_regstrationsystem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.text_multilineallinfo_regstrationsystem.TextChanged += new System.EventHandler(this.text_multilineallinfo_regstrationsystem_TextChanged);
            // 
            // label_registrationinformation_regstrationsystem
            // 
            this.label_registrationinformation_regstrationsystem.AutoSize = true;
            this.label_registrationinformation_regstrationsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_registrationinformation_regstrationsystem.Location = new System.Drawing.Point(217, 2);
            this.label_registrationinformation_regstrationsystem.Name = "label_registrationinformation_regstrationsystem";
            this.label_registrationinformation_regstrationsystem.Size = new System.Drawing.Size(245, 25);
            this.label_registrationinformation_regstrationsystem.TabIndex = 7;
            this.label_registrationinformation_regstrationsystem.Text = "Registration Information:";
            // 
            // button_viewbooking_registrationsystem
            // 
            this.button_viewbooking_registrationsystem.BackColor = System.Drawing.Color.White;
            this.button_viewbooking_registrationsystem.Enabled = false;
            this.button_viewbooking_registrationsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_viewbooking_registrationsystem.Location = new System.Drawing.Point(237, 469);
            this.button_viewbooking_registrationsystem.Name = "button_viewbooking_registrationsystem";
            this.button_viewbooking_registrationsystem.Size = new System.Drawing.Size(226, 33);
            this.button_viewbooking_registrationsystem.TabIndex = 6;
            this.button_viewbooking_registrationsystem.TabStop = false;
            this.button_viewbooking_registrationsystem.Text = "View Booking Record";
            this.button_viewbooking_registrationsystem.UseVisualStyleBackColor = false;
            this.button_viewbooking_registrationsystem.Visible = false;
            this.button_viewbooking_registrationsystem.Click += new System.EventHandler(this.button_viewbooking_registrationsystem_Click);
            // 
            // button_deleteregistration_regstrationsystem
            // 
            this.button_deleteregistration_regstrationsystem.BackColor = System.Drawing.Color.White;
            this.button_deleteregistration_regstrationsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_deleteregistration_regstrationsystem.Location = new System.Drawing.Point(611, 469);
            this.button_deleteregistration_regstrationsystem.Name = "button_deleteregistration_regstrationsystem";
            this.button_deleteregistration_regstrationsystem.Size = new System.Drawing.Size(82, 33);
            this.button_deleteregistration_regstrationsystem.TabIndex = 6;
            this.button_deleteregistration_regstrationsystem.TabStop = false;
            this.button_deleteregistration_regstrationsystem.Text = "Delete";
            this.button_deleteregistration_regstrationsystem.UseVisualStyleBackColor = false;
            this.button_deleteregistration_regstrationsystem.Click += new System.EventHandler(this.button_deleteregistration_regstrationsystem_Click);
            // 
            // button_editregistration_registrationsystem
            // 
            this.button_editregistration_registrationsystem.BackColor = System.Drawing.Color.White;
            this.button_editregistration_registrationsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_editregistration_registrationsystem.Location = new System.Drawing.Point(14, 469);
            this.button_editregistration_registrationsystem.Name = "button_editregistration_registrationsystem";
            this.button_editregistration_registrationsystem.Size = new System.Drawing.Size(61, 33);
            this.button_editregistration_registrationsystem.TabIndex = 5;
            this.button_editregistration_registrationsystem.TabStop = false;
            this.button_editregistration_registrationsystem.Text = "Edit";
            this.button_editregistration_registrationsystem.UseVisualStyleBackColor = false;
            this.button_editregistration_registrationsystem.Click += new System.EventHandler(this.button_editregistration_registrationsystem_Click);
            // 
            // listbox_registrationslist_regstrationsystem
            // 
            this.listbox_registrationslist_regstrationsystem.BackColor = System.Drawing.Color.Blue;
            this.listbox_registrationslist_regstrationsystem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listbox_registrationslist_regstrationsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listbox_registrationslist_regstrationsystem.ForeColor = System.Drawing.Color.White;
            this.listbox_registrationslist_regstrationsystem.FormattingEnabled = true;
            this.listbox_registrationslist_regstrationsystem.ItemHeight = 25;
            this.listbox_registrationslist_regstrationsystem.Location = new System.Drawing.Point(3, 30);
            this.listbox_registrationslist_regstrationsystem.Name = "listbox_registrationslist_regstrationsystem";
            this.listbox_registrationslist_regstrationsystem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listbox_registrationslist_regstrationsystem.Size = new System.Drawing.Size(650, 400);
            this.listbox_registrationslist_regstrationsystem.TabIndex = 6;
            this.listbox_registrationslist_regstrationsystem.TabStop = false;
            this.listbox_registrationslist_regstrationsystem.SelectedIndexChanged += new System.EventHandler(this.listbox_registrationslist_regstrationsystem_SelectedIndexChanged);
            // 
            // label_registrations_regstrationsystem
            // 
            this.label_registrations_regstrationsystem.AutoSize = true;
            this.label_registrations_regstrationsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_registrations_regstrationsystem.ForeColor = System.Drawing.Color.White;
            this.label_registrations_regstrationsystem.Location = new System.Drawing.Point(172, 2);
            this.label_registrations_regstrationsystem.Name = "label_registrations_regstrationsystem";
            this.label_registrations_regstrationsystem.Size = new System.Drawing.Size(144, 25);
            this.label_registrations_regstrationsystem.TabIndex = 5;
            this.label_registrations_regstrationsystem.Text = "Registrations:";
            // 
            // button_addnewregistration_registrationsystem
            // 
            this.button_addnewregistration_registrationsystem.BackColor = System.Drawing.Color.White;
            this.button_addnewregistration_registrationsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_addnewregistration_registrationsystem.Location = new System.Drawing.Point(177, 444);
            this.button_addnewregistration_registrationsystem.Name = "button_addnewregistration_registrationsystem";
            this.button_addnewregistration_registrationsystem.Size = new System.Drawing.Size(138, 58);
            this.button_addnewregistration_registrationsystem.TabIndex = 4;
            this.button_addnewregistration_registrationsystem.TabStop = false;
            this.button_addnewregistration_registrationsystem.Text = "Add New Registration";
            this.button_addnewregistration_registrationsystem.UseVisualStyleBackColor = false;
            this.button_addnewregistration_registrationsystem.Click += new System.EventHandler(this.button_addnewregistration_registrationsystem_Click);
            // 
            // button_exitsearchresults_registrationsystem
            // 
            this.button_exitsearchresults_registrationsystem.BackColor = System.Drawing.Color.White;
            this.button_exitsearchresults_registrationsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_exitsearchresults_registrationsystem.Location = new System.Drawing.Point(101, 444);
            this.button_exitsearchresults_registrationsystem.Name = "button_exitsearchresults_registrationsystem";
            this.button_exitsearchresults_registrationsystem.Size = new System.Drawing.Size(131, 58);
            this.button_exitsearchresults_registrationsystem.TabIndex = 5;
            this.button_exitsearchresults_registrationsystem.TabStop = false;
            this.button_exitsearchresults_registrationsystem.Text = "Exit Search Results";
            this.button_exitsearchresults_registrationsystem.UseVisualStyleBackColor = false;
            this.button_exitsearchresults_registrationsystem.Click += new System.EventHandler(this.button_exitsearchresults_registrationsystem_Click);
            // 
            // splitcontainer_registrationsearch_registrationsystem
            // 
            this.splitcontainer_registrationsearch_registrationsystem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitcontainer_registrationsearch_registrationsystem.Location = new System.Drawing.Point(0, 155);
            this.splitcontainer_registrationsearch_registrationsystem.Name = "splitcontainer_registrationsearch_registrationsystem";
            // 
            // splitcontainer_registrationsearch_registrationsystem.Panel1
            // 
            this.splitcontainer_registrationsearch_registrationsystem.Panel1.AutoScroll = true;
            this.splitcontainer_registrationsearch_registrationsystem.Panel1.BackColor = System.Drawing.Color.Blue;
            this.splitcontainer_registrationsearch_registrationsystem.Panel1.Controls.Add(this.button_exitsearchresults_registrationsystem);
            this.splitcontainer_registrationsearch_registrationsystem.Panel1.Controls.Add(this.listbox_registrationqueryreult_regstrationsystem);
            this.splitcontainer_registrationsearch_registrationsystem.Panel1.Controls.Add(this.text_registrationqueryresult_regstrationsystem);
            this.splitcontainer_registrationsearch_registrationsystem.Panel1Collapsed = true;
            // 
            // splitcontainer_registrationsearch_registrationsystem.Panel2
            // 
            this.splitcontainer_registrationsearch_registrationsystem.Panel2.Controls.Add(this.splitcontainer_registrationinfo_registrationsystem);
            this.splitcontainer_registrationsearch_registrationsystem.Size = new System.Drawing.Size(1366, 573);
            this.splitcontainer_registrationsearch_registrationsystem.SplitterDistance = 350;
            this.splitcontainer_registrationsearch_registrationsystem.SplitterWidth = 2;
            this.splitcontainer_registrationsearch_registrationsystem.TabIndex = 10;
            this.splitcontainer_registrationsearch_registrationsystem.TabStop = false;
            // 
            // listbox_registrationqueryreult_regstrationsystem
            // 
            this.listbox_registrationqueryreult_regstrationsystem.BackColor = System.Drawing.Color.Blue;
            this.listbox_registrationqueryreult_regstrationsystem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listbox_registrationqueryreult_regstrationsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listbox_registrationqueryreult_regstrationsystem.ForeColor = System.Drawing.Color.White;
            this.listbox_registrationqueryreult_regstrationsystem.FormattingEnabled = true;
            this.listbox_registrationqueryreult_regstrationsystem.ItemHeight = 25;
            this.listbox_registrationqueryreult_regstrationsystem.Location = new System.Drawing.Point(10, 35);
            this.listbox_registrationqueryreult_regstrationsystem.Name = "listbox_registrationqueryreult_regstrationsystem";
            this.listbox_registrationqueryreult_regstrationsystem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listbox_registrationqueryreult_regstrationsystem.Size = new System.Drawing.Size(350, 400);
            this.listbox_registrationqueryreult_regstrationsystem.TabIndex = 1;
            this.listbox_registrationqueryreult_regstrationsystem.TabStop = false;
            this.listbox_registrationqueryreult_regstrationsystem.SelectedIndexChanged += new System.EventHandler(this.listbox_registrationqueryreult_regstrationsystem_SelectedIndexChanged);
            // 
            // text_registrationqueryresult_regstrationsystem
            // 
            this.text_registrationqueryresult_regstrationsystem.BackColor = System.Drawing.Color.Blue;
            this.text_registrationqueryresult_regstrationsystem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_registrationqueryresult_regstrationsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_registrationqueryresult_regstrationsystem.ForeColor = System.Drawing.Color.White;
            this.text_registrationqueryresult_regstrationsystem.Location = new System.Drawing.Point(10, 5);
            this.text_registrationqueryresult_regstrationsystem.Name = "text_registrationqueryresult_regstrationsystem";
            this.text_registrationqueryresult_regstrationsystem.ReadOnly = true;
            this.text_registrationqueryresult_regstrationsystem.Size = new System.Drawing.Size(333, 24);
            this.text_registrationqueryresult_regstrationsystem.TabIndex = 0;
            this.text_registrationqueryresult_regstrationsystem.TabStop = false;
            this.text_registrationqueryresult_regstrationsystem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_addnewbooking_registrationsystem
            // 
            this.button_addnewbooking_registrationsystem.BackColor = System.Drawing.Color.White;
            this.button_addnewbooking_registrationsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_addnewbooking_registrationsystem.Location = new System.Drawing.Point(152, 10);
            this.button_addnewbooking_registrationsystem.Name = "button_addnewbooking_registrationsystem";
            this.button_addnewbooking_registrationsystem.Size = new System.Drawing.Size(136, 136);
            this.button_addnewbooking_registrationsystem.TabIndex = 8;
            this.button_addnewbooking_registrationsystem.TabStop = false;
            this.button_addnewbooking_registrationsystem.Text = "Add New Booking";
            this.button_addnewbooking_registrationsystem.UseVisualStyleBackColor = false;
            this.button_addnewbooking_registrationsystem.Click += new System.EventHandler(this.button_addnewbooking_registrationsystem_Click);
            // 
            // button_bookings_registrationsystem
            // 
            this.button_bookings_registrationsystem.BackColor = System.Drawing.Color.White;
            this.button_bookings_registrationsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_bookings_registrationsystem.Location = new System.Drawing.Point(294, 10);
            this.button_bookings_registrationsystem.Name = "button_bookings_registrationsystem";
            this.button_bookings_registrationsystem.Size = new System.Drawing.Size(136, 136);
            this.button_bookings_registrationsystem.TabIndex = 0;
            this.button_bookings_registrationsystem.TabStop = false;
            this.button_bookings_registrationsystem.Text = "Booking System";
            this.button_bookings_registrationsystem.UseVisualStyleBackColor = false;
            this.button_bookings_registrationsystem.Click += new System.EventHandler(this.button_bookings_registrationsystem_Click);
            // 
            // button_minimizeform_registrationsystem
            // 
            this.button_minimizeform_registrationsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_minimizeform_registrationsystem.Location = new System.Drawing.Point(1245, 3);
            this.button_minimizeform_registrationsystem.Name = "button_minimizeform_registrationsystem";
            this.button_minimizeform_registrationsystem.Size = new System.Drawing.Size(36, 36);
            this.button_minimizeform_registrationsystem.TabIndex = 5;
            this.button_minimizeform_registrationsystem.TabStop = false;
            this.button_minimizeform_registrationsystem.Text = "_";
            this.button_minimizeform_registrationsystem.UseVisualStyleBackColor = true;
            this.button_minimizeform_registrationsystem.Click += new System.EventHandler(this.button_minimizeform_registrationsystem_Click);
            // 
            // panel_banner_registrationsystem
            // 
            this.panel_banner_registrationsystem.BackColor = System.Drawing.Color.Blue;
            this.panel_banner_registrationsystem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_banner_registrationsystem.Controls.Add(this.label_titleRegistrationSystem);
            this.panel_banner_registrationsystem.Controls.Add(this.button_addnewbooking_registrationsystem);
            this.panel_banner_registrationsystem.Controls.Add(this.button_bookings_registrationsystem);
            this.panel_banner_registrationsystem.Controls.Add(this.button_goback_registrationsystem);
            this.panel_banner_registrationsystem.Controls.Add(this.button_minimizeform_registrationsystem);
            this.panel_banner_registrationsystem.Controls.Add(this.button_closeform_registrationsystem);
            this.panel_banner_registrationsystem.Controls.Add(this.picturebox_logo_regstrationsystem);
            this.panel_banner_registrationsystem.Controls.Add(this.button_searchregistrations_registrationsystem);
            this.panel_banner_registrationsystem.Controls.Add(this.button_searchbookings_registrationsystem);
            this.panel_banner_registrationsystem.Controls.Add(this.text_registrationquery_regstrationsystem);
            this.panel_banner_registrationsystem.Controls.Add(this.text_bookingquery_registrationsystem);
            this.panel_banner_registrationsystem.Controls.Add(this.label_registrationsearch_regstrationsystem);
            this.panel_banner_registrationsystem.Controls.Add(this.label_bookingsearch_regstrationsystem);
            this.panel_banner_registrationsystem.Controls.Add(this.button_home_registrationsystem);
            this.panel_banner_registrationsystem.Location = new System.Drawing.Point(0, 0);
            this.panel_banner_registrationsystem.Name = "panel_banner_registrationsystem";
            this.panel_banner_registrationsystem.Size = new System.Drawing.Size(1366, 155);
            this.panel_banner_registrationsystem.TabIndex = 9;
            // 
            // label_titleRegistrationSystem
            // 
            this.label_titleRegistrationSystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_titleRegistrationSystem.ForeColor = System.Drawing.Color.White;
            this.label_titleRegistrationSystem.Location = new System.Drawing.Point(1017, 101);
            this.label_titleRegistrationSystem.Name = "label_titleRegistrationSystem";
            this.label_titleRegistrationSystem.Size = new System.Drawing.Size(321, 42);
            this.label_titleRegistrationSystem.TabIndex = 9;
            this.label_titleRegistrationSystem.Text = "Registration System";
            this.label_titleRegistrationSystem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_closeform_registrationsystem
            // 
            this.button_closeform_registrationsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_closeform_registrationsystem.Location = new System.Drawing.Point(1287, 3);
            this.button_closeform_registrationsystem.Name = "button_closeform_registrationsystem";
            this.button_closeform_registrationsystem.Size = new System.Drawing.Size(57, 36);
            this.button_closeform_registrationsystem.TabIndex = 5;
            this.button_closeform_registrationsystem.TabStop = false;
            this.button_closeform_registrationsystem.Text = "Exit";
            this.button_closeform_registrationsystem.UseVisualStyleBackColor = true;
            this.button_closeform_registrationsystem.Click += new System.EventHandler(this.button_closeform_registrationsystem_Click);
            // 
            // picturebox_logo_regstrationsystem
            // 
            this.picturebox_logo_regstrationsystem.Image = ((System.Drawing.Image)(resources.GetObject("picturebox_logo_regstrationsystem.Image")));
            this.picturebox_logo_regstrationsystem.Location = new System.Drawing.Point(996, 60);
            this.picturebox_logo_regstrationsystem.Name = "picturebox_logo_regstrationsystem";
            this.picturebox_logo_regstrationsystem.Size = new System.Drawing.Size(363, 38);
            this.picturebox_logo_regstrationsystem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturebox_logo_regstrationsystem.TabIndex = 4;
            this.picturebox_logo_regstrationsystem.TabStop = false;
            // 
            // button_searchregistrations_registrationsystem
            // 
            this.button_searchregistrations_registrationsystem.BackColor = System.Drawing.Color.White;
            this.button_searchregistrations_registrationsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_searchregistrations_registrationsystem.Location = new System.Drawing.Point(765, 79);
            this.button_searchregistrations_registrationsystem.Name = "button_searchregistrations_registrationsystem";
            this.button_searchregistrations_registrationsystem.Size = new System.Drawing.Size(218, 64);
            this.button_searchregistrations_registrationsystem.TabIndex = 3;
            this.button_searchregistrations_registrationsystem.Text = "Search Registration System";
            this.button_searchregistrations_registrationsystem.UseVisualStyleBackColor = false;
            this.button_searchregistrations_registrationsystem.Click += new System.EventHandler(this.button_searchregistrations_registrationsystem_Click);
            // 
            // button_searchbookings_registrationsystem
            // 
            this.button_searchbookings_registrationsystem.BackColor = System.Drawing.Color.White;
            this.button_searchbookings_registrationsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_searchbookings_registrationsystem.Location = new System.Drawing.Point(578, 79);
            this.button_searchbookings_registrationsystem.Name = "button_searchbookings_registrationsystem";
            this.button_searchbookings_registrationsystem.Size = new System.Drawing.Size(181, 64);
            this.button_searchbookings_registrationsystem.TabIndex = 1;
            this.button_searchbookings_registrationsystem.Text = "Search Booking System";
            this.button_searchbookings_registrationsystem.UseVisualStyleBackColor = false;
            this.button_searchbookings_registrationsystem.Click += new System.EventHandler(this.button_searchbookings_registrationsystem_Click);
            // 
            // text_registrationquery_regstrationsystem
            // 
            this.text_registrationquery_regstrationsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_registrationquery_regstrationsystem.Location = new System.Drawing.Point(765, 42);
            this.text_registrationquery_regstrationsystem.Name = "text_registrationquery_regstrationsystem";
            this.text_registrationquery_regstrationsystem.Size = new System.Drawing.Size(218, 31);
            this.text_registrationquery_regstrationsystem.TabIndex = 2;
            this.text_registrationquery_regstrationsystem.Enter += new System.EventHandler(this.text_registrationquery_regstrationsystem_Enter);
            this.text_registrationquery_regstrationsystem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_registrationquery_regstrationsystem_KeyDown);
            this.text_registrationquery_regstrationsystem.Leave += new System.EventHandler(this.text_registrationquery_regstrationsystem_Leave);
            // 
            // text_bookingquery_registrationsystem
            // 
            this.text_bookingquery_registrationsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_bookingquery_registrationsystem.Location = new System.Drawing.Point(578, 42);
            this.text_bookingquery_registrationsystem.Name = "text_bookingquery_registrationsystem";
            this.text_bookingquery_registrationsystem.Size = new System.Drawing.Size(181, 31);
            this.text_bookingquery_registrationsystem.TabIndex = 0;
            this.text_bookingquery_registrationsystem.Enter += new System.EventHandler(this.text_bookingquery_registrationsystem_Enter);
            this.text_bookingquery_registrationsystem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_bookingquery_registrationsystem_KeyDown);
            this.text_bookingquery_registrationsystem.Leave += new System.EventHandler(this.text_bookingquery_registrationsystem_Leave);
            // 
            // label_registrationsearch_regstrationsystem
            // 
            this.label_registrationsearch_regstrationsystem.AutoSize = true;
            this.label_registrationsearch_regstrationsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_registrationsearch_regstrationsystem.ForeColor = System.Drawing.Color.White;
            this.label_registrationsearch_regstrationsystem.Location = new System.Drawing.Point(765, 14);
            this.label_registrationsearch_regstrationsystem.Name = "label_registrationsearch_regstrationsystem";
            this.label_registrationsearch_regstrationsystem.Size = new System.Drawing.Size(218, 25);
            this.label_registrationsearch_regstrationsystem.TabIndex = 1;
            this.label_registrationsearch_regstrationsystem.Text = "Search Registrations:";
            // 
            // label_bookingsearch_regstrationsystem
            // 
            this.label_bookingsearch_regstrationsystem.AutoSize = true;
            this.label_bookingsearch_regstrationsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_bookingsearch_regstrationsystem.ForeColor = System.Drawing.Color.White;
            this.label_bookingsearch_regstrationsystem.Location = new System.Drawing.Point(578, 14);
            this.label_bookingsearch_regstrationsystem.Name = "label_bookingsearch_regstrationsystem";
            this.label_bookingsearch_regstrationsystem.Size = new System.Drawing.Size(181, 25);
            this.label_bookingsearch_regstrationsystem.TabIndex = 1;
            this.label_bookingsearch_regstrationsystem.Text = "Search Bookings:";
            // 
            // button_home_registrationsystem
            // 
            this.button_home_registrationsystem.BackColor = System.Drawing.Color.White;
            this.button_home_registrationsystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_home_registrationsystem.Location = new System.Drawing.Point(10, 10);
            this.button_home_registrationsystem.Name = "button_home_registrationsystem";
            this.button_home_registrationsystem.Size = new System.Drawing.Size(136, 136);
            this.button_home_registrationsystem.TabIndex = 0;
            this.button_home_registrationsystem.TabStop = false;
            this.button_home_registrationsystem.Text = "Home";
            this.button_home_registrationsystem.UseVisualStyleBackColor = false;
            this.button_home_registrationsystem.Click += new System.EventHandler(this.button_home_registrationsystem_Click);
            // 
            // timer_registrationsystem
            // 
            this.timer_registrationsystem.Enabled = true;
            this.timer_registrationsystem.Interval = 10;
            this.timer_registrationsystem.Tick += new System.EventHandler(this.timer_registrationsystem_Tick);
            // 
            // form_registrationsystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1366, 728);
            this.Controls.Add(this.splitcontainer_registrationsearch_registrationsystem);
            this.Controls.Add(this.panel_banner_registrationsystem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "form_registrationsystem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chichester Cattery Booking System : Registration System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.form_registrationsystem_activated);
            this.Load += new System.EventHandler(this.form_registrationsystem_Load);
            this.splitcontainer_registrationinfo_registrationsystem.Panel1.ResumeLayout(false);
            this.splitcontainer_registrationinfo_registrationsystem.Panel1.PerformLayout();
            this.splitcontainer_registrationinfo_registrationsystem.Panel2.ResumeLayout(false);
            this.splitcontainer_registrationinfo_registrationsystem.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitcontainer_registrationinfo_registrationsystem)).EndInit();
            this.splitcontainer_registrationinfo_registrationsystem.ResumeLayout(false);
            this.splitcontainer_registrationsearch_registrationsystem.Panel1.ResumeLayout(false);
            this.splitcontainer_registrationsearch_registrationsystem.Panel1.PerformLayout();
            this.splitcontainer_registrationsearch_registrationsystem.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitcontainer_registrationsearch_registrationsystem)).EndInit();
            this.splitcontainer_registrationsearch_registrationsystem.ResumeLayout(false);
            this.panel_banner_registrationsystem.ResumeLayout(false);
            this.panel_banner_registrationsystem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_logo_regstrationsystem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_extrainfo_registrationsystem;
        private System.Windows.Forms.Label label_registrationpastbookings_registrationsystem;
        private System.Windows.Forms.Button button_goback_registrationsystem;
        private System.Windows.Forms.ListBox listbox_registrationpastbookings_registrationsystem;
        private System.Windows.Forms.TextBox text_extrainfo_registrationsystem;
        private System.Windows.Forms.SplitContainer splitcontainer_registrationinfo_registrationsystem;
        private System.Windows.Forms.TextBox text_multilineallinfo_regstrationsystem;
        private System.Windows.Forms.Label label_registrationinformation_regstrationsystem;
        private System.Windows.Forms.Button button_viewbooking_registrationsystem;
        private System.Windows.Forms.Button button_deleteregistration_regstrationsystem;
        private System.Windows.Forms.Button button_editregistration_registrationsystem;
        private System.Windows.Forms.ListBox listbox_registrationslist_regstrationsystem;
        private System.Windows.Forms.Label label_registrations_regstrationsystem;
        private System.Windows.Forms.Button button_addnewregistration_registrationsystem;
        private System.Windows.Forms.Button button_exitsearchresults_registrationsystem;
        private System.Windows.Forms.SplitContainer splitcontainer_registrationsearch_registrationsystem;
        private System.Windows.Forms.ListBox listbox_registrationqueryreult_regstrationsystem;
        private System.Windows.Forms.TextBox text_registrationqueryresult_regstrationsystem;
        private System.Windows.Forms.Button button_addnewbooking_registrationsystem;
        private System.Windows.Forms.Button button_bookings_registrationsystem;
        private System.Windows.Forms.Button button_minimizeform_registrationsystem;
        private System.Windows.Forms.Panel panel_banner_registrationsystem;
        private System.Windows.Forms.Button button_closeform_registrationsystem;
        private System.Windows.Forms.PictureBox picturebox_logo_regstrationsystem;
        private System.Windows.Forms.Button button_searchregistrations_registrationsystem;
        private System.Windows.Forms.Button button_searchbookings_registrationsystem;
        private System.Windows.Forms.TextBox text_registrationquery_regstrationsystem;
        private System.Windows.Forms.TextBox text_bookingquery_registrationsystem;
        private System.Windows.Forms.Label label_registrationsearch_regstrationsystem;
        private System.Windows.Forms.Label label_bookingsearch_regstrationsystem;
        private System.Windows.Forms.Button button_home_registrationsystem;
        private System.Windows.Forms.Timer timer_registrationsystem;
        private Label label_titleRegistrationSystem;
    }
}