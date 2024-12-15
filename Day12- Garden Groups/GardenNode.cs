namespace Advent_of_Code_2024.Day12__Garden_Groups;

public class GardenNode
{
    public char Crop;
    public bool HasBeenMapped;
    public int X;
    public int Y;

    public GardenNode(int x, int y, char crop)
    {
        X = x;
        Y = y;
        Crop = crop;
    }
}