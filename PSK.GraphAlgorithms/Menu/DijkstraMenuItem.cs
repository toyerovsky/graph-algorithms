using System.Diagnostics;
using PSK.GraphAlgorithms.Domain;

namespace PSK.GraphAlgorithms.Menu;

public class DijkstraMenuItem : IMenuItem
{
    public string Description => "Oblicz najlepszy wierzchołek algorytmem Dijkstry";

    private readonly IGraphSolver _solver;
    public DijkstraMenuItem()
    {
        _solver = new DijkstraSolver();
    }
    
    public void Run(ProgramState state)
    {
        var sw = Stopwatch.StartNew();
        var result = _solver.Calculate(state.Graph);
        sw.Stop();

        Console.WriteLine($"Ilość wierzchołków grafu {state.Graph.GraphSize}");      
        Console.WriteLine($"Index najkorzystniejszej krawędzi {result.VertexIndex}");        
        Console.WriteLine($"Koszt drogi {result.VertexRoadCost}");        
        Console.WriteLine($"Czas obliczenia {sw.Elapsed}");
    }
}