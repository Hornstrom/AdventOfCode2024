// See https://aka.ms/new-console-template for more information

using Advent_of_Code_2024.Day1___Order_my_list_please.Part1;
using Advent_of_Code_2024.Day10__Hoof_It;
using Advent_of_Code_2024.Day11__Plutonian_Pebbles;
using Advent_of_Code_2024.Day12__Garden_Groups;
using Advent_of_Code_2024.Day13__Claw_Contraption;
using Advent_of_Code_2024.Day14_Restroom_Redoubt;
using Advent_of_Code_2024.Day15__Warehouse_Woes;
using Advent_of_Code_2024.Day16__Reindeer_Maze;
using Advent_of_Code_2024.Day17__RAM_Run;
using Advent_of_Code_2024.Day2___Red_Nosed_Reports;
using Advent_of_Code_2024.Day3___Mull_It_Over;
using Advent_of_Code_2024.Day4__Ceres_Search;
using Advent_of_Code_2024.Day5__Print_Queue;
using Advent_of_Code_2024.Day6__Guard_Gallivant;
using Advent_of_Code_2024.Day7__Bridge_Repair;
using Advent_of_Code_2024.Day8__Resonant_Collinearity;
using Advent_of_Code_2024.Day9__Disk_Fragmenter;
using Advent_of_Code_2024.Day9__Disk_Fragmenter.Part1;


Console.WriteLine("Advent of Code 2024 - The Hunt for the Chief Historian");
Console.WriteLine("");
//
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

// Console.WriteLine("--- Day 8: Resonant Collinearity ---");
// var antiNodeMapper = new AntinodeMapper();
// Console.WriteLine("Part 1: " + antiNodeMapper.FindAntinodes());
// antiNodeMapper.DrawMap();
// Console.WriteLine("Part 2: " + antiNodeMapper.ApplyResonantHarmonics());
// antiNodeMapper.DrawMap();

//
// Console.WriteLine("--- Day 9: Disk Fragmenter ---");
// var diskDefrager = new DiskDefragmenter();
// diskDefrager.Defragment();
// Console.WriteLine("Part 1: " + diskDefrager.CalculateChecksum());
// var diskDefrager2 = new Advent_of_Code_2024.Day9__Disk_Fragmenter.Part2.DiskDefragmenter();
// diskDefrager2.Defragment();
// Console.WriteLine("Part 2: " + diskDefrager2.CalculateChecksum());


// Console.WriteLine("--- Day 10: Hoof It ---");
// var trailFinder = new TrailFinder();
// Console.WriteLine("Part 1: " + trailFinder.FindTrails());
// Console.WriteLine("Part 2: " + new TrailFinder2().FindTrails());
//
// Console.WriteLine("--- Day 11: Plutonian Pebbles ---");
// var peppleMultiplier = new PebbleMultiplier();
// Console.WriteLine("Part 1: " + peppleMultiplier.Blink(25));
// Console.WriteLine("Part 2: " + new PebbleMultiplier().SmartBlink3(75));


// Console.WriteLine("--- Day 12: Garden Groups ---");
// var gardenMapper = new GardenMapper();
// Console.WriteLine("Part 1: " + gardenMapper.FenceGardenPlots());
// Console.WriteLine("Part 2: " + gardenMapper.BulkDiscount());

// Console.WriteLine("--- Day 13: Claw Contraption ---");
// var arcade = new Arcade();
// Console.WriteLine("Part 1: " + arcade.Play()); // 21884 to low  // 31435 to low  // 33772 to high, 31552 correct
// Console.WriteLine("Part 2: " + new Advent_of_Code_2024.Day13__Claw_Contraption.Part2.Arcade().Play()); // 160830447803240 too high // 106947079683957 too high // 68369936555881 not the right answer


// Console.WriteLine("--- Day 14: Restroom Redoubt ---");
// Console.WriteLine("Part 1: " + new RobotSecurity().Run(100)); // 83445876 to low
// Console.WriteLine("Part 2: " + new RobotSecurity().Run(1000000));

// Console.WriteLine("--- Day 15: Warehouse Woes ---");
// Console.WriteLine("Part 1: " + new Warehouse().Part1()); 
// Console.WriteLine("Part 2: " + new Warehouse2().Part2()); //1489556 to low --1506070 to low

// Console.WriteLine("--- Day 16: Reindeer Maze ---");
// var olympics = new Olympics();
// Console.WriteLine("Part 1: " + olympics.ExploreMace());  // 75414 to low, 75416 correct
// Console.WriteLine("Part 2: " + olympics.FindBestSeats()); // 429 to low

Console.WriteLine("--- Day 18: RAM Run ---");

var data = File.ReadAllLines(@"Day18- RAM Run/data.txt");
var size = 70;
var computer = new Computer(size, data[..1024]);

Console.WriteLine("Part 1: " + computer.StepsToExit()); //248 right answer
Console.WriteLine("Part 2: " + computer.CoordinateThatBlockExitPath(data[1024..])); //32,55 right answer

