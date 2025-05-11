namespace Service;

public class ProductLogger : IProductLogger
{
    private readonly List<string> _logs = [];

    public void Log(string message)
    {
        _logs.Add($"[{DateTime.UtcNow}] {message}");
    }

    public List<string> GetLogs() => _logs;
}