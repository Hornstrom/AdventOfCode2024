namespace Advent_of_Code_2024.Day2___Red_Nosed_Reports;

public class ReportWithDampener
{
    public bool Safe;
    public List<int> Levels = [];
    private bool _increasing;
    private bool _decreaing;

    public ReportWithDampener(string data)
    {
        Safe = true;
        var inputs = data.Split(" ");

        var previousLevel = 0;
        var dampenerUsed = false;

        for (int i = 0; i < inputs.Length; i++)
        {
            var level = int.Parse(inputs[i]);

            if (i != 0)
            {
                var safe = SafetyCheck(previousLevel, level);
                if (!safe && !dampenerUsed)
                {
                    continue;
                }

                Safe = safe;
            }
            Levels.Add(level);
            previousLevel = level;
        }
        
    }

    private bool SafetyCheck(int previousLevel, int level)
    {
        if (level > previousLevel)
        {
            _increasing = true;
            if (_decreaing)
            {
                return false;
            }
        }
        if (level < previousLevel)
        {
            _decreaing = true;
            if (_increasing)
            {
                return false;
            }
        }

        if (Math.Abs(level - previousLevel) > 3 || level == previousLevel)
        {
            return false;
        }
        return true;
    }
}