using Advent_of_Code_2024.Day5__Print_Queue;

namespace Advent_of_Code_2024.Day15__Warehouse_Woes;

public class Warehouse2
{
    private int _x;
    private int _y;
    private WarehouseNode[,] _map;
    private readonly string[] _warehouseData = File.ReadAllLines(@"Day15- Warehouse Woes/warehouse2.txt");
    private readonly string[] _robotData = File.ReadAllLines(@"Day15- Warehouse Woes/robot.txt");
    private int _xMax;
    private int _yMax;

    public Warehouse2()
    {
        _xMax = _warehouseData[0].Length;
        _yMax = _warehouseData.Length;
        _map = new WarehouseNode[_xMax, _yMax];
        for (var y = 0; y < _yMax; y++)
        {
            for (int x = 0; x < _xMax; x++)
            {
                _map[x,y] = new WarehouseNode(_warehouseData[y][x], x, y);
                if (_warehouseData[y][x] == '@')
                {
                    _x = x;
                    _y = y;
                }
            }
        }
        //
        // Console.WriteLine("Initial state:");
        // Print();
        foreach (var line in _robotData)
        {
            foreach (var move in line)      
            {
                // Console.WriteLine("Move " + move + ":");
                var itemToMove = new ItemToMove
                {
                    X = _x,
                    Y = _y,
                    Character = '@'
                };
                
                Move(move, new List<ItemToMove>() { itemToMove });
                // Print();
            }
        }
    }

    private void Print()
    {
        for (var y = 0; y < _yMax; y++)
        {
            for (int x = 0; x < _xMax; x++)
            {
                if (_map[x, y].Character == '@')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write(_map[x,y].Character);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    private bool Move(char move, IEnumerable<ItemToMove> itemsToMove)
    {
        var xd = 0;
        var yd = 0;
        switch (move)
        {
            case '<':
                xd = -1;
                break;
            case '>':
                xd = 1;
                break;
            case 'v':
                yd = 1;
                break;
            case '^':
                yd = -1;
                break;
        }
        
        if (itemsToMove.Any(i => _map[i.X + xd, i.Y + yd].IsWall))
        {
            return false;
        }

        if (itemsToMove.All(i => _map[i.X + xd, i.Y + yd].IsEmpty))
        {
            foreach (var item in itemsToMove)
            {
                MoveObject(item.X, xd, item.Y, yd, item.Character);
            }
            return true;
        }

        if (itemsToMove.Any(i => _map[i.X + xd, i.Y + yd].IsBox))
        {
            var moveObjects2 = new List<ItemToMove>();
            foreach (var item in itemsToMove)
            {
                if (_map[item.X + xd, item.Y + yd].Character != '.')
                {
                    moveObjects2.Add(new ItemToMove
                    {
                        X = item.X + xd,
                        Y = item.Y + yd,
                        Character = _map[item.X + xd, item.Y + yd].Character
                    });
                }

                if (_map[item.X + xd, item.Y + yd].Character == '[' && yd != 0)
                {
                    moveObjects2.Add(new ItemToMove
                    {
                        X = item.X + xd + 1,
                        Y = item.Y + yd,
                        Character = _map[item.X + xd + 1, item.Y + yd].Character
                    }); 
                }
                
                if (_map[item.X + xd, item.Y + yd].Character == ']'  && yd != 0)
                {
                    moveObjects2.Add(new ItemToMove
                    {
                        X = item.X + xd - 1,
                        Y = item.Y + yd,
                        Character = _map[item.X + xd - 1, item.Y + yd].Character
                    }); 
                }
            }

            if (Move(move, moveObjects2))
            {
                foreach (var item in itemsToMove)
                {
                    MoveObject(item.X, xd, item.Y, yd, item.Character);
                }

                return true;
            }
        }
        return false;
    }

    private void MoveObject(int x, int xd, int y, int yd, char thingMoving)
    {
        if (thingMoving == '@')
        {
            _y += yd;
            _x += xd;
        }
        _map[x + xd,y + yd].Character = thingMoving;
        _map[x,y].Character = '.';
    }

    public int Part2()
    {
        int total = 0;
        for (var y = 0; y < _yMax; y++)
        {
            for (int x = 0; x < _xMax; x++)
            {
                if (_map[x, y].Character == '[')
                {
                    total += y * 100 + x;
                }
            }
        }

        return total;
    }

    private class ItemToMove()
    {
        public int X;
        public int Y;
        public char Character;
    }


    private class WarehouseNode
    {
        public bool IsWall;
        public bool IsRobot;
        public bool IsBox;
        public bool IsEmpty;
        private char _character;
        public int X;
        public int Y;

        public char Character
        {
            get => _character;
            set
            {
                _character = value;
                SetAllTheBools(value);
            }
        }

        public WarehouseNode(char character, int x, int y)
        {
            Character = character;
            SetAllTheBools(character);
            X = x;
            Y = y;
        }

        private void SetAllTheBools(char character)
        {
            switch (character)
            {
                case '#':
                    IsWall = true;
                    IsEmpty = false;
                    IsRobot = false;
                    IsBox = false;
                    break;
                case '.':
                    IsEmpty = true;
                    IsRobot = false;
                    IsBox = false;
                    IsWall = false;
                    break;
                case '[':
                    IsBox = true;
                    IsRobot = false;
                    IsEmpty = false;
                    IsWall = false;
                    break;
                case ']':
                    IsBox = true;
                    IsEmpty = false;
                    IsRobot = false;
                    IsWall = false;
                    break;
                case '@':
                    IsRobot = true;
                    IsEmpty = false;
                    IsWall = false;
                    IsBox = false;
                    break;
            }
        }
    }
}

