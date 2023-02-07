using MediatR;
using Murad.CQRS.WebApi.Data;
using System.Text.Unicode;
using System.Threading;
using System.Threading.Tasks;

namespace Murad.CQRS.WebApi
{
    public class RemoveStudentCommandHandler:IRequestHandler<RemoveStudentCommand>
    {

        private readonly StudentContext _studentContext;

        public RemoveStudentCommandHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public void Handle(RemoveStudentCommand command)
        {
            var deletedId = _studentContext.Set<Student>().Find(command.Id);
            _studentContext.Remove(deletedId);
            _studentContext.SaveChanges();
        }

        public async Task<Unit> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            var deletedId = await _studentContext.Students.FindAsync(request.Id);
            _studentContext.Remove(deletedId);
           await  _studentContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
