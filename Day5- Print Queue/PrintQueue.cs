namespace Advent_of_Code_2024.Day5__Print_Queue;

public class PrintQueue
{
    private readonly string[] _lineStrings = File.ReadAllLines(@"Day5- Print Queue/lines.txt");
    private readonly string[] _ruleStrings = File.ReadAllLines(@"Day5- Print Queue/rules.txt");
    private readonly List<Tuple<int, int>> _rules = [];
    private readonly List<int[]> _incorrectOrderedLines = [];
    public int MiddlePageNumberScore;

    public PrintQueue()
    {
        foreach (var ruleString in _ruleStrings)
        {
            var parts = ruleString.Split("|");
            _rules.Add(new Tuple<int, int>(int.Parse(parts[0]), int.Parse(parts[1])));
        }

        foreach (var lineString in _lineStrings)
        {
            var parts = lineString.Split(",");
            var numbers = parts.Select(int.Parse).ToArray();
            var allRulesFollowed = true;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (!allRulesFollowed)
                {
                    break;
                }
                var matchingRules = _rules.Where(r => r.Item1 == numbers[i]);
                foreach (var matchingRule in matchingRules)
                {
                    if (numbers[..i].Contains(matchingRule.Item2))
                    {
                        allRulesFollowed = false;
                        _incorrectOrderedLines.Add(numbers);
                        break;
                    }
                }
            }

            if (allRulesFollowed)
            {
                MiddlePageNumberScore += numbers[numbers.Length/2];
            }
        }
    }

    public int ReorderIncorrectlyOrderedLines()
    {
        var orderScore = 0;
        foreach (var line in _incorrectOrderedLines)
        {
            ElfSort(line);
            orderScore += line[line.Length/2];
        }
        
        return orderScore;
    }

    public void ElfSort(int[] numbers)
    {
        var orderIsInvalid = true;
        while (orderIsInvalid)
        {
            var allRulesFollowed = true;
            for (int i = 0; i < numbers.Length; i++)
            {
                var matchingRules = _rules.Where(r => r.Item1 == numbers[i]);
                foreach (var matchingRule in matchingRules)
                {
                    if (numbers[..i].Contains(matchingRule.Item2))
                    {
                        allRulesFollowed = false;
                        var badNumber = numbers[i];
                        var blockingNumber = matchingRule.Item2;
                        var indexOfBlockingNumber = Array.IndexOf(numbers[..i], blockingNumber);
                        numbers[i] = blockingNumber;
                        numbers[indexOfBlockingNumber] = badNumber;
                        break;
                    }
                }
            }
            orderIsInvalid = !allRulesFollowed;
        }
    }
    
}