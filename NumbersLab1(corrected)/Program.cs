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

			for (char digit = '1'; digit <= '9'; digit++)
			{
				int startIndex = 0;
				
				while (startIndex < myNumbers.Length)
				{
					int startMatch = myNumbers.IndexOf(digit, startIndex);

					if (startMatch == -1)
					{
						break;
					}

					int endMatch = myNumbers.IndexOf(digit, startMatch + 1);

					while (endMatch != -1)
					{
						
						string matchedNumbers = myNumbers.Substring(startMatch, endMatch - startMatch + 1);
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

						if (isValid)
						{
                            Console.Write(myNumbers.Substring(0, startMatch));
							Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write(matchedNumbers);
							Console.ResetColor();
                            Console.WriteLine(myNumbers.Substring(endMatch + 1));

							long matchedNums;
							if (long.TryParse(matchedNumbers, out matchedNums))
							{
								totalSum += matchedNums;
							}

							startIndex = endMatch + 1;
							break;
                        }
						else
						{
							endMatch = myNumbers.IndexOf(digit, endMatch + 1);
						}
					}

				}
			}

            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine($"\nTotal = {totalSum}");
			Console.ResetColor();

			Console.ReadKey();

        }
	}
}
