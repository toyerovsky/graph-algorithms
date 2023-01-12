namespace PSK.GraphAlgorithms.Menu;

public interface IMenuItem
{
    public string Description { get; }
    public void Run(ProgramState state);
}