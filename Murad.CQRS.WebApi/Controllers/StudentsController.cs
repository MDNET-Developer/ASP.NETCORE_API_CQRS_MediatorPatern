using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Murad.CQRS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //private readonly GetStudentByIdQueryHandler _getStudent;
        //private readonly GetAllStudentsQueryHandler _getAllStudent;
        //private readonly CreateStudentCommandHandler _createStudent;
        //private readonly RemoveStudentCommandHandler _removeStudent;
        //private readonly UpdateStudentCommandHandler _updateStudent;

        //public StudentsController(GetStudentByIdQueryHandler getStudent, GetAllStudentsQueryHandler getAllStudent, CreateStudentCommandHandler createStudent, RemoveStudentCommandHandler removeStudent, UpdateStudentCommandHandler updateStudent)
        //{
        //    _getStudent = getStudent;
        //    _getAllStudent = getAllStudent;
        //    _createStudent = createStudent;
        //    _removeStudent = removeStudent;
        //    _updateStudent = updateStudent;
        //}

        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetStudents(int id)
        {
          var data = await  _mediator.Send(new GetStudentByIdQuery(id));
            return Ok(data);

        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var result = await _mediator.Send(new GetAllStudentsQuery());
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateStudent(CreateStudentCommand createStudent)
        {
             _mediator.Send(createStudent);
            return Ok(createStudent.Name + " adlı şagird uğurla əlavə olundu");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveStudent(int id )
        {
            await _mediator.Send(new RemoveStudentCommand(id));
            return Ok(id +  " -li şagird uğurla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent(UpdateStudentCommand command)
        {
            await _mediator.Send(command);
            return Ok(command.Name + " adlı şagird uğurla yeniləndi");
        }
    }
}
