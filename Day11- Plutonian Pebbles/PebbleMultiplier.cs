namespace Advent_of_Code_2024.Day11__Plutonian_Pebbles;

public class PebbleMultiplier
{
    private readonly string _data = File.ReadAllText(@"Day11- Plutonian Pebbles/data.txt");
    private List<long> _pebbles = [];
    private long _numberOfPebbles;
    private Dictionary<long, List<long>> _fiveBlinksDictionary = [];
    private Dictionary<long, List<long>> _twentyfiveBlinksDictionary = [];
    

    public PebbleMultiplier()
    {
        var pebbles = _data.Split(' ');
        foreach (var pebble in pebbles)
        {
            _pebbles.Add(int.Parse(pebble));
        }
    }

    public int Blink(int numberOfBlinks)
    {
        for (int i = 0; i < numberOfBlinks; i++)
        {
            var newPebbleLine = new List<long>();
            foreach (var pebble in _pebbles)
            {
                if (pebble == 0)
                {
                    newPebbleLine.Add(1);
                }
                else if (pebble.ToString().Length % 2 == 0)
                {
                    var newStone1 = pebble.ToString().Substring(0, pebble.ToString().Length / 2);
                    var newStone2 = pebble.ToString().Substring(pebble.ToString().Length / 2, pebble.ToString().Length / 2);
                    newPebbleLine.Add(long.Parse(newStone1));
                    newPebbleLine.Add(long.Parse(newStone2));
                }
                else
                {
                    newPebbleLine.Add(pebble * 2024);
                }
            }
            _pebbles = newPebbleLine;
            // Print(_pebbles);
        }
        return _pebbles.Count;
    }
    
    public long Blink2(int numberOfBlinks)
    {
        _numberOfPebbles = _pebbles.Count;
        
        foreach (var pebble in _pebbles)
        {
            GoPebbles(pebble, numberOfBlinks);
        }
        
        
        return _numberOfPebbles;
    }

    private void GoPebbles(long pebble, int remainingBlinks)
    {
        // Console.WriteLine(remainingBlinks + " remaining blinks, " + NumberOfPebbles + " pebbles");
        if (remainingBlinks <= 0)   
        {
            return;
        }
        remainingBlinks--;
        if (pebble == 0)
        {
            pebble = 1;
            GoPebbles(pebble, remainingBlinks);
        }
        else if (pebble.ToString().Length % 2 == 0)
        {
            _numberOfPebbles++;
            var newStone1 = pebble.ToString().Substring(0, pebble.ToString().Length / 2);
            var newStone2 = pebble.ToString().Substring(pebble.ToString().Length / 2, pebble.ToString().Length / 2);
            GoPebbles(long.Parse(newStone1), remainingBlinks);
            GoPebbles(long.Parse(newStone2), remainingBlinks);
        }
        else
        {
            GoPebbles(pebble * 2024, remainingBlinks);
        }
    }

    public int SmartBlink(int numberOfBlinks)
    {
        var nrOfPebbles = 0;
        for (int i = 0; i < _pebbles.Count; i++)
        {
            var expandPebble = new List<long>();
            expandPebble.Add(_pebbles[i]);
            for (int j = 0; j < numberOfBlinks; j++)
            {
                var newPebbleLine = new List<long>();
                foreach (var pebble in expandPebble)
                {
                    if (pebble == 0)
                    {
                        newPebbleLine.Add(1);
                    }
                    else if (pebble.ToString().Length % 2 == 0)
                    {
                        var newStone1 = pebble.ToString().Substring(0, pebble.ToString().Length / 2);
                        var newStone2 = pebble.ToString()
                            .Substring(pebble.ToString().Length / 2, pebble.ToString().Length / 2);
                        newPebbleLine.Add(long.Parse(newStone1));
                        newPebbleLine.Add(long.Parse(newStone2));
                    }
                    else
                    {
                        newPebbleLine.Add(pebble * 2024);
                    }
                }
                expandPebble = newPebbleLine;
                
            }

            nrOfPebbles += expandPebble.Count;
        }

        return nrOfPebbles;
    }
    
    public long SmartBlink2(int numberOfBlinks)
    {
        var nrOfPebbles = 0L;
        foreach (var pebble in _pebbles)
        {
            nrOfPebbles += GoPebbles5X(pebble, numberOfBlinks);
            Console.WriteLine($"Pebble {pebble} completed");
        }
        
        return nrOfPebbles;
    }

