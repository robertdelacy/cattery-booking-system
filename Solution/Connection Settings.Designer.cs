using System.Windows.Forms;
using Global;
namespace Solution
{
    partial class form_connectionsettings
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
                    try
                    {
                        Application.OpenForms[Application.OpenForms.Count - 1].BringToFront(); //Brings to front the form below the current form
                        Application.OpenForms[Application.OpenForms.Count - 1].WindowState = FormWindowState.Maximized; //Maximises the form below the current form
                        Application.OpenForms[Application.OpenForms.Count - 1].Close(); //Closes the next form
                    }
                    catch
                    {
                        try
                        {
                            Application.OpenForms[Application.OpenForms.Count - 1].Activate(); //Brings to front the form below the current form
                            Application.OpenForms[Application.OpenForms.Count - 1].WindowState = FormWindowState.Maximized; //Maximises the form below the current form
                        }
                        catch
                        {
                        }
                    }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_connectionsettings));
            this.panel_banner_connectionsettings = new System.Windows.Forms.Panel();
            this.picturebox_logo_connectionsettings = new System.Windows.Forms.PictureBox();
            this.label_titleconnectionsettings = new System.Windows.Forms.Label();
            this.panel_connectionsettings = new System.Windows.Forms.Panel();
            this.label_password = new System.Windows.Forms.Label();
            this.label_username = new System.Windows.Forms.Label();
            this.label_port = new System.Windows.Forms.Label();
            this.label_datasource = new System.Windows.Forms.Label();
            this.text_password_connectionsettings = new System.Windows.Forms.TextBox();
            this.text_username_connectionsettings = new System.Windows.Forms.TextBox();
            this.text_port_connectionsettings = new System.Windows.Forms.TextBox();
            this.text_datasource_connectionsettings = new System.Windows.Forms.TextBox();
            this.button_testconnection_connectionsettings = new System.Windows.Forms.Button();
            this.button_exitconnectionsettings_connectionsettings = new System.Windows.Forms.Button();
            this.panel_banner_connectionsettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_logo_connectionsettings)).BeginInit();
            this.panel_connectionsettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_banner_connectionsettings
            // 
            this.panel_banner_connectionsettings.BackColor = System.Drawing.Color.Blue;
            this.panel_banner_connectionsettings.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_banner_connectionsettings.Controls.Add(this.picturebox_logo_connectionsettings);
            this.panel_banner_connectionsettings.Controls.Add(this.label_titleconnectionsettings);
            this.panel_banner_connectionsettings.Location = new System.Drawing.Point(0, 0);
            this.panel_banner_connectionsettings.Name = "panel_banner_connectionsettings";
            this.panel_banner_connectionsettings.Size = new System.Drawing.Size(683, 100);
            this.panel_banner_connectionsettings.TabIndex = 6;
            // 
            // picturebox_logo_connectionsettings
            // 
            this.picturebox_logo_connectionsettings.Image = ((System.Drawing.Image)(resources.GetObject("picturebox_logo_connectionsettings.Image")));
            this.picturebox_logo_connectionsettings.Location = new System.Drawing.Point(313, 30);
            this.picturebox_logo_connectionsettings.Name = "picturebox_logo_connectionsettings";
            this.picturebox_logo_connectionsettings.Size = new System.Drawing.Size(363, 38);
            this.picturebox_logo_connectionsettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturebox_logo_connectionsettings.TabIndex = 5;
            this.picturebox_logo_connectionsettings.TabStop = false;
            // 
            // label_titleconnectionsettings
            // 
            this.label_titleconnectionsettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_titleconnectionsettings.ForeColor = System.Drawing.Color.White;
            this.label_titleconnectionsettings.Location = new System.Drawing.Point(10, 7);
            this.label_titleconnectionsettings.Name = "label_titleconnectionsettings";
            this.label_titleconnectionsettings.Size = new System.Drawing.Size(297, 78);
            this.label_titleconnectionsettings.TabIndex = 3;
            this.label_titleconnectionsettings.Text = "Connection Settings";
            this.label_titleconnectionsettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_connectionsettings
            // 
            this.panel_connectionsettings.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_connectionsettings.Controls.Add(this.label_password);
            this.panel_connectionsettings.Controls.Add(this.label_username);
            this.panel_connectionsettings.Controls.Add(this.label_port);
            this.panel_connectionsettings.Controls.Add(this.label_datasource);
            this.panel_connectionsettings.Controls.Add(this.text_password_connectionsettings);
            this.panel_connectionsettings.Controls.Add(this.text_username_connectionsettings);
            this.panel_connectionsettings.Controls.Add(this.text_port_connectionsettings);
            this.panel_connectionsettings.Controls.Add(this.text_datasource_connectionsettings);
            this.panel_connectionsettings.Controls.Add(this.button_testconnection_connectionsettings);
            this.panel_connectionsettings.Controls.Add(this.button_exitconnectionsettings_connectionsettings);
            this.panel_connectionsettings.Location = new System.Drawing.Point(0, 100);
            this.panel_connectionsettings.Name = "panel_connectionsettings";
            this.panel_connectionsettings.Size = new System.Drawing.Size(683, 206);
            this.panel_connectionsettings.TabIndex = 7;
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_password.Location = new System.Drawing.Point(10, 118);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(114, 26);
            this.label_password.TabIndex = 16;
            this.label_password.Text = "Password:";
            // 
            // label_username
            // 
            this.label_username.AutoSize = true;
            this.label_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_username.Location = new System.Drawing.Point(10, 80);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(119, 26);
            this.label_username.TabIndex = 16;
            this.label_username.Text = "Username:";
            // 
            // label_port
            // 
            this.label_port.AutoSize = true;
            this.label_port.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_port.Location = new System.Drawing.Point(10, 42);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(58, 26);
            this.label_port.TabIndex = 16;
            this.label_port.Text = "Port:";
            // 
            // label_datasource
            // 
            this.label_datasource.AutoSize = true;
            this.label_datasource.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_datasource.Location = new System.Drawing.Point(10, 4);
            this.label_datasource.Name = "label_datasource";
            this.label_datasource.Size = new System.Drawing.Size(139, 26);
            this.label_datasource.TabIndex = 16;
            this.label_datasource.Text = "Data Source:";
            // 
            // text_password_connectionsettings
            // 
            this.text_password_connectionsettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_password_connectionsettings.Location = new System.Drawing.Point(256, 118);
            this.text_password_connectionsettings.Name = "text_password_connectionsettings";
            this.text_password_connectionsettings.PasswordChar = '*';
            this.text_password_connectionsettings.Size = new System.Drawing.Size(413, 32);
            this.text_password_connectionsettings.TabIndex = 3;
            this.text_password_connectionsettings.Enter += new System.EventHandler(this.text_ConnectionSettings_Enter);
            this.text_password_connectionsettings.KeyDown += new System.Windows.Forms.KeyEventHandler(this.connectionsettings_KeyPress);
            this.text_password_connectionsettings.Leave += new System.EventHandler(this.text_ConnectionSettings_Leave);
            // 
            // text_username_connectionsettings
            // 
            this.text_username_connectionsettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_username_connectionsettings.Location = new System.Drawing.Point(256, 80);
            this.text_username_connectionsettings.Name = "text_username_connectionsettings";
            this.text_username_connectionsettings.Size = new System.Drawing.Size(413, 32);
            this.text_username_connectionsettings.TabIndex = 2;
            this.text_username_connectionsettings.Enter += new System.EventHandler(this.text_ConnectionSettings_Enter);
            this.text_username_connectionsettings.KeyDown += new System.Windows.Forms.KeyEventHandler(this.connectionsettings_KeyPress);
            this.text_username_connectionsettings.Leave += new System.EventHandler(this.text_ConnectionSettings_Leave);
            // 
            // text_port_connectionsettings
            // 
            this.text_port_connectionsettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_port_connectionsettings.Location = new System.Drawing.Point(256, 42);
            this.text_port_connectionsettings.Name = "text_port_connectionsettings";
            this.text_port_connectionsettings.Size = new System.Drawing.Size(413, 32);
            this.text_port_connectionsettings.TabIndex = 1;
            this.text_port_connectionsettings.Enter += new System.EventHandler(this.text_ConnectionSettings_Enter);
            this.text_port_connectionsettings.KeyDown += new System.Windows.Forms.KeyEventHandler(this.connectionsettings_KeyPress);
            this.text_port_connectionsettings.Leave += new System.EventHandler(this.text_ConnectionSettings_Leave);
            // 
            // text_datasource_connectionsettings
            // 
            this.text_datasource_connectionsettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_datasource_connectionsettings.Location = new System.Drawing.Point(256, 4);
            this.text_datasource_connectionsettings.Name = "text_datasource_connectionsettings";
            this.text_datasource_connectionsettings.Size = new System.Drawing.Size(413, 32);
            this.text_datasource_connectionsettings.TabIndex = 0;
            this.text_datasource_connectionsettings.Enter += new System.EventHandler(this.text_ConnectionSettings_Enter);
            this.text_datasource_connectionsettings.KeyDown += new System.Windows.Forms.KeyEventHandler(this.connectionsettings_KeyPress);
            this.text_datasource_connectionsettings.Leave += new System.EventHandler(this.text_ConnectionSettings_Leave);
            // 
            // button_testconnection_connectionsettings
            // 
            this.button_testconnection_connectionsettings.BackColor = System.Drawing.Color.White;
            this.button_testconnection_connectionsettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_testconnection_connectionsettings.Location = new System.Drawing.Point(10, 156);
            this.button_testconnection_connectionsettings.Name = "button_testconnection_connectionsettings";
            this.button_testconnection_connectionsettings.Size = new System.Drawing.Size(198, 34);
            this.button_testconnection_connectionsettings.TabIndex = 4;
            this.button_testconnection_connectionsettings.Text = "Test Connection";
            this.button_testconnection_connectionsettings.UseVisualStyleBackColor = false;
            this.button_testconnection_connectionsettings.Click += new System.EventHandler(this.button_testconnection_connectionsettings_Click);
            // 
            // button_exitconnectionsettings_connectionsettings
            // 
            this.button_exitconnectionsettings_connectionsettings.BackColor = System.Drawing.Color.White;
            this.button_exitconnectionsettings_connectionsettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_exitconnectionsettings_connectionsettings.Location = new System.Drawing.Point(392, 156);
            this.button_exitconnectionsettings_connectionsettings.Name = "button_exitconnectionsettings_connectionsettings";
            this.button_exitconnectionsettings_connectionsettings.Size = new System.Drawing.Size(277, 34);
            this.button_exitconnectionsettings_connectionsettings.TabIndex = 5;
            this.button_exitconnectionsettings_connectionsettings.Text = "Close Connection Settings";
            this.button_exitconnectionsettings_connectionsettings.UseVisualStyleBackColor = false;
            this.button_exitconnectionsettings_connectionsettings.Click += new System.EventHandler(this.button_exitconnectionsettings_connectionsettings_Click);
            // 
            // form_connectionsettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(683, 306);
            this.Controls.Add(this.panel_connectionsettings);
            this.Controls.Add(this.panel_banner_connectionsettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "form_connectionsettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Chichester Cattery Booking System : Connection Settings";
            this.Load += new System.EventHandler(this.form_connectionsettings_Load);
            this.panel_banner_connectionsettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_logo_connectionsettings)).EndInit();
            this.panel_connectionsettings.ResumeLayout(false);
            this.panel_connectionsettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_banner_connectionsettings;
        private System.Windows.Forms.PictureBox picturebox_logo_connectionsettings;
        private System.Windows.Forms.Label label_titleconnectionsettings;
        private System.Windows.Forms.Panel panel_connectionsettings;
        private System.Windows.Forms.Button button_exitconnectionsettings_connectionsettings;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.Label label_port;
        private System.Windows.Forms.Label label_datasource;
        private System.Windows.Forms.TextBox text_password_connectionsettings;
        private System.Windows.Forms.TextBox text_username_connectionsettings;
        private System.Windows.Forms.TextBox text_port_connectionsettings;
        private System.Windows.Forms.TextBox text_datasource_connectionsettings;
        private System.Windows.Forms.Button button_testconnection_connectionsettings;
    }
}