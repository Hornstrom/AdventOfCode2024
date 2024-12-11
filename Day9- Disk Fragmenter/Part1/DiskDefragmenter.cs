namespace Advent_of_Code_2024.Day9__Disk_Fragmenter.Part1;

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

    public void Print()
    {
        foreach (var diskSection in _diskSections)
        {
            diskSection.Print();
        }
        Console.WriteLine();
    }
    
    public void Defragment()
    {
        var lastSection = _diskSections[^1].Content.Any() ? _diskSections.Count - 1 : _diskSections.Count - 2;
        for (var i = 0; i < _diskSections.Count; i++)
        {
            while (_diskSections[i].GetRemainingSpace() > 0)
            {
                if (!_diskSections[lastSection].Content.Any())
                {
                    lastSection--;
                    continue;
                }
                if(lastSection <= i)
                {
                    break;
                }
                
                var filePartToMove = _diskSections[lastSection].Content.Last();
                if (_diskSections[i].GetRemainingSpace() >= filePartToMove.Size)
                {
                    _diskSections[lastSection].Content.Remove(filePartToMove);
                    _diskSections[i].Content.Add(filePartToMove);
                }
                else
                {
                    filePartToMove.Size -= _diskSections[i].GetRemainingSpace();
                    _diskSections[i].Content.Add(new FilePart(_diskSections[i].GetRemainingSpace(), filePartToMove.Id));
                }
                // Print();
                
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
        }
        return checksum;
    }
}