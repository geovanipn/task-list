
namespace TaskList.Application.Core
{
    public class ApiInfo : IApiInfo
    {
        public string Title => "Supero TI | Task List";

        public string RoutePrefix => "supero";

        public string RoutePrefixAlias => "pc";

        public string Version => "v1";
    }
}
