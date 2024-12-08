// See https://aka.ms/new-console-template for more information

using Advent_of_Code_2024.Day1___Order_my_list_please.Part1;
using Advent_of_Code_2024.Day2___Red_Nosed_Reports;
using Advent_of_Code_2024.Day3___Mull_It_Over;
using Advent_of_Code_2024.Day4__Ceres_Search;
using Advent_of_Code_2024.Day5__Print_Queue;
using Advent_of_Code_2024.Day6__Guard_Gallivant;
using Advent_of_Code_2024.Day7__Bridge_Repair;
using Advent_of_Code_2024.Day8__Resonant_Collinearity;


Console.WriteLine("Advent of Code 2024 - The Hunt for the Chief Historian");
Console.WriteLine("");

// Console.WriteLine("--- Day 1: Historian Hysteria ---");
// var listSorter = new ListSorter();
// Console.WriteLine("Part 1: " + listSorter.CalculateDistance());
// Console.WriteLine("Part 2: " + listSorter.SimilarityScore());
//
// Console.WriteLine("--- Day 2: Red-Nosed Reports ---");
// var reportReader = new ReportReader();
// Console.WriteLine("Part 1: " + reportReader.Reports.Count(x => x.Safe));
// Console.WriteLine("Part 2: " + reportReader.ReportWithDampeners.Count(x => x.Safe));
//
// Console.WriteLine("--- Day 3: Mull It Over ---");
// var mulDataParser = new MulDataParser();
// var mulDataEditor = new MulDataEditor();
// Console.WriteLine("Part 1: " + mulDataParser.MulValue);
// Console.WriteLine("Part 2: " + mulDataEditor.MulValue);
//
// Console.WriteLine("--- Day 4: Ceres Search ---");
// var wordPuzzle = new WordPuzzle();
// Console.WriteLine("Part 1: " + wordPuzzle.XmasCount());
// Console.WriteLine("Part 2: " + wordPuzzle.MasCrossCount());
//
// Console.WriteLine("--- Day 5: Print Queue ---");
// var printQueue = new PrintQueue();
// Console.WriteLine("Part 1: " + printQueue.MiddlePageNumberScore);
// Console.WriteLine("Part 2: " + printQueue.ReorderIncorrectlyOrderedLines());
//
// Console.WriteLine("--- Day 6: Guard Gallivant ---");
// var patrolMapper = new PatrolMapper();
// patrolMapper.Patrol();
// Console.WriteLine("Part 1: " + patrolMapper.CountVisitedSpaces());
// Console.WriteLine("Part 2: " + patrolMapper.NumberOfObstaclePositionsThatCauseALoop());
//
// Console.WriteLine("--- Day 7: Bridge Repair ---");
// var operationsFinder = new OperatorFinder();
// Console.WriteLine("Part 1: " + operationsFinder.Equations.Where(e => e.HasSolution).Sum(e => e.Solution));
// Console.WriteLine("Part 2: " + operationsFinder.Equations.Where(e => e.HasPart2Solution).Sum(e => e.Solution));

Console.WriteLine("--- Day 8: Resonant Collinearity ---");
var antiNodeMapper = new AntinodeMapper();
Console.WriteLine("Part 1: " + antiNodeMapper.FindAntinodes());
antiNodeMapper.DrawMap();
Console.WriteLine("Part 2: " + antiNodeMapper.ApplyResonantHarmonics());
antiNodeMapper.DrawMap();
