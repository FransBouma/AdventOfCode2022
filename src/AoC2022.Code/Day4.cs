using System;
using System.Collections.Generic;
using System.Linq;
using SD.Tools.Algorithmia.GeneralDataStructures;

namespace AoC2022.Core
{
	public static class Day4
	{
		private static Pair<int, int> MakeSectionSequence(string sequenceString)
		{
			var startEnd = sequenceString.Split('-');
			return new Pair<int, int>(Convert.ToInt32(startEnd[0]), Convert.ToInt32(startEnd[1]));
		}

		
		public static int Solve1(List<string> input)
		{
			var total = 0;
			foreach(var s in input)
			{
				var pairs = s.Split(',');
				var sections1 = MakeSectionSequence(pairs[0]);
				var sections2 = MakeSectionSequence(pairs[1]);

				if((sections1.Value1 >= sections2.Value1 && sections1.Value2 <= sections2.Value2) ||
				   (sections2.Value1 >= sections1.Value1 && sections2.Value2 <= sections1.Value2))
				{
					total += 1;
				}
			}
			return total;
		}


		public static int Solve2(List<string> input)
		{
			var total = 0;
			foreach(var s in input)
			{
				var pairs = s.Split(',');
				var sections1 = MakeSectionSequence(pairs[0]);
				var sections2 = MakeSectionSequence(pairs[1]);

				if((sections1.Value1 >= sections2.Value1 && sections1.Value1 <= sections2.Value2) ||
				   (sections1.Value2 >= sections2.Value1 && sections1.Value2 <= sections2.Value2) ||
				   (sections2.Value1 >= sections1.Value1 && sections2.Value1 <= sections1.Value2) ||
				   (sections2.Value2 >= sections1.Value1 && sections2.Value2 <= sections1.Value2))
				{
					total += 1;
				}
			}
			return total;		}
	}
}