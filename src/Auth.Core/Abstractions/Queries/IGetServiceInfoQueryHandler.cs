using Auth.Domain.Dtos;
using Auth.Domain.Http;

namespace Auth.Core.Abstractions.Queries
{
    public interface IGetServiceInfoQueryHandler : IRequestHandler<ServiceInfoDto, EmptyRequest>
    {
    }
}
