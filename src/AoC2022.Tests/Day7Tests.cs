using System;
using System.IO;
using AoC2022.Core;
using NUnit.Framework;

namespace AoC2022.Tests
{
	public class Day7Tests
	{
		[SetUp]
		public void Setup()
		{
		}


		[Test]
		public void Puzzle1_ExampleInput()
		{
			var input = InputReader.GetInputAsStringList("..\\..\\..\\PuzzleInputs\\day7_example.txt");
			Assert.IsTrue(input.Count>0);
			Assert.AreEqual(95437, Day7.Solve1(input));
		}

		
		[Test]
		public void Puzzle1_Solver()
		{
			var input = InputReader.GetInputAsStringList("..\\..\\..\\PuzzleInputs\\day7.txt");
			Assert.IsTrue(input.Count>0);
			Console.WriteLine(Day7.Solve1(input));
		}
		
		
		[Test]
		public void Puzzle2_ExampleInput()
		{
			var input = InputReader.GetInputAsStringList("..\\..\\..\\PuzzleInputs\\day7_example.txt");
			Assert.IsTrue(input.Count>0);
			Assert.AreEqual(24933642, Day7.Solve2(input));
		}
		
		
		[Test]
		public void Puzzle2_Solver()
		{
			var input = InputReader.GetInputAsStringList("..\\..\\..\\PuzzleInputs\\day7.txt");
			Assert.IsTrue(input.Count>0);
			Console.WriteLine(Day7.Solve2(input));
		}
	}
}