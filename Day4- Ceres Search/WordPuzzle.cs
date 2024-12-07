using System.Xml.Linq;

namespace Advent_of_Code_2024.Day4__Ceres_Search;

public class WordPuzzle
{
    private readonly string[] _data = File.ReadAllLines(@"Day4- Ceres Search/data.txt");

    private char[][] _matrix;

    public WordPuzzle()
    {
        _matrix = new char[_data.Length][];
        for (int i = 0; i < _data.Length; i++)
        {
            _matrix[i] = _data[i].ToCharArray();
        }
    }

    public int XmasCount()
    {
        var count = 0;
        for (int i = 0; i < _matrix.Length; i++)
        {
            for (int j = 0; j < _matrix[i].Length; j++)
            {
                count += DoesPositionSpellXmas(i, j);
            }
        }
        return count;
    }
    
    public int MasCrossCount()
    {
        var count = 0;
        for (int i = 0; i < _matrix.Length; i++)
        {
            for (int j = 0; j < _matrix[i].Length; j++)
            {
                if (IsPositionAXmasCross(i, j))
                {
                    count++;
                };
            }
        }
        return count;
    }

    private bool IsPositionAXmasCross(int i, int j)
    {
        if (_matrix[i][j] == 'A')
        {
            var mCount = 0;
            var sCount = 0;
            if (_matrix[i].Length < j + 2 || _matrix.Length < i + 2 || i == 0 || j == 0)
            {
                return false;
            }

            if (_matrix[i + 1][j + 1] == 'M')
            {
                mCount++;
            }
            if (_matrix[i + 1][j + 1] == 'S')
            {
                sCount++;
            }
            if (_matrix[i - 1][j - 1] == 'M')
            {
                mCount++;
            }
            if (_matrix[i - 1][j - 1] == 'S')
            {
                sCount++;
            }
            if (_matrix[i + 1][j - 1] == 'M')
            {
                mCount++;
            }
            if (_matrix[i + 1][j - 1] == 'S')
            {
                sCount++;
            }
            if (_matrix[i - 1][j + 1] == 'M')
            {
                mCount++;
            }
            if (_matrix[i - 1][j + 1] == 'S')
            {
                sCount++;
            }

            if (mCount == 2 && sCount == 2 && _matrix[i - 1][j + 1] != _matrix[i + 1][j - 1])
            {
                return true;
            }
            
        }

        return false;
    }

    private int DoesPositionSpellXmas(int i, int j)
    {
        var count = 0;
        if (_matrix[i][j] == 'X')
        {
            if (_matrix[i].Length > j + 3)
            {
                if (_matrix[i][j+1] == 'M')
                {
                    if (_matrix[i][j+2] == 'A')
                    {
                        if (_matrix[i][j+3] == 'S')
                        {
                            count++;
                        }
                    }
                }
            }
            if (j >= 3)
            {
                if (_matrix[i][j-1] == 'M')
                {
                    if (_matrix[i][j-2] == 'A')
                    {
                        if (_matrix[i][j-3] == 'S')
                        {
                            count++;
                        }
                    }
                }
            }
            if (_matrix.Length > i + 3)
            {
                if (_matrix[i+1][j] == 'M')
                {
                    if (_matrix[i+2][j] == 'A')
                    {
                        if (_matrix[i+3][j] == 'S')
                        {
                            count++;
                        }
                    }
                }
            }
            if (i >= 3)
            {
                if (_matrix[i-1][j] == 'M')
                {
                    if (_matrix[i-2][j] == 'A')
                    {
                        if (_matrix[i-3][j] == 'S')
                        {
                            count++;
                        }
                    }
                }
            }
            if (_matrix[i].Length > j + 3 && _matrix.Length > i + 3)
            {
                if (_matrix[i+1][j+1] == 'M')
                {
                    if (_matrix[i+2][j+2] == 'A')
                    {
                        if (_matrix[i+3][j+3] == 'S')
                        {
                            count++;
                        }
                    }
                }
            }
            if (_matrix[i].Length > j + 3 && i >= 3)
            {
                if (_matrix[i-1][j+1] == 'M')
                {
                    if (_matrix[i-2][j+2] == 'A')
                    {
                        if (_matrix[i-3][j+3] == 'S')
                        {
                            count++;
                        }
                    }
                }
            }
            if (j >= 3 && _matrix.Length > i + 3)
            {
                if (_matrix[i+1][j-1] == 'M')
                {
                    if (_matrix[i+2][j-2] == 'A')
                    {
                        if (_matrix[i+3][j-3] == 'S')
                        {
                            count++;
                        }
                    }
                }
            }
            if (j >= 3 && i >= 3)
            {
                if (_matrix[i-1][j-1] == 'M')
                {
                    if (_matrix[i-2][j-2] == 'A')
                    {
                        if (_matrix[i-3][j-3] == 'S')
                        {
                            count++;
                        }
                    }
                }
            }
        }
        return count;
    }
}