    private long GoPebbles5X(long pebble, int numberOfBlinks)
    {
        var nrOfPebbles = 0L;
        if (numberOfBlinks <= 0)
        {
            return 1;
        }

        var pebbles = BlinkFiveTimes(pebble);
        numberOfBlinks -= 5;
        foreach (var shinyPebble in pebbles)
        {
            nrOfPebbles += GoPebbles5X(shinyPebble, numberOfBlinks);
        }
        return nrOfPebbles;
    }

    private List<long> BlinkFiveTimes(long inboundPebble)
    {
        if (_fiveBlinksDictionary.TryGetValue(inboundPebble, out var result))
        {
            Console.WriteLine($"Dictionary lookup success for pebble {inboundPebble}");
            return result;
        }
        
        var pebbles = new List<long> { inboundPebble };
        for (int i = 0; i < 5; i++)
        {
            var newPebbleLine = new List<long>();
            foreach (var pebble in pebbles)
            {
                if (pebble == 0)
                {
                    newPebbleLine.Add(1);
                }
                else if (pebble.ToString().Length % 2 == 0)
                {
                    var newStone1 = pebble.ToString().Substring(0, pebble.ToString().Length / 2);
                    var newStone2 = pebble.ToString().Substring(pebble.ToString().Length / 2, pebble.ToString().Length / 2);
                    newPebbleLine.Add(long.Parse(newStone1));
                    newPebbleLine.Add(long.Parse(newStone2));
                }
                else
                {
                    newPebbleLine.Add(pebble * 2024);
                }
            }
            pebbles = newPebbleLine;
            // Print(pebbles);
        }

        Console.WriteLine($"Created dictionary for pebble {inboundPebble}");
        _fiveBlinksDictionary.Add(inboundPebble, pebbles);
        return pebbles;
    }
    
    public long SmartBlink3(int numberOfBlinks)
    {
        var nrOfPebbles = 0L;
        foreach (var pebble in _pebbles)
        {
            nrOfPebbles += GoPebbles25X(pebble, numberOfBlinks);
            Console.WriteLine($"Pebble {pebble} completed");
        }
        
        return nrOfPebbles;
    }

    private long GoPebbles25X(long pebble, int numberOfBlinks)
    {
        var nrOfPebbles = 0L;
        if (numberOfBlinks <= 0)
        {
            return 1;
        }

        var pebbles = BlinkTwentyFiveTimes(pebble);
        numberOfBlinks -= 25;
        if (numberOfBlinks <= 0)
        {
            // Console.WriteLine($"Returning nr of pebbles for the last 25 iteration of {pebble}");
            return pebbles.Count;
        }
        foreach (var shinyPebble in pebbles)
        {
            nrOfPebbles += GoPebbles25X(shinyPebble, numberOfBlinks);
        }
        return nrOfPebbles;
    }

    private List<long> BlinkTwentyFiveTimes(long inboundPebble)
    {
        if (_twentyfiveBlinksDictionary.TryGetValue(inboundPebble, out var result))
        {
            // Console.WriteLine($"Dictionary lookup success for pebble {inboundPebble}");
            return result;
        }
        
        var pebbles = new List<long> { inboundPebble };
        for (int i = 0; i < 25; i++)
        {
            var newPebbleLine = new List<long>();
            foreach (var pebble in pebbles)
            {
                if (pebble == 0)
                {
                    newPebbleLine.Add(1);
                }
                else if (pebble.ToString().Length % 2 == 0)
                {
                    var newStone1 = pebble.ToString().Substring(0, pebble.ToString().Length / 2);
                    var newStone2 = pebble.ToString().Substring(pebble.ToString().Length / 2, pebble.ToString().Length / 2);
                    newPebbleLine.Add(long.Parse(newStone1));
                    newPebbleLine.Add(long.Parse(newStone2));
                }
                else
                {
                    newPebbleLine.Add(pebble * 2024);
                }
            }
            pebbles = newPebbleLine;
            // Print(pebbles);
        }

        Console.WriteLine($"Created dictionary for pebble {inboundPebble}");
        _twentyfiveBlinksDictionary.Add(inboundPebble, pebbles);
        return pebbles;
    }

    private void Print(List<long> pepples)
    {
        foreach (var pepple in pepples)
        {
            Console.Write(pepple + " ");
        }
        Console.WriteLine();
    }
}