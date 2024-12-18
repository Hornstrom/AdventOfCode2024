namespace Advent_of_Code_2024.Day17__RAM_Run;

public class RamNode
{
    public int X;
    public int Y;
    public char Symbol;
    public bool Visited;
    public int Distance = Int32.MaxValue;
    public RamNode Previous;
}