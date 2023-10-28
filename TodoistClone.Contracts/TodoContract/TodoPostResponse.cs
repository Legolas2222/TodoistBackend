using System.Threading.Channels;

namespace TodoistClone.Contracts.TodoContract {
    public record TodoPostResponse(
        Guid Id
    );
}