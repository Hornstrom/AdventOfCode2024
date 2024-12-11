namespace Advent_of_Code_2024.Day9__Disk_Fragmenter.Part1;

public class DiskSection
{
    public int Size { get; set; }
    public List<FilePart> Content = [];

    public DiskSection(int size, bool isFile, int fileId)
    {
        Size = size;
        if (isFile)
        {
            Content.Add(new FilePart(size, fileId));
        }
    }

    public void Print()
    {
        foreach (var filePart in Content)
        {
            for (int i = 0; i < filePart.Size; i++)
            {
                Console.Write(filePart.Id);
            }
        }

        for (int i = 0; i < GetRemainingSpace(); i++)
        {
            Console.Write(".");
        }
    }

    public int GetRemainingSpace()
    {
        return Size - Content.Sum(x => x.Size);
    }
}
public class FilePart
{
    public int Size { get; set; }
    public int Id {get; set;}

    public FilePart(int size, int id)
    {
        Size = size;
        Id = id;
    }
}
