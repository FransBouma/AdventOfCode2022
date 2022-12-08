using System;
using System.Collections.Generic;
using System.Linq;
using SD.Tools.Algorithmia.GeneralDataStructures;

namespace AoC2022.Core
{
	public static class Day8
	{
		public static long Solve1(int[,] input)
		{
			var toReturn = input.GetLength(0) * 2 + (input.GetLength(1) - 2) * 2;
			for(int x = 1; x < input.GetLength(0) - 1; x++)
			{
				for(int y = 1; y < input.GetLength(1) - 1; y++)
				{
					if(IsVisible(x, y, input))
					{
						toReturn += 1;
					}
				}
			}
			return toReturn;
		}


		private static bool IsVisible(int x, int y, int[,] input)
		{
			var toReturn = IsVisibleInDirection(x, y, input, -1, 0);
			toReturn |= IsVisibleInDirection(x, y, input, 1, 0);
			toReturn |= IsVisibleInDirection(x, y, input, 0, -1);
			toReturn |= IsVisibleInDirection(x, y, input, 0, 1);
			
			return toReturn;
			
		}


		private static bool IsVisibleInDirection(int x, int y, int[,] input, int directionX, int directionY)
		{
			int treeHeight = input[x, y];
			
			int tmpX = x+directionX;
			int tmpY = y+directionY;
			bool toReturn = true;
			while(tmpX >= 0 && tmpY >= 0 && tmpX < input.GetLength(0) && tmpY < input.GetLength(1))
			{
				if(input[tmpX, tmpY] >= treeHeight)
				{
					// not visible in this direction
					toReturn = false;
					break;
				}
				tmpX += directionX;
				tmpY += directionY;
			}

			return toReturn;
		}

		
		private static int CalculateScenicScore(int x, int y, int[,] input)
		{
			var toReturn = CalculateScenicScoreInDirection(x, y, input, -1, 0);
			toReturn *= CalculateScenicScoreInDirection(x, y, input, 1, 0);
			toReturn *= CalculateScenicScoreInDirection(x, y, input, 0, -1);
			toReturn *= CalculateScenicScoreInDirection(x, y, input, 0, 1);
			
			return toReturn;
		}


		private static int CalculateScenicScoreInDirection(int x, int y, int[,] input, int directionX, int directionY)
		{
			int treeHeight = input[x, y];
			
			int tmpX = x+directionX;
			int tmpY = y+directionY;
			int toReturn = 0;
			while(tmpX >= 0 && tmpY >= 0 && tmpX < input.GetLength(0) && tmpY < input.GetLength(1))
			{
				toReturn += 1;
				if(input[tmpX, tmpY] >= treeHeight)
				{
					// we run into a tree that's blocking the view, return the steps we took
					break;
				}
				tmpX += directionX;
				tmpY += directionY;
			}

			return toReturn;
		}

		
		
		public static long Solve2(int[,] input)
		{
			var maxScenicScore = 0;
			for(int x = 1; x < input.GetLength(0) - 1; x++)
			{
				for(int y = 1; y < input.GetLength(1) - 1; y++)
				{
					maxScenicScore = Math.Max(maxScenicScore, CalculateScenicScore(x, y, input));
				}
			}
			return maxScenicScore;
		}
	}
}