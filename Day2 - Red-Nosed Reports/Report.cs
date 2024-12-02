namespace Advent_of_Code_2024.Day2___Red_Nosed_Reports;

public class Report
{
    public bool Safe;
    public List<int> Levels = [];

    public Report(string data)
    {
        Safe = true;
        var inputs = data.Split(" ");

        var increasing = false;
        var decreasing = false;

        var previousLevel = 0;

        for (int i = 0; i < inputs.Length; i++)
        {
            var level = int.Parse(inputs[i]);
            Levels.Add(level);

            if (i != 0)
            {
                if (level > previousLevel)
                {
                    increasing = true;
                    if (decreasing)
                    {
                        //Level has both increased and decreased
                        Safe = false;
                        return;
                    }
                }
                if (level < previousLevel)
                {
                    decreasing = true;
                    if (increasing)
                    {
                        //Level has both increased and decreased
                        Safe = false;
                        return;
                    }
                }

                if (Math.Abs(level - previousLevel) > 3 || level == previousLevel)
                {
                    Safe = false;
                    return;
                }
                
            }
            previousLevel = level;
        }
        
    }
}