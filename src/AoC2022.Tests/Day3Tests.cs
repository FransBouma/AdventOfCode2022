using System;
using System.IO;
using AoC2022.Core;
using NUnit.Framework;

namespace AoC2022.Tests
{
	public class Day3Tests
	{
		[SetUp]
		public void Setup()
		{
		}


		[Test]
		public void Puzzle1_ExampleInput()
		{
			var input = InputReader.GetInputAsStringList("..\\..\\..\\PuzzleInputs\\day3_example.txt");
			Assert.IsTrue(input.Count>0);
			Assert.AreEqual(157, Day3.Solve1(input));
		}

		
		[Test]
		public void Puzzle1_Solver()
		{
			var input = InputReader.GetInputAsStringList("..\\..\\..\\PuzzleInputs\\day3.txt");
			Assert.IsTrue(input.Count>0);
			Console.WriteLine(Day3.Solve1(input));
		}
		
		
		[Test]
		public void Puzzle2_ExampleInput()
		{
			var input = InputReader.GetInputAsStringList("..\\..\\..\\PuzzleInputs\\day3_example.txt");
			Assert.IsTrue(input.Count>0);
			Assert.AreEqual(70, Day3.Solve2(input));
		}
		
		
		[Test]
		public void Puzzle2_Solver()
		{
			var input = InputReader.GetInputAsStringList("..\\..\\..\\PuzzleInputs\\day3.txt");
			Assert.IsTrue(input.Count>0);
			Console.WriteLine(Day3.Solve2(input));
		}
	}
}