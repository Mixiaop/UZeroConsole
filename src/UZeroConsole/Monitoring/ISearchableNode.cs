namespace UZeroConsole.Monitoring
{
    public interface ISearchableNode
    {
        string Name { get; }
        string CategoryName { get; }
        MonitorStatus MonitorStatus { get; }
    }
}
