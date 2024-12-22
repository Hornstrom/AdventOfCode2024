namespace Advent_of_Code_2024.Day21__Keypad_Conundrum;

public class ReindeerSpaceship
{
    private readonly string[] _data = File.ReadAllLines(@"Day21- Keypad Conundrum/data.txt");

    private Keypad _robotNumericKeypad = new Keypad(true);
    private Keypad _robotDirectionalKeypad1 = new Keypad(false);
    private Keypad _robotDirectionalKeyoad2 = new Keypad(false);
    private Keypad _myDirectionalKeyPad = new Keypad(false);

    public int Part1()
    {
        var result = 0;
        foreach (var line in _data)
        {
            var myPressesForThisLine = 0;
            Console.WriteLine($"Starting input of {line}");
            foreach (var symbol in line)
            {
                Console.Write($"Pressing numeric keypad: ");
                var movesNumeric = _robotNumericKeypad.PressKey(symbol);
                Console.WriteLine("");
                
                Console.Write("Pressing Directional 1: ");
                var movesD1 = new List<List<Tuple<char, int>>>();

                foreach (var move in movesNumeric)
                {
                    if (move.Item1 == 'X')
                    {
                        switch (move.Item2)
                        {
                            case -1:
                                movesD1.Add(_robotDirectionalKeypad1.PressKey('<'));
                                break;
                            case -2:
                                movesD1.Add(_robotDirectionalKeypad1.PressKey('<'));
                                movesD1.Add(_robotDirectionalKeypad1.PressKey('<'));
                                break;
                            case 1:
                                movesD1.Add(_robotDirectionalKeypad1.PressKey('>'));
                                break;
                            case 2:
                                movesD1.Add(_robotDirectionalKeypad1.PressKey('>'));
                                movesD1.Add(_robotDirectionalKeypad1.PressKey('>'));
                                break;
                        }
                    }

                    if (move.Item1 == 'Y')
                    {
                        switch (move.Item2)
                        {
                            case -1:
                                movesD1.Add(_robotDirectionalKeypad1.PressKey('^'));
                                break;
                            case -2:
                                movesD1.Add(_robotDirectionalKeypad1.PressKey('^'));
                                movesD1.Add(_robotDirectionalKeypad1.PressKey('^'));
                                break;
                            case -3:
                                movesD1.Add(_robotDirectionalKeypad1.PressKey('^'));
                                movesD1.Add(_robotDirectionalKeypad1.PressKey('^'));
                                movesD1.Add(_robotDirectionalKeypad1.PressKey('^'));
                                break;
                            case 1:
                                movesD1.Add(_robotDirectionalKeypad1.PressKey('v'));
                                break;
                            case 2:
                                movesD1.Add(_robotDirectionalKeypad1.PressKey('v'));
                                movesD1.Add(_robotDirectionalKeypad1.PressKey('v'));
                                break;
                            case 3:
                                movesD1.Add(_robotDirectionalKeypad1.PressKey('v'));
                                movesD1.Add(_robotDirectionalKeypad1.PressKey('v'));
                                movesD1.Add(_robotDirectionalKeypad1.PressKey('v'));
                                break;
                        }
                    }
                }
                movesD1.Add(_robotDirectionalKeypad1.PressKey('A'));
                Console.WriteLine("");

                Console.Write("Pressing Directional 2: ");
                var movesD2 = new List<List<Tuple<char, int>>>();
                foreach (var moves in movesD1)
                {
                    foreach (var move in moves)
                    {
                        if (move.Item1 == 'X')
                        {
                            switch (move.Item2)
                            {
                                case -1:
                                    movesD2.Add(_robotDirectionalKeypad1.PressKey('<'));
                                    break;
                                case -2:
                                    movesD2.Add(_robotDirectionalKeypad1.PressKey('<'));
                                    movesD2.Add(_robotDirectionalKeypad1.PressKey('<'));
                                    break;
                                case 1:
                                    movesD2.Add(_robotDirectionalKeypad1.PressKey('>'));
                                    break;
                                case 2:
                                    movesD2.Add(_robotDirectionalKeypad1.PressKey('>'));
                                    movesD2.Add(_robotDirectionalKeypad1.PressKey('>'));
                                    break;
                            }
                        }

                        if (move.Item1 == 'Y')
                        {
                            switch (move.Item2)
                            {
                                case -1:
                                    movesD2.Add(_robotDirectionalKeypad1.PressKey('^'));
                                    break;
                                case -2:
                                    throw new Exception("Invalid direction");
                                    movesD2.Add(_robotDirectionalKeypad1.PressKey('^'));
                                    movesD2.Add(_robotDirectionalKeypad1.PressKey('^'));
                                    break;
                                case -3:
                                    throw new Exception("Invalid direction");
                                    movesD2.Add(_robotDirectionalKeypad1.PressKey('^'));
                                    movesD2.Add(_robotDirectionalKeypad1.PressKey('^'));
                                    movesD2.Add(_robotDirectionalKeypad1.PressKey('^'));
                                    break;
                                case 1:
                                    movesD2.Add(_robotDirectionalKeypad1.PressKey('v'));
                                    break;
                                case 2:
                                    throw new Exception("Invalid direction");
                                    movesD2.Add(_robotDirectionalKeypad1.PressKey('v'));
                                    movesD2.Add(_robotDirectionalKeypad1.PressKey('v'));
                                    break;
                                case 3:
                                    throw new Exception("Invalid direction");
                                    movesD2.Add(_robotDirectionalKeypad1.PressKey('v'));
                                    movesD2.Add(_robotDirectionalKeypad1.PressKey('v'));
                                    movesD2.Add(_robotDirectionalKeypad1.PressKey('v'));
                                    break;
                            }
                        }
                    }
                    movesD2.Add(_robotDirectionalKeypad1.PressKey('A'));
                }
                Console.WriteLine("");
                
                Console.Write("Pressing my keypad: ");
                var myMoves = new List<List<Tuple<char, int>>>();
                foreach (var moves in movesD2)
                {
                    foreach (var move in moves)
                    {
                        if (move.Item1 == 'X')
                        {
                            switch (move.Item2)
                            {
                                case -1:
                                    myMoves.Add(_robotDirectionalKeypad1.PressKey('<'));
                                    break;
                                case -2:
                                    myMoves.Add(_robotDirectionalKeypad1.PressKey('<'));
                                    myMoves.Add(_robotDirectionalKeypad1.PressKey('<'));
                                    break;
                                case 1:
                                    myMoves.Add(_robotDirectionalKeypad1.PressKey('>'));
                                    break;
                                case 2:
                                    myMoves.Add(_robotDirectionalKeypad1.PressKey('>'));
                                    myMoves.Add(_robotDirectionalKeypad1.PressKey('>'));
                                    break;
                            }
                        }

                        if (move.Item1 == 'Y')
                        {
                            switch (move.Item2)
                            {
                                case -1:
                                    myMoves.Add(_robotDirectionalKeypad1.PressKey('^'));
                                    break;
                                case -2:
                                    myMoves.Add(_robotDirectionalKeypad1.PressKey('^'));
                                    myMoves.Add(_robotDirectionalKeypad1.PressKey('^'));
                                    break;
                                case -3:
                                    myMoves.Add(_robotDirectionalKeypad1.PressKey('^'));
                                    myMoves.Add(_robotDirectionalKeypad1.PressKey('^'));
                                    myMoves.Add(_robotDirectionalKeypad1.PressKey('^'));
                                    break;
                                case 1:
                                    myMoves.Add(_robotDirectionalKeypad1.PressKey('v'));
                                    break;
                                case 2:
                                    myMoves.Add(_robotDirectionalKeypad1.PressKey('v'));
                                    myMoves.Add(_robotDirectionalKeypad1.PressKey('v'));
                                    break;
                                case 3:
                                    myMoves.Add(_robotDirectionalKeypad1.PressKey('v'));
                                    myMoves.Add(_robotDirectionalKeypad1.PressKey('v'));
                                    myMoves.Add(_robotDirectionalKeypad1.PressKey('v'));
                                    break;
                            }
                        }
                    }
                    myMoves.Add(_robotDirectionalKeypad1.PressKey('A'));
                }
                Console.WriteLine("");

                myPressesForThisLine += myMoves.Count;  
            }
            var number = int.Parse(line.Replace("A", ""));
            Console.WriteLine($"{myPressesForThisLine} * {number}");
            result += number * myPressesForThisLine;
        }
        return result;
    }

