# Equipment Rental Service Database Project

## Description

This database project aims to design and implement a comprehensive system for an equipment rental service. The system will facilitate the management of equipment inventory, customer information, rental transactions, and other related data.

## Technologies

- Database Management System: SqlServer

- Programming Language: C#

- Frameworks and Libraries: .NETFramework

## How to test on your local machine

The code is ready to test on the IEETA database.
If you want to test it with your database you should go to the **Globals.cs** file and change the value of the variable **strConn** to your connection string.

**IMPORTANT NOTE:** Since we are using an hash function to store the user's passwords on the database and our authentication function also uses it, the users we inserted in the db for demonstration **will not work** so you should use the **Signup Form** to create your account on the system and then use it as normal.
The admin and Técnico accounts work with the ones stored in the Admin and TecnicoEquipamento tables.

## Super credentials

- admin: admin.um@example.com; senha1
- tecnico: tecnico1@example.com; senhatec1
  

## Project Team

- Beatriz Ferreira
- Diogo Pires


