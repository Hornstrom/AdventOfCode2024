using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2024.Day13__Claw_Contraption.Part2;

public class Arcade
{
    private readonly string[] _data = File.ReadAllLines(@"Day13- Claw Contraption/data.txt");
    private List<ClawMachine> _clawMachines = [];
    
    public Arcade()
    {
        for (int i = 0; i < _data.Length ; i++)
        {
            if (i % 4 == 0)
            {
                _clawMachines.Add(new ClawMachine(_data[i], _data[i + 1], _data[i + 2]));    
            }
        }
    }

    public long Play()
    {
        var tokens = 0L;
        foreach (var clawMachine in _clawMachines)
        {
            if (clawMachine.HasSolution)
            {
                tokens += clawMachine.TokensRequired;
            }
        }
        return tokens;
    }

    private class ClawMachine
    {
        public long TokensRequired;
        public bool HasSolution;
        public long A;
        public long B;
        public ClawMachine(string equation1, string equation2, string pricePosition)
        {
            // Button A: X+94, Y+34
            // Button B: X+22, Y+67
            // Prize: X=8400, Y=5400
            var digitRegex = new Regex("\\d+");
            var eq1matches = digitRegex.Matches(equation1);
            var eq2matches = digitRegex.Matches(equation2);
            var pricePositionMatches = digitRegex.Matches(pricePosition);

            var xe = long.Parse(pricePositionMatches[0].Value) + 10000000000000;
            var ye = long.Parse(pricePositionMatches[1].Value) + 10000000000000;
            
            var x1 = long.Parse(eq1matches[0].Value);
            var x2 = long.Parse(eq2matches[0].Value);
            
            var y1 = long.Parse(eq1matches[1].Value);
            var y2 = long.Parse(eq2matches[1].Value);

            var b = (ye / (double)y1 - xe / (double)x1) / (y2 / (double)y1 - x2 / (double)x1);
            var a = (ye - y2 * b) / (double)y1;

            var aRounded = double.Round(a, 3);
            var bRounded = double.Round(b, 3);
            
            A = (long)aRounded;
            B = (long)bRounded;
            //
            // var b = 1 / (y2 / ye - x2 * y1 / ye * x1) - 1 / (x1 * y2 / xe * y1 - x2 / xe );
            // var a = (ye - y2 * b) / y1;

            if (xe == x1 * A + x2 * B 
                && ye == y1 * A + y2 * B
                && aRounded % 1 == 0
                && bRounded % 1 == 0)
            {
                HasSolution = true;
            }

            TokensRequired = 3 * A + B;
        }
    }
}