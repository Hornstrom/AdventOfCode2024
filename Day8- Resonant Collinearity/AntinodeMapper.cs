namespace Advent_of_Code_2024.Day8__Resonant_Collinearity;

public class AntinodeMapper
{
    private readonly string[] _data = File.ReadAllLines(@"Day8- Resonant Collinearity/data.txt");
    private MapNode[,] _map;
    private int _xMax;
    private int _yMax;

    public AntinodeMapper()
    {
        _xMax = _data[0].Length;
        _yMax = _data.Length;
        _map = new MapNode[_xMax,_yMax];

        for (int y = 0; y < _yMax; y++)
        {
            for (int x = 0; x < _xMax; x++)
            {
                _map[x, y] = new MapNode(_data[y][x], x, y);
            }
        }
    }

    public int FindAntinodes()
    {
        for (int y = 0; y < _yMax; y++)
        {
            for (int x = 0; x < _xMax; x++)
            {
                if (_map[x, y].IsAntenna)
                {
                    //Find all other antenna of the same symbol. And mark their antinodes
                    var symbol = _map[x, y].Symbol;
                    FindAntinodeLocationFor(symbol, x, y);
                }
            }
        }

        return CountAntinodes();
    }

    private void FindAntinodeLocationFor(char symbol, int x1, int y1)
    {
        for (int y2 = 0; y2 < _yMax; y2++)
        {
            for (int x2 = 0; x2 < _xMax; x2++)
            {
                if (_map[x2, y2].IsAntenna && symbol == _map[x2, y2].Symbol)
                {
                    var xVector = x1 - x2;
                    var yVector = y1 - y2;
                    
                    var x3 = x2 - xVector;
                    var y3 = y2 - yVector;

                    if (x3 >= 0 && x3 < _xMax && y3 >= 0 && y3 < _yMax)
                    {
                        if (_map[x3, y3].Symbol != symbol)
                        {
                            _map[x3, y3].AddAntiNodeFrequency(symbol);    
                        }
                    }
                }
            }
        }
    }

    private int CountAntinodes()
    {
        var count = 0;
        for (int y = 0; y < _yMax; y++)
        {
            for (int x = 0; x < _xMax; x++)
            {
                if (_map[x, y].AntiNodeForFrequency.Any())
                {
                    count++;
                }
            }
        }

        return count;
    }
    
    public void DrawMap()
    {
        for (int y = 0; y < _yMax; y++)
        {
            for (int x = 0; x < _xMax; x++)
            {
                if (_map[x, y].AntiNodeForFrequency.Count > 1)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                if (_map[x, y].AntiNodeForFrequency.Count > 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                if (_map[x, y].Symbol == '.' && _map[x, y].AntiNodeForFrequency.Any())
                {
                    Console.Write('#');
                }
                else
                {
                    if (_map[x, y].AntiNodeForFrequency.Count > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    Console.Write(_map[x, y].Symbol);    
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();
        }
    }

    public int ApplyResonantHarmonics()
    {
        for (int y = 0; y < _yMax; y++)
        {
            for (int x = 0; x < _xMax; x++)
            {
                if (_map[x, y].IsAntenna)
                {
                    var symbol = _map[x, y].Symbol;
                    FindHarmonicAntinodeLocationFor(symbol, x, y);
                }
            }
        }

        return CountAntinodes();
    }
    
    private void FindHarmonicAntinodeLocationFor(char symbol, int x1, int y1)
    {
        for (int y2 = 0; y2 < _yMax; y2++)
        {
            for (int x2 = 0; x2 < _xMax; x2++)
            {
                if (_map[x2, y2].IsAntenna && symbol == _map[x2, y2].Symbol && (x1 != x2 || y1 != y2))
                {
                    _map[x2, y2].AddAntiNodeFrequency(symbol);
                    var xVector = x1 - x2;
                    var yVector = y1 - y2;
                    
                    var x3 = x2 - xVector;
                    var y3 = y2 - yVector;

                    var loop = 1;

                    while (x3 >= 0 && x3 < _xMax && y3 >= 0 && y3 < _yMax && (xVector != 0 || yVector != 0))
                    {
                        _map[x3, y3].AddAntiNodeFrequency(symbol);    
                        loop++;
                        x3 = x2 - xVector * loop;
                        y3 = y2 - yVector * loop;
                    }
                    
                }
            }
        }
    }
}