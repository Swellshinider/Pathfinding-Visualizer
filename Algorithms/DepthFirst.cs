using System.Collections.Generic;
using System.Linq;
using Visualizer.Algorithms.Tools;
using Visualizer.Classes;

namespace Visualizer.Algorithms
{
    public class DepthFirst : Algorithms
    {
        readonly Stack<Node> _stack = new Stack<Node>();

        public DepthFirst(Grid grid) : base(grid)
        {
            _algorithmName = "Depth-First";

            // Add the first node to the stack
            _stack.Push(new Node(_id++, null, _origin, 0, 0));
        }

        public override DetailsOfSearch GetPathTick()
        {
            if(_stack.Count == 0)
                return GetDetailsOfSearch();

            _currentNode = _stack.Peek();
            if (CoordsMatch(_currentNode.Coord, _destination))
            {
                _path = new List<Coord>();
                foreach (var item in _stack)
                    _path.Add(item.Coord);

                _path.Reverse();

                return GetDetailsOfSearch();
            }

            var neighbours = GetNeighbours(_currentNode).Where(x => !AlreadyVisited(new Coord(x.X, x.Y))).ToArray();
            if (neighbours.Any())
            {
                foreach (var neighbour in neighbours)
                    _grid.SetBlock(neighbour.X, neighbour.Y, BlockType.Open);

                var next = neighbours.First();
                var newNode = new Node(_id++, null, next.X, next.Y, 0, 0);
                _stack.Push(newNode);
                _grid.SetBlock(newNode.Coord.X, newNode.Coord.Y, BlockType.Current);
            }
            else
            {
                var abandonedCell = _stack.Pop();
                _grid.SetBlock(abandonedCell.Coord.X, abandonedCell.Coord.Y, BlockType.Closed);
                _closed.Add(abandonedCell);
            }

            return GetDetailsOfSearch();
        }

        private bool AlreadyVisited(Coord coord)
        {
            return _stack.Any(x => CoordsMatch(x.Coord, coord)) || _closed.Any(x => CoordsMatch(x.Coord, coord));
        }

        protected override DetailsOfSearch GetDetailsOfSearch()
        {
            return new DetailsOfSearch
            {
                Path = _path?.ToArray(),
                PathCost = GetPathCost(),
                LastNode = _currentNode,
                DistanceOfCurrentNode = _currentNode == null ? 0 : GetManhattenDistance(_currentNode.Coord, _destination),
                OpenListSize = _stack.Count,
                ClosedListSize = _closed.Count,
                UnexploredListSize = _grid.GetCountOfType(BlockType.Empty),
                Operations = _operationsCount++
            };
        }
    }
}
