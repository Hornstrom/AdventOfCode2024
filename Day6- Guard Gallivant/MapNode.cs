namespace Advent_of_Code_2024.Day6__Guard_Gallivant;

public class MapNode
{
    public bool Visited { get; set; }
    public bool StartNode { get; set; }
    public bool IsObstacle { get; set; }
    public char Symbol { get; set; }
    public List<char> PreviousDirections { get; set; }
    public MapNode(char c)
    {
        Symbol = c;
        PreviousDirections = [];
        switch (c)
        {
            case '#':
                IsObstacle = true;
                break;
            case '^':
                StartNode = true;
                break;
        }
    }
}