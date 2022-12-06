using System;
using System.IO;
using AoC2022.Core;
using NUnit.Framework;

namespace AoC2022.Tests
{
	public class Day5Tests
	{
		[SetUp]
		public void Setup()
		{
		}


		[Test]
		public void Puzzle1_ExampleInput()
		{
			var input = InputReader.GetInputAsStringList("..\\..\\..\\PuzzleInputs\\day5_example.txt");
			Assert.IsTrue(input.Count>0);
			Assert.AreEqual("CMZ", Day5.Solve1(input));
		}

		
		[Test]
		public void Puzzle1_Solver()
		{
			var input = InputReader.GetInputAsStringList("..\\..\\..\\PuzzleInputs\\day5.txt");
			Assert.IsTrue(input.Count>0);
			Console.WriteLine(Day5.Solve1(input));
		}
		
		
		[Test]
		public void Puzzle2_ExampleInput()
		{
			var input = InputReader.GetInputAsStringList("..\\..\\..\\PuzzleInputs\\day5_example.txt");
			Assert.IsTrue(input.Count>0);
			Assert.AreEqual("MCD", Day5.Solve2(input));
		}
		
		
		[Test]
		public void Puzzle2_Solver()
		{
			var input = InputReader.GetInputAsStringList("..\\..\\..\\PuzzleInputs\\day5.txt");
			Assert.IsTrue(input.Count>0);
			Console.WriteLine(Day5.Solve2(input));
		}
	}
}