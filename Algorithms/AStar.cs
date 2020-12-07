using System.Collections.Generic;
using System.Linq;
using Visualizer.Algorithms.Tools;
using Visualizer.Classes;

namespace Visualizer.Algorithms
{
    public class AStar : Algorithms
    {
        private readonly List<Node> _openList = new List<Node>();
        private readonly List<Coord> _neighbours;

        public AStar(Grid grid) : base(grid)
        {
            _algorithmName = "A*";
            _neighbours = new List<Coord>();
            _openList.Add(new Node(_id++, null, _origin, 0, GetH(_origin, _destination)));
        }

        public override DetailsOfSearch GetPathTick()
        {
            if (_currentNode == null)
            {
                if (!_openList.Any()) return GetDetailsOfSearch();

                // Take the current node off the open list to be examined
                _currentNode = _openList.OrderBy(x => x.F).ThenBy(x => x.H).First();

                // Move it to the closed list so it doesn't get examined again
                _openList.Remove(_currentNode);
                _closed.Add(_currentNode);
                _grid.SetBlock(_currentNode.Coord, BlockType.Closed);

                _neighbours.AddRange(GetNeighbours(_currentNode));
            }

            if (_neighbours.Any())
            {
                _grid.SetBlock(_currentNode.Coord, BlockType.Current);

                var thisNeighbour = _neighbours.First();
                _neighbours.Remove(thisNeighbour);

                // If the neighbour is the destination
                if (CoordsMatch(thisNeighbour, _destination))
                {
                    // Construct the path by tracing back through the closed list until there are no more parent id references
                    _path = new List<Coord> { thisNeighbour };
                    int? parentId = _currentNode.Id;
                    while (parentId.HasValue)
                    {
                        var nextNode = _closed.First(x => x.Id == parentId);
                        _path.Add(nextNode.Coord);
                        parentId = nextNode.ParentId;
                    }

                    // Reorder the path to be from origin to destination and return
                    _path.Reverse();

                    return GetDetailsOfSearch();
                }

                // Get the cost of the current node plus the extra step weight and heuristic
                var hFromHere = GetH(thisNeighbour, _destination);
                var cellWeight = _grid.GetBlock(thisNeighbour.X, thisNeighbour.Y).Cost;
                var neighbourCost = _currentNode.G + cellWeight + hFromHere;

                // Check if the node is on the open list already and if it has a higher cost path
                var openListItem = _openList.FirstOrDefault(x => x.Id == GetExistingNode(true, thisNeighbour));
                if (openListItem != null && openListItem.F > neighbourCost)
                {
                    // Repoint the openlist node to use this lower cost path
                    openListItem.F = neighbourCost;
                    openListItem.ParentId = _currentNode.Id;
                }

                // Check if the node is on the closed list already and if it has a higher cost path
                var closedListItem = _closed.FirstOrDefault(x => x.Id == GetExistingNode(false, thisNeighbour));
                if (closedListItem != null && closedListItem.F > neighbourCost)
                {
                    // Repoint the closedlist node to use this lower cost path
                    closedListItem.F = neighbourCost;
                    closedListItem.ParentId = _currentNode.Id;
                }

                // If the neighbour node isn't on the open or closed list, add it
                if (openListItem != null || closedListItem != null) return GetDetailsOfSearch();
                _openList.Add(new Node(_id++, _currentNode.Id, thisNeighbour, _currentNode.G + cellWeight, hFromHere));
                _grid.SetBlock(thisNeighbour.X, thisNeighbour.Y, BlockType.Open);
            }
            else
            {
                _grid.SetBlock(_currentNode.Coord, BlockType.Closed);
                _currentNode = null;
                return GetPathTick();
            }

            return GetDetailsOfSearch();
        }

        private static int GetH(Coord origin, Coord destination)
        {
            return GetManhattenDistance(origin, destination);
        }

        private int? GetExistingNode(bool checkOpenList, Coord coordToCheck)
        {
            return checkOpenList 
                ? _openList.FirstOrDefault(x => CoordsMatch(x.Coord, coordToCheck))?.Id 
                : _closed.FirstOrDefault(x => CoordsMatch(x.Coord, coordToCheck))?.Id;
        }

        protected override DetailsOfSearch GetDetailsOfSearch()
        {
            return new DetailsOfSearch
            {
                Path = _path?.ToArray(),
                PathCost = GetPathCost(),
                LastNode = _currentNode,

                DistanceOfCurrentNode = _currentNode == null 
                ? 0 
                : GetH(_currentNode.Coord, _destination),

                OpenListSize = _openList.Count,
                ClosedListSize = _closed.Count,
                UnexploredListSize = _grid.GetCountOfType(BlockType.Empty),
                Operations = _operationsCount++
            };
        }
    }
}
