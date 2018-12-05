CREATE SCHEMA `Chichester_Cattery_Booking_System`; -- Creates Database
CREATE TABLE `Chichester_Cattery_Booking_System`.`Contact Names` ( -- Creates Table
`Contact Name ID` INT(11) AUTO_INCREMENT,
`Contact Name` VARCHAR(45) NULL,
PRIMARY KEY (`Contact Name ID`),
INDEX `Contact Name` (`Contact Name` ASC),
UNIQUE INDEX `Contact Name ID UNIQUE` (`Contact Name ID` ASC));
CREATE TABLE `Chichester_Cattery_Booking_System`.`Contact Telephones`(
`Contact Telephone ID` INT(11) AUTO_INCREMENT,
`Contact Telephone` VARCHAR(45) NULL,
PRIMARY KEY (`Contact Telephone ID`),
INDEX `Contact Telephone` (`Contact Telephone` ASC),
UNIQUE INDEX `Contact Telephone ID UNIQUE` (`Contact Telephone ID` ASC));
CREATE TABLE `Chichester_Cattery_Booking_System`.`Cat Names` (
`Cat Name ID` INT(11) AUTO_INCREMENT,
`Cat Name` VARCHAR(45) NULL,
PRIMARY KEY (`Cat Name ID`),
INDEX `Cat Name` (`Cat Name` ASC),
UNIQUE INDEX `Cat Name ID UNIQUE` (`Cat Name ID` ASC));
CREATE TABLE `Chichester_Cattery_Booking_System`.`Sexes` (
`Sex ID` INT(11) AUTO_INCREMENT,
`Sex` VARCHAR(10) NULL,
PRIMARY KEY (`Sex ID`),
INDEX `Sex` (`Sex` ASC),
UNIQUE INDEX `Sex ID UNIQUE` (`Sex ID` ASC));
CREATE TABLE `Chichester_Cattery_Booking_System`.`Descriptions` (
`Description ID` INT(11) AUTO_INCREMENT,
`Description` VARCHAR(45) NULL,
PRIMARY KEY (`Description ID`),
INDEX `Description` (`Description` ASC),
UNIQUE INDEX `Description ID UNIQUE` (`Description ID` ASC));
CREATE TABLE `Chichester_Cattery_Booking_System`.`Foods` (
`Food ID` INT(11) AUTO_INCREMENT,
`Food` VARCHAR(45) NULL,
PRIMARY KEY (`Food ID`),
INDEX `Food` (`Food` ASC),
UNIQUE INDEX `Food ID UNIQUE` (`Food ID` ASC));
CREATE TABLE `Chichester_Cattery_Booking_System`.`Cats`(
`Cat ID` INT(11) AUTO_INCREMENT,
`Cat Name ID` INT(11),
`Date Of Birth` DATE,
`Sex ID` INT(11),
`Next Vaccination Date` DATE,
`Description ID` INT(11),
`Food ID` INT(11),
`Foods To Be Avoided` VARCHAR(100) NULL,
`Allergies` VARCHAR(100) NULL,
`Special Treatment` VARCHAR(100) NULL,
PRIMARY KEY (`Cat ID`),
CONSTRAINT `Cat Name` FOREIGN KEY (`Cat Name ID`)
REFERENCES `Chichester_Cattery_Booking_System`.`Cat Names` (`Cat Name ID`),
CONSTRAINT `Sex` FOREIGN KEY (`Sex ID`)
REFERENCES `Chichester_Cattery_Booking_System`.`Sexes` (`Sex ID`),
CONSTRAINT `Description` FOREIGN KEY (`Description ID`)
REFERENCES `Chichester_Cattery_Booking_System`.`Descriptions` (`Description ID`),
CONSTRAINT `Food` FOREIGN KEY (`Food ID`)
REFERENCES `Chichester_Cattery_Booking_System`.`Foods` (`Food ID`),
INDEX `Dates` (`Date Of Birth` ASC, `Next Vaccination Date` ASC),
INDEX `Special Treatments` (`Foods To Be Avoided` ASC, `Allergies` ASC, `Special Treatment` ASC),
INDEX `Other Details` (`Cat Name ID` ASC, `Sex ID` ASC, `Description ID` ASC, `Food ID` ASC),
  UNIQUE INDEX `Cat ID UNIQUE` (`Cat ID` ASC));
