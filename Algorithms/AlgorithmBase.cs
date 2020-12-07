using System;
using System.Collections.Generic;
using System.Linq;
using Visualizer.Algorithms.Tools;
using Visualizer.Classes;

namespace Visualizer.Algorithms
{
    public abstract class AlgorithmBase
    {
        protected readonly Grid _grid;
        protected readonly List<Node> _closed;
        protected List<Coord> _path;
        protected readonly Coord _origin;
        protected readonly Coord _destination;
        protected int _id;
        protected Node _currentNode;
        protected int _operationsCount;
        public string algorithmName;

        protected AlgorithmBase(Grid grid)
        {
            _grid = grid;
            _closed = new List<Node>();
            _origin = _grid.GetStart().Coord;
            _destination = _grid.GetEnd().Coord;
            _operationsCount = 0;
            _id = 1;
        }

        public abstract DetailsOfSearch GetPathTick();

        protected virtual IEnumerable<Coord> GetNeighbours(Node current)
        {
            var neighbours = new List<Block>
            {
                _grid.GetBlock(current.Coord.X - 1, current.Coord.Y),
                _grid.GetBlock(current.Coord.X + 1, current.Coord.Y),
                _grid.GetBlock(current.Coord.X, current.Coord.Y - 1),
                _grid.GetBlock(current.Coord.X, current.Coord.Y + 1)
            };

            return neighbours
                .Where(x => x.Type != BlockType.Invalid && x.Type != BlockType.Solid)
                .Select(x => x.Coord)
                .ToArray();
        }

        protected abstract DetailsOfSearch GetDetailsOfSearch();

        protected static bool CoordsMatch(Coord a, Coord b) => a.X == b.X && a.Y == b.Y;

        protected static int GetManhattenDistance(Coord origin, Coord destination)
        {
            return Math.Abs(origin.X - destination.X) + Math.Abs(origin.Y - destination.Y);
        }

        protected int GetPathCost()
        {
            if (_path == null) return 0;

            var cost = 0;
            foreach (var step in _path)
                cost += _grid.GetBlock(step.X, step.Y).Weight;

            return cost;
        }
    }
}
