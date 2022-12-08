using System;
using System.IO;
using AoC2022.Core;
using NUnit.Framework;

namespace AoC2022.Tests
{
	public class Day8Tests
	{
		[SetUp]
		public void Setup()
		{
		}


		[Test]
		public void Puzzle1_ExampleInput()
		{
			var input = InputReader.GetInputAs2DIntArrayList("..\\..\\..\\PuzzleInputs\\day8_example.txt");
			Assert.IsTrue(input.Length>0);
			Assert.AreEqual(21, Day8.Solve1(input));
		}

		
		[Test]
		public void Puzzle1_Solver()
		{
			var input = InputReader.GetInputAs2DIntArrayList("..\\..\\..\\PuzzleInputs\\day8.txt");
			Assert.IsTrue(input.Length>0);
			Console.WriteLine(Day8.Solve1(input));
		}
		
		
		[Test]
		public void Puzzle2_ExampleInput()
		{
			var input = InputReader.GetInputAs2DIntArrayList("..\\..\\..\\PuzzleInputs\\day8_example.txt");
			Assert.IsTrue(input.Length>0);
			Assert.AreEqual(8, Day8.Solve2(input));
		}
		
		
		[Test]
		public void Puzzle2_Solver()
		{
			var input = InputReader.GetInputAs2DIntArrayList("..\\..\\..\\PuzzleInputs\\day8.txt");
			Assert.IsTrue(input.Length>0);
			Console.WriteLine(Day8.Solve2(input));
		}
	}
}