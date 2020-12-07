using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visualizer.Algorithms.Tools;
using Visualizer.Classes;

namespace Visualizer.Algorithms
{
    public class BreadthFirst : AlgorithmBase
    {
        private readonly Queue<Node> _q = new Queue<Node>();
        private bool _destinationFound;

        public BreadthFirst(Grid grid) : base(grid)
        {
            algorithmName = "Breadth-First";
            _q.Enqueue(new Node(_id++, null, _origin, 0, 0));
        }

        public override DetailsOfSearch GetPathTick()
        {
            if (_q.Count > 0 && !_destinationFound)
            {
                _currentNode = _q.Dequeue();
                if (AlreadyVisited(_currentNode.Coord)) return GetDetailsOfSearch();

                _closed.Add(_currentNode);
                _grid.SetBlock(_currentNode.Coord.X, _currentNode.Coord.Y, BlockType.Closed);

                var neighbours = GetNeighbours(_currentNode);
                foreach (var neighbour in neighbours)
                {
                    if (AlreadyVisited(neighbour)) continue;

                    var neighbourNode = new Node(_id++, _currentNode.Id, neighbour.X, neighbour.Y, 0, 0);
                    _q.Enqueue(neighbourNode);
                    _grid.SetBlock(neighbour, BlockType.Open);

                    if (!CoordsMatch(neighbour, _destination)) continue;

                    _closed.Add(neighbourNode);
                    _destinationFound = true;
                }
            }
            else
            {
               _path = new List<Coord>();

                Node step;

                try
                {
                    step = _closed.First(x => CoordsMatch(x.Coord, _destination));
                } catch (InvalidOperationException)
                {
                    return GetDetailsOfSearch();
                }

                while (!CoordsMatch(step.Coord, _origin))
                {
                    _path.Add(step.Coord);
                    step = _closed.First(x => x.Id == step.ParentId);
                }

                _path.Add(_origin);
                _path.Reverse();
            }

            return GetDetailsOfSearch();
        }

        private bool AlreadyVisited(Coord coord)
        {
            return _closed.Any(x => CoordsMatch(x.Coord, coord));
        }

        protected override DetailsOfSearch GetDetailsOfSearch()
        {
            return new DetailsOfSearch
            {
                Path = _path?.ToArray(),
                PathCost = GetPathCost(),
                LastNode = _currentNode,
                DistanceOfCurrentNode = _currentNode == null ? 0 : GetManhattenDistance(_currentNode.Coord, _destination),
                OpenListSize = _q.Count,
                ClosedListSize = _closed.Count,
                UnexploredListSize = _grid.GetCountOfType(BlockType.Empty),
                Operations = _operationsCount++
            };
        }
    }
}
