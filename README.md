<h1 align="center">
  <img src="https://github.com/robertdelacy/cattery-booking-system/raw/master/Chichester Cattery Logo.jpg" alt="Chichester Cattery" width="500">
  <br>
  Cattery Booking System
  <br>
</h1>

<h4 align="center">A Booking System for a local Cattery, intended to upgrade a pencil-and-paper system whilst improving the efficiency of allocating 'Chalets'.</h4>

## Features

- Registration System for Families and their Cats
- Booking System to add bookings for stays at the Cattery
- 'Potential Changes' looks for any moving of bookings that would improve the efficiency of future chalet allocations.
- Ability to back up the system as a digital backup for restoring or a printable document

## Install

The System uses a MySQL database.

- Install and setup [MySQL](https://dev.mysql.com/downloads/windows/installer/8.0.html)
- Open and run 'Chichester Cattery Booking Database Set-up' in MySQL Workbench

You can build from a clone:

```sh
git clone https://github.com/robertdelacy/cattery-booking-system
```

Once built, a binary for the system will appear at `Solution/bin/debug/Chichester Cattery Booking System`.

## Config

Before using the system, the connection settings need to be set up. The Data Source, Port and Username can be found on the MySQL Workbench
and the password was given during the MySQL setup.

The Chalets also need to be set up. Set the number of Chalets, then move the Chalets to their correct type:

- Normal: 2 Cats
- Family: 4 Cats
- Large Family: 6 Cats
