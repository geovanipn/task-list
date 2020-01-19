
namespace TaskList.Application.Core
{
    public interface IApiInfo
    {
        string Title { get; }

        string RoutePrefix { get; }

        string RoutePrefixAlias { get; }

        string Version { get; }
    }
}