CREATE TABLE `Chichester_Cattery_Booking_System`.`Absence Contacts` (
`Absence Contact ID` INT(11) AUTO_INCREMENT,
`Contact Name ID` INT(11),
`Contact Telephone ID` INT(11),
PRIMARY KEY (`Absence Contact ID`),
CONSTRAINT `Contact Name` FOREIGN KEY (`Contact Name ID`)
REFERENCES `Chichester_Cattery_Booking_System`.`Contact Names` (`Contact Name ID`),
CONSTRAINT `Contact Telephone` FOREIGN KEY (`Contact Telephone ID`)
REFERENCES `Chichester_Cattery_Booking_System`.`Contact Telephones` (`Contact Telephone ID`),
INDEX `Absence Contact` (`Contact Name ID` ASC, `Contact Telephone ID` ASC),
UNIQUE INDEX `Absence Contact ID UNIQUE` (`Absence Contact ID` ASC));
CREATE TABLE `Chichester_Cattery_Booking_System`.`Vets` (
`Vet ID` INT(11) AUTO_INCREMENT,
`Contact Name ID` INT(11),
`Contact Telephone ID` INT(11),
PRIMARY KEY (`Vet ID`),
CONSTRAINT `Vet Name` FOREIGN KEY (`Contact Name ID`)
REFERENCES `Chichester_Cattery_Booking_System`.`Contact Names` (`Contact Name ID`),
CONSTRAINT `Vet Telephone` FOREIGN KEY (`Contact Telephone ID`)
REFERENCES `Chichester_Cattery_Booking_System`.`Contact Telephones` (`Contact Telephone ID`),
INDEX `Vet` (`Contact Name ID` ASC, `Contact Telephone ID` ASC),
UNIQUE INDEX `Vet ID UNIQUE` (`Vet ID` ASC));
CREATE TABLE `Chichester_Cattery_Booking_System`.`Postcodes`(
`Postcode ID` INT(11) AUTO_INCREMENT,
`Postcode` VARCHAR(8) NULL,
PRIMARY KEY (`Postcode ID`),
INDEX `Postcode`(`Postcode` ASC),
UNIQUE INDEX `Postcode ID UNIQUE` (`Postcode ID` ASC));
CREATE TABLE `Chichester_Cattery_Booking_System`.`Towns`(
`Town ID` INT(11) AUTO_INCREMENT,
`Town` VARCHAR(100) NULL,
PRIMARY KEY (`Town ID`),
INDEX `Town`(`Town` ASC),
UNIQUE INDEX `Town ID UNIQUE` (`Town ID` ASC));
CREATE TABLE `Chichester_Cattery_Booking_System`.`Addresses`(
`Address ID` INT(11) AUTO_INCREMENT,
`Address` VARCHAR(100) NULL,
`Town ID` INT(11),
`Postcode ID` INT(11),
PRIMARY KEY (`Address ID`),
CONSTRAINT `Postcode` FOREIGN KEY (`Postcode ID`)
REFERENCES chichester_cattery_booking_system.postcodes (`Postcode ID`),
CONSTRAINT `Town` FOREIGN KEY (`Town ID`)
REFERENCES chichester_cattery_booking_system.towns (`Town ID`),
INDEX `Address` (`Address` ASC, `Town ID` ASC, `Postcode ID` ASC),
  UNIQUE INDEX `Address ID UNIQUE` (`Address ID` ASC));
