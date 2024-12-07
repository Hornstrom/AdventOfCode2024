namespace Advent_of_Code_2024.Day6__Guard_Gallivant;

public class PatrolMapper
{
    private readonly string[] _data = File.ReadAllLines(@"Day6- Guard Gallivant/data.txt");
    
    private MapNode[,] _map;
    private int _xStart;
    private int _yStart;
    private int _xMax;
    private int _yMax;

    public PatrolMapper()
    {
        CreateMap();
    }

    private void CreateMap()
    {
        _xMax = _data[0].Length;
        _yMax = _data.Length;
        _map = new MapNode[_xMax,_yMax];

        for (int y = 0; y < _yMax; y++)
        {
            for (int x = 0; x < _xMax; x++)
            {
                _map[x, y] = new MapNode(_data[y][x]);
                if (_data[y][x] == '^')
                {
                    _xStart = x;
                    _yStart = y;
                }
            }
        }
    }

    public void Patrol()
    {
        var direction = _map[_xStart, _yStart].Symbol;
        var x = _xStart;
        var y = _yStart;
        var nextX = _xStart;
        var nextY = _yStart;
        
        while (nextX >= 0 && nextX < _xMax && nextY >= 0 && nextY < _yMax)
        {
            if (_map[nextX, nextY].IsObstacle)
            {
                switch (direction)
                {
                    case '^':
                        direction = '>';
                        break;
                    case '>':
                        direction = 'v';
                        break;
                    case 'v':
                        direction = '<';
                        break;
                    case '<':
                        direction = '^';
                        break;
                }
            }
            else
            {
                x = nextX;
                y = nextY;
            }

            if (_map[x, y].Visited && _map[x, y].PreviousDirections.Contains(direction))
            {
                throw new LoopException();
            }
            
            _map[x, y].Visited = true;
            _map[x, y].PreviousDirections.Add(direction);
            switch (direction)
            {
                case '^':
                    nextX = x;
                    nextY = y - 1;
                    break;
                case '>':
                    nextX = x + 1;
                    nextY = y;
                    break;
                case 'v':
                    nextX = x;
                    nextY = y + 1;
                    break;
                case '<':
                    nextX = x - 1;
                    nextY = y;
                    break;
            }
        }
    }

    public int CountVisitedSpaces()
    {
        var visitedSpaces = 0;
        foreach (var mapNode in _map)
        {
            if (mapNode.Visited)
            {
                visitedSpaces++;
            }
        }
        return visitedSpaces;
    }

    public int NumberOfObstaclePositionsThatCauseALoop()
    {
        var numberOfLoops = 0;
        for (int y = 0; y < _yMax; y++)
        {
            for (int x = 0; x < _xMax; x++)
            {
                
                if (_map[x, y].Symbol == '.')
                {
                    CreateMap();
                    _map[x, y].Symbol = '#';
                    _map[x, y].IsObstacle = true;
                    try
                    {
                        Patrol();
                    }
                    catch (LoopException e)
                    {
                        numberOfLoops++;
                    }
                }
                
            }
        }
        return numberOfLoops;
    }

    private class LoopException : Exception;
}