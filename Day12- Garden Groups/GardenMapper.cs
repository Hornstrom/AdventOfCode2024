namespace Advent_of_Code_2024.Day12__Garden_Groups;

public class GardenMapper
{
    private readonly string[] _data = File.ReadAllLines(@"Day12- Garden Groups/data.txt");
    private GardenNode[,] _map;
    private int _xMax;
    private int _yMax;
    private List<GardenPlot> _gardenPlots = [];
    
    public GardenMapper()
    {
        _xMax = _data[0].Length;
        _yMax = _data.Length;
        _map = new GardenNode[_xMax,_yMax];

        for (int y = 0; y < _yMax; y++)
        {
            for (int x = 0; x < _xMax; x++)
            {
                _map[x, y] = new GardenNode(x, y, _data[y][x]);
            }
        }
    }

    public int FenceGardenPlots()
    {
        var totalPrice = 0;

        for (int y = 0; y < _yMax; y++)
        {
            for (int x = 0; x < _xMax; x++)
            {
                if (!_map[x, y].HasBeenMapped)
                {
                    var gardenPlot = new GardenPlot();
                    var nrOfFences = Fence(_map[x, y], gardenPlot);
                    gardenPlot.NumberOfFences = nrOfFences;
                    totalPrice += gardenPlot.NumberOfFences * gardenPlot.Nodes.Count;
                    _gardenPlots.Add(gardenPlot);
                }
            }
        }
        
        return totalPrice;
    }

    public int BulkDiscount()
    {
        var totalPrice = 0;
        foreach (var gardenPlot in _gardenPlots)
        {
            var xSides = gardenPlot.Nodes.Select(n => n.X).Distinct();
            var ySides = gardenPlot.Nodes.Select(n => n.Y).Distinct();
            var xMax = xSides.Max();
            var yMax = ySides.Max();
            var xMin = xSides.Min();
            var yMin = ySides.Min();

            var nrOfSides = 0;

            for (int x = xMin; x <= xMax; x++)
            {
                int? lastYWithLeftFence = null;
                int? lastYWithRightFence = null;
                for (int y = yMin; y <= yMax; y++)
                {
                    var node = gardenPlot.Nodes.FirstOrDefault(n => n.X == x && n.Y == y);
                    if (node != null)
                    {
                        var nodeToTheLeftIsInTheGardenPlot = gardenPlot.Nodes.Any(n => n.X == x - 1 && n.Y == y);
                        if (lastYWithLeftFence == y - 1)
                        {
                            if (!nodeToTheLeftIsInTheGardenPlot)
                            {
                                lastYWithLeftFence = y;    
                            }
                        }
                        else
                        {
                            
                            if (!nodeToTheLeftIsInTheGardenPlot)
                            {
                                nrOfSides++;
                                lastYWithLeftFence = y;
                            }
                        }
                        
                        var nodeToTheRightIsInTheGardenPlot = gardenPlot.Nodes.Any(n => n.X == x + 1 && n.Y == y);
                        if (lastYWithRightFence == y - 1)
                        {
                            if (!nodeToTheRightIsInTheGardenPlot)
                            {
                                lastYWithRightFence = y;    
                            }
                        }
                        else
                        {
                            if (!nodeToTheRightIsInTheGardenPlot)
                            {
                                nrOfSides++;
                                lastYWithRightFence = y;
                            }
                        }
                    }
                }
            }
            for (int y = yMin; y <= yMax; y++)
            {
                int? lastXWithTopFence = null;
                int? lastXWithBottomFence = null;
                for (int x = xMin; x <= xMax; x++)
                {
                    var node = gardenPlot.Nodes.FirstOrDefault(n => n.X == x && n.Y == y);
                    if (node != null)
                    {
                        var nodeAboveIsInTheGardenPlot = gardenPlot.Nodes.Any(n => n.X == x && n.Y == y + 1);
                        if (lastXWithTopFence == x - 1)
                        {
                            if (!nodeAboveIsInTheGardenPlot)
                            {
                                lastXWithTopFence = x;    
                            }
                        }
                        else
                        {
                            if (!nodeAboveIsInTheGardenPlot)
                            {
                                nrOfSides++;
                                lastXWithTopFence = x;
                            }
                        }
                        
                        var nodeBelowIsInTheGardenPlot = gardenPlot.Nodes.Any(n => n.X == x && n.Y == y - 1);
                        if (lastXWithBottomFence == x - 1)
                        {
                            if (!nodeBelowIsInTheGardenPlot)
                            {
                                lastXWithBottomFence = x;    
                            }
                        }
                        else
                        {
                            
                            if (!nodeBelowIsInTheGardenPlot)
                            {
                                nrOfSides++;
                                lastXWithBottomFence = x;
                            }
                        }
                    }
                }
            }
            Console.WriteLine($"A region of {gardenPlot.Nodes.First().Crop} plants with price {nrOfSides} * {gardenPlot.Nodes.Count} = {nrOfSides * gardenPlot.Nodes.Count}");
            totalPrice += nrOfSides * gardenPlot.Nodes.Count;
        }

        return totalPrice;
    }

    private int Fence(GardenNode node, GardenPlot gardenPlot)
    {
        var x = node.X;
        var y = node.Y;
        node.HasBeenMapped = true;
        gardenPlot.Nodes.Add(node);
        var nrOfFences = 0;
        if (x + 1 < _xMax && _map[x + 1, y].Crop == node.Crop && !_map[x + 1, y].HasBeenMapped)
        {
            nrOfFences += Fence(_map[x + 1, y], gardenPlot);
        }
        else
        {
            if (x + 1 >= _xMax || _map[x + 1, y].Crop != node.Crop)
            {
                nrOfFences++;    
            }
        }
        
        if (x - 1 >= 0 && _map[x - 1, y].Crop ==  node.Crop && !_map[x - 1, y].HasBeenMapped)
        {
            nrOfFences += Fence(_map[x -+ 1, y], gardenPlot);
        }
        else
        {
            if (x - 1 < 0 || _map[x - 1, y].Crop != node.Crop)
            {
                nrOfFences++;    
            }
        }
        
        if (y + 1 < _yMax && _map[x, y + 1].Crop ==  node.Crop && !_map[x, y + 1].HasBeenMapped)
        {
            nrOfFences += Fence(_map[x, y + 1], gardenPlot);
        }
        else
        {
            if (y + 1 >= _yMax || _map[x, y + 1].Crop != node.Crop)
            {
                nrOfFences++;
            }
        }
        
        if (y - 1 >= 0 && _map[x, y - 1].Crop ==  node.Crop && !_map[x, y - 1].HasBeenMapped)
        {
            nrOfFences += Fence(_map[x, y - 1], gardenPlot);
        }
        else
        {
            if (y - 1 < 0 || _map[x, y - 1].Crop != node.Crop)
            {
                nrOfFences++;
            }
        }

        return nrOfFences;
    }

    private class GardenPlot
    {
        public List<GardenNode> Nodes = [];
        public int NumberOfFences;
    }
}