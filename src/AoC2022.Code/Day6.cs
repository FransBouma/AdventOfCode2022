using System;
using System.Collections.Generic;
using System.Linq;
using SD.Tools.Algorithmia.GeneralDataStructures;

namespace AoC2022.Core
{
	public static class Day6
	{
		public static int Solve1(List<string> input)
		{
			// just 1 line in the input
			var line = input[0];
			var markerLength = 4;
			return Solve(markerLength, line);
		}


		private static int Solve(int markerLength, string line)
		{
			var setOfChars = new HashSet<char>();
			var toReturn = 0;
			for(int i = markerLength - 1; i < line.Length; i++)
			{
				setOfChars.Clear();

				// add all chars before the current char for the length of the marker
				for(int j = 0; j < markerLength; j++)
				{
					setOfChars.Add(line[i - j]);
				}

				if(setOfChars.Count == markerLength)
				{
					// all unique
					toReturn = i + 1; // starts at 1
					break;
				}
			}

			return toReturn;
		}


		public static int Solve2(List<string> input)
		{
			var line = input[0];
			var markerLength = 14;
			return Solve(markerLength, line);
		}
	}
}