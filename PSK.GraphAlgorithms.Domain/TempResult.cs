namespace PSK.GraphAlgorithms.Domain;

internal class TempResult
{
    public int RoadCost { get; set; }
    public int Vertex { get; set; }

    public TempResult(int roadCost, int vertex)
    {
        RoadCost = roadCost;
        Vertex = vertex;
    }
}