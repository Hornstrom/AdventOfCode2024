using Advent_of_Code_2024.Day5__Print_Queue;

namespace Advent_of_Code_2024.Day16__Reindeer_Maze;

public class Olympics
{
    private MazeNode[,] _map;
    private readonly string[] _data = File.ReadAllLines(@"Day16- Reindeer Maze/testdata.txt");
    private int _xMax;
    private int _yMax;
    private int _x;
    private int _y;
    public List<Tuple<int,int>> CountedInBackTrace { get; set; } = new List<Tuple<int,int>>();

    private DirectionNode FinalNode;
    // private string _faceing = "East";
    private List<DirectionNode> _distanceList = [];
    

    public Olympics()
    {
        _xMax = _data[0].Length;
        _yMax = _data.Length;
        _map = new MazeNode[_xMax, _yMax];
        for (var y = 0; y < _yMax; y++)
        {
            for (int x = 0; x < _xMax; x++)
            {
                _map[x,y] = new MazeNode(x, y, _data[y][x]);
                if (_data[y][x] == 'S')
                {
                    _x = x;
                    _y = y;
                    _map[x, y].East.ShortestDistance = 0;
                    _distanceList.Add(_map[x, y].East);
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
                if (x == _x && y == _y)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.Write(_map[x, y].Symbol);
            }
            Console.WriteLine();
        }
    }
    
    

    public int ExploreMace()
    {
        while (true)
        {
            // Print();
            var currentNode = _distanceList.OrderBy(d => d.ShortestDistance).First();
            _distanceList.Remove(currentNode);
            currentNode.Visited = true;
            _x = currentNode.X;
            _y = currentNode.Y;
            if (currentNode.Symbol == 'E')
            {
                FinalNode = currentNode;
                return currentNode.ShortestDistance;
            }

            if (currentNode.Facing == "East")
            {
                var eastNode = _map[_x + 1, _y].East;
                if (eastNode.Visited == false && eastNode.Symbol != '#' && eastNode.ShortestDistance >= currentNode.ShortestDistance + 1)
                {
                    if (eastNode.ShortestDistance < currentNode.ShortestDistance + 1)
                    {
                        _distanceList.Add(eastNode);
                        eastNode.ShortestDistance = currentNode.ShortestDistance + 1;
                    }
                    eastNode.ShortestPathThrough.Add(currentNode);
                }
                var northNode = _map[_x, _y - 1].North;
                if (northNode.Visited == false && northNode.Symbol != '#' && northNode.ShortestDistance >= currentNode.ShortestDistance + 1001)
                {
                    _distanceList.Add(northNode);
                    northNode.ShortestDistance = currentNode.ShortestDistance + 1001;
                    northNode.ShortestPathThrough.Add(currentNode);
                }
                var southNode = _map[_x, _y + 1].South;
                if (southNode.Visited == false && southNode.Symbol != '#' && southNode.ShortestDistance >= currentNode.ShortestDistance + 1001)
                {
                    _distanceList.Add(southNode);
                    southNode.ShortestDistance = currentNode.ShortestDistance + 1001;
                    southNode.ShortestPathThrough.Add(currentNode);
                }
            }
            
            if (currentNode.Facing == "North")
            {
                var eastNode = _map[_x + 1, _y].East;
                if (eastNode.Visited == false && eastNode.Symbol != '#' && eastNode.ShortestDistance >= currentNode.ShortestDistance + 1001)
                {
                    _distanceList.Add(eastNode);
                    eastNode.ShortestDistance = currentNode.ShortestDistance + 1001;
                    eastNode.ShortestPathThrough.Add(currentNode);
                }
                var northNode = _map[_x, _y - 1].North;
                if (northNode.Visited == false && northNode.Symbol != '#' && northNode.ShortestDistance >= currentNode.ShortestDistance + 1)
                {
                    _distanceList.Add(northNode);
                    northNode.ShortestDistance = currentNode.ShortestDistance + 1;
                    northNode.ShortestPathThrough.Add(currentNode);
                }
                var westNode = _map[_x - 1, _y].West;
                if (westNode.Visited == false && westNode.Symbol != '#' && westNode.ShortestDistance >= currentNode.ShortestDistance + 1001)
                {
                    _distanceList.Add(westNode);
                    westNode.ShortestDistance = currentNode.ShortestDistance + 1001;
                    westNode.ShortestPathThrough.Add(currentNode);
                }
            }
            if (currentNode.Facing == "West")
            {
                var westNode = _map[_x - 1, _y].West;
                if (westNode.Visited == false && westNode.Symbol != '#' && westNode.ShortestDistance >= currentNode.ShortestDistance + 1)
                {
                    _distanceList.Add(westNode);
                    westNode.ShortestDistance = currentNode.ShortestDistance + 1;
                    westNode.ShortestPathThrough.Add(currentNode);
                }
                var northNode = _map[_x, _y - 1].North;
                if (northNode.Visited == false && northNode.Symbol != '#' && northNode.ShortestDistance >= currentNode.ShortestDistance + 1001)
                {
                    _distanceList.Add(northNode);
                    northNode.ShortestDistance = currentNode.ShortestDistance + 1001;
                    northNode.ShortestPathThrough.Add(currentNode);
                }
                var southNode = _map[_x, _y + 1].South;
                if (southNode.Visited == false && southNode.Symbol != '#' && southNode.ShortestDistance >= currentNode.ShortestDistance + 1001)
                {
                    _distanceList.Add(southNode);
                    southNode.ShortestDistance = currentNode.ShortestDistance + 1001;
                    southNode.ShortestPathThrough.Add(currentNode);
                }
            }
            
            if (currentNode.Facing == "South")
            {
                var eastNode = _map[_x + 1, _y].East;
                if (eastNode.Visited == false && eastNode.Symbol != '#' && eastNode.ShortestDistance >= currentNode.ShortestDistance + 1001)
                {
                    _distanceList.Add(eastNode);
                    eastNode.ShortestDistance = currentNode.ShortestDistance + 1001;
                    eastNode.ShortestPathThrough.Add(currentNode);
                }
                var southNode = _map[_x, _y + 1].South;
                if (southNode.Visited == false && southNode.Symbol != '#' && southNode.ShortestDistance >= currentNode.ShortestDistance + 1)
                {
                    _distanceList.Add(southNode);
                    southNode.ShortestDistance = currentNode.ShortestDistance + 1;
                    southNode.ShortestPathThrough.Add(currentNode);
                }
                var westNode = _map[_x - 1, _y].West;
                if (westNode.Visited == false && westNode.Symbol != '#' && westNode.ShortestDistance >= currentNode.ShortestDistance + 1001)
                {
                    _distanceList.Add(westNode);
                    westNode.ShortestDistance = currentNode.ShortestDistance + 1001;
                    westNode.ShortestPathThrough.Add(currentNode);
                }
            }
            
        }
    }

    public int FindBestSeats()
    {
        var bestSeats = 0;
        return BackTrace(FinalNode);
    }

    private int BackTrace(DirectionNode currentNode)
    {
        if (CountedInBackTrace.Any(cbt => cbt.Item1 == currentNode.X && cbt.Item2 == currentNode.Y))
        {
            return 0;
        }
        CountedInBackTrace.Add(new Tuple<int, int>(currentNode.X, currentNode.Y));
        var backTrace = 1;
        foreach (var node in currentNode.ShortestPathThrough)
        {
            backTrace += BackTrace(node);
        }
        return backTrace;    
    }

    private class MazeNode
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol
        {
            get => _symbol;
            set
            {
                _symbol = value;
                SetAllTheBools(value);
            }
        }

        public bool IsEmpty;
        public bool IsWall;
        public bool IsStart;
        public bool IsEnd;
        private char _symbol;
        public DirectionNode North;
        public DirectionNode East;
        public DirectionNode South;
        public DirectionNode West;

        public MazeNode(int x, int y, char symbol)
        {
            X = x;
            Y = y;
            Symbol = symbol;
            SetAllTheBools(symbol);
            North = new DirectionNode(x, y, "North", symbol);
            East = new DirectionNode(x, y, "East", symbol);
            South = new DirectionNode(x, y, "South", symbol);
            West = new DirectionNode(x, y, "West", symbol);

            if (Symbol == 'S')
            {
                East.ShortestDistance = 0;
                East.Visited = true;
            }
        }

        private void SetAllTheBools(char character)
        {
            switch (character)
            {
                case '#':
                    IsWall = true;
                    IsStart = false;
                    IsEmpty = false;
                    IsEnd = false;
                    break;
                case '.':
                    IsEmpty = true;
                    IsStart = false;
                    IsEnd = false;
                    IsWall = false;
                    break;
                case 'E':
                    IsEnd = true;
                    IsStart = false;
                    IsEmpty = false;
                    IsWall = false;
                    break;
                case 'S':
                    IsStart = true;
                    IsEmpty = false;
                    IsEnd = false;
                    IsWall = false;
                    break;
            }
        }
    }

    protected class DirectionNode(int x, int y, string facing, char symbol)
    {
        public int ShortestDistance = Int32.MaxValue;
        public int X = x;
        public int Y = y;
        public string Facing = facing;
        public List<DirectionNode> ShortestPathThrough = [];
        public bool Visited = false;
        public char Symbol = symbol;
        public bool CountedInBackTrace;
    }
}