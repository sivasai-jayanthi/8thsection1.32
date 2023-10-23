using System;
using System.IO;

namespace _8thsection1._32
{
	internal class Program
	{
		static void Main(string[] args)
		{

			readtext();

			
			Console.Write("Enter a student name to search for: ");
			string searchName = Console.ReadLine();

			SearchStudentByName(searchName);
			Console.ReadLine();
		}




		public static void readtext()
		{
			
			
			string[] data = File.ReadAllLines(@"C:\Users\sai\source\repos\8thsection1.32\data.txt");
			Array.Sort(data);
			foreach (string line in data)
			{
				Console.WriteLine(line);
			}
			


		}
		public static void SearchStudentByName(string name)
		{
			
			try
			{
				FileStream fs = new FileStream(@"C:\Users\sai\source\repos\8thsection1.32\data.txt", FileMode.Open, FileAccess.Read);
				StreamReader sr = new StreamReader(fs);
				{
					string line;
					while ((line = sr.ReadLine()) != null)
					{
						string[] parts = line.Split(',');
						if (parts.Length >= 3)
						{
							string studentName = parts[0].Trim();

							if (studentName.Equals(name, StringComparison.OrdinalIgnoreCase))
							{
								int studentAge;
								if (int.TryParse(parts[1], out studentAge))
								{
									string major = parts[2].Trim();

									Console.WriteLine($"Name: {studentName}, Age: {studentAge},               Major: {major}");
								}
							}
						}
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine($"Error reading the file: {e.Message}");
			}
		}






	}
}

