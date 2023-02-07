using MediatR;

namespace Murad.CQRS.WebApi
{
    public class RemoveStudentCommand:IRequest
    {
        public int Id { get; set; }
        public RemoveStudentCommand(int id)
        {
            Id = id;
        }

        
    }
}
