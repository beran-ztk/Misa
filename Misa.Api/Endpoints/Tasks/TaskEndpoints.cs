using Misa.Application.Items.Tasks.Queries;
using Misa.Contract.Common.Results;
using Misa.Contract.Items;
using Wolverine;

namespace Misa.Api.Endpoints.Tasks;

public static class TaskEndpoints
{
    public static void Map(WebApplication app)
    {
        app.MapGet("/items/tasks", GetTasks);
    }

    private static async Task<Result<List<ListTaskDto>>> GetTasks(IMessageBus bus, CancellationToken ct)
    {
        var res = await bus.InvokeAsync<Result<List<ListTaskDto>>>(new GetTasksQuery(), ct);
        return res;
    }
}