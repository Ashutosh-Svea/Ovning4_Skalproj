﻿using System;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// Q1. List capacity increases when it is needed. Since cost of copying elements is hight, increase of size is done by doubling when needed.Therefore, it is not increased with each element add because of added cost of copying. 
        /// List size does not decrease on its own when the elements are taken out. One must call trim methods to resize the list
        /// It is advantageous to use array over list when we know how many elements will be there beforehand. Fixed size.  
        /// 
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            List<string> theList = new List<string>();

            do
            {
                Console.WriteLine("Enter +input to add input to list.");
                Console.WriteLine("Enter -input to remove input to list.");
                Console.WriteLine("Enter p to print the list.");
                Console.WriteLine("Enter 0 to exit to main menu.");

                string? input = Console.ReadLine();
                string? value = "";

                if (Utils.IsStringAtleastGivenCharacters(input, 1) is false)
                {
                    Console.WriteLine("Please enter valid choice");
                    continue;
                }
                if (input is null)
                {
                    Console.WriteLine("Please enter valid choice");
                    continue;

                }

                switch (input[0])
                {
                    case '+':

                        if (Utils.IsStringAtleastGivenCharacters(input, 2))
                        {
                            value = input?.Substring(1);
                            //Console.WriteLine($"Add to list {value}");
                            Console.WriteLine("List capacity before adding" + theList.Capacity);
                            if (value is not null)
                                theList.Add(value);
                            Console.WriteLine("List capacity after adding" + theList.Capacity);

                        }
                        else
                            Console.WriteLine("Please enter some string to add to the list");
                        break;

                    case '-':
                        if (Utils.IsStringAtleastGivenCharacters(input, 2))
                        {
                            value = input?.Substring(1);
                            //Console.WriteLine($"Remove from list {value}");
                            Console.WriteLine("List capacity before removing" + theList.Capacity);

                            if (value is not null)
                                theList.Remove(value);

                            Console.WriteLine("List capacity after removing" + theList.Capacity);

                        }
                        else
                            Console.WriteLine("Please enter some string to remove from the list");

                        break;
                    case 'p':
                        foreach (var item in theList)
                        {
                            Console.WriteLine(item);
                        }
                        //Console.WriteLine("Print list");
                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("Please enter valid input");
                        break;
                }
            } while (true);
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */


            Queue<string> queue = new ();

            

            do
            {
                Console.WriteLine("Enter +name to add name to ICA Checkout Queue.");
                Console.WriteLine("Enter - to expedite one person.");
                Console.WriteLine("Enter p to print the queue.");
                Console.WriteLine("Enter t to simulate the ICA queue as given in the exercise.");
                Console.WriteLine("Enter 0 to exit to main menu.");

                string? input = Console.ReadLine();
                string? value = "";

                if (Utils.IsStringAtleastGivenCharacters(input, 1) is false)
                {
                    Console.WriteLine("Please enter valid choice");
                    continue;
                }
                if (input is null)
                {
                    Console.WriteLine("Please enter valid choice");
                    continue;

                }

                switch (input[0])
                {
                    case '+':

                        if (Utils.IsStringAtleastGivenCharacters(input, 2))
                        {
                            value = input?.Substring(1);
                            //Console.WriteLine($"Add to list {value}");
                            if (value is not null)
                                queue.Enqueue(value);
                        }
                        else
                            Console.WriteLine("Please enter some name to add to the ICA Checkout queue");
                        break;

                    case '-':
                        string name;
                        if (queue.Count > 0)
                        {
                            name = queue.Dequeue();
                            Console.WriteLine($"{name} is leaving the queue and is expediated now.");
                        }
                        else
                            Console.WriteLine("Nobody in the queue.");
                        break;

                    case 'p':
                        foreach (var item in queue)
                        {
                            Console.WriteLine(item);
                        }
                        //Console.WriteLine("Print list");
                        break;
                    case 't':
                        testQueue();
                        break;

                    case '0':
                        return;
                    default:
                        Console.WriteLine("Please enter valid input");
                        break;
                }
            } while (true);
        }


        static void testQueue()
        {
            Queue<string> icaQueue = new Queue<string>();

            icaQueue.Enqueue("Kalle");
            icaQueue.Enqueue("Greta");
            icaQueue.Dequeue();
            icaQueue.Enqueue("Stina");
            icaQueue.Dequeue();
            icaQueue.Enqueue("Olle");

            foreach (var item in icaQueue)
                Console.WriteLine(item);
            {

            }
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}

