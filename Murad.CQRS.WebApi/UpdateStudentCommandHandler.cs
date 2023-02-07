using MediatR;
using Murad.CQRS.WebApi.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Murad.CQRS.WebApi
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
    {
        private readonly StudentContext _studentContext;

        public UpdateStudentCommandHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public void Handle(UpdateStudentCommand command)
        {
            var getId = _studentContext.Set<Student>().Find(command.Id);
            command.Surname = getId.Surname;
            command.Name = getId.Name;
            command.age = getId.age;
            _studentContext.Update(getId);
            _studentContext.SaveChanges();

        }

        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var getId = await _studentContext.Students.FindAsync(request.Id);
            getId.Surname= request.Surname;
            getId.Name = request.Name;
            getId.age = request.age;
            await _studentContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
