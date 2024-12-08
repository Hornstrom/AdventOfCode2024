namespace Advent_of_Code_2024.Day8__Resonant_Collinearity;

public class MapNode
{
    public bool IsAntenna;
    public List<char> AntiNodeForFrequency = [];
    public int X;
    public int Y;
    public char Symbol;

    public MapNode(char symbol, int x, int y)
    {
        if (symbol != '.')
        {
            IsAntenna = true;
        }

        X = x;
        Y = y;
        Symbol = symbol;
    }

    public void AddAntiNodeFrequency(char symbol)
    {
        if (!AntiNodeForFrequency.Contains(symbol))
        {
            AntiNodeForFrequency.Add(symbol);
        }
    }
}