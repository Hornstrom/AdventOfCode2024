using System.Text.RegularExpressions;

namespace Advent_of_Code_2024.Day3___Mull_It_Over;

public class MulDataParser
{
    private readonly string _data = File.ReadAllText(@"Day3 - Mull It Over/data.txt");
    public int MulValue;

    public MulDataParser()
    {
        var regex = new Regex("mul\\(\\d+,\\d+\\)");
        var matches = regex.Matches(_data);

        foreach (Match match in matches)
        {
            MulValue += MulCalculator(match.Value);
        }
    }

    public int MulCalculator(string mul)
    {
        var regex = new Regex("\\d+");
        var matches = regex.Matches(mul);
        return int.Parse(matches[0].Value) * int.Parse(matches[1].Value);
        
    }
}