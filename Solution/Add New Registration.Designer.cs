using System.Windows.Forms;
using Global;

namespace Solution
{
    partial class form_addnewregistration
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
                this.WindowState = FormWindowState.Maximized; //If the disposing is a closing, maximise the 'Add New Registration' form
                this.TopMost = true; //Shows the 'Add New Registration' form on top
                if (MessageBox.Show("Are you sure you want to close the current window?", "Close?", MessageBoxButtons.YesNo) == DialogResult.Yes) //Show messagebox
                {// for confirmation on closing
                    if (disposing && (components != null)) //If yes, dispose
                    {
                        components.Dispose();
                    }
                    base.Dispose(disposing);

                    if (Application.OpenForms.Count < 1) //Check if the form is the last form
                    {
                        Application.Exit(); //If yes, exit the application
                    }
                    else if (Application.OpenForms.Count >= 1)
                    {//If not the last form:
                        Application.OpenForms[Application.OpenForms.Count - 1].BringToFront(); //Brings to front the form below the 'Add New Registration' form
                        Application.OpenForms[Application.OpenForms.Count - 1].WindowState = FormWindowState.Maximized; //Maximises the form below the 'Add New Registration' form
                        Application.OpenForms[Application.OpenForms.Count - 1].Close(); //Closes the next form
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
            { //If a disposing is a navigation:
                if (disposing && (components != null)) //Current form disposed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_addnewregistration));
            this.text_vetnumber_addnewregistration = new System.Windows.Forms.TextBox();
            this.text_vetname_addnewregistration = new System.Windows.Forms.TextBox();
            this.text_absencenumber_addnewregistration = new System.Windows.Forms.TextBox();
            this.text_absencecontact_addnewregistration = new System.Windows.Forms.TextBox();
            this.label_vetnumber_addnewregistration = new System.Windows.Forms.Label();
            this.label_contactnumber_addnewregistration = new System.Windows.Forms.Label();
            this.label_vetname_addnewregistration = new System.Windows.Forms.Label();
            this.label_contactname_addnewregistration = new System.Windows.Forms.Label();
            this.label_vetdetails_addnewregistration = new System.Windows.Forms.Label();
            this.label_absencecontact_addnewregistration = new System.Windows.Forms.Label();
            this.label_vaccinations_addnewregistration = new System.Windows.Forms.Label();
            this.text_catfoodtoavoid_addnewregistration = new System.Windows.Forms.TextBox();
            this.text_catallergies_addnewregistration = new System.Windows.Forms.TextBox();
            this.text_catspecialtreatment_addnewregistration = new System.Windows.Forms.TextBox();
            this.text_catdiet_addnewregistration = new System.Windows.Forms.TextBox();
            this.button_deletecat_addnewregistration = new System.Windows.Forms.Button();
            this.button_editcat_addnewregistration = new System.Windows.Forms.Button();
            this.button_addcat_addnewregistration = new System.Windows.Forms.Button();
            this.text_addcatdescription_addnewregistration = new System.Windows.Forms.TextBox();
            this.datetimepicker_vaccinationduedate_addnewregistration = new System.Windows.Forms.DateTimePicker();
            this.datetimepicker_dob_addnewregistration = new System.Windows.Forms.DateTimePicker();
            this.combobox_catsex_addnewregistration = new System.Windows.Forms.ComboBox();
            this.text_addcatname_addnewregistration = new System.Windows.Forms.TextBox();
            this.label_catdescription_addnewregistration = new System.Windows.Forms.Label();
            this.label_catdiet_addnewregistration = new System.Windows.Forms.Label();
            this.label_catfoodtoavoid_addnewregistration = new System.Windows.Forms.Label();
            this.label_catallergies_addnewregistration = new System.Windows.Forms.Label();
            this.label_catspecialtreatment_addnewregistration = new System.Windows.Forms.Label();
            this.label_catdob_addnewregistration = new System.Windows.Forms.Label();
            this.label_catname_addnewregistration = new System.Windows.Forms.Label();
            this.label_catsex_addnewregistration = new System.Windows.Forms.Label();
            this.text_town_addnewregistration = new System.Windows.Forms.TextBox();
            this.text_postcode_addnewregistration = new System.Windows.Forms.TextBox();
            this.button_goback_addnewregistration = new System.Windows.Forms.Button();
            this.button_minimizeform_addnewregistration = new System.Windows.Forms.Button();
            this.button_closeform_addnewregistration = new System.Windows.Forms.Button();
            this.picturebox_logo_addnewregistration = new System.Windows.Forms.PictureBox();
            this.button_searchbookings_addnewregistration = new System.Windows.Forms.Button();
            this.text_bookingquery_addnewregistration = new System.Windows.Forms.TextBox();
            this.label_postcode_addnewregistration = new System.Windows.Forms.Label();
            this.label_bookingsearch_addnewregistration = new System.Windows.Forms.Label();
            this.button_registrations_addnewregistration = new System.Windows.Forms.Button();
            this.label_town_addnewregistration = new System.Windows.Forms.Label();
            this.text_homenumber_addnewregistration = new System.Windows.Forms.TextBox();
            this.text_address_addnewregistration = new System.Windows.Forms.TextBox();
            this.listbox_moblies_addnewregistration = new System.Windows.Forms.ListBox();
            this.text_addmobile_addnewregistration = new System.Windows.Forms.TextBox();
            this.button_deletemobile_addnewregistration = new System.Windows.Forms.Button();
            this.button_editmobile_addnewregistration = new System.Windows.Forms.Button();
            this.button_addmobile_addnewregistration = new System.Windows.Forms.Button();
            this.button_bookings_addnewregistration = new System.Windows.Forms.Button();
            this.listbox_owners_addnewregistration = new System.Windows.Forms.ListBox();
            this.text_addowner_addnewregistration = new System.Windows.Forms.TextBox();
            this.button_deleteowner_addnewregistration = new System.Windows.Forms.Button();
            this.button_editowner_addnewregistration = new System.Windows.Forms.Button();
            this.button_addowner_addnewregistration = new System.Windows.Forms.Button();
            this.label_catsinfo_addnewregistration = new System.Windows.Forms.Label();
            this.label_address_addnewregistration = new System.Windows.Forms.Label();
            this.label_ownername_addnewregistration = new System.Windows.Forms.Label();
            this.label_hometelephone_addnewregistration = new System.Windows.Forms.Label();
            this.button_home_addnewregistration = new System.Windows.Forms.Button();
            this.label_mobile_addnewregistration = new System.Windows.Forms.Label();
            this.label_ownerdetails_addnewregistration = new System.Windows.Forms.Label();
            this.button_confirmregistration_addnewregistration = new System.Windows.Forms.Button();
            this.button_cancelnewregistration_addnewregistration = new System.Windows.Forms.Button();
            this.panel_banner_addnewregistration = new System.Windows.Forms.Panel();
            this.label_titleaddnewregistration = new System.Windows.Forms.Label();
            this.panel_catlistboxes_addnewregistration = new System.Windows.Forms.Panel();
            this.label_listboxspecialtreatment_addnewregistration = new System.Windows.Forms.Label();
            this.label_listboxfood_addnewregistration = new System.Windows.Forms.Label();
            this.label_listboxdescription_addnewregistration = new System.Windows.Forms.Label();
            this.label_listboxvaccination_addnewregistration = new System.Windows.Forms.Label();
            this.label_listboxsex_addnewregistration = new System.Windows.Forms.Label();
            this.label_listboxdob_addnewregistration = new System.Windows.Forms.Label();
            this.label_listboxname_addnewregistration = new System.Windows.Forms.Label();
            this.listbox_foodtobeavoided_addnewregistration = new System.Windows.Forms.ListBox();
            this.listbox_description_addnewregistration = new System.Windows.Forms.ListBox();
            this.listbox_allergies_addnewregistration = new System.Windows.Forms.ListBox();
            this.listbox_vaccination_addnewregistration = new System.Windows.Forms.ListBox();
            this.listbox_sex_addnewregistration = new System.Windows.Forms.ListBox();
            this.listbox_dob_addnewregistration = new System.Windows.Forms.ListBox();
            this.listbox_specialtreatment_addnewregistration = new System.Windows.Forms.ListBox();
            this.listbox_catnames_addnewregistration = new System.Windows.Forms.ListBox();
            this.listbox_diet_addnewregistration = new System.Windows.Forms.ListBox();
            this.timer_addnewregistration = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_logo_addnewregistration)).BeginInit();
            this.panel_banner_addnewregistration.SuspendLayout();
            this.panel_catlistboxes_addnewregistration.SuspendLayout();
            this.SuspendLayout();
            // 
            // text_vetnumber_addnewregistration
            // 
            this.text_vetnumber_addnewregistration.Enabled = false;
            this.text_vetnumber_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_vetnumber_addnewregistration.Location = new System.Drawing.Point(1194, 573);
            this.text_vetnumber_addnewregistration.Name = "text_vetnumber_addnewregistration";
            this.text_vetnumber_addnewregistration.Size = new System.Drawing.Size(160, 31);
            this.text_vetnumber_addnewregistration.TabIndex = 21;
            this.text_vetnumber_addnewregistration.Enter += new System.EventHandler(this.RegistrationAdd_Enter);
            this.text_vetnumber_addnewregistration.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RegistrationAdd_KeyDown);
            this.text_vetnumber_addnewregistration.Leave += new System.EventHandler(this.RegistrationAdd_Leave);
            // 
            // text_vetname_addnewregistration
            // 
            this.text_vetname_addnewregistration.Enabled = false;
            this.text_vetname_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_vetname_addnewregistration.Location = new System.Drawing.Point(1047, 536);
            this.text_vetname_addnewregistration.Name = "text_vetname_addnewregistration";
            this.text_vetname_addnewregistration.Size = new System.Drawing.Size(307, 31);
            this.text_vetname_addnewregistration.TabIndex = 20;
            this.text_vetname_addnewregistration.Enter += new System.EventHandler(this.RegistrationAdd_Enter);
            this.text_vetname_addnewregistration.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RegistrationAdd_KeyDown);
            this.text_vetname_addnewregistration.Leave += new System.EventHandler(this.RegistrationAdd_Leave);
            // 
            // text_absencenumber_addnewregistration
            // 
            this.text_absencenumber_addnewregistration.Enabled = false;
            this.text_absencenumber_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_absencenumber_addnewregistration.Location = new System.Drawing.Point(1194, 474);
            this.text_absencenumber_addnewregistration.Name = "text_absencenumber_addnewregistration";
            this.text_absencenumber_addnewregistration.Size = new System.Drawing.Size(160, 31);
            this.text_absencenumber_addnewregistration.TabIndex = 19;
            this.text_absencenumber_addnewregistration.Enter += new System.EventHandler(this.RegistrationAdd_Enter);
            this.text_absencenumber_addnewregistration.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RegistrationAdd_KeyDown);
            this.text_absencenumber_addnewregistration.Leave += new System.EventHandler(this.RegistrationAdd_Leave);
            // 
            // text_absencecontact_addnewregistration
            // 
            this.text_absencecontact_addnewregistration.Enabled = false;
            this.text_absencecontact_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_absencecontact_addnewregistration.Location = new System.Drawing.Point(1047, 437);
            this.text_absencecontact_addnewregistration.Name = "text_absencecontact_addnewregistration";
            this.text_absencecontact_addnewregistration.Size = new System.Drawing.Size(307, 31);
            this.text_absencecontact_addnewregistration.TabIndex = 18;
            this.text_absencecontact_addnewregistration.Enter += new System.EventHandler(this.RegistrationAdd_Enter);
            this.text_absencecontact_addnewregistration.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RegistrationAdd_KeyDown);
            this.text_absencecontact_addnewregistration.Leave += new System.EventHandler(this.RegistrationAdd_Leave);
            // 
            // label_vetnumber_addnewregistration
            // 
            this.label_vetnumber_addnewregistration.AutoSize = true;
            this.label_vetnumber_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_vetnumber_addnewregistration.Location = new System.Drawing.Point(967, 576);
            this.label_vetnumber_addnewregistration.Name = "label_vetnumber_addnewregistration";
            this.label_vetnumber_addnewregistration.Size = new System.Drawing.Size(201, 25);
            this.label_vetnumber_addnewregistration.TabIndex = 168;
            this.label_vetnumber_addnewregistration.Text = "Telephone Number:";
            // 
            // label_contactnumber_addnewregistration
            // 
            this.label_contactnumber_addnewregistration.AutoSize = true;
            this.label_contactnumber_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_contactnumber_addnewregistration.Location = new System.Drawing.Point(967, 477);
            this.label_contactnumber_addnewregistration.Name = "label_contactnumber_addnewregistration";
            this.label_contactnumber_addnewregistration.Size = new System.Drawing.Size(201, 25);
            this.label_contactnumber_addnewregistration.TabIndex = 164;
            this.label_contactnumber_addnewregistration.Text = "Telephone Number:";
            // 
            // label_vetname_addnewregistration
            // 
            this.label_vetname_addnewregistration.AutoSize = true;
            this.label_vetname_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_vetname_addnewregistration.Location = new System.Drawing.Point(967, 539);
            this.label_vetname_addnewregistration.Name = "label_vetname_addnewregistration";
            this.label_vetname_addnewregistration.Size = new System.Drawing.Size(74, 25);
            this.label_vetname_addnewregistration.TabIndex = 163;
            this.label_vetname_addnewregistration.Text = "Name:";
            // 
            // label_contactname_addnewregistration
            // 
            this.label_contactname_addnewregistration.AutoSize = true;
            this.label_contactname_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_contactname_addnewregistration.Location = new System.Drawing.Point(967, 440);
            this.label_contactname_addnewregistration.Name = "label_contactname_addnewregistration";
            this.label_contactname_addnewregistration.Size = new System.Drawing.Size(74, 25);
            this.label_contactname_addnewregistration.TabIndex = 166;
            this.label_contactname_addnewregistration.Text = "Name:";
            // 
            // label_vetdetails_addnewregistration
            // 
            this.label_vetdetails_addnewregistration.AutoSize = true;
            this.label_vetdetails_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_vetdetails_addnewregistration.Location = new System.Drawing.Point(1135, 508);
            this.label_vetdetails_addnewregistration.Name = "label_vetdetails_addnewregistration";
            this.label_vetdetails_addnewregistration.Size = new System.Drawing.Size(50, 25);
            this.label_vetdetails_addnewregistration.TabIndex = 165;
            this.label_vetdetails_addnewregistration.Text = "Vet:";
            // 
            // label_absencecontact_addnewregistration
            // 
            this.label_absencecontact_addnewregistration.AutoSize = true;
            this.label_absencecontact_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_absencecontact_addnewregistration.Location = new System.Drawing.Point(1012, 402);
            this.label_absencecontact_addnewregistration.Name = "label_absencecontact_addnewregistration";
            this.label_absencecontact_addnewregistration.Size = new System.Drawing.Size(297, 25);
            this.label_absencecontact_addnewregistration.TabIndex = 167;
            this.label_absencecontact_addnewregistration.Text = "Person to contact in absence:";
            // 
            // label_vaccinations_addnewregistration
            // 
            this.label_vaccinations_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_vaccinations_addnewregistration.Location = new System.Drawing.Point(338, 427);
            this.label_vaccinations_addnewregistration.Name = "label_vaccinations_addnewregistration";
            this.label_vaccinations_addnewregistration.Size = new System.Drawing.Size(159, 77);
            this.label_vaccinations_addnewregistration.TabIndex = 162;
            this.label_vaccinations_addnewregistration.Text = "Next Vaccination Due date:";
            this.label_vaccinations_addnewregistration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // text_catfoodtoavoid_addnewregistration
            // 
            this.text_catfoodtoavoid_addnewregistration.Enabled = false;
            this.text_catfoodtoavoid_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_catfoodtoavoid_addnewregistration.Location = new System.Drawing.Point(508, 455);
            this.text_catfoodtoavoid_addnewregistration.Name = "text_catfoodtoavoid_addnewregistration";
            this.text_catfoodtoavoid_addnewregistration.Size = new System.Drawing.Size(262, 31);
            this.text_catfoodtoavoid_addnewregistration.TabIndex = 14;
            this.text_catfoodtoavoid_addnewregistration.Enter += new System.EventHandler(this.CatAdd_Enter);
            this.text_catfoodtoavoid_addnewregistration.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CatAdd_KeyDown);
            this.text_catfoodtoavoid_addnewregistration.Leave += new System.EventHandler(this.CatAdd_Leave);
            // 
            // text_catallergies_addnewregistration
            // 
            this.text_catallergies_addnewregistration.Enabled = false;
            this.text_catallergies_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_catallergies_addnewregistration.Location = new System.Drawing.Point(776, 455);
            this.text_catallergies_addnewregistration.Name = "text_catallergies_addnewregistration";
            this.text_catallergies_addnewregistration.Size = new System.Drawing.Size(165, 31);
            this.text_catallergies_addnewregistration.TabIndex = 15;
            this.text_catallergies_addnewregistration.Enter += new System.EventHandler(this.CatAdd_Enter);
            this.text_catallergies_addnewregistration.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CatAdd_KeyDown);
            this.text_catallergies_addnewregistration.Leave += new System.EventHandler(this.CatAdd_Leave);
            // 
            // text_catspecialtreatment_addnewregistration
            // 
            this.text_catspecialtreatment_addnewregistration.Enabled = false;
            this.text_catspecialtreatment_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_catspecialtreatment_addnewregistration.Location = new System.Drawing.Point(508, 517);
            this.text_catspecialtreatment_addnewregistration.Name = "text_catspecialtreatment_addnewregistration";
            this.text_catspecialtreatment_addnewregistration.Size = new System.Drawing.Size(328, 31);
            this.text_catspecialtreatment_addnewregistration.TabIndex = 16;
            this.text_catspecialtreatment_addnewregistration.Enter += new System.EventHandler(this.CatAdd_Enter);
            this.text_catspecialtreatment_addnewregistration.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CatAdd_KeyDown);
            this.text_catspecialtreatment_addnewregistration.Leave += new System.EventHandler(this.CatAdd_Leave);
            // 
            // text_catdiet_addnewregistration
            // 
            this.text_catdiet_addnewregistration.Enabled = false;
            this.text_catdiet_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_catdiet_addnewregistration.Location = new System.Drawing.Point(12, 644);
            this.text_catdiet_addnewregistration.Name = "text_catdiet_addnewregistration";
            this.text_catdiet_addnewregistration.Size = new System.Drawing.Size(226, 31);
            this.text_catdiet_addnewregistration.TabIndex = 13;
            this.text_catdiet_addnewregistration.TextChanged += new System.EventHandler(this.text_catdiet_addnewregistration_TextChanged);
            this.text_catdiet_addnewregistration.Enter += new System.EventHandler(this.CatAdd_Enter);
            this.text_catdiet_addnewregistration.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CatAdd_KeyDown);
            this.text_catdiet_addnewregistration.Leave += new System.EventHandler(this.CatAdd_Leave);
            // 
            // button_deletecat_addnewregistration
            // 
            this.button_deletecat_addnewregistration.BackColor = System.Drawing.Color.White;
            this.button_deletecat_addnewregistration.Enabled = false;
            this.button_deletecat_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_deletecat_addnewregistration.Location = new System.Drawing.Point(820, 680);
            this.button_deletecat_addnewregistration.Name = "button_deletecat_addnewregistration";
            this.button_deletecat_addnewregistration.Size = new System.Drawing.Size(121, 35);
            this.button_deletecat_addnewregistration.TabIndex = 157;
            this.button_deletecat_addnewregistration.Text = "Delete Cat";
            this.button_deletecat_addnewregistration.UseVisualStyleBackColor = false;
            this.button_deletecat_addnewregistration.Click += new System.EventHandler(this.button_deletecat_addnewregistration_Click);
            // 
            // button_editcat_addnewregistration
            // 
            this.button_editcat_addnewregistration.BackColor = System.Drawing.Color.White;
            this.button_editcat_addnewregistration.Enabled = false;
            this.button_editcat_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_editcat_addnewregistration.Location = new System.Drawing.Point(244, 680);
            this.button_editcat_addnewregistration.Name = "button_editcat_addnewregistration";
            this.button_editcat_addnewregistration.Size = new System.Drawing.Size(96, 35);
            this.button_editcat_addnewregistration.TabIndex = 156;
            this.button_editcat_addnewregistration.Text = "Edit Cat";
            this.button_editcat_addnewregistration.UseVisualStyleBackColor = false;
            this.button_editcat_addnewregistration.Click += new System.EventHandler(this.button_editcat_addnewregistration_Click);
            // 
            // button_addcat_addnewregistration
            // 
            this.button_addcat_addnewregistration.BackColor = System.Drawing.Color.White;
            this.button_addcat_addnewregistration.Enabled = false;
            this.button_addcat_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_addcat_addnewregistration.Location = new System.Drawing.Point(842, 513);
            this.button_addcat_addnewregistration.Name = "button_addcat_addnewregistration";
            this.button_addcat_addnewregistration.Size = new System.Drawing.Size(99, 35);
            this.button_addcat_addnewregistration.TabIndex = 17;
            this.button_addcat_addnewregistration.Text = "Add Cat";
            this.button_addcat_addnewregistration.UseVisualStyleBackColor = false;
            this.button_addcat_addnewregistration.Click += new System.EventHandler(this.button_addcat_addnewregistration_Click);
            // 
            // text_addcatdescription_addnewregistration
            // 
            this.text_addcatdescription_addnewregistration.Enabled = false;
            this.text_addcatdescription_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_addcatdescription_addnewregistration.Location = new System.Drawing.Point(12, 579);
            this.text_addcatdescription_addnewregistration.Name = "text_addcatdescription_addnewregistration";
            this.text_addcatdescription_addnewregistration.Size = new System.Drawing.Size(226, 31);
            this.text_addcatdescription_addnewregistration.TabIndex = 12;
            this.text_addcatdescription_addnewregistration.TextChanged += new System.EventHandler(this.text_addcatdescription_addnewregistration_TextChanged);
            this.text_addcatdescription_addnewregistration.Enter += new System.EventHandler(this.CatAdd_Enter);
            this.text_addcatdescription_addnewregistration.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CatAdd_KeyDown);
            this.text_addcatdescription_addnewregistration.Leave += new System.EventHandler(this.CatAdd_Leave);
            // 
            // datetimepicker_vaccinationduedate_addnewregistration
            // 
            this.datetimepicker_vaccinationduedate_addnewregistration.Enabled = false;
            this.datetimepicker_vaccinationduedate_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datetimepicker_vaccinationduedate_addnewregistration.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datetimepicker_vaccinationduedate_addnewregistration.Location = new System.Drawing.Point(343, 507);
            this.datetimepicker_vaccinationduedate_addnewregistration.Name = "datetimepicker_vaccinationduedate_addnewregistration";
            this.datetimepicker_vaccinationduedate_addnewregistration.Size = new System.Drawing.Size(159, 31);
            this.datetimepicker_vaccinationduedate_addnewregistration.TabIndex = 11;
            // 
            // datetimepicker_dob_addnewregistration
            // 
            this.datetimepicker_dob_addnewregistration.Enabled = false;
            this.datetimepicker_dob_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datetimepicker_dob_addnewregistration.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datetimepicker_dob_addnewregistration.Location = new System.Drawing.Point(32, 517);
            this.datetimepicker_dob_addnewregistration.Name = "datetimepicker_dob_addnewregistration";
            this.datetimepicker_dob_addnewregistration.Size = new System.Drawing.Size(159, 31);
            this.datetimepicker_dob_addnewregistration.TabIndex = 9;
            // 
            // combobox_catsex_addnewregistration
            // 
            this.combobox_catsex_addnewregistration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.combobox_catsex_addnewregistration.Enabled = false;
            this.combobox_catsex_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combobox_catsex_addnewregistration.FormattingEnabled = true;
            this.combobox_catsex_addnewregistration.Items.AddRange(new object[] {
            "Female",
            "Male"});
            this.combobox_catsex_addnewregistration.Location = new System.Drawing.Point(216, 455);
            this.combobox_catsex_addnewregistration.Name = "combobox_catsex_addnewregistration";
            this.combobox_catsex_addnewregistration.Size = new System.Drawing.Size(121, 100);
            this.combobox_catsex_addnewregistration.TabIndex = 10;
            this.combobox_catsex_addnewregistration.SelectedIndexChanged += new System.EventHandler(this.combobox_catsex_addnewregistration_SelectedIndexChanged);
            // 
            // text_addcatname_addnewregistration
            // 
            this.text_addcatname_addnewregistration.Enabled = false;
            this.text_addcatname_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_addcatname_addnewregistration.Location = new System.Drawing.Point(12, 455);
            this.text_addcatname_addnewregistration.Name = "text_addcatname_addnewregistration";
            this.text_addcatname_addnewregistration.Size = new System.Drawing.Size(198, 31);
            this.text_addcatname_addnewregistration.TabIndex = 8;
            this.text_addcatname_addnewregistration.TextChanged += new System.EventHandler(this.text_addcatname_addnewregistration_TextChanged);
            // 
            // label_catdescription_addnewregistration
            // 
            this.label_catdescription_addnewregistration.AutoSize = true;
            this.label_catdescription_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_catdescription_addnewregistration.Location = new System.Drawing.Point(29, 551);
            this.label_catdescription_addnewregistration.Name = "label_catdescription_addnewregistration";
            this.label_catdescription_addnewregistration.Size = new System.Drawing.Size(191, 25);
            this.label_catdescription_addnewregistration.TabIndex = 143;
            this.label_catdescription_addnewregistration.Text = "Colour, Breed, etc:";
            // 
            // label_catdiet_addnewregistration
            // 
            this.label_catdiet_addnewregistration.AutoSize = true;
            this.label_catdiet_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_catdiet_addnewregistration.Location = new System.Drawing.Point(52, 613);
            this.label_catdiet_addnewregistration.Name = "label_catdiet_addnewregistration";
            this.label_catdiet_addnewregistration.Size = new System.Drawing.Size(147, 25);
            this.label_catdiet_addnewregistration.TabIndex = 144;
            this.label_catdiet_addnewregistration.Text = "Brand of food:";
            // 
            // label_catfoodtoavoid_addnewregistration
            // 
            this.label_catfoodtoavoid_addnewregistration.AutoSize = true;
            this.label_catfoodtoavoid_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_catfoodtoavoid_addnewregistration.Location = new System.Drawing.Point(508, 427);
            this.label_catfoodtoavoid_addnewregistration.Name = "label_catfoodtoavoid_addnewregistration";
            this.label_catfoodtoavoid_addnewregistration.Size = new System.Drawing.Size(262, 25);
            this.label_catfoodtoavoid_addnewregistration.TabIndex = 141;
            this.label_catfoodtoavoid_addnewregistration.Text = "Any foods to be avoided?:";
            // 
            // label_catallergies_addnewregistration
            // 
            this.label_catallergies_addnewregistration.AutoSize = true;
            this.label_catallergies_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_catallergies_addnewregistration.Location = new System.Drawing.Point(782, 427);
            this.label_catallergies_addnewregistration.Name = "label_catallergies_addnewregistration";
            this.label_catallergies_addnewregistration.Size = new System.Drawing.Size(154, 25);
            this.label_catallergies_addnewregistration.TabIndex = 142;
            this.label_catallergies_addnewregistration.Text = "Any allergies?:";
            // 
            // label_catspecialtreatment_addnewregistration
            // 
            this.label_catspecialtreatment_addnewregistration.AutoSize = true;
            this.label_catspecialtreatment_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_catspecialtreatment_addnewregistration.Location = new System.Drawing.Point(511, 489);
            this.label_catspecialtreatment_addnewregistration.Name = "label_catspecialtreatment_addnewregistration";
            this.label_catspecialtreatment_addnewregistration.Size = new System.Drawing.Size(322, 25);
            this.label_catspecialtreatment_addnewregistration.TabIndex = 147;
            this.label_catspecialtreatment_addnewregistration.Text = "Any special treatment required?:";
            // 
            // label_catdob_addnewregistration
            // 
            this.label_catdob_addnewregistration.AutoSize = true;
            this.label_catdob_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_catdob_addnewregistration.Location = new System.Drawing.Point(43, 489);
            this.label_catdob_addnewregistration.Name = "label_catdob_addnewregistration";
            this.label_catdob_addnewregistration.Size = new System.Drawing.Size(137, 25);
            this.label_catdob_addnewregistration.TabIndex = 148;
            this.label_catdob_addnewregistration.Text = "Date of Birth:";
            // 
            // label_catname_addnewregistration
            // 
            this.label_catname_addnewregistration.AutoSize = true;
            this.label_catname_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_catname_addnewregistration.Location = new System.Drawing.Point(74, 427);
            this.label_catname_addnewregistration.Name = "label_catname_addnewregistration";
            this.label_catname_addnewregistration.Size = new System.Drawing.Size(74, 25);
            this.label_catname_addnewregistration.TabIndex = 145;
            this.label_catname_addnewregistration.Text = "Name:";
            // 
            // label_catsex_addnewregistration
            // 
            this.label_catsex_addnewregistration.AutoSize = true;
            this.label_catsex_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_catsex_addnewregistration.Location = new System.Drawing.Point(248, 427);
            this.label_catsex_addnewregistration.Name = "label_catsex_addnewregistration";
            this.label_catsex_addnewregistration.Size = new System.Drawing.Size(55, 25);
            this.label_catsex_addnewregistration.TabIndex = 146;
            this.label_catsex_addnewregistration.Text = "Sex:";
            // 
            // text_town_addnewregistration
            // 
            this.text_town_addnewregistration.Enabled = false;
            this.text_town_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_town_addnewregistration.Location = new System.Drawing.Point(458, 328);
            this.text_town_addnewregistration.Name = "text_town_addnewregistration";
            this.text_town_addnewregistration.Size = new System.Drawing.Size(182, 31);
            this.text_town_addnewregistration.TabIndex = 3;
            this.text_town_addnewregistration.TextChanged += new System.EventHandler(this.text_town_addnewregistration_TextChanged);
            // 
            // text_postcode_addnewregistration
            // 
            this.text_postcode_addnewregistration.Enabled = false;
            this.text_postcode_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_postcode_addnewregistration.Location = new System.Drawing.Point(646, 328);
            this.text_postcode_addnewregistration.Name = "text_postcode_addnewregistration";
            this.text_postcode_addnewregistration.Size = new System.Drawing.Size(145, 31);
            this.text_postcode_addnewregistration.TabIndex = 4;
            this.text_postcode_addnewregistration.TextChanged += new System.EventHandler(this.text_postcode_addnewregistration_TextChanged);
            // 
            // button_goback_addnewregistration
            // 
            this.button_goback_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_goback_addnewregistration.Location = new System.Drawing.Point(1134, 3);
            this.button_goback_addnewregistration.Name = "button_goback_addnewregistration";
            this.button_goback_addnewregistration.Size = new System.Drawing.Size(105, 36);
            this.button_goback_addnewregistration.TabIndex = 6;
            this.button_goback_addnewregistration.TabStop = false;
            this.button_goback_addnewregistration.Text = "Go Back";
            this.button_goback_addnewregistration.UseVisualStyleBackColor = true;
            this.button_goback_addnewregistration.Visible = false;
            this.button_goback_addnewregistration.Click += new System.EventHandler(this.button_goback_addnewregistration_Click);
            // 
            // button_minimizeform_addnewregistration
            // 
            this.button_minimizeform_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_minimizeform_addnewregistration.Location = new System.Drawing.Point(1245, 3);
            this.button_minimizeform_addnewregistration.Name = "button_minimizeform_addnewregistration";
            this.button_minimizeform_addnewregistration.Size = new System.Drawing.Size(36, 36);
            this.button_minimizeform_addnewregistration.TabIndex = 5;
            this.button_minimizeform_addnewregistration.TabStop = false;
            this.button_minimizeform_addnewregistration.Text = "_";
            this.button_minimizeform_addnewregistration.UseVisualStyleBackColor = true;
            this.button_minimizeform_addnewregistration.Click += new System.EventHandler(this.button_minimizeform_addnewregistration_Click);
            // 
            // button_closeform_addnewregistration
            // 
            this.button_closeform_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_closeform_addnewregistration.Location = new System.Drawing.Point(1287, 3);
            this.button_closeform_addnewregistration.Name = "button_closeform_addnewregistration";
            this.button_closeform_addnewregistration.Size = new System.Drawing.Size(57, 36);
            this.button_closeform_addnewregistration.TabIndex = 5;
            this.button_closeform_addnewregistration.TabStop = false;
            this.button_closeform_addnewregistration.Text = "Exit";
            this.button_closeform_addnewregistration.UseVisualStyleBackColor = true;
            this.button_closeform_addnewregistration.Click += new System.EventHandler(this.button_closeform_addnewregistration_Click);
            // 
            // picturebox_logo_addnewregistration
            // 
            this.picturebox_logo_addnewregistration.Image = ((System.Drawing.Image)(resources.GetObject("picturebox_logo_addnewregistration.Image")));
            this.picturebox_logo_addnewregistration.Location = new System.Drawing.Point(996, 60);
            this.picturebox_logo_addnewregistration.Name = "picturebox_logo_addnewregistration";
            this.picturebox_logo_addnewregistration.Size = new System.Drawing.Size(363, 38);
            this.picturebox_logo_addnewregistration.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturebox_logo_addnewregistration.TabIndex = 4;
            this.picturebox_logo_addnewregistration.TabStop = false;
            // 
            // button_searchbookings_addnewregistration
            // 
            this.button_searchbookings_addnewregistration.BackColor = System.Drawing.Color.White;
            this.button_searchbookings_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_searchbookings_addnewregistration.Location = new System.Drawing.Point(578, 79);
            this.button_searchbookings_addnewregistration.Name = "button_searchbookings_addnewregistration";
            this.button_searchbookings_addnewregistration.Size = new System.Drawing.Size(181, 64);
            this.button_searchbookings_addnewregistration.TabIndex = 1;
            this.button_searchbookings_addnewregistration.Text = "Search Booking System";
            this.button_searchbookings_addnewregistration.UseVisualStyleBackColor = false;
            this.button_searchbookings_addnewregistration.Click += new System.EventHandler(this.button_searchbookings_addnewregistration_Click);
            // 
            // text_bookingquery_addnewregistration
            // 
            this.text_bookingquery_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_bookingquery_addnewregistration.Location = new System.Drawing.Point(578, 42);
            this.text_bookingquery_addnewregistration.Name = "text_bookingquery_addnewregistration";
            this.text_bookingquery_addnewregistration.Size = new System.Drawing.Size(181, 31);
            this.text_bookingquery_addnewregistration.TabIndex = 0;
            this.text_bookingquery_addnewregistration.Enter += new System.EventHandler(this.text_bookingquery_addnewregistration_Enter);
            this.text_bookingquery_addnewregistration.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_bookingquery_addnewregistration_KeyDown);
            this.text_bookingquery_addnewregistration.Leave += new System.EventHandler(this.text_bookingquery_addnewregistration_Leave);
            // 
            // label_postcode_addnewregistration
            // 
            this.label_postcode_addnewregistration.AutoSize = true;
            this.label_postcode_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_postcode_addnewregistration.Location = new System.Drawing.Point(641, 300);
            this.label_postcode_addnewregistration.Name = "label_postcode_addnewregistration";
            this.label_postcode_addnewregistration.Size = new System.Drawing.Size(108, 25);
            this.label_postcode_addnewregistration.TabIndex = 138;
            this.label_postcode_addnewregistration.Text = "Postcode:";
            // 
            // label_bookingsearch_addnewregistration
            // 
            this.label_bookingsearch_addnewregistration.AutoSize = true;
            this.label_bookingsearch_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_bookingsearch_addnewregistration.ForeColor = System.Drawing.Color.White;
            this.label_bookingsearch_addnewregistration.Location = new System.Drawing.Point(578, 14);
            this.label_bookingsearch_addnewregistration.Name = "label_bookingsearch_addnewregistration";
            this.label_bookingsearch_addnewregistration.Size = new System.Drawing.Size(181, 25);
            this.label_bookingsearch_addnewregistration.TabIndex = 1;
            this.label_bookingsearch_addnewregistration.Text = "Search Bookings:";
            // 
            // button_registrations_addnewregistration
            // 
            this.button_registrations_addnewregistration.BackColor = System.Drawing.Color.White;
            this.button_registrations_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_registrations_addnewregistration.Location = new System.Drawing.Point(294, 10);
            this.button_registrations_addnewregistration.Name = "button_registrations_addnewregistration";
            this.button_registrations_addnewregistration.Size = new System.Drawing.Size(136, 136);
            this.button_registrations_addnewregistration.TabIndex = 0;
            this.button_registrations_addnewregistration.TabStop = false;
            this.button_registrations_addnewregistration.Text = "Registration System";
            this.button_registrations_addnewregistration.UseVisualStyleBackColor = false;
            this.button_registrations_addnewregistration.Click += new System.EventHandler(this.button_registrations_addnewregistration_Click);
            // 
            // label_town_addnewregistration
            // 
            this.label_town_addnewregistration.AutoSize = true;
            this.label_town_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_town_addnewregistration.Location = new System.Drawing.Point(453, 300);
            this.label_town_addnewregistration.Name = "label_town_addnewregistration";
            this.label_town_addnewregistration.Size = new System.Drawing.Size(70, 25);
            this.label_town_addnewregistration.TabIndex = 137;
            this.label_town_addnewregistration.Text = "Town:";
            // 
            // text_homenumber_addnewregistration
            // 
            this.text_homenumber_addnewregistration.Enabled = false;
            this.text_homenumber_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_homenumber_addnewregistration.Location = new System.Drawing.Point(797, 328);
            this.text_homenumber_addnewregistration.Name = "text_homenumber_addnewregistration";
            this.text_homenumber_addnewregistration.Size = new System.Drawing.Size(175, 31);
            this.text_homenumber_addnewregistration.TabIndex = 5;
            this.text_homenumber_addnewregistration.TextChanged += new System.EventHandler(this.text_homenumber_addnewregistration_TextChanged);
            // 
            // text_address_addnewregistration
            // 
            this.text_address_addnewregistration.Enabled = false;
            this.text_address_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_address_addnewregistration.Location = new System.Drawing.Point(458, 186);
            this.text_address_addnewregistration.Multiline = true;
            this.text_address_addnewregistration.Name = "text_address_addnewregistration";
            this.text_address_addnewregistration.Size = new System.Drawing.Size(514, 111);
            this.text_address_addnewregistration.TabIndex = 2;
            this.text_address_addnewregistration.TextChanged += new System.EventHandler(this.text_address_addnewregistration_TextChanged);
            // 
            // listbox_moblies_addnewregistration
            // 
            this.listbox_moblies_addnewregistration.Enabled = false;
            this.listbox_moblies_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listbox_moblies_addnewregistration.FormattingEnabled = true;
            this.listbox_moblies_addnewregistration.ItemHeight = 25;
            this.listbox_moblies_addnewregistration.Location = new System.Drawing.Point(1095, 264);
            this.listbox_moblies_addnewregistration.Name = "listbox_moblies_addnewregistration";
            this.listbox_moblies_addnewregistration.Size = new System.Drawing.Size(160, 54);
            this.listbox_moblies_addnewregistration.TabIndex = 134;
            this.listbox_moblies_addnewregistration.TabStop = false;
            this.listbox_moblies_addnewregistration.SelectedIndexChanged += new System.EventHandler(this.listbox_moblies_addnewregistration_SelectedIndexChanged);
            // 
            // text_addmobile_addnewregistration
            // 
            this.text_addmobile_addnewregistration.Enabled = false;
            this.text_addmobile_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_addmobile_addnewregistration.Location = new System.Drawing.Point(1095, 186);
            this.text_addmobile_addnewregistration.Name = "text_addmobile_addnewregistration";
            this.text_addmobile_addnewregistration.Size = new System.Drawing.Size(160, 31);
            this.text_addmobile_addnewregistration.TabIndex = 6;
            this.text_addmobile_addnewregistration.TextChanged += new System.EventHandler(this.text_addmobile_addnewregistration_TextChanged);
            this.text_addmobile_addnewregistration.Enter += new System.EventHandler(this.text_addmobile_addnewregistration_Enter);
            this.text_addmobile_addnewregistration.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_addmobile_addnewregistration_KeyDown);
            this.text_addmobile_addnewregistration.Leave += new System.EventHandler(this.text_addmobile_addnewregistration_Leave);
            // 
            // button_deletemobile_addnewregistration
            // 
            this.button_deletemobile_addnewregistration.BackColor = System.Drawing.Color.White;
            this.button_deletemobile_addnewregistration.Enabled = false;
            this.button_deletemobile_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_deletemobile_addnewregistration.Location = new System.Drawing.Point(1163, 324);
            this.button_deletemobile_addnewregistration.Name = "button_deletemobile_addnewregistration";
            this.button_deletemobile_addnewregistration.Size = new System.Drawing.Size(156, 35);
            this.button_deletemobile_addnewregistration.TabIndex = 132;
            this.button_deletemobile_addnewregistration.Text = "Delete Mobile";
            this.button_deletemobile_addnewregistration.UseVisualStyleBackColor = false;
            this.button_deletemobile_addnewregistration.Click += new System.EventHandler(this.button_deletemobile_addnewregistration_Click);
            // 
            // button_editmobile_addnewregistration
            // 
            this.button_editmobile_addnewregistration.BackColor = System.Drawing.Color.White;
            this.button_editmobile_addnewregistration.Enabled = false;
            this.button_editmobile_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_editmobile_addnewregistration.Location = new System.Drawing.Point(1030, 324);
            this.button_editmobile_addnewregistration.Name = "button_editmobile_addnewregistration";
            this.button_editmobile_addnewregistration.Size = new System.Drawing.Size(127, 35);
            this.button_editmobile_addnewregistration.TabIndex = 131;
            this.button_editmobile_addnewregistration.Text = "Edit Mobile";
            this.button_editmobile_addnewregistration.UseVisualStyleBackColor = false;
            this.button_editmobile_addnewregistration.Click += new System.EventHandler(this.button_editmobile_addnewregistration_Click);
            // 
            // button_addmobile_addnewregistration
            // 
            this.button_addmobile_addnewregistration.BackColor = System.Drawing.Color.White;
            this.button_addmobile_addnewregistration.Enabled = false;
            this.button_addmobile_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_addmobile_addnewregistration.Location = new System.Drawing.Point(1106, 223);
            this.button_addmobile_addnewregistration.Name = "button_addmobile_addnewregistration";
            this.button_addmobile_addnewregistration.Size = new System.Drawing.Size(137, 35);
            this.button_addmobile_addnewregistration.TabIndex = 7;
            this.button_addmobile_addnewregistration.Text = "Add Mobile";
            this.button_addmobile_addnewregistration.UseVisualStyleBackColor = false;
            this.button_addmobile_addnewregistration.Click += new System.EventHandler(this.button_addmobile_addnewregistration_Click);
            // 
            // button_bookings_addnewregistration
            // 
            this.button_bookings_addnewregistration.BackColor = System.Drawing.Color.White;
            this.button_bookings_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_bookings_addnewregistration.Location = new System.Drawing.Point(152, 10);
            this.button_bookings_addnewregistration.Name = "button_bookings_addnewregistration";
            this.button_bookings_addnewregistration.Size = new System.Drawing.Size(136, 136);
            this.button_bookings_addnewregistration.TabIndex = 0;
            this.button_bookings_addnewregistration.TabStop = false;
            this.button_bookings_addnewregistration.Text = "Booking System";
            this.button_bookings_addnewregistration.UseVisualStyleBackColor = false;
            this.button_bookings_addnewregistration.Click += new System.EventHandler(this.button_bookings_addnewregistration_Click);
            // 
            // listbox_owners_addnewregistration
            // 
            this.listbox_owners_addnewregistration.Enabled = false;
            this.listbox_owners_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listbox_owners_addnewregistration.FormattingEnabled = true;
            this.listbox_owners_addnewregistration.ItemHeight = 25;
            this.listbox_owners_addnewregistration.Location = new System.Drawing.Point(121, 264);
            this.listbox_owners_addnewregistration.Name = "listbox_owners_addnewregistration";
            this.listbox_owners_addnewregistration.Size = new System.Drawing.Size(307, 54);
            this.listbox_owners_addnewregistration.Sorted = true;
            this.listbox_owners_addnewregistration.TabIndex = 129;
            this.listbox_owners_addnewregistration.TabStop = false;
            this.listbox_owners_addnewregistration.SelectedIndexChanged += new System.EventHandler(this.listbox_owners_addnewregistration_SelectedIndexChanged);
            // 
            // text_addowner_addnewregistration
            // 
            this.text_addowner_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_addowner_addnewregistration.Location = new System.Drawing.Point(121, 186);
            this.text_addowner_addnewregistration.Name = "text_addowner_addnewregistration";
            this.text_addowner_addnewregistration.Size = new System.Drawing.Size(307, 31);
            this.text_addowner_addnewregistration.TabIndex = 0;
            this.text_addowner_addnewregistration.TextChanged += new System.EventHandler(this.text_addowner_addnewregistration_TextChanged);
            this.text_addowner_addnewregistration.Enter += new System.EventHandler(this.text_addowner_addnewregistration_Enter);
            this.text_addowner_addnewregistration.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_addowner_addnewregistration_KeyDown);
            this.text_addowner_addnewregistration.Leave += new System.EventHandler(this.text_addowner_addnewregistration_Leave);
            // 
            // button_deleteowner_addnewregistration
            // 
            this.button_deleteowner_addnewregistration.BackColor = System.Drawing.Color.White;
            this.button_deleteowner_addnewregistration.Enabled = false;
            this.button_deleteowner_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_deleteowner_addnewregistration.Location = new System.Drawing.Point(278, 324);
            this.button_deleteowner_addnewregistration.Name = "button_deleteowner_addnewregistration";
            this.button_deleteowner_addnewregistration.Size = new System.Drawing.Size(150, 35);
            this.button_deleteowner_addnewregistration.TabIndex = 127;
            this.button_deleteowner_addnewregistration.Text = "Delete Owner";
            this.button_deleteowner_addnewregistration.UseVisualStyleBackColor = false;
            this.button_deleteowner_addnewregistration.Click += new System.EventHandler(this.button_deleteowner_addnewregistration_Click);
            // 
            // button_editowner_addnewregistration
            // 
            this.button_editowner_addnewregistration.BackColor = System.Drawing.Color.White;
            this.button_editowner_addnewregistration.Enabled = false;
            this.button_editowner_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_editowner_addnewregistration.Location = new System.Drawing.Point(121, 324);
            this.button_editowner_addnewregistration.Name = "button_editowner_addnewregistration";
            this.button_editowner_addnewregistration.Size = new System.Drawing.Size(125, 35);
            this.button_editowner_addnewregistration.TabIndex = 126;
            this.button_editowner_addnewregistration.Text = "Edit Owner";
            this.button_editowner_addnewregistration.UseVisualStyleBackColor = false;
            this.button_editowner_addnewregistration.Click += new System.EventHandler(this.button_editowner_addnewregistration_Click);
            // 
            // button_addowner_addnewregistration
            // 
            this.button_addowner_addnewregistration.BackColor = System.Drawing.Color.White;
            this.button_addowner_addnewregistration.Enabled = false;
            this.button_addowner_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_addowner_addnewregistration.Location = new System.Drawing.Point(202, 223);
            this.button_addowner_addnewregistration.Name = "button_addowner_addnewregistration";
            this.button_addowner_addnewregistration.Size = new System.Drawing.Size(136, 35);
            this.button_addowner_addnewregistration.TabIndex = 1;
            this.button_addowner_addnewregistration.Text = "Add Owner";
            this.button_addowner_addnewregistration.UseVisualStyleBackColor = false;
            this.button_addowner_addnewregistration.Click += new System.EventHandler(this.button_addowner_addnewregistration_Click);
            // 
            // label_catsinfo_addnewregistration
            // 
            this.label_catsinfo_addnewregistration.AutoSize = true;
            this.label_catsinfo_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_catsinfo_addnewregistration.Location = new System.Drawing.Point(429, 402);
            this.label_catsinfo_addnewregistration.Name = "label_catsinfo_addnewregistration";
            this.label_catsinfo_addnewregistration.Size = new System.Drawing.Size(76, 25);
            this.label_catsinfo_addnewregistration.TabIndex = 121;
            this.label_catsinfo_addnewregistration.Text = "Cat(s):";
            // 
            // label_address_addnewregistration
            // 
            this.label_address_addnewregistration.AutoSize = true;
            this.label_address_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_address_addnewregistration.Location = new System.Drawing.Point(453, 158);
            this.label_address_addnewregistration.Name = "label_address_addnewregistration";
            this.label_address_addnewregistration.Size = new System.Drawing.Size(97, 25);
            this.label_address_addnewregistration.TabIndex = 120;
            this.label_address_addnewregistration.Text = "Address:";
            // 
            // label_ownername_addnewregistration
            // 
            this.label_ownername_addnewregistration.AutoSize = true;
            this.label_ownername_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ownername_addnewregistration.Location = new System.Drawing.Point(238, 158);
            this.label_ownername_addnewregistration.Name = "label_ownername_addnewregistration";
            this.label_ownername_addnewregistration.Size = new System.Drawing.Size(74, 25);
            this.label_ownername_addnewregistration.TabIndex = 119;
            this.label_ownername_addnewregistration.Text = "Name:";
            // 
            // label_hometelephone_addnewregistration
            // 
            this.label_hometelephone_addnewregistration.AutoSize = true;
            this.label_hometelephone_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_hometelephone_addnewregistration.Location = new System.Drawing.Point(790, 300);
            this.label_hometelephone_addnewregistration.Name = "label_hometelephone_addnewregistration";
            this.label_hometelephone_addnewregistration.Size = new System.Drawing.Size(182, 25);
            this.label_hometelephone_addnewregistration.TabIndex = 124;
            this.label_hometelephone_addnewregistration.Text = "Home Telephone:";
            // 
            // button_home_addnewregistration
            // 
            this.button_home_addnewregistration.BackColor = System.Drawing.Color.White;
            this.button_home_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_home_addnewregistration.Location = new System.Drawing.Point(10, 10);
            this.button_home_addnewregistration.Name = "button_home_addnewregistration";
            this.button_home_addnewregistration.Size = new System.Drawing.Size(136, 136);
            this.button_home_addnewregistration.TabIndex = 0;
            this.button_home_addnewregistration.TabStop = false;
            this.button_home_addnewregistration.Text = "Home";
            this.button_home_addnewregistration.UseVisualStyleBackColor = false;
            this.button_home_addnewregistration.Click += new System.EventHandler(this.button_home_addnewregistration_Click);
            // 
            // label_mobile_addnewregistration
            // 
            this.label_mobile_addnewregistration.AutoSize = true;
            this.label_mobile_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_mobile_addnewregistration.Location = new System.Drawing.Point(1134, 158);
            this.label_mobile_addnewregistration.Name = "label_mobile_addnewregistration";
            this.label_mobile_addnewregistration.Size = new System.Drawing.Size(82, 25);
            this.label_mobile_addnewregistration.TabIndex = 123;
            this.label_mobile_addnewregistration.Text = "Mobile:";
            // 
            // label_ownerdetails_addnewregistration
            // 
            this.label_ownerdetails_addnewregistration.AutoSize = true;
            this.label_ownerdetails_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ownerdetails_addnewregistration.Location = new System.Drawing.Point(12, 158);
            this.label_ownerdetails_addnewregistration.Name = "label_ownerdetails_addnewregistration";
            this.label_ownerdetails_addnewregistration.Size = new System.Drawing.Size(80, 25);
            this.label_ownerdetails_addnewregistration.TabIndex = 122;
            this.label_ownerdetails_addnewregistration.Text = "Owner:";
            // 
            // button_confirmregistration_addnewregistration
            // 
            this.button_confirmregistration_addnewregistration.BackColor = System.Drawing.Color.White;
            this.button_confirmregistration_addnewregistration.Enabled = false;
            this.button_confirmregistration_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_confirmregistration_addnewregistration.Location = new System.Drawing.Point(1061, 721);
            this.button_confirmregistration_addnewregistration.Name = "button_confirmregistration_addnewregistration";
            this.button_confirmregistration_addnewregistration.Size = new System.Drawing.Size(293, 35);
            this.button_confirmregistration_addnewregistration.TabIndex = 22;
            this.button_confirmregistration_addnewregistration.Text = "Confirm New Registration";
            this.button_confirmregistration_addnewregistration.UseVisualStyleBackColor = false;
            this.button_confirmregistration_addnewregistration.Click += new System.EventHandler(this.button_confirmregistration_addnewregistration_Click);
            // 
            // button_cancelnewregistration_addnewregistration
            // 
            this.button_cancelnewregistration_addnewregistration.BackColor = System.Drawing.Color.White;
            this.button_cancelnewregistration_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cancelnewregistration_addnewregistration.Location = new System.Drawing.Point(12, 721);
            this.button_cancelnewregistration_addnewregistration.Name = "button_cancelnewregistration_addnewregistration";
            this.button_cancelnewregistration_addnewregistration.Size = new System.Drawing.Size(258, 35);
            this.button_cancelnewregistration_addnewregistration.TabIndex = 118;
            this.button_cancelnewregistration_addnewregistration.TabStop = false;
            this.button_cancelnewregistration_addnewregistration.Text = "Cancel New Registration";
            this.button_cancelnewregistration_addnewregistration.UseVisualStyleBackColor = false;
            this.button_cancelnewregistration_addnewregistration.Click += new System.EventHandler(this.button_cancelnewregistration_addnewregistration_Click);
            // 
            // panel_banner_addnewregistration
            // 
            this.panel_banner_addnewregistration.BackColor = System.Drawing.Color.Blue;
            this.panel_banner_addnewregistration.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_banner_addnewregistration.Controls.Add(this.label_titleaddnewregistration);
            this.panel_banner_addnewregistration.Controls.Add(this.button_goback_addnewregistration);
            this.panel_banner_addnewregistration.Controls.Add(this.button_minimizeform_addnewregistration);
            this.panel_banner_addnewregistration.Controls.Add(this.button_closeform_addnewregistration);
            this.panel_banner_addnewregistration.Controls.Add(this.picturebox_logo_addnewregistration);
            this.panel_banner_addnewregistration.Controls.Add(this.button_searchbookings_addnewregistration);
            this.panel_banner_addnewregistration.Controls.Add(this.text_bookingquery_addnewregistration);
            this.panel_banner_addnewregistration.Controls.Add(this.label_bookingsearch_addnewregistration);
            this.panel_banner_addnewregistration.Controls.Add(this.button_registrations_addnewregistration);
            this.panel_banner_addnewregistration.Controls.Add(this.button_bookings_addnewregistration);
            this.panel_banner_addnewregistration.Controls.Add(this.button_home_addnewregistration);
            this.panel_banner_addnewregistration.Location = new System.Drawing.Point(0, 0);
            this.panel_banner_addnewregistration.Name = "panel_banner_addnewregistration";
            this.panel_banner_addnewregistration.Size = new System.Drawing.Size(1366, 155);
            this.panel_banner_addnewregistration.TabIndex = 116;
            // 
            // label_titleaddnewregistration
            // 
            this.label_titleaddnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_titleaddnewregistration.ForeColor = System.Drawing.Color.White;
            this.label_titleaddnewregistration.Location = new System.Drawing.Point(1004, 101);
            this.label_titleaddnewregistration.Name = "label_titleaddnewregistration";
            this.label_titleaddnewregistration.Size = new System.Drawing.Size(347, 42);
            this.label_titleaddnewregistration.TabIndex = 9;
            this.label_titleaddnewregistration.Text = "Add New Registration";
            this.label_titleaddnewregistration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_catlistboxes_addnewregistration
            // 
            this.panel_catlistboxes_addnewregistration.AutoScroll = true;
            this.panel_catlistboxes_addnewregistration.Controls.Add(this.label_listboxspecialtreatment_addnewregistration);
            this.panel_catlistboxes_addnewregistration.Controls.Add(this.label_listboxfood_addnewregistration);
            this.panel_catlistboxes_addnewregistration.Controls.Add(this.label_listboxdescription_addnewregistration);
            this.panel_catlistboxes_addnewregistration.Controls.Add(this.label_listboxvaccination_addnewregistration);
            this.panel_catlistboxes_addnewregistration.Controls.Add(this.label_listboxsex_addnewregistration);
            this.panel_catlistboxes_addnewregistration.Controls.Add(this.label_listboxdob_addnewregistration);
            this.panel_catlistboxes_addnewregistration.Controls.Add(this.label_listboxname_addnewregistration);
            this.panel_catlistboxes_addnewregistration.Controls.Add(this.listbox_foodtobeavoided_addnewregistration);
            this.panel_catlistboxes_addnewregistration.Controls.Add(this.listbox_description_addnewregistration);
            this.panel_catlistboxes_addnewregistration.Controls.Add(this.listbox_allergies_addnewregistration);
            this.panel_catlistboxes_addnewregistration.Controls.Add(this.listbox_vaccination_addnewregistration);
            this.panel_catlistboxes_addnewregistration.Controls.Add(this.listbox_sex_addnewregistration);
            this.panel_catlistboxes_addnewregistration.Controls.Add(this.listbox_dob_addnewregistration);
            this.panel_catlistboxes_addnewregistration.Controls.Add(this.listbox_specialtreatment_addnewregistration);
            this.panel_catlistboxes_addnewregistration.Controls.Add(this.listbox_catnames_addnewregistration);
            this.panel_catlistboxes_addnewregistration.Controls.Add(this.listbox_diet_addnewregistration);
            this.panel_catlistboxes_addnewregistration.Enabled = false;
            this.panel_catlistboxes_addnewregistration.Location = new System.Drawing.Point(244, 554);
            this.panel_catlistboxes_addnewregistration.Name = "panel_catlistboxes_addnewregistration";
            this.panel_catlistboxes_addnewregistration.Size = new System.Drawing.Size(717, 121);
            this.panel_catlistboxes_addnewregistration.TabIndex = 169;
            // 
            // label_listboxspecialtreatment_addnewregistration
            // 
            this.label_listboxspecialtreatment_addnewregistration.AutoSize = true;
            this.label_listboxspecialtreatment_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_listboxspecialtreatment_addnewregistration.Location = new System.Drawing.Point(1029, 0);
            this.label_listboxspecialtreatment_addnewregistration.Name = "label_listboxspecialtreatment_addnewregistration";
            this.label_listboxspecialtreatment_addnewregistration.Size = new System.Drawing.Size(192, 25);
            this.label_listboxspecialtreatment_addnewregistration.TabIndex = 174;
            this.label_listboxspecialtreatment_addnewregistration.Text = "Special Treatment:";
            // 
            // label_listboxfood_addnewregistration
            // 
            this.label_listboxfood_addnewregistration.AutoSize = true;
            this.label_listboxfood_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_listboxfood_addnewregistration.Location = new System.Drawing.Point(792, 0);
            this.label_listboxfood_addnewregistration.Name = "label_listboxfood_addnewregistration";
            this.label_listboxfood_addnewregistration.Size = new System.Drawing.Size(67, 25);
            this.label_listboxfood_addnewregistration.TabIndex = 173;
            this.label_listboxfood_addnewregistration.Text = "Food:";
            // 
            // label_listboxdescription_addnewregistration
            // 
            this.label_listboxdescription_addnewregistration.AutoSize = true;
            this.label_listboxdescription_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_listboxdescription_addnewregistration.Location = new System.Drawing.Point(612, 0);
            this.label_listboxdescription_addnewregistration.Name = "label_listboxdescription_addnewregistration";
            this.label_listboxdescription_addnewregistration.Size = new System.Drawing.Size(126, 25);
            this.label_listboxdescription_addnewregistration.TabIndex = 172;
            this.label_listboxdescription_addnewregistration.Text = "Description:";
            // 
            // label_listboxvaccination_addnewregistration
            // 
            this.label_listboxvaccination_addnewregistration.AutoSize = true;
            this.label_listboxvaccination_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_listboxvaccination_addnewregistration.Location = new System.Drawing.Point(460, 0);
            this.label_listboxvaccination_addnewregistration.Name = "label_listboxvaccination_addnewregistration";
            this.label_listboxvaccination_addnewregistration.Size = new System.Drawing.Size(130, 25);
            this.label_listboxvaccination_addnewregistration.TabIndex = 171;
            this.label_listboxvaccination_addnewregistration.Text = "Vaccination:";
            // 
            // label_listboxsex_addnewregistration
            // 
            this.label_listboxsex_addnewregistration.AutoSize = true;
            this.label_listboxsex_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_listboxsex_addnewregistration.Location = new System.Drawing.Point(348, 0);
            this.label_listboxsex_addnewregistration.Name = "label_listboxsex_addnewregistration";
            this.label_listboxsex_addnewregistration.Size = new System.Drawing.Size(55, 25);
            this.label_listboxsex_addnewregistration.TabIndex = 170;
            this.label_listboxsex_addnewregistration.Text = "Sex:";
            // 
            // label_listboxdob_addnewregistration
            // 
            this.label_listboxdob_addnewregistration.AutoSize = true;
            this.label_listboxdob_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_listboxdob_addnewregistration.Location = new System.Drawing.Point(188, 0);
            this.label_listboxdob_addnewregistration.Name = "label_listboxdob_addnewregistration";
            this.label_listboxdob_addnewregistration.Size = new System.Drawing.Size(75, 25);
            this.label_listboxdob_addnewregistration.TabIndex = 171;
            this.label_listboxdob_addnewregistration.Text = "D.O.B:";
            // 
            // label_listboxname_addnewregistration
            // 
            this.label_listboxname_addnewregistration.AutoSize = true;
            this.label_listboxname_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_listboxname_addnewregistration.Location = new System.Drawing.Point(38, 0);
            this.label_listboxname_addnewregistration.Name = "label_listboxname_addnewregistration";
            this.label_listboxname_addnewregistration.Size = new System.Drawing.Size(74, 25);
            this.label_listboxname_addnewregistration.TabIndex = 170;
            this.label_listboxname_addnewregistration.Text = "Name:";
            // 
            // listbox_foodtobeavoided_addnewregistration
            // 
            this.listbox_foodtobeavoided_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listbox_foodtobeavoided_addnewregistration.FormattingEnabled = true;
            this.listbox_foodtobeavoided_addnewregistration.ItemHeight = 25;
            this.listbox_foodtobeavoided_addnewregistration.Location = new System.Drawing.Point(900, 25);
            this.listbox_foodtobeavoided_addnewregistration.Name = "listbox_foodtobeavoided_addnewregistration";
            this.listbox_foodtobeavoided_addnewregistration.Size = new System.Drawing.Size(150, 4);
            this.listbox_foodtobeavoided_addnewregistration.TabIndex = 177;
            this.listbox_foodtobeavoided_addnewregistration.TabStop = false;
            this.listbox_foodtobeavoided_addnewregistration.SelectedIndexChanged += new System.EventHandler(this.listbox_foodtobeavoided_addnewregistration_SelectedIndexChanged);
            // 
            // listbox_description_addnewregistration
            // 
            this.listbox_description_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listbox_description_addnewregistration.FormattingEnabled = true;
            this.listbox_description_addnewregistration.ItemHeight = 25;
            this.listbox_description_addnewregistration.Location = new System.Drawing.Point(600, 25);
            this.listbox_description_addnewregistration.Name = "listbox_description_addnewregistration";
            this.listbox_description_addnewregistration.Size = new System.Drawing.Size(150, 4);
            this.listbox_description_addnewregistration.TabIndex = 174;
            this.listbox_description_addnewregistration.TabStop = false;
            this.listbox_description_addnewregistration.SelectedIndexChanged += new System.EventHandler(this.listbox_description_addnewregistration_SelectedIndexChanged);
            // 
            // listbox_allergies_addnewregistration
            // 
            this.listbox_allergies_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listbox_allergies_addnewregistration.FormattingEnabled = true;
            this.listbox_allergies_addnewregistration.ItemHeight = 25;
            this.listbox_allergies_addnewregistration.Location = new System.Drawing.Point(1050, 25);
            this.listbox_allergies_addnewregistration.Name = "listbox_allergies_addnewregistration";
            this.listbox_allergies_addnewregistration.Size = new System.Drawing.Size(150, 4);
            this.listbox_allergies_addnewregistration.TabIndex = 176;
            this.listbox_allergies_addnewregistration.TabStop = false;
            this.listbox_allergies_addnewregistration.SelectedIndexChanged += new System.EventHandler(this.listbox_allergies_addnewregistration_SelectedIndexChanged);
            // 
            // listbox_vaccination_addnewregistration
            // 
            this.listbox_vaccination_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listbox_vaccination_addnewregistration.FormattingEnabled = true;
            this.listbox_vaccination_addnewregistration.ItemHeight = 25;
            this.listbox_vaccination_addnewregistration.Location = new System.Drawing.Point(450, 25);
            this.listbox_vaccination_addnewregistration.Name = "listbox_vaccination_addnewregistration";
            this.listbox_vaccination_addnewregistration.Size = new System.Drawing.Size(150, 4);
            this.listbox_vaccination_addnewregistration.TabIndex = 173;
            this.listbox_vaccination_addnewregistration.TabStop = false;
            this.listbox_vaccination_addnewregistration.SelectedIndexChanged += new System.EventHandler(this.listbox_vaccination_addnewregistration_SelectedIndexChanged);
            // 
            // listbox_sex_addnewregistration
            // 
            this.listbox_sex_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listbox_sex_addnewregistration.FormattingEnabled = true;
            this.listbox_sex_addnewregistration.ItemHeight = 25;
            this.listbox_sex_addnewregistration.Location = new System.Drawing.Point(300, 25);
            this.listbox_sex_addnewregistration.Name = "listbox_sex_addnewregistration";
            this.listbox_sex_addnewregistration.Size = new System.Drawing.Size(150, 4);
            this.listbox_sex_addnewregistration.TabIndex = 172;
            this.listbox_sex_addnewregistration.TabStop = false;
            this.listbox_sex_addnewregistration.SelectedIndexChanged += new System.EventHandler(this.listbox_sex_addnewregistration_SelectedIndexChanged);
            // 
            // listbox_dob_addnewregistration
            // 
            this.listbox_dob_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listbox_dob_addnewregistration.FormattingEnabled = true;
            this.listbox_dob_addnewregistration.ItemHeight = 25;
            this.listbox_dob_addnewregistration.Location = new System.Drawing.Point(150, 25);
            this.listbox_dob_addnewregistration.Name = "listbox_dob_addnewregistration";
            this.listbox_dob_addnewregistration.Size = new System.Drawing.Size(150, 4);
            this.listbox_dob_addnewregistration.TabIndex = 171;
            this.listbox_dob_addnewregistration.TabStop = false;
            this.listbox_dob_addnewregistration.SelectedIndexChanged += new System.EventHandler(this.listbox_dob_addnewregistration_SelectedIndexChanged);
            // 
            // listbox_specialtreatment_addnewregistration
            // 
            this.listbox_specialtreatment_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listbox_specialtreatment_addnewregistration.FormattingEnabled = true;
            this.listbox_specialtreatment_addnewregistration.ItemHeight = 25;
            this.listbox_specialtreatment_addnewregistration.Location = new System.Drawing.Point(1200, 25);
            this.listbox_specialtreatment_addnewregistration.Name = "listbox_specialtreatment_addnewregistration";
            this.listbox_specialtreatment_addnewregistration.Size = new System.Drawing.Size(150, 4);
            this.listbox_specialtreatment_addnewregistration.TabIndex = 175;
            this.listbox_specialtreatment_addnewregistration.TabStop = false;
            this.listbox_specialtreatment_addnewregistration.SelectedIndexChanged += new System.EventHandler(this.listbox_specialtreatment_addnewregistration_SelectedIndexChanged);
            // 
            // listbox_catnames_addnewregistration
            // 
            this.listbox_catnames_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listbox_catnames_addnewregistration.FormattingEnabled = true;
            this.listbox_catnames_addnewregistration.ItemHeight = 25;
            this.listbox_catnames_addnewregistration.Location = new System.Drawing.Point(0, 25);
            this.listbox_catnames_addnewregistration.Name = "listbox_catnames_addnewregistration";
            this.listbox_catnames_addnewregistration.Size = new System.Drawing.Size(150, 4);
            this.listbox_catnames_addnewregistration.TabIndex = 170;
            this.listbox_catnames_addnewregistration.TabStop = false;
            this.listbox_catnames_addnewregistration.SelectedIndexChanged += new System.EventHandler(this.listbox_catnames_addnewregistration_SelectedIndexChanged);
            // 
            // listbox_diet_addnewregistration
            // 
            this.listbox_diet_addnewregistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listbox_diet_addnewregistration.FormattingEnabled = true;
            this.listbox_diet_addnewregistration.ItemHeight = 25;
            this.listbox_diet_addnewregistration.Location = new System.Drawing.Point(750, 25);
            this.listbox_diet_addnewregistration.Name = "listbox_diet_addnewregistration";
            this.listbox_diet_addnewregistration.Size = new System.Drawing.Size(150, 4);
            this.listbox_diet_addnewregistration.TabIndex = 174;
            this.listbox_diet_addnewregistration.TabStop = false;
            this.listbox_diet_addnewregistration.SelectedIndexChanged += new System.EventHandler(this.listbox_diet_addnewregistration_SelectedIndexChanged);
            // 
            // timer_addnewregistration
            // 
            this.timer_addnewregistration.Enabled = true;
            this.timer_addnewregistration.Interval = 10;
            this.timer_addnewregistration.Tick += new System.EventHandler(this.timer_addnewregistration_Tick);
            // 
            // form_addnewregistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.panel_catlistboxes_addnewregistration);
            this.Controls.Add(this.text_vetnumber_addnewregistration);
            this.Controls.Add(this.text_vetname_addnewregistration);
            this.Controls.Add(this.text_absencenumber_addnewregistration);
            this.Controls.Add(this.text_absencecontact_addnewregistration);
            this.Controls.Add(this.label_vetnumber_addnewregistration);
            this.Controls.Add(this.label_contactnumber_addnewregistration);
            this.Controls.Add(this.label_vetname_addnewregistration);
            this.Controls.Add(this.label_contactname_addnewregistration);
            this.Controls.Add(this.label_vetdetails_addnewregistration);
            this.Controls.Add(this.label_absencecontact_addnewregistration);
            this.Controls.Add(this.label_vaccinations_addnewregistration);
            this.Controls.Add(this.text_catfoodtoavoid_addnewregistration);
            this.Controls.Add(this.text_catallergies_addnewregistration);
            this.Controls.Add(this.text_catspecialtreatment_addnewregistration);
            this.Controls.Add(this.text_catdiet_addnewregistration);
            this.Controls.Add(this.button_deletecat_addnewregistration);
            this.Controls.Add(this.button_editcat_addnewregistration);
            this.Controls.Add(this.button_addcat_addnewregistration);
            this.Controls.Add(this.text_addcatdescription_addnewregistration);
            this.Controls.Add(this.datetimepicker_vaccinationduedate_addnewregistration);
            this.Controls.Add(this.datetimepicker_dob_addnewregistration);
            this.Controls.Add(this.combobox_catsex_addnewregistration);
            this.Controls.Add(this.text_addcatname_addnewregistration);
            this.Controls.Add(this.label_catdescription_addnewregistration);
            this.Controls.Add(this.label_catdiet_addnewregistration);
            this.Controls.Add(this.label_catfoodtoavoid_addnewregistration);
            this.Controls.Add(this.label_catallergies_addnewregistration);
            this.Controls.Add(this.label_catspecialtreatment_addnewregistration);
            this.Controls.Add(this.label_catdob_addnewregistration);
            this.Controls.Add(this.label_catname_addnewregistration);
            this.Controls.Add(this.label_catsex_addnewregistration);
            this.Controls.Add(this.text_town_addnewregistration);
            this.Controls.Add(this.text_postcode_addnewregistration);
            this.Controls.Add(this.label_postcode_addnewregistration);
            this.Controls.Add(this.label_town_addnewregistration);
            this.Controls.Add(this.text_homenumber_addnewregistration);
            this.Controls.Add(this.text_address_addnewregistration);
            this.Controls.Add(this.listbox_moblies_addnewregistration);
            this.Controls.Add(this.text_addmobile_addnewregistration);
            this.Controls.Add(this.button_deletemobile_addnewregistration);
            this.Controls.Add(this.button_editmobile_addnewregistration);
            this.Controls.Add(this.button_addmobile_addnewregistration);
            this.Controls.Add(this.listbox_owners_addnewregistration);
            this.Controls.Add(this.text_addowner_addnewregistration);
            this.Controls.Add(this.button_deleteowner_addnewregistration);
            this.Controls.Add(this.button_editowner_addnewregistration);
            this.Controls.Add(this.button_addowner_addnewregistration);
            this.Controls.Add(this.label_catsinfo_addnewregistration);
            this.Controls.Add(this.label_address_addnewregistration);
            this.Controls.Add(this.label_ownername_addnewregistration);
            this.Controls.Add(this.label_hometelephone_addnewregistration);
            this.Controls.Add(this.label_mobile_addnewregistration);
            this.Controls.Add(this.label_ownerdetails_addnewregistration);
            this.Controls.Add(this.button_confirmregistration_addnewregistration);
            this.Controls.Add(this.button_cancelnewregistration_addnewregistration);
            this.Controls.Add(this.panel_banner_addnewregistration);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "form_addnewregistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chichester Cattery Booking System : Add New Registration";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.form_addnewregistration_Activated);
            this.Load += new System.EventHandler(this.form_addnewregistration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_logo_addnewregistration)).EndInit();
            this.panel_banner_addnewregistration.ResumeLayout(false);
            this.panel_banner_addnewregistration.PerformLayout();
            this.panel_catlistboxes_addnewregistration.ResumeLayout(false);
            this.panel_catlistboxes_addnewregistration.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox text_vetnumber_addnewregistration;
        private System.Windows.Forms.TextBox text_vetname_addnewregistration;
        private System.Windows.Forms.TextBox text_absencenumber_addnewregistration;
        private System.Windows.Forms.TextBox text_absencecontact_addnewregistration;
        private System.Windows.Forms.Label label_vetnumber_addnewregistration;
        private System.Windows.Forms.Label label_contactnumber_addnewregistration;
        private System.Windows.Forms.Label label_vetname_addnewregistration;
        private System.Windows.Forms.Label label_contactname_addnewregistration;
        private System.Windows.Forms.Label label_vetdetails_addnewregistration;
        private System.Windows.Forms.Label label_absencecontact_addnewregistration;
        private System.Windows.Forms.Label label_vaccinations_addnewregistration;
        private System.Windows.Forms.TextBox text_catfoodtoavoid_addnewregistration;
        private System.Windows.Forms.TextBox text_catallergies_addnewregistration;
        private System.Windows.Forms.TextBox text_catspecialtreatment_addnewregistration;
        private System.Windows.Forms.TextBox text_catdiet_addnewregistration;
        private System.Windows.Forms.Button button_deletecat_addnewregistration;
        private System.Windows.Forms.Button button_editcat_addnewregistration;
        private System.Windows.Forms.Button button_addcat_addnewregistration;
        private System.Windows.Forms.TextBox text_addcatdescription_addnewregistration;
        private System.Windows.Forms.DateTimePicker datetimepicker_vaccinationduedate_addnewregistration;
        private System.Windows.Forms.DateTimePicker datetimepicker_dob_addnewregistration;
        private System.Windows.Forms.ComboBox combobox_catsex_addnewregistration;
        private System.Windows.Forms.TextBox text_addcatname_addnewregistration;
        private System.Windows.Forms.Label label_catdescription_addnewregistration;
        private System.Windows.Forms.Label label_catdiet_addnewregistration;
        private System.Windows.Forms.Label label_catfoodtoavoid_addnewregistration;
        private System.Windows.Forms.Label label_catallergies_addnewregistration;
        private System.Windows.Forms.Label label_catspecialtreatment_addnewregistration;
        private System.Windows.Forms.Label label_catdob_addnewregistration;
        private System.Windows.Forms.Label label_catname_addnewregistration;
        private System.Windows.Forms.Label label_catsex_addnewregistration;
        private System.Windows.Forms.TextBox text_town_addnewregistration;
        private System.Windows.Forms.TextBox text_postcode_addnewregistration;
        private System.Windows.Forms.Button button_goback_addnewregistration;
        private System.Windows.Forms.Button button_minimizeform_addnewregistration;
        private System.Windows.Forms.Button button_closeform_addnewregistration;
        private System.Windows.Forms.PictureBox picturebox_logo_addnewregistration;
        private System.Windows.Forms.Button button_searchbookings_addnewregistration;
        private System.Windows.Forms.TextBox text_bookingquery_addnewregistration;
        private System.Windows.Forms.Label label_postcode_addnewregistration;
        private System.Windows.Forms.Label label_bookingsearch_addnewregistration;
        private System.Windows.Forms.Button button_registrations_addnewregistration;
        private System.Windows.Forms.Label label_town_addnewregistration;
        private System.Windows.Forms.TextBox text_homenumber_addnewregistration;
        private System.Windows.Forms.TextBox text_address_addnewregistration;
        private System.Windows.Forms.ListBox listbox_moblies_addnewregistration;
        private System.Windows.Forms.TextBox text_addmobile_addnewregistration;
        private System.Windows.Forms.Button button_deletemobile_addnewregistration;
        private System.Windows.Forms.Button button_editmobile_addnewregistration;
        private System.Windows.Forms.Button button_addmobile_addnewregistration;
        private System.Windows.Forms.Button button_bookings_addnewregistration;
        private System.Windows.Forms.ListBox listbox_owners_addnewregistration;
        private System.Windows.Forms.TextBox text_addowner_addnewregistration;
        private System.Windows.Forms.Button button_deleteowner_addnewregistration;
        private System.Windows.Forms.Button button_editowner_addnewregistration;
        private System.Windows.Forms.Button button_addowner_addnewregistration;
        private System.Windows.Forms.Label label_catsinfo_addnewregistration;
        private System.Windows.Forms.Label label_address_addnewregistration;
        private System.Windows.Forms.Label label_ownername_addnewregistration;
        private System.Windows.Forms.Label label_hometelephone_addnewregistration;
        private System.Windows.Forms.Button button_home_addnewregistration;
        private System.Windows.Forms.Label label_mobile_addnewregistration;
        private System.Windows.Forms.Label label_ownerdetails_addnewregistration;
        private System.Windows.Forms.Button button_confirmregistration_addnewregistration;
        private System.Windows.Forms.Button button_cancelnewregistration_addnewregistration;
        private System.Windows.Forms.Panel panel_banner_addnewregistration;
        private Panel panel_catlistboxes_addnewregistration;
        private Label label_listboxsex_addnewregistration;
        private Label label_listboxdob_addnewregistration;
        private Label label_listboxname_addnewregistration;
        private ListBox listbox_foodtobeavoided_addnewregistration;
        private ListBox listbox_description_addnewregistration;
        private ListBox listbox_allergies_addnewregistration;
        private ListBox listbox_vaccination_addnewregistration;
        private ListBox listbox_sex_addnewregistration;
        private ListBox listbox_dob_addnewregistration;
        private ListBox listbox_specialtreatment_addnewregistration;
        private ListBox listbox_catnames_addnewregistration;
        private ListBox listbox_diet_addnewregistration;
        private Label label_listboxfood_addnewregistration;
        private Label label_listboxdescription_addnewregistration;
        private Label label_listboxvaccination_addnewregistration;
        private Label label_listboxspecialtreatment_addnewregistration;
        private Timer timer_addnewregistration;
        private Label label_titleaddnewregistration;
    }
}