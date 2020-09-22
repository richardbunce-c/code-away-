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

			//Create a new empty list of names
			List < string > names= new List<string>();

			names.Add("Roberto");//0
	names.Add("Carlos");//1
			names.Add("Caesar");//2
			names.Add("Jose");//3
			names.Add("Frankie");//4
			
			names.Insert(3, "Jose");//Jose becomes 3, Frankie moves down to 4
			names.Insert(0, "Shane"); //Shane is 1st now, everyone else moves down one spot

			//The outfield is in an array
			string[] outfield = new string[] { "Jordan", "Delino", "Tyler" };
			names.AddRange(outfield);
			//Remove the third element
			names.RemoveAt(2);

			//Remove Jordan
			bool wasRemoved =names.Remove("Jordan");
			names.Remove("Mike");

			//Lists may be accessed by Index, just like arrays;
			//Print the 4th player
			Console.WriteLine(names[3]);
			//update the 2nd player
			names[1] = "Sandy";

            //Display what is in the current list
            for (int i = 0; i< names.Count; i++)
            {
				string name = names[i];
				Console.WriteLine(name);
            }
			foreach (string name in names) 
			{
				Console.WriteLine(names); }
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


			Console.WriteLine("####################");
			Console.WriteLine("Find index of item in List");
			Console.WriteLine("####################");


			Console.WriteLine("####################");
			Console.WriteLine("Lists can be turned into an array");
			Console.WriteLine("####################");


			Console.WriteLine("####################");
			Console.WriteLine("Lists can be sorted");
			Console.WriteLine("####################");


			Console.WriteLine("####################");
			Console.WriteLine("Lists can be reversed too");
			Console.WriteLine("####################");


			Console.WriteLine("####################");
			Console.WriteLine("       FOREACH");
			Console.WriteLine("####################");
			Console.WriteLine();


		}
	}
}
