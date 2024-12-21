namespace Advent_of_Code_2024.Day20__Race_Condition;

public class RaceCondition
{
    private MapNode[,] _map;
    private readonly string[] _data = File.ReadAllLines(@"Day20- Race Condition/data.txt");
    private int _xMax;
    private int _yMax;
    private int _xStart;
    private int _yStart;
    private MapNode _finalNode;
    private List<MapNode> _distanceList = [];
    private List<MapNode> _cheats = [];

    public RaceCondition()
    {
        _xMax = _data[0].Length;
        _yMax = _data.Length;
        _map = new MapNode[_xMax, _yMax];
        for (var y = 0; y < _yMax; y++)
        {
            for (int x = 0; x < _xMax; x++)
            {
                _map[x,y] = new MapNode(x, y, _data[y][x]);
                if (_data[y][x] == 'S')
                {
                    _xStart = x;
                    _yStart = y;
                    _map[x, y].Distance = 0;
                    _distanceList.Add(_map[x, y]);
                }
            }
        }
    }
    public void Print()
    {
        for (var y = 0; y < _yMax; y++)
        {
            for (int x = 0; x < _xMax; x++)
            {
                if (_map[x,y].Visited)
                {
                    Console.Write("O");
                }
                else
                {
                    Console.Write(_map[x, y].Symbol);
                }
                
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    private bool FindShortestPath()
    {
        // Print();
        while (true)
        {
            if (_distanceList.Count == 0)
            {
                return false;
            }
            
            var node = _distanceList.OrderBy(r => r.Distance).First();
            _distanceList.Remove(node);
            node.Visited = true;
            var x = node.X;
            var y = node.Y;
            if (node.Symbol == 'E')
            {
                _finalNode = node;
                // Print();
                return true;
            }

            if (x + 1 < _xMax)
            {
                var eastNode = _map[x + 1, y];
                if (eastNode.Symbol != '#' && !eastNode.Visited && eastNode.Distance > node.Distance + 1)
                {
                    eastNode.Distance = node.Distance + 1;
                    eastNode.Previous = node;
                    _distanceList.Add(eastNode);
                }
            }
            if (x - 1 >= 0)
            {
                var westNode = _map[x - 1, y];
                if (westNode.Symbol != '#' && !westNode.Visited && westNode.Distance > node.Distance + 1)
                {
                    westNode.Distance = node.Distance + 1;
                    westNode.Previous = node;
                    _distanceList.Add(westNode);
                }
            }
            if (y + 1 < _yMax)
            {
                var southNode = _map[x, y + 1];
                if (southNode.Symbol != '#' && !southNode.Visited && southNode.Distance > node.Distance + 1)
                {
                    southNode.Distance = node.Distance + 1;
                    southNode.Previous = node;
                    _distanceList.Add(southNode);
                }
            }
            if (y - 1 >= 0)
            {
                var northNode = _map[x, y - 1];
                if (northNode.Symbol != '#' && !northNode.Visited && northNode.Distance > node.Distance + 1)
                {
                    northNode.Distance = node.Distance + 1;
                    northNode.Previous = node;
                    _distanceList.Add(northNode);
                }
            }
        }
    }
    private int BackTrace(MapNode currentNode)
    {
        if (currentNode.Previous == null)
        {
            return 0;
        }
        else
        {
            return 1 + BackTrace(currentNode.Previous);
        }
    }

    public int Part1(int timeSavedThreshold)
    {
        FindShortestPath();
        var noCheatSpeed = _finalNode.Distance;
        
        for (var y = 0; y < _yMax; y++)
        {
            for (int x = 0; x < _xMax; x++)
            {
                if (_map[x, y].Symbol == '#')
                {
                    CleanseTheMap();
                    _map[x, y].Symbol = '.';
                    FindShortestPath();
                    var cheatSpeed = _finalNode.Distance;;
                    var timeSaved = noCheatSpeed - cheatSpeed;
                    if (timeSaved > 0)
                    {
                        _cheats.Add(_map[x, y]);
                        _map[x, y].TimeSavedByCheating = timeSaved;
                    }
                    _map[x, y].Symbol = '#';
                }
            }
        }

        return _cheats.Count(m => m.TimeSavedByCheating >= timeSavedThreshold);
    }
    

    
    private void CleanseTheMap()
    {
        foreach (var node in _map)
        {
            node.Visited = false;
            node.Distance = int.MaxValue;
            node.Previous = null;
            node.Symbol = _data[node.Y][node.X];
        }
        _distanceList = new List<MapNode>();
        _map[_xStart, _yStart].Distance = 0;
        _distanceList.Add(_map[_xStart, _yStart]);
    }
    
    
    private class MapNode(int x, int y,char symbol)
    {
        public int Distance = Int32.MaxValue;
        public int X = x;
        public int Y = y;
        public bool Visited = false;
        public char Symbol = symbol;
        public bool CountedInBackTrace;
        public MapNode Previous = null;
        public int TimeSavedByCheating = 0;
    }
}