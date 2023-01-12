namespace PSK.GraphAlgorithms.Domain;

public class Graph
{
    public int[][] AdjacencyMatrix { get; set; }

    public int this[int x, int y] => AdjacencyMatrix[x][y];

    public int GraphSize => AdjacencyMatrix?.Length ?? 0;
    
    public  bool Adjacent(int vertexA, int vertexB)
    {
        return this[vertexA, vertexB] > 0;
    }

    public int GetVerticeLength(int vertexU, int vertexV)
    {
        return this[vertexU, vertexV];
    }
}