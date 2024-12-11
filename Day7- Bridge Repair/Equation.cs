using System.Runtime.InteropServices.ComTypes;

namespace Advent_of_Code_2024.Day7__Bridge_Repair;

public class Equation
{
    public long Solution;
    public bool HasSolution;
    public long[] Numbers;
    public bool HasPart2Solution;
    

    public Equation(string data)
    {
        var combinedData = data.Split(':');
        Solution = long.Parse(combinedData[0]);
        Numbers = combinedData[1].Trim().Split(' ').Select(long.Parse).ToArray();
        Solve(0, Numbers[0]);
        SolveWithNewOperator(0, Numbers[0]);
    }

    public void Solve(int position, long previousSum)
    {
        if (position == Numbers.Length - 1 && previousSum == Solution)
        {
            HasSolution = true;
        }

        if (position == Numbers.Length - 1 || previousSum > Solution)
        {
            return;
        }
        
        position++;
        var addition = previousSum + Numbers[position];
        var multiplication = previousSum * Numbers[position];
        
        Solve(position, addition);
        Solve(position, multiplication);
    }
    
    public void SolveWithNewOperator(int position, long previousSum)
    {
        if (position == Numbers.Length - 1 && previousSum == Solution)
        {
            HasPart2Solution = true;
        }

        if (position == Numbers.Length - 1 || previousSum > Solution)
        {
            return;
        }
        
        position++;
        var addition = previousSum + Numbers[position];
        var multiplication = previousSum * Numbers[position];
        var concentration = long.Parse(previousSum.ToString() + Numbers[position]);
        
        SolveWithNewOperator(position, addition);
        SolveWithNewOperator(position, multiplication);
        SolveWithNewOperator(position, concentration);
    }
}