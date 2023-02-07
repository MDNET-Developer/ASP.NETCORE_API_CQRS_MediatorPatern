using MediatR;
using Microsoft.EntityFrameworkCore;
using Murad.CQRS.WebApi.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Murad.CQRS.WebApi
{
    public class GetAllStudentsQueryHandler:IRequestHandler<GetAllStudentsQuery, IEnumerable<GetAllStudentsQueryResult>>
    {
       
        private readonly StudentContext _studentContext;

        public GetAllStudentsQueryHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        //public IEnumerable<GetAllStudentsQueryResult> Handle(GetAllStudentsQuery query)
        //{
        //    var allStudent = _studentContext.Set<Student>().Select(x=> new GetAllStudentsQueryResult {Name=x.Name,Surname=x.Surname,age=x.age}).AsNoTracking().AsEnumerable();

        //    return allStudent;
        //}


        //DIQQET  - IEnumerable adi qaydada yazsan eger AsEnumerable dan istifade edeceksen, yox asinxorn proqramlasdirma edirsense eger ToListAsync olacaq
        public async Task<IEnumerable<GetAllStudentsQueryResult>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var allStudentResult = await _studentContext.Set<Student>().Select(x => new GetAllStudentsQueryResult { Name = x.Name, Surname = x.Surname, age = x.age }).AsNoTracking().ToListAsync();
            return allStudentResult;
        }
    }
}
