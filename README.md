# razor_sql

Basic Razor C# Project + SQL query

## Table of Contents

1. [Razor](#razor)
   1. [For Visual Studio](#for-visual-studio)
   2. [For VS Code or Terminal](#for-vs-code-or-terminal)
   3. [When then application is running](#when-the-application-is-running)
   4. [Car Page](#car-page)
   5. [Edit Page](#edit-page)
   6. [Guess Price Page](#guess-price-page)
   7. [Create New Page](#create-new-page)
2. [SQL](#sql)
   1. [The SQL file is `customers.sql`](#the-sql-file-is-customerssql)

## Razor

The Razor project is located on folder *"WebApplicationRazor"*.

To execute the Project open the *.sln* file on Visual Studio, the folder on VS Code or on terminal.

### For Visual Studio

Running in Visual Studio should follow the basic project Debug steps.

### For VS Code or Terminal

I didn't set up any VS Code debugger and just ran it on the integrated terminal :(

To do that, make sure you are on *"WebApplicationRazor"* folder and type `dotnet run`.

> You can use `dotnet watch` if you want to change something, save it and Dotnet will reload the project with those changes.
>
> This might not be so reliable if you change something on `Program.cs` or whatever the Dotnet cache decides it doesn't like too much.

### When the application is running

You'll be on the *Home Page*.

To see the Cars list use the navigation bar on top.

### Car Page

On this Page you have Cars information on a table and some actions to do with that row.

The price is hidden!

* *Edit* will take you to the edit page.

* *Guess Price* will take you to the page that let's you try and guess the price of that specific car.

* *Delete* will delete the car without any notice!

* *Show Price* will **show** or **hide** the price.

On the bottom of the table there's the *Create New* to take you to the creation page.

On the right side there's the *Reset all changes* button.
This will undo all changes done to the Cars list.

> All information is stored in memory.

And bellow is the *Back to Home Page* button to take you back to the starting page.

### Edit Page

This page shows all the information on `Input` fields so you can change it to whatever value, respecting its properties.

You can't change the ID since this is used to tie everything together.

*Save* button will copy the changes made to the main Cars list.

And *Back to List* takes you back to the Car list Page.

### Guess Price Page

This page shows the chosen car information and provides a input for you to type what price you think this car have.

Press *Try!* to see if you guessed correctly.

If it's not, the field is cleaned for you to try again and a red message appears.

If the price is between `plus 5000` or `minus 5000` you successfully guessed the price and a green message appears!

*Back to List* will take you back to the Car list Page.

### Create New Page

This page lists all Car properties for you to type new information.

> **All fields are required to create a new Car.**

*Save* button will append the new Car to the Cars list and it's ID will be the greatest on the list plus one.

At the end a green message will appear saying it was successful.

*Back to List* will take you back to the Car list Page.

## SQL

### The SQL file is `customers.sql`

First I clear the temporary tables and creates them.

Insert some mock data on the tables, that have information that can join correctly.

Selects Customer information joining with Order table and OrderDetail table where the OrderDetail *ProductID* matches.
