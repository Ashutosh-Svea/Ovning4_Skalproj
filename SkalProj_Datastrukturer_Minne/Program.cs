using System;

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
                    + "\n5. Find Recursive Even"
                    + "\n6. Fibonacci Sequence"
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
                    case '5':
                        TryRecursiveEven();
                        break;
                    case '6':
                        TryFibonacci();
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

        private static void TryFibonacci()
        {
            Console.WriteLine("Please enter a number");

            int n;

            if (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Invalid number entered. Try again.");
            }
            else if (n < 0)
            {
                Console.WriteLine("Invalid number entered. Try again.");
            }
            else
            {
                int output = Fibonacci(n);
                Console.WriteLine($" Fibonacci is : { output }");

            }
        }

        private static int Fibonacci (int n)
        {
            if (n == 0) 
                return 0;    
            if (n == 1) 
                return 1; 

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        private static void TryRecursiveEven()
        {
            Console.WriteLine("To find its recursive even, please enter a number");
            int n;

            if (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Invalid number entered. Try again.");
            }
            else if (n < 0)
            {
                Console.WriteLine("Invalid number entered. Try again.");
            }
            else
            {
                int output = RecursiveEven(n);

                Console.WriteLine($" Recursive even is : { output }");
            }

        }

        public static int RecursiveEven(int n)
        {
            if (n == 0)
                return 0;
            else
                return (RecursiveEven(n - 1) + 2);
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
        /// using stack for ICA Queue means that everytime one person who came first leaves, the stack has to be emptied and recreated since the first person
        /// is at the bottom of stack. 
        /// </summary>
        /// 
        static void ExamineStack()
        {
            Stack<string> stringStack = new Stack<string>();

            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
            do
            {
                Console.WriteLine("Enter +name to add name to stack.");
                Console.WriteLine("Enter - to pop the top name.");
                Console.WriteLine("Enter p to print the stack.");
                Console.WriteLine("Enter r to reverse a string using stack");
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
                                stringStack.Push(value);

                        }
                        else
                            Console.WriteLine("Please enter some string with at least one character");
                        break;

                    case '-':
                        string name;
                        if (stringStack.Count > 0)
                        {
                            name = stringStack.Pop();
                            Console.WriteLine($"{name} is popped from the stack.");
                        }
                        else
                            Console.WriteLine("No string in the stack");
                        break;

                    case 'p':
                        foreach (var item in stringStack)
                        {
                            Console.WriteLine(item);
                        }

                        //Console.WriteLine("Print list");
                        break;
                    case 'r':
                        Console.WriteLine("Enter a string to be revered");
                        string? inputString = Console.ReadLine();
                        if (Utils.IsEmptyString(inputString))
                            Console.WriteLine("Invalid input. String must be atleast one character");
                        else if (inputString is not null)
                        {
                            Stack<char> charStack = new Stack<char>();
                            foreach (var character in inputString)
                            {
                                charStack.Push(character);
                            }

                            String reverseString = "";

                            foreach (var item in charStack)
                            {
                                reverseString += item;
                            }

                            Console.WriteLine($"Reversed string is {reverseString}");
                        }
                        break;

                    case '0':
                        return;
                    default:
                        Console.WriteLine("Please enter valid input");
                        break;
                }
            } while (true);

        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            Console.WriteLine("Please enter a string perhaps with different kinds of paranthesis");

            string? inputString = Console.ReadLine();
            
            Stack<char> bracketStack = new Stack<char>();

            if (inputString is null)
                Console.WriteLine("Invalid string. It should have atleast one character");
            else if (Utils.IsEmptyString(inputString))
                Console.WriteLine("Invalid string. It should have atleast one character");
            else
            {
                foreach (var character in inputString)
                {
                    if (isSomeOpeningBrackets(character))
                        bracketStack.Push(character);
                    else if (isSomeClosingBrackets(character))
                    {
                        char poppedBracket = bracketStack.Pop();
                        if (matchClosingBracket(character, poppedBracket) is true)
                            continue;
                        else
                        {
                            Console.WriteLine("Unbalanced brackets!");
                            return;
                        }
                    }
                }

                if (bracketStack.Count > 0)
                    Console.WriteLine("Unbalanced brackets!");
                else
                    Console.WriteLine("Balanced brackets!");
            }
        
        }

        private static bool isSomeClosingBrackets(char character)
        {
            if (character is ')')
                return true;
            else if (character is ']')
                return true;
            else if (character is '}')
                return true;
            else
                return false;
        }

        private static bool matchClosingBracket(char character, char v)
        {
            switch (character)
            {
                case ')':
                    if (v == '(')
                        return true;

                    break;

                case ']':
                    if (v == '[')
                        return true;

                    break;

                case '}':
                    if (v == '{')
                        return true;

                    break;
            }

            return false;
        }

        private static bool isSomeOpeningBrackets(char character)
        {
            if (character is '(')
                return true;
            else if (character is '[')
                return true;
            else if (character is '{')
                return true;
            else
                return false;
        }
    }
}

