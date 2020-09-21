using System;

namespace StringsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int age1 = 25;
            int age2 = age1;
            age2 = 30;


            string str = "Foo";
            str = str.Replace("o", "a");
            Console.WriteLine(str);

            // Use our custom Person data type (class)
            CreatePerson();

            // Create an array of ints
            int[] nums1 = new int[] { 2, 4, 6 };
            int[] nums2 = nums1;

            // Change the 2nd element of nums2
            nums2[1] = 25;

            // display nums1
            Console.WriteLine(string.Join(":", nums1));


            string name = "Ada Betty Lovelace";

            // Strings are actually arrays of characters (char). 
            // Those characters can be accessed using [] notation.

            // 1. Write code that prints out the first and last characters
            //      of name.
            // Output: A
            // Output: e
            Console.WriteLine($"First: {name[0]}, Last: {name[name.Length-1]}");

            // Can I change the first character?
            // name[0] = 'F';   // NO!

            // Console.WriteLine("First and Last Character. ");

            // 2. How do we write code that prints out the first three characters
            // Output: Ada
            string substr = name.Substring(0, 3);
            Console.WriteLine($"First 3 characters: '{substr}'");

            // 3. Now print out the  last three characters
            // Output: Adaace
            string last3 = name.Substring(name.Length - 3);

            Console.WriteLine($"Last 3 characters: {last3}");

            // 4. What about the last word?
            // Output: Lovelace
            string[] names = name.Split(" ");
            Console.WriteLine($"Last Word: {names[names.Length-1]}");

            // Can you do the same thing with IndexOf
            int spaceIndex = name.LastIndexOf(" ");
            string lastWord = name.Substring(spaceIndex + 1);
            Console.WriteLine($"Last Word: {lastWord}");

            // 5. Does the string contain inside of it "Love"?
            // Output: true
            bool containsLove = name.Contains("love");
            Console.WriteLine($"Contains \"Love\": {containsLove}");

            // 6. Where does the string "lace" show up in name?
            // Output: 8

            // Console.WriteLine("Index of \"lace\": ");

            // 7. How many 'a's OR 'A's are in name?
            // Output: 3
            int aCount = 0;
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == 'a' || name[i] == 'A')
                {
                    aCount++;
                }
            }
            Console.WriteLine($"Number of \"a's\": {aCount} ");

            // 8. Replace "Ada" with "Ada, Countess of Lovelace"
            name = name.Replace("Ada", "Ada, Countess of Lovelace");
            Console.WriteLine(name);

            // 9. Set name equal to null.
            name = null;

            // 10. If name is equal to null or "", print out "All Done".
            if (name == null)
            {
                Console.WriteLine("All done");
            }

            // Console.ReadLine();
            string s1 = " Keith Wier ";
            string s2 = "keith WIER";
            if (s1.Trim().ToLower() == s2.ToLower())
            {
                Console.WriteLine("The keiths are the same");
            }
            else
            {
                Console.WriteLine("The keiths are different");
            }



        }

        public static void CreatePerson()
        {
            // Create a new Person object from the Person class
            Person person1 = new Person();

            // Set the properties of this object
            person1.FirstName = "Mike";
            person1.LastName = "Morel";
            person1.HeightInches = 71;

            // Create another person and set its value.
            Person person2 = new Person();
            person2.FirstName = "Zoe";
            person2.LastName = "Moskalew";
            person2.HeightInches = 70;

            Console.WriteLine($"{person2.FirstName} {person2.LastName} is {person2.HeightInches} inches tall.");

            Person anotherPerson = person2;
            anotherPerson.FirstName = "Betty";

            Console.WriteLine($"{anotherPerson.FirstName} {anotherPerson.LastName} is {anotherPerson.HeightInches} inches tall.");
            Console.WriteLine($"{person2.FirstName} {person2.LastName} is {person2.HeightInches} inches tall.");

            // Create another person and set its value.
            Person person3 = new Person();
            person3.FirstName = "Zoe";
            person3.LastName = "Moskalew";
            person3.HeightInches = 70;

            if (person2 == person3)
            {
                Console.WriteLine("They are the same!");
            }
            else
            {
                Console.WriteLine("They are different!");
            }




        }
    }

}