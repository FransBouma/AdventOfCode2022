using System;
using System.Collections.Generic;
using System.Linq;
using SD.Tools.Algorithmia.GeneralDataStructures;

namespace AoC2022.Core
{
	public static class Day5
	{
		public static string Solve1(List<string> input)
		{
			var stacks = GetStacks(input, out int movelineStart);
			for(int i = movelineStart; i < input.Count; i++)
			{
				string command = input[i];
				var fragments = command.Split(' ');
				// 0 is 'move', 1 is amount, 2 is 'from', 3 is from stack, 4 is 'to', 5 is to stack
				// from/to stack start at 1 so subtract 1
				var amount = Convert.ToInt32(fragments[1]);
				var fromStack = stacks[Convert.ToInt32(fragments[3]) - 1];
				var toStack = stacks[Convert.ToInt32(fragments[5]) - 1];
				for(int j = 0; j < amount; j++)
				{
					toStack.Push(fromStack.Pop());
				}
			}
			return new string(stacks.Select(s=>s.Peek()).ToArray());
		}


		private static List<Stack<char>> GetStacks(List<string> input, out int movelineStart)
		{
			var tempLists = new List<List<char>>();
			for(int i = 0; i < (input[0].Length / 4) + 1;i++)
			{
				tempLists.Add(new List<char>());
			}
			movelineStart = 0;
			foreach(var row in input)
			{
				if(row[1] == '1')
				{
					// done
					break;
				}

				int charIndex = 0;
				while(charIndex < row.Length)
				{
					var currentStack = tempLists[charIndex / 4];
					if(row[charIndex] != ' ')
					{
						currentStack.Add(row[charIndex + 1]);
					}

					charIndex += 4;
				}

				movelineStart++;
			}
			// moveLineStart is now the line number with the stack numbers. Add 2
			movelineStart += 2;
			
			// All stacks are read from bottom to top, so we now use our lists to create our stack. We have to reverse the lists!
			return tempLists.Select(l => new Stack<char>(((IEnumerable<char>)l).Reverse())).ToList();
		}


		public static string Solve2(List<string> input)
		{
			var stacks = GetStacks(input, out int movelineStart);
			var tempSet = new List<char>();
			for(int i = movelineStart; i < input.Count; i++)
			{
				tempSet.Clear();
				string command = input[i];
				var fragments = command.Split(' ');
				// 0 is 'move', 1 is amount, 2 is 'from', 3 is from stack, 4 is 'to', 5 is to stack
				// from/to stack start at 1 so subtract 1
				var amount = Convert.ToInt32(fragments[1]);
				var fromStack = stacks[Convert.ToInt32(fragments[3]) - 1];
				var toStack = stacks[Convert.ToInt32(fragments[5]) - 1];
				for(int j = 0; j < amount; j++)
				{
					tempSet.Add(fromStack.Pop());
				}
				// we have to reverse push multiple elements
				tempSet.Reverse();
				foreach(var c in tempSet)
				{
					toStack.Push(c);
				}
			}
			return new string(stacks.Select(s=>s.Peek()).ToArray());	
		}
	}
}