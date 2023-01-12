namespace PSK.GraphAlgorithms.Domain;

public class FloydWarshallSolver : IGraphSolver
{
    public VertexCalculation Calculate(Graph graph)
    {
        var resultMatrix = ResultWarshallMatrix(WarshallFirstMatrix(graph), graph);
        var results = new List<TempResult>();
        var bestVertex = new TempResult(int.MaxValue, -1);
        for (var i = 0; i < graph.GraphSize; i++)
        {
            var sum = 0;
            for (var j = 0; j < graph.GraphSize; j++)
            {
                sum += resultMatrix[i, j];
            }

            results.Add(new TempResult(sum, i));
        }

        foreach (var vertex in results)
        {
            if (vertex.RoadCost < bestVertex.RoadCost)
            {
                bestVertex = vertex;
            }
        }


        return new VertexCalculation()
        {
            VertexIndex = bestVertex.Vertex,
            VertexRoadCost = bestVertex.RoadCost,
        };
    }

    private static int[,] WarshallFirstMatrix(Graph graph)
    {
        var firstMatrix = new int[graph.GraphSize, graph.GraphSize];
        for (var i = 0; i < graph.GraphSize; i++)
        {
            for (var j = 0; j < graph.GraphSize; j++)
            {
                if (i == j)
                {
                    firstMatrix[i, j] = 0;
                }
                else
                {
                    if (graph.Adjacent(i, j))
                    {
                        firstMatrix[i, j] = graph.GetVerticeLength(i, j);
                    }
                    else
                    {
                        firstMatrix[i, j] = int.MaxValue;
                    }
                }
            }
        }

        return firstMatrix;
    }
    
    private static bool Adjacent(int vertexA, int vertexB, int[,] matrix)
    {
        return matrix[vertexA, vertexB] > 0 && matrix[vertexA, vertexB] != Int32.MaxValue;
    }

    private static int Length(int vertexU, int vertexV, int[,] matrix)
    {
        return matrix[vertexU, vertexV];
    }

    private static int[,] ResultWarshallMatrix(int[,] firstMatrix, Graph graph)
    {
        var resultMatrix = firstMatrix;
        for (var k = 0; k < graph.GraphSize; k++)
        {
            for (var i = 0; i < graph.GraphSize; i++)
            {
                for (var j = 0; j < graph.GraphSize; j++)
                {
                    if (i == k || j == k || i == j) continue;
                    if (FoundShorterPath(i, j, k, resultMatrix))
                    {
                        resultMatrix[i, j] = Length(i, k, resultMatrix) + Length(k, j, resultMatrix);
                    }
                }
            }
        }

        return resultMatrix;
    }

    private static bool FoundShorterPath(int i, int j, int k, int[,] matrix)
    {
        if (!Adjacent(i, j, matrix))
        {
            return Adjacent(i, k, matrix) && Adjacent(j, k, matrix);
        }

        if (!Adjacent(i, k, matrix) || !Adjacent(j, k, matrix))
            return false;

        return Length(i, j, matrix) > Length(i, k, matrix) + Length(k, j, matrix);
    }
}