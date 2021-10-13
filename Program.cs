using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using static System.Console;
namespace TextAnalyzer
{
	class Program
	{
		private static string GetLetters(string str)
		{
			System.Text.RegularExpressions.Regex rgx = new System.Text.RegularExpressions.Regex("[^a-zA-Z ]");
			str = rgx.Replace(str, "");
			str = str.ToLower();
			return str;
		}
		private static string ReadFromFile(string fileDirectory)
		{
			string str = "";
			try
			{
				StreamReader stream = new StreamReader(fileDirectory);
				str = stream.ReadToEnd();
				stream.Close();
			}
			catch
			{
				WriteLine("Error reading a file");
			}
			return str;
		}
		static void Main()
		{
			string str = "";
			//WriteLine("Input directory of a file for learning:");
			string currnetDirectory = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.Length - 9);
			str = ReadFromFile(currnetDirectory + @"text-for-learning.txt");
			WriteLine($"Symbol count: {str.Length}");
			str = GetLetters(str);// removes ',', ';' etc.
			// https://stackoverflow.com/questions/23453260/find-and-count-latter-pair-from-a-string-by-alphabetical-order
			Dictionary<string, int> counts = new Dictionary<string, int>();
			for (char ch1 = 'a'; ch1 <= 'z'; ch1 ++)
			{
				for (char ch2 = 'a'; ch2 <= 'z'; ch2 ++)
				{
					counts.Add(""+ch1+ch2, 0);
				}
			}
			int n = str.Length;
			for (int i = 0; i < n - 1; i ++)
			{
				string index = "" + str[i] + str[i + 1];
				if (counts.ContainsKey(index))
					counts[index]++;
			}
			WriteLine("Input string:");
			str = ReadLine();
			str = GetLetters(str);
			n = str.Length;
			int countChars = n - str.Count(Char.IsWhiteSpace);
			double trustFactor = 1.0;
			for (int i = 0; i < n - 1; i ++)
				if (str[i] != ' ' && str[i+1] != ' ')
					trustFactor *= Math.Pow(counts["" + str[i] + str[i + 1]], 1.0/countChars);
			WriteLine($"trustFactor = {trustFactor}");
			if (trustFactor > 1200)
				WriteLine("Correct");
			else
				WriteLine("Nonsense");
		}
	}
}
