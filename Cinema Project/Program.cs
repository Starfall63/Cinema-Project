using System;
//Hello
namespace Cinema_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            //variables assigned at the start of the program
            bool valid = false;
            bool valid1 = false;
            string filmName = "";
            int film = 0;
            int ticketsRemaining1 = 80; //Number for ticketsRemaining is based on movie number
            int ticketsRemaining2 = 0;
            int ticketsRemaining3 = 80;
            int ticketsRemaining4 = 80;
            int ticketsRemaining5 = 80;
            DateTime Dob = DateTime.Today;
            TimeSpan ageRequired = TimeSpan.FromDays(1);
            TimeSpan daysAlive;
            DateTime watchDate = DateTime.Today.AddDays(8);
            int rowNumber = 0;
            int colNumber = 0;
            int day = 0;
            int[,,,] seating = new int[2, 5, 5, 7];//4D Array [row,column,film,day]
            int rowLength = seating.GetLength(0);
            int colLength = seating.GetLength(1);





            while (filmName == "")
            {
                if (ticketsRemaining1 == 0 && ticketsRemaining2 == 0 && ticketsRemaining3 == 0 && ticketsRemaining4 == 0 && ticketsRemaining5 == 0)
                {
                    Console.WriteLine("Sorry but we are sold out of tickets for the day");
                    break;
                }

                //Outputs the list of films to be shown and the tickets remaining
                Console.WriteLine("\n\nWelcome to Aquinas Multiplex\n" +
                "We are presently showing:\n" +
                "1. Teenage Horror film (15) {0} Tickets Remaining\n" +
                "2. How I live Now (15)      {1} Tickets Remaining\n" +
                "3. Another Marvel Film (12) {2} Tickets Remaining\n" +
                "4. Filth (18)               {3} Tickets Remaining\n" +
                "5. Planes(U)                {4} Tickets Remaining",
                ticketsRemaining1, ticketsRemaining2, ticketsRemaining3, ticketsRemaining4, ticketsRemaining5);

                Console.Write("Please select the number of the film that you would like to see:");
                do//While loop to validate the user input
                {
                    try
                    {
                        film = int.Parse(Console.ReadLine());//User selects the film they would like to see
                    }
                    catch
                    {
                        Console.WriteLine("Please enter valid number.");
                        film = 0;

                    }
                } while (film == 0);

                //Switch statement to change the filmName for the ticket and also they age restriction based on what the user chooses
                switch (film)
                {
                    case 1:
                        filmName = "Teenage Horror Film";
                        ageRequired = TimeSpan.FromDays(5475);
                        break;
                    case 2:
                        filmName = "How I Live Now";
                        ageRequired = TimeSpan.FromDays(5475);
                        break;
                    case 3:
                        ageRequired = TimeSpan.FromDays(4380);
                        filmName = "Another Marvel Film";
                        break;
                    case 4:
                        ageRequired = TimeSpan.FromDays(6570);
                        filmName = "Filth";
                        break;
                    case 5:
                        ageRequired = TimeSpan.FromDays(0);
                        filmName = "Planes";
                        break;
                    default:
                        Console.WriteLine("Please enter a valid movie.");
                        filmName = "";
                        break;


                }

                //Checks if film chosen is sold out
                if ((film == 1 && ticketsRemaining1 == 0) || (film == 2 && ticketsRemaining2 == 0) || (film == 3 && ticketsRemaining3 == 0) || (film == 4 && ticketsRemaining4 == 0) || (film == 5 && ticketsRemaining5 == 0))
                {
                    Console.WriteLine("Sorry this film is sold out please select another film." +
                        "\n Press any key to continue.");
                    Console.ReadKey();
                    filmName = "";
                    Console.Clear();
                }


                if (filmName != "")
                {
                    //Age check for user to make sure they are old enough to watch their chosen film; will loop back to start if they are not old enough
                    do//while loop to make sure user enters a valid date
                    {
                        Console.Write("Please enter your date of birth:");
                        try
                        {
                            Dob = DateTime.Parse(Console.ReadLine());
                        }

                        catch
                        {
                            Console.WriteLine("Please enter a valid date");
                            Dob = DateTime.Today;
                        }

                    } while (Dob == DateTime.Today);

                    daysAlive = DateTime.Today - Dob;

                    if (daysAlive < ageRequired)
                    {
                        Console.WriteLine("You are not old enough to watch this film please try another film." +
                            "\n Press any key to continue.");
                        Console.ReadKey();
                        filmName = "";
                        Console.Clear();

                    }
                    else
                    {
                        //User selects the date that they would like to watch the film
                        do
                        {
                            Console.Write("Please enter the date that you would like to watch the film:");
                            try
                            {
                                watchDate = DateTime.Parse(Console.ReadLine());
                                if (watchDate < DateTime.Today || watchDate > DateTime.Today.AddDays(7))
                                {
                                    Console.WriteLine("Please enter a valid date");
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Please enter a valid date");
                                DateTime.Today.AddDays(8);
                            }


                        } while (watchDate < DateTime.Today || watchDate > DateTime.Today.AddDays(7));

                        //Gets the correct seating for the correct day
                        if (watchDate == DateTime.Today)
                        {
                            day = 0;
                        }
                        else if (watchDate == DateTime.Today.AddDays(1))
                        {
                            day = 1;
                        }
                        else if (watchDate == DateTime.Today.AddDays(2))
                        {
                            day = 2;
                        }
                        else if (watchDate == DateTime.Today.AddDays(3))
                        {
                            day = 3;
                        }
                        else if (watchDate == DateTime.Today.AddDays(4))
                        {
                            day = 4;
                        }
                        else if (watchDate == DateTime.Today.AddDays(5))
                        {
                            day = 5;
                        }
                        else if (watchDate == DateTime.Today.AddDays(6))
                        {
                            day = 6;
                        }
                        else if (watchDate == DateTime.Today.AddDays(7))
                        {
                            day = 7;
                        }




                        //Displays the seats that are available for the user to choose
                        Console.WriteLine("Please select a seat that is free to sit in.\n (Seats marked as 1 are taken.) ");
                        Console.Write(" ");
                        for (int colNo = 0; colNo < colLength; colNo++)
                        {
                            Console.Write(" {0}", colNo + 1);
                        }
                        Console.WriteLine("");

                        for (int rowNo = 0; rowNo < rowLength; rowNo++)
                        {
                            Console.Write(rowNo + 1);
                            for (int colNo = 0; colNo < colLength; colNo++)
                            {
                                Console.Write(string.Format(" {0}", seating[rowNo, colNo, film - 1, day]));
                            }
                            Console.Write("\n");
                        }

                        //User selects valid seats to sit in
                        while (rowNumber == 0 && colNumber == 0)
                        {
                            while (valid == false || valid1 == false)
                            {
                                Console.Write("Row number:");
                                try
                                {
                                    rowNumber = int.Parse(Console.ReadLine());
                                    valid = true;
                                }
                                catch
                                {
                                    valid = false;
                                }
                                Console.Write("Column number:");
                                try
                                {
                                    colNumber = int.Parse(Console.ReadLine());
                                    valid1 = true;
                                }
                                catch
                                {
                                    valid1 = false;
                                }
                                if (valid == false || valid1 == false)
                                {
                                    Console.WriteLine("Please enter a valid seat number.");
                                }
                            }
                            if (rowNumber > rowLength || colNumber > colLength)
                            {
                                Console.WriteLine("Please enter a valid seat number.");
                                rowNumber = 0;
                                colNumber = 0;
                            }
                            else if ((seating[(rowNumber - 1), (colNumber - 1), film - 1, day] != 0))
                            {
                                Console.WriteLine("Sorry this seat is taken please select another seat.");
                                rowNumber = 0;
                                colNumber = 0;

                            }
                            valid = false;
                            valid1 = false;
                        }




                        //Prints out ticket for user
                        Console.WriteLine("\n\n-------------------------\n" +
                                "Aquinas Multiplex\n" +
                                "Film: {0}\n" +
                                "Date: {1}\n" +
                                "Row Number: {2}\n" +
                                "Column Number: {3}\n\n" +
                                "Enjoy the film\n" +
                                "-------------------------", filmName, watchDate.ToString("dd/MM/yyyy"), rowNumber, colNumber);
                        //Switch statement to change tickets remaining once at ticket has been sold
                        switch (film)
                        {
                            case 1:
                                ticketsRemaining1--;

                                break;
                            case 2:
                                ticketsRemaining2--;

                                break;
                            case 3:
                                ticketsRemaining3--;

                                break;
                            case 4:
                                ticketsRemaining4--;

                                break;
                            case 5:
                                ticketsRemaining5--;

                                break;
                        }
                        //Marks seat as taken
                        seating[(rowNumber - 1), (colNumber - 1), film - 1, day] = 1;
                        //Resets rowNumber and colNumber for when program restarts
                        rowNumber = 0;
                        colNumber = 0;
                        //Allows user to see ticket before choosing to finish so that the console won't be cleared straight after the ticket is printed
                        Console.WriteLine("\n\nPress any key to finish");
                        Console.ReadKey();
                        Console.Clear();
                        filmName = "";//Loops back to the start so that a new user can choose a film
                    }
                }
            }
        }
    }
}
