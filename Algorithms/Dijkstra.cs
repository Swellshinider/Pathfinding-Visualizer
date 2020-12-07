using System.Collections.Generic;
using System.Linq;
using Visualizer.Algorithms.Tools;
using Visualizer.Classes;

namespace Visualizer.Algorithms
{
    public class Dijkstra : Algorithms
    {
        private readonly List<Node> _openList = new List<Node>();
        private readonly List<Coord> _neighbours;

        public Dijkstra(Grid grid) : base(grid)
        {
            _algorithmName = "Dijkstra's";

            _neighbours = new List<Coord>();
            _openList.Add(new Node(_id++, null, _origin, 0, 0));
        }

        public override DetailsOfSearch GetPathTick()
        {
            if (_currentNode == null)
            {
                if (!_openList.Any()) return GetDetailsOfSearch();

                _currentNode = _openList.OrderBy(x => x.F).First();

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

                if (CoordsMatch(thisNeighbour, _destination))
                {
                    _path = new List<Coord> { thisNeighbour };
                    int? parentId = _currentNode.Id;
                    while (parentId.HasValue)
                    {
                        var nextNode = _closed.First(x => x.Id == parentId);
                        _path.Add(nextNode.Coord);
                        parentId = nextNode.ParentId;
                    }

                    _path.Reverse();

                    return GetDetailsOfSearch();
                }

                var cellWeight = _grid.GetBlock(thisNeighbour.X, thisNeighbour.Y).Cost;
                var neighbourCost = _currentNode.G + cellWeight;

                var openListItem = _openList.FirstOrDefault(x => x.Id == GetExistingNode(true, thisNeighbour));
                
                if (openListItem != null && openListItem.F > neighbourCost)
                {
                    openListItem.F = neighbourCost;
                    openListItem.ParentId = _currentNode.Id;
                }

                var closedListItem = _closed.FirstOrDefault(x => x.Id == GetExistingNode(false, thisNeighbour));
                
                if (closedListItem != null && closedListItem.F > neighbourCost)
                {
                    closedListItem.F = neighbourCost;
                    closedListItem.ParentId = _currentNode.Id;
                }

                if (openListItem != null || closedListItem != null) return GetDetailsOfSearch();
                _openList.Add(new Node(_id++, _currentNode.Id, thisNeighbour, _currentNode.G + cellWeight, 0));
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
                : GetManhattenDistance(_currentNode.Coord, _destination),
                OpenListSize = _openList.Count,
                ClosedListSize = _closed.Count,
                UnexploredListSize = _grid.GetCountOfType(BlockType.Empty),
                Operations = _operationsCount++
            };
        }
    }
}
