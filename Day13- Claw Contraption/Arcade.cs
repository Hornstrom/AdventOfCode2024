using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2024.Day13__Claw_Contraption;

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

    public int Play()
    {
        var tokens = 0;
        foreach (var clawMachine in _clawMachines)
        {
            if (clawMachine.HasSolution && clawMachine is { A: <= 100, B: <= 100 })
            {
                tokens += clawMachine.TokensRequired;
            }
        }
        return tokens;
    }

    private class ClawMachine
    {
        public int TokensRequired;
        public bool HasSolution;
        public int A;
        public int B;
        public ClawMachine(string equation1, string equation2, string pricePosition)
        {
            // Button A: X+94, Y+34
            // Button B: X+22, Y+67
            // Prize: X=8400, Y=5400
            var digitRegex = new Regex("\\d+");
            var eq1matches = digitRegex.Matches(equation1);
            var eq2matches = digitRegex.Matches(equation2);
            var pricePositionMatches = digitRegex.Matches(pricePosition);

            var xe = float.Parse(pricePositionMatches[0].Value);
            var ye = float.Parse(pricePositionMatches[1].Value);
            
            var x1 = float.Parse(eq1matches[0].Value);
            var x2 = float.Parse(eq2matches[0].Value);
            
            var y1 = float.Parse(eq1matches[1].Value);
            var y2 = float.Parse(eq2matches[1].Value);

            var b = (ye / y1 - xe / x1) / (y2 / y1 - x2 / x1);
            var a = (ye - y2 * b) / y1;

            if (Math.Round(xe) == Math.Round(x1 * a + x2 * b) 
                && Math.Round(ye) == Math.Round(y1 * a + y2 * b)
                && Math.Round(b, 2) == Math.Round(b, 0)
                && Math.Round(a, 2) == Math.Round(a, 0))
            {
                HasSolution = true;
            }

            A = (int)Math.Round(a, 0);
            B = (int)Math.Round(b, 0);

            TokensRequired = 3 * A + B;
        }
    }
}