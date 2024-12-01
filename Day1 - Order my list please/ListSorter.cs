namespace Advent_of_Code_2024.Day1___Order_my_list_please.Part1;

public class ListSorter
{
    private readonly string[] _data = File.ReadAllLines(@"Day1 - Order my list please\data.txt");

    private List<int> _leftNumbers = new List<int>();
    private List<int> _rightNumbers = new List<int>();

    public ListSorter()
    {
        foreach (var row in _data)
        {
            var splited = row.Split("   ");
            _leftNumbers.Add(int.Parse(splited[0]));
            _rightNumbers.Add(int.Parse(splited[1]));
        }
        
        _leftNumbers = _leftNumbers.OrderBy(x => x).ToList();
        _rightNumbers = _rightNumbers.OrderBy(x => x).ToList();
    }

    public int CalculateDistance()
    {
        var distanceTotal = 0;
        for (int i = 0; i < _leftNumbers.Count; i++)
        {
            var distance = _leftNumbers[i] - _rightNumbers[i];
            distanceTotal += Math.Abs(distance);
        }
        return distanceTotal;
    }
    
    public int SimilarityScore()
    {
        var totalScore = 0;
        for (int i = 0; i < _leftNumbers.Count; i++)
        {
            var rightCount = _rightNumbers.Count(x => x == _leftNumbers[i]);
            var score = _leftNumbers[i] * rightCount;
            totalScore += score;
        }
        return totalScore;
    }
}
