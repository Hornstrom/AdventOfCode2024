// See https://aka.ms/new-console-template for more information

using Advent_of_Code_2024.Day1___Order_my_list_please.Part1;
using Advent_of_Code_2024.Day2___Red_Nosed_Reports;

Console.WriteLine("Advent of Code 2024 - The Hunt for the Chief Historian");
Console.WriteLine("");

Console.WriteLine("--- Day 1: Historian Hysteria ---");
var listSorter = new ListSorter();
Console.WriteLine("Part 1: " + listSorter.CalculateDistance());
Console.WriteLine("Part 2: " + listSorter.SimilarityScore());

Console.WriteLine("--- Day 2: Red-Nosed Reports ---");
var reportReader = new ReportReader();
Console.WriteLine("Part 1: " + reportReader.Reports.Count(x => x.Safe));
Console.WriteLine("Part 2: " + reportReader.ReportWithDampeners.Count(x => x.Safe));
//598 to high