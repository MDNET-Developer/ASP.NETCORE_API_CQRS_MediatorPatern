using MediatR;
using Murad.CQRS.WebApi.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Murad.CQRS.WebApi
{
    public class CreateStudentCommandHandler: IRequestHandler<CreateStudentCommand>
    {
        private readonly StudentContext _contextStudent;

        public CreateStudentCommandHandler(StudentContext contextStudent)
        {
            _contextStudent = contextStudent;
        }

        public void  Handle(CreateStudentCommand createStudent)
        {
            _contextStudent.Add(new Student { Name = createStudent.Name, Surname = createStudent.Surname, age = createStudent.age });
            _contextStudent.SaveChanges();
        }

        public  async Task<Unit> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
             _contextStudent.Add(new Student { Name = request.Name, Surname = request.Surname, age = request.age });
           await  _contextStudent.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
