namespace Advent_of_Code_2024.Day10__Hoof_It;

public class HoofNode
{
    public bool IsTrailHead;
    public int Elevation;
    public List<HoofNode> TrailEndsReached = [];
    public int X;
    public int Y;
    public bool TopPointReached;

    public HoofNode(int x, int y, int elevation)
    {
        X = x;
        Y = y;
        Elevation = elevation;
        if(Elevation == 0)
        {
            IsTrailHead = true;
        }
    }
}