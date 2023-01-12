namespace PSK.GraphAlgorithms.Domain;

public class DijkstraSolver : IGraphSolver
{
    public VertexCalculation Calculate(Graph graph)
    {
        var results = new List<TempResult>();

        var bestVertex = new TempResult(int.MaxValue, -1);

        for (var i = 0; i < graph.GraphSize; i++)
        {
            results.Add(new TempResult(Dijkstra(i, graph), i));
        }

        foreach (var result in results)
        {
            if (result.RoadCost < bestVertex.RoadCost)
            {
                bestVertex = result;
            }
        }

        return new VertexCalculation
        {
            VertexIndex = bestVertex.Vertex,
            VertexRoadCost = bestVertex.RoadCost,
        };
    }

    private static int Dijkstra(int vertex, Graph graph)
    {
        var elements = new List<TempElement>();

        for (var i = 0; i < graph.GraphSize; i++)
        {
            elements.Add(new TempElement());
            elements[i].Distance = int.MaxValue;
            elements[i].Previous = -1;
            elements[i].IsCounted = false;
        }

        elements[vertex].Distance = 0;

        while (elements.Any(x => !x.IsCounted))
        {
            var u = FindMinDistanceElement(elements);

            elements[u].IsCounted = true;

            for (var i = 0; i < graph.GraphSize; i++)
            {
                if (graph.Adjacent(u, i) && u != i)
                {
                    if (elements[i].Distance > graph.GetVerticeLength(u, i) + elements[u].Distance)
                    {
                        elements[i].Distance = graph.GetVerticeLength(u, i) + elements[u].Distance;
                        elements[i].Previous = u;
                    }
                }
            }
        }

        return elements.Sum(item => item.Distance);
    }

    private static int FindMinDistanceElement(List<TempElement> elements)
    {
        var element = new TempElement {Distance = int.MaxValue};
        var index = -1;

        foreach (var item in elements)
        {
            if (item.Distance < element.Distance && !item.IsCounted)
            {
                element = item;
                index = elements.IndexOf(item);
            }
        }

        return index;
    }
}