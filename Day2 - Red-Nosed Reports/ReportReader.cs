namespace Advent_of_Code_2024.Day2___Red_Nosed_Reports;

public class ReportReader
{
    private readonly string[] _data = File.ReadAllLines(@"Day2 - Red-Nosed Reports/data.txt");

    public List<Report> Reports = [];
    public List<ReportWithDampener> ReportWithDampeners = [];

    public ReportReader()
    {
        foreach (var data in _data)
        {
            Reports.Add(new Report(data));
            ReportWithDampeners.Add(new ReportWithDampener(data));
        }
    }
}