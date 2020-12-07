using Visualizer.Classes;

namespace Visualizer.Algorithms.Tools
{
    public class DetailsOfSearch
    {
        public Coord[] Path { get; set; }
        public Node LastNode { get; set; }

        public bool PathPossible => (PathFound || OpenListSize > 0);
        public bool PathFound => Path != null;  
        
        public int PathCost { get; set; }
        public int DistanceOfCurrentNode { get; set; }
        public int OpenListSize { get; set; }
        public int ClosedListSize { get; set; }
        public int UnexploredListSize { get; set; }
        public int Operations { get; set; }
    }
}