CREATE TABLE `Chichester_Cattery_Booking_System`.`Registrations`( 
`Registration ID` INT(11) AUTO_INCREMENT,
  `Owner 1 ID` INT(11),
  `Owner 2 ID` INT(11),
  `Owner 3 ID` INT(11),
  `Owner 4 ID` INT(11),
  `Owner 5 ID` INT(11),
  `Owner 6 ID` INT(11),
  `Address ID` INT (11),
  `Home Telephone ID` INT(11),
  `Mobile 1 ID` INT(11),
  `Mobile 2 ID` INT(11),
  `Mobile 3 ID` INT(11),
  `Mobile 4 ID` INT(11),
  `Mobile 5 ID` INT(11),
  `Mobile 6 ID` INT(11),
  `Cat 1 ID` INT(11),
  `Cat 2 ID` INT(11),
  `Cat 3 ID` INT(11),
  `Cat 4 ID` INT(11),
  `Cat 5 ID` INT(11),
  `Cat 6 ID` INT(11),
  `Absence Contact ID` INT(11),
  `Vet ID` INT(11),
  `Extra Information` VARCHAR(200) NULL,
PRIMARY KEY (`Registration ID`),
CONSTRAINT `Owner 1` FOREIGN KEY (`Owner 1 ID`)
REFERENCES `chichester_cattery_booking_system`.`Contact Names` (`Contact Name ID`),
CONSTRAINT `Owner 2` FOREIGN KEY (`Owner 2 ID`)
REFERENCES `chichester_cattery_booking_system`.`Contact Names` (`Contact Name ID`),
CONSTRAINT `Owner 3` FOREIGN KEY (`Owner 3 ID`)
REFERENCES `chichester_cattery_booking_system`.`Contact Names` (`Contact Name ID`),
CONSTRAINT `Owner 4` FOREIGN KEY (`Owner 4 ID`)
REFERENCES `chichester_cattery_booking_system`.`Contact Names` (`Contact Name ID`),
CONSTRAINT `Owner 5` FOREIGN KEY (`Owner 5 ID`)
REFERENCES `chichester_cattery_booking_system`.`Contact Names` (`Contact Name ID`),
CONSTRAINT `Owner 6` FOREIGN KEY (`Owner 6 ID`)
REFERENCES `chichester_cattery_booking_system`.`Contact Names` (`Contact Name ID`),
CONSTRAINT `Address` FOREIGN KEY (`Address ID`)
REFERENCES chichester_cattery_booking_system.addresses (`Address ID`),
CONSTRAINT `Home Telephone` FOREIGN KEY (`Home Telephone ID`)
REFERENCES `Chichester_Cattery_Booking_System`.`Contact Telephones` (`Contact Telephone ID`),
CONSTRAINT `Mobile 1` FOREIGN KEY (`Mobile 1 ID`)
REFERENCES `Chichester_Cattery_Booking_System`.`Contact Telephones` (`Contact Telephone ID`),
CONSTRAINT `Mobile 2` FOREIGN KEY (`Mobile 2 ID`)
REFERENCES `Chichester_Cattery_Booking_System`.`Contact Telephones` (`Contact Telephone ID`),
CONSTRAINT `Mobile 3` FOREIGN KEY (`Mobile 3 ID`)
REFERENCES `Chichester_Cattery_Booking_System`.`Contact Telephones` (`Contact Telephone ID`),
CONSTRAINT `Mobile 4` FOREIGN KEY (`Mobile 4 ID`)
REFERENCES `Chichester_Cattery_Booking_System`.`Contact Telephones` (`Contact Telephone ID`),
CONSTRAINT `Mobile 5` FOREIGN KEY (`Mobile 5 ID`)
REFERENCES `Chichester_Cattery_Booking_System`.`Contact Telephones` (`Contact Telephone ID`),
CONSTRAINT `Mobile 6` FOREIGN KEY (`Mobile 6 ID`)
REFERENCES `Chichester_Cattery_Booking_System`.`Contact Telephones` (`Contact Telephone ID`),
CONSTRAINT `Cat 1` FOREIGN KEY (`Cat 1 ID`)
REFERENCES `Chichester_Cattery_Booking_System`.`Cats` (`Cat ID`),
CONSTRAINT `Cat 2` FOREIGN KEY (`Cat 2 ID`)
REFERENCES `Chichester_Cattery_Booking_System`.`Cats` (`Cat ID`),
CONSTRAINT `Cat 3` FOREIGN KEY (`Cat 3 ID`)
REFERENCES `Chichester_Cattery_Booking_System`.`Cats` (`Cat ID`),
CONSTRAINT `Cat 4` FOREIGN KEY (`Cat 4 ID`)
REFERENCES `Chichester_Cattery_Booking_System`.`Cats` (`Cat ID`),
CONSTRAINT `Cat 5` FOREIGN KEY (`Cat 5 ID`)
REFERENCES `Chichester_Cattery_Booking_System`.`Cats` (`Cat ID`),
CONSTRAINT `Cat 6` FOREIGN KEY (`Cat 6 ID`)
REFERENCES `Chichester_Cattery_Booking_System`.`Cats` (`Cat ID`),
CONSTRAINT `Absence Contact` FOREIGN KEY (`Absence Contact ID`)
REFERENCES `Chichester_Cattery_Booking_System`.`Absence Contacts` (`Absence Contact ID`),
CONSTRAINT `Vet` FOREIGN KEY (`Vet ID`)
REFERENCES `Chichester_Cattery_Booking_System`.`Vets` (`Vet ID`),
INDEX `Owners` (`Owner 1 ID` ASC, `Owner 2 ID` ASC, `Owner 3 ID` ASC, `Owner 4 ID` ASC, `Owner 5 ID` ASC, `Owner 6 ID` ASC), -- Indexes Columns
INDEX `Contact Information` (`Address ID` ASC,`Home Telephone ID` ASC, `Mobile 1 ID` ASC, `Mobile 2 ID` ASC, `Mobile 3 ID` ASC, `Mobile 4 ID` ASC, `Mobile 5 ID` ASC, `Mobile 6 ID` ASC, `Absence Contact ID` ASC, `Vet ID` ASC),
INDEX `Other Registration Information` (`Cat 1 ID` ASC, `Cat 2 ID` ASC, `Cat 3 ID` ASC, `Cat 4 ID` ASC, `Cat 5 ID` ASC, `Cat 6 ID` ASC, `Extra Information` ASC),
  UNIQUE INDEX `Registration ID UNIQUE` (`Registration ID` ASC));
