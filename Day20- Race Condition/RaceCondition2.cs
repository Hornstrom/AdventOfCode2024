namespace Advent_of_Code_2024.Day20__Race_Condition;

public class RaceCondition2
{
    private MapNode[,] _map;
    private readonly string[] _data = File.ReadAllLines(@"Day20- Race Condition/data.txt");
    private int _xMax;
    private int _yMax;
    private int _xStart;
    private int _yStart;
    private MapNode? _finalNode;
    private List<MapNode> _distanceList = [];
    private List<MapNode> _cheats = [];
    private int _noCheatSpeed = Int32.MaxValue;

    public RaceCondition2()
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

    private int FindShortestPath(bool fillCheatNodes)
    {
        
        // Print();
        while (true)
        {
            if (_distanceList.Count == 0)
            {
                return int.MaxValue;
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
                return node.Distance;
            }

            if (node.Distance >= _noCheatSpeed)
            {
                return node.Distance;
            }

            if (fillCheatNodes)
            {
                
                for (int x2 = x - 20; x2 <= x + 20; x2++)
                {
                    var cheatStepsTaken = Math.Abs(x2 - x);
                    var yDirectionSteps = 20 - cheatStepsTaken;
                    for (int y2 = y - yDirectionSteps; y2 <= y + yDirectionSteps; y2++)
                    {
                        if (x2 >= 0 && x2 < _xMax && y2 >= 0 && y2 < _yMax)
                        {
                            var targetNode = _map[x2, y2];
                            if (!targetNode.Visited && targetNode.Symbol != '#')
                            {
                                var cheatNode = new MapNode(targetNode.X, targetNode.Y, targetNode.Symbol);
                                cheatNode.JumpDistance = Math.Abs(x2 - x) + Math.Abs(y2 - y);
                                cheatNode.Distance = node.Distance + cheatNode.JumpDistance;
                                cheatNode.Previous = node;
                                _cheats.Add(cheatNode);
                            }
                        }
                    }
                }
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
    private int BackTrace(MapNode? currentNode)
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

    public int Part2(int timeSavedThreshold)
    {
        _noCheatSpeed = FindShortestPath(true);
        var nrOfGoodCheats = 0;
        Console.WriteLine($"Total number of cheats {_cheats.Count}");;
        var nrOfCheatsProcessed = 0;
        
        foreach (var cheat in _cheats)
        {
            nrOfCheatsProcessed++;
            CleanseTheMap();
            _distanceList.Add(cheat);
            var cheatSpeed = FindShortestPath(false);
            var timeSaved = _noCheatSpeed - cheatSpeed;
            if (timeSaved >= timeSavedThreshold)
            {
                nrOfGoodCheats++;
                // Console.WriteLine($"{timeSaved} on cheat {cheat.X}, {cheat.Y}");
                if (nrOfGoodCheats % 1000 == 0)
                {
                    Console.WriteLine($"Nr of good cheats found {nrOfGoodCheats} out of {nrOfCheatsProcessed}");
                }
            }
        }
        return nrOfGoodCheats;
        
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
        _distanceList = [];
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
        public int JumpDistance = 0;
        public bool CheatTested = false;
        public MapNode? Previous = null;
        public int TimeSavedByCheating = 0;
    }
}