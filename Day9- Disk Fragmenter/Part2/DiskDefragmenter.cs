namespace Advent_of_Code_2024.Day9__Disk_Fragmenter.Part2;

public class DiskDefragmenter
{
    private readonly string _data = File.ReadAllText(@"Day9- Disk Fragmenter/data.txt");
    private List<DiskSection> _diskSections = [];

    public DiskDefragmenter()
    {
        var fileId = 0;
        for (var i = 0; i < _data.Length; i++)
        {
            var isFile = i % 2 == 0;
            _diskSections.Add(new DiskSection(int.Parse(_data[i].ToString()), isFile, fileId));
            if (isFile)
            {
                fileId++;
            }
        }
    }

    public string Print()
    {
        var theString = "";
        foreach (var diskSection in _diskSections)
        {
            theString += diskSection.Print();
        }
        Console.WriteLine();
        return theString;
    }
    
    public void Defragment()
    {
        var lastSection = _diskSections[^1].Content.Any() ? _diskSections.Count - 1 : _diskSections.Count - 2;
        for (var i = lastSection; i >= 0; i--)
        {
            if (!_diskSections[i].Content.Any() || _diskSections[i].Content.All(fp => fp.FileHasBeenMoved))
            {
                continue;
            }
            for (var j = 0; j < i; j++)
            {
                while (_diskSections[i].Content.Any(fp => !fp.FileHasBeenMoved))
                {
                    if (_diskSections[j].GetRemainingSpace() >= _diskSections[i].Content.Last().Size)
                    {
                        var filePartToMove = _diskSections[i].Content.Last();
                        filePartToMove.FileHasBeenMoved = true;
                        _diskSections[i].Content.Remove(filePartToMove);
                        _diskSections[j].Content.Add(filePartToMove);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }

    public long CalculateChecksum()
    {
        var checksum = 0L;
        var counter = 0;
        foreach (var diskSection in _diskSections)
        {
            foreach (var filePart in diskSection.Content)
            {
                for (var i = 0; i < filePart.Size; i++)
                {
                    checksum += filePart.Id * counter;
                    counter++;
                }
            }
            for (int i = 0; i < diskSection.GetRemainingSpace(); i++)
            {
                counter++;
            }
        }
        return checksum;
    }
}