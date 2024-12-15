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
                _map[x,y] = new WarehouseNode(_warehouseData[y][x]);
                if (_warehouseData[y][x] == '@')
                {
                    _x = x;
                    _y = y;
                }
            }
        }

        // Print();
        foreach (var line in _robotData)
        {
            foreach (var move in line)      
            {
                // Console.WriteLine("Move: " + move);
                Move(move, _x, _y, '@');
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
                Console.Write(_map[x,y].Character);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    private bool Move(char move, int x, int y, char thingMoving)
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
        if (_map[x + xd, y + yd].IsWall)
        {
            return false;
        }

        if (_map[x + xd, y + yd].IsEmpty)
        {
            if (thingMoving == '@')
            {
                _map[x + xd, y + yd].IsRobot = true;
                _map[x + xd, y + yd].IsEmpty = false;
                _map[x + xd, y + yd].Character = '@';
                _y += yd;
                _x += xd;
                _map[x, y].IsRobot = false;
            }
            else
            {
                _map[x + xd, y + yd].IsBox = true;
                _map[x + xd, y + yd].IsEmpty = false;
                _map[x + xd, y + yd].Character = 'O';
                _map[x, y].IsBox = false;
            }
            _map[x, y].IsEmpty = true;
            _map[x, y].Character = '.';
            return true;
        }

        if (_map[x + xd, y + yd].IsBox)
        {
            if (Move(move, x + xd, y + yd, 'O'))
            {
                if (thingMoving == '@')
                {
                    _map[x + xd, y + yd].IsRobot = true;
                    _map[x + xd, y + yd].IsEmpty = false;
                    _map[x + xd, y + yd].Character = '@';
                    _y += yd;
                    _x += xd;
                    _map[x, y].IsRobot = false;
                }
                else
                {
                    _map[x + xd, y + yd].IsBox = true;
                    _map[x + xd, y + yd].IsEmpty = false;
                    _map[x + xd, y + yd].Character = 'O';
                    _map[x, y].IsBox = false;
                }
                _map[x, y].IsEmpty = true;
                _map[x, y].Character = '.';
                return true;
            }
        }

        return false;
    }

    public int Part1()
    {
        int total = 0;
        for (var y = 0; y < _yMax; y++)
        {
            for (int x = 0; x < _xMax; x++)
            {
                if (_map[x, y].IsBox)
                {
                    total += y * 100 + x;
                }
            }
        }

        return total;
    }


    private class WarehouseNode
    {
        public bool IsWall;
        public bool IsRobot;
        public bool IsBox;
        public bool IsEmpty;
        public char Character;

        public WarehouseNode(char character)
        {
            Character = character;
            switch (character)
            {
                case '#':
                    IsWall = true;
                    break;
                case '.':
                    IsEmpty = true;
                    break;
                case '[':
                    IsBox = true;
                    break;
                case ']':
                    IsBox = true;
                    break;
                case '@':
                    IsRobot = true;
                    break;
            }
        }
    }
}

