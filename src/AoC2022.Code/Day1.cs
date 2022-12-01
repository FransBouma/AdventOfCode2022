using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021.Core
{
	public static class Day1
	{
		private static List<int> CalculateTotals(List<string> input)
		{
			var totals = new List<int>();
			int currentMax = 0;
			foreach(var s in input)
			{
				if(string.IsNullOrWhiteSpace(s))
				{
					totals.Add(currentMax);
					currentMax = 0;
				}
				else
				{
					currentMax += int.Parse(s);
				}
			}

			// last portion doesn't have a delimiter line at the end
			totals.Add(currentMax);
			return totals;
		}

		
		public static int Solve1(List<string> input)
		{
			var totals = CalculateTotals(input);
			return totals.Max();
		}


		public static int Solve2(List<string> input)
		{
			var totals = CalculateTotals(input);
			return totals.OrderByDescending(c => c).Take(3).Sum();
		}
	}
}