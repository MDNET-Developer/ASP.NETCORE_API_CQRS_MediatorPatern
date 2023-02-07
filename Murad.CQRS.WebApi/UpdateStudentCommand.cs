using MediatR;

namespace Murad.CQRS.WebApi
{
    public class UpdateStudentCommand:IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int age { get; set; }
    }
}
