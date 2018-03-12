using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamResultProcessingService.ExamService
{
    public interface IExamServiceConfiguration
    {
        string ExamServiceUrl { get; }
    }
}
