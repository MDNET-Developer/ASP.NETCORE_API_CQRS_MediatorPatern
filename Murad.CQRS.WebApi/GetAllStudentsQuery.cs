using MediatR;
using System.Collections.Generic;

namespace Murad.CQRS.WebApi
{
    public class GetAllStudentsQuery:IRequest<IEnumerable<GetAllStudentsQueryResult>>
    {
    }
}
