using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2022.Core
{
	public static class Day3
	{
		public static int Solve1(List<string> input)
		{
			int total = 0;
			foreach(var s in input)
			{
				var firstHalf = s.Substring(0, s.Length / 2);
				var secondHalf = s.Substring(s.Length / 2);
				var commonItems = firstHalf.Intersect(secondHalf);
				foreach(var c in commonItems)
				{
					total += Char.IsLower(c) ? (c - 'a') + 1 : (c - 'A') + 27;
				}
			}

			return total;
		}

		
		public static int Solve2(List<string> input)
		{
			int total = 0;
			int index = 0;
			while(index<input.Count)
			{
				var commonItems = input[index].Intersect(input[index + 1]).Intersect(input[index + 2]);
				foreach(var c in commonItems)
				{
					total += Char.IsLower(c) ? (c - 'a') + 1 : (c - 'A') + 27;
				}

				index += 3;
			}

			return total;
		}
	}
}