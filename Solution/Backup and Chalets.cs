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
using System.Security.Permissions;

namespace Solution
{
    public partial class form_backupandchalets : Form
    {
        string[,] Chalets;
        string[] ListBoxSelectedChalets = new string[0];
        int[] ListBoxScrollPositions = new int[3];
        int[] ListBoxSelectedItemsCounts = new int[3];

        public form_backupandchalets()
        {
            InitializeComponent();

            this.SuspendLayout();

            if (MyGlobalClass.ResolutionHeightScale == -1 || MyGlobalClass.ResolutionWidthScale == -1)
            {
                Form ComparisonForm = null;
                try
                {
                    ComparisonForm = new form_initialscreen();
                    ComparisonForm.Close();
                }
                catch
                {

                }
            }

            this.Width = (int)(this.Width * MyGlobalClass.ResolutionWidthScale);
            this.Height = (int)(this.Height * MyGlobalClass.ResolutionHeightScale);

            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_numberofchalets)).BeginInit();
            MyGlobalClass.ScaleParent(MyGlobalClass.ResolutionHeightScale, MyGlobalClass.ResolutionWidthScale, this);
            numericUpDown_numberofchalets.Font = label_addingremovingchalets.Font;
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_numberofchalets)).EndInit();

            this.ResumeLayout();
            this.PerformLayout();
        }

        private void backup(ProgressBar progressbar)
        {
            #region database
            string[] Database = 
            {
"CREATE SCHEMA `Chichester_Cattery_Booking_System`;",
"CREATE TABLE `Chichester_Cattery_Booking_System`.`Contact Names` (",
"`Contact Name ID` INT(11) AUTO_INCREMENT,",
"`Contact Name` VARCHAR(45) NULL,",
"PRIMARY KEY (`Contact Name ID`),",
"INDEX `Contact Name` (`Contact Name` ASC),",
"UNIQUE INDEX `Contact Name ID UNIQUE` (`Contact Name ID` ASC));",
"CREATE TABLE `Chichester_Cattery_Booking_System`.`Contact Telephones`(",
"`Contact Telephone ID` INT(11) AUTO_INCREMENT,",
"`Contact Telephone` VARCHAR(45) NULL,",
"PRIMARY KEY (`Contact Telephone ID`),",
"INDEX `Contact Telephone` (`Contact Telephone` ASC),",
"UNIQUE INDEX `Contact Telephone ID UNIQUE` (`Contact Telephone ID` ASC));",
"CREATE TABLE `Chichester_Cattery_Booking_System`.`Cat Names` (",
"`Cat Name ID` INT(11) AUTO_INCREMENT,",
"`Cat Name` VARCHAR(45) NULL,",
"PRIMARY KEY (`Cat Name ID`),",
"INDEX `Cat Name` (`Cat Name` ASC),",
"UNIQUE INDEX `Cat Name ID UNIQUE` (`Cat Name ID` ASC));",
"CREATE TABLE `Chichester_Cattery_Booking_System`.`Sexes` (",
"`Sex ID` INT(11) AUTO_INCREMENT,",
"`Sex` VARCHAR(10) NULL,",
"PRIMARY KEY (`Sex ID`),",
"INDEX `Sex` (`Sex` ASC),",
"UNIQUE INDEX `Sex ID UNIQUE` (`Sex ID` ASC));",
"CREATE TABLE `Chichester_Cattery_Booking_System`.`Descriptions` (",
"`Description ID` INT(11) AUTO_INCREMENT,",
"`Description` VARCHAR(45) NULL,",
"PRIMARY KEY (`Description ID`),",
"INDEX `Description` (`Description` ASC),",
"UNIQUE INDEX `Description ID UNIQUE` (`Description ID` ASC));",
"CREATE TABLE `Chichester_Cattery_Booking_System`.`Foods` (",
"`Food ID` INT(11) AUTO_INCREMENT,",
"`Food` VARCHAR(45) NULL,",
"PRIMARY KEY (`Food ID`),",
"INDEX `Food` (`Food` ASC),",
"UNIQUE INDEX `Food ID UNIQUE` (`Food ID` ASC));",
"CREATE TABLE `Chichester_Cattery_Booking_System`.`Cats`(",
"`Cat ID` INT(11) AUTO_INCREMENT,",
"`Cat Name ID` INT(11),",
"`Date Of Birth` DATE,",
"`Sex ID` INT(11),",
"`Next Vaccination Date` DATE,",
"`Description ID` INT(11),",
"`Food ID` INT(11),",
"`Foods To Be Avoided` VARCHAR(100) NULL,",
"`Allergies` VARCHAR(100) NULL,",
"`Special Treatment` VARCHAR(100) NULL,",
"PRIMARY KEY (`Cat ID`),",
"CONSTRAINT `Cat Name` FOREIGN KEY (`Cat Name ID`)",
"REFERENCES `Chichester_Cattery_Booking_System`.`Cat Names` (`Cat Name ID`),",
"CONSTRAINT `Sex` FOREIGN KEY (`Sex ID`)",
"REFERENCES `Chichester_Cattery_Booking_System`.`Sexes` (`Sex ID`),",
"CONSTRAINT `Description` FOREIGN KEY (`Description ID`)",
"REFERENCES `Chichester_Cattery_Booking_System`.`Descriptions` (`Description ID`),",
"CONSTRAINT `Food` FOREIGN KEY (`Food ID`)",
"REFERENCES `Chichester_Cattery_Booking_System`.`Foods` (`Food ID`),",
"INDEX `Dates` (`Date Of Birth` ASC, `Next Vaccination Date` ASC),",
"INDEX `Special Treatments` (`Foods To Be Avoided` ASC, `Allergies` ASC, `Special Treatment` ASC),",
"INDEX `Other Details` (`Cat Name ID` ASC, `Sex ID` ASC, `Description ID` ASC, `Food ID` ASC),",
"UNIQUE INDEX `Cat ID UNIQUE` (`Cat ID` ASC));",
"CREATE TABLE `Chichester_Cattery_Booking_System`.`Absence Contacts` (",
"`Absence Contact ID` INT(11) AUTO_INCREMENT,",
"`Contact Name ID` INT(11),",
"`Contact Telephone ID` INT(11),",
"PRIMARY KEY (`Absence Contact ID`),",
"CONSTRAINT `Contact Name` FOREIGN KEY (`Contact Name ID`)",
"REFERENCES `Chichester_Cattery_Booking_System`.`Contact Names` (`Contact Name ID`),",
"CONSTRAINT `Contact Telephone` FOREIGN KEY (`Contact Telephone ID`)",
"REFERENCES `Chichester_Cattery_Booking_System`.`Contact Telephones` (`Contact Telephone ID`),",
"INDEX `Absence Contact` (`Contact Name ID` ASC, `Contact Telephone ID` ASC),",
"UNIQUE INDEX `Absence Contact ID UNIQUE` (`Absence Contact ID` ASC));",
"CREATE TABLE `Chichester_Cattery_Booking_System`.`Vets` (",
"`Vet ID` INT(11) AUTO_INCREMENT,",
"`Contact Name ID` INT(11),",
"`Contact Telephone ID` INT(11),",
"PRIMARY KEY (`Vet ID`),",
"CONSTRAINT `Vet Name` FOREIGN KEY (`Contact Name ID`)",
"REFERENCES `Chichester_Cattery_Booking_System`.`Contact Names` (`Contact Name ID`),",
"CONSTRAINT `Vet Telephone` FOREIGN KEY (`Contact Telephone ID`)",
"REFERENCES `Chichester_Cattery_Booking_System`.`Contact Telephones` (`Contact Telephone ID`),",
"INDEX `Vet` (`Contact Name ID` ASC, `Contact Telephone ID` ASC),",
"UNIQUE INDEX `Vet ID UNIQUE` (`Vet ID` ASC));",
"CREATE TABLE `Chichester_Cattery_Booking_System`.`Postcodes`(",
"`Postcode ID` INT(11) AUTO_INCREMENT,",
"`Postcode` VARCHAR(8) NULL,",
"PRIMARY KEY (`Postcode ID`),",
"INDEX `Postcode`(`Postcode` ASC),",
"UNIQUE INDEX `Postcode ID UNIQUE` (`Postcode ID` ASC));",
"CREATE TABLE `Chichester_Cattery_Booking_System`.`Towns`(",
"`Town ID` INT(11) AUTO_INCREMENT,",
"`Town` VARCHAR(100) NULL,",
"PRIMARY KEY (`Town ID`),",
"INDEX `Town`(`Town` ASC),",
"UNIQUE INDEX `Town ID UNIQUE` (`Town ID` ASC));",
"CREATE TABLE `Chichester_Cattery_Booking_System`.`Addresses`(",
"`Address ID` INT(11) AUTO_INCREMENT,",
"`Address` VARCHAR(100) NULL,",
"`Town ID` INT(11),",
"`Postcode ID` INT(11),",
"PRIMARY KEY (`Address ID`),",
"CONSTRAINT `Postcode` FOREIGN KEY (`Postcode ID`)",
"REFERENCES chichester_cattery_booking_system.postcodes (`Postcode ID`),",
"CONSTRAINT `Town` FOREIGN KEY (`Town ID`)",
"REFERENCES chichester_cattery_booking_system.towns (`Town ID`),",
"INDEX `Address` (`Address` ASC, `Town ID` ASC, `Postcode ID` ASC),",
"UNIQUE INDEX `Address ID UNIQUE` (`Address ID` ASC));",
"CREATE TABLE `Chichester_Cattery_Booking_System`.`Registrations`(",
"`Registration ID` INT(11) AUTO_INCREMENT,",
"`Owner 1 ID` INT(11),",
"`Owner 2 ID` INT(11),",
"`Owner 3 ID` INT(11),",
"`Owner 4 ID` INT(11),",
"`Owner 5 ID` INT(11),",
"`Owner 6 ID` INT(11),",
"`Address ID` INT (11),",
"`Home Telephone ID` INT(11),",
"`Mobile 1 ID` INT(11),",
"`Mobile 2 ID` INT(11),",
"`Mobile 3 ID` INT(11),",
"`Mobile 4 ID` INT(11),",
"`Mobile 5 ID` INT(11),",
"`Mobile 6 ID` INT(11),",
"`Cat 1 ID` INT(11),",
"`Cat 2 ID` INT(11),",
"`Cat 3 ID` INT(11),",
"`Cat 4 ID` INT(11),",
"`Cat 5 ID` INT(11),",
"`Cat 6 ID` INT(11),",
"`Absence Contact ID` INT(11),",
"`Vet ID` INT(11),",
"`Extra Information` VARCHAR(200) NULL,",
"PRIMARY KEY (`Registration ID`),",
"CONSTRAINT `Owner 1` FOREIGN KEY (`Owner 1 ID`)",
"REFERENCES `chichester_cattery_booking_system`.`Contact Names` (`Contact Name ID`),",
"CONSTRAINT `Owner 2` FOREIGN KEY (`Owner 2 ID`)",
"REFERENCES `chichester_cattery_booking_system`.`Contact Names` (`Contact Name ID`),",
"CONSTRAINT `Owner 3` FOREIGN KEY (`Owner 3 ID`)",
"REFERENCES `chichester_cattery_booking_system`.`Contact Names` (`Contact Name ID`),",
"CONSTRAINT `Owner 4` FOREIGN KEY (`Owner 4 ID`)",
"REFERENCES `chichester_cattery_booking_system`.`Contact Names` (`Contact Name ID`),",
"CONSTRAINT `Owner 5` FOREIGN KEY (`Owner 5 ID`)",
"REFERENCES `chichester_cattery_booking_system`.`Contact Names` (`Contact Name ID`),",
"CONSTRAINT `Owner 6` FOREIGN KEY (`Owner 6 ID`)",
"REFERENCES `chichester_cattery_booking_system`.`Contact Names` (`Contact Name ID`),",
"CONSTRAINT `Address` FOREIGN KEY (`Address ID`)",
"REFERENCES chichester_cattery_booking_system.addresses (`Address ID`),",
"CONSTRAINT `Home Telephone` FOREIGN KEY (`Home Telephone ID`)",
"REFERENCES `Chichester_Cattery_Booking_System`.`Contact Telephones` (`Contact Telephone ID`),",
"CONSTRAINT `Mobile 1` FOREIGN KEY (`Mobile 1 ID`)",
"REFERENCES `Chichester_Cattery_Booking_System`.`Contact Telephones` (`Contact Telephone ID`),",
"CONSTRAINT `Mobile 2` FOREIGN KEY (`Mobile 2 ID`)",
"REFERENCES `Chichester_Cattery_Booking_System`.`Contact Telephones` (`Contact Telephone ID`),",
"CONSTRAINT `Mobile 3` FOREIGN KEY (`Mobile 3 ID`)",
"REFERENCES `Chichester_Cattery_Booking_System`.`Contact Telephones` (`Contact Telephone ID`),",
"CONSTRAINT `Mobile 4` FOREIGN KEY (`Mobile 4 ID`)",
"REFERENCES `Chichester_Cattery_Booking_System`.`Contact Telephones` (`Contact Telephone ID`),",
"CONSTRAINT `Mobile 5` FOREIGN KEY (`Mobile 5 ID`)",
"REFERENCES `Chichester_Cattery_Booking_System`.`Contact Telephones` (`Contact Telephone ID`),",
"CONSTRAINT `Mobile 6` FOREIGN KEY (`Mobile 6 ID`)",
"REFERENCES `Chichester_Cattery_Booking_System`.`Contact Telephones` (`Contact Telephone ID`),",
"CONSTRAINT `Cat 1` FOREIGN KEY (`Cat 1 ID`)",
"REFERENCES `Chichester_Cattery_Booking_System`.`Cats` (`Cat ID`),",
"CONSTRAINT `Cat 2` FOREIGN KEY (`Cat 2 ID`)",
"REFERENCES `Chichester_Cattery_Booking_System`.`Cats` (`Cat ID`),",
"CONSTRAINT `Cat 3` FOREIGN KEY (`Cat 3 ID`)",
"REFERENCES `Chichester_Cattery_Booking_System`.`Cats` (`Cat ID`),",
"CONSTRAINT `Cat 4` FOREIGN KEY (`Cat 4 ID`)",
"REFERENCES `Chichester_Cattery_Booking_System`.`Cats` (`Cat ID`),",
"CONSTRAINT `Cat 5` FOREIGN KEY (`Cat 5 ID`)",
"REFERENCES `Chichester_Cattery_Booking_System`.`Cats` (`Cat ID`),",
"CONSTRAINT `Cat 6` FOREIGN KEY (`Cat 6 ID`)",
"REFERENCES `Chichester_Cattery_Booking_System`.`Cats` (`Cat ID`),",
"CONSTRAINT `Absence Contact` FOREIGN KEY (`Absence Contact ID`)",
"REFERENCES `Chichester_Cattery_Booking_System`.`Absence Contacts` (`Absence Contact ID`),",
"CONSTRAINT `Vet` FOREIGN KEY (`Vet ID`)",
"REFERENCES `Chichester_Cattery_Booking_System`.`Vets` (`Vet ID`),",
"INDEX `Owners` (`Owner 1 ID` ASC, `Owner 2 ID` ASC, `Owner 3 ID` ASC, `Owner 4 ID` ASC, `Owner 5 ID` ASC, `Owner 6 ID` ASC), -- Indexes Columns",
"INDEX `Contact Information` (`Address ID` ASC,`Home Telephone ID` ASC, `Mobile 1 ID` ASC, `Mobile 2 ID` ASC, `Mobile 3 ID` ASC, `Mobile 4 ID` ASC, `Mobile 5 ID` ASC, `Mobile 6 ID` ASC, `Absence Contact ID` ASC, `Vet ID` ASC),",
"INDEX `Other Registration Information` (`Cat 1 ID` ASC, `Cat 2 ID` ASC, `Cat 3 ID` ASC, `Cat 4 ID` ASC, `Cat 5 ID` ASC, `Cat 6 ID` ASC, `Extra Information` ASC),",
"UNIQUE INDEX `Registration ID UNIQUE` (`Registration ID` ASC));",
"CREATE TABLE `Chichester_Cattery_Booking_System`.`Arrival/Departure Times`(",
"`Arrival/Departure Time ID` INT(11) AUTO_INCREMENT,",
"`Arrival/Departure Time` VARCHAR(45) NULL,",
"PRIMARY KEY (`Arrival/Departure Time ID`),",
"INDEX `Arrival/Departure Time` (`Arrival/Departure Time` ASC),",
"UNIQUE INDEX `Arrival/Departure Time ID UNIQUE` (`Arrival/Departure Time ID` ASC));",
"CREATE TABLE `Chichester_Cattery_Booking_System`.`Bookings`(",
"`Booking ID` INT(11) AUTO_INCREMENT,",
"`Registration ID` INT(11),",
"`Cat 1 Staying` VARCHAR(45) NULL,",
"`Cat 2 Staying` VARCHAR(45) NULL,",
"`Cat 3 Staying` VARCHAR(45) NULL,",
"`Cat 4 Staying` VARCHAR(45) NULL,",
"`Cat 5 Staying` VARCHAR(45) NULL,",
"`Cat 6 Staying` VARCHAR(45) NULL,",
"`Arrival Date` DATE,",
"`Departure Date` DATE,",
"`Arrival Time ID` INT(11),",
"`Departure Time ID` INT(11),",
"`Checked In` BOOL,",
"`Checked Out` BOOL,",
"`Chalet` INT(5),",
"`Cat 1 Vaccination` BOOL,",
"`Cat 2 Vaccination` BOOL,",
"`Cat 3 Vaccination` BOOL,",
"`Cat 4 Vaccination` BOOL,",
"`Cat 5 Vaccination` BOOL,",
"`Cat 6 Vaccination` BOOL,",
"PRIMARY KEY (`Booking ID`),",
"CONSTRAINT `Registration` FOREIGN KEY (`Registration ID`)",
"REFERENCES `chichester_cattery_booking_system`.`Registrations` (`Registration ID`),",
"CONSTRAINT `Arrival Time` FOREIGN KEY (`Arrival Time ID`)",
"REFERENCES `Chichester_Cattery_Booking_System`.`Arrival/Departure Times` (`Arrival/Departure Time ID`),",
"CONSTRAINT `Departure Time` FOREIGN KEY (`Departure Time ID`)",
"REFERENCES `Chichester_Cattery_Booking_System`.`Arrival/Departure Times` (`Arrival/Departure Time ID`),",
"INDEX `Other Details` (`Registration ID` ASC, `Checked In` ASC, `Checked Out` ASC, `Chalet` ASC),",
"INDEX `Cats Staying` (`Cat 1 Staying` ASC, `Cat 2 Staying` ASC, `Cat 3 Staying` ASC, `Cat 4 Staying` ASC,",
"`Cat 5 Staying` ASC, `Cat 6 Staying` ASC),",
"INDEX `Arrival and Departure` (`Arrival Date` ASC, `Departure Date` ASC,",
"`Arrival Time ID` ASC, `Departure Time ID` ASC),",
"INDEX `Vaccinations` (`Cat 1 Vaccination` ASC, `Cat 2 Vaccination` ASC,",
"`Cat 3 Vaccination` ASC, `Cat 4 Vaccination` ASC, `Cat 5 Vaccination` ASC, `Cat 6 Vaccination` ASC),",
"UNIQUE INDEX `Booking ID UNIQUE` (`Booking ID` ASC));",
"CREATE TABLE `Chichester_Cattery_Booking_System`.`Backup Directories` (",
"`ID` INT(11) AUTO_INCREMENT,",
"`Backup Directory` VARCHAR(250) NULL,",
"`Restore Directory` VARCHAR(250) NULL,",
"`Total Chalets` INT(11) NULL,",
"PRIMARY KEY (`ID`),",
"INDEX `Directories` (`Backup Directory` ASC, `Restore Directory` ASC),",
"INDEX `Settings`(`Total Chalets` ASC),",
"UNIQUE INDEX `ID UNIQUE` (`ID` ASC));",
"CREATE TABLE `Chichester_Cattery_Booking_System`.`Chalets`(",
"`Chalet` INT(11),",
"`Maximum Number of Cats` INT(11) NULL,",
"PRIMARY KEY (`Chalet`),",
"INDEX `Max` (`Maximum Number of Cats` ASC),",
"UNIQUE INDEX `Chalet UNIQUE` (`Chalet` ASC));",
"CREATE TABLE `Chichester_Cattery_Booking_System`.`Potential Changes`(",
"`ID` INT(11) AUTO_INCREMENT,",
"`Booking ID` INT(11),",
"`New Chalet` INT(11),",
"`Arrival Date` DATE,",
"`Departure Date` DATE,",
"`Pair` INT(11),",
"`Current Sum` INT(11),",
"`Change Improvement` INT(11),",
"PRIMARY KEY (`ID`),",
"INDEX `Change Information`(`Booking ID` ASC, `New Chalet` ASC, `Arrival Date` ASC, `Departure Date` ASC, `Pair` ASC, `Change Improvement` ASC, `Current Sum` ASC),",
"UNIQUE INDEX `ID UNIQUE` (`ID` ASC));",
"INSERT INTO `chichester_cattery_booking_system`.`backup directories` (`Total Chalets`) VALUES ('0');",
            };
            #endregion
            if (progressbar == progressBar_backup)
            {
                progressbar.Value = progressbar.Value + (100 / 6);
            }
            else
            {
                progressbar.Value = progressbar.Value + (100 / 12);
            }
            this.PerformLayout();
            #region chaletsanddirectories
            bool chaletcheck = MyGlobalClass.updatechaletnumber(false, MyGlobalClass.totalchalets, false);
            if (chaletcheck == false)
            {
                MessageBox.Show("The Database will be backed up with no Chalets", "No Chalets", MessageBoxButtons.OK);
            }
            int count = 0;
            int changes = 0;
            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`potential changes`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                count++;
            }
            MyGlobalClass.new_connection.Close();
            changes = count;
            string[] ChaletsandDirectories = new string[(9 * MyGlobalClass.totalchalets) + count + 1];
            for (int chalet = 1; chalet <= MyGlobalClass.totalchalets; chalet++)
            {
                int initial = (chalet - 1) * 9;
                string chaletmax = "2";
                ChaletsandDirectories[initial] = "CREATE TABLE `chichester_cattery_booking_system`.`" + chalet + "`(";
                ChaletsandDirectories[initial + 1] = "`Date` DATE,";
                ChaletsandDirectories[initial + 2] = "`Booking ID` INT(11),";
                ChaletsandDirectories[initial + 3] = "PRIMARY KEY (`Date`),";
                ChaletsandDirectories[initial + 4] = "CONSTRAINT `Booking " + chalet + "` FOREIGN KEY (`Booking ID`)";
                ChaletsandDirectories[initial + 5] = "REFERENCES `Chichester_Cattery_Booking_System`.`Bookings` (`Booking ID`),";
                ChaletsandDirectories[initial + 6] = "INDEX `Booking " + chalet + "` (`Booking ID` ASC),";
                ChaletsandDirectories[initial + 7] = "UNIQUE INDEX `Date UNIQUE " + chalet + "` (`Date` ASC));";
                MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`chalets` WHERE `Chalet` = '" + chalet + "';", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                while (MyGlobalClass.SQL_Alter_Database.Read())
                {
                    chaletmax = MyGlobalClass.SQL_Alter_Database["Maximum Number of Cats"].ToString();
                }
                MyGlobalClass.new_connection.Close();
                ChaletsandDirectories[initial + 8] = "INSERT INTO `chichester_cattery_booking_system`.`chalets` (`Chalet`, `Maximum Number of Cats`) VALUES ('" + chalet + "', '" + chaletmax + "');";
            }

            string backupdirectory = text_backupdirectory_backup.Text.Replace('\\', '|');
            string restoredirectory = text_restoredirectory_backup.Text.Replace('\\', '|');
            char[] chararray = restoredirectory.ToCharArray();
            char[] resizedchararray = new char[0];
            count = 0;
            for (int i = 0; i < chararray.GetLength(0); i++)
            {
                if (chararray[i] == 'º' || chararray[i] == '\'')
                {
                    count++;
                }
            }
            resizedchararray = new char[(chararray.GetLength(0) + count)];
            count = 0;

            for (int i = 0; i < chararray.GetLength(0); i++)
            {
                if (chararray[i] == 'º')
                {
                    resizedchararray[count] = '\\';
                    count++;
                    resizedchararray[count] = 'º';
                    count++;
                }
                else if (chararray[i] == '\'')
                {
                    resizedchararray[count] = '\\';
                    count++;
                    resizedchararray[count] = '\'';
                    count++;
                }
                else
                {
                    resizedchararray[count] = chararray[i];
                    count++;
                }
            }
            restoredirectory = new string(resizedchararray);
            count = 0;
            int bookingid = 1;
            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`potential changes`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                MySqlConnection Connection = new MySqlConnection(MyGlobalClass.connection_to_database);
                MySqlCommand Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings`;", Connection);
                Connection.Open();
                MySqlDataReader Reader = Command.ExecuteReader();
                while (MyGlobalClass.SQL_Alter_Database.Read())
                {
                    if (Reader["Booking ID"].ToString() == MyGlobalClass.SQL_Alter_Database["Booking ID"].ToString())
                    {
                        break;
                    }
                    bookingid++;
                }
                Connection.Close();
                ChaletsandDirectories[(MyGlobalClass.totalchalets * 9) + count] = "INSERT INTO `chichester_cattery_booking_system`.`potential changes` (`Booking ID`, `New Chalet`, `Arrival Date`, `Departure Date`, `Pair`, `Current Sum`, `Change Improvement`) VALUES ('" + bookingid + "', '" + MyGlobalClass.SQL_Alter_Database["New Chalet"].ToString() + "', '" + MyGlobalClass.SQL_Alter_Database["Arrival Date"].ToString() + "', '" + MyGlobalClass.SQL_Alter_Database["Departure Date"].ToString() + "', '" + MyGlobalClass.SQL_Alter_Database["Pair"].ToString() + "', '" + MyGlobalClass.SQL_Alter_Database["Current Sum"].ToString() + "', '" + MyGlobalClass.SQL_Alter_Database["Change Improvement"].ToString() + "');";
                count++;
            }
            MyGlobalClass.new_connection.Close();
            ChaletsandDirectories[(MyGlobalClass.totalchalets * 9) + changes] = "INSERT INTO `chichester_cattery_booking_system`.`backup directories` (`Backup Directory`, `Restore Directory`, `Total Chalets`) VALUES ('" + backupdirectory + "', '" + restoredirectory + "', '" + MyGlobalClass.totalchalets + "');";
            #endregion
            if (progressbar == progressBar_backup)
            {
                progressbar.Value = progressbar.Value + (100 / 6);
            }
            else
            {
                progressbar.Value = progressbar.Value + (100 / 12);
            }
            this.PerformLayout();
            #region cats
            string[] catnames = new string[0];
            string[] catnamesoldids = new string[0];
            string[] sexes = new string[0];
            string[] sexesoldids = new string[0];
            string[] descriptions = new string[0];
            string[] descriptionsoldids = new string[0];
            string[] foods = new string[0];
            string[] foodsoldids = new string[0];
            string[] cats = new string[0];
            string[] catsoldids = new string[0];
            string[] Cats = new string[0];
            count = 0;

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`cat names`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                count++;
            }
            MyGlobalClass.new_connection.Close();
            catnames = new string[count];
            catnamesoldids = new string[count];
            count = 0;

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`cat names`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                catnames[count] = "INSERT INTO `chichester_cattery_booking_system`.`cat names` (`Cat Name`) VALUES ('" + MyGlobalClass.SQL_Alter_Database["Cat Name"].ToString() + "');";
                catnamesoldids[count] = MyGlobalClass.SQL_Alter_Database["Cat Name ID"].ToString();
                count++;
            }
            MyGlobalClass.new_connection.Close();
            count = 0;

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`sexes`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                count++;
            }
            MyGlobalClass.new_connection.Close();
            sexes = new string[count];
            sexesoldids = new string[count];
            count = 0;

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`sexes`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                sexes[count] = "INSERT INTO `chichester_cattery_booking_system`.`sexes` (`Sex`) VALUES ('" + MyGlobalClass.SQL_Alter_Database["Sex"].ToString() + "');";
                sexesoldids[count] = MyGlobalClass.SQL_Alter_Database["Sex ID"].ToString();
                count++;
            }
            MyGlobalClass.new_connection.Close();
            count = 0;

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`descriptions`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                count++;
            }
            MyGlobalClass.new_connection.Close();
            descriptions = new string[count];
            descriptionsoldids = new string[count];
            count = 0;

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`descriptions`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                descriptions[count] = "INSERT INTO `chichester_cattery_booking_system`.`descriptions` (`Description`) VALUES ('" + MyGlobalClass.SQL_Alter_Database["Description"].ToString() + "');";
                descriptionsoldids[count] = MyGlobalClass.SQL_Alter_Database["Description ID"].ToString();
                count++;
            }
            MyGlobalClass.new_connection.Close();
            count = 0;

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`foods`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                count++;
            }
            MyGlobalClass.new_connection.Close();
            foods = new string[count];
            foodsoldids = new string[count];
            count = 0;

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`foods`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                foods[count] = "INSERT INTO `chichester_cattery_booking_system`.`foods` (`Food`) VALUES ('" + MyGlobalClass.SQL_Alter_Database["Food"].ToString() + "');";
                foodsoldids[count] = MyGlobalClass.SQL_Alter_Database["Food ID"].ToString();
                count++;
            }
            MyGlobalClass.new_connection.Close();
            count = 0;

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`cats`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                count++;
            }
            MyGlobalClass.new_connection.Close();
            cats = new string[count];
            catsoldids = new string[count];
            count = 0;

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`cats`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                bool found = false;
                string catname = "";
                string sex = "";
                string description = "";
                string food = "";
                for (int i = 0; i < catnamesoldids.GetLength(0) && found == false; i++)
                {
                    if (catnamesoldids[i] == MyGlobalClass.SQL_Alter_Database["Cat Name ID"].ToString())
                    {
                        catname = (i + 1).ToString();
                        found = true;
                    }
                }
                found = false;
                for (int i = 0; i < sexesoldids.GetLength(0) && found == false; i++)
                {
                    if (sexesoldids[i] == MyGlobalClass.SQL_Alter_Database["Sex ID"].ToString())
                    {
                        sex = (i + 1).ToString();
                        found = true;
                    }
                }
                found = false;
                for (int i = 0; i < descriptionsoldids.GetLength(0) && found == false; i++)
                {
                    if (descriptionsoldids[i] == MyGlobalClass.SQL_Alter_Database["Description ID"].ToString())
                    {
                        description = (i + 1).ToString();
                        found = true;
                    }
                }
                found = false;
                for (int i = 0; i < foodsoldids.GetLength(0) && found == false; i++)
                {
                    if (foodsoldids[i] == MyGlobalClass.SQL_Alter_Database["Food ID"].ToString())
                    {
                        food = (i + 1).ToString();
                        found = true;
                    }
                }
                cats[count] = "INSERT INTO `chichester_cattery_booking_system`.`cats` (`Cat Name ID`, `Date Of Birth`, `Sex ID`, `Next Vaccination Date`, `Description ID`, `Food ID`, `Foods To Be Avoided`, `Allergies`, `Special Treatment`) VALUES ('" + catname + "', '" + DateTime.Parse(MyGlobalClass.SQL_Alter_Database["Date Of Birth"].ToString()).ToString("yyyy-MM-dd") + "', '" + sex + "', '" + DateTime.Parse(MyGlobalClass.SQL_Alter_Database["Next Vaccination Date"].ToString()).ToString("yyyy-MM-dd") + "', '" + description + "', '" + food + "', '" + MyGlobalClass.SQL_Alter_Database["Foods To Be Avoided"].ToString() + "', '" + MyGlobalClass.SQL_Alter_Database["Allergies"].ToString() + "', '" + MyGlobalClass.SQL_Alter_Database["Special Treatment"].ToString() + "');";
                catsoldids[count] = MyGlobalClass.SQL_Alter_Database["Cat ID"].ToString();
                count++;
            }
            MyGlobalClass.new_connection.Close();
            count = 0;

            count = catnames.GetLength(0) + sexes.GetLength(0) + descriptions.GetLength(0) + foods.GetLength(0) + cats.GetLength(0);
            Cats = new string[count];

            for (int i = 0; i < catnames.GetLength(0); i++)
            {
                Cats[i] = catnames[i];
            }
            for (int i = 0; i < sexes.GetLength(0); i++)
            {
                int index = i + catnames.GetLength(0);
                Cats[index] = sexes[i];
            }
            for (int i = 0; i < descriptions.GetLength(0); i++)
            {
                int index = i + catnames.GetLength(0) + sexes.GetLength(0);
                Cats[index] = descriptions[i];
            }
            for (int i = 0; i < foods.GetLength(0); i++)
            {
                int index = i + catnames.GetLength(0) + sexes.GetLength(0) + descriptions.GetLength(0);
                Cats[index] = foods[i];
            }
            for (int i = 0; i < cats.GetLength(0); i++)
            {
                int index = i + catnames.GetLength(0) + sexes.GetLength(0) + descriptions.GetLength(0) + foods.GetLength(0);
                Cats[index] = cats[i];
            }
            count = 0;
            #endregion
            if (progressbar == progressBar_backup)
            {
                progressbar.Value = progressbar.Value + (100 / 6);
            }
            else
            {
                progressbar.Value = progressbar.Value + (100 / 12);
            }
            this.PerformLayout();
            #region registration
            string[] contactnames = new string[0];
            string[] contactnamesoldids = new string[0];
            string[] towns = new string[0];
            string[] townsoldids = new string[0];
            string[] postcodes = new string[0];
            string[] postcodesoldids = new string[0];
            string[] addresses = new string[0];
            string[] addressesoldids = new string[0];
            string[] contacttelephones = new string[0];
            string[] contacttelephonesoldids = new string[0];
            string[] absencecontacts = new string[0];
            string[] absencecontactsoldids = new string[0];
            string[] vets = new string[0];
            string[] vetsoldids = new string[0];
            string[] registrations = new string[0];
            string[] registrationsoldids = new string[0];
            string[] Registrations = new string[0];

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact names`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                count++;
            }
            MyGlobalClass.new_connection.Close();
            contactnames = new string[count];
            contactnamesoldids = new string[count];
            count = 0;

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact names`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                contactnames[count] = "INSERT INTO `chichester_cattery_booking_system`.`contact names` (`Contact Name`) VALUES ('" + MyGlobalClass.SQL_Alter_Database["Contact Name"].ToString() + "');";
                contactnamesoldids[count] = MyGlobalClass.SQL_Alter_Database["Contact Name ID"].ToString();
                count++;
            }
            MyGlobalClass.new_connection.Close();
            count = 0;

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`towns`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                count++;
            }
            MyGlobalClass.new_connection.Close();
            towns = new string[count];
            townsoldids = new string[count];
            count = 0;

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`towns`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                towns[count] = "INSERT INTO `chichester_cattery_booking_system`.`towns` (`Town`) VALUES ('" + MyGlobalClass.SQL_Alter_Database["Town"].ToString() + "');";
                townsoldids[count] = MyGlobalClass.SQL_Alter_Database["Town ID"].ToString();
                count++;
            }
            MyGlobalClass.new_connection.Close();
            count = 0;

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`postcodes`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                count++;
            }
            MyGlobalClass.new_connection.Close();
            postcodes = new string[count];
            postcodesoldids = new string[count];
            count = 0;

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`postcodes`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                postcodes[count] = "INSERT INTO `chichester_cattery_booking_system`.`postcodes` (`Postcode`) VALUES ('" + MyGlobalClass.SQL_Alter_Database["Postcode"].ToString() + "');";
                postcodesoldids[count] = MyGlobalClass.SQL_Alter_Database["Postcode ID"].ToString();
                count++;
            }
            MyGlobalClass.new_connection.Close();
            count = 0;

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`addresses`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                count++;
            }
            MyGlobalClass.new_connection.Close();
            addresses = new string[count];
            addressesoldids = new string[count];
            count = 0;

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`addresses`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                bool found = false;
                string town = "";
                string postcode = "";
                for (int i = 0; i < townsoldids.GetLength(0) && found == false; i++)
                {
                    if (townsoldids[i] == MyGlobalClass.SQL_Alter_Database["Town ID"].ToString())
                    {
                        town = (i + 1).ToString();
                        found = true;
                    }
                }
                found = false;
                for (int i = 0; i < postcodesoldids.GetLength(0) && found == false; i++)
                {
                    if (postcodesoldids[i] == MyGlobalClass.SQL_Alter_Database["Postcode ID"].ToString())
                    {
                        postcode = (i + 1).ToString();
                        found = true;
                    }
                }
                addresses[count] = "INSERT INTO `chichester_cattery_booking_system`.`addresses` (`Address`, `Town ID`, `Postcode ID`) VALUES ('" + MyGlobalClass.SQL_Alter_Database["Address"].ToString() + "', '" + town + "', '" + postcode + "');";
                addressesoldids[count] = MyGlobalClass.SQL_Alter_Database["Address ID"].ToString();
                count++;
            }
            MyGlobalClass.new_connection.Close();
            count = 0;

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact telephones`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                count++;
            }
            MyGlobalClass.new_connection.Close();
            contacttelephones = new string[count];
            contacttelephonesoldids = new string[count];
            count = 0;

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`contact telephones`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                contacttelephones[count] = "INSERT INTO `chichester_cattery_booking_system`.`contact telephones` (`Contact Telephone`) VALUES ('" + MyGlobalClass.SQL_Alter_Database["Contact Telephone"].ToString() + "');";
                contacttelephonesoldids[count] = MyGlobalClass.SQL_Alter_Database["Contact Telephone ID"].ToString();
                count++;
            }
            MyGlobalClass.new_connection.Close();
            count = 0;

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`absence contacts`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                count++;
            }
            MyGlobalClass.new_connection.Close();
            absencecontacts = new string[count];
            absencecontactsoldids = new string[count];
            count = 0;

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`absence contacts`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                bool found = false;
                string name = "";
                string telephone = "";
                for (int i = 0; i < contactnamesoldids.GetLength(0) && found == false; i++)
                {
                    if (contactnamesoldids[i] == MyGlobalClass.SQL_Alter_Database["Contact Name ID"].ToString())
                    {
                        name = (i + 1).ToString();
                        found = true;
                    }
                }
                found = false;
                for (int i = 0; i < contacttelephonesoldids.GetLength(0) && found == false; i++)
                {
                    if (contacttelephonesoldids[i] == MyGlobalClass.SQL_Alter_Database["Contact Telephone ID"].ToString())
                    {
                        telephone = (i + 1).ToString();
                        found = true;
                    }
                }
                absencecontacts[count] = "INSERT INTO `chichester_cattery_booking_system`.`absence contacts` (`Contact Name ID`, `Contact Telephone ID`) VALUES ('" + name + "', '" + telephone + "');";
                absencecontactsoldids[count] = MyGlobalClass.SQL_Alter_Database["Absence Contact ID"].ToString();
                count++;
            }
            MyGlobalClass.new_connection.Close();
            count = 0;

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`vets`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                count++;
            }
            MyGlobalClass.new_connection.Close();
            vets = new string[count];
            vetsoldids = new string[count];
            count = 0;

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`vets`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                bool found = false;
                string name = "";
                string telephone = "";
                for (int i = 0; i < contactnamesoldids.GetLength(0) && found == false; i++)
                {
                    if (contactnamesoldids[i] == MyGlobalClass.SQL_Alter_Database["Contact Name ID"].ToString())
                    {
                        name = (i + 1).ToString();
                        found = true;
                    }
                }
                found = false;
                for (int i = 0; i < contacttelephonesoldids.GetLength(0) && found == false; i++)
                {
                    if (contacttelephonesoldids[i] == MyGlobalClass.SQL_Alter_Database["Contact Telephone ID"].ToString())
                    {
                        telephone = (i + 1).ToString();
                        found = true;
                    }
                }
                vets[count] = "INSERT INTO `chichester_cattery_booking_system`.`vets` (`Contact Name ID`, `Contact Telephone ID`) VALUES ('" + name + "', '" + telephone + "');";
                vetsoldids[count] = MyGlobalClass.SQL_Alter_Database["Vet ID"].ToString();
                count++;
            }
            MyGlobalClass.new_connection.Close();
            count = 0;

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                count++;
            }
            MyGlobalClass.new_connection.Close();
            registrations = new string[count];
            registrationsoldids = new string[count];
            count = 0;

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                bool found = false;
                string[] owners = new string[6];
                string address = "";
                string hometelephone = "";
                string[] mobiles = new string[6];
                string[] registrationcats = new string[6];
                string absencecontact = "";
                string vet = "";
                string extrainfo = MyGlobalClass.SQL_Alter_Database["Extra Information"].ToString();
                for (int owner = 0; owner < 6; owner++)
                {
                    for (int i = 0; i < contactnamesoldids.GetLength(0) && found == false; i++)
                    {
                        if (contactnamesoldids[i] == MyGlobalClass.SQL_Alter_Database["Owner " + (owner + 1) + " ID"].ToString())
                        {
                            owners[owner] = "'" + (i + 1).ToString() + "'";
                            found = true;
                        }
                    }
                    if (found == false)
                    {
                        owners[owner] = "NULL";
                    }
                    found = false;
                }
                found = false;
                for (int i = 0; i < addressesoldids.GetLength(0) && found == false; i++)
                {
                    if (addressesoldids[i] == MyGlobalClass.SQL_Alter_Database["Address ID"].ToString())
                    {
                        address = (i + 1).ToString();
                        found = true;
                    }
                }
                found = false;
                for (int i = 0; i < contacttelephonesoldids.GetLength(0) && found == false; i++)
                {
                    if (contacttelephonesoldids[i] == MyGlobalClass.SQL_Alter_Database["Home Telephone ID"].ToString())
                    {
                        hometelephone = (i + 1).ToString();
                        found = true;
                    }
                }
                found = false;
                for (int telephone = 0; telephone < 6; telephone++)
                {
                    for (int i = 0; i < contacttelephonesoldids.GetLength(0) && found == false; i++)
                    {
                        if (contacttelephonesoldids[i] == MyGlobalClass.SQL_Alter_Database["Mobile " + (telephone + 1) + " ID"].ToString())
                        {
                            mobiles[telephone] = "'" + (i + 1).ToString() + "'";
                            found = true;
                        }
                    }
                    if (found == false)
                    {
                        mobiles[telephone] = "NULL";
                    }
                    found = false;
                }
                found = false;
                for (int cat = 0; cat < 6; cat++)
                {
                    for (int i = 0; i < catsoldids.GetLength(0) && found == false; i++)
                    {
                        if (catsoldids[i] == MyGlobalClass.SQL_Alter_Database["Cat " + (cat + 1) + " ID"].ToString())
                        {
                            registrationcats[cat] = "'" + (i + 1).ToString() + "'";
                            found = true;
                        }
                    }
                    if (found == false)
                    {
                        registrationcats[cat] = "NULL";
                    }
                    found = false;
                }
                found = false;
                for (int i = 0; i < absencecontactsoldids.GetLength(0) && found == false; i++)
                {
                    if (absencecontactsoldids[i] == MyGlobalClass.SQL_Alter_Database["Absence Contact ID"].ToString())
                    {
                        absencecontact = (i + 1).ToString();
                        found = true;
                    }
                }
                found = false;
                for (int i = 0; i < vetsoldids.GetLength(0) && found == false; i++)
                {
                    if (vetsoldids[i] == MyGlobalClass.SQL_Alter_Database["Vet ID"].ToString())
                    {
                        vet = (i + 1).ToString();
                        found = true;
                    }
                }
                registrations[count] = "INSERT INTO `chichester_cattery_booking_system`.`registrations` (`Owner 1 ID`, `Owner 2 ID`, `Owner 3 ID`, `Owner 4 ID`, `Owner 5 ID`, `Owner 6 ID`, `Address ID`, `Home Telephone ID`, `Mobile 1 ID`, `Mobile 2 ID`, `Mobile 3 ID`, `Mobile 4 ID`, `Mobile 5 ID`, `Mobile 6 ID`, `Cat 1 ID`, `Cat 2 ID`, `Cat 3 ID`, `Cat 4 ID`, `Cat 5 ID`, `Cat 6 ID`, `Absence Contact ID`, `Vet ID`, `Extra Information`) VALUES (" + owners[0] + ", " + owners[1] + ", " + owners[2] + ", " + owners[3] + ", " + owners[4] + ", " + owners[5] + ", '" + address + "', '" + hometelephone + "', " + mobiles[0] + ", " + mobiles[1] + ", " + mobiles[2] + ", " + mobiles[3] + ", " + mobiles[4] + ", " + mobiles[5] + ", " + registrationcats[0] + ", " + registrationcats[1] + ", " + registrationcats[2] + ", " + registrationcats[3] + ", " + registrationcats[4] + ", " + registrationcats[5] + ", '" + absencecontact + "', '" + vet + "', '" + extrainfo + "');";
                registrationsoldids[count] = MyGlobalClass.SQL_Alter_Database["Registration ID"].ToString();
                count++;
            }
            MyGlobalClass.new_connection.Close();
            count = 0;

            count = contactnames.GetLength(0) + towns.GetLength(0) + postcodes.GetLength(0) + addresses.GetLength(0) + contacttelephones.GetLength(0) + absencecontacts.GetLength(0) + vets.GetLength(0) + registrations.GetLength(0);
            Registrations = new string[count];

            for (int i = 0; i < contactnames.GetLength(0); i++)
            {
                int index = i;
                Registrations[index] = contactnames[i];
            }
            for (int i = 0; i < towns.GetLength(0); i++)
            {
                int index = i + contactnames.GetLength(0);
                Registrations[index] = towns[i];
            }
            for (int i = 0; i < postcodes.GetLength(0); i++)
            {
                int index = i + contactnames.GetLength(0) + towns.GetLength(0);
                Registrations[index] = postcodes[i];
            }
            for (int i = 0; i < addresses.GetLength(0); i++)
            {
                int index = i + contactnames.GetLength(0) + towns.GetLength(0) + postcodes.GetLength(0);
                Registrations[index] = addresses[i];
            }
            for (int i = 0; i < contacttelephones.GetLength(0); i++)
            {
                int index = i + contactnames.GetLength(0) + towns.GetLength(0) + postcodes.GetLength(0) + addresses.GetLength(0);
                Registrations[index] = contacttelephones[i];
            }
            for (int i = 0; i < absencecontacts.GetLength(0); i++)
            {
                int index = i + contactnames.GetLength(0) + towns.GetLength(0) + postcodes.GetLength(0) + addresses.GetLength(0) + contacttelephones.GetLength(0);
                Registrations[index] = absencecontacts[i];
            }
            for (int i = 0; i < vets.GetLength(0); i++)
            {
                int index = i + contactnames.GetLength(0) + towns.GetLength(0) + postcodes.GetLength(0) + addresses.GetLength(0) + contacttelephones.GetLength(0) + absencecontacts.GetLength(0);
                Registrations[index] = vets[i];
            }
            for (int i = 0; i < registrations.GetLength(0); i++)
            {
                int index = i + contactnames.GetLength(0) + towns.GetLength(0) + postcodes.GetLength(0) + addresses.GetLength(0) + contacttelephones.GetLength(0) + absencecontacts.GetLength(0) + vets.GetLength(0);
                Registrations[index] = registrations[i];
            }
            count = 0;
            #endregion
            if (progressbar == progressBar_backup)
            {
                progressbar.Value = progressbar.Value + (100 / 6);
            }
            else
            {
                progressbar.Value = progressbar.Value + (100 / 12);
            }
            this.PerformLayout();
            #region bookings
            string[] arrivaldeparturetimes = new string[0];
            string[] arrivaldeparturetimesoldids = new string[0];
            string[] bookings = new string[0];
            string[] bookingsoldids = new string[0];
            string[,] chalets = new string[0, 0];
            string[] Bookings = new string[0];
            string[,] rearrangingarray = new string[0, 0];

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`arrival/departure times`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                count++;
            }
            MyGlobalClass.new_connection.Close();
            arrivaldeparturetimes = new string[count];
            arrivaldeparturetimesoldids = new string[count];
            count = 0;

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`arrival/departure times`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                arrivaldeparturetimes[count] = "INSERT INTO `chichester_cattery_booking_system`.`arrival/departure times` (`Arrival/Departure Time`) VALUES ('" + MyGlobalClass.SQL_Alter_Database["Arrival/Departure Time"].ToString() + "');";
                arrivaldeparturetimesoldids[count] = MyGlobalClass.SQL_Alter_Database["Arrival/Departure Time ID"].ToString();
                count++;
            }
            MyGlobalClass.new_connection.Close();
            count = 0;

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                count++;
            }
            MyGlobalClass.new_connection.Close();
            bookings = new string[count];
            bookingsoldids = new string[count];
            count = 0;

            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                bool found = false;
                string registrationid = "";
                string arrivaltime = "";
                string departuretime = "";
                string cat1vaccination = "";
                string cat2vaccination = "";
                string cat3vaccination = "";
                string cat4vaccination = "";
                string cat5vaccination = "";
                string cat6vaccination = "";

                for (int i = 0; i < registrationsoldids.GetLength(0); i++)
                { //Looks through an array of old ID's, which are in the order they should be added in, to find the index of the old ID which maps to the New ID
                    if (registrationsoldids[i] == MyGlobalClass.SQL_Alter_Database["Registration ID"].ToString())
                    {
                        registrationid = "'" + (i + 1).ToString() + "'";
                        break;
                    }
                }

                for (int i = 0; i < arrivaldeparturetimesoldids.GetLength(0) && found == false; i++)
                {
                    if (arrivaldeparturetimesoldids[i] == MyGlobalClass.SQL_Alter_Database["Arrival Time ID"].ToString())
                    {
                        arrivaltime = (i + 1).ToString();
                        found = true;
                    }
                }
                found = false;
                for (int i = 0; i < arrivaldeparturetimesoldids.GetLength(0) && found == false; i++)
                {
                    if (arrivaldeparturetimesoldids[i] == MyGlobalClass.SQL_Alter_Database["Departure Time ID"].ToString())
                    {
                        departuretime = (i + 1).ToString();
                        found = true;
                    }
                }
                for (int i = 1; i <= 6; i++)
                {
                    string catvaccination = "";
                    string booleanvalue = MyGlobalClass.SQL_Alter_Database["Cat " + i + " Vaccination"].ToString();
                    if (booleanvalue == "")
                    {
                        catvaccination = "NULL";
                    }
                    else if (booleanvalue == "1" || booleanvalue == "True")
                    {
                        catvaccination = "'1'";
                    }
                    else if (booleanvalue == "0" || booleanvalue == "False")
                    {
                        catvaccination = "'0'";
                    }
                    switch (i)
                    {
                        case 1:
                            cat1vaccination = catvaccination;
                            break;
                        case 2:
                            cat2vaccination = catvaccination;
                            break;
                        case 3:
                            cat3vaccination = catvaccination;
                            break;
                        case 4:
                            cat4vaccination = catvaccination;
                            break;
                        case 5:
                            cat5vaccination = catvaccination;
                            break;
                        case 6:
                            cat6vaccination = catvaccination;
                            break;
                    }
                }
                bookings[count] = "INSERT INTO `chichester_cattery_booking_system`.`bookings` (`Registration ID`, `Cat 1 Staying`, `Cat 2 Staying`, `Cat 3 Staying`, `Cat 4 Staying`, `Cat 5 Staying`, `Cat 6 Staying`, `Arrival Date`, `Departure Date`, `Arrival Time ID`, `Departure Time ID`, `Checked In`, `Checked Out`, `Chalet`, `Cat 1 Vaccination`, `Cat 2 Vaccination`, `Cat 3 Vaccination`, `Cat 4 Vaccination`, `Cat 5 Vaccination`, `Cat 6 Vaccination`) VALUES (" + registrationid + ", '" + MyGlobalClass.SQL_Alter_Database["Cat 1 Staying"] + "', '" + MyGlobalClass.SQL_Alter_Database["Cat 2 Staying"] + "', '" + MyGlobalClass.SQL_Alter_Database["Cat 3 Staying"] + "', '" + MyGlobalClass.SQL_Alter_Database["Cat 4 Staying"] + "', '" + MyGlobalClass.SQL_Alter_Database["Cat 5 Staying"] + "', '" + MyGlobalClass.SQL_Alter_Database["Cat 6 Staying"] + "', '" + DateTime.Parse(MyGlobalClass.SQL_Alter_Database["Arrival Date"].ToString()).ToString("yyyy-MM-dd") + "', '" + DateTime.Parse(MyGlobalClass.SQL_Alter_Database["Departure Date"].ToString()).ToString("yyyy-MM-dd") + "', '" + arrivaltime + "', '" + departuretime + "', '" + Convert.ToInt32((bool)MyGlobalClass.SQL_Alter_Database["Checked In"]) + "', '" + Convert.ToInt32((bool)MyGlobalClass.SQL_Alter_Database["Checked Out"]) + "', '" + MyGlobalClass.SQL_Alter_Database["Chalet"] + "', " + cat1vaccination + ", " + cat2vaccination + ", " + cat3vaccination + ", " + cat4vaccination + ", " + cat5vaccination + ", " + cat6vaccination + ");";
                bookingsoldids[count] = MyGlobalClass.SQL_Alter_Database["Booking ID"].ToString();
                count++;
            }
            MyGlobalClass.new_connection.Close();
            count = 0;

            MyGlobalClass.updatechaletnumber(false, MyGlobalClass.totalchalets, false);
            for (int chalet = 0; chalet < MyGlobalClass.totalchalets; chalet++)
            {
                string[] chaletarray = new string[0];
                MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`" + (chalet + 1) + "`;", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                while (MyGlobalClass.SQL_Alter_Database.Read())
                {
                    count++;
                }
                MyGlobalClass.new_connection.Close();
                chaletarray = new string[count];
                count = 0;

                MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`" + (chalet + 1) + "`;", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                while (MyGlobalClass.SQL_Alter_Database.Read())
                {
                    bool found = false;
                    string booking = "";
                    string date = DateTime.Parse(MyGlobalClass.SQL_Alter_Database["Date"].ToString()).ToString("yyyy-MM-dd");
                    for (int i = 0; i < bookingsoldids.GetLength(0) && found == false; i++)
                    {
                        if (bookingsoldids[i] == MyGlobalClass.SQL_Alter_Database["Booking ID"].ToString())
                        {
                            booking = (i + 1).ToString();
                            found = true;
                        }
                    }
                    chaletarray[count] = "INSERT INTO `chichester_cattery_booking_system`.`" + (chalet + 1) + "` (`Date`, `Booking ID`) VALUES ('" + date + "', '" + booking + "');";
                    count++;
                }
                MyGlobalClass.new_connection.Close();
                count = 0;

                if (chaletarray.GetLength(0) > chalets.GetLength(0))
                {
                    rearrangingarray = new string[chaletarray.GetLength(0), MyGlobalClass.totalchalets];
                    for (int chaletindex = 0; chaletindex < MyGlobalClass.totalchalets; chaletindex++)
                    {
                        for (int record = 0; record < chalets.GetLength(0); record++)
                        {
                            rearrangingarray[record, chaletindex] = chalets[record, chaletindex];
                        }
                    }
                    chalets = new string[chaletarray.GetLength(0), MyGlobalClass.totalchalets];
                    for (int chaletindex = 0; chaletindex < MyGlobalClass.totalchalets; chaletindex++)
                    {
                        for (int record = 0; record < chalets.GetLength(0); record++)
                        {
                            chalets[record, chaletindex] = rearrangingarray[record, chaletindex];
                        }
                    }
                }
                for (int record = 0; record < chaletarray.GetLength(0); record++)
                {
                    chalets[record, chalet] = chaletarray[record];
                }
            }

            count = arrivaldeparturetimes.GetLength(0) + bookings.GetLength(0) + (chalets.GetLength(0) * MyGlobalClass.totalchalets);
            rearrangingarray = new string[count, 1];
            count = 0;

            for (int i = 0; i < arrivaldeparturetimes.GetLength(0); i++)
            {
                rearrangingarray[count, 0] = arrivaldeparturetimes[i];
                count++;
            }
            for (int i = 0; i < bookings.GetLength(0); i++)
            {
                rearrangingarray[count, 0] = bookings[i];
                count++;
            }
            for (int chalet = 0; chalet < MyGlobalClass.totalchalets; chalet++)
            {
                for (int record = 0; record < chalets.GetLength(0); record++)
                {
                    if (chalets[record, chalet] != null)
                    {
                        rearrangingarray[count, 0] = chalets[record, chalet];
                        count++;
                    }
                }
            }
            Bookings = new string[count];
            count = 0;

            for (int i = 0; i < Bookings.GetLength(0); i++)
            {
                Bookings[i] = rearrangingarray[i, 0];
            }
            #endregion
            if (progressbar == progressBar_backup)
            {
                progressbar.Value = progressbar.Value + (100 / 6);
            }
            else
            {
                progressbar.Value = progressbar.Value + (100 / 12);
            }
            this.PerformLayout();

            string directory = text_backupdirectory_backup.Text + "\\BACKUPS\\BACKUP " + DateTime.Now.ToString(@"yyyy-MM-dd  HH\ºmm\'ss\'\'") + "";
            System.IO.Directory.CreateDirectory(@directory);
            FileIOPermission permissions = new FileIOPermission(FileIOPermissionAccess.Read, directory);
            permissions.AddPathList(FileIOPermissionAccess.Write | FileIOPermissionAccess.Read, directory + "\\Database.txt");
            permissions.AddPathList(FileIOPermissionAccess.Write | FileIOPermissionAccess.Read, directory + "\\Chalets.txt");
            permissions.AddPathList(FileIOPermissionAccess.Write | FileIOPermissionAccess.Read, directory + "\\Cats.txt");
            permissions.AddPathList(FileIOPermissionAccess.Write | FileIOPermissionAccess.Read, directory + "\\Registrations.txt");
            permissions.AddPathList(FileIOPermissionAccess.Write | FileIOPermissionAccess.Read, directory + "\\Bookings.txt");

            try
            {
                permissions.Demand();
            }
            catch (System.Security.SecurityException s)
            {
                Console.WriteLine(s.Message);
            }

            System.IO.File.WriteAllLines(@"" + directory + "\\Database.txt", Database);
            System.IO.File.WriteAllLines(@"" + directory + "\\Chalets.txt", ChaletsandDirectories);
            System.IO.File.WriteAllLines(@"" + directory + "\\Cats.txt", Cats);
            System.IO.File.WriteAllLines(@"" + directory + "\\Registrations.txt", Registrations);
            System.IO.File.WriteAllLines(@"" + directory + "\\Bookings.txt", Bookings);
            if (progressbar == progressBar_backup)
            {
                progressbar.Value = progressbar.Value + (100 / 6);
            }
            else
            {
                progressbar.Value = progressbar.Value + (100 / 12);
            }
            this.PerformLayout();
        }

        private string restore()
        {
            string report = "";
            string directory = text_restoredirectory_backup.Text;
            FileIOPermission permissions = new FileIOPermission(FileIOPermissionAccess.Read, directory);
            permissions.AddPathList(FileIOPermissionAccess.Write | FileIOPermissionAccess.Read, directory + "\\Database.txt");
            permissions.AddPathList(FileIOPermissionAccess.Write | FileIOPermissionAccess.Read, directory + "\\Chalets.txt");
            permissions.AddPathList(FileIOPermissionAccess.Write | FileIOPermissionAccess.Read, directory + "\\Cats.txt");
            permissions.AddPathList(FileIOPermissionAccess.Write | FileIOPermissionAccess.Read, directory + "\\Registrations.txt");
            permissions.AddPathList(FileIOPermissionAccess.Write | FileIOPermissionAccess.Read, directory + "\\Bookings.txt");

            try
            {
                permissions.Demand();
            }
            catch (System.Security.SecurityException s)
            {
                Console.WriteLine(s.Message);
            }

            string Database = System.IO.File.ReadAllText(@"" + directory + "\\Database.txt");
            string ChaletsandDirectories = System.IO.File.ReadAllText(@"" + directory + "\\Chalets.txt");
            string Cats = System.IO.File.ReadAllText(@"" + directory + "\\Cats.txt");
            string Registrations = System.IO.File.ReadAllText(@"" + directory + "\\Registrations.txt");
            string Bookings = System.IO.File.ReadAllText(@"" + directory + "\\Bookings.txt");

            MyGlobalClass.SQL_Command = new MySqlCommand("DROP SCHEMA `chichester_cattery_booking_system`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            MyGlobalClass.new_connection.Close();
            progressBar_restore.Value = progressBar_restore.Value + (100 / 12);
            this.PerformLayout();

            MyGlobalClass.SQL_Command = new MySqlCommand(Database, MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            MyGlobalClass.new_connection.Close();
            progressBar_restore.Value = progressBar_restore.Value + (100 / 12);
            this.PerformLayout();

            MyGlobalClass.SQL_Command = new MySqlCommand(ChaletsandDirectories, MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            MyGlobalClass.new_connection.Close();
            progressBar_restore.Value = progressBar_restore.Value + (100 / 12);
            this.PerformLayout();

            if (Cats != "")
            {
                MyGlobalClass.SQL_Command = new MySqlCommand(Cats, MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                MyGlobalClass.new_connection.Close();
            }
            else
            {
                report = report + " The Registration System may not have been successfully restored.";
            }
            progressBar_restore.Value = progressBar_restore.Value + (100 / 12);
            this.PerformLayout();

            if (Registrations != "")
            {
                MyGlobalClass.SQL_Command = new MySqlCommand(Registrations, MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                MyGlobalClass.new_connection.Close();
            }
            else if (Cats != "")
            {
                report = report + " The Registration System may not have been successfully restored.";
            }
            progressBar_restore.Value = progressBar_restore.Value + (100 / 12);
            this.PerformLayout();

            if (Bookings != "")
            {
                MyGlobalClass.SQL_Command = new MySqlCommand(Bookings, MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                MyGlobalClass.new_connection.Close();
            }
            else
            {
                report = report + " The Booking System may not have been successfully restored.";
            }
            progressBar_restore.Value = progressBar_restore.Value + (100 / 12);
            this.PerformLayout();

            return report;
        }

        private void button_exitbackup_backup_Click(object sender, EventArgs e)
        {
            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`backup directories`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                MyGlobalClass.totalchalets = int.Parse(MyGlobalClass.SQL_Alter_Database["Total Chalets"].ToString());
            }
            MyGlobalClass.new_connection.Close();

            if (MyGlobalClass.totalchalets > 0)
            {
                if (MyGlobalClass.initialform_open == false)
                {
                    var newform = new form_initialscreen();
                    MyGlobalClass.CloseForm(newform, this);
                    MyGlobalClass.initialform_open = true;
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                if (MessageBox.Show("Please set a value for the number of chalets in the Backup window. Do you wish to exit the program?", "No value for the number of chalets", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }

        private void numericUpDown_numberofchalets_ValueChanged(object sender, EventArgs e)
        {
            float FontSize = numericUpDown_numberofchalets.Font.Size;
            float ListBoxFontSize = listBox_familychalets.Font.Size;
            if (numericUpDown_numberofchalets.Value != 0)
            {
                if (numericUpDown_numberofchalets.Value > MyGlobalClass.totalchalets)
                {
                    label_addingremovingchalets.Text = "Adding...";
                }
                else if (numericUpDown_numberofchalets.Value < MyGlobalClass.totalchalets)
                {
                    label_addingremovingchalets.Text = "Removing...";
                }
                label_totalnumberofchalets.Visible = false;
                label_totalnumberofchalets.Enabled = false;
                label_addingremovingchalets.Visible = true;
                label_addingremovingchalets.Enabled = true;
            }
            this.PerformLayout();
            MyGlobalClass.updatechaletnumber(true, int.Parse(numericUpDown_numberofchalets.Value.ToString()), true); //Calls the global method
            label_totalnumberofchalets.Visible = true;
            label_totalnumberofchalets.Enabled = true;
            label_addingremovingchalets.Visible = false;
            label_addingremovingchalets.Enabled = false;

            Chalets = new string[MyGlobalClass.totalchalets, 3]; //Initalizing a new array with one column for normal, family and large family chalets
            numericUpDown_numberofchalets.Value = MyGlobalClass.totalchalets; //Updates the numeric updown (should be updated to the same)

            int normal = 0;
            int family = 0;
            int large = 0;

            listBox_normalchalets.SelectedIndex = -1;
            listBox_familychalets.SelectedIndex = -1;
            listBox_largefamilychalets.SelectedIndex = -1;
            listBox_normalchalets.Items.Clear();
            listBox_familychalets.Items.Clear();
            listBox_largefamilychalets.Items.Clear();
            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`chalets`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            { //Adds each chalet to the respective column in the array
                if (MyGlobalClass.SQL_Alter_Database["Maximum Number of Cats"].ToString() == "2")
                {
                    Chalets[normal, 0] = MyGlobalClass.SQL_Alter_Database["Chalet"].ToString();
                    normal++;
                }
                else if (MyGlobalClass.SQL_Alter_Database["Maximum Number of Cats"].ToString() == "4")
                {
                    Chalets[family, 1] = MyGlobalClass.SQL_Alter_Database["Chalet"].ToString();
                    family++;
                }
                else if (MyGlobalClass.SQL_Alter_Database["Maximum Number of Cats"].ToString() == "6")
                {
                    Chalets[large, 2] = MyGlobalClass.SQL_Alter_Database["Chalet"].ToString();
                    large++;
                }
            }
            MyGlobalClass.new_connection.Close();

            for (int i = 0; i < normal; i++) //Adds each chalet to the respective list box
            {
                listBox_normalchalets.Items.Add("Chalet " + Chalets[i, 0] + "");
            }
            for (int i = 0; i < family; i++)
            {
                listBox_familychalets.Items.Add("Chalet " + Chalets[i, 1] + "");
            }
            for (int i = 0; i < large; i++)
            {
                listBox_largefamilychalets.Items.Add("Chalet " + Chalets[i, 2] + "");
            }
            this.ResumeLayout();
            this.PerformLayout();
        }

        private void button_browsebackup_backup_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog Browse = new FolderBrowserDialog();
            Browse.SelectedPath = text_backupdirectory_backup.Text;
            Browse.ShowDialog();
            text_backupdirectory_backup.Text = Browse.SelectedPath;
        }

        private void button_browserestore_backup_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog Browse = new FolderBrowserDialog();
            Browse.SelectedPath = text_restoredirectory_backup.Text;
            Browse.ShowDialog();
            text_restoredirectory_backup.Text = Browse.SelectedPath;
        }

        private void form_backupandchalets_Load(object sender, EventArgs e)
        {
            text_backupdirectory_backup.TextChanged -= text_backupdirectory_backup_TextChanged;
            text_restoredirectory_backup.TextChanged -= text_restoredirectory_backup_TextChanged;
            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`backup directories`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                text_backupdirectory_backup.Text = MyGlobalClass.SQL_Alter_Database["Backup Directory"].ToString().Replace('|', '\\');
                text_restoredirectory_backup.Text = MyGlobalClass.SQL_Alter_Database["Restore Directory"].ToString().Replace('|', '\\');
                MyGlobalClass.totalchalets = int.Parse(MyGlobalClass.SQL_Alter_Database["Total Chalets"].ToString());
                numericUpDown_numberofchalets.ValueChanged -= numericUpDown_numberofchalets_ValueChanged;
                numericUpDown_numberofchalets.Value = int.Parse(MyGlobalClass.SQL_Alter_Database["Total Chalets"].ToString());
                numericUpDown_numberofchalets.ValueChanged += numericUpDown_numberofchalets_ValueChanged;
            }
            MyGlobalClass.new_connection.Close();

            Chalets = new string[MyGlobalClass.totalchalets, 3];

            int normal = 0;
            int family = 0;
            int large = 0;

            listBox_normalchalets.SelectedIndex = -1;
            listBox_familychalets.SelectedIndex = -1;
            listBox_largefamilychalets.SelectedIndex = -1;
            listBox_normalchalets.Items.Clear();
            listBox_familychalets.Items.Clear();
            listBox_largefamilychalets.Items.Clear();
            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`chalets`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                if (MyGlobalClass.SQL_Alter_Database["Maximum Number of Cats"].ToString() == "2")
                {
                    Chalets[normal, 0] = MyGlobalClass.SQL_Alter_Database["Chalet"].ToString();
                    normal++;
                }
                else if (MyGlobalClass.SQL_Alter_Database["Maximum Number of Cats"].ToString() == "4")
                {
                    Chalets[family, 1] = MyGlobalClass.SQL_Alter_Database["Chalet"].ToString();
                    family++;
                }
                else if (MyGlobalClass.SQL_Alter_Database["Maximum Number of Cats"].ToString() == "6")
                {
                    Chalets[large, 2] = MyGlobalClass.SQL_Alter_Database["Chalet"].ToString();
                    large++;
                }
            }
            MyGlobalClass.new_connection.Close();

            for (int i = 0; i < normal; i++)
            {
                listBox_normalchalets.Items.Add("Chalet " + Chalets[i, 0] + "");
            }
            for (int i = 0; i < family; i++)
            {
                listBox_familychalets.Items.Add("Chalet " + Chalets[i, 1] + "");
            }
            for (int i = 0; i < large; i++)
            {
                listBox_largefamilychalets.Items.Add("Chalet " + Chalets[i, 2] + "");
            }
            text_backupdirectory_backup.TextChanged += text_backupdirectory_backup_TextChanged;
            text_restoredirectory_backup.TextChanged += text_restoredirectory_backup_TextChanged;
        }

        private void button_backup_backup_Click(object sender, EventArgs e)
        {
            if (checkdirectoryvalidation(text_backupdirectory_backup.Text) == true)
            {
                if (MessageBox.Show("Are you sure you wish to backup the Chichester Cattery Booking System?", "Backup", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    progressBar_backup.Enabled = true;
                    progressBar_backup.Visible = true;
                    progressBar_backup.Value = 0;
                    try
                    {
                        backup(progressBar_backup);
                        progressBar_backup.Value = 100;
                        MessageBox.Show("Chichester Cattery Booking System Sucessfully Backed Up", "Backup Successful", MessageBoxButtons.OK);
                    }
                    catch
                    {
                        MessageBox.Show("Unfortunately, Chichester Cattery Booking System was not sucessfully Backed Up", "Backup Unsuccessful", MessageBoxButtons.OK);
                        MyGlobalClass.new_connection.Close();
                    }
                    progressBar_backup.Enabled = false;
                    progressBar_backup.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Invalid Backup Directory. Please enter a directory in the correct form.", "Invalid Backup Directory", MessageBoxButtons.OK);
            }
        }

        private void listBox_normalchalets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_normalchalets.SelectedIndices.Count != ListBoxSelectedItemsCounts[0])
            {
                ListBoxSelectedItemsCounts[0] = listBox_normalchalets.SelectedIndices.Count;
                ListBoxSelectedChalets = new string[ListBoxSelectedItemsCounts[0] + ListBoxSelectedItemsCounts[1] + ListBoxSelectedItemsCounts[2]];
                int count = 0;
                foreach (int Chalet in listBox_normalchalets.SelectedIndices)
                {
                    ListBoxSelectedChalets[count] = Chalets[Chalet, 0];
                    count++;
                }
                foreach (int Chalet in listBox_familychalets.SelectedIndices)
                {
                    ListBoxSelectedChalets[count] = Chalets[Chalet, 1];
                    count++;
                }
                foreach (int Chalet in listBox_largefamilychalets.SelectedIndices)
                {
                    ListBoxSelectedChalets[count] = Chalets[Chalet, 2];
                    count++;
                }
            }

            button_setnormalchalet.Enabled = false;
            button_setfamilychalet.Enabled = false;
            button_setlargefamilychalet.Enabled = false;
            if (ListBoxSelectedItemsCounts[0] > 0)
            {
                button_setfamilychalet.Enabled = true;
                button_setlargefamilychalet.Enabled = true;
            }
            if (ListBoxSelectedItemsCounts[1] > 0)
            {
                button_setnormalchalet.Enabled = true;
                button_setlargefamilychalet.Enabled = true;
            }
            if (ListBoxSelectedItemsCounts[2] > 0)
            {
                button_setnormalchalet.Enabled = true;
                button_setfamilychalet.Enabled = true;
            }
        }

        private void listBox_familychalets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_familychalets.SelectedIndices.Count != ListBoxSelectedItemsCounts[1])
            {
                ListBoxSelectedItemsCounts[1] = listBox_familychalets.SelectedIndices.Count;
                ListBoxSelectedChalets = new string[ListBoxSelectedItemsCounts[0] + ListBoxSelectedItemsCounts[1] + ListBoxSelectedItemsCounts[2]];
                int count = 0;
                foreach (int Chalet in listBox_normalchalets.SelectedIndices)
                {
                    ListBoxSelectedChalets[count] = Chalets[Chalet, 0];
                    count++;
                }
                foreach (int Chalet in listBox_familychalets.SelectedIndices)
                {
                    ListBoxSelectedChalets[count] = Chalets[Chalet, 1];
                    count++;
                }
                foreach (int Chalet in listBox_largefamilychalets.SelectedIndices)
                {
                    ListBoxSelectedChalets[count] = Chalets[Chalet, 2];
                    count++;
                }
            }

            button_setnormalchalet.Enabled = false;
            button_setfamilychalet.Enabled = false;
            button_setlargefamilychalet.Enabled = false;
            if (ListBoxSelectedItemsCounts[0] > 0)
            {
                button_setfamilychalet.Enabled = true;
                button_setlargefamilychalet.Enabled = true;
            }
            if (ListBoxSelectedItemsCounts[1] > 0)
            {
                button_setnormalchalet.Enabled = true;
                button_setlargefamilychalet.Enabled = true;
            }
            if (ListBoxSelectedItemsCounts[2] > 0)
            {
                button_setnormalchalet.Enabled = true;
                button_setfamilychalet.Enabled = true;
            }
        }

        private void listBox_largefamilychalets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_largefamilychalets.SelectedIndices.Count != ListBoxSelectedItemsCounts[2])
            {
                ListBoxSelectedItemsCounts[2] = listBox_largefamilychalets.SelectedIndices.Count;
                ListBoxSelectedChalets = new string[ListBoxSelectedItemsCounts[0] + ListBoxSelectedItemsCounts[1] + ListBoxSelectedItemsCounts[2]];
                int count = 0;
                foreach (int Chalet in listBox_normalchalets.SelectedIndices)
                {
                    ListBoxSelectedChalets[count] = Chalets[Chalet, 0];
                    count++;
                }
                foreach (int Chalet in listBox_familychalets.SelectedIndices)
                {
                    ListBoxSelectedChalets[count] = Chalets[Chalet, 1];
                    count++;
                }
                foreach (int Chalet in listBox_largefamilychalets.SelectedIndices)
                {
                    ListBoxSelectedChalets[count] = Chalets[Chalet, 2];
                    count++;
                }
            }

            button_setnormalchalet.Enabled = false;
            button_setfamilychalet.Enabled = false;
            button_setlargefamilychalet.Enabled = false;
            if (ListBoxSelectedItemsCounts[0] > 0)
            {
                button_setfamilychalet.Enabled = true;
                button_setlargefamilychalet.Enabled = true;
            }
            if (ListBoxSelectedItemsCounts[1] > 0)
            {
                button_setnormalchalet.Enabled = true;
                button_setlargefamilychalet.Enabled = true;
            }
            if (ListBoxSelectedItemsCounts[2] > 0)
            {
                button_setnormalchalet.Enabled = true;
                button_setfamilychalet.Enabled = true;
            }
        }

        private void button_setnormalchalet_Click(object sender, EventArgs e)
        {
            ListBoxScrollPositions[0] = listBox_normalchalets.TopIndex;
            ListBoxScrollPositions[1] = listBox_familychalets.TopIndex;
            ListBoxScrollPositions[2] = listBox_largefamilychalets.TopIndex;

            foreach (string Chalet in ListBoxSelectedChalets)
            {
                MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`chalets` SET `Maximum Number of Cats` = '2' WHERE `Chalet` = '" + Chalet + "';", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                MyGlobalClass.new_connection.Close();
            }

            Chalets = new string[MyGlobalClass.totalchalets, 3];
            numericUpDown_numberofchalets.Value = MyGlobalClass.totalchalets;

            int normal = 0;
            int family = 0;
            int large = 0;

            listBox_normalchalets.SelectedIndex = -1;
            listBox_familychalets.SelectedIndex = -1;
            listBox_largefamilychalets.SelectedIndex = -1;
            listBox_normalchalets.Items.Clear();
            listBox_familychalets.Items.Clear();
            listBox_largefamilychalets.Items.Clear();
            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`chalets`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                if (MyGlobalClass.SQL_Alter_Database["Maximum Number of Cats"].ToString() == "2")
                {
                    Chalets[normal, 0] = MyGlobalClass.SQL_Alter_Database["Chalet"].ToString();
                    normal++;
                }
                else if (MyGlobalClass.SQL_Alter_Database["Maximum Number of Cats"].ToString() == "4")
                {
                    Chalets[family, 1] = MyGlobalClass.SQL_Alter_Database["Chalet"].ToString();
                    family++;
                }
                else if (MyGlobalClass.SQL_Alter_Database["Maximum Number of Cats"].ToString() == "6")
                {
                    Chalets[large, 2] = MyGlobalClass.SQL_Alter_Database["Chalet"].ToString();
                    large++;
                }
            }
            MyGlobalClass.new_connection.Close();

            for (int i = 0; i < normal; i++)
            {
                listBox_normalchalets.Items.Add("Chalet " + Chalets[i, 0] + "");
            }
            for (int i = 0; i < family; i++)
            {
                listBox_familychalets.Items.Add("Chalet " + Chalets[i, 1] + "");
            }
            for (int i = 0; i < large; i++)
            {
                listBox_largefamilychalets.Items.Add("Chalet " + Chalets[i, 2] + "");
            }

            listBox_normalchalets.TopIndex = ListBoxScrollPositions[0];
            listBox_familychalets.TopIndex = ListBoxScrollPositions[1];
            listBox_largefamilychalets.TopIndex = ListBoxScrollPositions[2];
        }

        private void button_setfamilychalet_Click(object sender, EventArgs e)
        {
            ListBoxScrollPositions[0] = listBox_normalchalets.TopIndex;
            ListBoxScrollPositions[1] = listBox_familychalets.TopIndex;
            ListBoxScrollPositions[2] = listBox_largefamilychalets.TopIndex;

            foreach (string Chalet in ListBoxSelectedChalets)
            {
                MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`chalets` SET `Maximum Number of Cats` = '4' WHERE `Chalet` = '" + Chalet + "';", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open(); //The chalet table is updated
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                MyGlobalClass.new_connection.Close();
            }

            Chalets = new string[MyGlobalClass.totalchalets, 3]; //Updating the 'Backup' form to show the change
            numericUpDown_numberofchalets.Value = MyGlobalClass.totalchalets;

            int normal = 0;
            int family = 0;
            int large = 0;

            listBox_normalchalets.SelectedIndex = -1;
            listBox_familychalets.SelectedIndex = -1;
            listBox_largefamilychalets.SelectedIndex = -1;
            listBox_normalchalets.Items.Clear();
            listBox_familychalets.Items.Clear();
            listBox_largefamilychalets.Items.Clear();
            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`chalets`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                if (MyGlobalClass.SQL_Alter_Database["Maximum Number of Cats"].ToString() == "2")
                {
                    Chalets[normal, 0] = MyGlobalClass.SQL_Alter_Database["Chalet"].ToString();
                    normal++;
                }
                else if (MyGlobalClass.SQL_Alter_Database["Maximum Number of Cats"].ToString() == "4")
                {
                    Chalets[family, 1] = MyGlobalClass.SQL_Alter_Database["Chalet"].ToString();
                    family++;
                }
                else if (MyGlobalClass.SQL_Alter_Database["Maximum Number of Cats"].ToString() == "6")
                {
                    Chalets[large, 2] = MyGlobalClass.SQL_Alter_Database["Chalet"].ToString();
                    large++;
                }
            }
            MyGlobalClass.new_connection.Close();

            for (int i = 0; i < normal; i++)
            {
                listBox_normalchalets.Items.Add("Chalet " + Chalets[i, 0] + "");
            }
            for (int i = 0; i < family; i++)
            {
                listBox_familychalets.Items.Add("Chalet " + Chalets[i, 1] + "");
            }
            for (int i = 0; i < large; i++)
            {
                listBox_largefamilychalets.Items.Add("Chalet " + Chalets[i, 2] + "");
            }

            listBox_normalchalets.TopIndex = ListBoxScrollPositions[0];
            listBox_familychalets.TopIndex = ListBoxScrollPositions[1];
            listBox_largefamilychalets.TopIndex = ListBoxScrollPositions[2];
        }

        private void button_setlargefamilychalet_Click(object sender, EventArgs e)
        {
            ListBoxScrollPositions[0] = listBox_normalchalets.TopIndex;
            ListBoxScrollPositions[1] = listBox_familychalets.TopIndex;
            ListBoxScrollPositions[2] = listBox_largefamilychalets.TopIndex;

            foreach (string Chalet in ListBoxSelectedChalets)
            {
                MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`chalets` SET `Maximum Number of Cats` = '6' WHERE `Chalet` = '" + Chalet + "';", MyGlobalClass.new_connection);
                MyGlobalClass.new_connection.Open();
                MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                MyGlobalClass.new_connection.Close();
            }

            Chalets = new string[MyGlobalClass.totalchalets, 3];
            numericUpDown_numberofchalets.Value = MyGlobalClass.totalchalets;

            int normal = 0;
            int family = 0;
            int large = 0;

            listBox_normalchalets.SelectedIndex = -1;
            listBox_familychalets.SelectedIndex = -1;
            listBox_largefamilychalets.SelectedIndex = -1;
            listBox_normalchalets.Items.Clear();
            listBox_familychalets.Items.Clear();
            listBox_largefamilychalets.Items.Clear();
            MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`chalets`;", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            while (MyGlobalClass.SQL_Alter_Database.Read())
            {
                if (MyGlobalClass.SQL_Alter_Database["Maximum Number of Cats"].ToString() == "2")
                {
                    Chalets[normal, 0] = MyGlobalClass.SQL_Alter_Database["Chalet"].ToString();
                    normal++;
                }
                else if (MyGlobalClass.SQL_Alter_Database["Maximum Number of Cats"].ToString() == "4")
                {
                    Chalets[family, 1] = MyGlobalClass.SQL_Alter_Database["Chalet"].ToString();
                    family++;
                }
                else if (MyGlobalClass.SQL_Alter_Database["Maximum Number of Cats"].ToString() == "6")
                {
                    Chalets[large, 2] = MyGlobalClass.SQL_Alter_Database["Chalet"].ToString();
                    large++;
                }
            }
            MyGlobalClass.new_connection.Close();

            for (int i = 0; i < normal; i++)
            {
                listBox_normalchalets.Items.Add("Chalet " + Chalets[i, 0] + "");
            }
            for (int i = 0; i < family; i++)
            {
                listBox_familychalets.Items.Add("Chalet " + Chalets[i, 1] + "");
            }
            for (int i = 0; i < large; i++)
            {
                listBox_largefamilychalets.Items.Add("Chalet " + Chalets[i, 2] + "");
            }

            listBox_normalchalets.TopIndex = ListBoxScrollPositions[0];
            listBox_familychalets.TopIndex = ListBoxScrollPositions[1];
            listBox_largefamilychalets.TopIndex = ListBoxScrollPositions[2];
        }

        private void button_restore_backup_Click(object sender, EventArgs e)
        {
            if (checkdirectoryvalidation(text_backupdirectory_backup.Text) == true && checkdirectoryvalidation(text_restoredirectory_backup.Text) == true)
            {
                if (MessageBox.Show("Are you sure you wish to restore the Chichester Cattery Booking System?", "Restore", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string backupdirectory = text_backupdirectory_backup.Text;
                    string restoredirectory = text_restoredirectory_backup.Text;
                    progressBar_restore.Enabled = true;
                    progressBar_restore.Visible = true;
                    progressBar_restore.Value = 0;
                    try
                    {
                        backup(progressBar_restore);
                        string report = restore();
                        progressBar_restore.Value = 100;
                        MessageBox.Show("Chichester Cattery Booking System Sucessfully Restored." + report + "", "Restore Successful", MessageBoxButtons.OK);
                        form_backupandchalets_Load(sender, e);
                    }
                    catch
                    {
                        MessageBox.Show("Unfortunately, Chichester Cattery Booking System was not sucessfully Restored", "Restore Unsuccessful", MessageBoxButtons.OK);
                        MyGlobalClass.new_connection.Close();
                    }
                    progressBar_restore.Enabled = false;
                    progressBar_restore.Visible = false;
                    text_backupdirectory_backup.Text = backupdirectory;
                    text_restoredirectory_backup.Text = restoredirectory;
                }
            }
            else
            {
                if (checkdirectoryvalidation(text_backupdirectory_backup.Text) == false)
                {
                    MessageBox.Show("Invalid Backup Directory. Please enter a directory in the correct form.", "Invalid Backup Directory", MessageBoxButtons.OK);
                }
                if (checkdirectoryvalidation(text_restoredirectory_backup.Text) == false)
                {
                    MessageBox.Show("Invalid Restore Directory. Please enter a directory in the correct form.", "Invalid Restore Directory", MessageBoxButtons.OK);
                }
            }
        }

        private void button_printregistrationsandbookings_backup_Click(object sender, EventArgs e)
        {
            if (button_printregistrationsandbookings_backup.Text != "Opening Document... (Click to Confirm)")
            {
                button_printregistrationsandbookings_backup.Text = "Opening Document... (Click to Confirm)";
                button_printregistrationsandbookings_backup.Font = new Font(Font.FontFamily.Name, 13);
                string[] printdocument = new string[0];
                string[,] registrations = MyGlobalClass.FillQuery(null, false, false, false);
                printdocument = new string[registrations.GetLength(0)];
                for (int registration = 0; registration < printdocument.GetLength(0); registration++)
                {
                    printdocument[registration] = "Registration:\r\n";
                    printdocument[registration] = printdocument[registration] + MyGlobalClass.retrieveregistrationdata(registrations[registration, 1], false);
                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`registrations` WHERE `Registration ID` = '" + registrations[registration, 1] + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        printdocument[registration] = printdocument[registration] + "\r\nExtra Information: " + MyGlobalClass.SQL_Alter_Database["Extra Information"].ToString() + "\r\n";
                    }
                    MyGlobalClass.new_connection.Close();

                    int identifier = 0;
                    MyGlobalClass.SQL_Command = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`bookings` WHERE `Registration ID` = '" + registrations[registration, 1] + "';", MyGlobalClass.new_connection);
                    MyGlobalClass.new_connection.Open();
                    MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
                    while (MyGlobalClass.SQL_Alter_Database.Read())
                    {
                        string bookingstring = "";
                        string arrivaldate = DateTime.Parse(MyGlobalClass.SQL_Alter_Database["Arrival Date"].ToString()).ToString("dd/MM/yyyy");
                        string departuredate = DateTime.Parse(MyGlobalClass.SQL_Alter_Database["Departure Date"].ToString()).ToString("dd/MM/yyyy");
                        string catsstaying = "";
                        string chalet = MyGlobalClass.SQL_Alter_Database["Chalet"].ToString();
                        string arrivaltime = "";
                        string departuretime = "";
                        string vaccinations = "";
                        int count = 0;
                        for (int i = 1; i <= 6; i++)
                        {
                            if (MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString() != "NULL")
                            {
                                if (count == 0)
                                {
                                    catsstaying = MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString();
                                }
                                else
                                {
                                    catsstaying = catsstaying + ", " + MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString() + "";
                                }
                                count++;
                            }
                        }

                        MySqlConnection newconnection = new MySqlConnection(MyGlobalClass.connection_to_database);
                        MySqlCommand sqlcommand = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`arrival/departure times` WHERE `Arrival/Departure Time ID` = '" + MyGlobalClass.SQL_Alter_Database["Arrival Time ID"].ToString() + "';", newconnection);
                        newconnection.Open();
                        MySqlDataReader sqlalterdatabase = sqlcommand.ExecuteReader();
                        while (sqlalterdatabase.Read())
                        {
                            arrivaltime = sqlalterdatabase["Arrival/Departure Time"].ToString();
                        }
                        newconnection.Close();

                        newconnection = new MySqlConnection(MyGlobalClass.connection_to_database);
                        sqlcommand = new MySqlCommand("SELECT * FROM `chichester_cattery_booking_system`.`arrival/departure times` WHERE `Arrival/Departure Time ID` = '" + MyGlobalClass.SQL_Alter_Database["Departure Time ID"].ToString() + "';", newconnection);
                        newconnection.Open();
                        sqlalterdatabase = sqlcommand.ExecuteReader();
                        while (sqlalterdatabase.Read())
                        {
                            departuretime = sqlalterdatabase["Arrival/Departure Time"].ToString();
                        }
                        newconnection.Close();

                        count = 0;
                        for (int i = 1; i <= 6; i++)
                        {
                            try
                            {
                                bool check = Convert.ToBoolean(MyGlobalClass.SQL_Alter_Database["Cat " + i + " Vaccination"]);
                            }
                            catch
                            {
                                if (count == 0)
                                {
                                    vaccinations = "Vaccinations done for " + MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString() + "";
                                }
                                else
                                {
                                    vaccinations = vaccinations + ", " + MyGlobalClass.SQL_Alter_Database["Cat " + i + " Staying"].ToString() + "";
                                }
                                count++;
                            }
                        }

                        bookingstring = "" + arrivaldate + " to " + departuredate + ": " + catsstaying + "\r\nChalet: " + chalet + "\r\n";
                        bool arrival = false;
                        if (arrivaltime != "")
                        {
                            bookingstring = bookingstring + "Arrival Time: " + arrivaltime + "";
                            arrival = true;
                        }
                        if (departuretime != "")
                        {
                            if (arrival == true)
                            {
                                bookingstring = bookingstring + "\t";
                            }
                            bookingstring = bookingstring + "Departure Time: " + departuretime + "";
                        }
                        if (vaccinations != "")
                        {
                            bookingstring = bookingstring + "\r\n" + vaccinations + "";
                        }

                        if (identifier == 0)
                        {
                            printdocument[registration] = printdocument[registration] + "\r\nBookings:\r\n";
                            printdocument[registration] = printdocument[registration] + bookingstring;
                        }
                        else
                        {
                            printdocument[registration] = printdocument[registration] + "\r\n\r\n" + bookingstring + "";
                        }
                        identifier++;
                    }
                    MyGlobalClass.new_connection.Close();

                    if (registration < printdocument.GetLength(0) - 1)
                    {
                        printdocument[registration] = printdocument[registration] + "\r\n\r\n";
                    }
                }

                if (checkdirectoryvalidation(text_backupdirectory_backup.Text) == true)
                {
                    string directory = text_backupdirectory_backup.Text + "\\PRINTS\\PRINT " + DateTime.Now.ToString(@"yyyy-MM-dd  HH\ºmm\'ss\'\'") + "";
                    System.IO.Directory.CreateDirectory(@directory);
                    FileIOPermission permissions = new FileIOPermission(FileIOPermissionAccess.Read, directory);
                    permissions.AddPathList(FileIOPermissionAccess.Write | FileIOPermissionAccess.Read, directory + "\\PrintFile.doc");

                    try
                    {
                        permissions.Demand();
                    }
                    catch (System.Security.SecurityException s)
                    {
                        Console.WriteLine(s.Message);
                    }

                    System.IO.File.WriteAllLines(@"" + directory + "\\PrintFile.doc", printdocument);
                    System.Diagnostics.Process.Start(@"" + directory + "\\PrintFile.doc");
                }
                else
                {
                    MessageBox.Show("Invalid Backup Directory. Please enter a directory in the correct form.", "Invalid Backup Directory", MessageBoxButtons.OK);
                    button_printregistrationsandbookings_backup.Text = "Print Registrations and Bookings";
                    button_printregistrationsandbookings_backup.Font = new Font(Font.FontFamily.Name, 16);
                }
            }
            else
            {
                button_printregistrationsandbookings_backup.Text = "Print Registrations and Bookings";
                button_printregistrationsandbookings_backup.Font = new Font(Font.FontFamily.Name, 16);
            }
        }

        private void button_connectionsettings_backup_Click(object sender, EventArgs e)
        {
            MyGlobalClass.offsetconnectionsettings = true;
            var newform = new form_connectionsettings();
            bool found = false;
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                Form openform = Application.OpenForms[i];
                if (openform.Name == newform.Name)
                {
                    newform.Close();
                    openform.BringToFront();
                    found = true;
                }
            }
            if (found == false)
            {
                newform.ShowDialog(this);
            }
        }

        private bool checkdirectoryvalidation(string directory)
        {
            bool validity = false;
            for (int charpointer = 0; charpointer < directory.Length; charpointer++)//Check for a lack text in directory text box
            {
                if (Char.IsLetter(directory, charpointer))
                {
                    validity = true;
                }
            }
            try
            {
                FileIOPermission permissions = new FileIOPermission(FileIOPermissionAccess.Read, directory);
                permissions.Demand();
            }
            catch
            {
                validity = false;
            }

            return validity;
        }

        private void text_restoredirectory_backup_TextChanged(object sender, EventArgs e)
        {
            string directory = text_restoredirectory_backup.Text.Replace('\\', '|');
            char[] chararray = directory.ToCharArray();
            char[] resizedchararray = new char[0];
            int count = 0;
            for (int i = 0; i < chararray.GetLength(0); i++)
            {
                if (chararray[i] == 'º' || chararray[i] == '\'')
                {
                    count++;
                }
            }
            resizedchararray = new char[(chararray.GetLength(0) + count)];
            count = 0;

            for (int i = 0; i < chararray.GetLength(0); i++)
            {
                if (chararray[i] == 'º')
                {
                    resizedchararray[count] = '\\';
                    count++;
                    resizedchararray[count] = 'º';
                    count++;
                }
                else if (chararray[i] == '\'')
                {
                    resizedchararray[count] = '\\';
                    count++;
                    resizedchararray[count] = '\'';
                    count++;
                }
                else
                {
                    resizedchararray[count] = chararray[i];
                    count++;
                }
            }
            directory = new string(resizedchararray);
            count = 0;

            MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`backup directories` SET `Restore Directory`='" + directory + "' WHERE `ID`='1';", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            MyGlobalClass.new_connection.Close();
        }

        private void text_backupdirectory_backup_TextChanged(object sender, EventArgs e)
        {
            MyGlobalClass.SQL_Command = new MySqlCommand("UPDATE `chichester_cattery_booking_system`.`backup directories` SET `Backup Directory`= '" + text_backupdirectory_backup.Text.Replace('\\', '|') + "' WHERE `ID` = '1';", MyGlobalClass.new_connection);
            MyGlobalClass.new_connection.Open();
            MyGlobalClass.SQL_Alter_Database = MyGlobalClass.SQL_Command.ExecuteReader();
            MyGlobalClass.new_connection.Close();
        }
    }
}
