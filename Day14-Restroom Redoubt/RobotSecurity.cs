using System.Globalization;

namespace Advent_of_Code_2024.Day14_Restroom_Redoubt;

public class RobotSecurity
{
    private readonly string[] _data = File.ReadAllLines(@"Day14-Restroom Redoubt/data.txt");
    private List<Robot> _robots = [];

    public RobotSecurity()
    {
        foreach (var line in _data)
        {
            _robots.Add(new Robot(line));
        }
    }

    public int Run(int seconds)
    {
        var width = 101;
        var height = 103;

        var minRobotPositions = 455;
        
        DrawRobotRoom(width, height, 0);
        for (int i = 0; i < seconds; i++)
        {
            foreach (var robot in  _robots)
            {
                robot.PosX = (robot.PosX + robot.VelX) % width;
                robot.PosY = (robot.PosY + robot.VelY) % height;
                while (robot.PosX < 0)
                {
                    robot.PosX += width;
                }

                while (robot.PosY < 0)
                {
                    robot.PosY += height;
                }
            }

            var robotPositions = 0;
            var longestVerticalLine = 0;
            for (var x = 0; x < width; x++)
            {
                var verticalLineLength = 0;
                for (var y = 0; y < height; y++)
                {
                    if (_robots.Any(r => r.PosX == x && r.PosY == y))
                    {
                        if (y != 0 && _robots.Any(r => r.PosX == x && r.PosY == y - 1))
                        {
                            verticalLineLength++;
                            if (verticalLineLength > longestVerticalLine)
                            {
                                longestVerticalLine = verticalLineLength;
                            }
                        }
                        else
                        {
                            verticalLineLength = 0;
                        }
                        robotPositions++;
                    }
                }
            }

            if (robotPositions < minRobotPositions || longestVerticalLine > 9)
            {
                minRobotPositions = robotPositions;
                DrawRobotRoom(width, height, i+1);
                Console.WriteLine($"Number of robot positions: {robotPositions}");
                Console.WriteLine($"Longest vertical line: {longestVerticalLine}");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }
            
        }
        
        var midWidth = width / 2;
        var midHeight = height / 2;
        
        var robotsInQ1 = _robots.Count(r => r.PosX < midWidth && r.PosY < midHeight);
        var robotsInQ2 = _robots.Count(r => r.PosX < midWidth && r.PosY > midHeight);
        var robotsInQ3 = _robots.Count(r => r.PosX > midWidth && r.PosY < midHeight);
        var robotsInQ4 = _robots.Count(r => r.PosX > midWidth && r.PosY > midHeight);
        
        return robotsInQ1 * robotsInQ2 * robotsInQ3 * robotsInQ4;
    }

    private void DrawRobotRoom(int width, int height, int seconds)
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                var nrOfRobots = _robots.Count(r => r.PosX == j && r.PosY == i);
                if (nrOfRobots > 0)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    if (nrOfRobots > 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    Console.Write(nrOfRobots);    
                    Console.ResetColor();
                }
                else
                {
                    Console.Write('.');
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine($"Result above after {seconds} seconds");
    }


    private class Robot
    {
        public int PosX;
        public int PosY;
        public int VelX;
        public int VelY;

        public Robot(string line)
        {
            string[] parts = line.Split(' ');
            var positions = parts[0].Replace("p=", "").Split(',');
            PosX = int.Parse(positions[0]);
            PosY = int.Parse(positions[1]);
            var velocity = parts[1].Replace("v=", "").Split(',');
            VelX = int.Parse(velocity[0]);
            VelY = int.Parse(velocity[1]);
        }
    }
}