CREATE TABLE `Chichester_Cattery_Booking_System`.`Arrival/Departure Times`(
`Arrival/Departure Time ID` INT(11) AUTO_INCREMENT,
`Arrival/Departure Time` VARCHAR(45) NULL,
PRIMARY KEY (`Arrival/Departure Time ID`),
INDEX `Arrival/Departure Time` (`Arrival/Departure Time` ASC),
UNIQUE INDEX `Arrival/Departure Time ID UNIQUE` (`Arrival/Departure Time ID` ASC));
CREATE TABLE `Chichester_Cattery_Booking_System`.`Bookings`(
`Booking ID` INT(11) AUTO_INCREMENT,
`Registration ID` INT(11),
`Cat 1 Staying` VARCHAR(45) NULL,
`Cat 2 Staying` VARCHAR(45) NULL,
`Cat 3 Staying` VARCHAR(45) NULL,
`Cat 4 Staying` VARCHAR(45) NULL,
`Cat 5 Staying` VARCHAR(45) NULL,
`Cat 6 Staying` VARCHAR(45) NULL,
`Arrival Date` DATE,
`Departure Date` DATE,
`Arrival Time ID` INT(11),
`Departure Time ID` INT(11),
`Checked In` BOOL,
`Checked Out` BOOL,
`Chalet` INT(5),
`Cat 1 Vaccination` BOOL,
`Cat 2 Vaccination` BOOL,
`Cat 3 Vaccination` BOOL,
`Cat 4 Vaccination` BOOL,
`Cat 5 Vaccination` BOOL,
`Cat 6 Vaccination` BOOL,
PRIMARY KEY (`Booking ID`),
CONSTRAINT `Registration` FOREIGN KEY (`Registration ID`)
REFERENCES `chichester_cattery_booking_system`.`Registrations` (`Registration ID`),
CONSTRAINT `Arrival Time` FOREIGN KEY (`Arrival Time ID`)
REFERENCES `Chichester_Cattery_Booking_System`.`Arrival/Departure Times` (`Arrival/Departure Time ID`),
CONSTRAINT `Departure Time` FOREIGN KEY (`Departure Time ID`)
REFERENCES `Chichester_Cattery_Booking_System`.`Arrival/Departure Times` (`Arrival/Departure Time ID`),
INDEX `Other Details` (`Registration ID` ASC, `Checked In` ASC, `Checked Out` ASC, `Chalet` ASC),
INDEX `Cats Staying` (`Cat 1 Staying` ASC, `Cat 2 Staying` ASC, `Cat 3 Staying` ASC, `Cat 4 Staying` ASC,
`Cat 5 Staying` ASC, `Cat 6 Staying` ASC),
INDEX `Arrival and Departure` (`Arrival Date` ASC, `Departure Date` ASC,
`Arrival Time ID` ASC, `Departure Time ID` ASC),
INDEX `Vaccinations` (`Cat 1 Vaccination` ASC, `Cat 2 Vaccination` ASC,
`Cat 3 Vaccination` ASC, `Cat 4 Vaccination` ASC, `Cat 5 Vaccination` ASC, `Cat 6 Vaccination` ASC),
  UNIQUE INDEX `Booking ID UNIQUE` (`Booking ID` ASC));
CREATE TABLE `Chichester_Cattery_Booking_System`.`Backup Directories` (
`ID` INT(11) AUTO_INCREMENT,
`Backup Directory` VARCHAR(250) NULL,
`Restore Directory` VARCHAR(250) NULL,
`Total Chalets` INT(11) NULL,
PRIMARY KEY (`ID`),
INDEX `Directories` (`Backup Directory` ASC, `Restore Directory` ASC),
INDEX `Settings`(`Total Chalets` ASC),
UNIQUE INDEX `ID UNIQUE` (`ID` ASC));
CREATE TABLE `Chichester_Cattery_Booking_System`.`Chalets`(
`Chalet` INT(11),
`Maximum Number of Cats` INT(11) NULL,
PRIMARY KEY (`Chalet`),
INDEX `Max` (`Maximum Number of Cats` ASC),
UNIQUE INDEX `Chalet UNIQUE` (`Chalet` ASC));
CREATE TABLE `Chichester_Cattery_Booking_System`.`Potential Changes`(
`ID` INT(11) AUTO_INCREMENT,
`Booking ID` INT(11),
`New Chalet` INT(11),
`Arrival Date` DATE,
`Departure Date` DATE,
`Pair` INT(11),
PRIMARY KEY (`ID`),
INDEX `Change Information`(`Booking ID` ASC, `New Chalet` ASC, `Arrival Date` ASC, `Departure Date` ASC, `Pair` ASC),
UNIQUE INDEX `ID UNIQUE` (`ID` ASC));
INSERT INTO `chichester_cattery_booking_system`.`backup directories` (`Total Chalets`) VALUES ('0');