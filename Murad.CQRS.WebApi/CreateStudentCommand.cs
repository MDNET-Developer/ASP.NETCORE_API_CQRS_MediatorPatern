using MediatR;

namespace Murad.CQRS.WebApi
{
    public class CreateStudentCommand:IRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int age { get; set; }
    }
}
