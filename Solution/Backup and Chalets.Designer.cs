using System.Windows.Forms;
using Global;

namespace Solution
{
    partial class form_backupandchalets
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
                    try
                    {
                        Application.OpenForms[Application.OpenForms.Count - 1].BringToFront();
                        Application.OpenForms[Application.OpenForms.Count - 1].WindowState = FormWindowState.Maximized;
                        Application.OpenForms[Application.OpenForms.Count - 1].Close();
                    }
                    catch
                    {
                    }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_backupandchalets));
            this.label_connectionsettings_backup = new System.Windows.Forms.Label();
            this.label_printregistrationsandbookings_backup = new System.Windows.Forms.Label();
            this.label_backuptofile_backup = new System.Windows.Forms.Label();
            this.label_restorefrombackup_backup = new System.Windows.Forms.Label();
            this.text_restoredirectory_backup = new System.Windows.Forms.TextBox();
            this.text_backupdirectory_backup = new System.Windows.Forms.TextBox();
            this.button_backup_backup = new System.Windows.Forms.Button();
            this.button_exitbackup_backup = new System.Windows.Forms.Button();
            this.button_printregistrationsandbookings_backup = new System.Windows.Forms.Button();
            this.button_restore_backup = new System.Windows.Forms.Button();
            this.button_connectionsettings_backup = new System.Windows.Forms.Button();
            this.button_browserestore_backup = new System.Windows.Forms.Button();
            this.panel_backupandrestore_backup = new System.Windows.Forms.Panel();
            this.progressBar_restore = new System.Windows.Forms.ProgressBar();
            this.progressBar_backup = new System.Windows.Forms.ProgressBar();
            this.button_setnormalchalet = new System.Windows.Forms.Button();
            this.button_setlargefamilychalet = new System.Windows.Forms.Button();
            this.button_setfamilychalet = new System.Windows.Forms.Button();
            this.label_normal = new System.Windows.Forms.Label();
            this.label_family = new System.Windows.Forms.Label();
            this.label_largefamily = new System.Windows.Forms.Label();
            this.label_addingremovingchalets = new System.Windows.Forms.Label();
            this.label_totalnumberofchalets = new System.Windows.Forms.Label();
            this.listBox_largefamilychalets = new System.Windows.Forms.ListBox();
            this.listBox_familychalets = new System.Windows.Forms.ListBox();
            this.listBox_normalchalets = new System.Windows.Forms.ListBox();
            this.numericUpDown_numberofchalets = new System.Windows.Forms.NumericUpDown();
            this.button_browsebackup_backup = new System.Windows.Forms.Button();
            this.picturebox_logo_backup = new System.Windows.Forms.PictureBox();
            this.panel_banner_backup = new System.Windows.Forms.Panel();
            this.label_titlebackupandchalets = new System.Windows.Forms.Label();
            this.panel_backupandrestore_backup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_numberofchalets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_logo_backup)).BeginInit();
            this.panel_banner_backup.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_connectionsettings_backup
            // 
            this.label_connectionsettings_backup.AutoSize = true;
            this.label_connectionsettings_backup.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_connectionsettings_backup.Location = new System.Drawing.Point(10, 211);
            this.label_connectionsettings_backup.Name = "label_connectionsettings_backup";
            this.label_connectionsettings_backup.Size = new System.Drawing.Size(213, 26);
            this.label_connectionsettings_backup.TabIndex = 13;
            this.label_connectionsettings_backup.Text = "Connection Settings:";
            // 
            // label_printregistrationsandbookings_backup
            // 
            this.label_printregistrationsandbookings_backup.AutoSize = true;
            this.label_printregistrationsandbookings_backup.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_printregistrationsandbookings_backup.Location = new System.Drawing.Point(10, 132);
            this.label_printregistrationsandbookings_backup.Name = "label_printregistrationsandbookings_backup";
            this.label_printregistrationsandbookings_backup.Size = new System.Drawing.Size(334, 26);
            this.label_printregistrationsandbookings_backup.TabIndex = 14;
            this.label_printregistrationsandbookings_backup.Text = "Print Registrations and Bookings:";
            // 
            // label_backuptofile_backup
            // 
            this.label_backuptofile_backup.AutoSize = true;
            this.label_backuptofile_backup.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_backuptofile_backup.Location = new System.Drawing.Point(10, 9);
            this.label_backuptofile_backup.Name = "label_backuptofile_backup";
            this.label_backuptofile_backup.Size = new System.Drawing.Size(249, 26);
            this.label_backuptofile_backup.TabIndex = 16;
            this.label_backuptofile_backup.Text = "Backup and Print to File:";
            // 
            // label_restorefrombackup_backup
            // 
            this.label_restorefrombackup_backup.AutoSize = true;
            this.label_restorefrombackup_backup.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_restorefrombackup_backup.Location = new System.Drawing.Point(10, 52);
            this.label_restorefrombackup_backup.Name = "label_restorefrombackup_backup";
            this.label_restorefrombackup_backup.Size = new System.Drawing.Size(223, 26);
            this.label_restorefrombackup_backup.TabIndex = 15;
            this.label_restorefrombackup_backup.Text = "Restore from Backup:";
            // 
            // text_restoredirectory_backup
            // 
            this.text_restoredirectory_backup.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_restoredirectory_backup.Location = new System.Drawing.Point(239, 49);
            this.text_restoredirectory_backup.Name = "text_restoredirectory_backup";
            this.text_restoredirectory_backup.Size = new System.Drawing.Size(329, 32);
            this.text_restoredirectory_backup.TabIndex = 12;
            this.text_restoredirectory_backup.TextChanged += new System.EventHandler(this.text_restoredirectory_backup_TextChanged);
            // 
            // text_backupdirectory_backup
            // 
            this.text_backupdirectory_backup.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_backupdirectory_backup.Location = new System.Drawing.Point(265, 6);
            this.text_backupdirectory_backup.Name = "text_backupdirectory_backup";
            this.text_backupdirectory_backup.Size = new System.Drawing.Size(303, 32);
            this.text_backupdirectory_backup.TabIndex = 11;
            this.text_backupdirectory_backup.TextChanged += new System.EventHandler(this.text_backupdirectory_backup_TextChanged);
            // 
            // button_backup_backup
            // 
            this.button_backup_backup.BackColor = System.Drawing.Color.White;
            this.button_backup_backup.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_backup_backup.Location = new System.Drawing.Point(344, 89);
            this.button_backup_backup.Name = "button_backup_backup";
            this.button_backup_backup.Size = new System.Drawing.Size(93, 37);
            this.button_backup_backup.TabIndex = 10;
            this.button_backup_backup.Text = "Backup";
            this.button_backup_backup.UseVisualStyleBackColor = false;
            this.button_backup_backup.Click += new System.EventHandler(this.button_backup_backup_Click);
            // 
            // button_exitbackup_backup
            // 
            this.button_exitbackup_backup.BackColor = System.Drawing.Color.White;
            this.button_exitbackup_backup.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_exitbackup_backup.Location = new System.Drawing.Point(313, 450);
            this.button_exitbackup_backup.Name = "button_exitbackup_backup";
            this.button_exitbackup_backup.Size = new System.Drawing.Size(356, 34);
            this.button_exitbackup_backup.TabIndex = 5;
            this.button_exitbackup_backup.Text = "Close Backup and Chalet Window";
            this.button_exitbackup_backup.UseVisualStyleBackColor = false;
            this.button_exitbackup_backup.Click += new System.EventHandler(this.button_exitbackup_backup_Click);
            // 
            // button_printregistrationsandbookings_backup
            // 
            this.button_printregistrationsandbookings_backup.BackColor = System.Drawing.Color.White;
            this.button_printregistrationsandbookings_backup.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_printregistrationsandbookings_backup.Location = new System.Drawing.Point(352, 132);
            this.button_printregistrationsandbookings_backup.Name = "button_printregistrationsandbookings_backup";
            this.button_printregistrationsandbookings_backup.Size = new System.Drawing.Size(198, 67);
            this.button_printregistrationsandbookings_backup.TabIndex = 4;
            this.button_printregistrationsandbookings_backup.Text = "Print Registrations and Bookings";
            this.button_printregistrationsandbookings_backup.UseVisualStyleBackColor = false;
            this.button_printregistrationsandbookings_backup.Click += new System.EventHandler(this.button_printregistrationsandbookings_backup_Click);
            // 
            // button_restore_backup
            // 
            this.button_restore_backup.BackColor = System.Drawing.Color.White;
            this.button_restore_backup.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_restore_backup.Location = new System.Drawing.Point(443, 89);
            this.button_restore_backup.Name = "button_restore_backup";
            this.button_restore_backup.Size = new System.Drawing.Size(226, 37);
            this.button_restore_backup.TabIndex = 9;
            this.button_restore_backup.Text = "Restore from Backup";
            this.button_restore_backup.UseVisualStyleBackColor = false;
            this.button_restore_backup.Click += new System.EventHandler(this.button_restore_backup_Click);
            // 
            // button_connectionsettings_backup
            // 
            this.button_connectionsettings_backup.BackColor = System.Drawing.Color.White;
            this.button_connectionsettings_backup.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_connectionsettings_backup.Location = new System.Drawing.Point(229, 205);
            this.button_connectionsettings_backup.Name = "button_connectionsettings_backup";
            this.button_connectionsettings_backup.Size = new System.Drawing.Size(219, 37);
            this.button_connectionsettings_backup.TabIndex = 7;
            this.button_connectionsettings_backup.Text = "Connection Settings";
            this.button_connectionsettings_backup.UseVisualStyleBackColor = false;
            this.button_connectionsettings_backup.Click += new System.EventHandler(this.button_connectionsettings_backup_Click);
            // 
            // button_browserestore_backup
            // 
            this.button_browserestore_backup.BackColor = System.Drawing.Color.White;
            this.button_browserestore_backup.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_browserestore_backup.Location = new System.Drawing.Point(574, 46);
            this.button_browserestore_backup.Name = "button_browserestore_backup";
            this.button_browserestore_backup.Size = new System.Drawing.Size(95, 37);
            this.button_browserestore_backup.TabIndex = 8;
            this.button_browserestore_backup.Text = "Browse";
            this.button_browserestore_backup.UseVisualStyleBackColor = false;
            this.button_browserestore_backup.Click += new System.EventHandler(this.button_browserestore_backup_Click);
            // 
            // panel_backupandrestore_backup
            // 
            this.panel_backupandrestore_backup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_backupandrestore_backup.Controls.Add(this.progressBar_restore);
            this.panel_backupandrestore_backup.Controls.Add(this.progressBar_backup);
            this.panel_backupandrestore_backup.Controls.Add(this.button_setnormalchalet);
            this.panel_backupandrestore_backup.Controls.Add(this.button_setlargefamilychalet);
            this.panel_backupandrestore_backup.Controls.Add(this.button_setfamilychalet);
            this.panel_backupandrestore_backup.Controls.Add(this.label_normal);
            this.panel_backupandrestore_backup.Controls.Add(this.label_family);
            this.panel_backupandrestore_backup.Controls.Add(this.label_largefamily);
            this.panel_backupandrestore_backup.Controls.Add(this.label_addingremovingchalets);
            this.panel_backupandrestore_backup.Controls.Add(this.label_totalnumberofchalets);
            this.panel_backupandrestore_backup.Controls.Add(this.listBox_largefamilychalets);
            this.panel_backupandrestore_backup.Controls.Add(this.listBox_familychalets);
            this.panel_backupandrestore_backup.Controls.Add(this.listBox_normalchalets);
            this.panel_backupandrestore_backup.Controls.Add(this.numericUpDown_numberofchalets);
            this.panel_backupandrestore_backup.Controls.Add(this.label_connectionsettings_backup);
            this.panel_backupandrestore_backup.Controls.Add(this.label_printregistrationsandbookings_backup);
            this.panel_backupandrestore_backup.Controls.Add(this.label_backuptofile_backup);
            this.panel_backupandrestore_backup.Controls.Add(this.label_restorefrombackup_backup);
            this.panel_backupandrestore_backup.Controls.Add(this.text_restoredirectory_backup);
            this.panel_backupandrestore_backup.Controls.Add(this.text_backupdirectory_backup);
            this.panel_backupandrestore_backup.Controls.Add(this.button_backup_backup);
            this.panel_backupandrestore_backup.Controls.Add(this.button_exitbackup_backup);
            this.panel_backupandrestore_backup.Controls.Add(this.button_printregistrationsandbookings_backup);
            this.panel_backupandrestore_backup.Controls.Add(this.button_restore_backup);
            this.panel_backupandrestore_backup.Controls.Add(this.button_browserestore_backup);
            this.panel_backupandrestore_backup.Controls.Add(this.button_browsebackup_backup);
            this.panel_backupandrestore_backup.Controls.Add(this.button_connectionsettings_backup);
            this.panel_backupandrestore_backup.Location = new System.Drawing.Point(0, 100);
            this.panel_backupandrestore_backup.Name = "panel_backupandrestore_backup";
            this.panel_backupandrestore_backup.Size = new System.Drawing.Size(683, 495);
            this.panel_backupandrestore_backup.TabIndex = 6;
            // 
            // progressBar_restore
            // 
            this.progressBar_restore.Enabled = false;
            this.progressBar_restore.Location = new System.Drawing.Point(443, 89);
            this.progressBar_restore.Name = "progressBar_restore";
            this.progressBar_restore.Size = new System.Drawing.Size(226, 37);
            this.progressBar_restore.TabIndex = 23;
            this.progressBar_restore.Visible = false;
            // 
            // progressBar_backup
            // 
            this.progressBar_backup.Enabled = false;
            this.progressBar_backup.Location = new System.Drawing.Point(344, 89);
            this.progressBar_backup.Name = "progressBar_backup";
            this.progressBar_backup.Size = new System.Drawing.Size(93, 37);
            this.progressBar_backup.TabIndex = 23;
            this.progressBar_backup.Visible = false;
            // 
            // button_setnormalchalet
            // 
            this.button_setnormalchalet.BackColor = System.Drawing.Color.White;
            this.button_setnormalchalet.Enabled = false;
            this.button_setnormalchalet.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_setnormalchalet.Location = new System.Drawing.Point(388, 315);
            this.button_setnormalchalet.Name = "button_setnormalchalet";
            this.button_setnormalchalet.Size = new System.Drawing.Size(229, 34);
            this.button_setnormalchalet.TabIndex = 22;
            this.button_setnormalchalet.Text = "Set as Normal Chalet";
            this.button_setnormalchalet.UseVisualStyleBackColor = false;
            this.button_setnormalchalet.Click += new System.EventHandler(this.button_setnormalchalet_Click);
            // 
            // button_setlargefamilychalet
            // 
            this.button_setlargefamilychalet.BackColor = System.Drawing.Color.White;
            this.button_setlargefamilychalet.Enabled = false;
            this.button_setlargefamilychalet.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_setlargefamilychalet.Location = new System.Drawing.Point(388, 395);
            this.button_setlargefamilychalet.Name = "button_setlargefamilychalet";
            this.button_setlargefamilychalet.Size = new System.Drawing.Size(284, 34);
            this.button_setlargefamilychalet.TabIndex = 22;
            this.button_setlargefamilychalet.Text = "Set as Large Family Chalet";
            this.button_setlargefamilychalet.UseVisualStyleBackColor = false;
            this.button_setlargefamilychalet.Click += new System.EventHandler(this.button_setlargefamilychalet_Click);
            // 
            // button_setfamilychalet
            // 
            this.button_setfamilychalet.BackColor = System.Drawing.Color.White;
            this.button_setfamilychalet.Enabled = false;
            this.button_setfamilychalet.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_setfamilychalet.Location = new System.Drawing.Point(388, 355);
            this.button_setfamilychalet.Name = "button_setfamilychalet";
            this.button_setfamilychalet.Size = new System.Drawing.Size(229, 34);
            this.button_setfamilychalet.TabIndex = 22;
            this.button_setfamilychalet.Text = "Set as Family Chalet";
            this.button_setfamilychalet.UseVisualStyleBackColor = false;
            this.button_setfamilychalet.Click += new System.EventHandler(this.button_setfamilychalet_Click);
            // 
            // label_normal
            // 
            this.label_normal.AutoSize = true;
            this.label_normal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_normal.Location = new System.Drawing.Point(27, 287);
            this.label_normal.Name = "label_normal";
            this.label_normal.Size = new System.Drawing.Size(86, 25);
            this.label_normal.TabIndex = 21;
            this.label_normal.Text = "Normal:";
            // 
            // label_family
            // 
            this.label_family.AutoSize = true;
            this.label_family.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_family.Location = new System.Drawing.Point(156, 287);
            this.label_family.Name = "label_family";
            this.label_family.Size = new System.Drawing.Size(81, 25);
            this.label_family.TabIndex = 21;
            this.label_family.Text = "Family:";
            // 
            // label_largefamily
            // 
            this.label_largefamily.AutoSize = true;
            this.label_largefamily.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_largefamily.Location = new System.Drawing.Point(251, 287);
            this.label_largefamily.Name = "label_largefamily";
            this.label_largefamily.Size = new System.Drawing.Size(142, 25);
            this.label_largefamily.TabIndex = 21;
            this.label_largefamily.Text = "Large Family:";
            // 
            // label_addingremovingchalets
            // 
            this.label_addingremovingchalets.AutoSize = true;
            this.label_addingremovingchalets.Enabled = false;
            this.label_addingremovingchalets.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_addingremovingchalets.Location = new System.Drawing.Point(10, 255);
            this.label_addingremovingchalets.Name = "label_addingremovingchalets";
            this.label_addingremovingchalets.Size = new System.Drawing.Size(126, 25);
            this.label_addingremovingchalets.TabIndex = 21;
            this.label_addingremovingchalets.Text = "Removing...";
            this.label_addingremovingchalets.Visible = false;
            // 
            // label_totalnumberofchalets
            // 
            this.label_totalnumberofchalets.AutoSize = true;
            this.label_totalnumberofchalets.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_totalnumberofchalets.Location = new System.Drawing.Point(10, 255);
            this.label_totalnumberofchalets.Name = "label_totalnumberofchalets";
            this.label_totalnumberofchalets.Size = new System.Drawing.Size(250, 25);
            this.label_totalnumberofchalets.TabIndex = 21;
            this.label_totalnumberofchalets.Text = "Total Number of Chalets:";
            // 
            // listBox_largefamilychalets
            // 
            this.listBox_largefamilychalets.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_largefamilychalets.FormattingEnabled = true;
            this.listBox_largefamilychalets.ItemHeight = 25;
            this.listBox_largefamilychalets.Location = new System.Drawing.Point(262, 315);
            this.listBox_largefamilychalets.Name = "listBox_largefamilychalets";
            this.listBox_largefamilychalets.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_largefamilychalets.Size = new System.Drawing.Size(120, 129);
            this.listBox_largefamilychalets.TabIndex = 20;
            this.listBox_largefamilychalets.SelectedIndexChanged += new System.EventHandler(this.listBox_largefamilychalets_SelectedIndexChanged);
            // 
            // listBox_familychalets
            // 
            this.listBox_familychalets.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_familychalets.FormattingEnabled = true;
            this.listBox_familychalets.ItemHeight = 25;
            this.listBox_familychalets.Location = new System.Drawing.Point(136, 315);
            this.listBox_familychalets.Name = "listBox_familychalets";
            this.listBox_familychalets.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_familychalets.Size = new System.Drawing.Size(120, 129);
            this.listBox_familychalets.TabIndex = 19;
            this.listBox_familychalets.SelectedIndexChanged += new System.EventHandler(this.listBox_familychalets_SelectedIndexChanged);
            // 
            // listBox_normalchalets
            // 
            this.listBox_normalchalets.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_normalchalets.FormattingEnabled = true;
            this.listBox_normalchalets.ItemHeight = 25;
            this.listBox_normalchalets.Location = new System.Drawing.Point(10, 315);
            this.listBox_normalchalets.Name = "listBox_normalchalets";
            this.listBox_normalchalets.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_normalchalets.Size = new System.Drawing.Size(120, 129);
            this.listBox_normalchalets.TabIndex = 18;
            this.listBox_normalchalets.SelectedIndexChanged += new System.EventHandler(this.listBox_normalchalets_SelectedIndexChanged);
            // 
            // numericUpDown_numberofchalets
            // 
            this.numericUpDown_numberofchalets.AutoSize = true;
            this.numericUpDown_numberofchalets.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown_numberofchalets.Location = new System.Drawing.Point(266, 253);
            this.numericUpDown_numberofchalets.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_numberofchalets.Name = "numericUpDown_numberofchalets";
            this.numericUpDown_numberofchalets.Size = new System.Drawing.Size(61, 30);
            this.numericUpDown_numberofchalets.TabIndex = 17;
            this.numericUpDown_numberofchalets.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_numberofchalets.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_numberofchalets.ValueChanged += new System.EventHandler(this.numericUpDown_numberofchalets_ValueChanged);
            // 
            // button_browsebackup_backup
            // 
            this.button_browsebackup_backup.BackColor = System.Drawing.Color.White;
            this.button_browsebackup_backup.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_browsebackup_backup.Location = new System.Drawing.Point(574, 3);
            this.button_browsebackup_backup.Name = "button_browsebackup_backup";
            this.button_browsebackup_backup.Size = new System.Drawing.Size(95, 37);
            this.button_browsebackup_backup.TabIndex = 6;
            this.button_browsebackup_backup.Text = "Browse";
            this.button_browsebackup_backup.UseVisualStyleBackColor = false;
            this.button_browsebackup_backup.Click += new System.EventHandler(this.button_browsebackup_backup_Click);
            // 
            // picturebox_logo_backup
            // 
            this.picturebox_logo_backup.Image = ((System.Drawing.Image)(resources.GetObject("picturebox_logo_backup.Image")));
            this.picturebox_logo_backup.Location = new System.Drawing.Point(313, 30);
            this.picturebox_logo_backup.Name = "picturebox_logo_backup";
            this.picturebox_logo_backup.Size = new System.Drawing.Size(363, 38);
            this.picturebox_logo_backup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturebox_logo_backup.TabIndex = 5;
            this.picturebox_logo_backup.TabStop = false;
            // 
            // panel_banner_backup
            // 
            this.panel_banner_backup.BackColor = System.Drawing.Color.Blue;
            this.panel_banner_backup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_banner_backup.Controls.Add(this.picturebox_logo_backup);
            this.panel_banner_backup.Controls.Add(this.label_titlebackupandchalets);
            this.panel_banner_backup.Location = new System.Drawing.Point(0, 0);
            this.panel_banner_backup.Name = "panel_banner_backup";
            this.panel_banner_backup.Size = new System.Drawing.Size(683, 100);
            this.panel_banner_backup.TabIndex = 5;
            // 
            // label_titlebackupandchalets
            // 
            this.label_titlebackupandchalets.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_titlebackupandchalets.ForeColor = System.Drawing.Color.White;
            this.label_titlebackupandchalets.Location = new System.Drawing.Point(10, 7);
            this.label_titlebackupandchalets.Name = "label_titlebackupandchalets";
            this.label_titlebackupandchalets.Size = new System.Drawing.Size(297, 78);
            this.label_titlebackupandchalets.TabIndex = 3;
            this.label_titlebackupandchalets.Text = "Backup and Chalets";
            this.label_titlebackupandchalets.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // form_backupandchalets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(683, 603);
            this.Controls.Add(this.panel_backupandrestore_backup);
            this.Controls.Add(this.panel_banner_backup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "form_backupandchalets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chichester Cattery Booking System : Backup and Chalets";
            this.Load += new System.EventHandler(this.form_backupandchalets_Load);
            this.panel_backupandrestore_backup.ResumeLayout(false);
            this.panel_backupandrestore_backup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_numberofchalets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_logo_backup)).EndInit();
            this.panel_banner_backup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_connectionsettings_backup;
        private System.Windows.Forms.Label label_printregistrationsandbookings_backup;
        private System.Windows.Forms.Label label_backuptofile_backup;
        private System.Windows.Forms.Label label_restorefrombackup_backup;
        private System.Windows.Forms.TextBox text_restoredirectory_backup;
        private System.Windows.Forms.TextBox text_backupdirectory_backup;
        private System.Windows.Forms.Button button_backup_backup;
        private System.Windows.Forms.Button button_exitbackup_backup;
        private System.Windows.Forms.Button button_printregistrationsandbookings_backup;
        private System.Windows.Forms.Button button_restore_backup;
        private System.Windows.Forms.Button button_connectionsettings_backup;
        private System.Windows.Forms.Button button_browserestore_backup;
        private System.Windows.Forms.Panel panel_backupandrestore_backup;
        private System.Windows.Forms.Button button_browsebackup_backup;
        private System.Windows.Forms.PictureBox picturebox_logo_backup;
        private System.Windows.Forms.Panel panel_banner_backup;
        private NumericUpDown numericUpDown_numberofchalets;
        private Label label_titlebackupandchalets;
        private Button button_setnormalchalet;
        private Button button_setlargefamilychalet;
        private Button button_setfamilychalet;
        private Label label_family;
        private Label label_largefamily;
        private Label label_totalnumberofchalets;
        private ListBox listBox_largefamilychalets;
        private ListBox listBox_familychalets;
        private ListBox listBox_normalchalets;
        private Label label_normal;
        private ProgressBar progressBar_restore;
        private ProgressBar progressBar_backup;
        private Label label_addingremovingchalets;
    }
}