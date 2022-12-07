using System;
using System.Collections.Generic;
using System.Linq;
using SD.Tools.Algorithmia.GeneralDataStructures;

namespace AoC2022.Core
{
	public static class Day7
	{
		public static long Solve1(List<string> input)
		{
			int currentLineNo = -1;
			var sizePerFolder = new List<Pair<string, long>>();
			HandleInput(input, sizePerFolder, string.Empty, ref currentLineNo);

			return sizePerFolder.Where(p => p.Value2 < 100000).Select(p => p.Value2).Sum();
		}


		private static long HandleInput(List<string> input, List<Pair<string, long>> sizePerFolder, string currentFolder, ref int lineNo)
		{
			long totalSize = 0;
			bool exit = false;
			while(lineNo < input.Count-1 && !exit)
			{
				lineNo++;

				var line = input[lineNo];
				var fragments = line.Split(' ');
				if(line[0] == '$')
				{
					switch(fragments[1])
					{
						case "cd":
							if(fragments[2] == "..")
							{
								// go up a level
								exit = true;
								continue;
							}
							totalSize += HandleInput(input, sizePerFolder, fragments[2], ref lineNo);
							break;
						case "ls":
							// nothing 
							continue;
					}
				}
				else
				{
					if(char.IsDigit(line[0]))
					{
						totalSize += Convert.ToInt32(fragments[0]);
					}
				}
			}
			// as the first call is a 'pre state' the 'current folder' is therefore empty. If that's the case we don't need to add the result, as it's the
			// same as the root
			if(currentFolder != string.Empty)
			{
				sizePerFolder.Add(new Pair<string, long>(currentFolder, totalSize));
			}

			return totalSize;
		}


		public static long Solve2(List<string> input)
		{
			int currentLineNo = -1;
			var sizePerFolder = new List<Pair<string, long>>();
			HandleInput(input, sizePerFolder, string.Empty, ref currentLineNo);

			var outerMostFolderPair = sizePerFolder.FirstOrDefault(p => p.Value1 == "/");
			if(outerMostFolderPair == null)
			{
				return -1;
			}
			long currentFreeDiskSpace = 70000000 - outerMostFolderPair.Value2;
			var candidates = sizePerFolder.Where(p => p.Value2 + currentFreeDiskSpace > 30000000);
			return candidates.Min(p => p.Value2);
		}
	}
}