using System;
using System.Collections.Generic;

namespace Programming_Lecture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Variable DataTypes  
            //StringInput();
            //CharacterInput();
            //IntegerInput();
            //BooleanInput();
            //CelsiusToFahrenheit();

            ////String Manipulation
           // ManipulateString();

            ////Datatypes Arrays and Lists 
            //ArrayDefinitions();
           // ArrayInput();

            //// Lists
           //ListDefinitions();
            ListInput();
        }

        static void StringInput()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Name: " + name);
        }
        static void IntegerInput()
        {
            Console.Write("\nEnter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Age: " + age);
        }
        static void BooleanInput()
        {
            Console.Write("\nAre you a tax filer? (true/false): ");
            bool taxFiler = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Tax Filer: " + taxFiler);
        }
        static void CharacterInput()
        {
            // Read char input: gender
            Console.Write("\nEnter your gender (M/F): " );
            char vowel = 'a';
            char gender = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Gender: " + gender);
        }
        static void CelsiusToFahrenheit()
        {
            // Read float input: Celsius temperature
            Console.Write("\nEnter temperature in Celsius:");
            float celsius = Convert.ToSingle(Console.ReadLine());
            float fahrenheit = (celsius * 9 / 5) +32;
            Console.WriteLine($"{celsius}°C is equals to {fahrenheit}°F");

        }
        static void ManipulateString()
        {
            // Read string input for manipulation
            Console.WriteLine("Enter a string for manipulation:");
            string originalString = Console.ReadLine();
            string manipulatedString = originalString.ToUpper(); // Example 1: Convert to uppercase
            Console.WriteLine("Original: " + originalString);
            Console.WriteLine("Manipulated (Uppercase): " + manipulatedString);

            // Example 2: Convert to lowercase
            manipulatedString = originalString.ToLower();
            Console.WriteLine("Manipulated (Lowercase): " + manipulatedString);

            // Example 3: Trim whitespace
            manipulatedString = originalString.Trim(); // Removes leading and trailing whitespace
            Console.WriteLine("Manipulated (Trimmed): " + manipulatedString);

            // Example 4: Replace characters
            Console.WriteLine("Enter a character to replace:");
            char charToReplace = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Enter a replacement character:");
            char replacementChar = Convert.ToChar(Console.ReadLine());
            manipulatedString = originalString.Replace(charToReplace, replacementChar);
            Console.WriteLine($"Manipulated (Replaced '{charToReplace}' with '{replacementChar}'): " + manipulatedString);

            // Example 5: Substring
            Console.WriteLine("Enter starting position(index) for substring:");
            int startIndex = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter length of substring:");
            int length = Convert.ToInt32(Console.ReadLine());
            if (startIndex >= 0 && startIndex < originalString.Length)
            {
                if (startIndex + length <= originalString.Length)
                {
                    manipulatedString = originalString.Substring(startIndex, length);
                    Console.WriteLine($"Manipulated (Substring): " + manipulatedString);
                }
                else
                {
                    Console.WriteLine("Invalid length for substring.");
                }
            }
            else
            {
                Console.WriteLine("Invalid starting index for substring.");
            }

            // Example 6: Split into array of substrings
            Console.WriteLine("Enter a delimiter to split the string:");
            string delimiter = Console.ReadLine();
            string[] substrings = originalString.Split(new string[] { delimiter }, StringSplitOptions.None);
            Console.WriteLine("Manipulated (Split into substrings):");
            foreach (string substring in substrings)
            {
                Console.WriteLine(substring);
            }
        }
        static void ArrayDefinitions()
        {
            // Array Declaration and definitions 
            int[] marks = new int[5];
            marks[0] = 10;  // assign the value 10 in array on its index 0
            marks[1] = 30;  // assign the value 20 in array on its index 1
            marks[2] = 20;  // assign the value 30 in array on its index 2
            marks[3] = 40;  // assign the value 40 in array on its index 3
            marks[4] = 50;  // assign the value 50 in array on its index 4

            //or you can define array with 5 elements which indicates the size of an array
            int[] numbersArray = { 1, 2, 3, 4, 5 };
            Console.WriteLine("\nNumbers in array are: ");
            for (int i = 0; i < numbersArray.Length; i++)
            {
                Console.Write(numbersArray[i] + " ");
            }


            string[] fruits;  // declares an Array of string.
            fruits = new string[] { "Apple", "Banana", "Mango", "Orange" }; // allocating memory for fruits.
            Console.WriteLine("\nArray of fruits: ");
            for (int i = 0; i < fruits.Length; i++)
            {
                Console.Write(fruits[i] + " ");
            }

            char[] charArray = { 'a','e','i','o','u'}; // can store decimal values
            Console.WriteLine("\nArray of decimals: ");
            for (int i = 0; i < charArray.Length; i++)
            {
                Console.Write(charArray[i] + " ");
            }
        }
        static void ArrayInput()
        {
            Console.Write("\nEnter five numbers separated by spaces:");
            string[] numbersInput = Console.ReadLine().Split(' ');
            int[] numbersArray = new int[numbersInput.Length];
            for (int i = 0; i < numbersInput.Length; i++)
            {
                numbersArray[i] = Convert.ToInt32(numbersInput[i]);
            }
            Console.Write("\nArray elements: ");
            for (int i = 0; i < numbersArray.Length; i++)
            {
                Console.Write(numbersArray[i] + " ");
            }
            Console.WriteLine();
        }
        static void ListDefinitions()
        {
            List<string> months = new List<string>();
            months.Add("January");
            months.Add("February");
            months.Add("March");
            months.Add("April");
            months.Add("May");
            months.Add("June");
            months.Add("July");
            months.Add("August");
            months.Add("September");
            months.Add("October");
            months.Add("November");
            months.Add("December");

            Console.Write("\nMonths in a year are: ");
            for (int i = 0; i < months.Count; i++)
            {
                Console.Write(months[i] + " ");
            }

            // After using Remove() method
            months.Remove("February");
            Console.Write("\nMonths in a year are: ");
            for (int i = 0; i < months.Count; i++)
            {
                Console.Write(months[i] + " ");
            }


            // After using RemoveAt() method
            months.RemoveAt(4);
            Console.Write("\nAfter removing value at index 4: ");
            for (int i = 0; i < months.Count; i++)
            {
                Console.Write(months[i] + " ");
            }


            // After using RemoveRange() method
            months.RemoveRange(0, 2);
            Console.Write("\nAfter removing values at index 4: ");
            for (int i = 0; i < months.Count; i++)
            {
                Console.Write(months[i] + " ");
            }



        }
        static void ListInput()
        {
            Console.Write("\nEnter names separated by commas:");
            string[] namesInput = Console.ReadLine().Split(',');
            List<string> namesList = new List<string>(namesInput);
            Console.Write("\nNames in list:");
            foreach (string nameItem in namesList)
            {
                Console.Write(nameItem.Trim()); // Trim to remove any leading/trailing spaces
            }
        }
    }
}
