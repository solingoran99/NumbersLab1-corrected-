using System.Text.RegularExpressions;

namespace NumbersLab1_corrected_
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string myNumbers = "81575187k62387623593465387469";
			long totalSum = 0;

			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("Patterns that start and end with the same digit.");
			Console.ResetColor();

			
			for (int startIndex = 0; startIndex < myNumbers.Length; startIndex++)
			{
				char startDigit = myNumbers[startIndex];

				if (char.IsDigit(startDigit))
				{
					int endIndex = myNumbers.IndexOf(startDigit, startIndex + 1);

					while (endIndex != -1)
					{
						string matchedNumbers = myNumbers.Substring(startIndex, endIndex - startIndex + 1);
						string middlePart = matchedNumbers.Substring(1, matchedNumbers.Length - 2);

						bool isValid = true;

						foreach (char c in middlePart)
						{
							if (!char.IsDigit(c))
							{
								isValid = false;
								break;
							}
						}

						if (isValid && !middlePart.Contains(startDigit))
						{
							Console.Write(myNumbers.Substring(0, startIndex));
							Console.ForegroundColor = ConsoleColor.Magenta;
							Console.Write(matchedNumbers);
							Console.ResetColor();
							Console.WriteLine(myNumbers.Substring(endIndex + 1));

							if (long.TryParse(matchedNumbers, out long matchedNums))
							{
								totalSum += matchedNums;
							}

							endIndex = myNumbers.IndexOf(startDigit, endIndex + 1);
						}
						else
						{
							endIndex = myNumbers.IndexOf(startDigit, endIndex + 1);
						}
					}
				}
			}

			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"\nTotal = {totalSum}");
			Console.ResetColor();

			Console.ReadKey();
		}
	}
}

