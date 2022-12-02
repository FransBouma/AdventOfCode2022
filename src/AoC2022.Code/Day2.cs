using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2022.Core
{
	public static class Day2
	{
		private enum OutcomeType
		{
			Tie = 0,
			P1 = 1,
			P2 = 2
		}


		// A==Rock, B==Paper, C==Scissors
		// X==Rock, Y==Paper, Z==Scissors
		// A < Y
		// A > Z
		// B > X
		// B < Z
		// C < X
		// C > Y
		private static OutcomeType DetermineWinner(char p1, char p2)
		{
			if((p1-'A') == (p2-'X'))		
			{
				return OutcomeType.Tie;
			}

			switch(p1)
			{
				case 'A':
					return p2 == 'Z' ? OutcomeType.P1 : OutcomeType.P2;
				case 'B':
					return p2 == 'X' ? OutcomeType.P1 : OutcomeType.P2; 
				case 'C':
					return p2 == 'Y' ? OutcomeType.P1 : OutcomeType.P2;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
		
		private static int DetermineRoundScore(char p1, char p2)
		{
			var winner = DetermineWinner(p1, p2);
			int toReturn = p2 - 'W';		// ascii of X - ascii of W gives 1 for X, 2 for Y and 3 for Z;
			switch(winner)
			{
				case OutcomeType.P1:
					// lost
					toReturn += 0;
					break;
				case OutcomeType.Tie:
					toReturn += 3;
					break;
				case OutcomeType.P2:
					toReturn += 6;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			return toReturn;
		}
		
		public static int Solve1(List<string> input)
		{
			return input.Where(s=>s.Length>0).Sum(round => DetermineRoundScore(round[0], round[2]));
		}

		public static int Solve2(List<string> input)
		{
			// we now have to pre-determine our move char based on the input char, and then calculate the score as-is
			return input.Where(s=>s.Length>0).Sum(round => PreprocessForPuzzle2(round[0], round[2]));
		}


		private static int PreprocessForPuzzle2(char p1, char outcome)
		{
			// determine p2's move based on outcome
			char p2 = ' ';
			switch(outcome)
			{
				case 'X':		// p1 wins
					var x = ((p1 - 'A') - 1);		// can become -1 so we have to check for that
					if(x < 0)
					{
						x +=3;			// see for explanation: https://stackoverflow.com/a/1082938/44991
					}
					p2 = (char)((x % 3) + 'X');
					break;
				case 'Y':		// tie
					p2 = (char)((p1 - 'A') + 'X');
					break;
				case 'Z':		// p2 wins
					p2 = (char)((((p1 - 'A') + 1) % 3) + 'X');
					break;
			}
			return DetermineRoundScore(p1, p2);
		}
	}
}