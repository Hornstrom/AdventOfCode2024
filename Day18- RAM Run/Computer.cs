namespace Advent_of_Code_2024.Day17__RAM_Run;

public class Computer
{
    private RamNode[,] _map;
    
    private int _xMax;
    private int _yMax;
    private int _x;
    private int _y;
    private List<RamNode> _distanceList = [];
    
    public Computer(int size, string[] data)
    {
        _xMax = size + 1;
        _yMax = size + 1;
        
        _map = new RamNode[_xMax, _yMax];
        for (var y = 0; y < _yMax; y++)
        {
            for (int x = 0; x < _xMax; x++)
            {
                _map[x, y] = new RamNode();
                _map[x, y].X = x;
                _map[x, y].Y = y;
                _map[x, y].Symbol = '.';
            }
        }

        foreach (var line in data)
        {
            var coordinates = line.Split(",");
            var x = int.Parse(coordinates[0]);
            var y = int.Parse(coordinates[1]);
            _map[x, y].Symbol = '#';
        }

        _map[0, 0].Visited = true;
        _map[0, 0].Distance = 0;
        _distanceList.Add(_map[0, 0]);
    }

    public int StepsToExit()
    {
        MapTheMemory();
        
        return BackTrace((_map[_xMax-1,_yMax-1]));
    }

    public string CoordinateThatBlockExitPath(string[] data)
    {
        foreach (var line in data)
        {
            CleanseTheMap();
            var coordinates = line.Split(",");
            var x = int.Parse(coordinates[0]);
            var y = int.Parse(coordinates[1]);
            _map[x, y].Symbol = '#';
            if (!MapTheMemory())
            {
                return line;
            }
        }
        return "exit never blocked!";
    }

    private void CleanseTheMap()
    {
        foreach (var node in _map)
        {
            node.Visited = false;
            node.Distance = int.MaxValue;
            node.Previous = null;
        }
        _map[0, 0].Visited = true;
        _map[0, 0].Distance = 0;
        _distanceList.Add(_map[0, 0]);
    }

    private int BackTrace(RamNode currentNode)
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

    private bool MapTheMemory()
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
            if (x == _xMax - 1 && y == _yMax - 1)
            {
                _distanceList = new List<RamNode>();
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
    
    
}