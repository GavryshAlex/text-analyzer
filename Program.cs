using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;
namespace TextAnalyzer
{
	class Program
	{
		private static string GetLetters(string str)
		{
			System.Text.RegularExpressions.Regex rgx = new System.Text.RegularExpressions.Regex("[^a-zA-Z]");
			str = rgx.Replace(str, "");
			str = str.ToLower();
			return str;
		}
		static void Main()
		{
			string str = "";
			try
			{
				string fileDirectory = ReadLine();
				StreamReader stream = new StreamReader(fileDirectory);
				str = stream.ReadToEnd();
				stream.Close();
				WriteLine("Symbol Count: " + str.Length.ToString());
				WriteLine(str);
			}
			catch
			{
				WriteLine("Error reading a file");
				return;
			}
			str = GetLetters(str); // removes ' ', ',', ';' etc.
			// https://stackoverflow.com/questions/23453260/find-and-count-latter-pair-from-a-string-by-alphabetical-order
			Dictionary<string, int> counts = new Dictionary<string, int>();
			int n = str.Length;
			for (int i = 0; i < n - 1; i ++)
			{
				string pairChars = "" + str[i] + str[i + 1];
				if (!counts.ContainsKey(pairChars)) // why ""?
					counts.Add(pairChars, 0);
				counts[pairChars]++;
			}
			foreach (string s in counts.Keys)
			{
				WriteLine(s + " " + counts[s]);
			}
		}
	}
}
