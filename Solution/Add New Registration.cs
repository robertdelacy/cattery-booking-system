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
    public partial class form_addnewregistration : Form
    {
        string[,] cats = new string[6, 9];
        int editindex = -1;
        string CurrentRegistration = "";

        public form_addnewregistration()
        {
            InitializeComponent();

            this.SuspendLayout();

            FormCollection formcollection = Application.OpenForms;
            bool AddNewRegistrationFound = false;
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                Form openform = Application.OpenForms[i];
                openform.WindowState = FormWindowState.Maximized;
                if (openform.Name == "form_addnewregistration")
                {
                    AddNewRegistrationFound = true;
                }
            }
            if (AddNewRegistrationFound == false)
            {
                MyGlobalClass.updateaddnewregistration = false;
            }

            Rectangle resolution = Screen.PrimaryScreen.Bounds;

            double WidthScale = (double)resolution.Width / (double)this.Width;
            double HeightScale = (double)resolution.Height / (double)this.Height;

            this.Width = (int)(this.Width * WidthScale);
            this.Height = (int)(this.Height * HeightScale);

            MyGlobalClass.ScaleParent(HeightScale, WidthScale, this);

            this.ResumeLayout();
            this.PerformLayout();
        }

        private void button_closeform_addnewregistration_Click(object sender, EventArgs e)
        {
            MyGlobalClass.CloseApplication(this);
        }

        private void button_minimizeform_addnewregistration_Click(object sender, EventArgs e)
        {
            MyGlobalClass.MinimizeApplication();
        }

        private void button_searchbookings_addnewregistration_Click(object sender, EventArgs e)
        {
            var newform = new form_bookingsystem();
            MyGlobalClass.OpenForm(newform);
        }

        private void button_home_addnewregistration_Click(object sender, EventArgs e)
        {
            var newform = new form_initialscreen();
            MyGlobalClass.OpenForm(newform);
        }

        private void button_bookings_addnewregistration_Click(object sender, EventArgs e)
        {
            var newform = new form_bookingsystem();
            MyGlobalClass.OpenForm(newform);
        }

        private void button_registrations_addnewregistration_Click(object sender, EventArgs e)
        {
            var newform = new form_registrationsystem();
            MyGlobalClass.OpenForm(newform);
        }

        private void timer_addnewregistration_Tick(object sender, EventArgs e)
        {
            MyGlobalClass.CheckFormCount(button_goback_addnewregistration);

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
                button_home_addnewregistration.Text = "Home";
            }
            else
            {
                button_home_addnewregistration.Text = "Home (" + count + ")";
            }
        }

        private void button_goback_addnewregistration_Click(object sender, EventArgs e)
        {
            MyGlobalClass.GoBack(this);
        }

        private void button_cancelnewregistration_addnewregistration_Click(object sender, EventArgs e)
        {
            try //Try Catch insures no errors occur when 'Add New Registration' form is opened from the 'Add New Booking' form
            {
                var previous_form = MyGlobalClass.previous_form_addnewregistration; //Var variable set as the previous_form_addnewregistration variable
                try //Try Catch insures no errors occur
                {
                    string text = "Are you sure you want to cancel the New Registration?";
                    if (button_cancelnewregistration_addnewregistration.Text == "Cancel Registration Edit")
                    {
                        text = "Are you sure you want to cancel the editing of the Registration?";
                    }
                    if (MessageBox.Show(text, "Cancel?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        MyGlobalClass.registration_addnewregistration = "";
                        MyGlobalClass.navigation = true; //MessageBox shown so another one does not need to be shown
                        MyGlobalClass.CloseForm(previous_form, this);
                        MyGlobalClass.navigation = false; //Reset the variable when form has been closed
                    }
                }
                catch
                {
                }
            }
            catch
            {
                MyGlobalClass.registration_addnewregistration = "";
                MyGlobalClass.GoBack(this);
            }
        }

        private void form_addnewregistration_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            if (MyGlobalClass.registration_addnewregistration != "")
            { //If editing a registration
                button_cancelnewregistration_addnewregistration.Text = "Cancel Registration Edit";
                button_confirmregistration_addnewregistration.Text = "Confirm Registration Edit";
                for (int arraypointer = 0; arraypointer < 6; arraypointer++)
                {
                    if (MyGlobalClass.selectedregistration[arraypointer, 0] != null)
                    {
                        listbox_owners_addnewregistration.Items.Add(MyGlobalClass.selectedregistration[arraypointer, 0]);
                    }
                }

                text_address_addnewregistration.Text = MyGlobalClass.selectedregistration[6, 0];
                text_town_addnewregistration.Text = MyGlobalClass.selectedregistration[7, 0];
                text_postcode_addnewregistration.Text = MyGlobalClass.selectedregistration[8, 0];
                text_homenumber_addnewregistration.Text = MyGlobalClass.selectedregistration[9, 0]; //Adding all information to the respective controls

                for (int arraypointer = 10; arraypointer < 16; arraypointer++)
                {
                    if (MyGlobalClass.selectedregistration[arraypointer, 0] != null)
                    {
                        listbox_moblies_addnewregistration.Items.Add(MyGlobalClass.selectedregistration[arraypointer, 0]);
                    }
                }

                text_absencecontact_addnewregistration.Text = MyGlobalClass.selectedregistration[16, 0];
                text_absencenumber_addnewregistration.Text = MyGlobalClass.selectedregistration[17, 0];
                text_vetname_addnewregistration.Text = MyGlobalClass.selectedregistration[18, 0];
                text_vetnumber_addnewregistration.Text = MyGlobalClass.selectedregistration[19, 0];

                for (int catpointer = 0; catpointer < 11; catpointer = catpointer + 2)
                {
                    if (MyGlobalClass.selectedregistrationcats[1, (catpointer + 1)] != null)
                    {
                        cats[(catpointer / 2), 0] = MyGlobalClass.selectedregistrationcats[0, catpointer];
                        cats[(catpointer / 2), 1] = MyGlobalClass.selectedregistrationcats[1, catpointer];
                        cats[(catpointer / 2), 2] = MyGlobalClass.selectedregistrationcats[2, catpointer];
                        cats[(catpointer / 2), 3] = MyGlobalClass.selectedregistrationcats[3, catpointer];
                        cats[(catpointer / 2), 4] = MyGlobalClass.selectedregistrationcats[4, catpointer];
                        cats[(catpointer / 2), 5] = MyGlobalClass.selectedregistrationcats[5, catpointer];
                        cats[(catpointer / 2), 6] = MyGlobalClass.selectedregistrationcats[6, catpointer];
                        cats[(catpointer / 2), 7] = MyGlobalClass.selectedregistrationcats[7, catpointer];
                        cats[(catpointer / 2), 8] = MyGlobalClass.selectedregistrationcats[8, catpointer];
                    }
                }

                for (int catpointer = 0; catpointer < 6; catpointer++)
                {
                    if (cats[catpointer, 0] != null)
                    {
                        listbox_catnames_addnewregistration.Items.Add(cats[catpointer, 0]);
                        listbox_dob_addnewregistration.Items.Add(cats[catpointer, 1]);
                        listbox_sex_addnewregistration.Items.Add(cats[catpointer, 2]);
                        listbox_vaccination_addnewregistration.Items.Add(cats[catpointer, 3]);
                        listbox_description_addnewregistration.Items.Add(cats[catpointer, 4]);
                        listbox_diet_addnewregistration.Items.Add(cats[catpointer, 5]);
                        listbox_foodtobeavoided_addnewregistration.Items.Add(cats[catpointer, 6]);
                        listbox_allergies_addnewregistration.Items.Add(cats[catpointer, 7]);
                        listbox_specialtreatment_addnewregistration.Items.Add(cats[catpointer, 8]);
                    }
                }

                foreach (Control Ctrl in panel_catlistboxes_addnewregistration.Controls)
                {
                    try
                    {
                        ListBox listbox = (ListBox)Ctrl;
                        listbox.Height = (listbox.Items.Count * listbox.ItemHeight) + 4;
                    }
                    catch
                    {
                    }
                }
            }
            else
            {
                button_cancelnewregistration_addnewregistration.Text = "Cancel New Registration";
                button_confirmregistration_addnewregistration.Text = "Confirm New Registration";
            }

            CurrentRegistration = MyGlobalClass.registration_addnewregistration;

            if (listbox_owners_addnewregistration.Items.Count >= 1)
            {//Check if enough owners
                listbox_owners_addnewregistration.Enabled = true;
                text_address_addnewregistration.Enabled = true;
                text_town_addnewregistration.Enabled = true;
                text_postcode_addnewregistration.Enabled = true;
                text_homenumber_addnewregistration.Enabled = true;
                text_addmobile_addnewregistration.Enabled = true;
                if (listbox_moblies_addnewregistration.Items.Count > 0)
                {//Enables the mobile listbox if there are items. The cat name textbox is enabled when text is added to the addess textboxes using the old data
                    listbox_moblies_addnewregistration.Enabled = true;
                }
                if (listbox_catnames_addnewregistration.Items.Count > 0)
                { //Given that there is text in the contact textboxes, check if there are items in the cat listboxes
                    datetimepicker_dob_addnewregistration.Enabled = true;
                    combobox_catsex_addnewregistration.Enabled = true;
                    datetimepicker_vaccinationduedate_addnewregistration.Enabled = true;
                    text_addcatdescription_addnewregistration.Enabled = true;
                    text_catdiet_addnewregistration.Enabled = true;
                    text_catspecialtreatment_addnewregistration.Enabled = true;
                    text_catfoodtoavoid_addnewregistration.Enabled = true;
                    text_catallergies_addnewregistration.Enabled = true;
                    text_absencecontact_addnewregistration.Enabled = true;
                    text_absencenumber_addnewregistration.Enabled = true;
                    text_vetname_addnewregistration.Enabled = true;
                    text_vetnumber_addnewregistration.Enabled = true;
                    button_confirmregistration_addnewregistration.Enabled = true;
                    panel_catlistboxes_addnewregistration.Enabled = true;
                }
            }
            this.ResumeLayout();
            this.PerformLayout();
        }

        private void text_addowner_addnewregistration_TextChanged(object sender, EventArgs e)
        {
            if (text_addowner_addnewregistration.Text != "") //Check that the textbox isn't empty
            {
                button_addowner_addnewregistration.Enabled = true; //Enable button if textbox isn't empty
            }
            else
            {
                button_addowner_addnewregistration.Enabled = false; //Disable button if textbox is empty
            }
        }

        private void text_addmobile_addnewregistration_TextChanged(object sender, EventArgs e)
        {
            if (text_addmobile_addnewregistration.Text != "") //Check that the textbox isn't empty
            {
                button_addmobile_addnewregistration.Enabled = true; //Enable button if textbox isn't empty
            }
            else
            {
                button_addmobile_addnewregistration.Enabled = false; //Disable button if textbox is empty
            }
        }

        private void button_addowner_addnewregistration_Click(object sender, EventArgs e)
        {
            listbox_owners_addnewregistration.Enabled = true;
            text_address_addnewregistration.Enabled = true;
            text_town_addnewregistration.Enabled = true;
            text_postcode_addnewregistration.Enabled = true;
            text_homenumber_addnewregistration.Enabled = true;
            text_addmobile_addnewregistration.Enabled = true; //Enable textboxes and listbox
            if (listbox_owners_addnewregistration.Items.Count < 6) //Check if new addition won't exceed amount
            {
                listbox_owners_addnewregistration.Items.Add(text_addowner_addnewregistration.Text); //Add to listbox if it doesn't exceed the limit
                text_addowner_addnewregistration.Clear(); //Clear the textbox
                button_addowner_addnewregistration.Enabled = false; //Disable add button
            }
            else
            { //If limit exceeded, show messagebox
                MessageBox.Show("Too many owners. Please edit or delete an owner.", "Exceeded Limit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void listbox_owners_addnewregistration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbox_owners_addnewregistration.SelectedItems.Count > 0)
            {
                button_deleteowner_addnewregistration.Enabled = true;
                button_editowner_addnewregistration.Enabled = true; //Enable Edit and Delete buttons if selected item
            }
            else
            {
                button_deleteowner_addnewregistration.Enabled = false;
                button_editowner_addnewregistration.Enabled = false; //Disable Edit and Delete buttons if no selected item
            }
        }

        private void button_editowner_addnewregistration_Click(object sender, EventArgs e)
        {
            text_addowner_addnewregistration.Text = listbox_owners_addnewregistration.SelectedItem.ToString(); //Set the textbox text to the selected item
            listbox_owners_addnewregistration.Items.Remove(listbox_owners_addnewregistration.SelectedItem); //Removes selected item
            text_addowner_addnewregistration.Focus(); //Focusses textbox
        }

        private void button_deleteowner_addnewregistration_Click(object sender, EventArgs e)
        {
            listbox_owners_addnewregistration.Items.Remove(listbox_owners_addnewregistration.SelectedItem); //Removes selected item
            if (listbox_owners_addnewregistration.Items.Count < 1)
            {
                text_addowner_addnewregistration.Focus(); //Focusses textbox if no owners in listbox
            }
        }

        private void button_addmobile_addnewregistration_Click(object sender, EventArgs e)
        {
            listbox_moblies_addnewregistration.Enabled = true;
            text_addcatname_addnewregistration.Enabled = true; //Enable the cat name textbox and mobile listbox
            if (listbox_moblies_addnewregistration.Items.Count < 6) //Check if new addition won't exceed amount
            {
                listbox_moblies_addnewregistration.Items.Add(text_addmobile_addnewregistration.Text); //Add to listbox if it doesn't exceed the limit
                text_addmobile_addnewregistration.Clear(); //Clear the textbox
                button_addmobile_addnewregistration.Enabled = false; //Disable add button
            }
            else
            { //If limit exceeded, show messagebox
                MessageBox.Show("Too many mobiles. Please edit or delete a mobile.", "Exceeded Limit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button_editmobile_addnewregistration_Click(object sender, EventArgs e)
        {
            text_addmobile_addnewregistration.Text = listbox_moblies_addnewregistration.SelectedItem.ToString(); //Set the textbox text to the selected item
            listbox_moblies_addnewregistration.Items.Remove(listbox_moblies_addnewregistration.SelectedItem); //Removes selected item
            text_addmobile_addnewregistration.Focus(); //Focusses textbox
        }

        private void listbox_moblies_addnewregistration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbox_moblies_addnewregistration.SelectedItems.Count > 0)
            {
                button_deletemobile_addnewregistration.Enabled = true;
                button_editmobile_addnewregistration.Enabled = true; //Enable Edit and Delete buttons if selected item
            }
            else
            {
                button_deletemobile_addnewregistration.Enabled = false;
                button_editmobile_addnewregistration.Enabled = false; //Disable Edit and Delete buttons if no selected item
            }
        }

        private void button_deletemobile_addnewregistration_Click(object sender, EventArgs e)
        {
            listbox_moblies_addnewregistration.Items.Remove(listbox_moblies_addnewregistration.SelectedItem); //Removes selected item
            if (listbox_moblies_addnewregistration.Items.Count < 1)
            {
                text_addmobile_addnewregistration.Focus(); //Focusses textbox if no owners in listbox
            }
        }

        private void text_address_addnewregistration_TextChanged(object sender, EventArgs e)
        {
            if (text_address_addnewregistration.Text != "")
            {
                text_addcatname_addnewregistration.Enabled = true; //Enables the cat name textbox
            }
        }

        private void text_town_addnewregistration_TextChanged(object sender, EventArgs e)
        {
            if (text_town_addnewregistration.Text != "")
            {
                text_addcatname_addnewregistration.Enabled = true; //Enables the cat name textbox
            }
        }

        private void text_postcode_addnewregistration_TextChanged(object sender, EventArgs e)
        {
            if (text_postcode_addnewregistration.Text != "")
            {
                text_addcatname_addnewregistration.Enabled = true; //Enables the cat name textbox
            }
        }

        private void text_homenumber_addnewregistration_TextChanged(object sender, EventArgs e)
        {
            if (text_homenumber_addnewregistration.Text != "")
            {
                text_addcatname_addnewregistration.Enabled = true; //Enables the cat name textbox
            }
        }

        private void text_addcatname_addnewregistration_TextChanged(object sender, EventArgs e)
        {
            if (text_addcatname_addnewregistration.Text != "")
            {
                datetimepicker_dob_addnewregistration.Enabled = true;
                combobox_catsex_addnewregistration.Enabled = true; //Enables the Date of birth date time picker and sex combo box
            }
        }

        private void combobox_catsex_addnewregistration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combobox_catsex_addnewregistration.Text != "")
            {
                datetimepicker_vaccinationduedate_addnewregistration.Enabled = true;
                text_addcatdescription_addnewregistration.Enabled = true;
                text_catdiet_addnewregistration.Enabled = true; //Enables vaccination datetimepicker, description and food textboxes
            }
        }

        private void text_addcatdescription_addnewregistration_TextChanged(object sender, EventArgs e)
        {
            if (text_addcatdescription_addnewregistration.Text != "")
            {
                button_addcat_addnewregistration.Enabled = true;
                text_catfoodtoavoid_addnewregistration.Enabled = true;
                text_catspecialtreatment_addnewregistration.Enabled = true;
                text_catallergies_addnewregistration.Enabled = true; //Fully enable all cat input
            }
        }

        private void text_catdiet_addnewregistration_TextChanged(object sender, EventArgs e)
        {
            if (text_catdiet_addnewregistration.Text != "")
            {
                button_addcat_addnewregistration.Enabled = true;
                text_catfoodtoavoid_addnewregistration.Enabled = true;
                text_catspecialtreatment_addnewregistration.Enabled = true;
                text_catallergies_addnewregistration.Enabled = true; //Fully enable all cat input
            }
        }

        private void button_addcat_addnewregistration_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            panel_catlistboxes_addnewregistration.Enabled = true;
            text_absencecontact_addnewregistration.Enabled = true;
            text_absencenumber_addnewregistration.Enabled = true;
            text_vetname_addnewregistration.Enabled = true;
            text_vetnumber_addnewregistration.Enabled = true; //Enable the rest of the form and cat panel
            button_confirmregistration_addnewregistration.Enabled = true;
            panel_catlistboxes_addnewregistration.Enabled = true;
            if (listbox_catnames_addnewregistration.Items.Count < 6) //Check if new addition won't exceed amount
            {
                int index = 0;
                for (index = 0; index < 6; index++)//Looking for the first available slot in the array.
                {
                    if (cats[index, 0] == null && cats[index, 1] == null) //Checks if name and date of birth are empty
                    {
                        if (index < editindex || editindex == -1)
                        { //If not editing or the first empty index is before the edit index, insert the cat information into the first empty index
                            cats[index, 0] = text_addcatname_addnewregistration.Text;
                            #region ...
                            cats[index, 1] = datetimepicker_dob_addnewregistration.Value.ToShortDateString();
                            cats[index, 2] = combobox_catsex_addnewregistration.Text;
                            cats[index, 3] = datetimepicker_vaccinationduedate_addnewregistration.Value.ToShortDateString();
                            cats[index, 4] = text_addcatdescription_addnewregistration.Text;
                            cats[index, 5] = text_catdiet_addnewregistration.Text;
                            cats[index, 6] = text_catfoodtoavoid_addnewregistration.Text;
                            cats[index, 7] = text_catallergies_addnewregistration.Text;
                            #endregion
                            cats[index, 8] = text_catspecialtreatment_addnewregistration.Text;
                        }
                        else
                        { //If adding back an edited cat
                            for (int move = (cats.GetLength(0) - 1); move > editindex; move--) //Shift all values below(and including) the edited/deleted cat index down
                            {
                                cats[move, 0] = cats[(move - 1), 0];
                                #region ...
                                cats[move, 1] = cats[(move - 1), 1];
                                cats[move, 2] = cats[(move - 1), 2];
                                cats[move, 3] = cats[(move - 1), 3];
                                cats[move, 4] = cats[(move - 1), 4];
                                cats[move, 5] = cats[(move - 1), 5];
                                cats[move, 6] = cats[(move - 1), 6];
                                cats[move, 7] = cats[(move - 1), 7];
                                #endregion
                                cats[move, 8] = cats[(move - 1), 8];
                            }
                            cats[editindex, 0] = text_addcatname_addnewregistration.Text; //Insert the edited cat information into it's previous index
                            #region ...
                            cats[editindex, 1] = datetimepicker_dob_addnewregistration.Value.ToShortDateString();
                            cats[editindex, 2] = combobox_catsex_addnewregistration.Text;
                            cats[editindex, 3] = datetimepicker_vaccinationduedate_addnewregistration.Value.ToShortDateString();
                            cats[editindex, 4] = text_addcatdescription_addnewregistration.Text;
                            cats[editindex, 5] = text_catdiet_addnewregistration.Text;
                            cats[editindex, 6] = text_catfoodtoavoid_addnewregistration.Text;
                            cats[editindex, 7] = text_catallergies_addnewregistration.Text;
                            #endregion
                            cats[editindex, 8] = text_catspecialtreatment_addnewregistration.Text;
                        }
                        editindex = -1; //Mark as no longer editing
                        break; //Breaks out of for loop
                    }
                }

                text_addcatname_addnewregistration.Clear(); //Clear everything
                combobox_catsex_addnewregistration.SelectedIndex = -1;
                text_addcatdescription_addnewregistration.Clear();
                text_catdiet_addnewregistration.Clear();
                text_catspecialtreatment_addnewregistration.Clear();
                text_catfoodtoavoid_addnewregistration.Clear();
                text_catallergies_addnewregistration.Clear();
                button_addcat_addnewregistration.Enabled = false; //Disable add button

                listbox_catnames_addnewregistration.Items.Clear();
                listbox_dob_addnewregistration.Items.Clear();
                listbox_sex_addnewregistration.Items.Clear();
                listbox_vaccination_addnewregistration.Items.Clear();
                listbox_description_addnewregistration.Items.Clear();
                listbox_diet_addnewregistration.Items.Clear();
                listbox_foodtobeavoided_addnewregistration.Items.Clear();
                listbox_allergies_addnewregistration.Items.Clear();
                listbox_specialtreatment_addnewregistration.Items.Clear();

                for (int catpointer = 0; catpointer < 6; catpointer++)
                {
                    if (cats[catpointer, 0] != null)
                    {
                        listbox_catnames_addnewregistration.Items.Add(cats[catpointer, 0]);
                        listbox_dob_addnewregistration.Items.Add(cats[catpointer, 1]);
                        listbox_sex_addnewregistration.Items.Add(cats[catpointer, 2]);
                        listbox_vaccination_addnewregistration.Items.Add(cats[catpointer, 3]);
                        listbox_description_addnewregistration.Items.Add(cats[catpointer, 4]);
                        listbox_diet_addnewregistration.Items.Add(cats[catpointer, 5]);
                        listbox_foodtobeavoided_addnewregistration.Items.Add(cats[catpointer, 6]);
                        listbox_allergies_addnewregistration.Items.Add(cats[catpointer, 7]);
                        listbox_specialtreatment_addnewregistration.Items.Add(cats[catpointer, 8]);
                    }
                }
            }
            else
            { //If limit exceeded, show messagebox
                MessageBox.Show("Too many cats. Please edit or delete a cat.", "Exceeded Limit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            foreach (Control Ctrl in panel_catlistboxes_addnewregistration.Controls)
            {
                try
                {
                    ListBox listbox = (ListBox)Ctrl;
                    listbox.Height = (listbox.Items.Count * listbox.ItemHeight) + 4;
                }
                catch
                {
                }
            }
            this.ResumeLayout();
            this.PerformLayout();
        }

        private void button_deletecat_addnewregistration_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            try
            {
                int index = listbox_catnames_addnewregistration.SelectedIndex;
                cats[index, 0] = null;
                cats[index, 1] = null;
                cats[index, 2] = null;
                cats[index, 3] = null;
                cats[index, 4] = null;
                cats[index, 5] = null;
                cats[index, 6] = null;
                cats[index, 7] = null;
                cats[index, 8] = null;
                for (int move = index; move < (cats.GetLength(0) - 1); move++) //Shift all values below the edited/deleted cat up (resulting in the last index theoretically empty)
                {
                    cats[move, 0] = cats[(move + 1), 0];
                    cats[move, 1] = cats[(move + 1), 1];
                    cats[move, 2] = cats[(move + 1), 2];
                    cats[move, 3] = cats[(move + 1), 3];
                    cats[move, 4] = cats[(move + 1), 4];
                    cats[move, 5] = cats[(move + 1), 5];
                    cats[move, 6] = cats[(move + 1), 6];
                    cats[move, 7] = cats[(move + 1), 7];
                    cats[move, 8] = cats[(move + 1), 8];
                }
                cats[(cats.GetLength(0) - 1), 0] = null; //Clears the last value as only if the array is full, the last value would not have been cleared
                cats[(cats.GetLength(0) - 1), 1] = null;
                cats[(cats.GetLength(0) - 1), 2] = null;
                cats[(cats.GetLength(0) - 1), 3] = null;
                cats[(cats.GetLength(0) - 1), 4] = null;
                cats[(cats.GetLength(0) - 1), 5] = null;
                cats[(cats.GetLength(0) - 1), 6] = null;
                cats[(cats.GetLength(0) - 1), 7] = null;
                cats[(cats.GetLength(0) - 1), 8] = null;

                listbox_catnames_addnewregistration.Items.Clear();
                listbox_dob_addnewregistration.Items.Clear();
                listbox_sex_addnewregistration.Items.Clear();
                listbox_vaccination_addnewregistration.Items.Clear();
                listbox_description_addnewregistration.Items.Clear();
                listbox_diet_addnewregistration.Items.Clear();
                listbox_foodtobeavoided_addnewregistration.Items.Clear();
                listbox_allergies_addnewregistration.Items.Clear();
                listbox_specialtreatment_addnewregistration.Items.Clear();

                for (int catpointer = 0; catpointer < 6; catpointer++)
                {
                    if (cats[catpointer, 0] != null)
                    {
                        listbox_catnames_addnewregistration.Items.Add(cats[catpointer, 0]);
                        listbox_dob_addnewregistration.Items.Add(cats[catpointer, 1]);
                        listbox_sex_addnewregistration.Items.Add(cats[catpointer, 2]);
                        listbox_vaccination_addnewregistration.Items.Add(cats[catpointer, 3]);
                        listbox_description_addnewregistration.Items.Add(cats[catpointer, 4]);
                        listbox_diet_addnewregistration.Items.Add(cats[catpointer, 5]);
                        listbox_foodtobeavoided_addnewregistration.Items.Add(cats[catpointer, 6]);
                        listbox_allergies_addnewregistration.Items.Add(cats[catpointer, 7]);
                        listbox_specialtreatment_addnewregistration.Items.Add(cats[catpointer, 8]);
                    }
                }

                listbox_catnames_addnewregistration.ClearSelected(); //Deselect all listboxes
                listbox_dob_addnewregistration.ClearSelected();
                listbox_sex_addnewregistration.ClearSelected();
                listbox_vaccination_addnewregistration.ClearSelected();
                listbox_description_addnewregistration.ClearSelected();
                listbox_diet_addnewregistration.ClearSelected();
                listbox_specialtreatment_addnewregistration.ClearSelected();
                listbox_allergies_addnewregistration.ClearSelected();
                listbox_foodtobeavoided_addnewregistration.ClearSelected();
                button_editcat_addnewregistration.Enabled = false;
                button_deletecat_addnewregistration.Enabled = false;
                if (listbox_catnames_addnewregistration.Items.Count < 1)
                {
                    text_addcatname_addnewregistration.Focus(); //Focusses cat name textbox if no cats in listboxes
                    panel_catlistboxes_addnewregistration.Enabled = false;
                }
                foreach (Control Ctrl in panel_catlistboxes_addnewregistration.Controls)
                {
                    try
                    {
                        ListBox listbox = (ListBox)Ctrl;
                        listbox.Height = (listbox.Items.Count * listbox.ItemHeight) + 4;
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
                button_editcat_addnewregistration.Enabled = false;
                button_deletecat_addnewregistration.Enabled = false;
            }
            this.ResumeLayout();
            this.PerformLayout();
        }

        private void button_editcat_addnewregistration_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            try
            {
                text_addcatname_addnewregistration.Text = listbox_catnames_addnewregistration.SelectedItem.ToString(); //Set the cat input to the selected items
                datetimepicker_dob_addnewregistration.Value = Convert.ToDateTime(listbox_dob_addnewregistration.SelectedItem.ToString());
                combobox_catsex_addnewregistration.Text = listbox_sex_addnewregistration.SelectedItem.ToString();
                datetimepicker_vaccinationduedate_addnewregistration.Value = Convert.ToDateTime(listbox_vaccination_addnewregistration.SelectedItem.ToString());
                text_addcatdescription_addnewregistration.Text = listbox_description_addnewregistration.SelectedItem.ToString();
                text_catdiet_addnewregistration.Text = listbox_diet_addnewregistration.SelectedItem.ToString();
                text_catspecialtreatment_addnewregistration.Text = listbox_specialtreatment_addnewregistration.SelectedItem.ToString();
                text_catallergies_addnewregistration.Text = listbox_allergies_addnewregistration.SelectedItem.ToString();
                text_catfoodtoavoid_addnewregistration.Text = listbox_foodtobeavoided_addnewregistration.SelectedItem.ToString();

                editindex = listbox_catnames_addnewregistration.SelectedIndex; //Clear the array for the edited/deleted cat
                cats[editindex, 0] = null;
                cats[editindex, 1] = null;
                cats[editindex, 2] = null;
                cats[editindex, 3] = null;
                cats[editindex, 4] = null;
                cats[editindex, 5] = null;
                cats[editindex, 6] = null;
                cats[editindex, 7] = null;
                cats[editindex, 8] = null;
                for (int move = editindex; move < (cats.GetLength(0) - 1); move++) //Shift all values below the edited/deleted cat up
                {
                    cats[move, 0] = cats[(move + 1), 0];
                    cats[move, 1] = cats[(move + 1), 1];
                    cats[move, 2] = cats[(move + 1), 2];
                    cats[move, 3] = cats[(move + 1), 3];
                    cats[move, 4] = cats[(move + 1), 4];
                    cats[move, 5] = cats[(move + 1), 5];
                    cats[move, 6] = cats[(move + 1), 6];
                    cats[move, 7] = cats[(move + 1), 7];
                    cats[move, 8] = cats[(move + 1), 8];
                }
                cats[(cats.GetLength(0) - 1), 0] = null; //Clears the last value as only if the array is full, the last value would not have been cleared
                cats[(cats.GetLength(0) - 1), 1] = null;
                cats[(cats.GetLength(0) - 1), 2] = null;
                cats[(cats.GetLength(0) - 1), 3] = null;
                cats[(cats.GetLength(0) - 1), 4] = null;
                cats[(cats.GetLength(0) - 1), 5] = null;
                cats[(cats.GetLength(0) - 1), 6] = null;
                cats[(cats.GetLength(0) - 1), 7] = null;
                cats[(cats.GetLength(0) - 1), 8] = null;

                listbox_catnames_addnewregistration.Items.Clear();
                listbox_dob_addnewregistration.Items.Clear();
                listbox_sex_addnewregistration.Items.Clear();
                listbox_vaccination_addnewregistration.Items.Clear();
                listbox_description_addnewregistration.Items.Clear();
                listbox_diet_addnewregistration.Items.Clear();
                listbox_foodtobeavoided_addnewregistration.Items.Clear();
                listbox_allergies_addnewregistration.Items.Clear();
                listbox_specialtreatment_addnewregistration.Items.Clear();

                for (int catpointer = 0; catpointer < 6; catpointer++) //After clearing the list boxes, the remaining cats in the array are re-added to the list boxes
                {
                    if (cats[catpointer, 0] != null)
                    {
                        listbox_catnames_addnewregistration.Items.Add(cats[catpointer, 0]);
                        listbox_dob_addnewregistration.Items.Add(cats[catpointer, 1]);
                        listbox_sex_addnewregistration.Items.Add(cats[catpointer, 2]);
                        listbox_vaccination_addnewregistration.Items.Add(cats[catpointer, 3]);
                        listbox_description_addnewregistration.Items.Add(cats[catpointer, 4]);
                        listbox_diet_addnewregistration.Items.Add(cats[catpointer, 5]);
                        listbox_foodtobeavoided_addnewregistration.Items.Add(cats[catpointer, 6]);
                        listbox_allergies_addnewregistration.Items.Add(cats[catpointer, 7]);
                        listbox_specialtreatment_addnewregistration.Items.Add(cats[catpointer, 8]);
                    }
                }

                listbox_catnames_addnewregistration.SelectedIndex = -1; //Deselect all listboxes
                listbox_dob_addnewregistration.SelectedIndex = -1;
                listbox_sex_addnewregistration.SelectedIndex = -1;
                listbox_vaccination_addnewregistration.SelectedIndex = -1;
                listbox_description_addnewregistration.SelectedIndex = -1;
                listbox_diet_addnewregistration.SelectedIndex = -1;
                listbox_specialtreatment_addnewregistration.SelectedIndex = -1;
                listbox_allergies_addnewregistration.SelectedIndex = -1;
                listbox_foodtobeavoided_addnewregistration.SelectedIndex = -1;
                button_editcat_addnewregistration.Enabled = false;
                button_deletecat_addnewregistration.Enabled = false;
                text_addcatname_addnewregistration.Focus(); //Focusses cat name textbox

                foreach (Control Ctrl in panel_catlistboxes_addnewregistration.Controls) //Resizing the list boxes
                {
                    try
                    {
                        ListBox listbox = (ListBox)Ctrl;
                        listbox.Height = (listbox.Items.Count * listbox.ItemHeight) + 4;
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
                button_editcat_addnewregistration.Enabled = false;
                button_deletecat_addnewregistration.Enabled = false;
            }

            this.ResumeLayout();
            this.PerformLayout();
        }

        private void button_confirmregistration_addnewregistration_Click(object sender, EventArgs e)
        {
            #region continue
            bool Continue = true;
            if (listbox_owners_addnewregistration.Items.Count == 0)//Check for a lack of owners
            {
                MessageBox.Show("Please enter at least one owner.", "Missing Owner", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Continue = false;
            }

            if (Continue == true)
            {
                if (listbox_catnames_addnewregistration.Items.Count == 0)//Check for a lack of cats
                {
                    MessageBox.Show("Please enter at least one cat.", "Missing Cat", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Continue = false;
                }
            }

            for (int i = 0; i < listbox_catnames_addnewregistration.Items.Count; i++)
            {
                for (int charpointer = 0; charpointer < listbox_catnames_addnewregistration.Items[i].ToString().Length; charpointer++)//Check for a lack of name in each cat
                {
                    if (Char.IsLetter(listbox_catnames_addnewregistration.Items[i].ToString(), charpointer))
                    {
                        goto CatNameExists;
                    }
                }
                if (Continue == true)
                {
                    Continue = false;
                    switch (i)
                    {//Switch, case to show specific message boxes
                        case 0:
                            MessageBox.Show("Please enter a name for the first cat.", "Missing Cat Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        case 1:
                            MessageBox.Show("Please enter a name for the second cat.", "Missing Cat Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        case 2:
                            MessageBox.Show("Please enter a name for the third cat.", "Missing Cat Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        case 3:
                            MessageBox.Show("Please enter a name for the fourth cat.", "Missing Cat Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        case 4:
                            MessageBox.Show("Please enter a name for the fifth cat.", "Missing Cat Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        case 5:
                            MessageBox.Show("Please enter a name for the sixth cat.", "Missing Cat Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                    }
                }
            CatNameExists:
                if (Convert.ToDateTime(listbox_dob_addnewregistration.Items[i].ToString()) > DateTime.Today)
                {
                    if (Continue == true)
                    {
                        switch (i)
                        {
                            case 0:
                                if (MessageBox.Show("The date of birth for the first cat is in the future. Do you wish to continue?", "Invalid Date Of Birth", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                                {
                                    Continue = false;
                                }
                                break;
                            case 1:
                                if (MessageBox.Show("The date of birth for the second cat is in the future. Do you wish to continue?", "Invalid Date Of Birth", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                                {
                                    Continue = false;
                                }
                                break;
                            case 2:
                                if (MessageBox.Show("The date of birth for the third cat is in the future. Do you wish to continue?", "Invalid Date Of Birth", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                                {
                                    Continue = false;
                                }
                                break;
                            case 3:
                                if (MessageBox.Show("The date of birth for the fourth cat is in the future. Do you wish to continue?", "Invalid Date Of Birth", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                                {
                                    Continue = false;
                                }
                                break;
                            case 4:
                                if (MessageBox.Show("The date of birth for the fifth cat is in the future. Do you wish to continue?", "Invalid Date Of Birth", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                                {
                                    Continue = false;
                                }
                                break;
                            case 5:
                                if (MessageBox.Show("The date of birth for the sixth cat is in the future. Do you wish to continue?", "Invalid Date Of Birth", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                                {
                                    Continue = false;
                                }
                                break;
                        }
                    }
                }
            else if (Convert.ToDateTime(listbox_dob_addnewregistration.Items[i].ToString()) == DateTime.Today)
            {
                if (Continue == true)
                {
                    switch (i)
                    {
                        case 0:
                            if (MessageBox.Show("The date of birth for the first cat is today. Do you wish to continue?", "Is the Date Of Birth correct?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                            {
                                Continue = false;
                            }
                            break;
                        case 1:
                            if (MessageBox.Show("The date of birth for the second cat is today. Do you wish to continue?", "Is the Date Of Birth correct?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                            {
                                Continue = false;
                            }
                            break;
                        case 2:
                            if (MessageBox.Show("The date of birth for the third cat is today. Do you wish to continue?", "Is the Date Of Birth correct?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                            {
                                Continue = false;
                            }
                            break;
                        case 3:
                            if (MessageBox.Show("The date of birth for the fourth cat is today. Do you wish to continue?", "Is the Date Of Birth correct?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                            {
                                Continue = false;
                            }
                            break;
                        case 4:
                            if (MessageBox.Show("The date of birth for the fifth cat is today. Do you wish to continue?", "Is the Date Of Birth correct?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                            {
                                Continue = false;
                            }
                            break;
                        case 5:
                            if (MessageBox.Show("The date of birth for the sixth cat is today. Do you wish to continue?", "Is the Date Of Birth correct?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                            {
                                Continue = false;
                            }
                            break;
                    }
                }
            }
                if (Convert.ToDateTime(listbox_vaccination_addnewregistration.Items[i].ToString()) < DateTime.Today)
                {
                    if (Continue == true)
                    {
                        switch (i)
                        {
                            case 0:
                                if (MessageBox.Show("The date of the next vaccination for the first cat is in the past. Do you wish to continue?", "Invalid Next Vaccination Date", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                                {
                                    Continue = false;
                                }
                                break;
                            case 1:
                                if (MessageBox.Show("The date of the next vaccination for the second cat is in the past. Do you wish to continue?", "Invalid Next Vaccination Date", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                                {
                                    Continue = false;
                                }
                                break;
                            case 2:
                                if (MessageBox.Show("The date of the next vaccination for the third cat is in the past. Do you wish to continue?", "Invalid Next Vaccination Date", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                                {
                                    Continue = false;
                                }
                                break;
                            case 3:
                                if (MessageBox.Show("The date of the next vaccination for the fourth cat is in the past. Do you wish to continue?", "Invalid Next Vaccination Date", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                                {
                                    Continue = false;
                                }
                                break;
                            case 4:
                                if (MessageBox.Show("The date of the next vaccination for the fifth cat is in the past. Do you wish to continue?", "Invalid Next Vaccination Date", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                                {
                                    Continue = false;
                                }
                                break;
                            case 5:
                                if (MessageBox.Show("The date of the next vaccination for the sixth cat is in the past. Do you wish to continue?", "Invalid Next Vaccination Date", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                                {
                                    Continue = false;
                                }
                                break;
                        }
                    }
                }
                else if (Convert.ToDateTime(listbox_vaccination_addnewregistration.Items[i].ToString()) == DateTime.Today)
                {
                    if (Continue == true)
                    {
                        switch (i)
                        {
                            case 0:
                                if (MessageBox.Show("The date of the next vaccination for the first cat is today. Do you wish to continue?", "Is the Next Vaccination Date correct?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                                {
                                    Continue = false;
                                }
                                break;
                            case 1:
                                if (MessageBox.Show("The date of the next vaccination for the second cat is today. Do you wish to continue?", "Is the Next Vaccination Date correct?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                                {
                                    Continue = false;
                                }
                                break;
                            case 2:
                                if (MessageBox.Show("The date of the next vaccination for the third cat is today. Do you wish to continue?", "Is the Next Vaccination Date correct?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                                {
                                    Continue = false;
                                }
                                break;
                            case 3:
                                if (MessageBox.Show("The date of the next vaccination for the fourth cat is today. Do you wish to continue?", "Is the Next Vaccination Date correct?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                                {
                                    Continue = false;
                                }
                                break;
                            case 4:
                                if (MessageBox.Show("The date of the next vaccination for the fifth cat is today. Do you wish to continue?", "Is the Next Vaccination Date correct?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                                {
                                    Continue = false;
                                }
                                break;
                            case 5:
                                if (MessageBox.Show("The date of the next vaccination for the sixth cat is today. Do you wish to continue?", "Is the Next Vaccination Date correct?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                                {
                                    Continue = false;
                                }
                                break;
                        }
                    }
                }
                
            }
            if (Continue == true)
            {
                bool editcat = false;
                for (int charpointer = 0; charpointer < text_addcatname_addnewregistration.Text.Length; charpointer++)//Check for a lack text in directory text box
                {
                    if (Char.IsLetter(text_addcatname_addnewregistration.Text, charpointer))
                    {
                        editcat = true;
                    }
                }
                if (editcat == true)
                {
                    if (MessageBox.Show("There is text in the cat name text box. Do you wish to continue?", "Adding/Editing a cat?", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        Continue = false;
                    }
                }
            }
            #endregion
            if (Continue == true)
            {
                if (MyGlobalClass.registration_addnewregistration == "") //The registration_addnewregistration variable stores any registration that is being edited
                {
                    # region newregistration
                    string new_registration = "";
                    string address_id = "";
                    string home_telephone_id = "";
                    string absence_contact_id = "";
                    string vet_id = "";
                    int records = 0;
                    #region owners
                    for (int i = 0; i < listbox_owners_addnewregistration.Items.Count; i++)
                    {
                        if (listbox_owners_addnewregistration.Items[i].ToString() != "")
                        {
                            string owner_name_id = "";
                            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact names` WHERE `Contact Name` = '" + this.listbox_owners_addnewregistration.Items[i].ToString() + "' ;", MyGlobalClass.new_connection);
                            MyGlobalClass.new_connection.Open(); //Checking if the owner name already exists in the databse
                            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                            records = 0;
                            while (MyGlobalClass.SQL_Alter_Database.Read())
                            {
                                records++; //Counting up the instances of the owner name
                                owner_name_id = MyGlobalClass.SQL_Alter_Database["Contact Name ID"].ToString(); //If found (there should only be either 0 or 1 instance of the owner name), the owner name id is stored
                            }
                            MyGlobalClass.new_connection.Close();
                            if (records == 1)
                            {
                                string owner_count = Convert.ToString(i + 1);
                                if (new_registration == "") //If a new registration needs to be made, just insert the new owner name id into the required owner id field
                                {
                                    MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`registrations` (`Owner " + owner_count + " ID`) VALUES ('" + owner_name_id + "'); SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                                    MyGlobalClass.new_connection.Open();
                                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                    while (MyGlobalClass.SQL_Alter_Database.Read())
                                    {
                                        new_registration = MyGlobalClass.SQL_Alter_Database["Registration ID"].ToString();
                                    }
                                    MyGlobalClass.new_connection.Close();
                                }
                                else //If a registration has already been added in the database for the new registration, update the database and insert the new owner name id
                                {
                                    MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`registrations` SET `Owner " + owner_count + " ID`='" + owner_name_id + "' WHERE `Registration ID`='" + new_registration + "';", MyGlobalClass.new_connection);
                                    MyGlobalClass.new_connection.Open();
                                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                    MyGlobalClass.new_connection.Close();
                                }
                            }
                            else if (records > 1) //There should not be more than one instance of the owner name so, if there is, a message box is shown
                            {
                                MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else if (records == 0) //If there are no instances, the owner name is added to database, and then the id is added to the registration record
                            {
                                MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`contact names` (`Contact Name`) VALUES ('" + this.listbox_owners_addnewregistration.Items[i].ToString() + "'); SELECT * FROM `chichester_cattery_booking_system`.`contact names` WHERE `Contact Name ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                                MyGlobalClass.new_connection.Open();
                                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                while (MyGlobalClass.SQL_Alter_Database.Read())
                                {
                                    owner_name_id = MyGlobalClass.SQL_Alter_Database["Contact Name ID"].ToString();
                                }
                                MyGlobalClass.new_connection.Close();

                                string owner_count = Convert.ToString(i + 1);
                                if (new_registration == "")
                                {
                                    MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`registrations` (`Owner " + owner_count + " ID`) VALUES ('" + owner_name_id + "'); SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                                    MyGlobalClass.new_connection.Open();
                                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                    while (MyGlobalClass.SQL_Alter_Database.Read())
                                    {
                                        new_registration = MyGlobalClass.SQL_Alter_Database["Registration ID"].ToString();
                                    }
                                    MyGlobalClass.new_connection.Close();
                                }
                                else
                                {
                                    MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`registrations` SET `Owner " + owner_count + " ID`='" + owner_name_id + "' WHERE `Registration ID`='" + new_registration + "';", MyGlobalClass.new_connection);
                                    MyGlobalClass.new_connection.Open();
                                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                    MyGlobalClass.new_connection.Close();
                                }
                            }
                        }
                    }
                    #endregion
                    #region address
                    string town_id = "";
                    string postcode_id = "";
                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`towns` WHERE `Town` = '" + this.text_town_addnewregistration.Text + "' ;", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    records = 0;
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        records++;
                        town_id = MyGlobalClass.SQL_Alter_Database["Town ID"].ToString();
                    }
                    MyGlobalClass.new_connection.Close();
                    if (records == 0)
                    {
                        MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`towns` (`Town`) VALUES ('" + this.text_town_addnewregistration.Text + "'); SELECT * FROM `chichester_cattery_booking_system`.`towns` WHERE `Town ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        while (MyGlobalClass.SQL_Alter_Database.Read())
                        {
                            town_id = MyGlobalClass.SQL_Alter_Database["Town ID"].ToString();
                        }
                        MyGlobalClass.new_connection.Close();
                    }
                    else if (records > 1)
                    {
                        MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`postcodes` WHERE `Postcode` = '" + this.text_postcode_addnewregistration.Text + "' ;", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    records = 0;
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        records++;
                        postcode_id = MyGlobalClass.SQL_Alter_Database["Postcode ID"].ToString();
                    }
                    MyGlobalClass.new_connection.Close();
                    if (records == 0)
                    {
                        MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`postcodes` (`Postcode`) VALUES ('" + this.text_postcode_addnewregistration.Text + "'); SELECT * FROM `chichester_cattery_booking_system`.`postcodes` WHERE `Postcode ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        while (MyGlobalClass.SQL_Alter_Database.Read())
                        {
                            postcode_id = MyGlobalClass.SQL_Alter_Database["Postcode ID"].ToString();
                        }
                        MyGlobalClass.new_connection.Close();
                    }
                    else if (records > 1)
                    {
                        MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`addresses` WHERE `Address` = '" + this.text_address_addnewregistration.Text + "' AND `Town ID` = '" + town_id + "' AND `Postcode ID` = '" + postcode_id + "' ;", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    records = 0;
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        records++;
                        address_id = MyGlobalClass.SQL_Alter_Database["Address ID"].ToString();
                    }
                    MyGlobalClass.new_connection.Close();

                    if (records == 0)
                    {
                        MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`addresses` (`Address`, `Town ID`, `Postcode ID`) VALUES ('" + this.text_address_addnewregistration.Text + "', '" + town_id + "', '" + postcode_id + "');  SELECT * FROM `chichester_cattery_booking_system`.`addresses` WHERE `Address ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        while (MyGlobalClass.SQL_Alter_Database.Read())
                        {
                            address_id = MyGlobalClass.SQL_Alter_Database["Address ID"].ToString();
                        }
                        MyGlobalClass.new_connection.Close();
                    }
                    else if (records > 1)
                    {
                        MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    if (new_registration == "")
                    {
                        MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`registrations` (`Address ID`) VALUES ('" + address_id + "');  SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        while (MyGlobalClass.SQL_Alter_Database.Read())
                        {
                            new_registration = MyGlobalClass.SQL_Alter_Database["Registration ID"].ToString();
                        }
                        MyGlobalClass.new_connection.Close();
                    }
                    else
                    {
                        MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`registrations` SET `Address ID`='" + address_id + "' WHERE `Registration ID`='" + new_registration + "';", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        MyGlobalClass.new_connection.Close();
                    }
                    #endregion
                    #region hometelephone
                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact telephones` WHERE `Contact Telephone` = '" + this.text_homenumber_addnewregistration.Text + "' ;", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    records = 0;
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        records++;
                        home_telephone_id = MyGlobalClass.SQL_Alter_Database["Contact Telephone ID"].ToString();
                    }
                    MyGlobalClass.new_connection.Close();
                    if (records == 0)
                    {
                        MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`contact telephones` (`Contact Telephone`) VALUES ('" + this.text_homenumber_addnewregistration.Text + "');  SELECT * FROM `chichester_cattery_booking_system`.`contact telephones` WHERE `Contact Telephone ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        while (MyGlobalClass.SQL_Alter_Database.Read())
                        {
                            home_telephone_id = MyGlobalClass.SQL_Alter_Database["Contact Telephone ID"].ToString();
                        }
                        MyGlobalClass.new_connection.Close();
                    }
                    else if (records > 1)
                    {
                        MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    if (new_registration == "")
                    {
                        MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`registrations` (`Home Telephone ID`) VALUES ('" + home_telephone_id + "'); SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        while (MyGlobalClass.SQL_Alter_Database.Read())
                        {
                            new_registration = MyGlobalClass.SQL_Alter_Database["Registration ID"].ToString();
                        }
                        MyGlobalClass.new_connection.Close();
                    }
                    else
                    {
                        MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`registrations` SET `Home Telephone ID`='" + home_telephone_id + "' WHERE `Registration ID`='" + new_registration + "';", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        MyGlobalClass.new_connection.Close();
                    }
                    #endregion
                    #region mobiles
                    for (int i = 0; i < listbox_moblies_addnewregistration.Items.Count; i++)
                    {
                        if (listbox_owners_addnewregistration.Items[i].ToString() != "")
                        {
                            string mobile_id = "";
                            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact telephones` WHERE `Contact Telephone` = '" + this.listbox_moblies_addnewregistration.Items[i].ToString() + "' ;", MyGlobalClass.new_connection);
                            MyGlobalClass.new_connection.Open();
                            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                            records = 0;
                            while (MyGlobalClass.SQL_Alter_Database.Read())
                            {
                                records++;
                                mobile_id = MyGlobalClass.SQL_Alter_Database["Contact Telephone ID"].ToString();
                            }
                            MyGlobalClass.new_connection.Close();
                            if (records == 1)
                            {
                                string mobile_count = Convert.ToString(i + 1);
                                if (new_registration == "")
                                {
                                    MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`registrations` (`Mobile " + mobile_id + " ID`) VALUES ('" + mobile_id + "');  SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                                    MyGlobalClass.new_connection.Open();
                                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                    while (MyGlobalClass.SQL_Alter_Database.Read())
                                    {
                                        new_registration = MyGlobalClass.SQL_Alter_Database["Registration ID"].ToString();
                                    }
                                    MyGlobalClass.new_connection.Close();
                                }
                                else
                                {
                                    MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`registrations` SET `Mobile " + mobile_count + " ID`='" + mobile_id + "' WHERE `Registration ID`='" + new_registration + "';", MyGlobalClass.new_connection);
                                    MyGlobalClass.new_connection.Open();
                                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                    MyGlobalClass.new_connection.Close();
                                }
                            }
                            else if (records > 1)
                            {
                                MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else if (records == 0)
                            {
                                MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`contact telephones` (`Contact Telephone`) VALUES ('" + this.listbox_moblies_addnewregistration.Items[i].ToString() + "'); SELECT * FROM `chichester_cattery_booking_system`.`contact telephones` WHERE `Contact Telephone ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                                MyGlobalClass.new_connection.Open();
                                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                while (MyGlobalClass.SQL_Alter_Database.Read())
                                {
                                    mobile_id = MyGlobalClass.SQL_Alter_Database["Contact Telephone ID"].ToString();
                                }
                                MyGlobalClass.new_connection.Close();

                                string mobile_count = Convert.ToString(i + 1);
                                if (new_registration == "")
                                {
                                    MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`registrations` (`Mobile " + mobile_count + " ID`) VALUES ('" + mobile_id + "'); SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                                    MyGlobalClass.new_connection.Open();
                                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                    while (MyGlobalClass.SQL_Alter_Database.Read())
                                    {
                                        new_registration = MyGlobalClass.SQL_Alter_Database["Registration ID"].ToString();
                                    }
                                    MyGlobalClass.new_connection.Close();
                                }
                                else
                                {
                                    MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`registrations` SET `Mobile " + mobile_count + " ID`='" + mobile_id + "' WHERE `Registration ID`='" + new_registration + "';", MyGlobalClass.new_connection);
                                    MyGlobalClass.new_connection.Open();
                                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                    MyGlobalClass.new_connection.Close();
                                }
                            }
                        }
                    }
                    #endregion
                    #region cats
                    for (int i = 0; i < listbox_catnames_addnewregistration.Items.Count; i++)
                    {
                        if (listbox_catnames_addnewregistration.Items[i].ToString() != "")
                        {
                            string cat_id = "";
                            string cat_name_id = "";
                            string cat_dob = DateTime.Parse(this.listbox_dob_addnewregistration.Items[i].ToString()).ToString("yyyy-MM-dd");
                            string sex_id = "";
                            string cat_vaccinationdate = DateTime.Parse(this.listbox_vaccination_addnewregistration.Items[i].ToString()).ToString("yyyy-MM-dd");
                            string description_id = "";
                            string food_id = "";
                            string foodstobeavoided = this.listbox_foodtobeavoided_addnewregistration.Items[i].ToString();
                            string allergies = this.listbox_allergies_addnewregistration.Items[i].ToString();
                            string specialtreatment = this.listbox_specialtreatment_addnewregistration.Items[i].ToString();

                            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`cat names` WHERE `Cat Name` = '" + this.listbox_catnames_addnewregistration.Items[i].ToString() + "' ;", MyGlobalClass.new_connection);
                            MyGlobalClass.new_connection.Open();
                            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                            records = 0;
                            while (MyGlobalClass.SQL_Alter_Database.Read())
                            {
                                records++;
                                cat_name_id = MyGlobalClass.SQL_Alter_Database["Cat Name ID"].ToString();
                            }
                            MyGlobalClass.new_connection.Close();
                            if (records > 1)
                            {
                                MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else if (records == 0)
                            {
                                MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`cat names` (`Cat Name`) VALUES ('" + this.listbox_catnames_addnewregistration.Items[i].ToString() + "');  SELECT * FROM `chichester_cattery_booking_system`.`cat names` WHERE `Cat Name ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                                MyGlobalClass.new_connection.Open();
                                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                while (MyGlobalClass.SQL_Alter_Database.Read())
                                {
                                    cat_name_id = MyGlobalClass.SQL_Alter_Database["Cat Name ID"].ToString();
                                }
                                MyGlobalClass.new_connection.Close();
                            }

                            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`sexes` WHERE `Sex` = '" + this.listbox_sex_addnewregistration.Items[i].ToString() + "' ;", MyGlobalClass.new_connection);
                            MyGlobalClass.new_connection.Open();
                            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                            records = 0;
                            while (MyGlobalClass.SQL_Alter_Database.Read())
                            {
                                records++;
                                sex_id = MyGlobalClass.SQL_Alter_Database["Sex ID"].ToString();
                            }
                            MyGlobalClass.new_connection.Close();
                            if (records > 1)
                            {
                                MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else if (records == 0)
                            {
                                MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`sexes` (`Sex`) VALUES ('" + this.listbox_sex_addnewregistration.Items[i].ToString() + "'); SELECT * FROM `chichester_cattery_booking_system`.`sexes` WHERE `Sex ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                                MyGlobalClass.new_connection.Open();
                                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                while (MyGlobalClass.SQL_Alter_Database.Read())
                                {
                                    sex_id = MyGlobalClass.SQL_Alter_Database["Sex ID"].ToString();
                                }
                                MyGlobalClass.new_connection.Close();
                            }

                            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`descriptions` WHERE `Description` = '" + this.listbox_description_addnewregistration.Items[i].ToString() + "' ;", MyGlobalClass.new_connection);
                            MyGlobalClass.new_connection.Open();
                            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                            records = 0;
                            while (MyGlobalClass.SQL_Alter_Database.Read())
                            {
                                records++;
                                description_id = MyGlobalClass.SQL_Alter_Database["Description ID"].ToString();
                            }
                            MyGlobalClass.new_connection.Close();
                            if (records > 1)
                            {
                                MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else if (records == 0)
                            {
                                MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`descriptions` (`Description`) VALUES ('" + this.listbox_description_addnewregistration.Items[i].ToString() + "'); SELECT * FROM `chichester_cattery_booking_system`.`descriptions` WHERE `Description ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                                MyGlobalClass.new_connection.Open();
                                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                while (MyGlobalClass.SQL_Alter_Database.Read())
                                {
                                    description_id = MyGlobalClass.SQL_Alter_Database["Description ID"].ToString();
                                }
                                MyGlobalClass.new_connection.Close();
                            }

                            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`foods` WHERE `Food` = '" + this.listbox_diet_addnewregistration.Items[i].ToString() + "' ;", MyGlobalClass.new_connection);
                            MyGlobalClass.new_connection.Open();
                            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                            records = 0;
                            while (MyGlobalClass.SQL_Alter_Database.Read())
                            {
                                records++;
                                food_id = MyGlobalClass.SQL_Alter_Database["Food ID"].ToString();
                            }
                            MyGlobalClass.new_connection.Close();
                            if (records > 1)
                            {
                                MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else if (records == 0)
                            {
                                MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`foods` (`Food`) VALUES ('" + this.listbox_diet_addnewregistration.Items[i].ToString() + "'); SELECT * FROM `chichester_cattery_booking_system`.`foods` WHERE `Food ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                                MyGlobalClass.new_connection.Open();
                                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                while (MyGlobalClass.SQL_Alter_Database.Read())
                                {
                                    food_id = MyGlobalClass.SQL_Alter_Database["Food ID"].ToString();
                                }
                                MyGlobalClass.new_connection.Close();
                            }

                            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`cats` WHERE `Cat Name ID` = '" + cat_name_id + "'AND `Date Of Birth` = '" + cat_dob + "' AND `Sex ID` = '" + sex_id + "' AND `Next Vaccination Date` = '" + cat_vaccinationdate + "' AND `Description ID` = '" + description_id + "' AND `Food ID` = '" + food_id + "' AND `Foods To Be Avoided` = '" + foodstobeavoided + "' AND `Allergies` = '" + allergies + "' AND `Special Treatment` = '" + specialtreatment + "';", MyGlobalClass.new_connection);
                            MyGlobalClass.new_connection.Open();
                            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                            records = 0;
                            while (MyGlobalClass.SQL_Alter_Database.Read())
                            {
                                records++;
                                cat_id = MyGlobalClass.SQL_Alter_Database["Cat ID"].ToString();
                            }
                            MyGlobalClass.new_connection.Close();
                            if (records > 1)
                            {
                                MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else if (records == 0)
                            {
                                MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`cats` (`Cat Name ID`,`Date Of Birth`,`Sex ID`,`Next Vaccination Date`,`Description ID`,`Food ID`,`Foods To Be Avoided`,`Allergies`,`Special Treatment`) VALUES ('" + cat_name_id + "','" + cat_dob + "','" + sex_id + "','" + cat_vaccinationdate + "','" + description_id + "','" + food_id + "','" + foodstobeavoided + "','" + allergies + "','" + specialtreatment + "'); SELECT * FROM `chichester_cattery_booking_system`.`cats` WHERE `Cat ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                                MyGlobalClass.new_connection.Open();
                                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                while (MyGlobalClass.SQL_Alter_Database.Read())
                                {
                                    cat_id = MyGlobalClass.SQL_Alter_Database["Cat ID"].ToString();
                                }
                                MyGlobalClass.new_connection.Close();
                            }

                            string cat_count = Convert.ToString(i + 1);
                            if (new_registration == "")
                            {
                                MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`registrations` (`Cat " + cat_count + " ID`) VALUES ('" + cat_id + "'); SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                                MyGlobalClass.new_connection.Open();
                                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                while (MyGlobalClass.SQL_Alter_Database.Read())
                                {
                                    new_registration = MyGlobalClass.SQL_Alter_Database["Registration ID"].ToString();
                                }
                                MyGlobalClass.new_connection.Close();
                            }
                            else
                            {
                                MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`registrations` SET `Cat " + cat_count + " ID`='" + cat_id + "' WHERE `Registration ID`='" + new_registration + "';", MyGlobalClass.new_connection);
                                MyGlobalClass.new_connection.Open();
                                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                MyGlobalClass.new_connection.Close();
                            }
                        }
                    }
                    #endregion
                    #region absencecontact
                    string absence_contact_name = "";
                    string absence_contact_number = "";
                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact names` WHERE `Contact Name` = '" + this.text_absencecontact_addnewregistration.Text + "' ;", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    records = 0;
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        records++;
                        absence_contact_name = MyGlobalClass.SQL_Alter_Database["Contact Name ID"].ToString();
                    }
                    MyGlobalClass.new_connection.Close();

                    if (records == 0)
                    {
                        MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`contact names` (`Contact Name`) VALUES ('" + this.text_absencecontact_addnewregistration.Text + "'); SELECT * FROM `chichester_cattery_booking_system`.`contact names` WHERE `Contact Name ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        while (MyGlobalClass.SQL_Alter_Database.Read())
                        {
                            absence_contact_name = MyGlobalClass.SQL_Alter_Database["Contact Name ID"].ToString();
                        }
                        MyGlobalClass.new_connection.Close();
                    }
                    else if (records > 1)
                    {
                        MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact telephones` WHERE `Contact Telephone` = '" + this.text_absencenumber_addnewregistration.Text + "' ;", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    records = 0;
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        records++;
                        absence_contact_number = MyGlobalClass.SQL_Alter_Database["Contact Telephone ID"].ToString();
                    }
                    MyGlobalClass.new_connection.Close();

                    if (records == 0)
                    {
                        MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`contact telephones` (`Contact Telephone`) VALUES ('" + this.text_absencenumber_addnewregistration.Text + "'); SELECT * FROM `chichester_cattery_booking_system`.`contact telephones` WHERE `Contact Telephone ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        while (MyGlobalClass.SQL_Alter_Database.Read())
                        {
                            absence_contact_number = MyGlobalClass.SQL_Alter_Database["Contact Telephone ID"].ToString();
                        }
                        MyGlobalClass.new_connection.Close();
                    }
                    else if (records > 1)
                    {
                        MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`absence contacts` WHERE `Contact Name ID` = '" + absence_contact_name + "'AND `Contact Telephone ID` = '" + absence_contact_number + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    records = 0;
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        records++;
                        absence_contact_id = MyGlobalClass.SQL_Alter_Database["Absence Contact ID"].ToString();
                    }
                    MyGlobalClass.new_connection.Close();

                    if (records == 1)
                    {
                        if (new_registration == "")
                        {
                            MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`registrations` (`Absence Contact ID`) VALUES ('" + absence_contact_id + "'); SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                            MyGlobalClass.new_connection.Open();
                            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                            while (MyGlobalClass.SQL_Alter_Database.Read())
                            {
                                new_registration = MyGlobalClass.SQL_Alter_Database["Registration ID"].ToString();
                            }
                            MyGlobalClass.new_connection.Close();
                        }
                        else
                        {
                            MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`registrations` SET `Absence Contact ID`='" + absence_contact_id + "' WHERE `Registration ID`='" + new_registration + "';", MyGlobalClass.new_connection);
                            MyGlobalClass.new_connection.Open();
                            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                            MyGlobalClass.new_connection.Close();
                        }
                    }
                    else if (records == 0)
                    {
                        MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`absence contacts` (`Contact Name ID`,`Contact Telephone ID`) VALUES ('" + absence_contact_name + "','" + absence_contact_number + "'); SELECT * FROM `chichester_cattery_booking_system`.`absence contacts` WHERE `Absence Contact ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        while (MyGlobalClass.SQL_Alter_Database.Read())
                        {
                            absence_contact_id = MyGlobalClass.SQL_Alter_Database["Absence Contact ID"].ToString();
                        }
                        MyGlobalClass.new_connection.Close();

                        if (new_registration == "")
                        {
                            MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`registrations` (`Absence Contact ID`) VALUES ('" + absence_contact_id + "'); SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                            MyGlobalClass.new_connection.Open();
                            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                            while (MyGlobalClass.SQL_Alter_Database.Read())
                            {
                                new_registration = MyGlobalClass.SQL_Alter_Database["Registration ID"].ToString();
                            }
                            MyGlobalClass.new_connection.Close();
                        }
                        else
                        {
                            MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`registrations` SET `Absence Contact ID`='" + absence_contact_id + "' WHERE `Registration ID`='" + new_registration + "';", MyGlobalClass.new_connection);
                            MyGlobalClass.new_connection.Open();
                            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                            MyGlobalClass.new_connection.Close();
                        }
                    }
                    else if (records > 1)
                    {
                        MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    #endregion
                    #region vet
                    string vet_name = "";
                    string vet_number = "";
                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact names` WHERE `Contact Name` = '" + this.text_vetname_addnewregistration.Text + "' ;", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    records = 0;
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        records++;
                        vet_name = MyGlobalClass.SQL_Alter_Database["Contact Name ID"].ToString();
                    }
                    MyGlobalClass.new_connection.Close();

                    if (records == 0)
                    {
                        MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`contact names` (`Contact Name`) VALUES ('" + this.text_vetname_addnewregistration.Text + "'); SELECT * FROM `chichester_cattery_booking_system`.`contact names` WHERE `Contact Name ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        while (MyGlobalClass.SQL_Alter_Database.Read())
                        {
                            vet_name = MyGlobalClass.SQL_Alter_Database["Contact Name ID"].ToString();
                        }
                        MyGlobalClass.new_connection.Close();
                    }
                    else if (records > 1)
                    {
                        MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact telephones` WHERE `Contact Telephone` = '" + this.text_vetnumber_addnewregistration.Text + "' ;", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    records = 0;
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        records++;
                        vet_number = MyGlobalClass.SQL_Alter_Database["Contact Telephone ID"].ToString();
                    }
                    MyGlobalClass.new_connection.Close();

                    if (records == 0)
                    {
                        MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`contact telephones` (`Contact Telephone`) VALUES ('" + this.text_vetnumber_addnewregistration.Text + "'); SELECT * FROM `chichester_cattery_booking_system`.`contact telephones` WHERE `Contact Telephone ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        while (MyGlobalClass.SQL_Alter_Database.Read())
                        {
                            vet_number = MyGlobalClass.SQL_Alter_Database["Contact Telephone ID"].ToString();
                        }
                        MyGlobalClass.new_connection.Close();
                    }
                    else if (records > 1)
                    {
                        MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`vets` WHERE `Contact Name ID` = '" + vet_name + "'AND `Contact Telephone ID` = '" + vet_number + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    records = 0;
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        records++;
                        vet_id = MyGlobalClass.SQL_Alter_Database["Vet ID"].ToString();
                    }
                    MyGlobalClass.new_connection.Close();

                    if (records == 1)
                    {
                        if (new_registration == "")
                        {
                            MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`registrations` (`Vet ID`) VALUES ('" + vet_id + "'); SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                            MyGlobalClass.new_connection.Open();
                            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                            while (MyGlobalClass.SQL_Alter_Database.Read())
                            {
                                new_registration = MyGlobalClass.SQL_Alter_Database["Registration ID"].ToString();
                            }
                            MyGlobalClass.new_connection.Close();
                        }
                        else
                        {
                            MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`registrations` SET `Vet ID`='" + vet_id + "' WHERE `Registration ID`='" + new_registration + "';", MyGlobalClass.new_connection);
                            MyGlobalClass.new_connection.Open();
                            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                            MyGlobalClass.new_connection.Close();
                        }
                    }
                    else if (records == 0)
                    {
                        MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`vets` (`Contact Name ID`,`Contact Telephone ID`) VALUES ('" + vet_name + "','" + vet_number + "'); SELECT * FROM `chichester_cattery_booking_system`.`vets` WHERE `Vet ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        while (MyGlobalClass.SQL_Alter_Database.Read())
                        {
                            vet_id = MyGlobalClass.SQL_Alter_Database["Vet ID"].ToString();
                        }
                        MyGlobalClass.new_connection.Close();

                        if (new_registration == "")
                        {
                            MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`registrations` (`Vet ID`) VALUES ('" + vet_id + "'); SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                            MyGlobalClass.new_connection.Open();
                            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                            while (MyGlobalClass.SQL_Alter_Database.Read())
                            {
                                new_registration = MyGlobalClass.SQL_Alter_Database["Registration ID"].ToString();
                            }
                            MyGlobalClass.new_connection.Close();
                        }
                        else
                        {
                            MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`registrations` SET `Vet ID`='" + vet_id + "' WHERE `Registration ID`='" + new_registration + "';", MyGlobalClass.new_connection);
                            MyGlobalClass.new_connection.Open();
                            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                            MyGlobalClass.new_connection.Close();
                        }
                    }
                    else if (records > 1)
                    {
                        MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    #endregion
                    MyGlobalClass.registration_registrationsystem = new_registration;
                }
                    #endregion
                else
                {
                    #region altered registration
                    MyGlobalClass.retrieveregistrationdata(MyGlobalClass.registration_addnewregistration, false);
                    #region Owners
                    int records = 0;
                    for (int i = 0; i < 6; i++)
                    {
                        if (i < listbox_owners_addnewregistration.Items.Count)
                        {
                            if (listbox_owners_addnewregistration.Items[i].ToString() != MyGlobalClass.selectedregistration[i, 0])
                            { // If there is a change
                                if (listbox_owners_addnewregistration.Items[i].ToString() != "")
                                {
                                    string owner_name_id = ""; //Standard check for instances and insertion
                                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact names` WHERE `Contact Name` = '" + this.listbox_owners_addnewregistration.Items[i].ToString() + "' ;", MyGlobalClass.new_connection);
                                    MyGlobalClass.new_connection.Open();
                                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                    records = 0;
                                    while (MyGlobalClass.SQL_Alter_Database.Read())
                                    {
                                        records++;
                                        owner_name_id = MyGlobalClass.SQL_Alter_Database["Contact Name ID"].ToString();
                                    }
                                    MyGlobalClass.new_connection.Close();
                                    if (records > 1)
                                    {
                                        MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                    else if (records == 0)
                                    {
                                        MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`contact names` (`Contact Name`) VALUES ('" + this.listbox_owners_addnewregistration.Items[i].ToString() + "'); SELECT * FROM `chichester_cattery_booking_system`.`contact names` WHERE `Contact Name ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                                        MyGlobalClass.new_connection.Open();
                                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                        while (MyGlobalClass.SQL_Alter_Database.Read())
                                        {
                                            owner_name_id = MyGlobalClass.SQL_Alter_Database["Contact Name ID"].ToString();
                                        }
                                        MyGlobalClass.new_connection.Close();
                                    }
                                    string owner_count = Convert.ToString(i + 1); //Updating the ids
                                    MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`registrations` SET `Owner " + owner_count + " ID`='" + owner_name_id + "' WHERE `Registration ID`='" + MyGlobalClass.registration_addnewregistration + "';", MyGlobalClass.new_connection);
                                    MyGlobalClass.new_connection.Open();
                                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                    MyGlobalClass.new_connection.Close();
                                }
                            }
                        }
                        else if (MyGlobalClass.selectedregistration[i, 0] != null)
                        {
                            string owner_count = Convert.ToString(i + 1);
                            MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`registrations` SET `Owner " + owner_count + " ID`= NULL WHERE `Registration ID`='" + MyGlobalClass.registration_addnewregistration + "';", MyGlobalClass.new_connection);
                            MyGlobalClass.new_connection.Open();
                            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                            MyGlobalClass.new_connection.Close();
                        }
                    }
                    #endregion
                    #region Address
                    if (text_address_addnewregistration.Text != MyGlobalClass.selectedregistration[6, 0] || text_town_addnewregistration.Text != MyGlobalClass.selectedregistration[7, 0] || text_postcode_addnewregistration.Text != MyGlobalClass.selectedregistration[8, 0])
                    {
                        string address_id = "";
                        string town_id = "";
                        string postcode_id = "";
                        MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`towns` WHERE `Town` = '" + this.text_town_addnewregistration.Text + "' ;", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        records = 0;
                        while (MyGlobalClass.SQL_Alter_Database.Read())
                        {
                            records++;
                            town_id = MyGlobalClass.SQL_Alter_Database["Town ID"].ToString();
                        }
                        MyGlobalClass.new_connection.Close();
                        if (records == 0)
                        {
                            MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`towns` (`Town`) VALUES ('" + this.text_town_addnewregistration.Text + "'); SELECT * FROM `chichester_cattery_booking_system`.`towns` WHERE `Town ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                            MyGlobalClass.new_connection.Open();
                            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                            while (MyGlobalClass.SQL_Alter_Database.Read())
                            {
                                town_id = MyGlobalClass.SQL_Alter_Database["Town ID"].ToString();
                            }
                            MyGlobalClass.new_connection.Close();
                        }
                        else if (records > 1)
                        {
                            MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`postcodes` WHERE `Postcode` = '" + this.text_postcode_addnewregistration.Text + "' ;", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        records = 0;
                        while (MyGlobalClass.SQL_Alter_Database.Read())
                        {
                            records++;
                            postcode_id = MyGlobalClass.SQL_Alter_Database["Postcode ID"].ToString();
                        }
                        MyGlobalClass.new_connection.Close();
                        if (records == 0)
                        {
                            MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`postcodes` (`Postcode`) VALUES ('" + this.text_postcode_addnewregistration.Text + "'); SELECT * FROM `chichester_cattery_booking_system`.`postcodes` WHERE `Postcode ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                            MyGlobalClass.new_connection.Open();
                            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                            while (MyGlobalClass.SQL_Alter_Database.Read())
                            {
                                postcode_id = MyGlobalClass.SQL_Alter_Database["Postcode ID"].ToString();
                            }
                            MyGlobalClass.new_connection.Close();
                        }
                        else if (records > 1)
                        {
                            MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`addresses` WHERE `Address` = '" + this.text_address_addnewregistration.Text + "' AND `Town ID` = '" + town_id + "' AND `Postcode ID` = '" + postcode_id + "' ;", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        records = 0;
                        while (MyGlobalClass.SQL_Alter_Database.Read())
                        {
                            records++;
                            address_id = MyGlobalClass.SQL_Alter_Database["Address ID"].ToString();
                        }
                        MyGlobalClass.new_connection.Close();

                        if (records == 0)
                        {
                            MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`addresses` (`Address`, `Town ID`, `Postcode ID`) VALUES ('" + this.text_address_addnewregistration.Text + "', '" + town_id + "', '" + postcode_id + "');  SELECT * FROM `chichester_cattery_booking_system`.`addresses` WHERE `Address ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                            MyGlobalClass.new_connection.Open();
                            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                            while (MyGlobalClass.SQL_Alter_Database.Read())
                            {
                                address_id = MyGlobalClass.SQL_Alter_Database["Address ID"].ToString();
                            }
                            MyGlobalClass.new_connection.Close();
                        }
                        else if (records > 1)
                        {
                            MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`registrations` SET `Address ID`='" + address_id + "' WHERE `Registration ID`='" + MyGlobalClass.registration_addnewregistration + "';", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        MyGlobalClass.new_connection.Close();
                    }
                    #endregion
                    #region Hometelphone
                    if (text_homenumber_addnewregistration.Text != MyGlobalClass.selectedregistration[9, 0])
                    {
                        string home_telephone_id = "";
                        MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact telephones` WHERE `Contact Telephone` = '" + this.text_homenumber_addnewregistration.Text + "' ;", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        records = 0;
                        while (MyGlobalClass.SQL_Alter_Database.Read())
                        {
                            records++;
                            home_telephone_id = MyGlobalClass.SQL_Alter_Database["Contact Telephone ID"].ToString();
                        }
                        MyGlobalClass.new_connection.Close();
                        if (records == 0)
                        {
                            MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`contact telephones` (`Contact Telephone`) VALUES ('" + this.text_homenumber_addnewregistration.Text + "');  SELECT * FROM `chichester_cattery_booking_system`.`contact telephones` WHERE `Contact Telephone ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                            MyGlobalClass.new_connection.Open();
                            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                            while (MyGlobalClass.SQL_Alter_Database.Read())
                            {
                                home_telephone_id = MyGlobalClass.SQL_Alter_Database["Contact Telephone ID"].ToString();
                            }
                            MyGlobalClass.new_connection.Close();
                        }
                        else if (records > 1)
                        {
                            MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`registrations` SET `Home Telephone ID`='" + home_telephone_id + "' WHERE `Registration ID`='" + MyGlobalClass.registration_addnewregistration + "';", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        MyGlobalClass.new_connection.Close();
                    }
                    #endregion
                    #region Mobiles
                    for (int i = 0; i < 6; i++)
                    {
                        if (i < listbox_moblies_addnewregistration.Items.Count)
                        {
                            if (listbox_moblies_addnewregistration.Items[i].ToString() != MyGlobalClass.selectedregistration[i + 10, 0])
                            {
                                if (listbox_moblies_addnewregistration.Items[i].ToString() != "")
                                {
                                    string mobile_id = "";
                                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact telephones` WHERE `Contact Telephone` = '" + this.listbox_moblies_addnewregistration.Items[i].ToString() + "' ;", MyGlobalClass.new_connection);
                                    MyGlobalClass.new_connection.Open();
                                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                    records = 0;
                                    while (MyGlobalClass.SQL_Alter_Database.Read())
                                    {
                                        records++;
                                        mobile_id = MyGlobalClass.SQL_Alter_Database["Contact Telephone ID"].ToString();
                                    }
                                    MyGlobalClass.new_connection.Close();
                                    if (records > 1)
                                    {
                                        MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                    else if (records == 0)
                                    {
                                        MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`contact telephones` (`Contact Telephone`) VALUES ('" + this.listbox_moblies_addnewregistration.Items[i].ToString() + "'); SELECT * FROM `chichester_cattery_booking_system`.`contact telephones` WHERE `Contact Telephone ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                                        MyGlobalClass.new_connection.Open();
                                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                        while (MyGlobalClass.SQL_Alter_Database.Read())
                                        {
                                            mobile_id = MyGlobalClass.SQL_Alter_Database["Contact Telephone ID"].ToString();
                                        }
                                        MyGlobalClass.new_connection.Close();
                                    }
                                    string mobile_count = Convert.ToString(i + 1);
                                    MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`registrations` SET `Mobile " + mobile_count + " ID`='" + mobile_id + "' WHERE `Registration ID`='" + MyGlobalClass.registration_addnewregistration + "';", MyGlobalClass.new_connection);
                                    MyGlobalClass.new_connection.Open();
                                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                    MyGlobalClass.new_connection.Close();
                                }
                            }
                        }
                        else
                        {
                            if (MyGlobalClass.selectedregistration[i + 10, 0] != null)
                            {
                                string mobile_count = Convert.ToString(i + 1);
                                MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`registrations` SET `Mobile " + mobile_count + " ID`= NULL WHERE `Registration ID`='" + MyGlobalClass.registration_addnewregistration + "';", MyGlobalClass.new_connection);
                                MyGlobalClass.new_connection.Open();
                                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                MyGlobalClass.new_connection.Close();
                            }
                        }

                    }
                    #endregion
                    #region Absencecontact
                    if (text_absencecontact_addnewregistration.Text != MyGlobalClass.selectedregistration[16, 0] || text_absencenumber_addnewregistration.Text != MyGlobalClass.selectedregistration[17, 0])
                    {
                        string absence_contact_id = "";
                        string absence_contact_name = "";
                        string absence_contact_number = "";
                        MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact names` WHERE `Contact Name` = '" + this.text_absencecontact_addnewregistration.Text + "' ;", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        records = 0;
                        while (MyGlobalClass.SQL_Alter_Database.Read())
                        {
                            records++;
                            absence_contact_name = MyGlobalClass.SQL_Alter_Database["Contact Name ID"].ToString();
                        }
                        MyGlobalClass.new_connection.Close();

                        if (records == 0)
                        {
                            MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`contact names` (`Contact Name`) VALUES ('" + this.text_absencecontact_addnewregistration.Text + "'); SELECT * FROM `chichester_cattery_booking_system`.`contact names` WHERE `Contact Name ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                            MyGlobalClass.new_connection.Open();
                            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                            while (MyGlobalClass.SQL_Alter_Database.Read())
                            {
                                absence_contact_name = MyGlobalClass.SQL_Alter_Database["Contact Name ID"].ToString();
                            }
                            MyGlobalClass.new_connection.Close();
                        }
                        else if (records > 1)
                        {
                            MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact telephones` WHERE `Contact Telephone` = '" + this.text_absencenumber_addnewregistration.Text + "' ;", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        records = 0;
                        while (MyGlobalClass.SQL_Alter_Database.Read())
                        {
                            records++;
                            absence_contact_number = MyGlobalClass.SQL_Alter_Database["Contact Telephone ID"].ToString();
                        }
                        MyGlobalClass.new_connection.Close();

                        if (records == 0)
                        {
                            MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`contact telephones` (`Contact Telephone`) VALUES ('" + this.text_absencenumber_addnewregistration.Text + "'); SELECT * FROM `chichester_cattery_booking_system`.`contact telephones` WHERE `Contact Telephone ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                            MyGlobalClass.new_connection.Open();
                            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                            while (MyGlobalClass.SQL_Alter_Database.Read())
                            {
                                absence_contact_number = MyGlobalClass.SQL_Alter_Database["Contact Telephone ID"].ToString();
                            }
                            MyGlobalClass.new_connection.Close();
                        }
                        else if (records > 1)
                        {
                            MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`absence contacts` WHERE `Contact Name ID` = '" + absence_contact_name + "'AND `Contact Telephone ID` = '" + absence_contact_number + "';", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        records = 0;
                        while (MyGlobalClass.SQL_Alter_Database.Read())
                        {
                            records++;
                            absence_contact_id = MyGlobalClass.SQL_Alter_Database["Absence Contact ID"].ToString();
                        }
                        MyGlobalClass.new_connection.Close();
                        if (records == 0)
                        {
                            MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`absence contacts` (`Contact Name ID`,`Contact Telephone ID`) VALUES ('" + absence_contact_name + "','" + absence_contact_number + "'); SELECT * FROM `chichester_cattery_booking_system`.`absence contacts` WHERE `Absence Contact ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                            MyGlobalClass.new_connection.Open();
                            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                            while (MyGlobalClass.SQL_Alter_Database.Read())
                            {
                                absence_contact_id = MyGlobalClass.SQL_Alter_Database["Absence Contact ID"].ToString();
                            }
                            MyGlobalClass.new_connection.Close();
                        }
                        else if (records > 1)
                        {
                            MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`registrations` SET `Absence Contact ID`='" + absence_contact_id + "' WHERE `Registration ID`='" + MyGlobalClass.registration_addnewregistration + "';", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        MyGlobalClass.new_connection.Close();
                    }
                    #endregion
                    #region Vet
                    if (text_vetname_addnewregistration.Text != MyGlobalClass.selectedregistration[18, 0] || text_vetnumber_addnewregistration.Text != MyGlobalClass.selectedregistration[19, 0])
                    {
                        string vet_id = "";
                        string vet_name = "";
                        string vet_number = "";
                        MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact names` WHERE `Contact Name` = '" + this.text_vetname_addnewregistration.Text + "' ;", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        records = 0;
                        while (MyGlobalClass.SQL_Alter_Database.Read())
                        {
                            records++;
                            vet_name = MyGlobalClass.SQL_Alter_Database["Contact Name ID"].ToString();
                        }
                        MyGlobalClass.new_connection.Close();

                        if (records == 0)
                        {
                            MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`contact names` (`Contact Name`) VALUES ('" + this.text_vetname_addnewregistration.Text + "'); SELECT * FROM `chichester_cattery_booking_system`.`contact names` WHERE `Contact Name ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                            MyGlobalClass.new_connection.Open();
                            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                            while (MyGlobalClass.SQL_Alter_Database.Read())
                            {
                                vet_name = MyGlobalClass.SQL_Alter_Database["Contact Name ID"].ToString();
                            }
                            MyGlobalClass.new_connection.Close();
                        }
                        else if (records > 1)
                        {
                            MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact telephones` WHERE `Contact Telephone` = '" + this.text_vetnumber_addnewregistration.Text + "' ;", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        records = 0;
                        while (MyGlobalClass.SQL_Alter_Database.Read())
                        {
                            records++;
                            vet_number = MyGlobalClass.SQL_Alter_Database["Contact Telephone ID"].ToString();
                        }
                        MyGlobalClass.new_connection.Close();

                        if (records == 0)
                        {
                            MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`contact telephones` (`Contact Telephone`) VALUES ('" + this.text_vetnumber_addnewregistration.Text + "'); SELECT * FROM `chichester_cattery_booking_system`.`contact telephones` WHERE `Contact Telephone ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                            MyGlobalClass.new_connection.Open();
                            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                            while (MyGlobalClass.SQL_Alter_Database.Read())
                            {
                                vet_number = MyGlobalClass.SQL_Alter_Database["Contact Telephone ID"].ToString();
                            }
                            MyGlobalClass.new_connection.Close();
                        }
                        else if (records > 1)
                        {
                            MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`vets` WHERE `Contact Name ID` = '" + vet_name + "'AND `Contact Telephone ID` = '" + vet_number + "';", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        records = 0;
                        while (MyGlobalClass.SQL_Alter_Database.Read())
                        {
                            records++;
                            vet_id = MyGlobalClass.SQL_Alter_Database["Vet ID"].ToString();
                        }
                        MyGlobalClass.new_connection.Close();

                        if (records == 0)
                        {
                            MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`vets` (`Contact Name ID`,`Contact Telephone ID`) VALUES ('" + vet_name + "','" + vet_number + "'); SELECT * FROM `chichester_cattery_booking_system`.`vets` WHERE `Vet ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                            MyGlobalClass.new_connection.Open();
                            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                            while (MyGlobalClass.SQL_Alter_Database.Read())
                            {
                                vet_id = MyGlobalClass.SQL_Alter_Database["Vet ID"].ToString();
                            }
                            MyGlobalClass.new_connection.Close();
                        }
                        else if (records > 1)
                        {
                            MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`registrations` SET `Vet ID`='" + vet_id + "' WHERE `Registration ID`='" + MyGlobalClass.registration_addnewregistration + "';", MyGlobalClass.new_connection);
                        MyGlobalClass.new_connection.Open();
                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                        MyGlobalClass.new_connection.Close();
                    }
                    #endregion
                    #region Cats
                    for (int i = 0; i < 6; i++)
                    {
                        if (i < listbox_catnames_addnewregistration.Items.Count)
                        {

                            if (listbox_catnames_addnewregistration.Items[i].ToString() != MyGlobalClass.selectedregistrationcats[0, (2 * i)] ||
                                listbox_dob_addnewregistration.Items[i].ToString() != MyGlobalClass.selectedregistrationcats[1, (2 * i)] ||
                                listbox_sex_addnewregistration.Items[i].ToString() != MyGlobalClass.selectedregistrationcats[2, (2 * i)] ||
                                listbox_vaccination_addnewregistration.Items[i].ToString() != MyGlobalClass.selectedregistrationcats[3, (2 * i)] ||
                                listbox_description_addnewregistration.Items[i].ToString() != MyGlobalClass.selectedregistrationcats[4, (2 * i)] ||
                                listbox_diet_addnewregistration.Items[i].ToString() != MyGlobalClass.selectedregistrationcats[5, (2 * i)] ||
                                listbox_foodtobeavoided_addnewregistration.Items[i].ToString() != MyGlobalClass.selectedregistrationcats[6, (2 * i)] ||
                                listbox_allergies_addnewregistration.Items[i].ToString() != MyGlobalClass.selectedregistrationcats[7, (2 * i)] ||
                                listbox_specialtreatment_addnewregistration.Items[i].ToString() != MyGlobalClass.selectedregistrationcats[8, (2 * i)])
                            {
                                if (listbox_catnames_addnewregistration.Items[i].ToString() != "")
                                {
                                    string cat_id = "";
                                    string cat_name_id = "";
                                    string cat_dob = DateTime.Parse(this.listbox_dob_addnewregistration.Items[i].ToString()).ToString("yyyy-MM-dd");
                                    string sex_id = "";
                                    string cat_vaccinationdate = DateTime.Parse(this.listbox_vaccination_addnewregistration.Items[i].ToString()).ToString("yyyy-MM-dd");
                                    string description_id = "";
                                    string food_id = "";
                                    string foodstobeavoided = this.listbox_foodtobeavoided_addnewregistration.Items[i].ToString();
                                    string allergies = this.listbox_allergies_addnewregistration.Items[i].ToString();
                                    string specialtreatment = this.listbox_specialtreatment_addnewregistration.Items[i].ToString();

                                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`cat names` WHERE `Cat Name` = '" + this.listbox_catnames_addnewregistration.Items[i].ToString() + "' ;", MyGlobalClass.new_connection);
                                    MyGlobalClass.new_connection.Open();
                                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                    records = 0;
                                    while (MyGlobalClass.SQL_Alter_Database.Read())
                                    {
                                        records++;
                                        cat_name_id = MyGlobalClass.SQL_Alter_Database["Cat Name ID"].ToString();
                                    }
                                    MyGlobalClass.new_connection.Close();
                                    if (records > 1)
                                    {
                                        MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                    else if (records == 0)
                                    {
                                        MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`cat names` (`Cat Name`) VALUES ('" + this.listbox_catnames_addnewregistration.Items[i].ToString() + "');  SELECT * FROM `chichester_cattery_booking_system`.`cat names` WHERE `Cat Name ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                                        MyGlobalClass.new_connection.Open();
                                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                        while (MyGlobalClass.SQL_Alter_Database.Read())
                                        {
                                            cat_name_id = MyGlobalClass.SQL_Alter_Database["Cat Name ID"].ToString();
                                        }
                                        MyGlobalClass.new_connection.Close();
                                    }

                                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`sexes` WHERE `Sex` = '" + this.listbox_sex_addnewregistration.Items[i].ToString() + "' ;", MyGlobalClass.new_connection);
                                    MyGlobalClass.new_connection.Open();
                                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                    records = 0;
                                    while (MyGlobalClass.SQL_Alter_Database.Read())
                                    {
                                        records++;
                                        sex_id = MyGlobalClass.SQL_Alter_Database["Sex ID"].ToString();
                                    }
                                    MyGlobalClass.new_connection.Close();
                                    if (records > 1)
                                    {
                                        MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                    else if (records == 0)
                                    {
                                        MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`sexes` (`Sex`) VALUES ('" + this.listbox_sex_addnewregistration.Items[i].ToString() + "'); SELECT * FROM `chichester_cattery_booking_system`.`sexes` WHERE `Sex ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                                        MyGlobalClass.new_connection.Open();
                                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                        while (MyGlobalClass.SQL_Alter_Database.Read())
                                        {
                                            sex_id = MyGlobalClass.SQL_Alter_Database["Sex ID"].ToString();
                                        }
                                        MyGlobalClass.new_connection.Close();
                                    }

                                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`descriptions` WHERE `Description` = '" + this.listbox_description_addnewregistration.Items[i].ToString() + "' ;", MyGlobalClass.new_connection);
                                    MyGlobalClass.new_connection.Open();
                                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                    records = 0;
                                    while (MyGlobalClass.SQL_Alter_Database.Read())
                                    {
                                        records++;
                                        description_id = MyGlobalClass.SQL_Alter_Database["Description ID"].ToString();
                                    }
                                    MyGlobalClass.new_connection.Close();
                                    if (records > 1)
                                    {
                                        MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                    else if (records == 0)
                                    {
                                        MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`descriptions` (`Description`) VALUES ('" + this.listbox_description_addnewregistration.Items[i].ToString() + "'); SELECT * FROM `chichester_cattery_booking_system`.`descriptions` WHERE `Description ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                                        MyGlobalClass.new_connection.Open();
                                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                        while (MyGlobalClass.SQL_Alter_Database.Read())
                                        {
                                            description_id = MyGlobalClass.SQL_Alter_Database["Description ID"].ToString();
                                        }
                                        MyGlobalClass.new_connection.Close();
                                    }

                                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`foods` WHERE `Food` = '" + this.listbox_diet_addnewregistration.Items[i].ToString() + "' ;", MyGlobalClass.new_connection);
                                    MyGlobalClass.new_connection.Open();
                                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                    records = 0;
                                    while (MyGlobalClass.SQL_Alter_Database.Read())
                                    {
                                        records++;
                                        food_id = MyGlobalClass.SQL_Alter_Database["Food ID"].ToString();
                                    }
                                    MyGlobalClass.new_connection.Close();
                                    if (records > 1)
                                    {
                                        MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                    else if (records == 0)
                                    {
                                        MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`foods` (`Food`) VALUES ('" + this.listbox_diet_addnewregistration.Items[i].ToString() + "'); SELECT * FROM `chichester_cattery_booking_system`.`foods` WHERE `Food ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                                        MyGlobalClass.new_connection.Open();
                                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                        while (MyGlobalClass.SQL_Alter_Database.Read())
                                        {
                                            food_id = MyGlobalClass.SQL_Alter_Database["Food ID"].ToString();
                                        }
                                        MyGlobalClass.new_connection.Close();
                                    }

                                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`cats` WHERE `Cat Name ID` = '" + cat_name_id + "'AND `Date Of Birth` = '" + cat_dob + "' AND `Sex ID` = '" + sex_id + "' AND `Next Vaccination Date` = '" + cat_vaccinationdate + "' AND `Description ID` = '" + description_id + "' AND `Food ID` = '" + food_id + "' AND `Foods To Be Avoided` = '" + foodstobeavoided + "' AND `Allergies` = '" + allergies + "' AND `Special Treatment` = '" + specialtreatment + "';", MyGlobalClass.new_connection);
                                    MyGlobalClass.new_connection.Open();
                                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                    records = 0;
                                    while (MyGlobalClass.SQL_Alter_Database.Read())
                                    {
                                        records++;
                                        cat_id = MyGlobalClass.SQL_Alter_Database["Cat ID"].ToString();
                                    }
                                    MyGlobalClass.new_connection.Close();
                                    if (records > 1)
                                    {
                                        MessageBox.Show("Error! Contact your Systems Analyst", "SQL Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                    else if (records == 0)
                                    {
                                        MyGlobalClass.SQL_Command = new MySqlCommand("INSERT INTO `chichester_cattery_booking_system`.`cats` (`Cat Name ID`,`Date Of Birth`,`Sex ID`,`Next Vaccination Date`,`Description ID`,`Food ID`,`Foods To Be Avoided`,`Allergies`,`Special Treatment`) VALUES ('" + cat_name_id + "','" + cat_dob + "','" + sex_id + "','" + cat_vaccinationdate + "','" + description_id + "','" + food_id + "','" + foodstobeavoided + "','" + allergies + "','" + specialtreatment + "'); SELECT * FROM `chichester_cattery_booking_system`.`cats` WHERE `Cat ID` = LAST_INSERT_ID();", MyGlobalClass.new_connection);
                                        MyGlobalClass.new_connection.Open();
                                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                        while (MyGlobalClass.SQL_Alter_Database.Read())
                                        {
                                            cat_id = MyGlobalClass.SQL_Alter_Database["Cat ID"].ToString();
                                        }
                                        MyGlobalClass.new_connection.Close();

                                        MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`registrations` SET `Cat " + (i + 1) + " ID`='" + cat_id + "' WHERE `Registration ID`='" + MyGlobalClass.registration_addnewregistration + "';", MyGlobalClass.new_connection);
                                        MyGlobalClass.new_connection.Open();
                                        MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                        MyGlobalClass.new_connection.Close();
                                    }
                                }
                            }
                            else if (MyGlobalClass.selectedregistrationcats[1, (2 * i) + 1] == null)
                            {
                                MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`registrations` SET `Cat " + (i + 1) + " ID`= NULL WHERE `Registration ID`='" + MyGlobalClass.registration_addnewregistration + "';", MyGlobalClass.new_connection);
                                MyGlobalClass.new_connection.Open();
                                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                                MyGlobalClass.new_connection.Close();
                            }
                        }
                        else if (MyGlobalClass.selectedregistrationcats[1, (2 * i) + 1] != null)
                        {
                            MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`registrations` SET `Cat " + (i + 1) + " ID`= NULL WHERE `Registration ID`='" + MyGlobalClass.registration_addnewregistration + "';", MyGlobalClass.new_connection);
                            MyGlobalClass.new_connection.Open();
                            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                            MyGlobalClass.new_connection.Close();
                        }
                    #endregion
                    }
                    MyGlobalClass.registration_booking = "";
                    MyGlobalClass.registration_registrationsystem = MyGlobalClass.registration_addnewregistration; //Sets the registration variable for the Registration System for selection
                    MyGlobalClass.registration_addnewregistration = ""; //Clears the registration variable for the Add New Registration System as no longer editing
                    MyGlobalClass.removeredundantregistrationvalues();
                    #endregion
                }
                try
                {
                    var previous_form = MyGlobalClass.previous_form_addnewregistration;
                    if (MyGlobalClass.previous_form_addnewregistration.Name == "form_addnewbooking") //Checks whether the previous form was the 'Add New Booking' form
                    {
                        MyGlobalClass.registration_booking = MyGlobalClass.registration_registrationsystem; //Sets the registration for the New Booking
                        MyGlobalClass.registration_registrationsystem = ""; //Clears the registration variable for the Registration System as no need to select the registration
                    }
                    try
                    {
                        MyGlobalClass.navigation = true;
                        MyGlobalClass.maintainselected[1] = true; //Stops the Registrations list box from de-selecting
                        MyGlobalClass.CloseForm(previous_form, this);
                        MyGlobalClass.navigation = false;
                    }
                    catch
                    {
                    }
                }
                catch
                {
                    MyGlobalClass.GoBack(this); //If the code fails, just revert to the 'GoBack' method
                }
            }
        }

        private void listbox_catnames_addnewregistration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbox_catnames_addnewregistration.Items.Count == listbox_dob_addnewregistration.Items.Count) //This check, on all listbox selected index changed methods, stops
            { //the selected index from changing before an item is removed
                listbox_dob_addnewregistration.SelectedIndex = listbox_catnames_addnewregistration.SelectedIndex; //Sets the selected index of the next (dob) listbox to the same
                //as the first (cat name) listbox
            }
            if (listbox_catnames_addnewregistration.SelectedItems.Count > 0)
            {
                button_editcat_addnewregistration.Enabled = true;
                button_deletecat_addnewregistration.Enabled = true; //Enable Edit and Delete buttons if selected item
            }
            else
            {
                button_deletecat_addnewregistration.Enabled = false;
                button_editcat_addnewregistration.Enabled = false; //Disable Edit and Delete buttons if no selected item
            }

        }

        private void listbox_dob_addnewregistration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbox_dob_addnewregistration.Items.Count == listbox_sex_addnewregistration.Items.Count)
            {
                listbox_sex_addnewregistration.SelectedIndex = listbox_dob_addnewregistration.SelectedIndex; //Sex listbox to the same selected index
            }
        }

        private void listbox_sex_addnewregistration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbox_sex_addnewregistration.Items.Count == listbox_vaccination_addnewregistration.Items.Count)
            {
                listbox_vaccination_addnewregistration.SelectedIndex = listbox_sex_addnewregistration.SelectedIndex;
            }
        }

        private void listbox_vaccination_addnewregistration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbox_vaccination_addnewregistration.Items.Count == listbox_description_addnewregistration.Items.Count)
            {
                listbox_description_addnewregistration.SelectedIndex = listbox_vaccination_addnewregistration.SelectedIndex;
            }
        }

        private void listbox_description_addnewregistration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbox_description_addnewregistration.Items.Count == listbox_diet_addnewregistration.Items.Count)
            {
                listbox_diet_addnewregistration.SelectedIndex = listbox_description_addnewregistration.SelectedIndex;
            }
        }

        private void listbox_diet_addnewregistration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbox_diet_addnewregistration.Items.Count == listbox_specialtreatment_addnewregistration.Items.Count)
            {
                listbox_specialtreatment_addnewregistration.SelectedIndex = listbox_diet_addnewregistration.SelectedIndex;
            }
        }

        private void listbox_specialtreatment_addnewregistration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbox_specialtreatment_addnewregistration.Items.Count == listbox_allergies_addnewregistration.Items.Count)
            {
                listbox_allergies_addnewregistration.SelectedIndex = listbox_specialtreatment_addnewregistration.SelectedIndex;
            }
        }

        private void listbox_allergies_addnewregistration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbox_allergies_addnewregistration.Items.Count == listbox_foodtobeavoided_addnewregistration.Items.Count)
            {
                listbox_foodtobeavoided_addnewregistration.SelectedIndex = listbox_allergies_addnewregistration.SelectedIndex;
            }
        }

        private void listbox_foodtobeavoided_addnewregistration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbox_catnames_addnewregistration.Items.Count == listbox_dob_addnewregistration.Items.Count)
            {
                listbox_catnames_addnewregistration.SelectedIndex = listbox_foodtobeavoided_addnewregistration.SelectedIndex;
            }
        }

        private void form_addnewregistration_Activated(object sender, EventArgs e)
        {
            if (MyGlobalClass.updateaddnewregistration == true)
            {
                if (MyGlobalClass.registration_addnewregistration != CurrentRegistration)
                {
                    this.Activated -= form_addnewregistration_Activated;
                    if (CurrentRegistration == "")
                    {
                        if (MessageBox.Show("Would you like to continue adding a Registration?", "Add New Registration?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            MyGlobalClass.registration_addnewregistration = CurrentRegistration;
                        }
                        else
                        {
                            CurrentRegistration = MyGlobalClass.registration_addnewregistration;
                            button_cancelnewregistration_addnewregistration.Text = "Cancel Registration Edit";
                            button_confirmregistration_addnewregistration.Text = "Confirm Registration Edit";

                            foreach (Control Ctrl in panel_catlistboxes_addnewregistration.Controls)
                            {
                                if (Ctrl is ListBox)
                                {
                                    ListBox listbox = (ListBox)Ctrl;
                                    listbox.Items.Clear();
                                }
                            }
                            listbox_owners_addnewregistration.Items.Clear();
                            listbox_owners_addnewregistration.Enabled = false;
                            listbox_moblies_addnewregistration.Items.Clear();
                            listbox_moblies_addnewregistration.Enabled = false;
                            text_addowner_addnewregistration.Clear();
                            text_address_addnewregistration.Clear();
                            text_address_addnewregistration.Enabled = false;
                            text_town_addnewregistration.Clear();
                            text_town_addnewregistration.Enabled = false;
                            text_postcode_addnewregistration.Clear();
                            text_postcode_addnewregistration.Enabled = false;
                            text_homenumber_addnewregistration.Clear();
                            text_homenumber_addnewregistration.Enabled = false;
                            text_addmobile_addnewregistration.Clear();
                            text_addmobile_addnewregistration.Enabled = false;
                            text_addcatname_addnewregistration.Clear();
                            text_addcatname_addnewregistration.Enabled = false;
                            text_addcatdescription_addnewregistration.Clear();
                            text_addcatdescription_addnewregistration.Enabled = false;
                            text_catdiet_addnewregistration.Clear();
                            text_catdiet_addnewregistration.Enabled = false;
                            text_catspecialtreatment_addnewregistration.Clear();
                            text_catspecialtreatment_addnewregistration.Enabled = false;
                            text_catfoodtoavoid_addnewregistration.Clear();
                            text_catfoodtoavoid_addnewregistration.Enabled = false;
                            text_catallergies_addnewregistration.Clear();
                            text_catallergies_addnewregistration.Enabled = false;
                            panel_catlistboxes_addnewregistration.Enabled = false;
                            text_absencecontact_addnewregistration.Clear();
                            text_absencecontact_addnewregistration.Enabled = false;
                            text_absencenumber_addnewregistration.Clear();
                            text_absencenumber_addnewregistration.Enabled = false;
                            text_vetname_addnewregistration.Clear();
                            text_vetname_addnewregistration.Enabled = false;
                            text_vetnumber_addnewregistration.Clear();
                            text_vetnumber_addnewregistration.Enabled = false;
                            datetimepicker_dob_addnewregistration.Value = DateTime.Today;
                            datetimepicker_dob_addnewregistration.Enabled = false;
                            datetimepicker_vaccinationduedate_addnewregistration.Value = DateTime.Today;
                            datetimepicker_vaccinationduedate_addnewregistration.Enabled = false;
                            combobox_catsex_addnewregistration.Enabled = false;
                            combobox_catsex_addnewregistration.SelectedIndex = -1;
                            combobox_catsex_addnewregistration.Text = "";
                            button_confirmregistration_addnewregistration.Enabled = false;

                            for (int arraypointer = 0; arraypointer < 6; arraypointer++)
                            {
                                if (MyGlobalClass.selectedregistration[arraypointer, 0] != null)
                                {
                                    listbox_owners_addnewregistration.Items.Add(MyGlobalClass.selectedregistration[arraypointer, 0]);
                                }
                            }

                            text_address_addnewregistration.Text = MyGlobalClass.selectedregistration[6, 0];
                            text_town_addnewregistration.Text = MyGlobalClass.selectedregistration[7, 0];
                            text_postcode_addnewregistration.Text = MyGlobalClass.selectedregistration[8, 0];
                            text_homenumber_addnewregistration.Text = MyGlobalClass.selectedregistration[9, 0]; //Adding all information to the respective controls

                            for (int arraypointer = 10; arraypointer < 16; arraypointer++)
                            {
                                if (MyGlobalClass.selectedregistration[arraypointer, 0] != null)
                                {
                                    listbox_moblies_addnewregistration.Items.Add(MyGlobalClass.selectedregistration[arraypointer, 0]);
                                }
                            }

                            text_absencecontact_addnewregistration.Text = MyGlobalClass.selectedregistration[16, 0];
                            text_absencenumber_addnewregistration.Text = MyGlobalClass.selectedregistration[17, 0];
                            text_vetname_addnewregistration.Text = MyGlobalClass.selectedregistration[18, 0];
                            text_vetnumber_addnewregistration.Text = MyGlobalClass.selectedregistration[19, 0];

                            for (int catpointer = 0; catpointer < 11; catpointer = catpointer + 2)
                            {
                                if (MyGlobalClass.selectedregistrationcats[1, (catpointer + 1)] != null)
                                {
                                    cats[(catpointer / 2), 0] = MyGlobalClass.selectedregistrationcats[0, catpointer];
                                    cats[(catpointer / 2), 1] = MyGlobalClass.selectedregistrationcats[1, catpointer];
                                    cats[(catpointer / 2), 2] = MyGlobalClass.selectedregistrationcats[2, catpointer];
                                    cats[(catpointer / 2), 3] = MyGlobalClass.selectedregistrationcats[3, catpointer];
                                    cats[(catpointer / 2), 4] = MyGlobalClass.selectedregistrationcats[4, catpointer];
                                    cats[(catpointer / 2), 5] = MyGlobalClass.selectedregistrationcats[5, catpointer];
                                    cats[(catpointer / 2), 6] = MyGlobalClass.selectedregistrationcats[6, catpointer];
                                    cats[(catpointer / 2), 7] = MyGlobalClass.selectedregistrationcats[7, catpointer];
                                    cats[(catpointer / 2), 8] = MyGlobalClass.selectedregistrationcats[8, catpointer];
                                }
                            }

                            for (int catpointer = 0; catpointer < 6; catpointer++)
                            {
                                if (cats[catpointer, 0] != null)
                                {
                                    listbox_catnames_addnewregistration.Items.Add(cats[catpointer, 0]);
                                    listbox_dob_addnewregistration.Items.Add(cats[catpointer, 1]);
                                    listbox_sex_addnewregistration.Items.Add(cats[catpointer, 2]);
                                    listbox_vaccination_addnewregistration.Items.Add(cats[catpointer, 3]);
                                    listbox_description_addnewregistration.Items.Add(cats[catpointer, 4]);
                                    listbox_diet_addnewregistration.Items.Add(cats[catpointer, 5]);
                                    listbox_foodtobeavoided_addnewregistration.Items.Add(cats[catpointer, 6]);
                                    listbox_allergies_addnewregistration.Items.Add(cats[catpointer, 7]);
                                    listbox_specialtreatment_addnewregistration.Items.Add(cats[catpointer, 8]);
                                }
                            }

                            foreach (Control Ctrl in panel_catlistboxes_addnewregistration.Controls)
                            {
                                try
                                {
                                    ListBox listbox = (ListBox)Ctrl;
                                    listbox.Height = (listbox.Items.Count * listbox.ItemHeight) + 4;
                                }
                                catch
                                {
                                }
                            }
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Do you wish to continue editing the Registration?", "Continue Editing?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            MyGlobalClass.registration_addnewregistration = CurrentRegistration;
                        }
                        else
                        {
                            CurrentRegistration = MyGlobalClass.registration_addnewregistration;

                            foreach (Control Ctrl in panel_catlistboxes_addnewregistration.Controls)
                            {
                                if (Ctrl is ListBox)
                                {
                                    ListBox listbox = (ListBox)Ctrl;
                                    listbox.Items.Clear();
                                }
                            }
                            listbox_owners_addnewregistration.Items.Clear();
                            listbox_owners_addnewregistration.Enabled = false;
                            listbox_moblies_addnewregistration.Items.Clear();
                            listbox_moblies_addnewregistration.Enabled = false;
                            text_addowner_addnewregistration.Clear();
                            text_address_addnewregistration.Clear();
                            text_address_addnewregistration.Enabled = false;
                            text_town_addnewregistration.Clear();
                            text_town_addnewregistration.Enabled = false;
                            text_postcode_addnewregistration.Clear();
                            text_postcode_addnewregistration.Enabled = false;
                            text_homenumber_addnewregistration.Clear();
                            text_homenumber_addnewregistration.Enabled = false;
                            text_addmobile_addnewregistration.Clear();
                            text_addmobile_addnewregistration.Enabled = false;
                            text_addcatname_addnewregistration.Clear();
                            text_addcatname_addnewregistration.Enabled = false;
                            text_addcatdescription_addnewregistration.Clear();
                            text_addcatdescription_addnewregistration.Enabled = false;
                            text_catdiet_addnewregistration.Clear();
                            text_catdiet_addnewregistration.Enabled = false;
                            text_catspecialtreatment_addnewregistration.Clear();
                            text_catspecialtreatment_addnewregistration.Enabled = false;
                            text_catfoodtoavoid_addnewregistration.Clear();
                            text_catfoodtoavoid_addnewregistration.Enabled = false;
                            text_catallergies_addnewregistration.Clear();
                            text_catallergies_addnewregistration.Enabled = false;
                            panel_catlistboxes_addnewregistration.Enabled = false;
                            text_absencecontact_addnewregistration.Clear();
                            text_absencecontact_addnewregistration.Enabled = false;
                            text_absencenumber_addnewregistration.Clear();
                            text_absencenumber_addnewregistration.Enabled = false;
                            text_vetname_addnewregistration.Clear();
                            text_vetname_addnewregistration.Enabled = false;
                            text_vetnumber_addnewregistration.Clear();
                            text_vetnumber_addnewregistration.Enabled = false;
                            datetimepicker_dob_addnewregistration.Value = DateTime.Today;
                            datetimepicker_dob_addnewregistration.Enabled = false;
                            datetimepicker_vaccinationduedate_addnewregistration.Value = DateTime.Today;
                            datetimepicker_vaccinationduedate_addnewregistration.Enabled = false;
                            combobox_catsex_addnewregistration.Enabled = false;
                            combobox_catsex_addnewregistration.SelectedIndex = -1;
                            combobox_catsex_addnewregistration.Text = "";
                            button_confirmregistration_addnewregistration.Enabled = false;

                            if (MyGlobalClass.registration_addnewregistration != "")
                            {

                                button_cancelnewregistration_addnewregistration.Text = "Cancel Registration Edit";
                                button_confirmregistration_addnewregistration.Text = "Confirm Registration Edit";

                                for (int arraypointer = 0; arraypointer < 6; arraypointer++)
                                {
                                    if (MyGlobalClass.selectedregistration[arraypointer, 0] != null)
                                    {
                                        listbox_owners_addnewregistration.Items.Add(MyGlobalClass.selectedregistration[arraypointer, 0]);
                                    }
                                }

                                text_address_addnewregistration.Text = MyGlobalClass.selectedregistration[6, 0];
                                text_town_addnewregistration.Text = MyGlobalClass.selectedregistration[7, 0];
                                text_postcode_addnewregistration.Text = MyGlobalClass.selectedregistration[8, 0];
                                text_homenumber_addnewregistration.Text = MyGlobalClass.selectedregistration[9, 0]; //Adding all information to the respective controls

                                for (int arraypointer = 10; arraypointer < 16; arraypointer++)
                                {
                                    if (MyGlobalClass.selectedregistration[arraypointer, 0] != null)
                                    {
                                        listbox_moblies_addnewregistration.Items.Add(MyGlobalClass.selectedregistration[arraypointer, 0]);
                                    }
                                }

                                text_absencecontact_addnewregistration.Text = MyGlobalClass.selectedregistration[16, 0];
                                text_absencenumber_addnewregistration.Text = MyGlobalClass.selectedregistration[17, 0];
                                text_vetname_addnewregistration.Text = MyGlobalClass.selectedregistration[18, 0];
                                text_vetnumber_addnewregistration.Text = MyGlobalClass.selectedregistration[19, 0];

                                for (int catpointer = 0; catpointer < 11; catpointer = catpointer + 2)
                                {
                                    if (MyGlobalClass.selectedregistrationcats[1, (catpointer + 1)] != null)
                                    {
                                        cats[(catpointer / 2), 0] = MyGlobalClass.selectedregistrationcats[0, catpointer];
                                        cats[(catpointer / 2), 1] = MyGlobalClass.selectedregistrationcats[1, catpointer];
                                        cats[(catpointer / 2), 2] = MyGlobalClass.selectedregistrationcats[2, catpointer];
                                        cats[(catpointer / 2), 3] = MyGlobalClass.selectedregistrationcats[3, catpointer];
                                        cats[(catpointer / 2), 4] = MyGlobalClass.selectedregistrationcats[4, catpointer];
                                        cats[(catpointer / 2), 5] = MyGlobalClass.selectedregistrationcats[5, catpointer];
                                        cats[(catpointer / 2), 6] = MyGlobalClass.selectedregistrationcats[6, catpointer];
                                        cats[(catpointer / 2), 7] = MyGlobalClass.selectedregistrationcats[7, catpointer];
                                        cats[(catpointer / 2), 8] = MyGlobalClass.selectedregistrationcats[8, catpointer];
                                    }
                                }

                                for (int catpointer = 0; catpointer < 6; catpointer++)
                                {
                                    if (cats[catpointer, 0] != null)
                                    {
                                        listbox_catnames_addnewregistration.Items.Add(cats[catpointer, 0]);
                                        listbox_dob_addnewregistration.Items.Add(cats[catpointer, 1]);
                                        listbox_sex_addnewregistration.Items.Add(cats[catpointer, 2]);
                                        listbox_vaccination_addnewregistration.Items.Add(cats[catpointer, 3]);
                                        listbox_description_addnewregistration.Items.Add(cats[catpointer, 4]);
                                        listbox_diet_addnewregistration.Items.Add(cats[catpointer, 5]);
                                        listbox_foodtobeavoided_addnewregistration.Items.Add(cats[catpointer, 6]);
                                        listbox_allergies_addnewregistration.Items.Add(cats[catpointer, 7]);
                                        listbox_specialtreatment_addnewregistration.Items.Add(cats[catpointer, 8]);
                                    }
                                }

                                foreach (Control Ctrl in panel_catlistboxes_addnewregistration.Controls)
                                {
                                    try
                                    {
                                        ListBox listbox = (ListBox)Ctrl;
                                        listbox.Height = (listbox.Items.Count * listbox.ItemHeight) + 4;
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                            else
                            {
                                button_cancelnewregistration_addnewregistration.Text = "Cancel New Registration";
                                button_confirmregistration_addnewregistration.Text = "Confirm New Registration";
                            }
                        }
                    }

                    if (listbox_owners_addnewregistration.Items.Count >= 1)
                    {//Check if enough owners
                        listbox_owners_addnewregistration.Enabled = true;
                        text_address_addnewregistration.Enabled = true;
                        text_town_addnewregistration.Enabled = true;
                        text_postcode_addnewregistration.Enabled = true;
                        text_homenumber_addnewregistration.Enabled = true;
                        text_addmobile_addnewregistration.Enabled = true;
                        if (listbox_moblies_addnewregistration.Items.Count > 0)
                        {//Enables the mobile listbox if there are items. The cat name textbox is enabled when text is added to the addess textboxes using the old data
                            listbox_moblies_addnewregistration.Enabled = true;
                        }
                        if (listbox_catnames_addnewregistration.Items.Count > 0)
                        { //Given that there is text in the contact textboxes, check if there are items in the cat listboxes
                            listbox_catnames_addnewregistration.Enabled = true;
                            datetimepicker_dob_addnewregistration.Enabled = true;
                            combobox_catsex_addnewregistration.Enabled = true;
                            datetimepicker_vaccinationduedate_addnewregistration.Enabled = true;
                            text_addcatdescription_addnewregistration.Enabled = true;
                            text_catdiet_addnewregistration.Enabled = true;
                            text_catspecialtreatment_addnewregistration.Enabled = true;
                            text_catfoodtoavoid_addnewregistration.Enabled = true;
                            text_catallergies_addnewregistration.Enabled = true;
                            text_absencecontact_addnewregistration.Enabled = true;
                            text_absencenumber_addnewregistration.Enabled = true;
                            text_vetname_addnewregistration.Enabled = true;
                            text_vetnumber_addnewregistration.Enabled = true;
                            button_confirmregistration_addnewregistration.Enabled = true;
                            panel_catlistboxes_addnewregistration.Enabled = true;
                        }
                    }

                    this.Activated += form_addnewregistration_Activated;
                }
            }
        }

        private void text_bookingquery_addnewregistration_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_searchbookings_addnewregistration_Click(sender, new EventArgs());
            }
        }

        private void CatAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && button_addcat_addnewregistration.Enabled == true)
            {
                button_addcat_addnewregistration_Click(sender, new EventArgs());
            }
        }

        private void text_addowner_addnewregistration_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && button_addowner_addnewregistration.Enabled == true)
            {
                button_addowner_addnewregistration_Click(sender, new EventArgs());
            }
        }

        private void text_addmobile_addnewregistration_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && button_addmobile_addnewregistration.Enabled == true)
            {
                button_addmobile_addnewregistration_Click(sender, new EventArgs());
            }
        }

        private void RegistrationAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_confirmregistration_addnewregistration_Click(sender, new EventArgs());
            }
        }

        private void text_bookingquery_addnewregistration_Enter(object sender, EventArgs e)
        {
            button_searchbookings_addnewregistration.Font = new Font(Font.FontFamily, button_searchbookings_addnewregistration.Font.Size, FontStyle.Bold);
        }

        private void text_bookingquery_addnewregistration_Leave(object sender, EventArgs e)
        {
            button_searchbookings_addnewregistration.Font = new Font(Font.FontFamily, button_searchbookings_addnewregistration.Font.Size, FontStyle.Regular);
        }

        private void text_addowner_addnewregistration_Enter(object sender, EventArgs e)
        {
            button_addowner_addnewregistration.Font = new Font(Font.FontFamily, button_addowner_addnewregistration.Font.Size, FontStyle.Bold);
        }

        private void text_addowner_addnewregistration_Leave(object sender, EventArgs e)
        {
            button_addowner_addnewregistration.Font = new Font(Font.FontFamily, button_addowner_addnewregistration.Font.Size, FontStyle.Regular);
        }

        private void text_addmobile_addnewregistration_Enter(object sender, EventArgs e)
        {
            button_addmobile_addnewregistration.Font = new Font(Font.FontFamily, button_addmobile_addnewregistration.Font.Size, FontStyle.Bold);
        }

        private void text_addmobile_addnewregistration_Leave(object sender, EventArgs e)
        {
            button_addmobile_addnewregistration.Font = new Font(Font.FontFamily, button_addmobile_addnewregistration.Font.Size, FontStyle.Regular);
        }

        private void CatAdd_Enter(object sender, EventArgs e)
        {
            if (button_addcat_addnewregistration.Enabled == true)
            {
                button_addcat_addnewregistration.Font = new Font(Font.FontFamily, button_addcat_addnewregistration.Font.Size, FontStyle.Bold);
            }
        }

        private void CatAdd_Leave(object sender, EventArgs e)
        {
            button_addcat_addnewregistration.Font = new Font(Font.FontFamily, button_addcat_addnewregistration.Font.Size, FontStyle.Regular);
        }

        private void RegistrationAdd_Enter(object sender, EventArgs e)
        {
            button_confirmregistration_addnewregistration.Font = new Font(Font.FontFamily, button_confirmregistration_addnewregistration.Font.Size, FontStyle.Bold);
        }

        private void RegistrationAdd_Leave(object sender, EventArgs e)
        {
            button_confirmregistration_addnewregistration.Font = new Font(Font.FontFamily, button_confirmregistration_addnewregistration.Font.Size, FontStyle.Regular);
        }
    }
}
