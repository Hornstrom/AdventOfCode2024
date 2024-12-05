using System.Text.RegularExpressions;

namespace Advent_of_Code_2024.Day3___Mull_It_Over;

public class MulDataEditor
{
    private readonly string _data = File.ReadAllText(@"Day3 - Mull It Over/data.txt");
    public int MulValue;

    public MulDataEditor()
    {
        var regex = new Regex(@"do\(\)|don't\(\)|mul\(\d+,\d+\)");
        var matches = regex.Matches(_data);

        var enable = true;

        foreach (Match match in matches)
        {
            if (match.Value == "do()")
            {
                enable = true;
            }

            if (match.Value == "don't()")
            {
                enable = false;
            }

            if (match.Value.Contains("mul") && enable)
            {
                MulValue += MulCalculator(match.Value);
            }
        }
        
    }

    private string StringFixer(string input)
    {
        var fix  = Regex.Replace(input, @"don't\(\).+?(?=do\(\))", "");
        return Regex.Replace(fix, @"don't\(\).+", "");
    }

    public int MulCalculator(string mul)
    {
        var regex = new Regex("\\d+");
        var matches = regex.Matches(mul);
        return int.Parse(matches[0].Value) * int.Parse(matches[1].Value);
    }
}