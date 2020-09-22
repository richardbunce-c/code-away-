using System;
using System.Collections.Generic;

namespace CollectionsPart1Lecture
{
    public class CollectionsPart1Lecture
	{
        static void Main(string[] args)
        {
			Console.WriteLine("####################");
			Console.WriteLine("       LISTS");
			Console.WriteLine("####################");

			// Create a new empty list of names
			List<string> names = new List<string>();

			names.Add("Roberto");	//0
			names.Add("Carlos");	//1
			names.Add("Ceasar");	//2
			names.Add("Frankie");   //3

			names.Insert(3, "Jose"); // Jose becomes 3, Frankie moves down to 4

			names.Insert(0, "Shane"); // Insert at the beginning of the list, EVERYONE else moves down

			// The outfield is ni an array
			string[] outfield = new string[] {"Jordan", "Delino", "Tyler" };

			names.AddRange(outfield);

			// Remove the third element
			names.RemoveAt(2);

			// Remove Jordan from the list
			bool wasRemoved = names.Remove("Jordan");
			wasRemoved = names.Remove("Mike");

            // Lists may be accessed by Index, just like arrays;
            // Print the 4th player
            Console.WriteLine(names[3]);

			// Update the 2nd player
			names[1] = "Sandy";

			Console.WriteLine("####################");
			// Display what is in the current list
			for (int i = 0; i < names.Count; i++)
            {
				string name = names[i];
                Console.WriteLine(name);
            }
			Console.WriteLine("####################");

			foreach(string name in names)
            {
                Console.WriteLine(name);
            }

			Console.WriteLine("####################");
			Console.WriteLine("Lists are ordered");
			Console.WriteLine("####################");


			Console.WriteLine("####################");
			Console.WriteLine("Lists allow duplicates");
			Console.WriteLine("####################");


			Console.WriteLine("####################");
			Console.WriteLine("Lists allow elements to be inserted in the middle");
			Console.WriteLine("####################");


			Console.WriteLine("####################");
			Console.WriteLine("Lists allow elements to be removed by index");
			Console.WriteLine("####################");


			Console.WriteLine("####################");
			Console.WriteLine("Find out if something is already in the List");
			Console.WriteLine("####################");

			bool isInList = names.Contains("Roberto");
			Console.WriteLine($"Contains 'Roberto': {isInList}");
			isInList = names.Contains("Shane");
			Console.WriteLine($"Contains 'Shane': {isInList}");

			Console.WriteLine("####################");
			Console.WriteLine("Find index of item in List");
			Console.WriteLine("####################");
			int indexOf = names.IndexOf("Roberto");
			indexOf = names.IndexOf("Shane");

			Console.WriteLine("####################");
			Console.WriteLine("Lists can be turned into an array");
			Console.WriteLine("####################");
			string[] namesArray = names.ToArray();


			// Print the list as it is now
			PrintList(names);

			Console.WriteLine("####################");
			Console.WriteLine("Lists can be sorted");
			Console.WriteLine("####################");
			names.Sort();
			PrintList(names);

			Console.WriteLine("####################");
			Console.WriteLine("Lists can be reversed too");
			Console.WriteLine("####################");
			names.Reverse();

			Console.WriteLine("####################");
			Console.WriteLine("       FOREACH");
			Console.WriteLine("####################");
			Console.WriteLine();


			// Create a stack of browser locations
			Stack<string> browserStack = new Stack<string>();
			browserStack.Push("Home Page");
			browserStack.Push("Login");
			browserStack.Push("User Dashboard");
			browserStack.Push("Details Page");

			// User hits Back button
			while(browserStack.Count > 0)
            {
				string page = browserStack.Pop();
                Console.WriteLine(page);
            }
			//string previousPage = browserStack.Pop();

		}

		static public void PrintList(List<string> list)
        {
			foreach(string s in list)
            {
                Console.WriteLine(s);
            }
        }
	}
}
