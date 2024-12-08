namespace Advent_of_Code_2024.Day2___Red_Nosed_Reports;

public class ReportWithDampener
{
    public bool Safe;
    private bool _increasing;
    private bool _decreasing;

    public ReportWithDampener(string data)
    {
        Safe = true;
        var inputs = data.Split(" ");
        var levels = Array.ConvertAll(inputs, int.Parse);
        
        Safe = SafetyCheck(levels);
        if(Safe) return;
        
        for (int i = 0; i < levels.Length; i++)
        {
            var arrayWithoutIndex = levels[..i].Concat(levels[(i+1)..]).ToArray();
            Safe = SafetyCheck(arrayWithoutIndex);
            if(Safe) return;
        }
        
    }

    private bool SafetyCheck(int[] levels)
    {
        var safe = true;
        _increasing = false;
        _decreasing = false;
        for (int i = 0; i < levels.Length - 1; i++)
        {
            safe = SafetyCheck(levels[i], levels[i + 1]);
            if (!safe)
            {
                return false;
            }
        }
        return safe;
    }

    private bool SafetyCheck(int previousLevel, int level)
    {
        if (level > previousLevel)
        {
            _increasing = true;
            if (_decreasing)
            {
                return false;
            }
        }
        if (level < previousLevel)
        {
            _decreasing = true;
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