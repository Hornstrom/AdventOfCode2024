namespace Advent_of_Code_2024.Day11__Plutonian_Pebbles;

public class PebbleMultiplier
{
    private readonly string _data = File.ReadAllText(@"Day11- Plutonian Pebbles/testdata.txt");
    private List<long> _pebbles = [];
    public long NumberOfPebbles;

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
            // Print(_pebbles);
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
        }
        return _pebbles.Count;
    }
    
    public long Blink2(int numberOfBlinks)
    {
        NumberOfPebbles = _pebbles.Count;
        
        foreach (var pebble in _pebbles)
        {
            GoPebbles(pebble, numberOfBlinks);
        }
        
        
        return NumberOfPebbles;
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
            NumberOfPebbles++;
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
            // Print(_pebbles);
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
                Console.WriteLine(j);
            }

            nrOfPebbles += expandPebble.Count;
        }

        return nrOfPebbles;
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