    protected class Keypad
    {
        private Dictionary<char, Key> _keypad = new Dictionary<char, Key>();
        private int _currentX;
        private int _currentY;
        public bool IsNumeric;

        public Keypad(bool isNumeric)
        {
            IsNumeric = isNumeric;
            if (isNumeric)
            {
                _keypad.Add('7', new Key(0,0,'7'));
                _keypad.Add('8', new Key(1,0,'8'));
                _keypad.Add('9', new Key(2,0,'9'));
                
                _keypad.Add('4', new Key(0,1,'4'));
                _keypad.Add('5', new Key(1,1,'5'));
                _keypad.Add('6', new Key(2,1,'6'));
                
                _keypad.Add('1', new Key(0,2,'1'));
                _keypad.Add('2', new Key(1,2,'2'));
                _keypad.Add('3', new Key(2,2,'3'));
                
                _keypad.Add('0', new Key(1,3,'0'));
                _keypad.Add('A', new Key(2,3,'A'));
            }
            else
            {
                _keypad.Add('^', new Key(1,0,'^'));
                _keypad.Add('A', new Key(2,0,'A'));
                             
                _keypad.Add('<', new Key(0,1,'<'));
                _keypad.Add('v', new Key(1,1,'v'));
                _keypad.Add('>', new Key(2,1,'>'));
            }
            
            PressKey('A');
        }

        public List<Tuple<char, int>> PressKey(char symbol)
        {
            Console.Write(symbol);
            var key = _keypad[symbol];
            var xMoves = key.X - _currentX;
            var yMoves = key.Y - _currentY;
            
            var safeMoves = new List<Tuple<char, int>>();
            
            if (IsNumeric && _currentY == 3 && key.X == 0)
            {
                //Do y moves first
                safeMoves.Add(new Tuple<char, int>('Y', yMoves));
                safeMoves.Add(new Tuple<char, int>('X', xMoves));
            }
            else if (!IsNumeric && _currentY == 0 && key.X == 0)
            {
                //Do y moves first
                safeMoves.Add(new Tuple<char, int>('Y', yMoves));
                safeMoves.Add(new Tuple<char, int>('X', xMoves));
            }
            else
            {
                //Do x moves first
                safeMoves.Add(new Tuple<char, int>('X', xMoves));
                safeMoves.Add(new Tuple<char, int>('Y', yMoves));
            }
            
            _currentX = key.X;
            _currentY = key.Y;

            return safeMoves;
        } 
    }

    public class Key(int x, int y, char symbol)
    {
        public char Symbol = symbol;
        public int X = x;
        public int Y = y;
    }
}