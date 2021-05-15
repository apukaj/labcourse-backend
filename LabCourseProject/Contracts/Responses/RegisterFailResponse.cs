using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabCourseProject.Contracts.Responses
{
    public class RegisterFailResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
