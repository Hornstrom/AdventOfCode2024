namespace Advent_of_Code_2024.Day10__Hoof_It;

public class TrailFinder2
{
    private readonly string[] _data = File.ReadAllLines(@"Day10- Hoof It/data.txt");
    private HoofNode[,] _map;
    private int _xMax;
    private int _yMax;
    private int _hikingTrails;

    public TrailFinder2()
    {
        _xMax = _data[0].Length;
        _yMax = _data.Length;
        _map = new HoofNode[_xMax,_yMax];

        for (int y = 0; y < _yMax; y++)
        {
            for (int x = 0; x < _xMax; x++)
            {
                _map[x, y] = new HoofNode(x, y, int.Parse(_data[y][x].ToString()));
            }
        }
    }

    public int FindTrails()
    {
        var score = 0;
        for (int y = 0; y < _yMax; y++)
        {
            for (int x = 0; x < _xMax; x++)
            {
                if (_map[x, y].IsTrailHead)
                {
                    var placesVisited = new HashSet<HoofNode>();
                    SearchForPaths(x, y, placesVisited);
                    score += CountScore();
                }
            }
        }
        return score;
    }

    private void SearchForPaths(int x, int y, HashSet<HoofNode> placesVisited)
    {
        if (placesVisited.Contains(_map[x, y]))
        {
            return;
        }
        
        placesVisited.Add(_map[x, y]);
        if (_map[x, y].Elevation == 9)
        {
            _map[x, y].TopPointReached = true;
            _hikingTrails++;
            return;
        }
        
        var freshHashSet = new HashSet<HoofNode>();
        foreach (var hoofNode in placesVisited)
        {
            freshHashSet.Add(hoofNode);
        }

        if (x + 1 < _xMax && _map[x + 1, y].Elevation == _map[x, y].Elevation + 1)
        {
            SearchForPaths(x + 1, y, freshHashSet);
        }
        if (x - 1 >= 0 && _map[x - 1, y].Elevation == _map[x, y].Elevation + 1)
        {
            SearchForPaths(x - 1, y, freshHashSet);
        }
        if (y + 1 < _yMax && _map[x, y + 1].Elevation == _map[x, y].Elevation + 1)
        {
            SearchForPaths(x, y + 1, freshHashSet);
        }
        if (y - 1 >= 0 && _map[x, y - 1].Elevation == _map[x, y].Elevation + 1)
        {
            SearchForPaths(x, y - 1, freshHashSet);
        }
    }

    private int CountScore()
    {
        var score = _hikingTrails;
        _hikingTrails = 0;
        return score;
    }
}