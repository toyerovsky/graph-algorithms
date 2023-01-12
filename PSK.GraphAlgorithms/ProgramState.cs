using PSK.GraphAlgorithms.Domain;

namespace PSK.GraphAlgorithms;

public class ProgramState
{
    public bool Exit { get; set; } = false;
    public Graph Graph { get; } = GraphHelper.GetDefaultGraph();
}

public static class GraphHelper
{
    public static Graph GetDefaultGraph()
    {
        return new Graph
        {
            AdjacencyMatrix = new[]
            {
                new[] {0, 4, 0, 0, 0, 0, 0, 8, 0},
                new[] {4, 0, 8, 0, 0, 0, 0, 11, 0},
                new[] {0, 8, 0, 7, 0, 4, 0, 0, 2},
                new[] {0, 0, 7, 0, 9, 14, 0, 0, 0},
                new[] {0, 0, 0, 9, 0, 10, 0, 0, 0},
                new[] {0, 0, 4, 14, 10, 0, 2, 0, 0},
                new[] {0, 0, 0, 0, 0, 2, 0, 1, 6},
                new[] {8, 11, 0, 0, 0, 0, 1, 0, 7},
                new[] {0, 0, 2, 0, 0, 0, 6, 7, 0}
            }
        };
    }
}