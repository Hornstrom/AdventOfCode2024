namespace Advent_of_Code_2024.Day7__Bridge_Repair;

public class OperatorFinder
{
    private readonly string[] _data = File.ReadAllLines(@"Day7- Bridge Repair/data.txt");
    public List<Equation> Equations = [];

    public OperatorFinder()
    {
        foreach (var line in _data)
        {
            Equations.Add(new Equation(line));
        }
    }
}