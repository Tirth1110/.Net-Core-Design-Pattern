namespace Service;

public interface IProductLogger
{
    void Log(string message);
    List<string> GetLogs();
}